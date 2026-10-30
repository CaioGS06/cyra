# Prompts utilizados — Cyra

## P01 — 20/10/2026 — A01

**Ferramenta:** Codex. **Modelo específico:** não aferido neste registro.

**Texto exato do pedido do desenvolvedor:**

> Seguir o roteiro anexado.

**Anexo indicado:** `C:\Users\caio\Downloads\roteiro.md`.

O conteúdo integral do anexo foi preservado, sem remover escapes ou corrigir sua formatação, em [P01_roteiro_original.md](prompts/P01_roteiro_original.md). Esse arquivo faz parte de P01 e delimita os cinco entregáveis da A01. Os exemplos de versão do roteiro foram substituídos na configuração pelas versões verificadas localmente.

**Contexto normativo:** `AGENTS.md` e as três skills locais `cyra-gerador-c-sharp`, `cyra-diario-experimento` e `cyra-rastreabilidade-testes`. A execução ficou limitada à A01; nenhuma mecânica das atividades futuras foi implementada.

**Saída vinculada:** [D01](Diario_Experimento_Cyra.md), [arquivo da saída original](saidas_originais/D01_A01.zip), [manifesto de integridade](saidas_originais/D01_SHA256.txt).

**Intervenção humana:** Caio revisou os scripts e a cena, instalou os templates e validou a execução no editor e no executável Windows. Não foram necessárias alterações funcionais no código; o histórico contém alterações de indentação. Lucas reproduziu o ambiente e aprovou o T00 e a revisão cruzada no commit `46d5986`.

## P02 — 22/10/2026 — A02 — preparação documental

**Ferramenta:** Codex. **Modelo específico:** não aferido neste registro. **Data real:** 22/10/2026.

**Saída vinculada:** [A02 — Escopo, requisitos e modelos](A02_Escopo_Requisitos_Modelos.md); D02 e T01 no [diário](Diario_Experimento_Cyra.md); [saída original D02](saidas_originais/D02_A02.zip); [manifesto](saidas_originais/D02_SHA256.txt).

**Natureza da saída original P02:** preparação documental, sem scripts/cenas/assets/configurações alterados e sem aprovação humana naquela entrega. Revisores e tempos estavam pendentes na geração original. A revisão posterior está registrada em P03 e na evidência T01, sem substituir o prompt ou o ZIP original. Sem commit ou envio automático ao GitHub.

**Texto integral do prompt enviado pelo desenvolvedor** (também preservado em [arquivo próprio](prompts/P02_A02_prompt_integral.md); apenas finais de linha normalizados):

````text
# Contexto do Projeto e Escopo Arquitetural (Cyra)

Estamos desenvolvendo o jogo 2D "Cyra" utilizando Godot Engine .NET / C# na versão 4.7.2, com SDK .NET 8.0.422 e exportação para Windows Desktop x86_64.

O desenvolvimento faz parte de um estudo de caso acadêmico sobre programação assistida por IA com curadoria humana obrigatória. Arte, animações, áudios e narrativa final são de autoria 100% humana. Não haverá implementação manual independente para comparação.

A Atividade A01 já foi realizada: o projeto possui estrutura de pastas, cena de validação, scripts de entrada/física/sinais, documentação e exportação Windows. Caio e Lucas registraram a validação. Confira o diário e o histórico do Git para identificar as versões correspondentes.

Embora você deva preparar APENAS os entregáveis documentais da Atividade A02 neste momento, considere o escopo completo já estabelecido:

- Movimentação 2D: andar, pular e cair; combate, vida e inimigo básico (RF01/RF02 — A05).
- Mimetismo de dois tipos de inimigos copiáveis, concedendo duas habilidades e troca de sprites humanos (RF03/RF04 — A06).
- Três seções curtas interligadas, reutilizando o mesmo conjunto de cenário, com dois obstáculos baseados em habilidade (RF05/RF06 — A07).
- Um arquivo de save local estruturado único, sem múltiplos slots, banco remoto ou servidor (A07).
- Controles, identificação dos módulos assistidos por IA e atribuição humana dos recursos (A09).

# Fontes e Estado Atual do Projeto

Antes de produzir os documentos, leia:

- AGENTS.md.
- docs/Cronograma_Cyra_15-10_a_23-11-2026.md.
- docs/Guia_atividades_Cyra_2026.md.
- docs/Diario_Experimento_Cyra.md.
- docs/Prompts_Utilizados.md.
- README.md.
- Os diagramas e modelos pertinentes existentes em docs/arquivos_tcc/, incluindo Untitled.sql.

Consulte a fonte dos requisitos indicada pelo cronograma:
C:\Users\caio\Downloads\(CLV) LES - 5 - Relatorio_Parcial_Final_ADS_assinado (1).pdf

