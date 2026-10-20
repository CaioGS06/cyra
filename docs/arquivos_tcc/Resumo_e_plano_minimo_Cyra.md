# Cyra e o plano mínimo de conclusão do TCC

Análise dos materiais de `arquivos_tcc`, preparada em 13 de outubro de 2026 para Caio Greiffo Sampaio, Lucas dos Santos Craveiro e Victor Guerreiro Paiva Justo.

**Conclusão principal.** O compromisso acadêmico é produzir um estudo empírico sobre o uso intensivo de IA generativa na programação de um jogo, tendo uma demo jogável de Cyra como caso de estudo. O conjunto mínimo mais fiel ao que vocês registraram reúne uma demo desktop pequena, a comparação técnica com programação manual, um texto acadêmico com evidências e a documentação de encerramento aplicável. Um jogo comercial completo está expressamente fora do escopo.

Este plano distingue **compromissos documentados**, **recomendações para executá-los** e **pontos que dependem de confirmação institucional**. Não equivale a uma declaração de aprovação pela banca: os arquivos não contêm o regulamento completo, os critérios de avaliação nem o calendário oficial do segundo semestre.

**O que é o projeto**

O título que melhor conecta o pré-projeto e o relatório é **Cyra — Um estudo sobre o desenvolvimento de jogos focado em IA**. A ficha de inscrição e os primeiros documentos de extensão usam **O impacto e superestimação das IAs em produções de videojogos**. São formulações diferentes do mesmo percurso de pesquisa, mas o título oficial deve ser uniformizado com o orientador, preservando os documentos já entregues como histórico. [S1, S2, S3, S4]

O objetivo central do pré-projeto é desenvolver um jogo de plataforma 2D para avaliar e contrastar a estabilidade e o desempenho de código gerado com IA e de uma implementação manual. O relatório acrescenta requisitos concretos de gameplay, autoria humana da arte e do som e transparência sobre o uso da tecnologia. A pergunta de pesquisa pode ser formulada assim: **em quais partes do desenvolvimento de Cyra a IA ajuda, quais problemas produz e quanto trabalho humano é necessário para obter uma demo estável?** Essa formulação é uma síntese proposta, não uma transcrição oficial. [S1, S4]

Na narrativa fornecida nesta conversa, Cyra é uma alienígena de corpo robótico quase prismático, em uma região antiga devastada por uma queimada. Ela enfrenta guerreiros contrários à tecnologia e copia sua aparência e suas habilidades. A exploração depende dessa cópia para superar obstáculos. O visual bruto e fosco, Hollow Knight e Ori and the Blind Forest orientam o conceito artístico e a jogabilidade; não estabelecem um padrão obrigatório de volume ou acabamento para o TCC.

A pesquisa de percepção do público explica por que vocês optaram por concentrar a IA no código. Ela é uma frente complementar ao experimento técnico: opiniões dos participantes não comprovam FPS, estabilidade ou produtividade do código. [S4, S5]

**Objetivos e evidências que precisam existir**

| Objetivo registrado | Trabalho mínimo correspondente | Evidência para o texto e a demonstração |
|---|---|---|
| Mapear regras de negócio | Definir a cópia de habilidades, obstáculos, progressão e limites da IA | Regras curtas, numeradas e consistentes com o jogo |
| Analisar requisitos funcionais e não funcionais | Manter RF01–RF06 e RNF01–RNF06 rastreáveis | Tabela requisito → implementação → teste → resultado |
| Elaborar casos de uso | Atualizar o diagrama existente e explicar as ações principais | Diagrama coerente com a demo e descrições breves |
| Desenvolver o diagrama de dados | Adequar o modelo ao save realmente implementado | Diagrama atualizado e exemplo do save local |
| Construir e validar a prototipação | Entregar e testar a demo desktop | Executável, código e roteiro de teste reproduzível |
| Avaliar código de IA e manual | Comparar implementações equivalentes e registrar correções | Código preservado, protocolo e resultados medidos |
| Documentar e apresentar os resultados | Concluir o texto acadêmico e preparar a defesa | Texto, referências, tabelas de resultados e apresentação |
| Desenvolver a extensão curricular | Registrar atividade, relação com o público e devolutiva compatível | Registros de execução e encerramento aplicáveis |

Os cinco primeiros objetivos estão no pré-projeto; comparação e documentação aparecem no pré-projeto, no projeto de extensão e no cronograma atualizado. A dimensão social aparece na ficha e no projeto de extensão. [S1, S3, S4, S6, S7]

