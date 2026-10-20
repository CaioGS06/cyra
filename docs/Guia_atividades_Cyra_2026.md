# Guia de execução das atividades de Cyra

Este guia detalha o [cronograma de 15/10 a 23/11/2026](C:/Users/caio/Desktop/cyra/docs/Cronograma_Cyra_15-10_a_23-11-2026.md). A fonte dos compromissos é o [PDF indicado pelo grupo](<C:/Users/caio/Downloads/(CLV) LES - 5 - Relatorio_Parcial_Final_ADS_assinado (1).pdf>). As datas de 16/11 e 23/11, a disponibilidade diária, a experiência da equipe e o estado inicial de 0% foram informados pelo usuário. Esta revisão incorpora a decisão do grupo de retirar a implementação manual independente para comparação.

Os passos, horas, responsáveis, exemplos e nomes dos registros são sugestões práticas. As indicações de páginas permitem distinguir a exigência documentada da forma proposta para cumpri-la. Nenhuma atividade ou conclusão abaixo usa os outros anexos da conversa como base.

**Rotina compatível com os horários atuais**

Usar a tabela diária do cronograma: Caio tem 21 h/semana, Lucas 11 h e Victor 18 h. Horários indefinidos contam como zero garantido; 02/11 segue livre de tarefa obrigatória. Não redistribuir essas horas como se todos tivessem a mesma disponibilidade diária.

Em blocos de uma hora, escolher uma única revisão, teste ou correção delimitada, incluindo o registro. Nas quartas e sextas, concentrar desenvolvimento que precisa de continuidade. Nos fins de semana, Caio concentra integração e escrita técnica; Victor usa o domingo para recursos humanos e consolidação do texto. Pausas, testes e documentação cabem nos blocos informados.

Os desenvolvedores produzem descrições e evidências prontas das próprias tarefas; Victor consolida, sem escrever sozinho toda a documentação. A arte permanece humana, com apoio pontual de Caio. O escopo não aumenta em razão das horas adicionais de programação.

**Mudança de metodologia registrada em 15/10**

Por decisão do grupo, não haverá versões manuais independentes nem comparação entre programação manual e IA. O PDF de base menciona esse contraste na página 6: explicitar a alteração no texto final e comunicar a metodologia atual à orientação. O trabalho passa a avaliar o processo assistido, sua curadoria humana e os resultados funcionais e de qualidade da demo. Não apresentar a etapa retirada como cumprida.

O ciclo é: **requisito definido → prompt registrado → saída original preservada → análise e adaptação humana → teste → integração → documentação**. Uma função que compila não está automaticamente validada. A comparação pontual antes/depois de uma correção serve para explicar retrabalho, não para provar superioridade da IA sobre um desenvolvimento independente.

**A01 — Preparar ambiente, aprender Godot e exportar — 15–18/10**

Base: Godot, C#, ferramentas gratuitas e desktop nas páginas 2–4; Git já é citado na página 6. Caio lidera, Lucas confere e Victor registra os procedimentos. Estimativa: 7 h de Caio, 3 h de Lucas e 1 h de Victor.

1. Conferir instalação do Godot com suporte a C# e do ambiente necessário para compilar. Escolher uma versão comum entre os dois desenvolvedores e registrar qual é.
2. Criar um projeto 2D de teste e praticar cena/nó, script C# anexado, entrada, sinal e colisão simples, sem construir um jogo de treinamento separado. Caio e Lucas conferem esse fluxo. Criar Git sem arquivos gerados desnecessários.
3. Executar um script C# mínimo e exportar uma build vazia para o desktop escolhido. Testar essa build fora do editor; resolver o processo de exportação agora.
4. Fazer uma primeira versão identificável no Git e conferir que o outro desenvolvedor consegue abrir o projeto.

**Documentação:** iniciar o README com versões, como abrir, compilar e exportar. No texto principal, preencher o ambiente e a experiência inicial: conhecimento de C#/Java, mas ausência de experiência prévia com Godot. Separar tempo de aprendizagem de erros do código gerado quando possível. Registrar erros de instalação reais no diário quando afetarem tempo ou decisões. Isso permite reproduzir o ambiente e evita gastar a última semana descobrindo que só funciona no editor.

