// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A03 — coleta de mensagens e erros da engine
// Descrição do Módulo: encaminhar callbacks nativos a uma fila limitada e segura.
// Entradas / Sinais Emitidos: Logger._LogMessage e _LogError; sem sinais próprios.
// Pontos de Curadoria Humana: erro/aviso capturado sem recursão nem travar jogo.
// ============================================================================
using Godot;

namespace Cyra.Core;

public partial class TestEngineLogger : Logger
{
    internal TestRunRecorder? Owner { get; set; }

    public override void _LogMessage(string message, bool error)
    {
        Owner?.Enqueue("engine_message", new { message = Clip(message), stderr = error });
    }

    public override void _LogError(string function, string file, int line, string code, string rationale,
        bool editorNotify, int errorType, Godot.Collections.Array<ScriptBacktrace> scriptBacktraces)
    {
        // Callbacks podem ocorrer em outras threads; não escrever disco nem usar GD aqui.
        Owner?.Enqueue("engine_error", new
        {
            function = Clip(function), file = Clip(file), line,
            code = Clip(code), rationale = Clip(rationale), error_type = errorType
        });
    }

    private static string Clip(string value) => value.Length > 4096 ? value[..4096] : value;
}