**Demo mínima mais fiel aos requisitos entregues**

| Requisito | O que demonstrar | Critério de aceite recomendado |
|---|---|---|
| RF01 Movimentação | Andar, pular, cair, gravidade e colisões | Percorrer a área de teste sem atravessar pisos/paredes ou ficar preso |
| RF02 Combate | Atacar, sofrer dano e atualizar vida | Jogador e inimigo recebem dano corretamente; vida visível acompanha o estado |
| RF03 Absorção | Copiar habilidade de inimigo derrotado por finalização ou comando | Derrotar o inimigo e obter a habilidade identificável |
| RF04 Mudança de estado | Trocar aparência/animação e permitir a nova ação | A transformação visual e a habilidade funcionam juntas |
| RF05 Fechadura e chave | Obstáculo que exige habilidade específica | Antes da cópia o obstáculo bloqueia; depois, a habilidade permite avançar |
| RF06 Transição | Passar entre três seções e conservar habilidades | Habilidade adquirida continua disponível após cada transição |
| Persistência local descrita no relatório | Conservar progresso relevante | Fechar e reabrir a demo recupera seção, habilidades e obstáculos persistentes |
| RNF01 Código com IA e curadoria | Uso intensivo de geração assistida com revisão humana | Registro identifica geração, problemas, alterações e responsável pela revisão |
| RNF02 Autoria artística humana | Arte, cenários, animações e som sem geração por IA | Inventário identifica autor e origem dos recursos usados |
| RNF03 Transparência | Aviso em menu/interface ou créditos sobre os módulos assistidos | Jogador encontra uma informação clara e específica |
| RNF04 Estabilidade e desempenho | Quadros estáveis e ausência de crescimento de memória que comprometa a demo | Medições em percurso e condições definidos, com falhas e limites registrados |
| RNF05 e RNF06 Ambiente e plataforma | Godot, scripts em C# conforme o relatório e executável desktop | Pacote abre fora do editor no sistema escolhido para a defesa |

Os critérios de aceite acima tornam os requisitos verificáveis; seus detalhes são recomendações, não novas exigências oficiais. O relatório não fixa 60 FPS, duração da partida, resolução, quantidade de inimigos, número mínimo de habilidades nem um limite numérico de memória. Vocês devem definir os parâmetros de teste e relatar o resultado real. [S4]

**A divergência sobre o tamanho do mapa importa.** `Título.docx` exclui mais de três seções e o relatório usa “limite máximo de três”; porém, RF06 exige transitar entre **as três seções distintas**. Portanto, o plano conservador é entregar **três áreas pequenas e interligadas**. Reduzir para uma ou duas muda a leitura literal do RF06 e precisa ser alinhado com o orientador. [S2, S4]

Uma implementação econômica pode usar: área 1 com movimentação, combate e primeira cópia; área 2 acessada por um obstáculo que exige essa habilidade, com um segundo inimigo copiável; área 3 acessada pela segunda habilidade, terminando em um objetivo simples. Superpulo e dash são opções coerentes com a ideia do colega. Lançar objetos pode entrar se necessário à concepção final; não aparece como obrigação nominal nos RF. Os exemplos de pulo duplo, fogo e investida do relatório também não exigem implementar todos eles.

Duas habilidades distintas são uma recomendação para demonstrar melhor a mecânica e duas transições, não um número imposto pelos arquivos. Preferir poucos inimigos reaproveitando lógica e animações, pequenas salas e um objetivo final simples. Um comando para recomeçar após derrota e instruções de controles ajudam a executar a demonstração; não precisam virar sistemas extensos.

**Restrições que não devem ser cortadas para ganhar tempo**

- IA restrita à lógica e ao código do jogo; arte, animação, cenários e composição sonora não podem ser gerados por IA segundo o relatório.
- Scripts gerados precisam passar por análise, adaptação e revisão humana antes de integrar a demo.
- Cópia precisa mudar habilidade **e aparência**, não apenas um valor invisível.
- Progressão precisa depender de habilidade, não apenas de derrotar todos os inimigos.
- Estado e save precisam corresponder ao compromisso de persistência local.
- Comparação técnica e documentação fazem parte do propósito acadêmico.
- Aviso ao jogador sobre os módulos assistidos precisa existir no produto.