Distinga requisitos da fonte, decisões humanas registradas e sugestões de execução do guia. Se uma fonte estiver inacessível, identifique a lacuna, sem inventar requisitos ou substituir silenciosamente o documento por outra versão.

# Tarefa Atual: Preparar a Atividade A02 (Fechar percurso, requisitos, regras e modelos)

Crie docs/A02_Escopo_Requisitos_Modelos.md como documento consolidado da atividade. Se já existir material equivalente, aproveite-o e evite duplicação.

Esta tarefa é documental. Não crie nem altere scripts C#, cenas .tscn, assets ou configurações do jogo. Não implemente as atividades futuras.

Execute os cinco itens abaixo:

1. **Conferência dos Requisitos e Critérios de Aceitação**

- Transcreva RF01–RF06 e RNF01–RNF06 da fonte, preservando os IDs e o significado.
- Indique a origem e a página de cada requisito.
- Separe a redação original da interpretação prática para a demo.
- Para cada requisito, apresente: demonstração objetiva de atendimento, atividade de implementação e teste/evidência previsto.
- Não marque funcionalidades futuras como implementadas ou testes como executados.
- Registre divergências entre fonte, guia e modelos, respeitando as decisões explícitas do grupo e os limites do AGENTS.md.

2. **Percurso Mínimo das Três Seções**

- Proponha três seções pequenas e interligadas, reutilizando o mesmo conjunto de pisos e cenário.
- Identifique entrada, ponto seguro, posição dos dois tipos de inimigos copiáveis, dois obstáculos por habilidade e um fim claro.
- Apresente o percurso em esquema textual ou Mermaid, sem gerar imagem artística.
- Use como proposta inicial: adquirir habilidade A na seção 1, superar o primeiro bloqueio, adquirir habilidade B na seção 2 e superar o segundo bloqueio para concluir a seção 3.
- Explique o retorno entre seções e como evitar situações sem possibilidade de progressão.
- Não acrescente biomas, chefes, missões, colecionáveis ou outros sistemas.

3. **Regras das Habilidades, Combate e Reinício**

- Confira se já existem decisões humanas sobre as duas habilidades. Na ausência delas, proponha pulo duplo e investida.
- Especifique as regras de derrota do inimigo, absorção, aquisição, habilidade ativa e troca entre formas.
- Confira eventuais limites de uso presentes nos modelos e apresente uma recomendação coerente com o percurso, identificada como proposta.
- Descreva vida, dano, morte e reinício apenas no nível necessário para orientar a implementação.
- Defina quais estados permanecem após morte e carregamento, evitando a perda definitiva de habilidades necessárias.
- Mantenha vida separada da UI e estado de habilidade separado da representação visual.
- Identifique propostas pendentes de curadoria; não atribua aprovação à equipe.

4. **Casos de Uso e Modelo do Save Local**

- Confira os casos de uso e o modelo de dados existentes antes de propor alterações.
- Apresente diagramas técnicos em Mermaid ou descrição textual, sem gerar assets.
- Diferencie dados estáticos do jogo de dados de progresso do jogador.
- Especifique um save local único contendo: seção, ponto seguro de retorno, vida, habilidades adquiridas, habilidade ativa, inimigos relevantes derrotados e obstáculos superados.
- Defina identificadores estáveis e proponha os momentos de salvar/carregar.
- Descreva o tratamento de arquivo inexistente ou inválido e a relação entre save, morte e reinício.
- Inclua um exemplo ilustrativo de JSON, claramente identificado como exemplo.
- Use Untitled.sql como referência de modelagem, sem implementar banco de dados. Preserve os materiais originais e explique as adaptações propostas.

5. **Documentação, Rastreabilidade e Revisão Humana**

- Organize todos os entregáveis em docs/A02_Escopo_Requisitos_Modelos.md, com uma lista final das decisões que a equipe precisa revisar.
- Identifique cada decisão como já registrada, proposta pela IA ou pendente de definição humana.
- Registre o texto integral deste prompt com o próximo ID disponível em docs/Prompts_Utilizados.md e vincule a saída documental.
- Acrescente ao diário um registro documental da A02, distinguindo preparação pela IA de aprovação humana. Preserve os registros e resultados da A01.
- Preserve uma cópia identificável da saída original da A02 antes de futuras revisões humanas, seguindo a organização documental existente.
- Registre a data real de execução, sem retroagir à janela planejada.
- Não invente tempos, decisões, revisores, testes ou aprovações.
- Consulte as skills locais pertinentes à documentação e à rastreabilidade, aplicando somente o que couber nesta tarefa documental. Não crie registros fictícios de geração de código.
- Acrescente no README um link para o documento da A02, sem duplicar seu conteúdo.

