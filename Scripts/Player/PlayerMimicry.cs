// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A06 — RF03/RF04; integração A05
// Descrição do Módulo: Absorção, comandos e usos transitórios separados da aparência.
// Entradas / Sinais Emitidos: E/K/1/2; StateChanged; sessão lógica.
// Pontos de Curadoria Humana: limites por ciclo, morte e coerência visual.
// ============================================================================
using Godot;
using Cyra.Core;
using Cyra.Enemies;
using System;
using System.Linq;
namespace Cyra.Player;
public partial class PlayerMimicry : Node
{
    [Export] public bool Enabled { get; set; }
    [Export] public float AbsorbRange { get; set; } = 90;
    [Export] public double AbsorbDuration { get; set; } = 0.20;
    [Export] public float ExtraJumpVelocity { get; set; } = -380;
    [Export] public float DashSpeed { get; set; } = 520;
    [Export] public double DashDuration { get; set; } = 0.18;
    [Export] public double DashInterval { get; set; } = 0.65;
    [Signal] public delegate void StateChangedEventHandler();
    public MimicrySession Session { get; private set; } = null!;
    public bool ExtraUsed { get; private set; }
    public bool AirDashUsed { get; private set; }
    public bool IsAbsorbing => _absorb > 0;
    public bool IsDashing => _dash > 0;
    public bool Locked => IsAbsorbing || IsDashing;
    public int DashDirection { get; private set; } = 1;
    private double _absorb, _dash, _cooldown;
    private BasicEnemy? _target;
    private PlayerController _player = null!;
    public override void _Ready()
    {
        _player = GetParent<PlayerController>();
        Session = GetNode<MimicrySession>("/root/MimicrySession");
        AbsorbRange = Math.Max(1, AbsorbRange); AbsorbDuration = Math.Max(0.05, AbsorbDuration);
        DashSpeed = Math.Max(1, DashSpeed); DashDuration = Math.Max(0.05, DashDuration);
        DashInterval = Math.Max(DashDuration, DashInterval); ExtraJumpVelocity = Math.Min(-1, ExtraJumpVelocity);
        Session.Changed += Notify;
    }
    private void Notify() => EmitSignal(SignalName.StateChanged);
    public void Tick(double delta)
    {
        if (!Enabled) return;
        _cooldown = Math.Max(0, _cooldown - delta);
        _dash = Math.Max(0, _dash - delta);
        if (!IsAbsorbing) return;
        _absorb = Math.Max(0, _absorb - delta);
        if (IsAbsorbing) return;
        string reason = Reason(_target);
        bool accepted = reason == "ok" && _target!.TryAbsorb();
        if (accepted) Session.Acquire(_target!.AbilityId); // Duplicate acquisition preserves active and usages.
        TestRunRecorder.RecordEvent("A06_absorb_result", new { target = _target?.TechnicalId, accepted, reason = accepted ? "completed" : reason, active = Session.Active });
        _target = null; Notify();
    }
    private string Reason(BasicEnemy? enemy)
    {
        if (_player.Health.IsDepleted) return "player_dead";
        if (enemy == null || !GodotObject.IsInstanceValid(enemy)) return "no_target";
        if (enemy.IsAbsorbed) return "unavailable";
        if (enemy.AbilityId != MimicrySession.A && enemy.AbilityId != MimicrySession.B) return "not_copyable";
        if (_player.GlobalPosition.DistanceTo(enemy.GlobalPosition) > AbsorbRange) return "out_of_range";
        return enemy.IsStunned ? "ok" : "target_alive";
    }
    public bool TryAbsorb()
    {
        if (!Enabled) return false;
        var enemies = GetTree().GetNodesInGroup("mimicry_targets").OfType<BasicEnemy>()
            .OrderBy(e => _player.GlobalPosition.DistanceSquaredTo(e.GlobalPosition))
            .ThenBy(e => e.TechnicalId, StringComparer.Ordinal).ThenBy(e => e.GetInstanceId()).ToArray();
        var target = enemies.FirstOrDefault(e => Reason(e) == "ok") ?? enemies.FirstOrDefault();
        string reason = _player.Health.IsDepleted ? "player_dead" : Locked || _player.IsAttacking ? "action_busy" : Reason(target);
        TestRunRecorder.RecordEvent("A06_absorb_attempt", new { target = target?.TechnicalId, reason, active = Session.Active });
        if (reason != "ok") { TestRunRecorder.RecordEvent("A06_absorb_result", new { target = target?.TechnicalId, accepted = false, reason }); return false; }
        _target = target; _absorb = AbsorbDuration; Notify(); return true;
    }
    public bool TrySwitch(string id)
    {
        if (!Enabled) return false;
        string previous = Session.Active;
        string reason = _player.Health.IsDepleted ? "player_dead" : Locked || _player.IsAttacking ? "action_busy" : !Session.Owns(id) ? "not_acquired" : "ok";
        if (reason == "ok") Session.Equip(id);
        TestRunRecorder.RecordEvent("A06_switch", new { requested = id, previous, current = Session.Active, accepted = reason == "ok", reason, extra_used = ExtraUsed, air_dash_used = AirDashUsed });
        return reason == "ok";
    }
    public bool TryExtraJump()
    {
        if (!Enabled || _player.Health.IsDepleted || Locked || Session.Active != MimicrySession.A || ExtraUsed) return false;
        ExtraUsed = true;
        TestRunRecorder.RecordEvent("A06_extra_jump", new { id = Session.Active, previous_used = false, current_used = true }); Notify(); return true;
    }
    public bool TryDash(int direction, bool onFloor)
    {
        if (!Enabled) return false;
        string reason = _player.Health.IsDepleted ? "player_dead" : Locked || _player.IsAttacking ? "action_busy" : Session.Active != MimicrySession.B ? "wrong_active" : _cooldown > 0 ? "cooldown" : !onFloor && AirDashUsed ? "air_use_spent" : "ok";
        if (reason == "ok")
        {
            _dash = DashDuration; _cooldown = DashInterval; DashDirection = direction;
            if (!onFloor) AirDashUsed = true;
            Notify();
        }
        TestRunRecorder.RecordEvent("A06_dash", new { accepted = reason == "ok", reason, direction, on_floor = onFloor, air_used = AirDashUsed, duration = DashDuration, speed = DashSpeed });
        return reason == "ok";
    }
    public void MarkAirborneDash()
    {
        if (Enabled && IsDashing && !AirDashUsed) { AirDashUsed = true; Notify(); TestRunRecorder.RecordEvent("A06_air_dash_consumed", new { reason = "dash_left_floor" }); }
    }
    public void Land()
    {
        if (!Enabled) return;
        bool extra = ExtraUsed, dash = AirDashUsed;
        ExtraUsed = false; AirDashUsed = false;
        TestRunRecorder.RecordEvent("A06_uses_restored", new { reason = "landing", previous_extra_used = extra, previous_air_used = dash, extra_used = false, air_used = false }); Notify();
    }
    public void Cancel()
    {
        if (IsAbsorbing) TestRunRecorder.RecordEvent("A06_absorb_result", new { target = _target?.TechnicalId, accepted = false, reason = "player_dead" });
        _target = null; _absorb = 0; _dash = 0;
    }
    public override void _ExitTree() => Session.Changed -= Notify;
}
