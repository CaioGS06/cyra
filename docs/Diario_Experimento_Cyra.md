# Diário do Experimento — Cyra

Registros iniciados em **20/10/2026**, conforme a execução real, mesmo que a janela planejada de A01 tenha sido 15–18/10. Campos humanos, tempos e commits não aferidos permanecem pendentes. Este diário documenta desenvolvimento assistido com curadoria; não há implementação manual independente de comparação.

## 1. Tabela 1: Resumo do Diário do Experimento

| ID | Data | Ativ. / Req. | Módulo / Script | Ferramenta / Modelo | ID do Prompt | Saída Original da IA | Intervenção / Revisão Humana | Resp. | Tempo Aprendizagem Godot | Tempo IA (Geração + Revisão + Correção) | Versão / Commit Integrado |
|---|---|---|---|---|---|---|---|---|---|---|---|
| D01 | 20/10 | A01 — ambiente e fluxo básico | Scripts/Test/TestActor.cs; Scripts/Test/TestSceneController.cs; Scenes/Test/TestSceneA01.tscn | Codex | [P01](Prompts_Utilizados.md) | Projeto Godot 2D .NET com ator de validação, piso, gatilho, UI e sinais nativos/personalizado, configuração Windows e documentação inicial. | Nenhuma alteração necessária após a revisão | Caio | 78 min | Revisão/Correção: 7 min 51 s | A01: saida original Codex |

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

Os templates .NET de exportação não estavam instalados. A distribuição oficial disponibiliza o pacote `Godot_v4.7.2-stable_mono_export_templates.tpz` com 1.202.598.411 bytes; o download não foi realizado. A instalação e o ensaio do pacote estão descritos no README e permanecem pendentes. Não houve cronometragem confiável; não reconstruir tempos como se tivessem sido medidos.

**O que exigiu Curadoria / Correção Humana**

- [X] Caio/Lucas: conferir os dois scripts e a cena, incluindo nomes de nós, referências e comentários de rastreabilidade.
- [X] Conferir as três `CollisionShape2D`, alinhamento dos retângulos e camadas/máscaras 1 (piso) e 2 (ator).
- [X] Confirmar no Inspector que não foram duplicadas as conexões feitas por C#.
- [X] Abrir graficamente, conferir legibilidade e título inicial exato; verificar ausência de erros no depurador.
- [X] Testar setas, pulo, gravidade e pouso; conferir que clicar antes de mover não valida entrada.
- [X] Entrar/sair da área, retornar e clicar novamente no botão; conferir título e confirmações.
- [X] Instalar templates .NET 4.7.2, exportar, executar fora do editor e guardar a evidência T00.
- [ ] O segundo desenvolvedor repetir abertura, compilação e execução em seu ambiente.
- [X] Preencher revisão, responsáveis, tempos efetivamente medidos e commit integrado; manter a saída original preservada.

**Situação:** entrega de arquivos da A01 preparada e verificada automaticamente; A01 não encerrada metodologicamente até a exportação e a validação humana. Revisão humana: [PENDENTE PREENCHIMENTO HUMANO: Descrever ajustes de código/Inspector].

## 3. Tabela 3: Registro de Testes Funcionais

| ID Teste | Requisito / Etapa | Condição Inicial | Passos Executados | Resultado Esperado | Resultado Observado | Situação | Evidência |
|---|---|---|---|---|---|---|---|
| T00 | A01 — ambiente, cena, entrada, colisão, sinais e exportação | D01 compilado; Godot .NET 4.7.2/SDK 8.0.422; templates Windows correspondentes instalados para etapa de exportação; cena reiniciada; repetir com o outro desenvolvedor | 1. Abrir projeto e compilar. 2. Executar e observar texto inicial e queda. 3. Clicar no botão antes de mover. 4. Mover nas duas direções e pular. 5. Entrar na área e voltar a entrar. 6. Clicar novamente no botão. 7. Conferir depurador. 8. Exportar release, fechar editor e repetir no executável. 9. Repetir abertura/execução no ambiente do outro desenvolvedor. | Texto inicial exato “Cyra em teste”; ator repousa sobre o piso, anda e pula sem atravessá-lo; clique isolado mantém entrada pendente; área e botão emitem sinais nativos e personalizado com título preservado; indicadores confirmam eventos reais; zero erros; pacote completo abre fora do editor; ambos reproduzem o fluxo. | Resultados esperados | Aguardando execução do segundo integrante | Sugestão: `docs/evidencias/T00_A01_cena.png`; `docs/evidencias/T00_A01_exportacao.png`; registrar também ambiente, versão e responsável |

## 4. Integração e evidências

Versão original: D01. Prompt: P01. Teste: T00. Commit: A01: saida original Codex. Arquivo original e manifesto em `docs/saidas_originais/`. Capturas propostas em T00 ainda não existem. Não há métricas de desempenho, economia de tempo ou comparação manual coletadas nesta atividade.

## 5. Matriz de Revisão Cruzada e Rastreabilidade (A08)

Preparação documental vinculada exclusivamente à A01; não declara a execução da A08.

| Requisito | Módulo/Script e Versão | Autor Principal | Revisor Cruzado | Achado na Revisão (Estado/Sinais/Acoplamento) | Decisão/Correção | Teste Vinculado |
|---|---|---|---|---|---|---|
| A01 — ciclo de vida, entrada e colisão | Scripts/Test/TestActor.cs; Scenes/Test/TestSceneA01.tscn; D01/P01; commit pendente | Caio; geração assistida por Codex | Lucas |  | Nenhuma correção | T00 |
| A01 — sinais e UI de validação | Scripts/Test/TestSceneController.cs; Scenes/Test/TestSceneA01.tscn; D01/P01; commit pendente | Caio; geração assistida por Codex | Lucas |  | Nenhuma correção | T00 |
| A01 — ambiente e pacote desktop | Cyra.csproj; Cyra.sln; global.json; project.godot; export_presets.cfg; README.md; D01/P01 | Caio | Lucas |  | Nenhuma correção | T00 |
