# Cyra

Estudo de caso acadêmico de desenvolvimento de um jogo 2D com Godot .NET/C# e curadoria humana obrigatória. O escopo planejado contém três seções curtas, combate/vida, mimetismo de dois inimigos e duas habilidades, dois bloqueios e um save local único.

**Implementado:** ambiente e cena A01, documentação A02 e suporte optativo de logs A03. O ator de teste não constitui a implementação final de RF01/A05. Combate, vida, habilidades, mapa e save ainda não foram implementados.

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

3. No gerenciador de projetos do Godot, escolher **Importar**, selecionar `project.godot` na raiz e abrir. A cena principal já é `Scenes/Test/TestSceneA01.tscn`.
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

5. No Godot, usar o botão **Build** de C# se necessário e **F5** para executar o projeto. **F6** executa a cena aberta; **F8** interrompe. Confirmar o texto inicial exato **Cyra em teste**.
6. Usar **setas esquerda/direita** para mover e **Espaço** para pular (`ui_left`, `ui_right`, `ui_accept` nativos). Observar a queda até o piso, caminhar até a área verde e clicar em **Testar sinal de UI**. O título permanece visível e a confirmação identifica a origem do sinal.

O botão não recebe foco de teclado, para que Espaço continue dedicado ao pulo durante o teste. Os indicadores distinguem entrada, colisão com o piso e sinal; clicar antes de mover mantém a entrada como pendente. O ator pode cair pelas extremidades do piso: reiniciar a cena para repetir o ensaio. Não há reinício, vida ou sistema de jogo nesta A01.

## Configurar os templates e exportar para Windows

1. Abrir o projeto com **Godot 4.7.2 .NET** e acessar **Editor → Gerenciar modelos de exportação / Manage Export Templates**.
2. Instalar os templates **4.7.2 stable .NET/mono**, da mesma versão do editor. Usar o download do gerenciador ou **Install from File** com `Godot_v4.7.2-stable_mono_export_templates.tpz` da [versão oficial](https://github.com/godotengine/godot/releases/tag/4.7.2-stable). O pacote completo informado pela distribuição tem aproximadamente 1,20 GB.
3. Confirmar que o gerenciador reconhece os modelos instalados. No Windows local, o Godot espera `windows_debug_x86_64.exe` e `windows_release_x86_64.exe` em `%APPDATA%\Godot\export_templates\4.7.2.stable.mono\`.
4. Compilar a solução C# e abrir **Projeto → Exportar / Project → Export**. Já existe o preset **Windows Desktop**, arquitetura `x86_64`, com saída `build/windows/Cyra.exe`. Exporta-se a cena de teste com suas dependências; `docs/` fica fora dos recursos do jogo.
5. Criar `build/windows/`, selecionar **Exportar Projeto / Export Project**, desmarcar **Export With Debug** para release e exportar. Manter todos os arquivos gerados juntos, inclusive `.pck` e a pasta de bibliotecas .NET; não distribuir apenas o `.exe`.
6. Fechar o editor e abrir `build/windows/Cyra.exe` pelo Explorador. Repetir os controles, o pouso no piso, o gatilho e o botão. Lucas deve repetir o procedimento em seu ambiente antes de encerrar a A01.

Alternativa por PowerShell, depois de instalar os templates:

```powershell
$godot = "C:\Godot_v4.7.2-stable_mono_win64\Godot_v4.7.2-stable_mono_win64_console.exe"
New-Item -ItemType Directory -Path build/windows -Force
& $godot --headless --path . --export-release "Windows Desktop" "build/windows/Cyra.exe"
& ".\build\windows\Cyra.exe"
```

Procedimento baseado na documentação oficial de [C# no Godot](https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_basics.html) e de [exportação Windows](https://docs.godotengine.org/en/stable/tutorials/export/exporting_for_windows.html). As versões efetivamente utilizadas constam na tabela de ambiente acima.

## Estado da verificação

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
| `Scripts/Player`, `Scripts/Enemies`, `Scripts/Save` | Reservas para módulos futuros |
| `Assets/Sprites`, `Assets/Audio`, `Assets/TileSets` | Exclusivas para recursos humanos futuros |
| `docs` | Documentação, prompts, saída original e evidências; ignorada pelo importador Godot |

O controller conecta `Button.Pressed` e `Area2D.BodyEntered` por código, emite `TesteConcluido(string mensagem)` e atualiza a UI. `TestActor` concentra entrada e física com `CharacterBody2D.MoveAndSlide()`. Piso e área usam as camadas 1 (piso) e 2 (ator), evitando detectar o piso como ator.

O Git ignora caches, exportações e temporários, preservando `.uid` e metadados `.import`. Os diretórios ainda vazios têm `.gitkeep`. `docs/.gdignore` impede a importação dos materiais acadêmicos existentes.

- [Diário principal: D01, T00 e matriz A08](docs/Diario_Experimento_Cyra.md)
- [A02 — escopo, requisitos e modelos: revisão documental aprovada com ajustes](docs/A02_Escopo_Requisitos_Modelos.md)
- [A03 — protocolo simplificado, revisão documental concluída com ajustes](docs/A03_Protocolo_Avaliacao_Curadoria.md)
- [Prompt P01 e roteiro original preservado](docs/Prompts_Utilizados.md)
- [Tabela metodológica inicial](docs/Diario_Experimento_IA.md)
- [Saída original preservada](docs/saidas_originais/D01_A01.zip), antes de revisão humana

A saída original está preservada no commit `9cdfcc4` e no arquivo ZIP indicado acima. A versão integrada da A01 está em `6bf3e2d`, e a aprovação de Lucas está registrada em `46d5986`. Os detalhes da curadoria e das evidências ficam no diário principal.

## Testes com coleta local automática — A03

O modo comum não grava sessões do coletor. Para testar com logs, use o pacote completo e `Executar_Teste.cmd`, conforme [guia de Lucas](docs/Guia_Lucas_Testes.md). Iniciador/analisador em `tools/Testing`; copiar os três arquivos e o guia ao lado do executável. A exportação separada atual está em `build/a03-test`, fora do Git; para compartilhar, enviar o pacote completo ou exportar novamente e copiar as ferramentas.

Lucas é a referência principal; Caio/Victor são complementares potenciais. Logs e resumo ficam em `TestResults/<sessão>`. Lucas usa F9 para marcar etapas e responde apenas o relato curto; IA auxilia análise/documentação sob curadoria. O resumo não aprova testes automaticamente. Caio confirmou revisão de código sem alterações e validação gráfica das seis etapas/F9; logs conferidos em [T04](docs/evidencias/T04_A03_coletor.md), com [evidência humana](docs/evidencias/T04_A03_validacao_humana_Caio.md). Piloto da demo na máquina de Lucas permanece futuro.

Os eventos atuais são da A01. A05–A07 integrarão vida/combate/habilidades/mapa/save quando implementados. Não há benchmark final ou teste de Lucas coletado nesta entrega.
