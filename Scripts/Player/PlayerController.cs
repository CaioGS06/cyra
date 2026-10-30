// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A05 — RF01/RF02
// Descrição do Módulo: entrada, física, ataque curto e proteção de dano do jogador.
// Entradas / Sinais Emitidos: player_left/right/jump/attack; Died, AttackStarted.
// Pontos de Curadoria Humana: piso, direção/alcance, alvo único e intervalo de dano.
// ============================================================================
using Godot;
using Cyra.Core;
using Cyra.Enemies;
using System;
using System.Collections.Generic;

namespace Cyra.Player;

public partial class PlayerController : CharacterBody2D
{
    [Export(PropertyHint.Range, "1,600,1")] public float Speed { get; set; } = 220;
    [Export(PropertyHint.Range, "-800,-1,1")] public float JumpVelocity { get; set; } = -380;
    [Export(PropertyHint.Range, "1,100,1")] public int AttackDamage { get; set; } = 1;
    [Export(PropertyHint.Range, "0.05,1,0.01")] public double AttackDuration { get; set; } = 0.16;
    [Export(PropertyHint.Range, "0.05,2,0.01")] public double AttackInterval { get; set; } = 0.45;
    [Export(PropertyHint.Range, "0.05,3,0.05")] public double HurtInterval { get; set; } = 0.8;
    [Export(PropertyHint.Range, "1,100,1")] public float AttackOffset { get; set; } = 40;

    [Signal] public delegate void DiedEventHandler();
    [Signal] public delegate void AttackStartedEventHandler(int attackId, int direction);

    public Health Health { get; private set; } = null!;
    public bool IsAttacking => _attackRemaining > 0;
    private Area2D _attackArea = null!;
    private CollisionShape2D _attackShape = null!;
    private ColorRect _attackVisual = null!;
    private ColorRect _visual = null!;
    private readonly HashSet<ulong> _hitTargets = new();
    private double _attackRemaining, _attackCooldown, _hurtRemaining, _damageFlash;
    private int _facing = 1, _attackId, _motionDirection;

    public override void _Ready()
    {
        Health = GetNode<Health>("Health");
        Health.Depleted += OnDepleted;
        _attackArea = GetNode<Area2D>("AttackArea");
        _attackShape = GetNode<CollisionShape2D>("AttackArea/CollisionShape2D");
        _attackVisual = GetNode<ColorRect>("AttackArea/Visual");
        _visual = GetNode<ColorRect>("Visual");
        AttackDuration = Math.Max(0.05, AttackDuration);
        AttackInterval = Math.Max(AttackDuration, AttackInterval);
        HurtInterval = Math.Max(0.05, HurtInterval);
        Speed = Math.Max(1, Speed);
        JumpVelocity = Math.Min(-1, JumpVelocity);
        AttackOffset = Math.Max(1, AttackOffset);
        AttackDamage = Math.Max(1, AttackDamage);
        _attackVisual.Visible = false;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Health.IsDepleted) return;
        _attackCooldown = Math.Max(0, _attackCooldown - delta);
        _hurtRemaining = Math.Max(0, _hurtRemaining - delta);
        _damageFlash = Math.Max(0, _damageFlash - delta);
        _visual.Color = _damageFlash > 0 ? new Color(1, 0.25f, 0.25f) : new Color(0.3f, 0.7f, 0.95f);

        float direction = Input.GetAxis("player_left", "player_right");
        if (direction != 0) _facing = direction > 0 ? 1 : -1;
        Vector2 velocity = Velocity;
        velocity.X = direction * Speed;
        bool wasOnFloor = IsOnFloor();
        if (!wasOnFloor) velocity += GetGravity() * (float)delta;
        if (Input.IsActionJustPressed("player_jump") && wasOnFloor)
        {
            velocity.Y = JumpVelocity;
            TestRunRecorder.RecordEvent("A05_jump", new { entity = "player", x = Position.X, y = Position.Y });
        }
        Velocity = velocity;
        MoveAndSlide();
        if (!wasOnFloor && IsOnFloor())
            TestRunRecorder.RecordEvent("A05_landing", new { entity = "player", x = Position.X, y = Position.Y });

        // Registrar só mudanças de movimento real, inclusive parada na parede.
        float realX = GetRealVelocity().X;
        int motion = Math.Abs(realX) < 0.1f ? 0 : Math.Sign(realX);
        if (motion != _motionDirection)
        {
            TestRunRecorder.RecordEvent("A05_movement", new { entity = "player", previous = _motionDirection, direction = motion, x = Position.X });
            _motionDirection = motion;
        }

        if (Input.IsActionJustPressed("player_attack") && !IsAttacking && _attackCooldown <= 0)
            BeginAttack();
        if (IsAttacking)
        {
            ResolveAttack();
            _attackRemaining = Math.Max(0, _attackRemaining - delta);
            _attackVisual.Visible = IsAttacking;
        }
    }

    private void BeginAttack()
    {
        _attackId++;
        _attackRemaining = AttackDuration;
        _attackCooldown = AttackInterval;
        _hitTargets.Clear();
        _attackArea.Position = new Vector2(_facing * AttackOffset, 0);
        _attackVisual.Visible = true;
        TestRunRecorder.RecordEvent("A05_attack", new { entity = "player", attack_id = _attackId, direction = _facing, damage = AttackDamage, duration = AttackDuration, interval = AttackInterval });
        EmitSignal(SignalName.AttackStarted, _attackId, _facing);
    }

    private void ResolveAttack()
    {
        // Consulta nativa imediata: não depende do cache de overlaps da Area2D
        // após virar a direção. O volume continua editável na CollisionShape2D.
        var query = new PhysicsShapeQueryParameters2D
        {
            Shape = _attackShape.Shape,
            Transform = _attackShape.GlobalTransform,
            CollisionMask = _attackArea.CollisionMask,
            CollideWithBodies = true,
            CollideWithAreas = false
        };
        foreach (var hit in GetWorld2D().DirectSpaceState.IntersectShape(query))
        {
            if (hit["collider"].AsGodotObject() is not BasicEnemy enemy) continue;
            if (!_hitTargets.Add(enemy.GetInstanceId())) continue;
            int previous = enemy.Health.Current;
            if (enemy.ReceiveAttack(AttackDamage))
                TestRunRecorder.RecordEvent("A05_damage_applied", new { source = "player", target = enemy.TechnicalId, requested_damage = AttackDamage, amount = previous - enemy.Health.Current, attack_id = _attackId, previous, current = enemy.Health.Current });
        }
    }

    public bool TryReceiveDamage(int amount, string source)
    {
        if (Health.IsDepleted || _hurtRemaining > 0 || amount <= 0) return false;
        _hurtRemaining = HurtInterval;
        _damageFlash = 0.15;
        int previous = Health.Current;
        bool applied = Health.ApplyDamage(amount, source);
        if (applied)
            TestRunRecorder.RecordEvent("A05_damage_received", new { entity = "player", source, previous, current = Health.Current, interval = HurtInterval });
        return applied;
    }

    private void OnDepleted()
    {
        _attackRemaining = 0;
        _attackVisual.Visible = false;
        Velocity = Vector2.Zero;
        TestRunRecorder.RecordEvent("A05_death", new { entity = "player", current = Health.Current });
        EmitSignal(SignalName.Died);
    }

    public override void _ExitTree() => Health.Depleted -= OnDepleted;
}
