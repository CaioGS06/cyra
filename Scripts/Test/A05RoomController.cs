// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A05 — sala repetível e reinício de apoio RF01/RF02
// Descrição do Módulo: reiniciar a sala no ponto local, mantendo o autoload de logs.
// Entradas / Sinais Emitidos: player_restart, Button.Pressed, Player.Died.
// Pontos de Curadoria Humana: retorno, inimigo restaurado e ausência de duplicações.
// ============================================================================
using Godot;
using Cyra.Core;
using Cyra.Player;
using Cyra.Enemies;

namespace Cyra.Test;

public partial class A05RoomController : Node2D
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
        TestRunRecorder.RecordEvent("A05_room_ready", new { scenario = "A05", cycle = _cycle, player_health = _player.Health.Current, enemy_health = enemy.Health.Current });
        if (_returnAfterDeath)
        {
            _returnAfterDeath = false;
            TestRunRecorder.RecordEvent("A05_safe_return", new { entity = "player", cycle = _cycle, current = _player.Health.Current, maximum = _player.Health.Maximum, safe_point = "a05_safe", x = _player.Position.X, y = _player.Position.Y, enemy_health = enemy.Health.Current });
        }
    }

    public override void _UnhandledInput(InputEvent input)
    {
        if (input.IsActionPressed("player_restart") && !input.IsEcho()) OnManualRestart();
    }

    private void OnManualRestart()
    {
        if (_reloadQueued) return;
        TestRunRecorder.RecordEvent("A05_room_reset", new { reason = "manual", cycle = _cycle });
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
            if (result != Error.Ok) GD.PushError($"A05: falha ao reiniciar a sala: {result}");
        }).CallDeferred();
    }

    public override void _ExitTree()
    {
        _player.Died -= OnPlayerDied;
        _restart.Pressed -= OnManualRestart;
    }
}
