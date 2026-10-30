# A03 — Protocolo de avaliação técnica e curadoria humana

**Data real da preparação:** 22/10/2026, America/Sao_Paulo. **Versão documental:** A03-v2, D03/P04/P06. **Revisão:** T02, Caio/Lucas/Victor, 27/10/2026, 13:16–13:57 (41 min conjuntos). **Estado:** revisão humana concluída com ajustes de simplificação e coleta automática. O suporte de coleta D04/D05 foi validado por Caio em P08/T04 e executado em Lucas em 30/10/P09, com coleta íntegra e evidência funcional incompleta aceita por Caio com ressalvas. A03 integrada em `e0aaeed`; medições da demo final não foram executadas. A janela planejada de 16–20/10 não foi usada como data de execução nem alterada.

## 1. Base, decisões vigentes e identificação

Foram consultados [AGENTS](../AGENTS.md), [cronograma](Cronograma_Cyra_15-10_a_23-11-2026.md), [guia](Guia_atividades_Cyra_2026.md), [A02 aprovada](A02_Escopo_Requisitos_Modelos.md), [T01](evidencias/T01_A02_revisao.md), [diário principal](Diario_Experimento_Cyra.md), [template metodológico inicial](Diario_Experimento_IA.md), [prompts](Prompts_Utilizados.md), [README](../README.md) e Git local. A02 integrada em **`f1453934c0be612ae8f5c70515820624d15478bd`**, conferida no histórico; esse commit contém a revisão e a aprovação documental T01. As atualizações de hash nesta entrega se limitam aos campos de versão de trabalho ainda pendentes da A02.

A matriz dos 12 RF/RNF, redações originais e páginas da fonte ficam na **seção 2 da A02**; aqui não são duplicadas. A fonte primária continua sendo o PDF assinado indicado na seção 1 da A02, sem substituição por relatório homônimo. Não foi necessária nova interpretação de suas exigências nesta tarefa. As referências técnicas externas sustentam apenas a coleta, sem criar requisitos do jogo. A revisão de 27/10 está em P06/T02 e altera a proposta detalhada original preservada em D03.

### 1.1 Decisões já registradas — não reabertas

- Estudo de caso do processo assistido, com atendimento aos requisitos, defeitos, intervenções humanas, retrabalho, arquitetura, estabilidade e desempenho. Sem versão manual independente ou comparação de produtividade com desenvolvimento manual; sem superioridade da IA presumida.
- A01/T00 aprovadas por Caio/Lucas; A02/T01 aprovadas documentalmente com ajustes. Isso não comprova atendimento dos requisitos da **demo final** nem desempenho de uma demo ainda não implementada.
- Pulo duplo e investida, aquisições permanentes, uma habilidade ativa; zero de vida do inimigo produz atordoamento sem prazo até comando de absorção ou reinício.
- Transições mantêm inimigos/obstáculos em memória. Morte e reabertura reiniciam o mundo inteiro. Morte mantém habilidades/forma ativa e retorna ao ponto seguro da seção atual com vida máxima.
- Save único contém versão do formato, seção, ponto seguro, vida atual, habilidades adquiridas e ativa. **Não contém inimigos nem obstáculos.** Carga válida restaura a vida salva, sem curar pelo simples carregamento.
- A exclusão dos estados do mundo altera a persistência descrita na fonte primária, p. 5–6. A equipe reconheceu a mudança em T01; a análise final deve explicitá-la. Não renomear isso como atendimento integral à persistência original ou criar RF07 para esconder a divergência.
- Assets e narrativa finais são humanos; vida lógica é separada da UI e habilidade lógica é separada do sprite. Escopo e física nativa permanecem conforme AGENTS.

### 1.2 IDs e preservação

O índice já contém P01, P02 e **P03, dedicado às decisões humanas da A02**. A solicitação atual pede o próximo ID e também menciona P03 no encerramento. Para cumprir a preservação sem colisão, o prompt atual é registrado integralmente como **P04**, ligado a D03/A03. P03 permanece intocado.

Na preparação de 22/10/2026, a última instrução do prompt P04 pediu T03 e esse ID foi usado, deixando T02 livre. Em 27/10/2026, o usuário solicitou a revisão como **T02**; a versão de trabalho adota T02, exclusivamente para a revisão documental da A03. T03 é somente a referência histórica dessa mesma ficha na saída original D03, não uma execução adicional. O prompt e o ZIP originais são preservados. Futuros testes exigem conferência dos IDs livres; cenários C-RFxx/C-RNFxx/C-SAVE não são resultados globais.