O relatório afirma que a pixel art e as animações das transformações serão feitas manualmente pela equipe. Usem um conjunto pequeno de recursos próprios. Recursos humanos de terceiros para outros elementos não devem ser assumidos como substituição automaticamente autorizada do que vocês prometeram produzir; alinhem eventual reaproveitamento e documentem origem e permissão de uso. [S4]

**O que pode ser simplificado ou deixado de fora**

Um jogo completo, mapa grande, múltiplos biomas extensos, chefes complexos, diálogos ramificados, dublagem, trilha longa, muitos NPCs, multiplayer, publicação comercial, versões mobile/web e servidores não são necessários para atender aos RF apresentados. O save local permite dispensar um banco remoto e um backend web. A palavra “backend” nos textos descreve a lógica interna do jogo e não cria uma obrigação de construir uma API. [S2, S4]

Não recriem em código próprio gravidade e colisões que a engine já fornece. Não implementem todos os usos de IA mencionados nas fontes bibliográficas: exemplos de geração de música, terreno, imagens e diálogos são conteúdo de pesquisa, e alguns contradizem as restrições do produto. O conversor Markdown → PDF e os arquivos usados para testá-lo também não são uma entrega obrigatória de Cyra.

Um save simples, local e único é compatível com o recorte; seleção de múltiplos slots não foi exigida. Conservem a posição/seção pertinente, habilidades, estado de obstáculos e inimigos derrotados quando afetarem a continuidade. Vocês podem escolher o formato de arquivo, mantendo modelo, implementação e texto alinhados.

**Como executar o experimento sem fazer dois jogos inteiros**

O pré-projeto exige comparação com uma implementação manual, mas não define claramente a extensão dessa segunda implementação. Uma comparação de **módulos equivalentes** pode viabilizar o trabalho, desde que o orientador aceite esse recorte e o texto deixe claro que a conclusão vale para os módulos testados. Os arquivos não permitem afirmar que uma comparação mínima de qualquer tamanho já está aprovada. [S1, S3, S7]

Recorte recomendado: escolher dois ou três sistemas significativos, como absorção/troca de estado, obstáculo com habilidade requerida e save/transição. Usar a mesma especificação e os mesmos cenários para duas implementações: uma assistida por IA, com o retrabalho humano contabilizado, e outra escrita manualmente sem gerar o código com IA. O restante do jogo, os recursos visuais, o hardware e as condições de execução devem ser comuns. Evitem comparar dois produtos com funcionalidades diferentes.

Preservem três estados do código assistido: saída original do agente, versão revisada e versão integrada. Isso permite explicar se a geração inicial já funcionava ou se dependia de alterações importantes. Se a saída original não compilar, registrem a falha; não a transformem em um dado de desempenho inventado. Comparem o desempenho de versões executáveis e apresentem separadamente a quantidade de correções até chegar a elas.

| Medida recomendada | Como registrar de forma útil |
|---|---|
| Tempo de desenvolvimento | Tempo de prompts/geração, revisão, correção, integração e implementação manual |
| Defeitos e retrabalho | Erro, módulo, impacto, correção aplicada e tempo gasto |
| Correção funcional | Mesmos cenários e resultados esperados para ambas as versões |
| Estabilidade | Travamentos, exceções, perda de estado e bloqueios de progressão |
| Desempenho | FPS/tempo de quadro e memória no mesmo percurso e equipamento |
| Arquitetura e manutenção | Responsabilidades, acoplamento, duplicação e esforço para uma alteração equivalente |

Registrar data, ferramenta/modelo utilizado, versões de Godot e C#, configuração do computador, cenário, tempo da execução e versão do código. A quantidade de rodadas não foi fixada; definir um protocolo repetido e praticável antes de medir. No prazo curto, três execuções comparáveis por cenário são uma sugestão, sem tratar isso como prova estatística ampla.

O diário pode ter os campos: `data; requisito; módulo; ferramenta/modelo; prompt; saída original; problema; intervenção humana; responsável; tempo; versão/commit; teste; resultado`. Um único arquivo de registros e uma pasta de evidências bastam; não é preciso criar um sistema de gerenciamento próprio.

Para avaliar se o produto ficou “genérico”, explicitem critérios observáveis: mimetismo funcional, identidade visual coerente, progressão ligada às habilidades e adequação do código às regras de Cyra. Autoria humana e adequação ao conceito não provam inovação de todo o gênero. A justificativa de “inovar o metroidvania” deve ser apresentada como intenção de design, sem prometer demonstrar que o gênero atingiu um platô ou que a demo revolucionou o mercado.