# Critério de Conclusão e Entrega

O documento deve permitir que a equipe explique o percurso completo e saiba como verificar cada requisito antes de implementar as mecânicas.

Avance com recomendações explícitas quando faltar uma decisão, sem interromper toda a preparação. A entrega da IA é uma proposta para curadoria; não declare a A02 aprovada sem revisão humana.

Ao concluir, informe:

- Arquivos criados ou alterados.
- Fontes consultadas e eventuais lacunas ou divergências.
- Decisões propostas que Caio, Lucas e Victor precisam revisar.
- Uma lista curta de conferência para aprovar a A02 e preparar a implementação correspondente.

Não faça commit nem envie alterações ao GitHub.

Ao concluir os arquivos da A02, utilize as skills em `.codex/skills/` para preencher automaticamente o registro `D02`, o prompt `P02` e o teste `T01` em `docs/Diario_Experimento_Cyra.md` e `docs/Prompts_Utilizados.md`.
````

**Intervenção / revisão humana posterior:** Caio, Lucas e Victor, 22/10/2026, 15:02–15:35 (33 min conjuntos). Decisões e alterações em P03 e [T01](evidencias/T01_A02_revisao.md); conferências finais posteriormente confirmadas em P03.

## P03 — 22/10/2026 — A02 — decisões e revisão humana de D02

**Ferramenta:** Codex; modelo específico não aferido. **Natureza:** incorporação documental de decisões humanas, sem código/cena/asset/configuração alterado. **Vínculos:** D02; [A02 revisada](A02_Escopo_Requisitos_Modelos.md); [T01](evidencias/T01_A02_revisao.md). Não aprova testes futuros.

**Contexto das respostas numeradas:** 1 habilidades; 2 limites de uso/contadores; 3 aquisição/forma ativa; 4 percurso; 5 retorno; 6 morte; 7 campos do save; 8 momentos de gravação; 9 falhas de carga/escrita. As propostas anteriores estão preservadas em D02/P02; o roteiro de perguntas foi apresentado nesta conversa.

**Texto integral da resposta do desenvolvedor:**

```text
Eis aqui as nossas respostas:
1 - Correto.
2 - Correto.
3 - Sim, o inimigo deve ficar "atordoado" e quando o jogador apertar o comando o inimigo deve ser absorvido.
4 - Sequência aprovada.
5 - Sim.
6 - Morrer reseta inimigos e obstáculos.
7 - Correto, com exceção dos inimigos e obstáculos salvos.
8 - Correto.
9 - Correto.

Todos nós participamos da revisão e ela foi feita hoje das 15:02 até às 15:35.
```

**Esclarecimentos posteriores recebidos por formulário nesta conversa:**

1. Pergunta: Ao morrer, Cyra mantém as habilidades adquiridas e a forma ativa e volta com vida máxima ao ponto seguro da seção atual, enquanto inimigos e obstáculos são reiniciados?
   Resposta: Sim, ponto seguro da seção atual
2. Pergunta: Como os inimigos e obstáculos não serão salvos, eles reiniciarão ao reabrir o jogo. Durante a mesma sessão, ao apenas trocar de seção, o que deve acontecer?
   Resposta: Manter estados até morrer ou reabrir
3. Pergunta: O inimigo fica atordoado e disponível para absorção quando sua vida chega a zero, sem voltar a atacar até ser absorvido ou ocorrer um reinício?
   Resposta: Sim, ao chegar a zero, sem prazo

**Participantes e tempo informados:** Caio, Lucas e Victor; 22/10/2026; 15:02–15:35, America/Sao_Paulo; 33 min de reunião conjunta. Esclarecimentos posteriores atribuídos a Caio; duração não medida. Não extrapolar para tempo de programação ou aprendizagem.

**Intervenção registrada:** aprovar habilidades/limites/percurso e alterar morte/save. Inimigos e obstáculos são mantidos em memória entre seções, reiniciados na morte/reabertura e excluídos do JSON; morte mantém habilidades/ativa e volta ao ponto seguro atual com vida máxima; inimigo a zero permanece atordoado até absorção/reinício. Atualizadas as consequências documentais e a divergência de persistência em relação à fonte/P02. Equipe confirmou fonte/critérios/modelos e cinco simulações documentais sem contradições. T01 aprovado documentalmente com ajustes, sem testes do jogo ou medições futuras.

**Confirmações finais recebidas por formulário nesta conversa:**