**Fluxo de exemplo:** criar uma cena com texto “Cyra em teste” → executar no editor → exportar → abrir o executável → Lucas repetir o procedimento.

**Pronto quando:** ambos abrem o mesmo projeto e existe uma exportação que inicia fora do editor.

**A02 — Fechar percurso, requisitos e modelos — 15–18/10**

Base: regras e RF/RNF nas páginas 1–4, casos de uso e modelo de dados nas páginas 4–6. O relatório declara a modelagem já realizada; esta atividade confere e adapta o que está no próprio PDF. Victor lidera a organização; Caio e Lucas decidem a solução técnica. Estimativa: 1 h de Caio, 1 h de Lucas e 4 h de Victor.

1. Transcrever RF01–RF06 e RNF01–RNF06 para uma tabela de acompanhamento, sem ampliar o escopo. Para cada item, definir uma demonstração objetiva de atendimento.
2. Desenhar três seções curtas, a posição de dois inimigos copiáveis, dois bloqueios e um fim claro. Usar o mesmo conjunto de pisos nas três áreas.
3. Escolher duas habilidades simples, por exemplo pulo duplo e investida. Definir aquisição, habilidade ativa, troca entre habilidades e o que acontece ao morrer, impedindo que o jogador fique sem uma chave necessária.
4. Conferir os casos de uso e especificar o save: seção e ponto seguro de retorno, vida, habilidades, habilidade ativa, inimigos relevantes derrotados e obstáculos superados. Atualizar o modelo somente onde a implementação exigir.

**Documentação:** no texto principal, registrar escopo, regras, requisitos e critérios de teste; inserir diagrama de casos de uso e modelo de dados coerentes. Um desenho simples do percurso basta. Distinguir dados estáticos, como o nome da habilidade, de dados de progresso, como já tê-la adquirido. A tabela será usada até a revisão final.

**Fluxo de exemplo:** Cyra encontra passagem alta → derrota inimigo A → copia pulo duplo → cruza a passagem → entra na seção 2 → adquire investida → supera o bloqueio da seção 3.

**Pronto quando:** cada requisito tem uma forma de verificação e o grupo consegue explicar o percurso completo antes de programá-lo.

**A03 — Preparar avaliação técnica e diário — 16–20/10**

Base mantida: revisão humana, RNF01 e RNF04 nas páginas 2 e 4. A comparação com código manual da página 6 foi retirada por decisão do grupo. Caio e Lucas definem o método. Estimativa: 1 h de Caio, 1 h de Lucas e 2 h de Victor.

1. Definir critérios verificáveis para cada requisito: ações, estados, persistência, transparência e pacote desktop.
2. Definir quais evidências registrar em cada script assistido: prompt, ferramenta/modelo, saída original, problemas, revisão, correções e versão integrada. Não criar uma solução manual independente.
3. Definir o percurso e as condições de medição de FPS/tempo de quadro e memória, no mesmo equipamento e configurações para as repetições. Registrar tempo gasto com aprendizagem do Godot separadamente do retrabalho quando possível.
4. Preparar diário e registro de testes antes de executar. Três repetições por cenário são uma sugestão praticável; não constituem prova estatística ampla.

**Documentação:** metodologia atualizada, incluindo a retirada do comparativo manual, justificativa, ferramenta/modelo, ambiente, cenários e limites. Diário distingue saída original, versão revisada e versão integrada. Contabilizar geração, revisão, correção e integração, sem usar esse total para afirmar economia frente a uma implementação inexistente.

**Fluxo de exemplo:** definir bloqueio por habilidade → IA gera script → equipe identifica erro de estado → corrige e registra a intervenção → executa testes com habilidade ausente, errada e correta → registra os resultados.

**Pronto quando:** o método permite repetir os testes e entender a contribuição humana sem depender de uma versão manual independente.