O projeto de extensão menciona hipóteses sobre a origem do código produzido. Registrem semelhanças verificáveis e suas limitações. Não é possível identificar automaticamente a fonte original ou o material de treinamento de um trecho apenas pelo resultado do modelo. Uma hipótese não deve virar acusação ou conclusão comprovada. [S3]

**O que já existe e o que ainda não foi comprovado nesta pasta**

| Frente | Evidência encontrada | Próximo trabalho |
|---|---|---|
| Tema, equipe e objetivos | Ficha, pré-projeto e resumo de escopo | Uniformizar título e orientador oficial |
| Pesquisa de percepção | Relatório com 43 respostas e apresentação com gráficos | Recuperar perguntas, base original e critérios de cálculo |
| Requisitos | RF01–RF06 e RNF01–RNF06 no relatório | Conectar a implementação e testes |
| Casos de uso | Diagrama externo e descrição no relatório | Conferir com a demo final e ajustar notação se necessário |
| Modelo de dados | PNG, PNG transparente, SVG e SQL | Completar o que o save real exigir |
| Organização | Cronogramas e declaração de uso de Git/Scrum | Atualizar responsáveis, progresso real e datas |
| Desenvolvimento | Relatório declara ambiente Godot/C#, início de prototipação e revisão de prompts | Demonstrar o código e a build atuais, ausentes dos materiais analisados |
| Comparação técnica | Objetivo e atividade prevista | Produzir protocolo, implementações e resultados |
| Extensão | Formulários 1, 2 e 5 preenchidos e versões indicadas como assinadas | Verificar registros e encerramento efetivamente aceitos |

“Ausente nesta pasta” não significa que vocês não fizeram a atividade. Não encontrei nos materiais fornecidos executável, projeto Godot, histórico de prompts/commits, dados brutos do Forms, medições técnicas ou comparação manual concluída. O cronograma registra planejamento, não conclusão.

O diagrama de dados contém `SAVE_JOGADOR`, `SECAO`, `HABILIDADE` e `OBSTACULO_ESTADO`. Ainda não explicita a posição exata do jogador ou os inimigos derrotados citados no relatório. `is_desbloqueada` e `is_superado` estão em entidades sem vínculo explícito com um save, o que exige atenção se houver vários saves. Para um único save local, vocês podem organizar um arquivo de estado simples e atualizar o diagrama para refletir essa decisão. `qt_uso` não basta, por si só, para concluir que todas as habilidades precisam ter cargas limitadas; descrevam a regra adotada. A sintaxe SQL com `GO` não transforma a adoção de SQL Server em exigência. [S4, S8]

**Correções documentais que precisam entrar no fechamento**

1. **Dados sobre intenção de jogar.** O relatório informa 55,8%. O gráfico da página 12 da apresentação mostra “sim” = 2 + 7 + 11 = 20 e “não” = 8 + 8 + 2 = 18, totalizando apenas 38 respostas representadas. Se o denominador for 43, “sim” corresponde a 46,5%; se forem 38 respostas válidas para essa pergunta, corresponde a 52,6%. Nenhuma dessas leituras reproduz 55,8%. Recuperar a base original e verificar respostas omitidas, denominador e gráfico antes de corrigir a versão final. Não alterar arquivos assinados em silêncio. [S4, S5]
2. **Média de aceitação para código.** O gráfico da página 10 mostra 2, 5, 7, 16 e 13 respostas nas notas 1 a 5. A média ponderada é 162/43 = 3,7674, arredondada para **3,77**, como no relatório. O slide de médias informa **3,76**. Conferir a base e padronizar arredondamento. [S4, S5]
3. **Amostra própria e amostra bibliográfica.** A pesquisa do grupo tem 43 participantes; o artigo de Alharthi tem 42 respondentes e 9 entrevistados. Não misturar os números nem atribuir entrevistas do artigo à equipe. [S4, S9]
4. **Títulos e orientadores.** Ficha de inscrição e pré-projeto deixam o orientador sem preenchimento efetivo. Cristina dos Santos Có está identificada nos documentos de LES. Os testes de formatação mencionam Valdir Pedro Tobias no Markdown e Luiz Alexandre da Costa Araujo no PDF. Esses testes não comprovam quem é o orientador do TCC. [S1, S3, S4, S6, S10]
5. **Escopo.** Manter a demo e esclarecer três áreas conforme RF06; uma redução requer alinhamento.
6. **Calendário.** A planilha contém cronogramas antigos/modelos, integrantes que saíram e datas invertidas. A área atual é `Gráfico de Gantt (2)!A21:D32`, com semanas no cabeçalho das linhas 19–20. Não usar tarefas do modelo superior, como entrevistas sobre organização, como obrigações do grupo. [S7]
7. **Conclusões.** Os dados de percepção representam a amostra consultada, não todo o mercado. O estudo técnico representa o contexto e os módulos experimentados. Não decidir previamente que a IA será boa ou ruim e depois selecionar apenas evidências favoráveis.