1. Pergunta: Para completar o T01, vocês já conferiram os 12 RF/RNF da seção 2 do documento A02 com as páginas 3–4 do PDF e reconhecem que excluir inimigos/obstáculos do save altera a persistência descrita nas páginas 5–6?
   Resposta: Conferimos e reconhecemos a alteração
2. Pergunta: Vocês aprovam a adaptação dos casos de uso e do modelo de dados das seções 5–6 da A02: manter UC01–UC05 e os originais, usar JSON com seção/ponto seguro/vida/habilidades/forma ativa, deixando inimigos e obstáculos somente na memória da sessão?
   Resposta: Aprovamos a adaptação documental
3. Pergunta: Simulem agora no papel: (a) chave ausente/errada não abre o bloqueio; (b) após morrer em S2/S3, habilidades mantidas permitem superar os bloqueios reiniciados também no retorno; (c) morrer antes de absorver exige enfrentar o inimigo novamente, depois de absorver mantém a habilidade; (d) reabrir mantém vida/habilidades, reinicia o mundo; (e) save inválido inicia do zero com aviso, falha de escrita mantém memória e último arquivo válido. O percurso e as regras ficam coerentes nesses cinco casos?
   Resposta: Simulamos os cinco casos, sem contradições

Essas confirmações posteriores foram comunicadas por Caio, sem duração adicional medida. Encerram a revisão documental T01 com ajustes incorporados; não são aprovação de testes futuros nem evidência de implementação. Sem commit/envio automático.

## P04 — 22/10/2026 — A03 — preparação documental do protocolo

**Ferramenta:** Codex; modelo específico não aferido. **Data real:** 22/10/2026, America/Sao_Paulo. **Natureza:** exclusivamente documental; sem geração de código/mecânicas, instrumentação ou medições da demo.

**IDs conferidos:** P03 já registra decisões humanas da A02 e permanece intocado. O pedido abaixo solicita próximo ID livre e, na última linha, P03; foi registrado como P04 para evitar sobrescrever/duplicar o ID histórico. D03 estava livre e T03 é reservado à revisão documental conforme a instrução final. T02 não é atribuído nem contado como executado.

**Vínculos:** [D03 e revisão da A03 no diário](Diario_Experimento_Cyra.md); [A03 proposta](A03_Protocolo_Avaliacao_Curadoria.md); [ficha de trabalho T02, originalmente T03](evidencias/T02_A03_revisao.md); [saída original](saidas_originais/D03_A03.zip); [manifesto](saidas_originais/D03_SHA256.txt). Base humana A02 conferida no Git: `f145393`. Ajustados somente seus campos de versão de trabalho pendentes, sem regravar originais/tempos.

**Texto integral do prompt do desenvolvedor**, também preservado em [arquivo próprio](prompts/P04_A03_prompt_integral.md); somente finais de linha normalizados, inclusive a instrução final conflitante de numeração:

````text
# Contexto do Projeto e Escopo Arquitetural (Cyra)

Estamos desenvolvendo o jogo 2D "Cyra" utilizando Godot Engine .NET / C# na versão 4.7.2, com SDK .NET 8.0.422 e exportação para Windows Desktop x86_64.

O desenvolvimento faz parte de um estudo de caso acadêmico sobre programação assistida por IA com curadoria humana obrigatória. Arte, animações, áudios e narrativa final são de autoria 100% humana.

A metodologia é um estudo de caso do processo assistido: atendimento aos requisitos, defeitos, intervenções humanas, retrabalho, arquitetura, estabilidade e desempenho. Não haverá implementação manual independente, comparação de produtividade com desenvolvimento manual ou alegação de superioridade da IA sem evidência correspondente.

As atividades anteriores estão documentadas:

- A01: ambiente, cena de validação e exportação Windows aprovados por Caio e Lucas.
- A02: requisitos, percurso, habilidades, morte e save revisados pela equipe; T01 aprovado documentalmente com ajustes.
- Commit de encerramento da A02: f145393. Confira o histórico antes de utilizá-lo como referência.

O escopo fechado permanece:

- Movimento, combate, vida separada da UI e inimigo básico — A05.
- Pulo duplo e investida, obtidos por absorção de dois tipos de inimigos, com representação visual humana — A06.
- Três seções interligadas, dois bloqueios por habilidade e um save local estruturado único — A07.
- Recursos humanos, controles, transparência sobre assistência de IA e pacote desktop — A04/A09.

# Fontes e Decisões Já Aprovadas

Antes de produzir os entregáveis, leia:

- AGENTS.md.
- docs/Cronograma_Cyra_15-10_a_23-11-2026.md.
- docs/Guia_atividades_Cyra_2026.md.
- docs/A02_Escopo_Requisitos_Modelos.md.
- docs/evidencias/T01_A02_revisao.md.
- docs/Diario_Experimento_Cyra.md.
- docs/Diario_Experimento_IA.md.
- docs/Prompts_Utilizados.md.
- README.md.