## 2. Ciclo e tipos de evidência

**Requisito → prompt integral → saída original preservada → revisão humana → correção quando necessária → teste → integração → análise.** A volta a etapas anteriores deve manter os vínculos, sem apagar a primeira saída ou o resultado desfavorável.

| Etapa | O que permite concluir | Evidência mínima e limite |
|---|---|---|
| Compilação | A solução daquela versão compilou nas condições registradas. | Comando/configuração, versões, saída e responsável. Não prova jogabilidade, ausência de defeitos ou FPS estável. |
| Validação funcional | O cenário executado produziu ou não o comportamento esperado. | Condição inicial, passos, esperado/observado e evidência. Não generalizar um caso positivo para condições negativas não executadas. |
| Revisão arquitetural | Um revisor analisou responsabilidades, estado, referências, sinais, acoplamento e uso da engine. | Achados/decisão reais na matriz A08/ficha; nome, versão e escopo. Pode terminar sem correção; não prova desempenho por inspeção. |
| Medição de estabilidade/desempenho | Houve observação limitada, com métrica e contexto definidos. | Série bruta, configuração, versão, duração e repetições. Sem inferência para máquinas/modos não testados ou prova absoluta de ausência de vazamentos. |
| Aprovação documental | Pessoas revisaram e aceitaram regras/protocolo/modelos daquela versão. | T01 ou T02 com participantes e decisões. Não é execução das mecânicas ou medição da demo. |

### 2.1 Vínculo com os requisitos, sem repetir a matriz

- **RF01/RF02:** C-RF01/C-RF02, A02 §2.2 e regras §4; futuras A05/A10. Relacionar movimento/colisão e vida/dano/reinício à versão testada.
- **RF03/RF04:** C-RF03/C-RF04, A02 §2.2/4; futuras A06/A10. Incluir vivo/atordoado, comando, duplicação, ativa/representação e uso após troca/morte/carga.
- **RF05/RF06:** C-RF05/C-RF06 e C-SAVE, A02 §2.2/3/6; futuras A07/A10. Cobrir chave ausente, errada/inativa e correta; retorno, manutenção na sessão e reinício do mundo na morte/carga.
- **RNF01:** C-RNF01, rastreabilidade deste protocolo e revisão A08; **RNF02:** C-RNF02 e inventário/fontes humanas A04; **RNF03:** C-RNF03, aviso no pacote A09/A10.
- **RNF04:** C-RNF04/DEC10, protocolo das seções 4–6, execução principalmente A10. **RNF05/RNF06:** C-RNF05/C-RNF06 e reprodução do projeto/pacote final A09/A10. A01 fornece precedente de ambiente/exportação, não aprovação antecipada da demo.

Em cada conclusão, distinguir **redação original**, **critério de execução da A02** e **alteração humana reconhecida**. Para C-SAVE, o esperado é o contrato revisado; o resultado deve dizer “conforme o recorte aprovado, com divergência de persistência da fonte”, quando aplicável. Mudança legítima de regra não deve ser registrada automaticamente como defeito do código anterior.

### 2.2 Situação do teste e situação do requisito

| Situação da execução de teste | Regra de registro |
|---|---|
| Não executado | Há roteiro, mas a execução ainda não ocorreu. Observado fica sem preenchimento; registrar versão prevista ou “a definir”. |
| Bloqueado | A execução foi impedida por dependência identificada: funcionalidade, build, acesso, ferramenta ou dado ausente. Registrar dependência; não inventar comportamento observado. |
| Aprovado | Execução válida cumpriu todos os resultados esperados do cenário, com evidência suficiente. |
| Reprovado | Execução válida observou divergência reproduzível ou suficientemente documentada em relação ao esperado. Vincular achado, sem presumir causa/autoria. |
| Inconclusivo / inválido | Dados insuficientes ou condições quebradas: PID errado, foco perdido, desvio de percurso, coleta ausente. Manter registro e motivo; repetir quando possível, sem tratar como aprovação ou falha funcional comprovada. |