O total de 38 respostas do gráfico de intenção de jogar é uma limitação adicional importante: cinco dos 43 participantes não aparecem no cruzamento exibido. Os motivos não são recuperáveis sem os dados originais. O gráfico sobre transparência da mesma página representa 38 “sim” e 5 “não”, compatível com os 88,4% informados.

**Entregas para o TCC e para a banca**

| Entrega | Status da obrigação nos arquivos | Conteúdo mínimo proposto |
|---|---|---|
| Demo jogável desktop | Compromisso expresso | RF/RNF, progressão, transformação, save e créditos/aviso |
| Texto acadêmico concluído | Compromisso expresso | Problema, objetivos, teoria, metodologia, desenvolvimento, resultados comparativos, discussão, limitações e conclusão |
| Diagramas e requisitos | Objetivos expressos | Versões consistentes com o que foi implementado, no texto ou apêndices |
| Resultados do experimento | Objetivo central expresso | Implementações equivalentes, medições, correções e análise |
| Fonte, build e instruções | Pacote recomendado para comprovar a entrega | Código organizado, executável e instruções de execução/controles |
| Apresentação e demonstração | Banca prevista no calendário | Problema, método, resultados, contribuição humana e percurso jogável |
| Registro de quatro reuniões no anexo V | Exigência explícita no calendário disponível | Registro real das reuniões no modelo oficial, que não está na pasta |
| Versão final corrigida em PDF | Exigência explícita no calendário disponível | Correções após avaliação, segundo o procedimento vigente |

O pré-projeto fala em consolidar um artigo. Isso exige um texto acadêmico próprio com o experimento; não comprova obrigação de publicar em periódico ou realizar um novo simpósio. O modelo SICT é um resumo de uma página, e não substitui automaticamente o TCC completo.

`ABNT.docx` é apenas um modelo de capa. O teste de conversão em PDF contém a tradução de um artigo de terceiros e metadados de teste; não é o texto final da pesquisa de Cyra. Reaproveitar referências com atribuição correta e escrever o método, o desenvolvimento e os resultados próprios. Para a formatação e a extensão final, recuperar o modelo vigente disponibilizado pelo curso; a pasta não contém todas as normas institucionais. [S1, S10, S11, S12]

As fontes bibliográficas apresentam possibilidades e riscos da IA; não obrigam vocês a implementar geração de arte, música ou NPCs inteligentes. O artigo principal usa questionários e entrevistas sobre percepções e reconhece limites de amostra, autorrelato e comparação. Ele fundamenta o estudo, mas não fornece resultados de desempenho de Cyra. [S9, S13]

**Entregas de extensão curricular e LES**

| Formulário | O que existe | Ação necessária ou ponto de confirmação |
|---|---|---|
| LES 1 Identificação | DOCX preenchido e PDF apresentado como assinado | Preservar, confirmar aceite e esclarecer a carga horária |
| LES 2 Projeto | DOCX preenchido e PDF apresentado como assinado | Preservar plano e registrar mudanças aceitas, se houver |
| LES 3 Autorização institucional | Modelo em branco | Necessário se houver instituição parceira/uso institucional aplicável; confirmar o enquadramento desta extensão |
| LES 4 Registro de conteúdo | Modelo em branco | Registrar atividades reais e obter vistos/assinatura do professor conforme solicitado |
| LES 5 Relatório parcial/final | Texto datado de 25/05/2026, com pesquisa e trabalho futuro | Confirmar se encerrou a disciplina ou se deve receber atualização final |
| LES 6 Declaração de conclusão | Modelo em branco | Confirmar se aplicável e quem é a instituição/responsável autorizado a assinar |

A ficha informa **80 horas de carga horária total**, mas não explica se a comprovação é por integrante, por grupo ou por outra forma de contabilização. Não dividir automaticamente por três nem afirmar 80 horas por aluno sem confirmação. O modelo LES 4 tem data, atividade e visto; manter um controle auxiliar de tempo e evidências pode sustentar a comprovação. [S6, S14]