**A04 — Produzir recursos humanos mínimos — 19/10–01/11**

Base: transição visual manual e proibição de geração de assets por IA nas páginas 2 e 4; fluxo de pixel art humana citado na página 7. Victor lidera. Estimativa: 22 h de Victor e 4 h de apoio de Caio em recursos humanos simples, como som/interface e organização das fontes. Entregar gradualmente; priorizar forma base e inimigo até 23/10. Não ampliar o conjunto artístico.

1. Fazer uma lista curta: Cyra base, duas formas copiadas, dois inimigos, um conjunto de pisos, dois obstáculos, indicação de vida e poucos sons de ação.
2. Produzir primeiro os sprites necessários à movimentação e ao combate. Até 23/10, entregar recursos mínimos que permitam visualizar personagem, inimigo e dano.
3. Completar as transformações e animações simples; manter tamanho, ponto de origem e nomes de arquivos consistentes. Reaproveitar poses e o conjunto de cenário entre as áreas.
4. Produzir sons humanos simples, ajustar volume e exportar em formatos que o projeto consiga usar. Manter uma versão editável dos recursos. Narrativa e textos do jogo também permanecem sob autoria humana neste recorte.

**Documentação:** inventário com nome do arquivo, autor, ferramenta, data e uso. Guardar fontes editáveis e um exemplo do processo manual. No texto, explicar como a diretriz de autoria humana foi aplicada. A origem documentada é mais útil que um aviso genérico de que “a arte é humana”.

**Fluxo de exemplo:** Victor desenha a forma base e a forma de investida → exporta ambas com o mesmo tamanho → Caio integra → Lucas testa a mudança de estado → o inventário liga os arquivos ao autor.

**Pronto quando:** todos os recursos indispensáveis estão disponíveis, têm autoria identificada e permitem distinguir as transformações. Trilha longa, ilustrações adicionais e muitas animações não entram na meta.

**A05 — Movimento, combate e vida — 19–25/10**

Base: RF01 e RF02, página 3; código híbrido e curadoria, páginas 2 e 4. Caio lidera. Estimativa: 10 h de Caio, 2 h de Lucas e 1 h de Victor. Conferir movimento em 23/10 e fechar combate/vida no bloco de fim de semana até 25/10.

1. Implementar andar, pular e cair usando os recursos de física e colisão da engine. Trabalhar em uma sala de teste pequena, sem construir o mapa inteiro.
2. Criar ataque, vida e dano. Separar o estado de vida da indicação visual para que a barra acompanhe o valor real.
3. Implementar um inimigo com comportamento simples e derrota identificável. Definir um reinício básico para permitir repetir a partida após perder toda a vida.
4. Testar colisão em piso e parede, ataque, dano recebido, inimigo derrotado e vida do jogador. Revisar cada trecho assistido antes de integrar.

**Documentação:** diário com os prompts e correções; texto principal com a estrutura dos componentes e o funcionamento de RF01/RF02; registro de testes com resultado esperado e observado. Guardar uma captura da vida antes/depois e a versão de código correspondente. Registrar o reinício como apoio proposto à execução da demo, sem apresentá-lo como RF adicional do PDF.

**Fluxo de exemplo:** jogador anda até o inimigo → recebe dano e vê a vida diminuir → ataca → o inimigo chega a zero de vida → permanece identificável para a absorção implementada na A06.

**Pronto quando:** é possível completar e repetir esse ciclo sem atravessar o chão, perder o controle ou causar dano incoerente.

**A06 — Mimetismo, habilidades e aparência — 26–28/10**

Base: regras de mimetismo/transição visual da página 2 e RF03/RF04 da página 3. Lucas lidera; Caio revisa integração. Estimativa: 5 h de Caio, 6 h de Lucas e 2 h de Victor. Lucas usa segunda e terça para partes delimitadas e quarta para consolidar; Caio participa da implementação e revisão.

