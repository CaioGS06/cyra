# T06 — A06 / C-RF03 e C-RF04

Preparado pela IA em 03/11/2026, D07/P14; base 4253d7c. **Validação funcional de Caio concluída em 03/11/2026 e registrada em P16.** Lucas executou em 05/11 e a sessão foi analisada em P17. RF04 parcial: só representação técnica, sem recursos humanos disponíveis. T03 permanece alias histórico da revisão A03; T05 não foi reaberto.

## Resultados automáticos separados

57 comportamentos A06, 56 A05 e 14 A01 passaram; 18 verificações de integração passaram. [Evidências](T06_A06_automatico/integration_checks.json), [A06](../A06_Mimetismo_Habilidades_Aparencia.md). Entrada simulada/fixtures/execução sem janela na máquina de Caio pela IA, não teste humano. Mesmo coletor durante três mortes e um R. Build/export/release observados, sem erro na rodada final. Métricas headless não aprovam desempenho gráfico. Marca F9 não aprova etapa.

## Roteiro e checklist da execução de Caio

Seguir [guia atual A06](../Guia_Lucas_Testes.md), 16 etapas pequenas, F9 e relato breve; sem editar cenas/JSON ou alterar segurança. Partida nova exige fechar e reabrir; R preserva aquisições. Pré-condições, ações e esperados estão no guia, complementados pelas fixtures identificadas.

- [x] Absorção rejeitada vivo/longe, aceita atordoado, sem duplicação/dano posterior.
- [x] Aquisição A/B com equipamento imediato; troca só adquiridas.
- [x] Pulo extra/investida respeitam limites, pouso restaura e troca não renova.
- [x] Reabsorção não cura/renova usos e mantém ativa atual.
- [x] Roteiro de rejeição de troca durante ataque/absorção/investida concluído segundo Caio. Ensaios complementares de comandos simultâneos permanecem nas evidências automáticas.
- [x] Morte com A/B preserva aquisições/ativa, restaura vida/usos e reinicia inimigos.
- [x] HUD/forma técnica acompanham lógica; legibilidade conferida; arte humana pendente.
- [x] Código lido, cenas visualizadas e parâmetros mantidos provisoriamente por Caio. Logs, F9 e pacote conferidos pela IA.

| Campo | Preencher somente após ocorrência real |
|---|---|
| Executor, revisor de código e máquina efetivos | Caio, executor e revisor. i5-12400F/GTX 750. |
| Data, versão/base+diff, pacote/sessão | 03/11/2026, base 4253d7c, D07. Sessão 20261103T153822827Z-bdc7ca26. Pacote 5952a35952ec, 193 arquivos conferidos. |
| Resultado observado, etapas/F9 e lacunas | Caio relata as 16 etapas concluídas conforme esperado. 16 marcas F9, 667 amostras, duas aquisições e três retornos seguros. |
| Achados, decisão, correção (ou nenhuma necessária) e autor real | Caio leu o código e visualizou as cenas, sem correções necessárias. Ajustes futuros de absorção/investida serão discutidos após os sprites. |
| Reteste/evidência quando necessário | [Relato e evidências de Caio](T06_A06_validacao_Caio.md). Nenhuma correção motivou reteste. |
| Esforço de aprendizagem/revisão/correção/teste | 37 min informados para leitura do roteiro e testes. Tempo específico de revisão do código/cenas não discriminado. Coletor 674,298 s, registrado separadamente. |
| Situação humana e limites aceitos explicitamente | Validação de Caio concluída em P16 e teste funcional de Lucas registrado em P17. RF04 parcial, aguardando integração e conferência dos sprites humanos. |
| Commit integrado após curadoria | Implementação A06 integrada em a31fac0. |

Capturas sugeridas, **não produzidas**: T06_A06_A_adquirida.png, T06_A06_B_ativa.png, T06_A06_antes_morte.png e T06_A06_retorno.png; identificar executor/versão. Enviar sessão inteira e relato; leitura de código deve ser confirmada separadamente de jogar. Caio confirmou execução e leitura do código/cenas. A participação de Lucas fica para registro próprio.

