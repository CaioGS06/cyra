---
name: cyra-gerador-c-sharp
description: Aplica os padrões de arquitetura de pastas, C# para Godot 4 e separação de responsabilidades exigidos nas atividades A01, A05, A06, A07, A08 e A09 do projeto Cyra.
---

# Skill: Padrão de Arquitetura e Código C# (Cyra)

## Quando usar
Sempre que gerar ou refatorar scripts `.cs` ou estruturar cenas `.tscn` para o jogo Cyra.

## Regras de Implementação
1. **Organização Estrita de Pastas:**
   - Cenas: `res://Scenes/Test/`, `res://Scenes/Sections/`, `res://Scenes/Entities/`, `res://Scenes/UI/`.
   - Scripts: `res://Scripts/Test/`, `res://Scripts/Core/`, `res://Scripts/Player/`, `res://Scripts/Enemies/`, `res://Scripts/Save/`.
   - Assets Humanos: `res://Assets/Sprites/`, `res://Assets/Audio/`, `res://Assets/TileSets/`.

2. **Cabeçalho de Rastreabilidade no Código (Para Atividade A08):**
   Todo arquivo `.cs` gerado deve conter no topo este bloco de comentário para facilitar a revisão cruzada entre Caio e Lucas:
   ```csharp
   // ============================================================================
   // PROJETO CYRA — Estudo de Caso de Desenvolvimento Assistido por IA
   // Atividade / Requisito: [Ex: A05 — RF01 / RF02]
   // Descrição do Módulo: [Resumo da responsabilidade única do script]
   // Entradas / Sinais Emitidos: [Listar inputs lidos e [Signal] declarados]
   // Pontos de Curadoria Humana (Checklist no Editor): [O que conferir no Godot]
   // ============================================================================