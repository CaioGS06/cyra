# Diário do Experimento — Cyra

Registros iniciados em **20/10/2026**, conforme a execução real, mesmo que a janela planejada de A01 tenha sido 15–18/10. Campos humanos, tempos e commits não aferidos permanecem pendentes. Este diário documenta desenvolvimento assistido com curadoria; não há implementação manual independente de comparação.

## 1. Tabela 1: Resumo do Diário do Experimento

| ID | Data | Ativ. / Req. | Módulo / Script | Ferramenta / Modelo | ID do Prompt | Saída Original da IA | Intervenção / Revisão Humana | Resp. | Tempo Aprendizagem Godot | Tempo IA (Geração + Revisão + Correção) | Versão / Commit Integrado |
|---|---|---|---|---|---|---|---|---|---|---|---|
| D01 | 20/10 | A01 — ambiente e fluxo básico | Scripts/Test/TestActor.cs; Scripts/Test/TestSceneController.cs; Scenes/Test/TestSceneA01.tscn | Codex | [P01](Prompts_Utilizados.md) | Projeto Godot 2D .NET com ator de validação, piso, gatilho, UI e sinais nativos/personalizado, configuração Windows e documentação inicial. | Nenhuma alteração necessária após a revisão | Caio | 78 min | Revisão/Correção: 7 min 51 s | Original: `9cdfcc4`; versão integrada: `6bf3e2d`; validação de Lucas: `46d5986` |
| D02 | 22/10 | A02 — preparação e revisão documental | docs/A02_Escopo_Requisitos_Modelos.md; docs/evidencias/T01_A02_revisao.md; sem script/cena/configuração do jogo alterado | Codex; modelo específico não aferido | [P02](Prompts_Utilizados.md#p02--22102026--a02--preparação-documental); P03 — decisões humanas | D02 original preserva a proposta inicial, com requisitos/percurso/UC/SQL/save. | Caio, Lucas e Victor aprovaram habilidades/percurso e alteraram morte/save: reiniciar inimigos/obstáculos e não persistir seus estados; atordoamento absorvível a zero. Conferência da fonte/modelos e cinco casos simulados confirmados; T01 aprovado documentalmente com ajustes. | Caio, Lucas e Victor — reunião conjunta; Caio — relato e esclarecimentos posteriores | Não medido nesta revisão documental | Revisão conjunta: 33 min (15:02–15:35, 22/10/2026, America/Sao_Paulo); geração/edição IA e esclarecimentos posteriores não medidos | D02 original arquivado; base f8a2f06; revisão de trabalho sem commit |

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
- [x] Registrar decisões/achados e confirmação humana das conferências/simulações de T01. Hash integrado a registrar após commit humano.

**Revisão humana posterior — P03**

Caio informou participação conjunta de **Caio, Lucas e Victor**, em **22/10/2026, 15:02–15:35 (America/Sao_Paulo), 33 minutos**. Aprovaram pulo duplo/investida, limites sem cargas, absorção por comando, percurso/retorno, eventos de save e falhas. Alteraram a proposta: morte e reabertura reiniciam inimigos/obstáculos; esses estados não são persistidos. Caio esclareceu retorno ao ponto seguro da seção atual com vida máxima e habilidades/ativa mantidas, transição sem reinício e inimigo a zero atordoado sem prazo.

A revisão está em [T01_A02_revisao.md](evidencias/T01_A02_revisao.md). Contrato, invariantes e JSON foram ajustados; os originais arquivados não foram alterados. A mudança de persistência diverge da descrição original de S01 p. 5–6 e foi reconhecida pela equipe. Nas confirmações posteriores, Caio relatou conferência dos 12 RF/RNF/critérios contra a fonte, aprovação da adaptação UC/SQL e cinco simulações documentais sem contradições. Registrar a mudança também no texto final; nenhum teste de mecânica implementada é alegado.

**Situação:** **A02/T01 aprovadas documentalmente com ajustes incorporados**, conforme relatos e confirmações em P03. Duração conjunta medida: 33 min; geração/edição IA, esclarecimentos e confirmações posteriores não medidos. Parâmetros de implementação e protocolo A03 encaminhados às atividades correspondentes. Versão integrada será identificada após commit humano; nenhum commit ou envio automático foi feito.

## 3. Tabela 3: Registro de Testes Funcionais

| ID Teste | Requisito / Etapa | Condição Inicial | Passos Executados | Resultado Esperado | Resultado Observado | Situação | Evidência |
|---|---|---|---|---|---|---|---|
| T00 | A01 — ambiente, cena, entrada, colisão, sinais e exportação | D01 compilado; Godot .NET 4.7.2/SDK 8.0.422; templates Windows correspondentes instalados para etapa de exportação; cena reiniciada; repetir com o outro desenvolvedor | 1. Abrir projeto e compilar. 2. Executar e observar texto inicial e queda. 3. Clicar no botão antes de mover. 4. Mover nas duas direções e pular. 5. Entrar na área e voltar a entrar. 6. Clicar novamente no botão. 7. Conferir depurador. 8. Exportar release, fechar editor e repetir no executável. 9. Repetir abertura/execução no ambiente do outro desenvolvedor. | Texto inicial exato “Cyra em teste”; ator repousa sobre o piso, anda e pula sem atravessá-lo; clique isolado mantém entrada pendente; área e botão emitem sinais nativos e personalizado com título preservado; indicadores confirmam eventos reais; zero erros; pacote completo abre fora do editor; ambos reproduzem o fluxo. | Os resultados esperados foram observados sem divergência. | Aprovado | Evidências de Caio: `docs/evidencias/T00_A01_cena.png`, `docs/evidencias/T00_A01_exportacao.png` e `docs/evidencias/T00_A01.txt`. Confirmação de Lucas está no commit `46d5986` |
| T01 | A02 — revisão documental; sem teste de mecânicas implementadas | D02/P02 original preservado; A01/T00 aprovados | Revisão de decisões 1–9 em reunião de Caio/Lucas/Victor, 22/10/2026, 15:02–15:35; esclarecimentos de Caio sobre checkpoint, transição e atordoamento. Equipe confirmou fonte/critérios, aprovou adaptação UC/SQL e simulou os cinco casos finais sem contradições. | Regras coerentes com o percurso/save, distinção entre fonte e alterações da equipe, critérios/modelos conferidos e ausência de travamento na simulação documental. | Habilidades/percurso aprovados; morte reinicia inimigos/obstáculos; save exclui esses estados; transição mantém sessão; atordoamento a zero sem prazo. Divergência da persistência original explicitada. | Aprovado documentalmente com ajustes | [T01_A02_revisao.md](evidencias/T01_A02_revisao.md); 33 min de revisão conjunta; P03; original D02 preservado |

## 4. Integração e evidências

Versão original: D01. Prompt: P01. Teste: T00. Commit: A01: saida original Codex (9cdfcc4). Arquivo original e manifesto em `docs/saidas_originais/`. Evidências: [T00_A01_cena](evidencias/T00_A01_cena.png), [T00_A01_exportacao](evidencias/T00_A01_exportacao.png) e [T00_A01](evidencias/T00_A01.txt). Versão integrada: `6bf3e2d`; validação de Lucas: `46d5986`.

**A02:** D02/P02/T01; [documento consolidado](A02_Escopo_Requisitos_Modelos.md); original em [D02_A02.zip](saidas_originais/D02_A02.zip). Base de consulta: `f8a2f06`. Decisões humanas em P03 e T01_A02_revisao.md; revisão conjunta de 33 min, 22/10/2026, 15:02–15:35. T01 aprovado documentalmente; commit integrado ainda não criado; nenhum commit criado nesta tarefa.

## 5. Matriz de Revisão Cruzada e Rastreabilidade (A08)

As linhas A01 preservam a revisão já registrada. A linha A02 registra a revisão documental aprovada com ajustes; sua inclusão não declara execução da A08 nem aprovação dos testes futuros de mecânicas.

| Requisito | Módulo/Script e Versão | Autor Principal | Revisor Cruzado | Achado na Revisão (Estado/Sinais/Acoplamento) | Decisão/Correção | Teste Vinculado |
|---|---|---|---|---|---|---|
| A01 — ciclo de vida, entrada e colisão | Scripts/Test/TestActor.cs; Scenes/Test/TestSceneA01.tscn; D01/P01; versão integrada: `6bf3e2d`; revisão: `46d5986` | Caio; geração assistida por Codex | Lucas | Ações funcionais | Aprovado | T00 |
| A01 — sinais e UI de validação | Scripts/Test/TestSceneController.cs; Scenes/Test/TestSceneA01.tscn; D01/P01; commit pendente | Caio; geração assistida por Codex | Lucas | Interface funcional | Aprovado | T00 |
| A01 — ambiente e pacote desktop | Cyra.csproj; Cyra.sln; global.json; project.godot; export_presets.cfg; README.md; D01/P01 | Caio | Lucas | Build realizada sem problemas | Aprovado | T00 |
| A02 — requisitos, percurso, regras, UC e save (documental) | docs/A02_Escopo_Requisitos_Modelos.md; D02/P02/P03; T01_A02_revisao.md; sem commit desta revisão | Codex — preparação; Caio, Lucas e Victor — curadoria de regras | Caio, Lucas e Victor — revisão conjunta relatada; Caio — esclarecimentos posteriores | Proposta original mantinha derrotas/bloqueios após morte e no save; equipe decidiu reiniciá-los e nomeou atordoamento a zero | Incorporadas decisões DEC03–DEC07; fonte/critérios/modelos e cinco simulações confirmados pela equipe; T01 aprovado documentalmente com ajustes | T01 aprovado documentalmente; testes futuros não executados |
