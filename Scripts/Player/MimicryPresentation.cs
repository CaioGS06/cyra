// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A06 — RF03/RF04; integração A05
// Descrição do Módulo: Mostrar HUD e animar os sprites humanos disponíveis na A06.
// Entradas / Sinais Emitidos: PlayerMimicry.StateChanged, forma ativa e movimento.
// Pontos de Curadoria Humana: ordem dos quadros, alinhamento dos pés e troca de forma.
// ============================================================================
using Godot;
using Cyra.Core;
namespace Cyra.Player;
public partial class MimicryPresentation : Node
{
    [Export] public SpriteFrames? BaseFrames { get; set; }
    [Export] public SpriteFrames? FormAFrames { get; set; }

    private PlayerController _player = null!;
    private PlayerMimicry _state = null!;
    private ColorRect _visual = null!;
    private AnimatedSprite2D _sprite = null!;
    private Label _label = null!;
    public override void _Ready()
    {
        _player = GetParent<PlayerController>();
        _state = _player.GetNode<PlayerMimicry>("Mimicry");
        _visual = _player.GetNode<ColorRect>("Visual");
        _sprite = _player.GetNode<AnimatedSprite2D>("HumanSprite");
        _label = _player.GetNode<Label>("FormLabel");
        _state.StateChanged += Refresh; Refresh();
    }
    public override void _Process(double delta)
    {
        if (!_sprite.Visible || _sprite.SpriteFrames is not { } frames) return;

        // A folha de absorção tem quatro quadros a 20 FPS na configuração atual.
        bool absorbing = _state.IsAbsorbing && frames.HasAnimation("absorb");
        StringName animation;
        if (absorbing)
            animation = "absorb";
        else if (!_player.IsOnFloor())
            animation = _player.Velocity.Y >= 0 && frames.HasAnimation("fall") ? "fall" : "jump";
        else
            animation = Mathf.Abs(_player.GetRealVelocity().X) > 0.1f ? "walk" : "idle";

        _sprite.FlipH = _player.FacingDirection < 0;
        _sprite.SelfModulate = _visual.SelfModulate;
        if (_sprite.Animation != animation)
            _sprite.Play(animation);
    }
    private void Refresh()
    {
        _label.Visible = _state.Enabled;
        if (!_state.Enabled) return;
        string active = _state.Session.Active;
        string form = active == MimicrySession.A ? "A" : active == MimicrySession.B ? "B" : "Base";
        SpriteFrames? frames = form == "A" ? FormAFrames : form == "Base" ? BaseFrames : null;
        if (frames != null && _sprite.SpriteFrames != frames)
        {
            _sprite.SpriteFrames = frames;
            _sprite.Play("idle");
        }
        _sprite.Visible = frames != null;
        _visual.Visible = frames == null;
        _visual.Color = form == "A" ? new Color(0.4f,1,0.4f) : form == "B" ? new Color(0.8f,0.4f,1) : new Color(0.3f,0.7f,0.95f);
        _label.Text = $"{form} | A:{(_state.Session.HasA ? "sim" : "não")} B:{(_state.Session.HasB ? "sim" : "não")} | extra:{(!_state.ExtraUsed ? "pronto" : "gasto")} ar K:{(!_state.AirDashUsed ? "pronto" : "gasto")}";
        var hud = GetNodeOrNull<Label>("../../CanvasLayer/MimicryStatus");
        if (hud != null) hud.Text = _label.Text;
    }
    public override void _ExitTree() => _state.StateChanged -= Refresh;
}
