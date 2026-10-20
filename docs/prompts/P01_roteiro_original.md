\# Contexto do Projeto e Escopo Arquitetural (Cyra)



Estamos iniciando do zero (0%) o desenvolvimento do jogo 2D "Cyra" utilizando Godot Engine (.NET / C#) na versão \[INSERIR VERSÃO EXATA, ex: Godot 4.3 .NET] com SDK \[INSERIR VERSÃO DO .NET, ex: .NET 8.0], voltado para exportação desktop em \[INSERIR SISTEMA, ex: Windows Desktop].



O desenvolvimento faz parte de um estudo de caso acadêmico sobre programação assistida por IA com curadoria humana obrigatória e autoria 100% humana para todos os assets visuais, animações, áudios e textos.



Embora você deva implementar APENAS os entregáveis da Atividade A01 neste momento, a estrutura de diretórios e configurações do projeto já deve prever o escopo completo planejado para as próximas etapas:



\- Movimentação 2D (andar, pular, cair), combate, sistema de vida e inimigos básicos (RF01, RF02 - Atividade A05).

\- Sistema de mimetismo/absorção de 2 inimigos copiáveis concedendo 2 habilidades (ex.: pulo duplo e investida) com transição visual baseada em sprites feitos por humanos (RF03, RF04 - Atividade A06).

\- Mapa dividido em 3 seções curtas e interligadas reaproveitando o mesmo conjunto de cenário, contendo 2 obstáculos/bloqueios que exigem a habilidade correta (RF05, RF06 - Atividade A07).

\- Persistência em um arquivo de save local único contendo seção/ponto seguro, vida, habilidades adquiridas, habilidade ativa, inimigos relevantes derrotados e obstáculos superados (Atividade A07).

\- Interface de menu/créditos com controles e aviso de transparência ao jogador detalhando os módulos assistidos por IA e a autoria humana dos assets (RNF03, RNF05, RNF06 - Atividade A09).



\# Tarefa Atual: Completar a Atividade A01 (Preparar ambiente, fluxo básico do Godot em C# e estrutura para exportação)



Não implemente os sistemas finais de jogo agora. Execute estritamente os 5 itens abaixo para concluir a A01:



1\. \*\*Configuração do Git (`.gitignore` e `.gitattributes`)\*\*:



\- Crie um `.gitignore` limpo e rigoroso para projetos Godot 4 com C# (.NET), ignorando pastas geradas automaticamente (`.godot/`, `.mono/`, `bin/`, `obj/`, `.vs/`, `.vscode/`, builds exportadas na pasta `build/` e arquivos temporários do sistema operacional) para que apenas o código-fonte, cenas, configurações e recursos necessários sejam versionados entre os dois desenvolvedores.



2\. \*\*Estrutura de Diretórios Escalável e Projeto Base\*\*:



\- Caso `project.godot`, `Cyra.sln` e `Cyra.csproj` ainda não existam na raiz, crie-os configurados para 2D (renderização compatível com pixel art / filtro Nearest) e C#. Se já existirem, preserve as configurações essenciais e aponte a cena principal (`run/main\\\_scene`) para a cena de teste da A01.

\- Crie a árvore de diretórios do projeto (com arquivos `.gdignore` ou `.gitkeep` onde apropriado) organizada para o ciclo completo:

&#x20;   - `res://Scenes/Test/` (para a cena de validação da A01)

&#x20;   - `res://Scenes/Sections/` (para as 3 seções interligadas futuras)

&#x20;   - `res://Scenes/Entities/` (para Cyra, inimigos e obstáculos futuros)

&#x20;   - `res://Scenes/UI/` (para HUD de vida, habilidade ativa e aviso de IA futuros)

&#x20;   - `res://Scripts/Test/` (para o script mínimo da A01)

&#x20;   - `res://Scripts/Core/`, `res://Scripts/Player/`, `res://Scripts/Enemies/`, `res://Scripts/Save/`

&#x20;   - `res://Assets/Sprites/`, `res://Assets/Audio/`, `res://Assets/TileSets/` (exclusivos para assets humanos futuros)

&#x20;   - `docs/` (na raiz do repositório, para documentação técnica e diários de curadoria)



3\. \*\*Cena 2D de Teste (`res://Scenes/Test/TestSceneA01.tscn`)\*\*:



\- Construa uma cena 2D funcional que não seja um jogo separado, mas um ambiente mínimo de validação contendo:

&#x20;   - Um `CanvasLayer` com um `Label` exibindo inicialmente o texto exato `"Cyra em teste"` e instruções rápidas na tela, além de um `Button` (ou gatilho visual) para testar sinais de UI.

&#x20;   - Um piso estático (`StaticBody2D` com `CollisionShape2D` e representação visual simples usando `ColorRect` ou `Polygon2D`, sem gerar arte por IA).

&#x20;   - Um ator de teste (`CharacterBody2D` com `CollisionShape2D` e `ColorRect`) posicionado acima do piso para demonstrar gravidade, movimento básico e colisão.

&#x20;   - Uma zona de gatilho (`Area2D` com `CollisionShape2D` e `ColorRect` identificado) posicionada ao lado do ator para demonstrar detecção de colisão e emissão de sinal.



4\. \*\*Script C# Mínimo de Validação (`res://Scripts/Test/TestSceneController.cs` e/ou script no `CharacterBody2D`)\*\*:



\- Escreva código C# idiomático para Godot 4, claro, comentado em português e de fácil revisão humana, demonstrando na prática os 4 pilares exigidos na A01:

&#x20;   - \*\*Anexação de Script e Ciclo de Vida\*\*: Uso de `\\\_Ready()` e `\\\_PhysicsProcess(double delta)`.

&#x20;   - \*\*Entrada (Input)\*\*: Leitura de comandos direcionais (setas ou A/D/Espaço via `Input.IsActionPressed` ou teclas padrão `ui\\\_left`, `ui\\\_right`, `ui\\\_accept`) para mover o `CharacterBody2D` de teste.

&#x20;   - \*\*Colisão Simples\*\*: Uso da física nativa da engine (`MoveAndSlide()`) colidindo com o `StaticBody2D` do chão sem atravessá-lo.

&#x20;   - \*\*Sinais (Signals)\*\*: Conexão via código C# de um sinal nativo (ex.: `BodyEntered` da `Area2D` e `Pressed` do `Button`) e declaração de um `\\\[Signal] public delegate void TesteConcluidoEventHandler(string mensagem);` personalizado. Quando o ator encostar na `Area2D` ou o botão for pressionado, atualize o texto do `Label` principal mantendo `"Cyra em teste"` visível junto à confirmação de que entrada, colisão e sinal funcionaram.



5\. \*\*Documentação Inicial da A01 (`README.md` e Templates em `docs/`)\*\*:



\- Crie o `README.md` na raiz contendo:

&#x20;   - Título e descrição curta do escopo de \*Cyra\* e do aviso de assistência de IA com autoria artística humana.

&#x20;   - Versões exatas utilizadas (Godot .NET, .NET SDK, SO de destino).

&#x20;   - Passo a passo claro de como clonar, abrir no Godot Editor, compilar a solução C# (`dotnet build`) e executar a cena `"Cyra em teste"`.

&#x20;   - Procedimento passo a passo de como configurar o Export Template no Godot e gerar o executável desktop fora do editor.



\- Crie o arquivo `docs/Diario\\\_Experimento\\\_IA.md` contendo a tabela de registro metodológico com as colunas exigidas pelo guia: `Data | Atividade/Requisito | Módulo/Script | Ferramenta/Modelo | Prompt/Arquivo | Saída Original (Resumo/Commit) | Intervenção/Revisão Humana | Responsável | Tempo (Aprendizagem Godot vs Geração/Revisão/Correção) | Versão/Commit`. Deixe a primeira linha pré-estruturada para o registro desta própria tarefa A01.



Ao concluir os arquivos da A01, utilize as skills em `.codex/skills/` para preencher automaticamente o registro `D01`, o prompt `P01` e o teste `T00` em `docs/Diario\\\_Experimento\\\_Cyra.md` e `docs/Prompts\\\_Utilizados.md`.