“Executado” é uma informação de ocorrência, não sinônimo de aprovado. Manter a data e a tentativa de cada execução; reteste não substitui a tentativa anterior. Na Tabela 3, usar a situação específica e a ficha para detalhar a tentativa.

| Situação do requisito naquela versão | Regra de consolidação |
|---|---|
| Atendido | Todos os critérios aplicáveis definidos para a versão e recorte foram cobertos por evidência válida, incluindo os casos negativos necessários. Informar limites/diferenças da fonte. |
| Atendimento parcial | Parte dos critérios está comprovada e outra parte tem falha, pendência ou cobertura ausente; listar exatamente ambas. |
| Falha | Uma condição essencial foi validamente observada em desacordo com o esperado, impedindo o atendimento. Listar critérios não testados separadamente. |
| Bloqueado | Ainda não há evidência suficiente porque uma dependência impede as verificações necessárias; identificar qual. |
| Sem execução / sem evidência | Nenhuma execução/auditoria aplicável foi realizada ou apresentada para essa versão. Ausência de teste não significa código defeituoso. |

Se houver evidência de atendimento e falha, usar atendimento parcial ou falha essencial, conforme o critério afetado, com justificativa; nunca “atendido” só porque algum teste passou. Uma condição não aplicável exige justificativa humana, sem exclusão silenciosa do denominador dos 12 requisitos. Aprovação de documento ou disponibilidade de compilação não altera automaticamente a situação dos RF da demo.

**Obrigatório em qualquer resultado:** ID/cenário/requisito e critério versionado; commit e estado de alterações locais; identificação/hash da build quando houver; executor/revisor efetivo; data; condições iniciais e equipamento; passos; esperado e observado separados; situação; evidência e limitações. Sem isso, a conclusão é inconclusiva ou fica pendente, conforme o que faltar. Dados não medidos são identificados como tais, nunca preenchidos com zero.

## 3. Gerações, curadoria, defeitos e versões

### 3.1 Estrutura existente e registro mínimo

Usar o [diário principal](Diario_Experimento_Cyra.md), o índice [Prompts utilizados](Prompts_Utilizados.md), `docs/prompts/`, `docs/saidas_originais/`, `docs/evidencias/` e os commits. O [Diário_Experimento_IA](Diario_Experimento_IA.md) continua template/referência histórica, não outro diário concorrente; não duplicar ali toda a coleta.

Por geração ou alteração assistida, registrar na ficha D correspondente:

1. Atividade/requisitos/cenários e limites; prompt integral, incluindo esclarecimentos que mudaram o contrato, com próximo ID P livre.
2. Ferramenta, modelo e versão quando conhecidos. Caso contrário, “modelo não aferido”; não reconstruir retrospectivamente.
3. Arquivos afetados e natureza: código, cena, configuração ou **documental**. Uma tarefa documental não é geração de código.
4. Saída original identificável antes de futura edição humana: arquivo/ZIP e manifesto SHA-256, ou commit explícito; indicar o marco preservado e o que ele contém.
5. Revisor humano, data, escopo examinado, critérios e achados reais; pode haver revisão sem correção. Não exigir alteração artificial para demonstrar curadoria.
6. Decisão e intervenção: quem decidiu, quem efetivamente editou, trecho/arquivo ou regra afetada, razão; novo prompt se a correção foi solicitada à IA.
7. Execuções e retestes ligados por ID/tentativa, versões, resultados/evidências; dependências e pendências separadas.
8. Versão revisada/integrada, arquivos/commit, situação e limites, além de esforço real conforme seção 7.

**Ajustes da própria IA** entre tentativas internas, antes de entregar a saída, são geração/correção assistida, não revisão humana. Uma pessoa pode identificar um problema e pedir à IA para editar: registrar a **decisão humana** e a **edição pela IA**, sem declarar que a pessoa escreveu o código. Resultados de verificações automáticas continuam automáticos, mesmo quando iniciados por uma pessoa.

Se o usuário já revisou uma saída, preservar essa sequência. Não regravar prompts, ZIPs ou hashes antigos para fazê-los coincidir com a versão humana. Um hash de fonte consultada identifica aquela versão histórica; não se espera que a fonte de trabalho revisada continue com o mesmo hash do original.

### 3.2 Categorias simples para os achados