1. Definir um comando simples de absorção após derrotar o inimigo, evitando uma animação longa de finalização.
2. Associar cada tipo de inimigo à habilidade correspondente e registrar a aquisição no estado do jogador.
3. Implementar as duas ações escolhidas. Trocar sprites/animações humanos quando a habilidade ativa mudar; usar uma indicação simples de qual forma está ativa.
4. Testar absorção antes/depois da derrota, repetição de absorção, troca de habilidade e retorno ao jogo após dano/reinício. Resolver estados que deixem a transformação visual diferente da habilidade ativa.

**Documentação:** regra de aquisição e de troca no texto principal, diagrama simples de estados se ajudar, testes de RF03/RF04, prompts/revisões no diário e referências aos assets humanos. Explicar a decisão sobre conservar habilidades adquiridas e o que significa estar com uma habilidade equipada.

**Fluxo de exemplo:** inimigo B derrotado → jogador pressiona absorver → investida é desbloqueada → Cyra assume a aparência correspondente → o comando de ação executa a investida.

**Pronto quando:** as duas cópias modificam comportamento e aparência, e o estado é compreensível pelo jogador.

**A07 — Obstáculos, três seções e save local — 29/10–03/11**

Base: regra de fechadura/chave e limite geográfico da página 2, RF05/RF06 das páginas 3–4 e persistência nas páginas 5–6. Lucas lidera save; Caio monta o percurso e integra. Estimativa: 10 h de Caio, 5 h de Lucas e 3 h de Victor. Lucas concentra o save em quinta/sexta; Caio integra mapa e transições no fim de semana, sem depender de Lucas nesses dias.

1. Construir as três áreas a partir de uma estrutura de cena reaproveitada. Distribuir entrada, inimigo/desafio e saída sem aumentar o mapa além do necessário.
2. Integrar os bloqueios: habilidade ausente ou errada mantém a passagem fechada; habilidade correta permite transpor/destruir o obstáculo conforme a regra escolhida.
3. Implementar um save local único com o progresso definido na A02. Manter identificadores estáveis para seção, inimigos relevantes, obstáculos e habilidades.
4. Testar transição entre as três áreas, retorno a uma área anterior e fechar/reabrir a demo. Quando não houver save, iniciar uma partida nova; definir tratamento simples para arquivo inválido, documentando a decisão.

**Documentação:** modelo de dados atualizado, lista do que é salvo e quando, exemplo de estrutura do save, testes de RF05/RF06 e persistência, além do diário. O diagrama existente no PDF não explicita todos os estados citados no próprio texto: conferir posição e inimigos derrotados na solução final. O save pode ser um arquivo local estruturado; não é necessário montar servidor ou banco remoto.

**Fluxo de exemplo:** adquirir A na seção 1 → abrir passagem → entrar na seção 2 → salvar → fechar o jogo → reabrir na seção/ponto seguro definido, com A e o estado do obstáculo preservados.

**Pronto quando:** o jogador conclui as três áreas sem perder progresso indevidamente e o save corresponde ao modelo documentado.

**A08 — Revisão cruzada e rastreabilidade — 20/10–08/11**

Esta atividade substitui a antiga construção de implementações manuais. Base: revisão obrigatória da página 2, geração híbrida da página 4 e modelagem/persistência das páginas 5–6. Caio e Lucas revisam o trabalho um do outro, sem duplicar a revisão local já incluída na implementação. Estimativa: 3 h de Caio, 2 h de Lucas e 1 h de Victor.

1. Selecionar uma versão de cada módulo relevante após sua implementação. Revisar gradualmente movimento/combate, mimetismo, transições e save.
2. Conferir responsabilidades, entradas/saídas, estados, sinais, referências entre cenas e compatibilidade com os modelos documentados. A experiência de Caio com C# apoia essa leitura; validar as particularidades do Godot com execução.
3. Relacionar script e versão aos requisitos, prompts, correções e testes. Registrar incoerências ou duplicações e encaminhá-las à tarefa de implementação correspondente.
4. Confirmar as correções nos testes, sem reimplementar um módulo apenas para compará-lo com a IA. Encerrar a conferência de rastreabilidade em 08/11.