## Conferência de prontidão — P15, 03/11/2026

[Conferência P15](T06_A06_conferencia_P15.md): compilação repetida sem erros/avisos; original D07, ZIP e 193 arquivos do pacote conferidos. Entrega técnica pronta para iniciar revisão humana, com RF04 parcial por ausência de arte humana. Resultados automáticos existentes consultados, sem nova execução funcional ou aprovação humana nesta conferência.

Iniciar pelo CMD de build/a06-test e seguir as 16 etapas do guia. R preserva aquisições; partida nova exige fechar/reabrir pelo CMD. Se não conseguir conferir a tentativa aérea antes de pousar ou a troca durante a absorção curta, registrar essa limitação. Ao retornar, informar executor, responsável pela leitura de código, observações, aceite/ajustes dos parâmetros e tempo medido ou não medido; os campos humanos acima permanecem pendentes.

## Validação de Caio — P16, análise em 04/11/2026

[Validação e evidências preservadas](T06_A06_validacao_Caio.md). Caio testou em 03/11, concluiu as 16 etapas, leu código e visualizou cenas. Relatou 37 min para leitura do roteiro e execução, sem necessidade de correções. Os parâmetros atuais ficam aceitos para o roteiro. Caio propôs discutir com a equipe, após a entrega dos sprites, uma duração de absorção adequada aos quadros e uma investida que preserve a altura durante a ação e retome a gravidade ao terminar. RF04 aguarda integração visual humana. O complemento P17 registra a execução posterior de Lucas.

## Execução de Lucas e situação da etapa — P17

Lucas executou o mesmo pacote de Caio em 05/11/2026. Relatou conclusão com leve dificuldade nos testes de troca no ar. A coleta teve 434 amostras e 15 marcas F9, duas aquisições, 15 saltos adicionais, 23 investidas aceitas e três retornos seguros, sem erros ou avisos registrados no jogo. Uma marca ficou ausente e a rejeição por uso aéreo já gasto foi observada em Caio, sem confirmação nos registros de Lucas. Tempo humano e leitura de código por Lucas não informados. [Relato, logs e diagnóstico do iniciador](T06_A06_validacao_Lucas.md).

Validação funcional da A06 registrada em Caio e Lucas, com as respectivas coberturas. A entrega de Victor chegou em P18. Na versão com sprites, a forma B e o inimigo B ainda usam representação provisória. O registro P19 cobre a revisão visual das trocas. O bloqueio inicial do PowerShell foi documentado com alternativa de abertura direta para os próximos testes.

## Integração visual parcial — D08/P18, 16/11/2026

A execução de Lucas é do pacote funcional anterior. A versão com arte integra Cyra base, forma A e inimigo A, com forma B e inimigo B provisórios. Conferir em partida nova movimento/direção, salto e queda, absorção, troca A/B e retorno depois de R/morte. Esperado: sprites correspondem ao estado da Cyra e do inimigo A, com os pés alinhados e cadência legível. **Resultado visual.** Caio e Lucas concluíram as oito etapas em P19. Ficou aberta a ocorrência visual da caminhada do inimigo. Sugestões de evidência: `T06_D08_base_A.png` e `T06_D08_atordoamento.png`. [Roteiro e escala](../A06_Sprites_Victor.md) · [Verificações automatizadas](T06_A06_sprites_automatico/behavior_results.json).

## Revisão visual de Caio e Lucas — P19, 16/11/2026

Caio e Lucas concluíram as oito etapas com F9 em 16/11. Caio apontou inconsistências nos desenhos, sem problema de implementação percebido. Lucas observou um aparente corte na cintura do capanga ao andar. A causa segue em aberto. Coleta íntegra e zero erros ou avisos. A sessão anterior de Lucas ficou preservada com zero marcas e relato em branco. O commit da integração é `0eeac22`. A conferência de Victor segue sem relato, e RF04 permanece parcial até completar a arte B. [Relatos, logs e análise](T06_A06_revisao_visual_Caio_Lucas.md).
