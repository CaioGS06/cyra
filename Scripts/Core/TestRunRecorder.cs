// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A03 — coleta local para curadoria e avaliação (RNF01/RNF04)
// Descrição do Módulo: registrar sessões optativas de teste, sem decidir aprovação.
// Entradas / Sinais Emitidos: --cyra-test; F9 marca etapa; notificações de foco.
// Pontos de Curadoria Humana: modo comum sem logs; modo teste, arquivos e falhas.
// ============================================================================
using Godot;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Cyra.Core;

public partial class TestRunRecorder : Node
{
    private const long MaxBytes = 25 * 1024 * 1024;
    private const int QueueLimit = 512;
    private static TestRunRecorder? _instance;
    private readonly ConcurrentQueue<(string Kind, object? Data, double Seconds)> _pending = new();
    private readonly Stopwatch _clock = new();
    private StreamWriter? _writer;
    private Process? _process;
    private TestEngineLogger? _engineLogger;
    private int _queued;
    private int _dropped;
    private int _step;
    private long _bytes;
    private double _nextSample;
    private volatile bool _failed;
    private volatile bool _capped;
    private string _session = "";

    public override void _Ready()
    {
        SetProcess(false);
        SetProcessInput(false);
        if (!Array.Exists(OS.GetCmdlineUserArgs(), a => a == "--cyra-test"))
            return;

        _clock.Start();
        _session = DateTime.UtcNow.ToString("yyyyMMddTHHmmssfffZ") + "-" + Guid.NewGuid().ToString("N")[..8];
        try
        {
            string folder = Option("--cyra-output=") ?? ProjectSettings.GlobalizePath("user://test_runs/" + _session);
            Directory.CreateDirectory(folder);
            // CreateNew impede que uma execução sobrescreva a evidência de outra.
            _writer = new StreamWriter(new FileStream(Path.Combine(folder, "session.jsonl"), FileMode.CreateNew, System.IO.FileAccess.Write, FileShare.Read), new UTF8Encoding(false)) { NewLine = "\n" };
            _process = Process.GetCurrentProcess();
            _instance = this;
            Write("session_start", new
            {
                schema = 1,
                protocol = Option("--cyra-protocol=") ?? "A03-v2",
                machine_label = Option("--cyra-machine=") ?? "nao_informada",
                build_label = Option("--cyra-build=") ?? "nao_informada",
                scenario = Option("--cyra-scenario=") ?? "A01",
                engine = Engine.GetVersionInfo()["string"].AsString(),
                os = OS.GetName(), os_version = OS.GetVersion(),
                cpu = OS.GetProcessorName(), gpu = RenderingServer.GetVideoAdapterName(),
                physical_memory_bytes = OS.GetMemoryInfo()["physical"].AsInt64(),
                runtime = System.Environment.Version.ToString(), pid = _process.Id,
                debug_build = OS.IsDebugBuild(), editor = OS.HasFeature("editor"),
                headless = DisplayServer.GetName() == "headless",
                renderer = RenderingServer.GetCurrentRenderingMethod(),
                window_width = DisplayServer.WindowGetSize().X,
                window_height = DisplayServer.WindowGetSize().Y,
                vsync = DisplayServer.WindowGetVsyncMode().ToString(), max_fps = Engine.MaxFps,
                sample_interval_seconds = 1, max_log_bytes = MaxBytes,
                supported_game_events = new[] { "A01_scene_ready", "A01_input_first", "A01_landing", "A01_jump", "A01_ui_signal", "A01_trigger" }
            });
            _engineLogger = new TestEngineLogger { Owner = this };
            OS.AddLogger(_engineLogger);
            _writer.Flush();
            _nextSample = 1;
            SetProcess(true);
            SetProcessInput(true);
            GD.Print("A03: teste ativo; F9 marca a próxima etapa. Logs: " + folder);
        }
        catch (Exception ex) when (IsFileError(ex))
        {
            Disable(ex);
        }
    }

    // Eventos de domínio devem ser emitidos pelo módulo real, na thread principal.
    // A05–A07 acrescentarão chamadas quando suas mecânicas existirem.
    public static void RecordEvent(string name, object? data = null) => _instance?.Enqueue(name, data);

    internal void Enqueue(string kind, object? data)
    {
        if (_failed || _capped) return;
        if (Interlocked.Increment(ref _queued) > QueueLimit)
        {
            Interlocked.Decrement(ref _queued);
            Interlocked.Increment(ref _dropped);
            return;
        }
        _pending.Enqueue((kind, data, _clock.Elapsed.TotalSeconds));
    }