**Documentação:** matriz requisito → módulo/versão → prompt → intervenção → teste; notas breves da revisão cruzada com autor, achado, decisão e resultado. Alterar o diagrama apenas quando a arquitetura implementada mudar. Isso demonstra curadoria e manutenção, não uma comparação de autoria independente.

**Fluxo de exemplo:** Caio revisa o save integrado por Lucas → percebe que a habilidade ativa não é restaurada → registra o achado → a correção entra no mesmo projeto → o teste de reabertura confirma o resultado → diário e modelo são atualizados.

**Pronto quando:** os módulos principais têm revisão de outro integrante e ligação verificável com requisitos, testes e intervenções humanas.

**A09 — Executável completo e transparência — 03–04/11**

Base: RNF03, RNF05 e RNF06 da página 4 e diretrizes da página 2. Caio lidera. Estimativa: 4 h de Caio, 1 h de Lucas e 3 h de Victor. O bloco de Caio ocupa 1 h de terça e 3 h de quarta; concluir sua integração da A07 preferencialmente em 01/11 e deixar 03/11 para a A09.

1. Integrar o conjunto final de recursos humanos e conferir a legibilidade da vida, da habilidade ativa e dos controles.
2. Incluir um aviso específico dos módulos assistidos por IA e da curadoria humana, em interface/menu ou créditos, conforme o PDF. Identificar a autoria dos recursos artísticos.
3. Exportar e testar o jogo fora do editor no computador de demonstração ou em ambiente equivalente. Conferir save, recursos e dependências do pacote.
4. Identificar a versão candidata e congelar novas funcionalidades em 04/11. Abrir pendências apenas para falhas e ajustes necessários.

**Documentação:** README de execução e controles, inventário final de recursos, texto do aviso de IA e identificação da build/código. No texto principal, explicar o atendimento aos RNF03/05/06. Registrar limitações conhecidas, em vez de depender de instruções verbais no dia da banca.

**Fluxo de exemplo:** abrir o executável → consultar controles e aviso → iniciar → percorrer as áreas → salvar/reabrir → consultar créditos.

**Pronto quando:** a demo completa abre fora do editor e as informações ao jogador descrevem o uso real de IA.

**A10 — Testes, estabilidade e desempenho — 05–10/11**

Base: RF/RNF, especialmente RNF04 da página 4, e validação da página 6, com a mudança metodológica informada pelo grupo. Lucas coordena; todos participam. Estimativa: 8 h de Caio, 6 h de Lucas e 3 h de Victor.

1. Executar a matriz: movimento, dano, derrota, absorção, aparência, habilidade, bloqueio, três seções, save, transparência e pacote desktop.
2. Registrar falhas e revisões humanas da saída de IA até a versão integrada. Quando uma versão original não executar, registrar a falha; não inventar uma medição anterior.
3. Repetir o percurso definido e medir FPS/tempo de quadro, memória, travamentos e perda de estado. Observar ciclos de transição após aquecimento; um aumento isolado de memória não comprova vazamento.
4. Corrigir falhas que impedem iniciar, concluir, salvar ou demonstrar o mimetismo; repetir os cenários afetados. Encerrar medições até 10/11. Aplicar o resultado da revisão A08 aos módulos já disponíveis, sem esperar seu encerramento para iniciar todos os testes.

**Documentação:** cenário, equipamento/configurações, versão, repetição, resultado esperado/observado, valores reais e evidência. Consolidar requisitos atendidos, defeitos por tipo, correções e tempo de retrabalho. O PDF não fixa 60 FPS ou percentual de melhoria. Apresentar os limites de observação e não comparar os resultados com código manual inexistente.

**Fluxo de exemplo:** versão gerada perde a habilidade ao trocar de seção → equipe registra e corrige a persistência → teste repetido conserva a habilidade → medir o percurso na build integrada → relatar falha, intervenção e resultado.

**Pronto quando:** cada requisito tem resultado identificado, as medições são reproduzíveis e falhas críticas foram tratadas ou explicitamente descritas como pendência.