| Categoria | Exemplo de classificação, sem alegar ocorrência |
|---|---|
| Compilação | Erro de sintaxe/tipo ou geração de bindings. Distinguir pacote ausente de erro de código. |
| Referência/sinal | Nó inexistente, referência indevida, conexão duplicada ou sinal não recebido. |
| Colisão | Máscara/forma/alinhamento ou transposição física incorreta. |
| Estado | Aquisição/ativa, uso por ciclo, morte, atordoamento ou transição incoerente. |
| Persistência | JSON inválido, campos errados, vida/checkpoint incoerentes ou falha de gravação mal tratada. Não chamar reset do mundo de defeito quando for o esperado aprovado. |
| Interface/representação | Vida/forma exibida divergente do estado, controles/aviso ilegíveis ou incompletos. |
| Ambiente | SDK/templates/pacotes/driver/permissão ou ferramenta de coleta ausente. |

Categoria e causa são campos distintos. Quando a causa não estiver demonstrada, usar “não determinada”. Aprendizagem da engine é esforço; não é por si só defeito. A origem pode ser geração, integração, configuração, regra alterada ou desconhecida; não atribuir automaticamente toda falha à IA. Uma deficiência de arquitetura pode ser anotada como tipo de achado de revisão, ligada à categoria pertinente, sem inventar falha funcional.

### 3.3 Achado, intervenção e reteste

Manter três registros ligados: **defeito/achado identificado** (evidência, gravidade/impacto e versão), **intervenção realizada** (autor real, ação/decisão e nova versão) e **resultado do reteste** (cenário/tentativa, esperado/observado e evidência). Corrigir não comprova que o problema foi resolvido. “Não exige correção, comportamento conforme regra” é decisão válida fundamentada; não contar mudança de escopo como defeito corrigido.

Para o texto acadêmico, relacionar requisito → P → D/arquivo original/hash → achado/decisão → diff ou descrição precisa da intervenção → teste/reteste → commit integrado. Citar trechos representativos e caminhos/versões; não reproduzir todo o código. Se a primeira saída não executar, registrar a falha e os limites observáveis; não inventar FPS dessa saída.

## 4. Equipamentos e responsabilidades — decisão humana de 27/10/2026

| ID | Uso | Configuração informada pela equipe |
|---|---|---|
| MR02 — Lucas | Máquina principal de testes; Lucas executa os percursos e relata ocorrências. | Ryzen 7 8700G; Radeon 780M; 32 GB, 5600 MHz; Windows 11. |
| MR01 — Caio | Complementar, se utilizada; não foi execução confirmada em Lucas. | Intel Core i5-12400F; GeForce GTX 750; 16 GB; Windows 11. |
| MR03 — Victor | Complementar, se utilizada. | Ryzen 5 3500X; Radeon RX 7600; 16 GB, 2400 MHz; Windows 11. |

As configurações acima são **informadas por humanos**, não medições feitas pelo jogo. A observação local da preparação original D03, em 22/10, era da máquina de Caio; isso não identifica o hardware de Lucas. Dados reais de CPU, GPU disponível, memória física utilizável, SO, runtime, janela e renderizador são registrados pelo coletor na execução. Driver/build do SO não informados não são inventados. Resultados de computadores diferentes permanecem separados.

A IA auxilia preparação/configuração, coleta, organização e análise. Lucas joga, observa e preenche relato curto de exceções. A equipe conserva curadoria das conclusões; ausência de eventos de erro não equivale a aprovação automática. O log do jogo mede duração da sessão, não tempo de trabalho fora dela ou de revisão de código.

## 5. Plano simplificado e adaptável — A03-v2

A equipe aceitou os pontos 2–8 como base inicial, solicitando reduzir rigidez/carga de medição, priorizar o estudo do desenvolvimento assistido e automatizar os registros. O protocolo anterior (PROG/CONT com 54 min, quotas e limites numéricos) está em D03 original; **não é uma obrigação fixa da versão v2**.

### 5.1 Condições iniciais

Preferir pacote release Windows, fora do editor, janela 960 × 540, Compatibility, limite operacional de 60 FPS/VSync quando presentes no pacote. Não alterar a configuração do jogo apenas para cumprir o roteiro documental. Registrar condições efetivas, versão e máquina; mudanças são aceitáveis quando identificadas.

O iniciador identifica os arquivos executáveis/dados do pacote por hash e cada sessão recebe pasta exclusiva. Não presumir commit de um pacote recebido sem essa informação. Editor, pacote release e execução headless devem ser identificados; uma verificação headless do coletor não mede desempenho gráfico.

