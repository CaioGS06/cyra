// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A01 — ciclo de vida e sinais nativos/personalizado
// Descrição do Módulo: conectar UI e gatilho, exibindo evidências da validação.
// Entradas / Sinais Emitidos: BodyEntered, Pressed; TesteConcluido(string).
// Pontos de Curadoria Humana (Checklist no Editor): referências, sinais e texto.
// ============================================================================
using Godot;

namespace Cyra.Test;

public partial class TestSceneController : Node2D
{
    [Signal]
    public delegate void TesteConcluidoEventHandler(string mensagem);

    private TestActor _actor = null!;
    private Area2D _trigger = null!;
    private Button _button = null!;
    private Label _mainLabel = null!;
    private Label _statusLabel = null!;
    private bool _signalObserved;

    public override void _Ready()
    {
        _actor = GetNode<TestActor>("TestActor");
        _trigger = GetNode<Area2D>("TriggerZone");
        _button = GetNode<Button>("CanvasLayer/TestButton");
        _mainLabel = GetNode<Label>("CanvasLayer/MainLabel");
        _statusLabel = GetNode<Label>("CanvasLayer/StatusLabel");

        // As conexões pertencem a esta cena; não conectar novamente no Inspector.
        _trigger.BodyEntered += OnTriggerBodyEntered;
        _button.Pressed += OnTestButtonPressed;
        TesteConcluido += OnTesteConcluido;
        _mainLabel.Text = "Cyra em teste";
        GD.Print("A01: controlador pronto; sinais conectados por C#.");
    }

    public override void _PhysicsProcess(double delta)
    {
        // Um clique comprova o sinal; entrada e piso dependem da execução do ator.
        _statusLabel.Text = $"Entrada: {Status(_actor.EntradaObservada)} | "
            + $"Colisão com piso: {Status(_actor.ColisaoObservada)} | "
            + $"Sinal: {Status(_signalObserved)}";
    }

    public override void _ExitTree()
    {
        _trigger.BodyEntered -= OnTriggerBodyEntered;
        _button.Pressed -= OnTestButtonPressed;
        TesteConcluido -= OnTesteConcluido;
    }

    private void OnTriggerBodyEntered(Node2D body)
    {
        if (body == _actor)
            EmitSignal(SignalName.TesteConcluido, "Área de gatilho acionada");
    }

    private void OnTestButtonPressed()
    {
        EmitSignal(SignalName.TesteConcluido, "Botão acionado");
    }

    private void OnTesteConcluido(string mensagem)
    {
        _signalObserved = true;
        _mainLabel.Text = $"Cyra em teste — {mensagem}";
        GD.Print($"A01: TesteConcluido recebido: {mensagem}.");
    }

    private static string Status(bool observed) => observed ? "OK" : "pendente";
}
