# Cyra

Estudo de caso acadêmico de desenvolvimento de um jogo 2D com Godot .NET/C# e curadoria humana obrigatória. O escopo planejado contém três seções curtas, combate/vida, mimetismo de dois inimigos e duas habilidades, dois bloqueios e um save local único.

**Implementado:** A01 preservada, documentação A02/A03, coletor optativo e **sala A05 com jogador próprio, movimento, combate, vida e reinício local**. A05/T05 validada por Caio em P12, código sem alterações e valores aceitos provisoriamente; execução/revisão A05 de Lucas pendente. Absorção, habilidades, seções, obstáculos e save ainda não foram implementados.

Código, cena de teste e documentação tiveram assistência de IA (Codex). Arte, animação, som e narrativa finais deverão ser integralmente humanos. Nenhum asset artístico foi gerado; os visuais atuais são exclusivamente nós `ColorRect` e `Label` do Godot.

## Ambiente registrado em 20/10/2026

| Item | Versão/configuração |
|---|---|
| Godot .NET | `4.7.2.stable.mono.official.ed1daf0bf` (confirmada com `--version`) |
| Pacote C# da engine | `Godot.NET.Sdk/4.7.2` |
| .NET SDK | `8.0.422`, fixado em `global.json` |
| Framework do projeto | `net8.0` |
| Ambiente Windows local | 25H2, build `26200.9711`, arquitetura x64 |
| Destino da exportação | Windows Desktop, `x86_64` |
| Renderização | Compatibility/OpenGL; filtro de textura Nearest; viewport 960 × 540 |

O SDK 10.0.401 também está instalado nesta máquina, mas esta solução seleciona explicitamente o 8.0.422. Caio e Lucas devem usar as mesmas versões do editor .NET e do SDK.

## Clonar, abrir, compilar e executar

1. Instalar **Godot 4.7.2 .NET**, preservando a pasta `GodotSharp` junto ao editor, e **.NET SDK 8.0.422 x64**. A edição do Godot sem .NET não executa os scripts C#.
2. Clonar o repositório do grupo.

   ```powershell
   git clone https://github.com/CaioGS06/cyra.git cyra
   cd cyra
   dotnet --version
   ```

3. No gerenciador de projetos do Godot, escolher **Importar**, selecionar `project.godot` na raiz e abrir. A cena principal agora é `Scenes/Test/TestRoomA05.tscn`. Para a A01 histórica, abrir `Scenes/Test/TestSceneA01.tscn` e executar por **F6**; seus scripts/cena permanecem preservados.
4. Na raiz do projeto, compilar:

   ```powershell
   dotnet build Cyra.sln
   ```

   Se o pacote da engine não for encontrado no NuGet, registrar os pacotes incluídos na instalação .NET (ajustar o caminho em cada máquina):

   ```powershell
   dotnet nuget add source "C:\Godot_v4.7.2-stable_mono_win64\GodotSharp\Tools\nupkgs" --name Godot-4.7.2-local
   dotnet build Cyra.sln
   ```

   Nesta máquina, essa origem local já foi registrada durante a A01. Se o nome já existir em outra máquina, conferir a origem com `dotnet nuget list source` e corrigir seu caminho com `dotnet nuget update source Godot-4.7.2-local --source "CAMINHO_LOCAL\GodotSharp\Tools\nupkgs"`.

5. No Godot, usar o botão **Build** de C# se necessário e **F5** para executar A05. **F6** executa a cena aberta; **F8** interrompe. A tela identifica “teste A05”, jogador azul e inimigo em patrulha.
6. **A/D ou setas:** andar; **Espaço:** pular; **J:** ataque curto; **R** ou botão: reiniciar sala; **F9:** marcador com coleta ativa. Ações próprias `player_left/right/jump/attack/restart`, sem conflito com os controles históricos da A01. Seguir o [roteiro A05](docs/Guia_Lucas_Testes.md) para dano, atordoamento e morte/retorno.

O botão de reinício não recebe foco de teclado, mantendo Espaço dedicado ao pulo. Os parâmetros iniciais da A05 são jogador 5/inimigo 3, dano 1, janela de ataque 0,16 s/intervalo 0,45 s e proteção de dano 0,8 s, ajustáveis no Inspector e **não aprovados como balanceamento**. Morte recarrega somente a sala: vida máxima, ponto seguro e inimigo reiniciado; o autoload mantém a mesma sessão de logs. Detalhes e limites em [A05](docs/A05_Movimento_Combate_Vida.md). A01 continua sendo a cena descartável sem combate/vida/reinício, com seus controles e sinais originais.

## Configurar os templates e exportar para Windows