Consulte a fonte primária indicada nesses documentos quando necessário para esclarecer uma exigência. Não substitua silenciosamente a fonte nem transforme sugestões do guia em requisitos originais.

Respeite especialmente as decisões humanas da A02:

- Habilidades adquiridas permanecem; uma fica ativa por vez.
- Inimigo a zero de vida fica atordoado, sem prazo, e é absorvido por comando.
- Trocar de seção mantém inimigos e obstáculos em memória.
- Morte e reabertura reiniciam inimigos e obstáculos.
- Morte mantém habilidades/forma ativa e retorna ao ponto seguro da seção atual com vida máxima.
- Save contém seção, ponto seguro, vida atual, habilidades adquiridas e habilidade ativa; não contém inimigos ou obstáculos.
- A mudança da persistência em relação à fonte original foi reconhecida pela equipe e deve aparecer no texto final.

# Tarefa Atual: Preparar a Atividade A03 (Avaliação Técnica e Registros da Curadoria Humana)

Crie docs/A03_Protocolo_Avaliacao_Curadoria.md como documento consolidado do método de avaliação.

Aproveite os registros existentes. Não crie outro diário independente, não duplique a tabela completa de requisitos da A02 e não reabra decisões já aprovadas.

Esta tarefa é documental. Não crie nem altere scripts C#, cenas, assets ou configurações do jogo. Não implemente ferramentas de medição, mecânicas futuras ou uma versão manual de comparação. Não execute medições da demo final, que ainda não existe.

Execute os cinco itens abaixo:

1. **Método de Avaliação e Critérios Verificáveis**

- Descreva o ciclo: requisito → prompt → saída original preservada → revisão humana → correção quando necessária → teste → integração → análise.
- Diferencie compilação, validação funcional, revisão arquitetural, medição de desempenho e aprovação documental.
- Vincule o protocolo aos 12 RF/RNF e aos cenários já previstos na A02 por referência, sem transcrever novamente toda a matriz.
- Defina como registrar atendimento, atendimento parcial, falha, bloqueio e ausência de execução, distinguindo situação do teste de situação do requisito.
- Para cada resultado, exigir identificação da versão, responsável, condições, resultado esperado/observado e evidência.
- Registre que aprovação da A01 ou da documentação A02 não comprova os requisitos da demo final.
- Preserve a distinção entre requisitos originais e alterações humanas de escopo/modelagem.

2. **Registro de Prompts, Versões e Intervenções Humanas**

- Especifique o registro mínimo por geração ou alteração assistida: atividade/requisito, prompt integral, ferramenta/modelo quando conhecido, arquivos afetados, saída original, revisão, achados, correções, testes e versão integrada.
- Use o diário principal, o índice de prompts, as saídas originais e os commits já existentes como estrutura.
- Diferencie ajustes feitos pela própria IA durante a geração de intervenções efetivamente realizadas por humanos.
- Permita revisão sem correção: não exigir alterações artificiais para demonstrar curadoria.
- Proponha categorias simples de defeito, como compilação, referência/sinal, colisão, estado, persistência, interface e ambiente.
- Distinga defeito identificado, intervenção realizada e resultado do reteste.
- Não atribua falhas da instalação ou aprendizagem da engine automaticamente ao código gerado.
- Explique como relacionar a saída original à versão revisada e integrada, preservando originais e sem precisar reproduzir todo o código no texto acadêmico.
- Não altere retroativamente os prompts ou arquivos originais preservados.

3. **Protocolo Reproduzível de Estabilidade e Desempenho**

- Prepare a proposta de protocolo vinculada à DEC10 da A02, para execução principalmente na A10.
- Defina uma máquina de referência e os dados necessários: CPU, GPU, RAM, sistema operacional, versões, identificação da build, resolução, modo de janela, renderizador e configuração de sincronização/limite de quadros.
- Dados já verificáveis podem ser levantados por consulta local somente de leitura. Diferencie equipamento observado de equipamento escolhido pela equipe para a medição.
- Proponha um percurso fixo pelas três seções, com combate, absorção, habilidades, bloqueios, transições e retorno. Descreva também as condições iniciais do save e dos estados do mapa.
- Separe cenários de persistência/reabertura das séries contínuas usadas para observar memória.
- Proponha aquecimento, duração, repetições e pontos de coleta compatíveis com as horas do projeto. Três repetições são uma sugestão do guia, não exigência da fonte.
- Defina o que será medido: FPS/tempo de quadro, memória, travamentos, erros e perda de estado.
- Escolha métodos de coleta realmente viáveis. Diferencie memória do processo e memória informada pela engine; não trate métricas distintas como equivalentes.
- Diferencie execução instrumentada no editor e execução do pacote fora dele; não misture resultados sem identificar condições e possível impacto da instrumentação.
- Se uma métrica exigir ferramenta ou instrumentação ainda indisponível, descreva a dependência e uma alternativa simples, sem implementá-la nesta tarefa.
- Proponha critérios operacionais de aceitação e valores quando necessários, identificados como propostas sujeitas à aprovação humana. Não atribua à fonte uma meta obrigatória de 60 FPS.
- Observe tendência de memória após aquecimento e ciclos repetidos. Não conclua vazamento por um aumento isolado nem ausência absoluta de vazamentos por um teste curto.
- Não produza números fictícios, resultados preenchidos ou comparações com implementação manual.

