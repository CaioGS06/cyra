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