O texto do relatório tem “parcial/final” no título do modelo, mas descreve prototipação e entrega ainda futuras. O nome do formulário não prova que a disciplina continua pendente, nem que o TCC foi concluído. Dado que vocês informam que esses documentos foram entregues para concluir LES, confirmar o aceite antes de refazer documentos desnecessariamente.

A comunidade indicada na ficha é o público sem conhecimento profundo das áreas criativas afetadas pela IA. Uma devolutiva curta dos resultados em linguagem acessível para esse público é recomendável para tornar visível o resultado social já previsto, aproveitando a pesquisa e a apresentação existentes. O canal, a carga e a necessidade dessa ação adicional dependem daquilo que já foi aceito pela professora; não é uma obrigação nova comprovada por um edital nesta pasta. Não inventar empresa parceira, assinatura ou atividade retroativa. [S3, S6, S14]

**Divisão prática entre os três integrantes**

A distribuição abaixo é uma recomendação baseada nos papéis de `Título.docx`: Caio desenvolvedor, Lucas gerente/desenvolvedor e Victor roteirista. A atribuição de arte e áudio a Victor precisa ser ajustada à habilidade e disponibilidade reais; não há confirmação de que ele seja artista ou compositor. [S2]

| Pessoa | Responsabilidade principal | Resultado de sua frente | Apoio e revisão |
|---|---|---|---|
| Caio | Núcleo de gameplay e integração | Movimento, combate, cópia, mudança visual/estado, obstáculos e evidências de geração/revisão | Lucas revisa código e testes; Victor fornece o conceito e recursos |
| Lucas | Gestão, persistência, comparação e qualidade | Cronograma, save/transições, implementações manuais escolhidas, protocolo, medições e build | Caio revisa; os três executam o percurso final |
| Victor | Identidade e conteúdo da demo, escrita e comunicação | Narrativa curta, desenho das três áreas, arte/animações humanas organizadas, curadoria das fontes e apresentação | Caio/Lucas ajudam com recursos e integração; todos escrevem sua parte técnica |
| Os três | Texto final, encerramento e defesa | Documento coerente, registros verdadeiros, apresentação ensaiada e resposta às perguntas | Cada autor revisa o conteúdo dos demais |

Evitar deixar “documentação” inteiramente para Victor: Caio deve explicar o código assistido e as correções; Lucas deve explicar o save, o método e os números; Victor consolida linguagem, contexto e apresentação. A versão manual do experimento precisa ser identificada como tal e separada dos módulos gerados com IA.

Primeiras ações: escolher uma pessoa por tarefa, inventariar o que já funciona, definir o pequeno percurso das três áreas, selecionar os módulos comparados e começar o diário. Manter uma reunião semanal curta e uma lista compartilhada com responsável, evidência de conclusão e impedimento, reaproveitando Git e a organização já declarados. Nenhuma tarefa está “pronta” só por constar no cronograma.

**Sequência de execução para prazo curto**

Como não há data oficial atual nos arquivos, este é um exemplo de **seis semanas de trabalho**, ajustável ao tempo real e ao estado do jogo. Não é um novo prazo institucional. Se já houver implementação, começar pelo primeiro bloco ainda incompleto.

| Bloco | Prioridade de execução | Evidência ao terminar |
|---|---|---|
| Primeiros 1–3 dias | Conferir prazo/orientador, auditar código e Forms, fechar escopo e tarefas | Lista única de pendências, regras e protocolo inicial |
| Semana 1 | Fazer uma área com movimento, combate, cópia e obstáculo; preparar arte mínima | Um ciclo completo jogável com registro da IA |
| Semana 2 | Fazer transições, três áreas pequenas e save | Percurso completo com estado preservado |
| Semana 3 | Concluir o núcleo, versões manuais e controles/créditos | Demo com funcionalidades congeladas e pares comparáveis |
| Semana 4 | Executar testes e medir; corrigir falhas de progressão | Resultados, lista de defeitos e versão candidata |
| Semana 5 | Concluir texto, diagramas, análise e documentação aplicável | Versão enviada para revisão do orientador |
| Semana 6 | Aplicar revisão, testar pacote fora do editor e ensaiar | Pacote final, apresentação e roteiro de defesa |

A escrita, o registro do experimento e a criação dos recursos humanos começam no primeiro bloco e acompanham o desenvolvimento. Havendo menos tempo, comprimir o tamanho e o acabamento do conteúdo; alterações dos RF, da comparação ou das restrições devem ser explicitadas e alinhadas. Reservar os últimos dias para falhas reais e apresentação, sem acrescentar mecânicas.