4. **Esforço, Testes e Modelos Mínimos de Registro**

- Defina como registrar separadamente preparação/aprendizagem, geração assistida, revisão humana, correção, teste e integração.
- Distinga duração decorrida, esforço por pessoa e reunião conjunta. Não duplique automaticamente uma duração conjunta como trabalho individual de todos.
- Use “não medido” quando necessário; não reconstrua tempos passados como se fossem cronometrados.
- Não use a duração da resposta da IA como tempo total de desenvolvimento.
- Aproveite as fichas do diário para detalhar etapas sem obrigar a reformatar todo o histórico.
- Inclua no protocolo modelos enxutos para futuras execuções funcionais, medições e defeitos/retestes.
- Mantenha campos observados sem preenchimento até execução real.
- Explique como consolidar requisitos atendidos, testes aprovados sobre executados, defeitos, correções e esforço, indicando o denominador e sem contar cenários não executados como aprovados.
- Se ainda faltar uma funcionalidade para executar um teste, registrar a dependência, sem inventar uma falha observada.
- Preserve T00 e T01. Confira os IDs existentes antes de reservar o próximo; cenários futuros da A02 não devem receber resultados ou numeração conflitante.

5. **Documentação, Rastreabilidade e Revisão Humana da A03**

- Organize os entregáveis no documento consolidado, com decisões metodológicas já registradas separadas das propostas novas.
- Liste somente os dados e escolhas que ainda precisam de confirmação humana: máquina de referência, condições de medição, duração/repetições, método de coleta, limites de aceitação e participantes efetivos.
- Avance com uma proposta utilizável, deixando as escolhas não confirmadas explicitamente pendentes.
- Registre este prompt integral com o próximo ID disponível em docs/Prompts_Utilizados.md.
- Acrescente ao diário o próximo registro documental e prepare a revisão humana da A03 com o próximo ID de teste disponível. Se for T02, identifique-o claramente como revisão documental da A03, sem reutilizá-lo depois para um teste diferente.
- Prepare o roteiro e a evidência prevista dessa revisão, sem declarar execução ou aprovação humana.
- Preserve uma cópia identificável da saída original da A03, com manifesto de integridade, seguindo a organização existente.
- Acrescente no README um link para o protocolo.
- Confira no Git o commit integrado da A02 e atualize somente os campos de versão de trabalho que ficaram aguardando esse hash, sem alterar o ZIP, os prompts originais ou os tempos registrados.
- Consulte as skills locais pertinentes e aplique apenas os procedimentos compatíveis com esta tarefa documental. Não crie registros fictícios de código ou mecânicas.
- Registre a data real de execução, sem retroagir à janela planejada de 16–20/10 e sem modificar o cronograma sem solicitação.

# Critério de Conclusão e Entrega

A proposta deve permitir que a equipe repita os testes nas mesmas condições, rastreie a contribuição humana e saiba quais dados coletar durante o desenvolvimento.

A preparação pela IA não significa aprovação humana da A03. O protocolo deve passar por revisão da equipe antes de ser tratado como método adotado.

Ao concluir, informe:

- Arquivos criados ou alterados.
- Registros e critérios existentes que foram aproveitados.
- Proposta de medição, suas limitações e dependências.
- Perguntas objetivas para a equipe fechar as decisões pendentes.
- Roteiro curto para revisar e aprovar documentalmente a A03.

Não implemente atividades futuras, não faça commit e não envie alterações ao GitHub.

Ao concluir os arquivos da A03, utilize as skills em `.codex/skills/` para preencher automaticamente o registro `D03`, o prompt `P03` e o teste `T03` em `docs/Diario_Experimento_Cyra.md` e `docs/Prompts_Utilizados.md`.
````