### 5.2 Roteiro e repetições

O roteiro do executor está em [Guia_Lucas_Testes.md](Guia_Lucas_Testes.md). Na entrega original A03 existia somente a cena A01. **Atualização de cobertura em 30/10/2026, D06/A05:** sala própria com movimento/combate/vida e reinício, pendente de curadoria T05; A01 preservada. Habilidades/mapa/save continuam futuros. Isso não amplia retroativamente o que Lucas comprovou em P09.

Quando as mecânicas existirem, realizar inicialmente um percurso das três seções, retorno e uma retomada após morte/reabertura; observar se a demo permite demonstrar os requisitos. Uma sessão curta, por exemplo 3–5 min, é ponto de partida, não prazo obrigatório nem tempo já gasto. Acrescentar uma repetição ou período contínuo somente para confirmar achado, ampliar evidência ou investigar um comportamento. Não exigir três séries longas antes de haver uma dúvida concreta.

Manter comparações na mesma máquina/versão/configuração quando possível. Mudanças de sessão, morte e reabertura precisam ser identificadas porque reiniciam o mundo. Não concatenar processos ou máquinas como se fossem um ensaio contínuo de memória. A IA deve considerar inicialização/aquecimento ao interpretar a série, sem excluir trechos desfavoráveis silenciosamente.

### 5.3 Mudanças de objetivo, roteiro ou condições

O plano pode evoluir com o piloto e a implementação. Registrar revisão do protocolo, data, responsável, motivo e sessões afetadas; preservar a versão e os dados anteriores. Definir a mudança antes da próxima coleta correspondente, sem reclassificar retroativamente um resultado como aprovado apenas por trocar o limite. Se a mudança ocorrer durante uma execução, registrar a ocorrência e separar os trechos ou considerar a comparação inconclusiva.

Alterações na prioridade de desempenho não apagam RNF04: relatar o que foi observado e seus limites. Mudança de requisito/escopo precisa ser explicitada no texto final. Não transformar uma série exploratória curta em evidência de estabilidade universal.

## 6. Coleta automática local — suporte A03/D04

### 6.1 Funcionamento

- `TestRunRecorder`, autoload em `Scripts/Core`, permanece inativo na execução comum. O modo `--cyra-test` habilita os registros; não altera vida, física, habilidades ou save.
- `tools/Testing/Executar_Teste.cmd` inicia o pacote por PowerShell; `Executar_Teste.ps1` prepara pasta exclusiva em `TestResults`, identifica o pacote, inicia o jogo e chama `Analisar_Logs.ps1` ao terminar. O CMD pergunta o computador; execução direta sem perfil fica NaoInformada. Atualização A05/D06: padrão `build/a05-test`; opção A01 usa `build/a03-test`, sem fallback para `build/windows`. Preservadas as proteções D05 de máquina explícita e coleta ausente; descritor A05 confere o cenário do pacote.
- `session.jsonl`: início, relógio monotônico/UTC, configuração, amostras aproximadamente a cada segundo, foco, marcadores F9, mensagens/erros nativos capturados e eventos instrumentados. Não inventar amostras durante pausas.
- Amostras: FPS agregado informado pela engine, Private Bytes e Working Set do processo. Cada contador mantém nome/unidade; memória física disponível não é consumo do jogo, memória do processo não é apenas heap C# nem VRAM.
- `engine.log` é solicitado à engine pelo iniciador, complementando o logger, que só recebe mensagens após sua instalação. Fatalidades antes do início e encerramentos abruptos podem impedir rodapé; não prometer captura integral de qualquer falha.
- A fila é limitada a 512 registros; mensagens nativas têm até 4096 caracteres e perdas de registros são contadas. O limite de 25 MiB por log encerra a coleta com marcador de limitação. Falha de escrita avisa e desativa o coletor sem interromper a partida. Não há envio de dados, serviço remoto ou banco.

### 6.2 Eventos disponíveis e integrações futuras

Continuam disponíveis os eventos A01: pronta, primeira entrada, salto, pouso, botão e gatilho. A05/D06 acrescenta eventos reais de sala pronta, mudança de movimento, salto/pouso, ataque, dano aplicado/recebido, vida anterior/atual, atordoamento, morte, retorno e reinício manual. F9 registra número da etapa do roteiro, não aprovação dessa etapa. Contagens em `summary.json` descrevem somente eventos presentes.