**Datas que os arquivos realmente informam**

O documento institucional é destinado aos ingressantes do **5º ciclo no primeiro semestre de 2026** e, em outro bloco, aos ingressantes do **6º ciclo naquele mesmo semestre**. Ele informa para o 5º ciclo: inscrição em 16/03, pré-projeto em 13/04, relatório parcial em 08/06 e avaliação até 17/08. Para a turma do 6º ciclo do primeiro semestre: TCC em `.doc` em 11/05, anexo V com quatro reuniões, resultado de plágio em 25/05, bancas de 08/06 a 13/06 e versão corrigida em PDF até 25/06. Essas datas já passaram e o bloco de 6º ciclo não deve ser aplicado automaticamente à turma de vocês no segundo semestre. [S12]

O documento pede envio do TCC concluído pelo orientador. Nas etapas de pré-projeto e relatório parcial, admite envio por um integrante caso ainda não haja orientador. Essas permissões das etapas iniciais não comprovam a mesma dispensa no fechamento.

Novembro de 2026 é uma **estimativa de finalização da demo** no resumo e no relatório. O Gantt atualizado planeja apresentação nas semanas 49–50; no cabeçalho da planilha isso começa em 03/12 e 10/12, e no PDF do projeto aparece 05/12 e 12/12. Essa diferença vem de cabeçalhos semanais distintos. Nenhuma dessas marcações substitui a data oficial de entrega e banca. [S2, S3, S4, S7]

Confirmar com o orientador/coordenação apenas o que não está resolvido: data e formato atuais, título e orientação, extensão aceita da comparação manual, leitura das três seções, modelo/anexo V, forma de contabilizar as 80 horas e pendências de LES 3/4/5/6. As demais tarefas podem avançar sem esperar.

**Checklist de fechamento**

- [ ] Título e orientação oficial consistentes nos novos documentos.
- [ ] Demo abre fora do editor e permite concluir o percurso.
- [ ] RF01–RF06 e RNF01–RNF06 têm evidência e resultado de teste.
- [ ] Habilidade altera ação e aparência e permite superar bloqueio específico.
- [ ] Três seções pequenas e save funcionam conforme o escopo adotado.
- [ ] Arte/animação/áudio seguem autoria humana e inventário de recursos.
- [ ] Créditos/menu explicam quais sistemas tiveram assistência de IA.
- [ ] Prompts, código original, correções e versões finais estão preservados.
- [ ] Comparação manual tem a mesma especificação e condições registradas.
- [ ] Texto contém resultados reais, limitações e contribuição de cada integrante.
- [ ] Dados do Forms conferidos; divergências percentuais e de arredondamento resolvidas.
- [ ] Diagramas correspondem à implementação final.
- [ ] Reuniões e documentos institucionais aplicáveis estão registrados e aceitos.
- [ ] Prazos oficiais, envio pelo responsável correto e revisão final confirmados.
- [ ] Apresentação ensaiada; pacote e cópia de segurança preparados.

**Fontes e limites desta análise**

Foram extraídos e confrontados os textos dos DOCX, do pré-projeto `.doc` binário, dos PDFs, das planilhas, do PPTX e dos Markdown. Foram inspecionados visualmente os diagramas, a imagem do cronograma e páginas relevantes dos PDFs com gráficos. Os PDFs assinados foram usados como versões de referência de conteúdo; esta análise não é uma validação criptográfica de assinaturas.

O `video.mp4` tem aproximadamente **31 minutos e 5 segundos**, com trilhas de vídeo e áudio e sem trilha de legendas identificada nos metadados. Não havia ferramenta de transcrição/decodificação audiovisual disponível para analisar a palestra. Portanto, seu conteúdo falado não sustenta nenhuma obrigação ou conclusão deste plano. Sua descrição pelo usuário e a referência à palestra no projeto foram consideradas apenas como contexto bibliográfico. Essa é a limitação de cobertura do material fornecido.