**Revisão humana posterior da A03:** P06/T02, Caio/Lucas/Victor, 27/10/2026, 13:16–13:57, 41 min conjuntos; método simplificado e coleta automática solicitados. Preparação original e consulta de hardware não eram aprovação/benchmark; suporte implementado em D04/T04, com curadoria técnica humana pendente. Sem commit/envio automático.

## P05 — 27/10/2026 — A03 — início da revisão humana

**Natureza:** conferência e orientação documental da revisão A03; D03/P04 e original preservados. A pedido do usuário, a ficha de trabalho passa de T03 para T02, ID até então livre. T03 no ZIP original é alias histórico, não outro teste. Não foram alterados scripts, cenas, assets ou configurações do jogo.

**Texto integral do pedido:**

```text
Já executei o prompt da A03. Pode conferir os arquivos gerados e me guiar pela revisão humana para preencher o T02, como fizemos na A02? Se houver outras questões que devemos responder e fazer em relação à essa etapa, por favor diga-nos também.
```

**Conferência:** conteúdo do protocolo, ficha, vínculos A02/D03, integridade do ZIP e manifesto verificados; participantes/data/tempo da revisão, máquina, condições, coleta e limites ainda dependem de relato humano. A conferência automática não aprova A03/T02 nem preenche medições. Preparação original datada de 22/10/2026 mantida; na abertura de P05, a revisão de trabalho iniciada em 27/10 ainda não tinha duração/participantes informados. Esses dados foram posteriormente recebidos em P06.

## P06 — 27/10/2026 — A03 — revisão humana, simplificação e coleta automática

**Pedido integral:** [P06_A03_revisao_coleta_automatica.md](prompts/P06_A03_revisao_coleta_automatica.md), incluindo as três configurações informadas e os pedidos de simplificação, logs e guia. **Vínculos:** D03/T02 (revisão documental), D04/T04 (suporte solicitado), protocolo A03-v2 e Guia_Lucas_Testes.md. Modelo específico não aferido.

**Decisões humanas relatadas por Caio:** Caio, Lucas e Victor revisaram em 27/10/2026, 13:16–13:57, America/Sao_Paulo, 41 min conjuntos. Lucas/MR02 é referência e executor; MR01/Caio e MR03/Victor são complementares potenciais. Pontos 2–8 são base inicial, com roteiro/limites simplificados e evolução rastreável; IA auxilia configuração/coleta/análise, Lucas observa e faz relato curto. Não atribuir benchmark, simulação de percentuais ou validação do coletor aos participantes sem relato.

**Autorização delimitada:** este pedido solicita expressamente a funcionalidade de logs no projeto e complementa a tarefa antes apenas documental de P04. D04 implementa suporte optativo de diagnóstico da A03; não antecipa combate, vida, habilidades, mapa ou save. Três skills locais foram aplicadas ao código/registro/rastreabilidade. Decisões humanas são dos participantes; edição de código/documentos e verificação automática são da IA.

**Saída:** coletor local em Scripts/Core, autoload, eventos na A01 existente, iniciador e analisador PowerShell, guia e protocolo leve. Modo comum sem coleta; teste ativado por argumento. Dados JSONL, configuração, eventos, FPS/memória do processo, logs nativos, resumo sem veredicto automático e relato mínimo. Eventos A05–A07 ficam para as implementações correspondentes.

**Verificações:** compilação final sem avisos/erros; ensaios automáticos do coletor e pipeline release headless, registrados em T04 e arquivo de checagens. Testes na máquina de Caio, não execução de Lucas nem benchmark gráfico. Na entrega P06, validação gráfica e piloto estavam pendentes; Caio concluiu a validação/revisão em P08, e o piloto da demo permanece futuro. Tempos de geração/edição/ensaio não medidos como esforço humano; ZIPs/manifestos D01–D03 preservados. Sem commit/envio automático.

## P07 — 27/10/2026 — A03 — conferência antes do commit e ajuste do iniciador

**Texto integral do pedido:**

```text
Ok, o que ainda falta nesta etapa para eu conseguir commitar todos os arquivos? Eu fui no caminho `C:\Users\caio\GIT\cyra\tools\Testing\Executar_Teste.cmd` e consegui testar normalmente, sem nenhum problema de lógica ou gráfico. Poderia me fazer as perguntas necessárias que ainda não respondi na documentação (ou outra coisa não necessariamente relacionada à documentação) para eu completar esta parte e commitar?
```

**Relato humano:** Caio informou teste sem problemas de lógica/gráficos. Não afirmou revisão de código nem uso de F9; essas informações não foram inventadas. A inspeção encontrou duas sessões sem session.jsonl, zero amostras/marcadores e perfil padrão Lucas indevido, pois o iniciador abria a exportação antiga build/windows.

