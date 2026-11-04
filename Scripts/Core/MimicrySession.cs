// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A06 — RF03/RF04; integração A05
// Descrição do Módulo: Aquisições/ativa somente em memória do processo.
// Entradas / Sinais Emitidos: Changed; sem disco ou save.
// Pontos de Curadoria Humana: limites por ciclo, morte e coerência visual.
// ============================================================================
using Godot;
namespace Cyra.Core;
public partial class MimicrySession : Node
{
    public const string A = "habilidade_A_pulo_duplo", B = "habilidade_B_investida";
    public bool HasA { get; private set; }
    public bool HasB { get; private set; }
    public string Active { get; private set; } = "";
    [Signal] public delegate void ChangedEventHandler();
    public bool Owns(string id) => id == A ? HasA : id == B && HasB;
    public bool Acquire(string id)
    {
        if ((id != A && id != B) || Owns(id)) return false;
        string previous = Active;
        if (id == A) HasA = true; else HasB = true;
        Active = id;
        TestRunRecorder.RecordEvent("A06_acquired", new { id, previous, current = Active, has_a = HasA, has_b = HasB });
        EmitSignal(SignalName.Changed); return true;
    }
    public bool Equip(string id)
    {
        if (!Owns(id)) return false;
        Active = id; EmitSignal(SignalName.Changed); return true;
    }
}
