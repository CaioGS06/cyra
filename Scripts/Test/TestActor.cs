// ============================================================================
// PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
// Atividade / Requisito: A01 — entrada/física/colisão; A03 — eventos optativos de teste
// Descrição do Módulo: mover somente o ator descartável de validação da A01.
// Entradas / Sinais Emitidos: ui_left, ui_right, ui_accept; sem sinais próprios.
// Pontos de Curadoria Humana (Checklist no Editor): queda, piso, setas e pulo.
// ============================================================================
using Godot;
using Cyra.Core;

namespace Cyra.Test;

public partial class TestActor : CharacterBody2D
{
	[Export] public float Speed { get; set; } = 220.0f;
	[Export] public float JumpVelocity { get; set; } = -380.0f;

	public bool EntradaObservada { get; private set; }
	public bool ColisaoObservada { get; private set; }

	public override void _Ready()
	{
		GD.Print("A01: script do ator anexado; _Ready executado.");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// A gravidade e o deslizamento usam a física nativa do CharacterBody2D.
		if (!IsOnFloor())
			velocity += GetGravity() * (float)delta;

		float direction = Input.GetAxis("ui_left", "ui_right");
		bool jumpPressed = Input.IsActionJustPressed("ui_accept");
		if (!EntradaObservada && (direction != 0.0f || jumpPressed))
			TestRunRecorder.RecordEvent("A01_input_first");
		EntradaObservada |= direction != 0.0f || jumpPressed;
		velocity.X = direction * Speed;

		if (jumpPressed && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			TestRunRecorder.RecordEvent("A01_jump");
		}

		Velocity = velocity;
		bool wasOnFloor = IsOnFloor();
		MoveAndSlide();
		if (!wasOnFloor && IsOnFloor())
			TestRunRecorder.RecordEvent("A01_landing");
		ColisaoObservada |= IsOnFloor();
	}
}
