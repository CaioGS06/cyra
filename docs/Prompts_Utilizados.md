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
