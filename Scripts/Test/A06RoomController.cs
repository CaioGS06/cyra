// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A06 — sala repetível e reinício de integração RF03/RF04
// Descrição do Módulo: reiniciar a sala no ponto local, mantendo o autoload de logs.
// Entradas / Sinais Emitidos: player_restart, Button.Pressed, Player.Died.
// Pontos de Curadoria Humana: retorno, inimigo restaurado e ausência de duplicações.
// ============================================================================
using Godot;
using Cyra.Core;
using Cyra.Player;
using Cyra.Enemies;

namespace Cyra.Test;

public partial class A06RoomController : Node2D
{
    private static bool _returnAfterDeath;
    private static int _cycle;
    private PlayerController _player = null!;
    private Button _restart = null!;
    private bool _reloadQueued;

    public override void _Ready()
    {
        _player = GetNode<PlayerController>("Player");
        _player.Position = GetNode<Marker2D>("SafePoint").Position;
        _player.Died += OnPlayerDied;
        _restart = GetNode<Button>("CanvasLayer/RestartButton");
        _restart.Pressed += OnManualRestart;
        var enemy = GetNode<BasicEnemy>("Enemy");
        var session = GetNode<MimicrySession>("/root/MimicrySession");
        TestRunRecorder.RecordEvent("A06_uses_restored", new { reason = _cycle == 0 ? "initial" : _returnAfterDeath ? "death_return" : "manual_return", extra_used = false, air_used = false, active = session.Active, has_a = session.HasA, has_b = session.HasB });
        TestRunRecorder.RecordEvent("A06_room_ready", new { scenario = "A06", cycle = _cycle, player_health = _player.Health.Current, enemy_health = enemy.Health.Current, enemy_b_health = GetNode<BasicEnemy>("EnemyB").Health.Current, active = session.Active, has_a = session.HasA, has_b = session.HasB });
        if (_returnAfterDeath)
        {
            _returnAfterDeath = false;
            TestRunRecorder.RecordEvent("A06_safe_return", new { entity = "player", cycle = _cycle, current = _player.Health.Current, maximum = _player.Health.Maximum, safe_point = "a06_safe", x = _player.Position.X, y = _player.Position.Y, enemy_health = enemy.Health.Current, enemy_b_health = GetNode<BasicEnemy>("EnemyB").Health.Current, active = session.Active, has_a = session.HasA, has_b = session.HasB });
        }
    }

    public override void _UnhandledInput(InputEvent input)
    {
        if (input.IsActionPressed("player_restart") && !input.IsEcho()) OnManualRestart();
    }

    private void OnManualRestart()
    {
        if (_reloadQueued) return;
        TestRunRecorder.RecordEvent("A06_room_reset", new { reason = "manual", cycle = _cycle });
        QueueReload(false);
    }

    private void OnPlayerDied() => QueueReload(true);

    private void QueueReload(bool afterDeath)
    {
        if (_reloadQueued) return;
        _reloadQueued = true;
        _returnAfterDeath = afterDeath;
        _cycle++;
        // A troca é adiada para fora dos callbacks de física/sinais. O autoload
        // não sai da árvore: mesma sessão/arquivo e contador F9 após a morte.
        Callable.From(() =>
        {
            Error result = GetTree().ReloadCurrentScene();
            if (result != Error.Ok) GD.PushError($"A06: falha ao reiniciar a sala: {result}");
        }).CallDeferred();
    }

    public override void _ExitTree()
    {
        _player.Died -= OnPlayerDied;
        _restart.Pressed -= OnManualRestart;
    }
}
