# T01 — Revisão humana documental da A02

**Documento:** [A02 — versão de trabalho revisada](../A02_Escopo_Requisitos_Modelos.md). **Registro:** D02, P02 e P03. **Original preservado:** [D02_A02.zip](../saidas_originais/D02_A02.zip).

**Reunião informada por Caio:** 22/10/2026, 15:02–15:35, America/Sao_Paulo; **33 minutos**, com participação de **Caio, Lucas e Victor**. Não somar como 33 minutos de correção individual de cada integrante; não foi informado tempo adicional de aprendizagem. Esclarecimentos posteriores nesta conversa foram respondidos por Caio e não têm duração medida.

**Situação:** T01 aprovado documentalmente com ajustes incorporados; A02 encerrada em planejamento/modelagem. A equipe confirmou conferência da fonte, aprovação dos modelos e cinco casos simulados sem contradições. Nenhum teste de mecânica implementada é alegado.

## 1. Respostas humanas, conforme P03

| Pergunta | Resposta comunicada pela equipe | Consequência documental |
|---|---|---|
| 1 — Habilidades | Correto. | Pulo duplo e investida, sem terceira habilidade. |
| 2 — Usos | Correto. | Sem cargas permanentes; salto extra por pouso; investida limitada por fase aérea e intervalo no solo; troca não restaura usos. Retirar contadores de cargas do save. |
| 3 — Absorção | Sim, o inimigo deve ficar "atordoado" e quando o jogador apertar o comando o inimigo deve ser absorvido. | Comando em alcance; aquisição permanente, equipamento ao adquirir e uma ativa. Incorporar atordoamento. |
| 4 — Sequência | Sequência aprovada. | S1 → A/pulo duplo → O1 → S2 → B/investida → O2 → S3/fim. |
| 5 — Retorno | Sim. | Retorno bidirecional com conexões abertas na sessão. |
| 6 — Morte | Morrer reseta inimigos e obstáculos. | Substituir a manutenção de derrotas/aberturas proposta pela IA pelo reinício do mundo. |
| 7 — Save | Correto, com exceção dos inimigos e obstáculos salvos. | Excluir os campos desses estados do JSON. Preservar seção/checkpoint/vida/aquisições/ativa. |
| 8 — Eventos de gravação | Correto. | Manter os eventos aprovados, mas serializar somente os dados do jogador. |
| 9 — Falhas | Correto. | Sem save: início. Inválido: aviso e início sem recuperar progresso; próxima gravação válida substitui. Falha de escrita: memória e último arquivo válido preservados, nova tentativa no próximo evento. |

## 2. Esclarecimentos posteriores de Caio

1. Morte mantém habilidades e forma ativa, devolve vida máxima e retorna ao ponto seguro da seção atual; reinicia inimigos e obstáculos.
2. A simples troca de seção mantém estados em memória até morrer ou reabrir o jogo. Morte/reabertura reiniciam o mundo inteiro.
3. Ao chegar a zero de vida, o inimigo fica atordoado sem prazo, não volta a atacar e permanece até absorção ou reinício.

## 3. Alterações da saída original e consequências

- DEC03–DEC05: habilidades/limites/percurso aprovados; atordoamento passa a nomear o estado de derrota absorvível. Aquisições não são duplicadas por inimigos que reaparecem.
- DEC06–DEC07: inimigos e obstáculos passam a estado da sessão; remover `inimigosRelevantesDerrotados` e `obstaculosSuperados` do save e do exemplo JSON. Ao carregar, validar acesso às seções pelas habilidades adquiridas, sem exigir campos removidos.
- Retorno após reinício: a geometria futura deve permitir usar A em O1 e B em O2 pelos dois sentidos, a partir dos pontos seguros. Essa condição deriva das escolhas humanas; sua coerência foi confirmada na simulação T01 e deve ser testada fisicamente na A07.
- A exclusão de derrotas/obstáculos diverge da persistência descrita em S01 p. 5–6 e da solicitação P02 original. A equipe reconheceu essa alteração na confirmação final. Preservar a fonte e o prompt e registrar a mudança no texto final. Não declarar que esses estados são persistidos.
- Os 33 minutos são a duração conjunta da revisão relatada, sem atribuir medição de geração ou alteração de código. Nenhum script, cena, asset ou configuração do jogo foi alterado.

## 4. Conferências finais e resultado

Caio respondeu às três confirmações adicionais em nome da revisão informada. Essa etapa posterior não foi cronometrada e não amplia os 33 minutos relatados da reunião.

- [x] Fonte: resposta **“Conferimos e reconhecemos a alteração”** à conferência dos 12 RF/RNF/critério com S01 p. 3–4 e à mudança da persistência de p. 5–6.
- [x] Modelos: resposta **“Aprovamos a adaptação documental”** à manutenção de UC01–UC05/originais e ao JSON revisado, com inimigos/obstáculos somente na memória da sessão.
- [x] Simulações: resposta **“Simulamos os cinco casos, sem contradições”** aos cenários abaixo.

| Caso simulado pela equipe | Resultado documental relatado |
|---|---|
| Chave ausente/errada | Não abre o bloqueio; regra de habilidade ativa correspondente mantida. |
| Morte em S2/S3 e retorno | Habilidades preservadas permitem superar os bloqueios reiniciados também no retorno; sem contradição no percurso planejado. |
| Morte antes/depois de absorver | Antes: enfrentar novamente. Depois: manter habilidade, sem impedir reinício do inimigo. |
| Reabrir | Retomar vida/habilidades/ponto seguro salvos e reiniciar o mundo. |
| Save inválido / falha de escrita | Inválido inicia do zero com aviso; falha de escrita mantém memória e último arquivo válido. |

**Achado e intervenção:** a proposta inicial preservava inimigos/obstáculos na morte e no arquivo. A equipe alterou ambos para reinício, solicitou atordoamento absorvível e confirmou os efeitos sobre save/retorno. A adaptação foi incorporada ao documento e ao JSON. A divergência da persistência original foi explicitamente reconhecida, sem reescrever a fonte.

**Resultado T01:** aprovado documentalmente com ajustes. Isso não aprova cenários futuros nem comprova geometria/colisões em execução. Valores de ação/dano/teclas e dimensões ficam nas atividades de implementação; protocolo de desempenho na A03. Autoria de assets e narrativa continua humana.

## 5. Versão e preservação

Base anterior: `f8a2f06`. Versão humana integrada: `f1453934c0be612ae8f5c70515820624d15478bd`, conferida no histórico Git em 22/10/2026 durante a preparação da A03. P02/D02 originais e manifestos permanecem preservados; P03 documenta as decisões posteriores. Esta atualização registra somente a referência de versão, sem alterar os resultados, participantes ou tempos da revisão.