**A11 — Escrever o documento e analisar resultados — 19/10–11/11**

Base: objetivos, pesquisa já realizada e validação descritos nas páginas 1, 6–9. Victor consolida; os devs fornecem conteúdo técnico. Estimativa total distribuída: 8 h de Caio, 5 h de Lucas e 14 h de Victor. Cada desenvolvedor entrega a redação técnica de suas tarefas e seus resultados; Victor consolida o texto.

1. Desde 19/10, escrever contexto, objetivo, requisitos, método e ambiente a partir do PDF e das decisões registradas. Atualizar a implementação ao fechar cada atividade, em vez de esperar o jogo terminar.
2. Apresentar os resultados da pesquisa de campo como já relatados no PDF, com 43 participantes e suas limitações. Não programar nova coleta. Se os dados primários estiverem disponíveis à equipe, conferir cálculos; caso contrário, declarar o uso dos resultados agregados reportados, sem inventar respostas individuais.
3. Até 06/11, reunir uma versão parcial do texto. Depois da A10, inserir números, falhas, correções, esforço de revisão e resultados do estudo de caso. Registrar a mudança metodológica e não afirmar superioridade em relação à programação manual. Separar percepção do público de evidência técnica: uma não comprova a outra.
4. Concluir a discussão até 11/11: o que funcionou, o que exigiu intervenção, onde houve retrabalho e que conclusões os dados permitem. Descrever a contribuição dos integrantes e as limitações do recorte.

**Documentação:** este é o texto principal do projeto. Organização sugerida: introdução/objetivos; requisitos e modelos; método; desenvolvimento; resultados da pesquisa já relatada; resultados técnicos; discussão/limitações; conclusão; referências efetivamente usadas; apêndices com registros relevantes. A estrutura é proposta de organização, não norma institucional extraída do PDF. Citar a fonte real de cada afirmação externa que venha a ser incorporada; não importar referências ou obrigações dos anexos anteriores.

**Fluxo de exemplo:** teste encontra perda de habilidade ao trocar de seção → equipe corrige o estado compartilhado → diário registra intervenção e tempo → tabela mostra o defeito → discussão explica por que a curadoria humana foi necessária.

**Pronto quando:** em 11/11 há uma versão completa com resultados reais e conclusão limitada ao experimento, pronta para revisão.

**A12 — Revisão final e fechamento — 12–13/11**

Base: demonstrar e documentar os objetivos do PDF; data de entrega informada pelo usuário. Todos participam. Estimativa: 4 h de Caio, 3 h de Lucas e 5 h de Victor.

1. Conferir cada requisito contra o jogo, o teste e o texto. Ajustar descrições e diagramas para refletirem o que realmente existe.
2. Revisar método, cálculos, identificação das versões e atribuição de recursos. Tratar como limitação qualquer resultado não medido, inclusive ausência de evidência para afirmar inexistência absoluta de vazamentos.
3. Revisar redação, figuras, tabelas, referências e apresentação visual. Aplicar o modelo/formato vigente comunicado pela instituição, sem presumir que o PDF de base o define.
4. Fechar documento, build, código e evidências com identificação correspondente. Guardar cópia em outro local disponível ao grupo e conferir a abertura dos arquivos.

**Documentação:** documento revisado, matriz final de requisitos, pacote de evidências e lista curta de limitações. Usar uma conferência de entrega com arquivo, versão, responsável e destino; não criar um relatório burocrático extenso.

**Fluxo de exemplo:** requisito de persistência → trecho no documento → caso de teste aprovado → exemplo do save → build usada no teste. Se algum elo faltar, corrigir a lacuna ou declarar a pendência.

**Pronto quando:** documento e versão demonstrável estão fechados até 13/11; 16/11 não depende de terminar uma funcionalidade.

**A13 — Entregar o documento — 16/11**

Base da data: instrução do usuário. O PDF não define canal, horário ou formato institucional do envio. Designar previamente quem efetivamente submete. Estimativa: 1 h de Caio, 1 h de Lucas e 2 h de Victor.

