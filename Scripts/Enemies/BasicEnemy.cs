// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A05 — RF02
// Descrição do Módulo: patrulhar, causar contato e permanecer atordoado a zero.
// Entradas / Sinais Emitidos: ReceiveAttack; Health.Depleted; Stunned.
// Pontos de Curadoria Humana: piso/parede, contato limitado e atordoamento sem prazo.
// ============================================================================
using Godot;
using Cyra.Core;
using Cyra.Player;
using System;

namespace Cyra.Enemies;

public partial class BasicEnemy : CharacterBody2D
{
    [Export] public string TechnicalId { get; set; } = "enemy_01";
    [Export(PropertyHint.Range, "1,200,1")] public float PatrolSpeed { get; set; } = 55;
    [Export(PropertyHint.Range, "1,300,1")] public float PatrolDistance { get; set; } = 70;
    [Export(PropertyHint.Range, "1,100,1")] public int ContactDamage { get; set; } = 1;
    [Signal] public delegate void StunnedEventHandler();
    public Health Health { get; private set; } = null!;
    public bool IsStunned { get; private set; }
    private Area2D _contact = null!;
    private RayCast2D _floorAhead = null!;
    private ColorRect _visual = null!;
    private Label _label = null!;
    private float _originX;
    private int _direction = -1;

    public override void _Ready()
    {
        Health = GetNode<Health>("Health");
        Health.EntityId = TechnicalId;
        Health.Depleted += OnDepleted;
        _contact = GetNode<Area2D>("ContactArea");
        _floorAhead = GetNode<RayCast2D>("FloorAhead");
        _visual = GetNode<ColorRect>("Visual");
        _label = GetNode<Label>("StateLabel");
        _originX = Position.X;
        PatrolSpeed = Math.Max(1, PatrolSpeed);
        PatrolDistance = Math.Max(1, PatrolDistance);
        ContactDamage = Math.Max(1, ContactDamage);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        if (!IsOnFloor()) velocity += GetGravity() * (float)delta;
        if (!IsStunned)
        {
            _floorAhead.Position = new Vector2(_direction * 26, 0);
            _floorAhead.ForceRaycastUpdate();
            if (IsOnFloor() && (IsOnWall() || !_floorAhead.IsColliding()
                || (_direction < 0 && Position.X <= _originX - PatrolDistance)
                || (_direction > 0 && Position.X >= _originX + PatrolDistance)))
                _direction *= -1;
        }
        velocity.X = IsStunned ? 0 : _direction * PatrolSpeed;
        Velocity = velocity;
        MoveAndSlide();
        if (IsStunned) return;
        foreach (Node2D body in _contact.GetOverlappingBodies())
        {
            if (body is PlayerController player)
            {
                int previous = player.Health.Current;
                if (player.TryReceiveDamage(ContactDamage, TechnicalId))
                    TestRunRecorder.RecordEvent("A05_damage_applied", new { source = TechnicalId, target = "player", requested_damage = ContactDamage, amount = previous - player.Health.Current, previous, current = player.Health.Current });
            }
        }
    }

    public bool ReceiveAttack(int amount) => !IsStunned && Health.ApplyDamage(amount, "player_attack");

    private void OnDepleted()
    {
        if (IsStunned) return;
        IsStunned = true;
        Velocity = Vector2.Zero;
        _visual.Color = new Color(0.95f, 0.75f, 0.2f);
        _label.Text = "Atordoado — sem absorção na A05";
        _contact.SetDeferred(Area2D.PropertyName.Monitoring, false);
        TestRunRecorder.RecordEvent("A05_stunned", new { entity = TechnicalId, previous = "patrol", current = "stunned", health = Health.Current });
        EmitSignal(SignalName.Stunned);
    }

    public override void _ExitTree() => Health.Depleted -= OnDepleted;
}
