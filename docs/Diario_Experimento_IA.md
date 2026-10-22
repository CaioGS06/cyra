# Diário metodológico do desenvolvimento assistido — Cyra

Este é o template inicial solicitado no roteiro. O registro detalhado, testes e revisão cruzada ficam no [diário principal](Diario_Experimento_Cyra.md), evitando duplicar resultados humanos. Não há comparação com implementação manual independente.

| Data | Atividade/Requisito | Módulo/Script | Ferramenta/Modelo | Prompt/Arquivo | Saída Original (Resumo/Commit) | Intervenção/Revisão Humana | Responsável | Tempo (Aprendizagem Godot vs Geração/Revisão/Correção) | Versão/Commit |
|---|---|---|---|---|---|---|---|---|---|
| 20/10/2026 | A01 — ambiente, cena de teste e exportação | Scripts/Test/TestActor.cs; Scripts/Test/TestSceneController.cs; Scenes/Test/TestSceneA01.tscn; configurações da raiz | Codex; modelo específico não aferido | [P01](Prompts_Utilizados.md); [anexo integral](prompts/P01_roteiro_original.md) | D01: projeto mínimo com entrada, gravidade/colisão, sinais e configuração Windows; [saída preservada](saidas_originais/D01_A01.zip) | Nenhuma alteração funcional necessária; validação de Caio e revisão cruzada aprovada por Lucas. | Caio: execução e revisão; Lucas: reprodução e revisão cruzada. | Aprendizagem: Caio: aprendizagem 78 min; revisão/correção 7 min 51 s. Geração e tempos de Lucas: não registrados. | D01; Original: `9cdfcc4`; integrada: `6bf3e2d`; aprovação de Lucas: `46d5986`. |

A01 concluída conforme os registros do diário principal, com exportação Windows validada por Caio e reprodução aprovada por Lucas no commit 46d5986. O diário principal concentra os resultados e as evidências.