1. Abrir o projeto com **Godot 4.7.2 .NET** e acessar **Editor → Gerenciar modelos de exportação / Manage Export Templates**.
2. Instalar os templates **4.7.2 stable .NET/mono**, da mesma versão do editor. Usar o download do gerenciador ou **Install from File** com `Godot_v4.7.2-stable_mono_export_templates.tpz` da [versão oficial](https://github.com/godotengine/godot/releases/tag/4.7.2-stable). O pacote completo informado pela distribuição tem aproximadamente 1,20 GB.
3. Confirmar que o gerenciador reconhece os modelos instalados. No Windows local, o Godot espera `windows_debug_x86_64.exe` e `windows_release_x86_64.exe` em `%APPDATA%\Godot\export_templates\4.7.2.stable.mono\`.
4. Compilar a solução C# e abrir **Projeto → Exportar / Project → Export**. Usar **A05 Windows Desktop**, `x86_64`, saída `build/a05-test/Cyra.exe`. Exporta A05 e dependências, mantendo A01 incluída; `docs/` fica fora dos recursos. Não sobrescrever `build/a03-test` nem evidências anteriores.
5. Criar `build/a05-test/`, exportar release e executar `tools/Testing/Preparar_Pacote_A05.ps1`. Ele copia iniciadores/analisador/guia atuais e cria `test-package.json`. Manter EXE, PCK, bibliotecas e ferramentas juntos; não distribuir apenas o EXE.
6. Para modo comum, fechar o editor e abrir `build/a05-test/Cyra.exe` (sem logs do coletor). Para teste A05 com logs, abrir o **Executar_Teste.cmd dessa pasta**, escolher a máquina e seguir o guia. Validação gráfica e leitura do código em T05 continuam humanas.

Alternativa por PowerShell, depois de instalar os templates:

```powershell
$godot = "C:\Godot_v4.7.2-stable_mono_win64\Godot_v4.7.2-stable_mono_win64_console.exe"
New-Item -ItemType Directory -Path build/a05-test -Force
& $godot --headless --path . --export-release "A05 Windows Desktop" "build/a05-test/Cyra.exe" --quit
& ".\tools\Testing\Preparar_Pacote_A05.ps1"
& ".\build\a05-test\Executar_Teste.cmd"
```

Procedimento baseado na documentação oficial de [C# no Godot](https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_basics.html) e de [exportação Windows](https://docs.godotengine.org/en/stable/tutorials/export/exporting_for_windows.html). As versões efetivamente utilizadas constam na tabela de ambiente acima.

## Estado da verificação — histórico A01

- Compilação da solução: **aprovada, zero avisos e zero erros**.
- Importação pelo editor sem janela e execução da cena principal por 120 quadros: **aprovadas**.
- Ensaio automatizado na engine, sem janela: **14 checagens aprovadas**, cobrindo texto, queda/colisão, movimento nas duas direções, pulo e sinais nativos/personalizado. [Log real](docs/evidencias/A01_verificacao_automatica.log).
- Exportação Windows: **validada por Caio**, após a instalação dos templates correspondentes. A tentativa inicial que falhou permanece registrada em `docs/evidencias/A01_exportacao_pendente.log`.
- Validação humana: **T00 aprovado por Caio e Lucas**, com execução fora do editor e revisão cruzada registrada no diário. Aprovação de Lucas: commit `46d5986`.

## Estrutura e rastreabilidade

| Pasta | Responsabilidade |
|---|---|
| `Scenes/Test`, `Scripts/Test` | Cena e dois scripts exclusivos da A01 |
| `Scenes/Sections`, `Scenes/Entities`, `Scenes/UI` | Reservas para cenas futuras |
| `Scripts/Core` | Coletor local optativo A03 |
| `Scripts/Player`, `Scripts/Enemies`, `Scenes/Entities` | Controlador do jogador, inimigo e cenas reutilizáveis A05 |
| `Scripts/Save` | Reserva para persistência futura A07 |
| `Assets/Sprites`, `Assets/Audio`, `Assets/TileSets` | Exclusivas para recursos humanos futuros |
| `docs` | Documentação, prompts, saída original e evidências; ignorada pelo importador Godot |

O controller conecta `Button.Pressed` e `Area2D.BodyEntered` por código, emite `TesteConcluido(string mensagem)` e atualiza a UI. `TestActor` concentra entrada e física com `CharacterBody2D.MoveAndSlide()`. Piso e área usam as camadas 1 (piso) e 2 (ator), evitando detectar o piso como ator.

O Git ignora caches, exportações e temporários, preservando `.uid` e metadados `.import`. Os diretórios ainda vazios têm `.gitkeep`. `docs/.gdignore` impede a importação dos materiais acadêmicos existentes.

- [Diário principal: D01, T00 e matriz A08](docs/Diario_Experimento_Cyra.md)
- [A02 — escopo, requisitos e modelos: revisão documental aprovada com ajustes](docs/A02_Escopo_Requisitos_Modelos.md)
- [A03 — protocolo simplificado, revisão documental concluída com ajustes](docs/A03_Protocolo_Avaliacao_Curadoria.md)
- [A05 — componentes, parâmetros provisórios e verificações](docs/A05_Movimento_Combate_Vida.md)
- [T05 — revisão de Caio registrada; Lucas pendente](docs/evidencias/T05_A05_revisao.md)
- [Prompt P01 e roteiro original preservado](docs/Prompts_Utilizados.md)
- [Tabela metodológica inicial](docs/Diario_Experimento_IA.md)
- [Saída original preservada](docs/saidas_originais/D01_A01.zip), antes de revisão humana

A saída original está preservada no commit `9cdfcc4` e no arquivo ZIP indicado acima. A versão integrada da A01 está em `6bf3e2d`, e a aprovação de Lucas está registrada em `46d5986`. Os detalhes da curadoria e das evidências ficam no diário principal.

## Testes com coleta local automática — A03/A05

O modo comum não grava sessões do coletor. Para testar A05 com logs, use o pacote completo em **build/a05-test** e `Executar_Teste.cmd`, conforme [guia de Lucas](docs/Guia_Lucas_Testes.md). Iniciador/analisador atuais em `tools/Testing`; preparar com `Preparar_Pacote_A05.ps1`. A exportação anterior A03 permanece em `build/a03-test`. Para iniciar da raiz: `./tools/Testing/Executar_Teste.ps1 -Maquina Caio -Cenario A05` (Lucas informa sua própria máquina). Sem argumento de máquina, fica NaoInformada; o CMD pergunta. Pacotes release usam sua cena principal e não aceitam troca por `--scene`.

Lucas é a referência principal; Caio/Victor são complementares potenciais. Logs e resumo ficam em `TestResults/<sessão>`. Lucas usa F9 para marcar etapas e responde apenas o relato curto; IA auxilia análise/documentação sob curadoria. O resumo não aprova testes automaticamente. Caio confirmou revisão de código sem alterações e validação gráfica das seis etapas/F9; logs conferidos em [T04](docs/evidencias/T04_A03_coletor.md), com [evidência humana](docs/evidencias/T04_A03_validacao_humana_Caio.md). Lucas também executou o pacote A01, com coleta completa e relato positivo; Caio aceitou a execução com ressalvas em P09: cinco marcas F9 e nenhum evento de pulo. [Análise de Lucas](docs/evidencias/T04_A03_validacao_Lucas.md). O piloto da demo permanece futuro.

Os eventos atuais incluem A01 e A05 (movimento/salto/pouso, ataque, dano, vida, atordoamento, morte e retorno); A06/A07 integrarão seus eventos quando existirem. A03 foi integrada em `e0aaeed` e encerrada documentalmente em `cf5ba4a`, com as ressalvas de Lucas preservadas. O pacote recebido em `tools/Cyra_A03_Teste_Feito` permanece local, ignorado pelo Git; fontes recebidas preservadas em evidências não foram usadas para desenvolver A05. Usar as ferramentas atuais; ausência de telemetria continua sendo avisada e não vira aprovação.

## Verificações A05 e curadoria humana

O ensaio de comportamento `tools/Testing/VerifyA05.gd` carrega as cenas C# na física da engine, com entrada simulada e fixtures identificadas, e verifica movimento, alcance/direção, intervalos, atordoamento e reinícios repetidos. Execução **sem janela**, na máquina de Caio, pela IA; não equivale a teste gráfico humano ou benchmark. Os resultados finais, logs e limites estão na [ficha T05](docs/evidencias/T05_A05_revisao.md). A regressão A01 é registrada separadamente, sem alterar T00 histórico.

Comando opcional para repetir o ensaio na raiz (fora do pacote; não é tarefa de Lucas): `& $godot --headless --path . --max-fps 240 --script res://tools/Testing/VerifyA05.gd`. Para coletar logs desse ensaio, adicionar os argumentos `--cyra-test` e uma pasta exclusiva conforme A03. No pacote humano, basta jogar/F9/relato; o resumo não atribui veredicto automático. Caio confirmou 12 etapas funcionando e código sem alterações, aceitou os parâmetros provisórios e informou 15 min de revisão. A sessão tem dez F9, com esquecimento de marcas esclarecido, 181 amostras e duas mortes/retornos, sem erros/avisos. [Validação de Caio](docs/evidencias/T05_A05_validacao_humana_Caio.md). Lucas ainda sem execução/revisão A05 informada. Não há commit automático.
