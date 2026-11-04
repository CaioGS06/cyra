// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A06 — RF03/RF04; integração A05
// Descrição do Módulo: Apresentação técnica, sem regras ou sprites gerados.
// Entradas / Sinais Emitidos: PlayerMimicry.StateChanged; ColorRect/Label.
// Pontos de Curadoria Humana: limites por ciclo, morte e coerência visual.
// ============================================================================
using Godot;
using Cyra.Core;
namespace Cyra.Player;
public partial class MimicryPresentation : Node
{
    private PlayerMimicry _state = null!;
    private ColorRect _visual = null!;
    private Label _label = null!;
    public override void _Ready()
    {
        _state = GetParent().GetNode<PlayerMimicry>("Mimicry");
        _visual = GetParent().GetNode<ColorRect>("Visual");
        _label = GetParent().GetNode<Label>("FormLabel");
        _state.StateChanged += Refresh; Refresh();
    }
    private void Refresh()
    {
        _label.Visible = _state.Enabled;
        if (!_state.Enabled) return;
        string active = _state.Session.Active;
        string form = active == MimicrySession.A ? "A" : active == MimicrySession.B ? "B" : "Base";
        _visual.Color = form == "A" ? new Color(0.4f,1,0.4f) : form == "B" ? new Color(0.8f,0.4f,1) : new Color(0.3f,0.7f,0.95f);
        _label.Text = $"{form} | A:{(_state.Session.HasA ? "sim" : "não")} B:{(_state.Session.HasB ? "sim" : "não")} | extra:{(!_state.ExtraUsed ? "pronto" : "gasto")} ar K:{(!_state.AirDashUsed ? "pronto" : "gasto")}";
        var hud = GetNodeOrNull<Label>("../../CanvasLayer/MimicryStatus");
        if (hud != null) hud.Text = _label.Text;
    }
    public override void _ExitTree() => _state.StateChanged -= Refresh;
}