    public override void _Process(double delta)
    {
        if (_writer == null || _failed || _capped) return;
        try
        {
            Drain();
            double now = _clock.Elapsed.TotalSeconds;
            if (now < _nextSample) return;
            // Uma pausa não gera amostras retroativas artificiais.
            _nextSample = now + 1;
            long? privateBytes = null, workingSet = null;
            string? memoryError = null;
            try
            {
                _process!.Refresh();
                privateBytes = _process.PrivateMemorySize64;
                workingSet = _process.WorkingSet64;
            }
            catch (Exception ex) when (ex is InvalidOperationException or System.ComponentModel.Win32Exception or NotSupportedException)
            {
                memoryError = ex.GetType().Name;
            }
            Write("sample", new
            {
                fps_last_second = Engine.GetFramesPerSecond(),
                private_bytes = privateBytes, working_set_bytes = workingSet,
                memory_error = memoryError,
                scene = GetTree().CurrentScene?.SceneFilePath,
                focused = DisplayServer.WindowIsFocused(),
                step = _step, dropped_records = Volatile.Read(ref _dropped)
            });
            _writer.Flush();
        }
        catch (Exception ex) when (IsFileError(ex)) { Disable(ex); }
    }

    public override void _Input(InputEvent input)
    {
        if (input is InputEventKey { Pressed: true, Echo: false, Keycode: Key.F9 })
            Enqueue("human_step_marker", new { step = ++_step });
    }

    public override void _Notification(int what)
    {
        if (_writer == null) return;
        if (what == NotificationApplicationFocusOut) Enqueue("focus_lost", null);
        if (what == NotificationApplicationFocusIn) Enqueue("focus_gained", null);
    }

    public override void _ExitTree()
    {
        if (_engineLogger != null)
        {
            OS.RemoveLogger(_engineLogger);
            _engineLogger.Owner = null;
            _engineLogger.Dispose();
        }
        try
        {
            if (_writer != null && !_failed && !_capped)
            {
                Drain();
                Write("session_end", new { reason = "scene_tree_exit", dropped_records = _dropped });
                _writer.Flush();
            }
        }
        catch (Exception ex) when (IsFileError(ex)) { _failed = true; }
        finally
        {
            try { _writer?.Dispose(); } catch (Exception ex) when (IsFileError(ex)) { _failed = true; }
            _process?.Dispose();
            _instance = null;
        }
    }

    private void Drain()
    {
        for (int i = 0; i < QueueLimit && _pending.TryDequeue(out var item); i++)
        {
            Interlocked.Decrement(ref _queued);
            Write(item.Kind, item.Data, item.Seconds);
        }
    }

    private void Write(string kind, object? data, double? seconds = null)
    {
        if (_capped) return;
        string row = JsonSerializer.Serialize(new { schema = 1, session_id = _session, utc = DateTime.UtcNow, elapsed_seconds = seconds ?? _clock.Elapsed.TotalSeconds, kind, data });
        long size = Encoding.UTF8.GetByteCount(row) + 1;
        if (_bytes + size > MaxBytes)
        {
            _writer!.WriteLine(JsonSerializer.Serialize(new { schema = 1, session_id = _session, kind = "logging_stopped", reason = "size_limit", elapsed_seconds = _clock.Elapsed.TotalSeconds }));
            _writer.Flush();
            _capped = true;
            return;
        }
        _writer!.WriteLine(row);
        _bytes += size;
    }

    private void Disable(Exception ex)
    {
        _failed = true;
        SetProcess(false);
        SetProcessInput(false);
        try { _writer?.Dispose(); } catch (Exception error) when (IsFileError(error)) { }
        _writer = null;
        // Aviso visível; falha no diagnóstico não interrompe a partida.
        GD.PushWarning("A03: não foi possível gravar os logs de teste (" + ex.GetType().Name + ").");
    }

    private static bool IsFileError(Exception ex) => ex is IOException or UnauthorizedAccessException or ArgumentException or NotSupportedException or JsonException or System.Security.SecurityException;
    private static string? Option(string prefix)
    {
        string? arg = Array.Find(OS.GetCmdlineUserArgs(), a => a.StartsWith(prefix, StringComparison.Ordinal));
        return arg == null ? null : arg[prefix.Length..];
    }
}