**Intervenção da IA em D05:** corrigir destino padrão para build/a03-test, perguntar computador no CMD/usar NaoInformada sem seleção, sinalizar telemetria ausente no analisador. Não altera mecânicas/saves nem atribui autoria da edição ao humano. D04/P06 originais preservados. Reteste técnico sem janela com telemetria completa; naquela etapa P07 faltavam revisão humana e repetição gráfica, posteriormente concluídas em P08. Tempo humano não informado permanece não medido. Sem commit/envio automático.

## P08 — 27/10/2026 — A03 — validação humana e encerramento pré-commit

**Texto integral do pedido:**

```text
Refiz as seis etapas com F9 e tudo funcionou. Também revisei o código e não precisei alterar nada; não medi o tempo. Pode conferir os logs e atualizar os registros para eu commitar?
```

**Relato humano:** Caio executou as seis etapas com F9 e confirmou funcionamento; revisou o código sem alterações. Tempo da revisão não medido. Não atribuir os 41 min da reunião ou a duração do processo ao tempo dessa leitura.

**Conferência assistida:** sessão gráfica release 20261027T191317657Z-1b393526, perfil Caio, pacote 172238021bea85cd8e57dbc0ba8a998153c6f7e972926c4f2e52e31eef84fb1c; seis marcadores ordenados, 68 amostras, cabeçalho/fim, zero erros/avisos/linhas inválidas/descartes, exit_code 0. Quatro perdas/retomadas de foco limitam conclusões de desempenho. Dados brutos selecionados preservados em evidências com manifesto; relato recebido nesta conversa, sem reescrever o formulário bruto.

**Saída documental:** T04 aprovado para o coletor entregue, encerrando pendências humanas de D04/D05; T02 metodológico permanece concluído. Código revisado não foi alterado nesta tarefa. Originais D03/D04/D05 e sessões sem coleta preservados. Piloto em Lucas e eventos futuros A05–A07 permanecem encaminhamentos. Nenhum commit/envio automático foi feito.

## P09 — 30/10/2026 — A03 — análise da execução de Lucas e aceitação com ressalvas

**Texto integral do pedido:**

```text
Lucas terminou de fazer os seus testes, e me enviou uma pasta compactada, onde descompactei em [Cyra_A03_Teste_Feito](tools/Cyra_A03_Teste_Feito/). Poderia analisar os seus resultados e atualizar toda a documentação necessária para eu commitar e completar esta parte?
```

**Esclarecimentos humanos de Caio recebidos após a análise indicar cinco F9 e nenhum pulo:**

```text
Eu apostaria que ele se esqueceu, mas ele me disse que foi tudo conforme esperado, então pode se assumir os resultados foram bem.
```

```text
Acho que está muito tarde para pedir os testes novamente. Vamos prosseguir com eles estando incompletos e só assumir algumas coisas, tudo bem? Esta parte ainda é muito cedo no projeto então não tem problema.
```

**Decisão registrada:** Caio aceitou seguir sem repetição nesta etapa inicial, com base no relato positivo de Lucas, mesmo conhecendo a evidência incompleta. Essa aceitação não cria evento de pulo, sexta marca F9 ou confirmação de qual marca foi esquecida. Detalhes do erro prévio de script não fornecidos. Tempo de revisão/correção humana fora do jogo não informado/não medido. Lucas não relatou revisão de código; a curadoria de Caio em P08 permanece separada.

**Análise assistida:** sessão 20261030T033654411Z-86a000b7, Lucas, 30/10, 00:36:58–00:39:04 America/Sao_Paulo; pacote 172238021bea85cd8e57dbc0ba8a998153c6f7e972926c4f2e52e31eef84fb1c, mesmos 188 arquivos do jogo de P08. Coleta completa/124 amostras/cinco F9/zero erros ou avisos; ausência de pulo registrada como limite. CMD/PowerShell/guia recebidos iguais ao D04 original, anteriores à correção D05; não substituir fontes atuais nem declarar validação das correções por Lucas. Quatro perdas/retomadas de foco e métricas descritivas sem aprovação RNF04.

**Saída documental:** [análise Lucas/T04](evidencias/T04_A03_validacao_Lucas.md), cópias brutas e ferramentas recebidas com SHA-256, conferência independente, atualizações no diário/matriz/T02/T04/protocolo/README/guia e exclusão do pacote local pelo Git. A03 integrada em e0aaeed, etapa atual encerrada com ressalvas aceitas por Caio; demo/eventos A05–A07 seguem futuros. Não houve código/cena/configuração Godot alterado, nova geração D06, execução de scripts recebidos, regravação de originais ou commit/envio automático. Skills de diário/rastreabilidade aplicadas à análise documental.
