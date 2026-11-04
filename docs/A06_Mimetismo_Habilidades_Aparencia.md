# A06 — Mimetismo, habilidades e aparência

Preparação pela IA em **03/11/2026**, base Git `4253d7c` (A05 `13c7add`). D07/P14/T06; proposta para curadoria, sem aprovação humana nesta entrega.

## Proposta inicial registrada antes da implementação

Preservar A/D/setas, Espaço, J, R e F9. Acrescentar **E** absorver, **K** investir, **1** equipar A e **2** equipar B. Valores ajustáveis no Inspector: alcance radial de absorção **90 px**, duração **0,20 s**, impulso adicional **−380 px/s**, investida **520 px/s** por **0,18 s**, intervalo entre inícios **0,65 s**. Os valores da A05 permanecem provisórios aceitos por Caio; os novos valores são proposta da IA, ainda não aprovados.

Propostas operacionais: absorção interrompe movimento horizontal mas mantém gravidade; confirma condições ao terminar. Investida mantém gravidade/velocidade vertical, bloqueia novo salto durante a ação e não concede dano ou invulnerabilidade. Reabsorção retira o alvo, mantém habilidade ativa atual e não cura/restaura usos. Uma habilidade nova equipa imediatamente. Reinício manual R tem os mesmos efeitos de retorno seguro da morte, preservando aquisições/ativa. Fechar e abrir o processo inicia sem aquisições; não há save.

Prioridade proposta: morte cancela tudo; ação em curso bloqueia novas ações incompatíveis; em repouso, E > K > J > troca (1 antes de 2) > salto. Movimento e salto básico continuam durante ataque como na A05; absorção/investida bloqueiam salto. Troca durante ataque/absorção/investida é rejeitada e nunca enfileirada. Seleção: entre candidatos atordoados disponíveis no alcance, menor distância, depois ID técnico ordinal e ID de instância para desempate residual. Sem candidato elegível, reportar o motivo do alvo mais próximo, sem conceder progresso.

Regras humanas usadas: [A02, seção 4 e DEC03–DEC09](A02_Escopo_Requisitos_Modelos.md). IDs `habilidade_A_pulo_duplo`, `habilidade_B_investida`, `inimigo_01_A`, `inimigo_02_B`. A sala é técnica, não seção final. Nenhum bloqueio de A07, persistência ou terceira habilidade.

## Recursos humanos

Inspeção em 03/11: `Assets/Sprites`, `Assets/Audio` e `Assets/TileSets` contêm somente `.gitkeep`. Nenhum recurso humano disponível ou integrado; sem autoria inventada. Base/A/B usarão ColorRect e Label; a ligação entre estado e apresentação será testável, mas **RF04 permanece parcial**, pendente dos sprites/animações humanos da A04 e da curadoria visual. Não é troca de sprites humanos validada.


## Componentes, sinais e integração

| Arquivo | Responsabilidade / sinais |
|---|---|
| `Scripts/Core/MimicrySession.cs` | Autoload somente em memória; HasA/HasB/Active, Acquire/Equip, Changed. Não escreve arquivo; processo novo inicia vazio. |
| `Scripts/Player/PlayerMimicry.cs` | Enabled por sala, absorção e temporizadores, ExtraUsed/AirDashUsed; StateChanged. Estado independente do texto/cor. |
| `Scripts/Player/MimicryPresentation.cs` | Escuta StateChanged, atualiza ColorRect, FormLabel e HUD fixo. Sem decisões de aquisição/uso/dano. |
| `Scripts/Player/PlayerController.cs` | Reutiliza física/ataque/vida A05; chama componente antes de MoveAndSlide, captura direção, aplica impulso extra/deslocamento de investida. Died/AttackStarted preservados. |
| `Scripts/Enemies/BasicEnemy.cs` | Mesma patrulha/Health para A/B e inimigo não copiável A05; AbilityId exportado, Stunned/Absorbed. Absorvido permanece nó oculto/indisponível, sem dano/colisão ativa até recarga. |
| `Scripts/Test/A06RoomController.cs` | Recarrega a sala com guarda/deferimento, restaura vida/usos; sessão de habilidades e coletor permanecem na árvore. Eventos room_ready/safe_return/reset. |
| `Scenes/Entities/Player.tscn` | Acrescenta componente/presentação desabilitados logicamente na A05. |
| `Scenes/Test/TestRoomA06.tscn` | Sala única, chão contínuo/paredes/ponto seguro e dois inimigos acessíveis por caminhada/salto básico. Sem bloqueio por habilidade. Instâncias da mesma cena BasicEnemy com IDs A02. |

