// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A05 — RF02
// Descrição do Módulo: manter vida limitada e emitir mudança/esgotamento uma vez.
// Entradas / Sinais Emitidos: ApplyDamage; Changed(anterior, atual, máximo), Depleted.
// Pontos de Curadoria Humana: limites, inicialização, zero e independência da UI.
// ============================================================================
using Godot;
using System;

namespace Cyra.Core;

public partial class Health : Node
{
    private int _maximum = 5;
    private bool _initialized;

    [Export(PropertyHint.Range, "1,100,1")]
    public int Maximum
    {
        get => _maximum;
        set
        {
            int previousMaximum = _maximum;
            _maximum = Math.Max(1, value);
            if (_initialized && Current > _maximum)
                SetCurrent(_maximum, "maximum_changed");
            else if (_initialized && previousMaximum != _maximum)
            {
                TestRunRecorder.RecordEvent("A05_health_changed", new { entity = EntityId, source = "maximum_changed", previous = Current, current = Current, maximum = Maximum });
                EmitSignal(SignalName.Changed, Current, Current, Maximum);
            }
        }
    }

    [Export] public string EntityId { get; set; } = "actor";
    public int Current { get; private set; }
    public bool IsDepleted => Current == 0;

    [Signal] public delegate void ChangedEventHandler(int previous, int current, int maximum);
    [Signal] public delegate void DepletedEventHandler();

    public override void _Ready()
    {
        Current = Maximum;
        _initialized = true;
    }

    public bool ApplyDamage(int amount, string source)
    {
        if (!_initialized || amount <= 0 || IsDepleted)
            return false;

        // Subtração em long evita estouro mesmo com entradas fora do balanceamento.
        SetCurrent((int)Math.Max(0L, (long)Current - amount), source);
        return true;
    }

    private void SetCurrent(int value, string source)
    {
        int previous = Current;
        Current = Math.Clamp(value, 0, Maximum);
        if (previous == Current) return;

        TestRunRecorder.RecordEvent("A05_health_changed", new
        {
            entity = EntityId, source, previous, current = Current, maximum = Maximum
        });
        EmitSignal(SignalName.Changed, previous, Current, Maximum);
        if (previous > 0 && Current == 0)
            EmitSignal(SignalName.Depleted);
    }
}