1. Confirmar o canal, horário limite, responsável pelo envio e arquivos exigidos na comunicação oficial que o grupo recebeu.
2. Abrir o arquivo final, verificar nomes dos integrantes, versão e integridade; conferir se o pacote corresponde à revisão encerrada.
3. Efetuar a entrega pelo procedimento confirmado e guardar confirmação/comprovante. O cronograma não autoriza envio automático a terceiros.
4. Preservar a versão entregue como referência imutável para preparar a banca.

**Documentação:** cópia do documento entregue, identificação da versão e comprovante de submissão. Esse registro comprova qual conteúdo foi entregue e evita confusão com rascunhos.

**Fluxo de exemplo:** conferir arquivo → integrante designado submete no canal oficial → guardar confirmação → os três confirmam que aquela é a versão usada na defesa.

**Pronto quando:** o documento foi recebido pelo canal correto e o grupo preservou a confirmação disponível.

**A14 — Preparar apresentação e demonstração — 17–18/11**

Base: data de banca informada e conteúdo técnico efetivamente produzido sob o PDF. Victor lidera. Estimativa: 3 h de Caio, 2 h de Lucas e 5 h de Victor.

1. Confirmar duração e condições da apresentação. Distribuir a fala conforme as contribuições reais.
2. Montar uma sequência curta: problema/objetivo, recorte, método atualizado, demo, intervenção humana, resultados e limitações.
3. Escolher um percurso que demonstre combate, absorção, mudança visual, bloqueio, transição e persistência sem depender de habilidade alta do jogador.
4. Preparar capturas ou um vídeo curto da build identificada como apoio caso a demonstração ao vivo falhe. Esse material é uma sugestão de contingência, não substitui a existência da demo.

**Documentação:** apresentação, roteiro de fala por integrante, roteiro da demo e identificação da versão mostrada. Usar os mesmos números do documento entregue; qualquer correção posterior precisa ser explicada.

**Fluxo de exemplo:** explicar o mimetismo → derrotar um inimigo → copiar sua forma → superar o obstáculo → mostrar a evidência de que esse módulo exigiu revisão humana.

**Pronto quando:** cada integrante sabe sua participação e o percurso cobre os resultados importantes dentro do tempo disponível.

**A15 — Ensaiar e conferir a execução — 19–20/11**

Base: preparação para a banca de 23/11. Todos participam. Estimativa: 2 h de cada desenvolvedor e 4 h de Victor.

1. Realizar um ensaio com cronômetro, apresentação, transições de fala e demonstração.
2. Fazer perguntas entre os integrantes: onde a IA ajudou, o que foi corrigido, por que não há referência manual independente e quais conclusões deixam de ser possíveis, por que os testes são limitados e como a autoria humana foi preservada.
3. Testar o pacote fora do editor, os arquivos da apresentação e o save inicial usado no percurso. Separar o save de demonstração dos registros de teste.
4. Corrigir problemas de apresentação e execução; evitar novidades no código. Havendo correção técnica indispensável, identificar a nova build, retestar o que mudou e manter o registro da versão entregue.

**Documentação:** roteiro ajustado, perguntas/respostas resumidas, resultado do ensaio e lista dos arquivos que serão levados. Registrar divergência entre versões se houver, sem trocar silenciosamente os resultados da pesquisa.

**Fluxo de exemplo:** ensaio passa do tempo → reduzir explicação repetida → manter método e resultados → repetir a passagem de fala e a demo até caber no limite.

**Pronto quando:** apresentação e execução estão verificadas até 20/11, com cópias acessíveis e sem depender de trabalho no fim de semana.

**A16 — Apresentar a banca — 23/11**

Base da data: instrução do usuário. Todos participam no horário oficial.

1. Conferir arquivos e ambiente antes do horário de apresentação.
2. Apresentar o estudo e demonstrar a demo, explicitando a contribuição humana e os limites do experimento.
3. Responder com base nos resultados registrados. Diferenciar o que foi medido, o que foi observado e o que permanece hipótese.
4. Anotar perguntas e alterações solicitadas pela banca; combinar responsáveis e prazo conforme a orientação efetivamente recebida.

