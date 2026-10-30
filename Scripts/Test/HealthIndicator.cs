// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A05 — RF02, apresentação passiva da vida
// Descrição do Módulo: mostrar o valor real inicial e acompanhar Health.Changed.
// Entradas / Sinais Emitidos: HealthPath e Health.Changed; nenhum sinal próprio.
// Pontos de Curadoria Humana: UI não decide dano, vida ou morte; conexão única.
// ============================================================================
using Godot;
using Cyra.Core;

namespace Cyra.Test;

public partial class HealthIndicator : Label
{
    [Export] public NodePath HealthPath { get; set; } = new();
    [Export] public string Prefix { get; set; } = "Vida";
    private Health _health = null!;

    public override void _Ready()
    {
        _health = GetNode<Health>(HealthPath);
        _health.Changed += UpdateValue;
        UpdateValue(_health.Current, _health.Current, _health.Maximum);
    }

    private void UpdateValue(int previous, int current, int maximum) => Text = $"{Prefix}: {current}/{maximum}";
    public override void _ExitTree() => _health.Changed -= UpdateValue;
}