Health, HealthIndicator e sala/controlador A05 foram preservados; TestRunRecorder apenas amplia catálogo de eventos. Camadas/máscaras iguais à A05: cenário 1, jogador 2/máscara1, inimigos4/máscara1, ataque0/máscara4, contato0/máscara2, raycast máscara1. Proximidade de absorção é distância entre centros em coordenadas globais; não exige orientação ou linha de visão nesta proposta, sala aberta. A seleção usa grupo nativo e ordenação documentada. Conclusão reconfirma vida/proximidade/disponibilidade. Não há cura, recompensa ou concessão repetida. Reabsorção mantém ativa atual (proposta operacional, não aprovação humana anterior).

A05 abre por F6 com mimetismo desabilitado/forma base; o estado A06 não interfere na A05. A01 permanece sem mudanças. R em A06 recarrega mundo/vida/usos mantendo aquisições; no processo novo, sem save, tudo começa vazio. Morte encerra ataque/absorção/investida antes da recarga. Não há carga persistida nem transição de seção implementada. As regras futuras de mundo em memória e save sem inimigos/obstáculos continuam na A02, sem implementação antecipada.

## Entrada, eventos e ferramentas

Novas ações `player_absorb` E, `player_dash` K, `player_form_a` 1, `player_form_b` 2; ações A05 preservadas. Todos os parâmetros novos estão exportados no Player/Mimicry, ajustáveis no Inspector. Aquisição pode ocorrer no ar; não renova usos já gastos. Investida no solo que abandona o piso consome também o uso aéreo desse ciclo. Pouso recompõe usos, mantendo intervalo residual da investida. Duração/intervalo começam no comando aceito; sem fila oculta. Direção de movimento é capturada antes do comando de ataque/investida.

Eventos A05 continuam para movimento, salto/pouso, ataque, vida/dano, atordoamento/morte (ações compartilhadas na sala A06). Eventos A06: absorb_attempt/result, acquired, switch, extra_jump, dash, air_dash_consumed, uses_restored, room_ready, safe_return, room_reset. Motivos de rejeição e IDs são valores simples; não se serializam nós. Logs de usos são emitidos nas mudanças/pousos, não por quadro. Repetir E/1/2/K exige novo pressionamento; permanência em área não dispara mensagem. Coletor original, limite 25 MiB/512 itens, F9, modo comum inativo e falha não fatal permanecem. Analisador inclui eventos A06 e não atribui aprovação. Máquina explícita/pergunta e coleta ausente D05 preservadas.

Iniciador fora de pacote usa A06; dentro de pacote preparado usa seu descritor quando não informado -Cenario. Cenário explícito divergente é rejeitado antes de iniciar o jogo. Preparar_Pacote_A06 copia ferramentas/guia atuais e cria descritor D07/base Git, sem inventar commit integrado. Pacotes recebidos não foram usados como fonte. A05/A03 exportados não foram sobrescritos.

## Verificações automáticas — 03/11/2026

- Compilação: zero avisos/erros. [Log](evidencias/T06_A06_automatico/build-final.log).
- **57 verificações A06, zero falhas**, incluindo aquisições, negativos, usos por ciclo/troca, colisão nativa, reabsorção, prioridade J+2 sem fila, empate de alvos, distância reconfirmada, dano durante investida, mortes A/B e R. [Relatório](evidencias/T06_A06_automatico/behavior_results.json).
- **56 verificações A05, zero falhas**; [relatório](evidencias/T06_A06_automatico/a05-final.json). A01: **14 verificações, zero falhas**, [log](evidencias/T06_A06_automatico/a01.log).
- **18 verificações de integração**, [relatório](evidencias/T06_A06_automatico/integration_checks.json): uma sessão contínua, duas aquisições únicas, três mortes/retornos, um R, marcador simulado, modo comum sem coleta, falha de gravação não fatal, release A06 completo/sem erros/avisos, sem aprovação automática. Três PowerShell passaram análise sintática; pacote divergente rejeitado, [mensagem](evidencias/T06_A06_automatico/wrong_package.txt).
- Exportação Windows e execução release pelo iniciador atual realizadas sem janela; [resumo](evidencias/T06_A06_automatico/release/summary.json), manifesto por arquivo em package.json da mesma pasta. Runtime efetivo e máquina estão no cabeçalho, sem equiparar runtime do Godot ao SDK fixado do projeto.