**Documentação:** lista das solicitações da banca, responsáveis e encaminhamentos. Nenhuma data de correção posterior foi presumida neste plano, pois não foi informada.

**Fluxo de exemplo:** banca questiona uma falha → grupo mostra teste/correção → reconhece o limite restante → registra a alteração solicitada para a versão posterior, se houver.

**Pronto quando:** defesa realizada e solicitações recebidas estão registradas com clareza.

**Modelos mínimos de registro**

Os exemplos abaixo são fictícios e ilustram preenchimento; não são resultados do projeto. Podem ser tabelas no próprio documento ou arquivos simples. Não é necessário criar um documento distinto para cada RF.

| Registro | Campos essenciais | Exemplo de preenchimento |
|---|---|---|
| Diário do experimento | Data, requisito, módulo, ferramenta/modelo, prompt/arquivo, saída original, intervenção humana, responsável, tempo e versão | RF03; absorção; modelo/versão utilizados; saída preservada; corrigida referência de estado; responsável identificado; tempo real; commit correspondente |
| Teste funcional | ID, requisito, versão, condição inicial, passos, esperado, observado, situação e evidência | T05; RF05; sem habilidade A; tentar atravessar; esperado bloqueio; observado preenchido após execução; captura correspondente |
| Medição | Cenário, máquina/configuração, versão da demo, repetição, duração, FPS/tempo de quadro, memória e falhas | Build assistida integrada; percurso definido; configuração registrada; rodada 1; valores reais preenchidos depois |
| Inventário de recursos | Arquivo, autor humano, ferramenta, origem/editável, uso e data | cyra_investida.png; autor identificado; ferramenta de desenho; fonte editável; forma de investida; data real |
| Rastreabilidade | Requisito, implementação, teste, resultado e trecho do texto | RF06; transição; T06; resultado real; seção de desenvolvimento correspondente |

Para tempo, separar preparação/aprendizagem do Godot, geração, revisão, correção e integração. Não usar a duração da resposta da IA como medida do tempo total de desenvolvimento. Sem implementação manual independente, não calcular economia frente a esse método. Quando não houver medição confiável, registrar ausência, sem reconstruir números como se tivessem sido cronometrados.

**Simplificações recomendadas para caber nas horas**

- Uma cena de base reaproveitada nas três áreas, um conjunto de cenário e poucos inimigos. A diferença entre seções pode vir de obstáculos e disposição, sem três biomas novos.
- Um sistema de habilidades por estado, sem árvore de talentos, equipamentos ou combos. A cópia precisa continuar perceptível e necessária à progressão.
- Um save local e um ponto seguro por seção. Sem slots múltiplos, conta de usuário, servidor ou sincronização.
- Física e colisão da engine, com scripts próprios restritos ao necessário. O uso de IA na programação não exige recriar recursos que o Godot já oferece.
- Prompts pequenos, vinculados a um requisito e com contexto de versão e contrato. Gerar um sistema inteiro de uma vez dificulta a revisão e a identificação das causas de erro.
- Arte e som humanos simples. Limitar quantidade e duração dos recursos antes de comprometer o calendário; não usar geração de imagens ou áudio por IA para compensar atraso.
- Estudo de caso com registros do código assistido e das revisões humanas. Não desenvolver módulos manuais independentes. Limitar conclusões ao atendimento aos requisitos, qualidade observada e esforço registrado.
- Uma documentação consolidada, escrita a cada atividade. Usar resultados e capturas já produzidos nos testes, sem criar uma nova coleta de opinião do público.
- Build completa em 04/11; documento completo em 11/11 e revisado em 13/11. As reservas atendem falhas e revisão, não ampliação do conteúdo.

**Ações imediatas em 15/10:** começar A01, escolher o percurso e responsáveis da A02, criar o texto principal e a lista comum de pendências. No fim do primeiro bloco, o grupo deve ter uma próxima tarefa concreta para cada integrante e uma decisão de escopo registrada.
