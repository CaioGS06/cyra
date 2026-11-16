# Sprites de Victor na sala A06

Entrega parcial de autoria humana atribuída a Victor por Caio. Integração P18/D08 em 16/11/2026. A sala iniciada por F5 continua sendo `Scenes/Test/TestRoomA06.tscn`. O pacote `build/a06-sprites-test` é uma exportação da mesma sala para conferir a arte após o T06 funcional.

Os 11 arquivos recebidos são PNG RGBA. As folhas têm células de 500 × 500 pixels, com uma ou duas colunas e duas ou três linhas. As cópias usadas em jogo são idênticas aos PNGs recebidos. Os recursos SpriteFrames selecionam as células ocupadas da esquerda para a direita e de cima para baixo. O Godot aplica filtro Nearest, escala visual de 0,1 e deslocamento vertical de −1 px ao mostrar a folha. Os arquivos recebidos ficam em `Assets/_SpritesVictor`, com `.gdignore` para evitar uma segunda importação. Ferramenta original, autoria por arquivo, tempos de animação pretendidos e arquivos editáveis ainda podem ser confirmados com Victor.

| Estado nesta versão | Arquivo de Victor | Destino sob `Assets/Sprites` | Quadros e velocidade de teste |
|---|---|---|---|
| Cyra base parada | CYRA-NEWTRY.png | cyra_base/idle.png | 3 a 5 FPS, repetição |
| Cyra base andando | cyra-walking.png | cyra_base/walk.png | 4 a 8 FPS, repetição |
| Cyra base subindo | CYRA-jump.png | cyra_base/jump.png | 2 a 8 FPS |
| Cyra base caindo | CYRA-fall(1).png | cyra_base/fall.png | 2 a 8 FPS |
| Cyra base absorvendo | cyra-absorb.png | cyra_base/absorb.png | 4 a 20 FPS, correspondentes a 0,20 s |
| Forma A parada | cyradjsprite.png | cyra_a/idle.png | 3 a 5 FPS, repetição |
| Forma A andando | cyradjsprite-testwalking.png | cyra_a/walk.png | 4 a 8 FPS, repetição |
| Forma A em salto, salto extra ou queda | djsprite-cyra-jump.png | cyra_a/jump.png | 3 a 8 FPS |
| Inimigo A em patrulha | djsprite1-2.png | inimigo_a/walk.png | 3 a 6 FPS, repetição |
| Inimigo A a zero de vida | djsprite-damaged.png | inimigo_a/damaged.png | Última célula ocupada, pose estática provisória |
| Salto do inimigo A | djsprite-jump.png | Arquivo recebido preservado | A patrulha atual anda pelo chão |

A associação das folhas à forma e ao estado segue os nomes e a aparência. A ordem, os FPS, o alinhamento e a pose de atordoamento são escolhas de integração para confirmar com Victor. A forma A reaproveita o salto na queda e a locomoção na absorção. O ataque ainda usa a área amarela de diagnóstico. A forma B e o inimigo B aparecem com retângulos provisórios.

## Conferência no jogo

1. Use F5 no Godot ou abra a exportação Windows em `build/a06-sprites-test`. Para abrir com coleta, use os passos da [seção A06 com sprites no guia de testes](Guia_Lucas_Testes.md).
2. Na base, ande para os dois lados, pule e caia. Confira direção, pés e transições. Depois ataque A em toques espaçados com J e veja a pose quando a vida chega a zero.
3. Use E perto de A atordoado. Confira a absorção da base e a troca para a forma A. Ande, pule e dê o salto extra.
4. Absorva B, alterne 1 e 2 e reinicie com R. Confira a aparência correspondente à forma ativa antes e depois da volta ao ponto seguro.
5. Relate cortes, pés desalinhados, orientação, ritmo e pose de atordoamento. Vincule a observação ao pacote com sprites.

O [teste funcional de Lucas em T06](evidencias/T06_A06_validacao_Lucas.md) corresponde ao pacote anterior sem arte. A integração visual parcial tem registro próprio em D08 e aguarda revisão humana. RF04 segue parcial enquanto faltar a arte B e a conferência visual.

## Verificações automáticas de 16/11

A compilação passou com zero erros e avisos. O Godot importou os dez PNGs de jogo com compressão sem perdas e exportou a cena A06 com os três recursos SpriteFrames. O ensaio sem janela passou 67 verificações, incluindo a regressão A06 e dez verificações adicionais de sprites. A exportação também abriu pelo iniciador e completou a coleta sem erros ou avisos. O primeiro ensaio de importação restrito encontrou erro de acesso à configuração local do editor. A importação com acesso à configuração concluiu. [Comportamento e estados](evidencias/T06_A06_sprites_automatico/behavior_results.json) e [coleta da exportação](evidencias/T06_A06_sprites_automatico/summary.json).

A avaliação em janela do alinhamento, direção, ritmo e pose provisória de atordoamento cabe à próxima revisão de Caio, Lucas e Victor. As verificações automáticas foram feitas no ambiente de Caio.