Condições: máquina de Caio, execução pela IA sem janela; entrada simulada e fixtures explícitas de posição, inimigos com patrulha/contato congelados em casos isolados, dano direto para forçar mortes. Outros casos usam física/entrada reais da engine. Um F9 simulado não é aprovação humana. A05 testa contato real; A06 testa dano durante investida por chamada de integração. Não há teste gráfico humano, capturas, benchmark ou comprovação de sprites humanos. As três mortes são com A adquirida/ativa, ambas/B ativa e ambas/A ativa. Novas aberturas release confirmam estado inicial vazio, não persistência.

Correções da própria IA na geração: ajuste do ramo do iniciador após substituição textual; correção de codificação de texto ao copiar arquivos; indicador fixo adicional para evitar depender só do rótulo que acompanha o jogador; captura de direção antes dos comandos; ID do ponto seguro corrigido de a05_safe para a06_safe e distinção initial/death_return/manual_return nos logs. Retestes finais passaram. Essas intervenções não são curadoria humana. Primeira importação sob acesso restrito falhou ao localizar assemblies/configuração; com acesso necessário ao ambiente local, importação e testes funcionaram. Logs de tentativas preservados; nenhuma política de segurança do Windows foi alterada. Não atribuir esse impedimento de ambiente à lógica do jogo.

## Curadoria e integração pendentes

[T06](evidencias/T06_A06_revisao.md) vincula C-RF03/C-RF04, integração A05 e morte. [Guia](Guia_Lucas_Testes.md) separa partida nova e ciclos, sem edição de estado/JSON por Lucas. Caio/Lucas precisam confirmar executor/revisor efetivo, resultado, ajustes ou revisão sem correções, parâmetros e tempo quando medido. Esforço desta geração/revisão: **não medido**. RF04 continua parcial até arte humana A04 e revisão; não declarar RF03 aprovado só pelos testes automáticos. A05/T05 foi encerrada com ressalvas no commit 4253d7c: Lucas apenas jogou, 11 F9/nenhum salto; Caio aceitou considerando sua validação anterior. A03 cinco F9/nenhum salto também permanece histórica.

Arquivos da entrega estão listados no [manifesto D07](saidas_originais/D07_SHA256.txt); saída anterior à curadoria em [D07_A06.zip](saidas_originais/D07_A06.zip). [P14 integral](prompts/P14_A06_implementacao.md) registra a solicitação mais recente, incluindo sua frase final incompleta, sem completá-la artificialmente. A tentativa interrompida anterior criou somente a proposta inicial, aproveitada aqui; não é revisão humana nem geração independente adicional. Nenhum commit/push executado, cronograma preservado.

## Validação de Caio e propostas futuras — P16

Caio concluiu as 16 etapas em 03/11/2026, leu os códigos e visualizou as cenas. A revisão ficou sem correções. Informou 37 min para leitura do roteiro e testes. [Validação e logs](evidencias/T06_A06_validacao_Caio.md). O comportamento atual foi aceito para esta fase. O teste de Lucas ainda aguarda relato e RF04 permanece parcial até a arte humana.

Após a entrega dos sprites, Caio propõe discutir com a equipe se a absorção deve durar mais, conforme os quadros da animação, e se a investida deve manter a altura durante a ação e retomar a gravidade ao terminar, tomando Hollow Knight como referência criativa. Outros ajustes ficam para essa discussão. São propostas para uma revisão futura dos parâmetros, separadas do estado validado em P16.