| Identificador | Arquivos e papel na análise |
|---|---|
| S1 | [PRE PROJETO.doc](<C:/Users/caio/Desktop/cyra/arquivos_tcc/PRE PROJETO.doc>) — pergunta técnica, objetivo, comparação e texto acadêmico |
| S2 | [Título.docx](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Título.docx>) — demo, equipe, prazo estimado e exclusões |
| S3 | [Projeto de extensão DOCX](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(A) LES - 2 - Projeto Extensão Curricular ADS.docx>) e [PDF](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(CL) LES - 2 - Projeto Extensão Curricular ADS.pdf>) — metodologia, ferramentas, cronograma e resultado social |
| S4 | [Relatório DOCX](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(A) LES - 5 - Relatério Parcial Final ADS.docx>) e [PDF](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(CL) LES - 5 - Relatório Parcial Final ADS.pdf>) — RF/RNF, regras, persistência e resultados declarados |
| S5 | [Apresentação da pesquisa](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Perspectiva sobre o uso de IA generativa no desenvolvimento de software.pdf>) — método, gráficos e divergências numéricas |
| S6 | [Ficha de inscrição](<C:/Users/caio/Desktop/cyra/arquivos_tcc/FICHA INSCRIÇÃO CAIO LUCAS VICTOR.docx>), [LES 1 DOCX](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(A) LES - 1 - Ficha Identificação Projeto ADS.docx>) e [PDF](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(CL) LES - 1 - Ficha Identificação Projeto ADS.pdf>) — tema, público e 80 horas |
| S7 | [Planilha Gantt](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Cronograma_Gantt - Copiar.xlsx>) e [Cronograma antigo](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Cronograma.png>) — distinguir plano atual, modelos e histórico |
| S8 | [Caso de uso](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Untitled Diagram.png>), [Modelo PNG](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Untitled.png>), [PNG transparente](<C:/Users/caio/Desktop/cyra/arquivos_tcc/svgviewer-png-output.png>), [SVG](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Untitled.svg>) e [SQL](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Untitled.sql>) — ações e estado do jogo |
| S9 | [Artigo original](<C:/Users/caio/Desktop/cyra/arquivos_tcc/jintelligence-13-00060-v2.pdf>) e [Tradução Markdown](<C:/Users/caio/Desktop/cyra/arquivos_tcc/IA Generativa no Game Design.md>) — estudo externo de Alharthi, com 42 respondentes e 9 entrevistas |
| S10 | [Markdown formatado de teste](<C:/Users/caio/Desktop/cyra/arquivos_tcc/IA Generativa no Game Design - Formatado.md>) e [PDF de teste](<C:/Users/caio/Desktop/cyra/arquivos_tcc/IA_GENERATIVA_GAME_DESIGN.pdf>) — conversão/formatação, sem autoridade para definir título, orientação ou autoria do TCC |
| S11 | [ABNT.docx](<C:/Users/caio/Desktop/cyra/arquivos_tcc/ABNT.docx>) — modelo de capa |
| S12 | [Calendário institucional](<C:/Users/caio/Desktop/cyra/arquivos_tcc/2026-1-TCC-DATAS.docx>) — procedimento e datas do primeiro semestre |
| S13 | [Texto de Bernard Marr](<C:/Users/caio/Desktop/cyra/arquivos_tcc/The Role Of Generative AI In Video Game Development.docx>) — exemplos de uso de IA, como referência, sem ampliar o produto |
| S14 | [LES 3](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(N) LES - 3 - Autorização Institucional ADS.docx>), [LES 4](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(N) LES - 4 - Registro Conteúdo Extensão ADS.docx>) e [LES 6](<C:/Users/caio/Desktop/cyra/arquivos_tcc/Curricularização/(N) LES - 6 - Declaração Conclusão Projeto ADS.docx>) — modelos de autorização, registro e encerramento |
| S15 | [Resumo SICT](<C:/Users/caio/Desktop/cyra/arquivos_tcc/MODELO_DE_RESUMO_27_SICT_FATEC-SP.docx>) e [Template de simpósio](<C:/Users/caio/Desktop/cyra/arquivos_tcc/template - I simposio de CD.pptx>) — modelos de divulgação, sem prova de obrigação de nova submissão |
| S16 | [Vídeo da palestra](<C:/Users/caio/Desktop/cyra/arquivos_tcc/video.mp4>) — identificado; conteúdo falado não analisado |

O modelo SICT pede PDF em uma página A4, duas colunas, com introdução, metodologia e materiais, resultados, conclusões e referências, sem Abstract. Essas regras são pertinentes a uma submissão nesse formato; não definem a estrutura obrigatória do TCC completo. O template de apresentação contém uma sequência sugerida de introdução, objetivos, fundamentação, metodologia, resultados e considerações finais, que pode ser reaproveitada sem criar uma nova obrigação de evento. [S15]
