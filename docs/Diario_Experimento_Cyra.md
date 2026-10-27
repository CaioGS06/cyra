# Diário do Experimento — Cyra

Registros iniciados em **20/10/2026**, conforme a execução real, mesmo que a janela planejada de A01 tenha sido 15–18/10. Campos humanos, tempos e commits não aferidos permanecem pendentes. Este diário documenta desenvolvimento assistido com curadoria; não há implementação manual independente de comparação.

## 1. Tabela 1: Resumo do Diário do Experimento

| ID | Data | Ativ. / Req. | Módulo / Script | Ferramenta / Modelo | ID do Prompt | Saída Original da IA | Intervenção / Revisão Humana | Resp. | Tempo Aprendizagem Godot | Tempo IA (Geração + Revisão + Correção) | Versão / Commit Integrado |
|---|---|---|---|---|---|---|---|---|---|---|---|
| D01 | 20/10 | A01 — ambiente e fluxo básico | Scripts/Test/TestActor.cs; Scripts/Test/TestSceneController.cs; Scenes/Test/TestSceneA01.tscn | Codex | [P01](Prompts_Utilizados.md) | Projeto Godot 2D .NET com ator de validação, piso, gatilho, UI e sinais nativos/personalizado, configuração Windows e documentação inicial. | Nenhuma alteração necessária após a revisão | Caio | 78 min | Revisão/Correção: 7 min 51 s | Original: `9cdfcc4`; versão integrada: `6bf3e2d`; validação de Lucas: `46d5986` |
| D02 | 22/10 | A02 — preparação e revisão documental | docs/A02_Escopo_Requisitos_Modelos.md; docs/evidencias/T01_A02_revisao.md; sem script/cena/configuração do jogo alterado | Codex; modelo específico não aferido | [P02](Prompts_Utilizados.md#p02--22102026--a02--preparação-documental); P03 — decisões humanas | D02 original preserva a proposta inicial, com requisitos/percurso/UC/SQL/save. | Caio, Lucas e Victor aprovaram habilidades/percurso e alteraram morte/save: reiniciar inimigos/obstáculos e não persistir seus estados; atordoamento absorvível a zero. Conferência da fonte/modelos e cinco casos simulados confirmados; T01 aprovado documentalmente com ajustes. | Caio, Lucas e Victor — reunião conjunta; Caio — relato e esclarecimentos posteriores | Não medido nesta revisão documental | Revisão conjunta: 33 min (15:02–15:35, 22/10/2026, America/Sao_Paulo); geração/edição IA e esclarecimentos posteriores não medidos | D02 original arquivado; base f8a2f06; revisão humana integrada: `f145393` |
| D03 | 22/10; revisão 27/10 | A03 — preparação e revisão documental | docs/A03_Protocolo_Avaliacao_Curadoria.md; docs/evidencias/T02_A03_revisao.md; Guia_Lucas_Testes.md | Codex; modelo específico não aferido | P04/P05/P06 | Proposta documental original com método, coleta e limites detalhados, preservada em D03. | Equipe escolheu Lucas/MR02 e simplificou condições/ensaios/critérios com logs e análise assistidos; método A03-v2. Suporte de código separado em D04. | Caio, Lucas e Victor — revisão; Lucas — executor futuro | Não medido | Revisão conjunta: 41 min, 27/10/2026, 13:16–13:57; geração/edição posterior não medidas | Original D03 preservado; A02 f145393; revisão A03 sem commit |
| D04 | 27/10 | A03 — suporte optativo de coleta local, RNF01/RNF04 | Scripts/Core/TestRunRecorder.cs; TestEngineLogger.cs; eventos A01; project.godot; tools/Testing; guia/evidências | Codex; modelo específico não aferido | P06; fechamento P08 | Coletor local optativo, logger nativo, JSONL/F9/eventos da A01 e iniciador/analisador; sem mecânicas futuras. | Caio confirmou revisão do código sem alterações e seis etapas/F9 funcionando; logs conferidos. Correção posterior do iniciador em D05/P07 preservada. | Codex — geração/edição; Caio — revisão e teste gráfico | Não medido | Revisão humana de código não medida; geração/edição IA não aferidas; duração do processo não é esforço de revisão | Original D04 preservado; código revisado sem alterações por Caio; commit integrado a registrar após criação |
| D05 | 27/10 | A03 — correção do iniciador e validação pré-commit | tools/Testing/Executar_Teste.cmd; Executar_Teste.ps1; Analisar_Logs.ps1; guia/evidências | Codex; modelo específico não aferido | P07; fechamento P08 | Destino padrão corrigido, seleção explícita de computador e aviso de telemetria ausente. | Caio refez seis etapas com F9 e revisou o código sem alterações; logs da sessão gráfica confirmam seis marcadores, 68 amostras, sem erros/avisos/descartes, encerramento íntegro. | Codex — correção/reteste automático; Caio — revisão/teste humano | Não medido | Tempo de revisão não medido; duração automática do coletor cerca de 69,074 s, sem confundir com esforço humano | Original D05 preservado; revisão/validação humana concluída em P08; commit integrado ainda não criado |

## 2. Fichas detalhadas

### Registro D01 — A01

**Requisito / Objetivo**

Preparar um projeto Godot .NET/C# comum aos desenvolvedores e demonstrar cena/nó, anexação de script, ciclo de vida, entrada, colisão e sinais. Entregar configurações Git, pastas, cena mínima, procedimento de exportação Windows e documentação. A preparação não implementa RF01/RF02, mimetismo, mapa, save ou interface final das próximas atividades.

**Ambiente observado**

- Godot `4.7.2.stable.mono.official.ed1daf0bf`, confirmado executando o editor instalado em `C:\Godot_v4.7.2-stable_mono_win64` com `--version`.
- .NET SDK `8.0.422`, fixado em `global.json`; `net8.0`; pacote `Godot.NET.Sdk/4.7.2`.
- Windows local 25H2, build `26200.9711`, x64. Destino: Windows Desktop `x86_64`.
- Renderização Compatibility, viewport 960 × 540 e filtro Nearest.

**O que a IA entregou originalmente (Estado Antes da Revisão)**

`TestSceneA01.tscn` tem raiz `Node2D` com `TestSceneController.cs`, `CanvasLayer` com três labels e um botão, piso `StaticBody2D`, ator `CharacterBody2D` com `TestActor.cs` e zona `Area2D`. Todos os corpos/área têm `CollisionShape2D` e retângulos nativos para visualização; não foi criado nenhum asset artístico.

`TestActor._Ready()` registra a anexação do script. `_PhysicsProcess(double delta)` lê `Input.GetAxis("ui_left", "ui_right")` e `Input.IsActionJustPressed("ui_accept")`, aplica `GetGravity()`, condiciona o pulo a `IsOnFloor()` e chama `MoveAndSlide()`. As propriedades `EntradaObservada` e `ColisaoObservada` registram evidências acumuladas desde o início desta execução.

`TestSceneController._Ready()` obtém referências explícitas aos nós e conecta `BodyEntered`, `Pressed` e o sinal personalizado `[Signal] TesteConcluidoEventHandler(string mensagem)`. A área só aceita o ator de teste. O sinal personalizado preserva o título “Cyra em teste” e acrescenta a origem da confirmação. `_PhysicsProcess` atualiza indicadores independentes de entrada, piso e sinal; o clique isolado não certifica uma entrada que ainda não ocorreu. `_ExitTree()` remove as conexões.

Foram criados `.gitignore`, `.gitattributes`, `Cyra.csproj`, `Cyra.sln`, `global.json`, `project.godot`, preset Windows e as pastas futuras com `.gitkeep`. `docs/.gdignore` exclui os materiais acadêmicos da importação. A documentação explica reprodução, controles e exportação. O Git foi inicializado em `main`, sem commit e sem remoto.

**Preservação da saída original**

- [P01 — pedido e anexo integral](Prompts_Utilizados.md).
- [D01_A01.zip](saidas_originais/D01_A01.zip): scripts, cena, UIDs, configurações e README, antes de qualquer revisão humana.
- [D01_SHA256.txt](saidas_originais/D01_SHA256.txt): hashes dos arquivos arquivados.
- As verificações e os ajustes realizados pelo próprio Codex pertencem à geração da IA. Não foram registrados como intervenção humana. Preservar esse arquivo ao revisar e relacionar a versão integrada ao futuro commit.

**Verificações automatizadas realizadas em 20/10/2026**

| Verificação | Resultado real | Limite |
|---|---|---|
| `dotnet build Cyra.sln` com origem local dos pacotes Godot | Sucesso, zero avisos/erros; recompilação `--no-restore` também passou | Não prova comportamento visual |
| Importação por `--headless --editor --import` | Sucesso | Sem conferência humana no Inspector |
| Cena principal, `--headless --fixed-fps 60 --quit-after 120` | Inicializou ambos os scripts e encerrou sem erro | Sem execução gráfica |
| Ensaio temporário com entrada simulada e física real da engine | 14 checagens aprovadas, zero falhas; [log](evidencias/A01_verificacao_automatica.log) | Entrada de ações simulada; clique físico e teclado humano ainda pendentes |
| Preset Windows, tentativa `--export-release` | Falhou pela ausência dos templates `windows_debug_x86_64.exe` e `windows_release_x86_64.exe`; [log](evidencias/A01_exportacao_pendente.log) | Executável não gerado nem validado |
| Regras Git de exclusão e finais de linha | Caches, builds e temporários ignorados; fontes/cenas LF e solução CRLF | Sem commit integrado |

O ensaio carregou a própria cena C#, conectou um observador do sinal personalizado e verificou: texto inicial, emissão única via botão, título/confirmacão, entrada ainda pendente após clique, queda até o chão, repouso em Y ≈ 416, indicador de colisão, deslocamento à direita, sinal da área, confirmação da área, indicadores de entrada/sinal, pulo, retorno ao piso e deslocamento à esquerda. O script auxiliar ficou em `.godot/validation/`, fora da solução e da exportação.

**Ocorrências reais de ambiente**

A primeira consulta `dotnet --info` encontrou restrição de acesso ao gerenciador de serviços; a listagem de SDKs ainda identificou 8.0.422 e 10.0.401. A primeira compilação não acessou o índice público NuGet. Foi registrada a origem local `Godot-4.7.2-local`, apontando para `GodotSharp/Tools/nupkgs` da instalação, e a compilação passou. A primeira importação sem acesso à pasta de configuração local do editor também falhou; a importação com acesso à configuração do Godot passou. Essas ocorrências são de ambiente, não foram atribuídas a falhas de lógica C#.

Na geração inicial, os templates .NET de exportação não estavam instalados, e a tentativa automatizada de exportação falhou por esse motivo. Posteriormente, Caio instalou os templates correspondentes ao Godot .NET 4.7.2, exportou o projeto para Windows e executou o pacote fora do editor. Movimento, pulo, colisão, botão e área de gatilho funcionaram conforme esperado. As evidências estão em `docs/evidencias/T00_A01_cena.png` e `docs/evidencias/T00_A01_exportacao.png`. Lucas reproduziu os testes e registrou a aprovação do T00 no commit `46d5986`.

**O que exigiu Curadoria / Correção Humana**

- [X] Caio/Lucas: conferir os dois scripts e a cena, incluindo nomes de nós, referências e comentários de rastreabilidade.
- [X] Conferir as três `CollisionShape2D`, alinhamento dos retângulos e camadas/máscaras 1 (piso) e 2 (ator).
- [X] Confirmar no Inspector que não foram duplicadas as conexões feitas por C#.
- [X] Abrir graficamente, conferir legibilidade e título inicial exato; verificar ausência de erros no depurador.
- [X] Testar setas, pulo, gravidade e pouso; conferir que clicar antes de mover não valida entrada.
- [X] Entrar/sair da área, retornar e clicar novamente no botão; conferir título e confirmações.
- [X] Instalar templates .NET 4.7.2, exportar, executar fora do editor e guardar a evidência T00.
- [X] O segundo desenvolvedor repetir abertura, compilação e execução em seu ambiente.
- [X] Preencher revisão, responsáveis, tempos efetivamente medidos e commit integrado; manter a saída original preservada.

**Situação:** A01 concluída conforme os registros de validação de Caio e Lucas. Caio validou a cena no editor e no executável Windows; Lucas confirmou a reprodução do ambiente e aprovou o T00 e a revisão cruzada no commit `46d5986`.

### Registro D02 — A02 (preparação documental)

**Data real:** 22/10/2026; a janela planejada de 15–18/10 não foi usada como data de execução. **Ferramenta:** Codex; modelo específico não aferido. **Prompt:** P02, integral em [Prompts utilizados](Prompts_Utilizados.md) e [arquivo próprio](prompts/P02_A02_prompt_integral.md).

**Requisito / Objetivo**

Preparar somente os entregáveis documentais da A02: conferir RF01–RF06/RNF01–RNF06 contra o PDF assinado indicado pelo grupo, consolidar critérios previstos, percurso de três seções, regras de habilidades/combate/reinício, casos de uso e save local. Separar exigências da fonte, decisões humanas registradas e propostas da IA, sem implementar atividades futuras ou declarar aprovação da A02.

**O que a IA entregou originalmente (Estado Antes da Revisão)**

[A02_Escopo_Requisitos_Modelos.md](A02_Escopo_Requisitos_Modelos.md) contém transcrições conferidas nas páginas 3–4 da fonte, matriz de demonstração/atividade/cenários previstos para os 12 requisitos, mapa técnico em Mermaid de S1→A→O1→S2→B→O2→S3 e retorno, regras propostas de absorção/forma ativa/uso/morte, conferência dos UC01–UC05 e adaptação documental do modelo SQL para um único JSON local. Diferencia catálogo, progresso e estado transitório, especifica IDs/checkpoints, momentos de gravação e carga, casos inexistente/inválido/falha, invariantes e um exemplo fictício de JSON. Lista DEC01–DEC11 e a conferência documental T01.

Foram preservados os diagramas/SQL existentes, acrescentado um link no README e registrados P02/D02/T01. **Não houve geração nem alteração de scripts C#, cenas, assets ou configurações do jogo.** A nomenclatura técnica de seções/inimigos/habilidades não é narrativa final. As skills locais de diário e rastreabilidade foram adaptadas à preparação documental explicitamente solicitada; não foram criados registros de código ou de testes de mecânicas inexistentes.

**Fontes e estado de partida**

AGENTS.md; cronograma; guia; D01/P01/README; PDF exato `C:\Users\caio\Downloads\(CLV) LES - 5 - Relatorio_Parcial_Final_ADS_assinado (1).pdf`, acessível; diagramas de casos de uso e dados em `docs/arquivos_tcc/`; `Untitled.sql`; antecedentes auxiliares identificados na seção 1 do documento. Páginas 2–6 do PDF e PNGs dos modelos foram conferidos visualmente, além da extração textual. A fonte primária não foi trocada pelo relatório homônimo do repositório.

A01/T00 permanecem aprovados conforme a curadoria registrada por Caio e Lucas. Histórico consultado: original `9cdfcc4`, integração indicada `6bf3e2d`, validação Lucas `46d5986`, consolidação `f8a2f06` (HEAD de partida). A aprovação da A01 não aprova as regras/documentos novos de A02.

**Lacunas e divergências da preparação original (histórico)**

- A comparação manual do PDF p. 6 e do resumo antigo foi retirada por decisão do grupo no cronograma/P02; não se propõe implementação manual independente.
- `qt_uso`/`qt_uso_atual` não têm semântica ou valores definidos; habilidades pulo duplo/investida continuam sendo propostas, não uma escolha humana comprovada.
- Modelo SQL não explicita checkpoint, coleção de aquisições e inimigos derrotados descritos na fonte; sua adaptação para save único permanece proposta.
- Limiares de desempenho, teclas, parâmetros de vida/dano/ações e dimensões físicas dependem de definição humana. Nenhum requisito inacessível foi inventado; S01 estava acessível. Links antigos para Desktop e trechos históricos da A01 foram identificados sem alterar resultados anteriores.

**Preservação da saída original**

- [D02_A02.zip](saidas_originais/D02_A02.zip): documento A02, README e registros documentais desta entrega, antes de futuras revisões humanas.
- [D02_SHA256.txt](saidas_originais/D02_SHA256.txt): manifesto dos arquivos arquivados; [D02_fontes_SHA256.txt](saidas_originais/D02_fontes_SHA256.txt): identificação das fontes consultadas.
- O arquivo original D01 e seus hashes não foram substituídos. O arquivo D02 inclui cópias dos registros para preservar o estado desta entrega; edições futuras devem ocorrer nos arquivos de trabalho, mantendo o ZIP original.

**Conferência automática da preparação**

A conferência de estrutura, links, presença dos 12 requisitos, JSON ilustrativo, integridade do arquivo original e limitação das alterações à documentação serve apenas para verificar a entrega da IA. Não corresponde à execução humana de T01, aprovação de conteúdo, teste do jogo, medição de desempenho ou revisão cruzada concluída. Nenhuma nova compilação/exportação da A01 é necessária para esta alteração documental.

**O que exigiu Curadoria / Correção Humana**

- [x] Equipe confirmou transcrições/origem/páginas e critérios contra a fonte, reconhecendo a mudança de persistência.
- [x] Caio, Lucas e Victor revisaram habilidades, limites de uso e percurso/retorno; registrar revisão conjunta de 33 min. Inventário/produção dos recursos humanos permanece A04.
- [x] Registrar decisões sobre absorção/forma ativa, morte e reinício; simulações documentais confirmadas pela equipe em T01.
- [x] Equipe aprovou adaptação UC/SQL, save revisado, eventos e política para arquivo inválido.
- [x] Encaminhar parâmetros/controles às implementações correspondentes e protocolo de desempenho à A03; sem implementar A05–A09 nesta tarefa.
- [x] Registrar decisões/achados e confirmação humana das conferências/simulações de T01. Versão humana integrada A02: `f145393`, conferida no Git em 22/10/2026.

**Revisão humana posterior — P03**

Caio informou participação conjunta de **Caio, Lucas e Victor**, em **22/10/2026, 15:02–15:35 (America/Sao_Paulo), 33 minutos**. Aprovaram pulo duplo/investida, limites sem cargas, absorção por comando, percurso/retorno, eventos de save e falhas. Alteraram a proposta: morte e reabertura reiniciam inimigos/obstáculos; esses estados não são persistidos. Caio esclareceu retorno ao ponto seguro da seção atual com vida máxima e habilidades/ativa mantidas, transição sem reinício e inimigo a zero atordoado sem prazo.

A revisão está em [T01_A02_revisao.md](evidencias/T01_A02_revisao.md). Contrato, invariantes e JSON foram ajustados; os originais arquivados não foram alterados. A mudança de persistência diverge da descrição original de S01 p. 5–6 e foi reconhecida pela equipe. Nas confirmações posteriores, Caio relatou conferência dos 12 RF/RNF/critérios contra a fonte, aprovação da adaptação UC/SQL e cinco simulações documentais sem contradições. Registrar a mudança também no texto final; nenhum teste de mecânica implementada é alegado.

**Situação:** **A02/T01 aprovadas documentalmente com ajustes incorporados**, conforme relatos e confirmações em P03. Duração conjunta medida: 33 min; geração/edição IA, esclarecimentos e confirmações posteriores não medidos. Parâmetros de implementação e protocolo A03 encaminhados às atividades correspondentes. Versão humana integrada: `f145393`, conferida no Git em 22/10/2026; nenhum commit ou envio automático foi feito nesta atualização de referência.

### Registro D03 — A03 (preparação documental)

**Data real:** 22/10/2026, America/Sao_Paulo; sem retroagir à janela de 16–20/10 e sem alterar o cronograma. **Ferramenta:** Codex; modelo específico não aferido. **Prompt atual:** P04, integral no [índice](Prompts_Utilizados.md) e em [arquivo próprio](prompts/P04_A03_prompt_integral.md).

**Conferência dos IDs:** P03 já contém a revisão humana da A02 e permanece intocado. O pedido atual solicita o próximo ID e também menciona P03: adota-se P04 para preservar o registro existente. D03 estava livre. A instrução final de P04 originalmente reservou T03. Em 27/10/2026, o usuário solicitou T02 (P05), que estava livre e passa a identificar a ficha de trabalho. T03 fica como referência histórica no ZIP D03, sem outra execução. T00/T01 e cenários C-RFxx/C-RNFxx/C-SAVE não são renumerados.

**Requisito / Objetivo**

Preparar o método de avaliação e registros da curadoria humana, aproveitando a matriz e as decisões aprovadas da A02 sem reabri-las. Diferenciar evidências documentais, compilação, teste funcional, revisão arquitetural e medição; planejar coleta reproduzível para A10 e registro de esforço sem comparação manual independente.

**O que a IA entregou originalmente (Estado Antes da Revisão)**

[A03_Protocolo_Avaliacao_Curadoria.md](A03_Protocolo_Avaliacao_Curadoria.md) consolida ciclo requisito–prompt–original–revisão–correção–teste–integração–análise, estados de teste versus requisito, rastreabilidade, categorias de achado/intervenção/reteste e critérios de consolidação com denominadores. Referencia os 12 RF/RNF e os cenários da A02 sem duplicar sua tabela. A ficha [T02 preparada](evidencias/T02_A03_revisao.md) contém roteiro e campos humanos ainda vazios.

Proposta de medição: perfil de máquina MR01 e condições de pacote release; PROG (aquecimento de 60 s + percurso/janela de 5 min), CONT (aquecimento de 2 min + cinco ciclos de 2 min), três repetições sugeridas. SAVE/morte/reabertura e DIAG/editor ficam separados. Métodos propostos: saída FPS da engine e contadores do processo no Performance Monitor; alternativas manuais e dependência de trace adequado para tempo real entre quadros. FPS, memória privada/working set e memória da engine não são equiparados. Limites de aceitação são propostas, sem números observados inventados ou alegação de ausência absoluta de vazamento.

Modelos mínimos de execução, medição e defeito/reteste ficam no próprio protocolo, com campos observados sem preenchimento. Etapas de esforço são separadas; “não medido” é preservado. Não foi criado outro diário, coletor, instrumentação, script C#, cena, asset ou configuração do jogo. Não houve execução de medições/testes da demo final.

**Fontes e estado confirmado**

Lidos AGENTS, cronograma, guia, A02, T01, diário principal, template metodológico inicial, índice de prompts e README. Git confirmou `f1453934c0be612ae8f5c70515820624d15478bd` como integração humana da A02. Atualizados somente os campos de versão de trabalho pendentes da A02 no documento, diário e evidência T01; regras, resultados e tempos anteriores foram preservados. Originais D01/D02, manifestos e textos P01–P03 não foram regravados.

Consulta local somente de leitura identificou i5-12400F (6/12), GTX 750, 17.004.335.104 bytes de RAM física reportada, Windows 11 Pro 25H2/build 26200.9711, vídeo reportado 1920×1080/60 Hz, Godot .NET 4.7.2 e SDK 8.0.422; conferiu a presença das ferramentas Windows e opções CLI. Isso caracteriza equipamento observado, **não escolha humana da máquina nem benchmark**. O protocolo registra dependências de coleta/condições do pacote final; referências oficiais Godot/Microsoft sustentam as definições de métricas, sem criar requisitos novos da fonte.

Regras A02 mantidas: aquisições/ativa permanentes, atordoamento sem prazo por comando, estado de mundo mantido nas transições e reiniciado na morte/reabertura, checkpoint atual/vida máxima na morte e save sem inimigos/obstáculos. A divergência de persistência da fonte continua explícita. A01/T00 e A02/T01 não aprovam a demo final ou RNF04.

**Preservação**

- [D03_A03.zip](saidas_originais/D03_A03.zip): proposta e registros documentais desta entrega antes de revisão humana.
- [D03_SHA256.txt](saidas_originais/D03_SHA256.txt): integridade das entradas do arquivo; [D03_fontes_SHA256.txt](saidas_originais/D03_fontes_SHA256.txt): fontes locais na base `f145393`, antes das atualizações de versão desta tarefa.
- Verificações automáticas de links, estrutura, preservação e integridade são conferências da preparação da IA; não correspondem a T02 executado nem aprovação humana.

**O que exige Curadoria / Correção Humana**

- [x] Registrar MR02/Lucas como referência e condições iniciais adaptáveis, com configuração efetiva no log.
- [x] Incorporar pedido de ensaio simplificado e repetições motivadas; piloto futuro separado.
- [x] Adotar coleta automática solicitada em P06; implementação e validação separadas em D04/T04.
- [x] Simplificar critérios e manter interpretação/denominadores/limites explícitos, sem aprovação automática.
- [x] Registrar revisão de Caio/Lucas/Victor, 41 min, decisões e versão A03-v2 em P06/T02.

**Revisão humana posterior — P06, 27/10/2026**

Caio informou participação de Caio, Lucas e Victor, 13:16–13:57 (America/Sao_Paulo), **41 min conjuntos**. Escolheram Lucas/Ryzen 7 8700G/Radeon 780M/32 GB 5600 MHz/Windows 11 como máquina principal; Caio e Victor poderão fazer ensaios complementares separados. Solicitaram roteiro/critérios menos rígidos e registros automáticos, ficando Lucas com jogo/observação/relato curto e IA com grande parte da configuração/coleta/análise assistida, sob curadoria da equipe.

A proposta extensa original permanece no ZIP D03. Protocolo de trabalho **A03-v2** incorpora simplicidade e adaptação versionada, sem alterar critérios retroativamente para aprovar dados. [Guia de Lucas](Guia_Lucas_Testes.md) e [T02](evidencias/T02_A03_revisao.md) registram decisões. O pedido autoriza explicitamente suporte de logs no projeto, antes vedado por P04 apenas documental; código e ensaios estão separados em D04/T04. Não se atribui simulação de percentuais/benchmark ou validação gráfica do coletor à reunião.

**Situação:** A03/T02 aprovadas documentalmente com ajustes. Observações da demo final não preenchidas. Duração conjunta humana 41 min; geração/edição/ensaios automáticos não medidos como esforço humano. Validação gráfica/revisão de código concluídas por Caio em P08/T04; piloto da demo em Lucas fica futuro; sem commit/envio automático.

### Registro D04 — A03, suporte de coleta solicitado em P06

**Objetivo:** reduzir anotação manual de Lucas com logs locais e análise assistida, conforme pedido explícito posterior à tarefa documental P04. Aplicadas as skills cyra-gerador-c-sharp, cyra-diario-experimento e cyra-rastreabilidade-testes. Nenhuma arte, narrativa final ou mecânica futura foi criada.

**Saída da IA:** TestRunRecorder autoload, inativo sem --cyra-test; fila limitada e arquivo exclusivo JSONL, metadados de execução/configuração, memória/FPS aproximadamente a cada segundo, marcadores F9 e notificações de foco. TestEngineLogger usa Logger/OS.AddLogger nativos, com callbacks seguros para threads, limite de texto/fila/tamanho e recuperação de falha de escrita. Eventos reais da cena A01 foram conectados sem alterar suas regras de física/sinais. Iniciador identifica pacote/saída da engine e cria pasta/relato; analisador preserva dados e relato e não atribui veredicto automático. Integrações de combate/vida/habilidades/mapa/save ficam nas A05–A07.

**Geração e ocorrências internas:** primeira compilação encontrou ambiguidade de FileAccess/Environment entre Godot e .NET; a IA qualificou os nomes e a compilação final passou sem avisos/erros. Isso é correção da geração, não intervenção humana. A primeira importação no sandbox não acessou configuração local da engine e falhou; a execução com acesso ao ambiente passou a importar/exportar. Os comandos via console wrapper chegaram ao fim de empacotamento mas ficaram aguardando; foram interrompidos após concluir, e o pacote produzido foi executado com êxito em verificação técnica. Não atribuir esse comportamento do ambiente ao desempenho da demo.

**Verificação automática:** [T04](evidencias/T04_A03_coletor.md), [24 checagens](evidencias/T04_A03_verificacao_automatica.json) e [amostra release headless](evidencias/T04_A03_amostra_automatica.jsonl). Compilação zero avisos/erros; eventos, F9 simulado, avisos/erro nativo injetados, modo comum sem pasta, falha de gravação sem interromper cena, fluxo release com resumo e identificação de pacote, log incompleto sinalizado e relato não sobrescrito. Os dois avisos/erros T04_expected_* são injeções do ensaio, não defeitos reais do jogo. Ensaios sem janela na máquina de Caio, não benchmark gráfico nem execução de Lucas.

**Curadoria humana concluída / limites:** Caio confirmou em P08 leitura do código sem alterações e execução gráfica das seis etapas/F9. Logs foram conferidos; [evidência humana](evidencias/T04_A03_validacao_humana_Caio.md). Tempo da revisão não medido. Conferir overhead/configuração na máquina principal durante o piloto futuro da demo. Dados do coletor não cobrem percepção/legibilidade ou esforço fora do jogo. Sem rodapé/coleta completa, não inferir crash nem aprovação automaticamente. Tempo de geração/edição não medido.

**Preservação:** docs/saidas_originais/D04_A03_Coleta.zip e D04_SHA256.txt preservam a saída entregue após verificações da IA e antes de futura revisão humana; D01–D03 não são regravados. Revisão de código e validação gráfica concluídas por Caio em P08; nenhuma alteração de código necessária; nenhum commit/envio automático.

### Registro D05 — A03, ajuste do iniciador em P07

Caio relatou jogo sem problemas visuais/lógicos pelo CMD. As sessões 20261027T185433341Z-b494a1e5 e 20261027T185757356Z-d013da9c, em build/windows, não contêm session.jsonl/amostras/marcadores. O fallback do iniciador abriu um pacote anterior ao coletor; o perfil padrão Lucas também não identificava o executor. Preservar o relato visual e os arquivos originais, sem aprovar coleta inexistente.

A IA alterou somente CMD/PowerShell/analisador e orientação correspondente: destino padrão build/a03-test quando executado de tools, pergunta explícita de computador, perfil desconhecido quando omitido e aviso claro quando faltarem registros. Isso é correção assistida da entrega, não código escrito por Caio. [Achado e reteste T04](evidencias/T04_A03_correcao_iniciador.md). Reteste headless técnico pelo novo padrão produziu cabeçalho/fim/amostras e exit_code 0; não prova experiência gráfica.

**Concluído em P08:** Caio revisou o código sem alterações e refez as seis etapas/F9; sessão gráfica com perfil Caio, seis marcadores ordenados, 68 amostras e encerramento normal, sem erros/avisos/descartes registrados. Foram preservadas quatro perdas/retomadas de foco como limite para análise de desempenho. Tempo da revisão não medido. O piloto da demo em Lucas e eventos futuros A05–A07 são encaminhamentos, não pré-requisitos de commit deste suporte. Tempo humano não informado = não medido. D04/manifesto originais preservados; D05_A03_Iniciador.zip/D05_SHA256.txt preservam esta correção antes de futura revisão humana. Nenhum commit/envio automático.

**Encerramento de D04/D05 — P08:** [T04 validado por Caio](evidencias/T04_A03_validacao_humana_Caio.md), sessão gráfica de 27/10/2026, aproximadamente 16:13:18–16:14:27 America/Sao_Paulo. Tempo do processo obtido automaticamente; tempo de revisão humana não medido. Relato recebido pela conversa preservado separado do formulário bruto não preenchido. A03 pronta para commit no escopo entregue; testes da futura demo e de Lucas/Victor não foram antecipados. Originais e duas sessões sem coleta permanecem preservados.

## 3. Tabela 3: Registro de Testes Funcionais

| ID Teste | Requisito / Etapa | Condição Inicial | Passos Executados | Resultado Esperado | Resultado Observado | Situação | Evidência |
|---|---|---|---|---|---|---|---|
| T00 | A01 — ambiente, cena, entrada, colisão, sinais e exportação | D01 compilado; Godot .NET 4.7.2/SDK 8.0.422; templates Windows correspondentes instalados para etapa de exportação; cena reiniciada; repetir com o outro desenvolvedor | 1. Abrir projeto e compilar. 2. Executar e observar texto inicial e queda. 3. Clicar no botão antes de mover. 4. Mover nas duas direções e pular. 5. Entrar na área e voltar a entrar. 6. Clicar novamente no botão. 7. Conferir depurador. 8. Exportar release, fechar editor e repetir no executável. 9. Repetir abertura/execução no ambiente do outro desenvolvedor. | Texto inicial exato “Cyra em teste”; ator repousa sobre o piso, anda e pula sem atravessá-lo; clique isolado mantém entrada pendente; área e botão emitem sinais nativos e personalizado com título preservado; indicadores confirmam eventos reais; zero erros; pacote completo abre fora do editor; ambos reproduzem o fluxo. | Os resultados esperados foram observados sem divergência. | Aprovado | Evidências de Caio: `docs/evidencias/T00_A01_cena.png`, `docs/evidencias/T00_A01_exportacao.png` e `docs/evidencias/T00_A01.txt`. Confirmação de Lucas está no commit `46d5986` |
| T01 | A02 — revisão documental; sem teste de mecânicas implementadas | D02/P02 original preservado; A01/T00 aprovados | Revisão de decisões 1–9 em reunião de Caio/Lucas/Victor, 22/10/2026, 15:02–15:35; esclarecimentos de Caio sobre checkpoint, transição e atordoamento. Equipe confirmou fonte/critérios, aprovou adaptação UC/SQL e simulou os cinco casos finais sem contradições. | Regras coerentes com o percurso/save, distinção entre fonte e alterações da equipe, critérios/modelos conferidos e ausência de travamento na simulação documental. | Habilidades/percurso aprovados; morte reinicia inimigos/obstáculos; save exclui esses estados; transição mantém sessão; atordoamento a zero sem prazo. Divergência da persistência original explicitada. | Aprovado documentalmente com ajustes | [T01_A02_revisao.md](evidencias/T01_A02_revisao.md); 33 min de revisão conjunta; P03; original D02 preservado |
| T02 | A03 — revisão documental do protocolo | D03/P04 original; A02/T01 aprovadas | Caio, Lucas e Victor revisaram em 27/10/2026, 13:16–13:57 (41 min); P06 informa máquinas, responsabilidades e pedidos de simplificação/coleta automática. | Método viável, adaptável com rastreabilidade e participação manual reduzida, sem inventar medições ou aprovar demo. | Lucas/MR02 referência; Caio/Victor opcionais; ensaios e critérios simplificados; coleta local e guia incorporados, com limites da análise assistida explícitos. | Aprovado documentalmente com ajustes | [T02_A03_revisao.md](evidencias/T02_A03_revisao.md); P06; verificação do coletor separada em T04 |
| T04 | A03 — suporte de coleta; separado de T02 e sem benchmark final | D04/P06, correção D05/P07; pacote release, máquina Caio; originais preservados | Ensaios técnicos anteriores mais revisão de código e seis etapas/F9 executadas por Caio, conforme P08; IA conferiu sessão gráfica 20261027T191317657Z-1b393526. | Coleta íntegra, eventos/marcadores presentes, identificações corretas e resultado visual conforme relato, sem alterar regras do jogo ou aprovar automaticamente testes. | Seis marcadores 1–6, 68 amostras, eventos A01 e encerramento normal; zero erros/avisos/linhas inválidas/descartes; Caio aprovou código sem alterações, tempo não medido. Quatro perdas/retomadas de foco limitam desempenho. | Aprovado no escopo do coletor A03/A01 | [Validação humana Caio](evidencias/T04_A03_validacao_humana_Caio.md); arquivos brutos/manifesto; checagens anteriores em T04_A03_coletor.md |

T02 identifica a revisão documental da A03 conforme P05 (27/10/2026); não será reutilizado para mecânica. A saída original D03 o chamava T03, preservado como alias histórico, sem duplicar execução. T02 foi preenchida com a revisão relatada em P06; os ensaios técnicos do coletor têm T04 próprio.

## 4. Integração e evidências

Versão original: D01. Prompt: P01. Teste: T00. Commit: A01: saida original Codex (9cdfcc4). Arquivo original e manifesto em `docs/saidas_originais/`. Evidências: [T00_A01_cena](evidencias/T00_A01_cena.png), [T00_A01_exportacao](evidencias/T00_A01_exportacao.png) e [T00_A01](evidencias/T00_A01.txt). Versão integrada: `6bf3e2d`; validação de Lucas: `46d5986`.

**A02:** D02/P02/T01; [documento consolidado](A02_Escopo_Requisitos_Modelos.md); original em [D02_A02.zip](saidas_originais/D02_A02.zip). Base de consulta: `f8a2f06`. Decisões humanas em P03 e T01_A02_revisao.md; revisão conjunta de 33 min, 22/10/2026, 15:02–15:35. T01 aprovado documentalmente; commit humano integrado: `f145393`, conferido no Git em 22/10/2026; nenhum commit criado nesta atualização de referência.

**A03:** D03/P04/T02; [protocolo proposto](A03_Protocolo_Avaliacao_Curadoria.md); [original D03](saidas_originais/D03_A03.zip). Base de consulta/integracão humana A02: `f145393`. P03/A02 preservado; revisão humana em P06/T02 concluída com ajustes A03-v2; versão integrada ainda depende de commit humano. Sem commit desta entrega.

## 5. Matriz de Revisão Cruzada e Rastreabilidade (A08)

As linhas A01 preservam a revisão já registrada. A linha A02 registra a revisão documental aprovada com ajustes; sua inclusão não declara execução da A08 nem aprovação dos testes futuros de mecânicas. A linha A03 registra revisão metodológica concluída; código de coleta tem linha separada D04/T04.

| Requisito | Módulo/Script e Versão | Autor Principal | Revisor Cruzado | Achado na Revisão (Estado/Sinais/Acoplamento) | Decisão/Correção | Teste Vinculado |
|---|---|---|---|---|---|---|
| A01 — ciclo de vida, entrada e colisão | Scripts/Test/TestActor.cs; Scenes/Test/TestSceneA01.tscn; D01/P01; versão integrada: `6bf3e2d`; revisão: `46d5986` | Caio; geração assistida por Codex | Lucas | Ações funcionais | Aprovado | T00 |
| A01 — sinais e UI de validação | Scripts/Test/TestSceneController.cs; Scenes/Test/TestSceneA01.tscn; D01/P01; versão integrada: `6bf3e2d`; revisão: `46d5986` | Caio; geração assistida por Codex | Lucas | Interface funcional | Aprovado | T00 |
| A01 — ambiente e pacote desktop | Cyra.csproj; Cyra.sln; global.json; project.godot; export_presets.cfg; README.md; D01/P01 | Caio | Lucas | Build realizada sem problemas | Aprovado | T00 |
| A02 — requisitos, percurso, regras, UC e save (documental) | docs/A02_Escopo_Requisitos_Modelos.md; D02/P02/P03; T01_A02_revisao.md; versão humana integrada: `f145393` | Codex — preparação; Caio, Lucas e Victor — curadoria de regras | Caio, Lucas e Victor — revisão conjunta relatada; Caio — esclarecimentos posteriores | Proposta original mantinha derrotas/bloqueios após morte e no save; equipe decidiu reiniciá-los e nomeou atordoamento a zero | Incorporadas decisões DEC03–DEC07; fonte/critérios/modelos e cinco simulações confirmados pela equipe; T01 aprovado documentalmente com ajustes | T01 aprovado documentalmente; testes futuros não executados |
| A03 — método de avaliação e curadoria (documental) | A03-v2; Guia_Lucas_Testes.md; D03/P04/P05/P06; base f145393; sem commit desta revisão | Codex — preparação/edição; Caio/Lucas/Victor — curadoria | Caio, Lucas e Victor — revisão conjunta informada | Proposta extensa e coleta manual excessiva para a prioridade do estudo; referência observada era Caio | Simplificação solicitada; Lucas como referência/executor, IA apoia logs/análise com curadoria. Código em D04; T02 documental concluído | T02 aprovado com ajustes; T04 coleta separado |
| A03 — coletor local e iniciador/analisador | D04/D05/P06/P07/P08; Scripts/Core, eventos A01, autoload e tools/Testing; originais preservados; commit futuro | Codex — geração/correção | Caio — revisão de código sem alterações e teste gráfico confirmados em P08 | Iniciador antigo abria pacote sem coletor e atribuía perfil Lucas; correção documentada, sem ocultar tentativas | Correção da IA, reteste automático e validação gráfica/humana de Caio; logs íntegros. Tempo de revisão não medido; eventos futuros/piloto Lucas encaminhados | T04 aprovado; T02 metodológico distinto |