A05 usa `TestRunRecorder.RecordEvent` em seus módulos reais, sem criar outro coletor. A06/A07 integrarão absorção, mudança de habilidade, bloqueios, seções e save/carga/falha quando existirem. A API aceita dados simples na thread principal, com ID técnico/valores; não serializar nós/cenas nem registrar movimento a cada quadro. Os módulos A05 não existiam na entrega original A03; a cobertura nova pertence a D06/T05, sem inventar resultados humanos.

### 6.3 Análise e critérios leves

O iniciador gera `package.json`, `execution.json`, `session.jsonl`, `engine.log` quando disponível, `summary.json` e `relato.txt`. A análise pode ser repetida por `Analisar_Logs.ps1` sem apagar o relato humano. Não preencher observado a partir do resultado esperado.

O resumo calcula amostras/FPS mediano/mínimo agregado, memória inicial/final/máxima, erros/avisos e completude do coletor. **Não atribui veredicto automático ao teste.** Dados brutos e relato são a evidência; números ausentes não viram zero. `session_end` significa saída ordenada da árvore, não sucesso funcional. Falta de rodapé, amostras, eventos ou registros descartados limita a interpretação; não determina sozinha a causa.

Critérios iniciais: verificar se as ações previstas funcionam, se há erro/travamento/perda de estado e se a experiência permite demonstrar o percurso. Descrever FPS e memória; investigar quedas perceptíveis e crescimento persistente em condições comparáveis. Não impor, na v2, as tolerâncias fixas de 55/50 FPS ou 20 MiB/10% da proposta anterior como aprovação obrigatória. Se a equipe adotar limites quantitativos depois, versioná-los antes da coleta correspondente.

FPS por segundo não fornece trace individual de frame nem p95/p99; não usar `1000/FPS` como amostra real de cada quadro. Memória crescente numa sessão curta não comprova vazamento; série estável não comprova ausência absoluta. Para conclusões mais fortes, planejar ensaio dirigido adicional.

### 6.4 Participação mínima de Lucas

Lucas segue o roteiro, usa F9 quando indicado e, após jogar, responde no `relato.txt`: conseguiu concluir? algo visual/de controle diferente? houve interrupção externa? Envia a pasta inteira para a análise assistida. Não transcreve memória/FPS nem preenche grandes tabelas.

Pixels/sprites corretos, legibilidade, sensação de controle, causa de uma falha e intenção do jogador não são comprovados por números/eventos sozinhos. Acrescentar captura curta apenas quando ajudar a demonstrar um achado. A IA resume dados com versão/máquina/limites e propõe entradas no diário; a equipe revisa os resultados antes de integrar.

## 7. Esforço, falhas e resultados — registros mínimos

- Reutilizar D/P/T, arquivos originais, logs e commits. Não criar diário paralelo nem sobrescrever primeira tentativa.
- Separar geração assistida, revisão humana, correção, teste, integração e aprendizagem quando houver medição. Duração do jogo é automática; tempo de pensar, revisar ou editar fora dele depende de informação humana, mesmo breve. Usar “não medido” quando necessário.
- Reunião A03: Caio, Lucas e Victor, 27/10/2026, 13:16–13:57, **41 min conjuntos**. Não somar como 41 min individuais de correção de cada pessoa. A02 mantém seus 33 min originais. Edição posterior pela IA não foi cronometrada como esforço humano.
- A IA prepara registros de achado/intervenção/reteste com fonte e versão. Distinguir decisão humana de edição feita pela IA; uma revisão pode não exigir correção. Não atribuir automaticamente falha de ambiente ao código gerado.
- Usar aprovado, reprovado, bloqueado, não executado ou inconclusivo conforme evidência. Separar requisito de tentativa; reteste não apaga reprovação anterior. Manter os 12 RF/RNF identificados, critérios da A02 e divergência de persistência.
- Caso se calcule taxa: aprovados/(aprovados+reprovados) das tentativas válidas com veredicto; mostrar também inválidas/bloqueadas e cobertura. Priorizar descrição rastreável em vez de percentuais sem denominador. Sem comparação manual independente nem economia de tempo inventada.

Modelo mínimo que a IA poderá preencher a partir dos arquivos:

| Campo | Fonte / preenchimento |
|---|---|
| Cenário, requisito, versão, máquina, horário, duração | Roteiro, package/execution/session e contexto de build. |
| Esperado / observado | A02/roteiro versus eventos/amostras e relato; manter separados. |
| Situação e limitações | Análise assistida, validada por humano; cobertura ausente fica explícita. |
| Achado, intervenção, reteste | Evidência ligada, autor da decisão/edição, nova sessão/versão. |
| Esforço fora do jogo | Relato humano medido, ou “não medido”. |

## 8. Revisão humana T02 e verificação do suporte

A equipe informou revisão em 27/10, 13:16–13:57, 41 min, com os três integrantes. Escolheu Lucas/MR02 como referência, Caio/Victor opcionais, Lucas como executor e análise/coleta majoritariamente assistidas. Aceitou condições anteriores como ponto de partida e solicitou simplificação, flexibilidade rastreável e logs automáticos. Não se atribui execução da antiga simulação de percentuais sem relato.

**T02:** revisão documental concluída com ajustes incorporados ao protocolo v2, conforme P06; não aprova RNF04 ou testes futuros. [Evidência T02](evidencias/T02_A03_revisao.md).

**D04/D05/T04:** suporte de logs solicitado explicitamente nesta revisão e correção posterior do iniciador; testes técnicos automáticos separados da revisão documental. Caio confirmou validação gráfica das seis etapas/F9 e revisão do código sem alterações em P08, com logs conferidos em T04. O tempo da revisão não foi medido. Em P09, Lucas enviou uma sessão A01 com 124 amostras, cinco F9, zero erros/avisos e nenhum evento de pulo. Caio aceitou prosseguir sem repetição com base no relato positivo; lacunas preservadas, sem declarar pulo comprovado. [Análise e fontes](evidencias/T04_A03_validacao_Lucas.md). Ferramentas recebidas são D04, não validam as correções D05; arquivos do jogo são idênticos aos de P08. Não atribuir essa execução à reunião de 27/10. O piloto da demo permanece futuro.

## 9. Encaminhamentos sem ampliar o jogo

1. Conferência inicial do modo de teste concluída por Caio em P08/T04. Novas falhas serão achados do suporte, sem reabrir A01 retroativamente; coleta na máquina principal de Lucas verificada em P09, com cobertura parcial aceita com ressalvas. Piloto da demo com mecânicas reais continua futuro.
2. A05 implementa movimento/combate/vida e integra seus eventos ao coletor; A06/A07 fazem o mesmo para habilidades, mapa e save. A04 permanece produção humana.
3. A09 empacota jogo, iniciador, analisador e guia; identifica a build. A10 executa o roteiro atualizado e testes negativos pertinentes. Preparação de saves/condições especiais pode ser assistida pela IA, sem exigir edição manual de JSON por Lucas e sem prometer que já existe automação desses cenários.
4. Antes de interpretar uma sessão, conferir configuração real, integridade/cobertura, eventos disponíveis e relato. Manter mudanças de protocolo e resultados por máquina/versão. Não alterar o cronograma sem solicitação.

## 10. Fontes e preservação

Referências técnicas: [Logger da Godot](https://docs.godotengine.org/en/stable/classes/class_logger.html), [OS](https://docs.godotengine.org/en/stable/classes/class_os.html), [Engine](https://docs.godotengine.org/en/stable/classes/class_engine.html), [opções de linha de comando](https://docs.godotengine.org/en/stable/tutorials/editor/command_line_tutorial.html), [PrivateMemorySize64](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.privatememorysize64) e [WorkingSet64](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.process.workingset64). Assinaturas do SDK local da Godot 4.7.2 foram conferidas para a implementação; não requer atualização de .NET por citar documentação atual.

D03 original, manifesto e fontes de 22/10 permanecem preservados. O original usava T03; T02 é o ID de trabalho conforme P05, sem contar dois testes. P06 registra as decisões de 27/10 e a solicitação de instrumentação; D04 preserva a saída do coletor. Nenhum dado de desempenho da demo final ou execução de Lucas é inventado. Integração A03 identificada em `e0aaeed18db26ff106a2f4a4b799c3c3d71320d6`. Atualização documental P09 posterior registra Lucas e aceitação humana das lacunas; nenhum novo commit/envio automático ao GitHub foi feito.
