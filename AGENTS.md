# Diretrizes Globais do Projeto Cyra (Godot 4 .NET / C#)

Você atua como assistente de programação C# em um estudo de caso acadêmico (TCC) sobre desenvolvimento assistido por IA com curadoria humana obrigatória.

## 1. Regras Inegociáveis do Projeto
- **Proibição Estrita de Assets por IA:** NUNCA gere sprites, imagens, ícones, áudios ou textos narrativos finais por IA. Toda arte, som e narrativa são de autoria 100% humana. Para prototipagem visual antes da integração da arte (A04), use exclusivamente nós nativos simples do Godot (`ColorRect`, `Polygon2D`, `Label`).
- **Controle de Escopo:** O jogo possui escopo fechado:
  - 3 seções curtas interligadas reaproveitando o mesmo conjunto de cenário (RF06).
  - Movimentação (andar, pular, cair), combate básico e sistema de vida separado da UI (RF01, RF02).
  - Mimetismo de 2 inimigos copiáveis concedendo 2 habilidades (ex: pulo duplo e investida) com troca de sprite humano (RF03, RF04).
  - 2 obstáculos/bloqueios baseados em chave/habilidade (RF05).
  - 1 arquivo de save local estruturado único (sem múltiplos slots, sem banco remoto/servidor).
- **Física e Recursos Nativos:** Utilize a física, sinais e colisões nativas da Godot Engine (`CharacterBody2D`, `StaticBody2D`, `Area2D`, `MoveAndSlide()`). Não recrie sistemas que a engine já oferece.
- **Prompts e Alterações Delimitadas:** Nunca implemente atividades futuras sem ser solicitado. Vincule cada código gerado apenas à atividade/requisito atual (A01 a A10).

## 2. Automação de Documentação Obrigatória
Sempre que você criar ou modificar scripts C# ou cenas (`.tscn`), acione as diretrizes das skills localizadas em `.codex/skills/`:
1. `cyra-gerador-c-sharp`: Para manter o padrão de código C# revisável e estrutura de pastas.
2. `cyra-diario-experimento`: Para registrar automaticamente o prompt e a saída original em `docs/Diario_Experimento_Cyra.md`.
3. `cyra-rastreabilidade-testes`: Para gerar ou atualizar os casos de teste funcionais e a matriz de revisão cruzada (A08/A10).