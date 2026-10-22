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
