# Entrega dos sprites de Cyra para integração no Godot

Victor, use os desenhos já prontos e entregue por conjunto à medida que fechar cada parte. Para a primeira conferência, mande uma pose de cada forma de Cyra e de cada inimigo. Isso permite verificar escala, alinhamento dos pés e leitura das silhuetas antes de cortar todas as animações.

## Arquivos para importar

- Exporte em **PNG com transparência**, no tamanho original do pixel art, sem redimensionar com suavização. Mantenha os arquivos editáveis da ferramenta em uma pasta separada.
- Use uma folha por animação com quadros de tamanho fixo e grade regular. Quadros individuais numerados, como `walk_00.png` e `walk_01.png`, também funcionam. Para folhas existentes com margem ou espaçamento, informe as medidas no inventário.
- Mantenha o mesmo quadro e a mesma posição dos pés nas três formas de Cyra. Informe o ponto de alinhamento em pixels contado do canto superior esquerdo. Use os tamanhos já produzidos como ponto de partida e indique as exceções. A integração pode ajustar o deslocamento visual em relação ao corpo físico.
- Indique a direção desenhada e se pode espelhar. Se uma animação depende do lado da arma, de um detalhe assimétrico ou de texto, avise antes de espelhar.
- Indique ordem e quantidade dos quadros, FPS ou duração pretendida, se repete e eventuais pausas por quadro. Marque os quadros que correspondem ao golpe, à absorção ou ao começo/fim da investida, se já houver essa intenção artística. O encaixe com os tempos da mecânica será decidido na integração.

O Godot aceita folhas ou imagens individuais no recurso `SpriteFrames` de `AnimatedSprite2D`. A integração ajustará a grade, as durações e o filtro Nearest do projeto. [Animação de sprites 2D no Godot](https://docs.godotengine.org/en/stable/tutorials/2d/2d_sprite_animation.html)

## Organização sugerida

```text
entrega_victor/
  sprites/
    cyra_base/
      idle.png
      walk.png
      jump.png
      fall.png
      attack.png
    cyra_a/
      idle.png
      double_jump.png
      ...
    cyra_b/
      idle.png
      dash.png
      ...
    inimigo_a/
      walk.png
      stunned.png
    inimigo_b/
      walk.png
      stunned.png
  tilesets/
  editaveis/
  inventario.md
```

Use nomes minúsculos, sem espaços ou acentos. Para cada animação reaproveitada, escreva no inventário qual PNG deve ser usado. Assim é possível montar os estados sem duplicar arquivos. O integrador colocará os PNGs em `Assets/Sprites` e `Assets/TileSets` conforme o conjunto.

| Campo do inventário | Exemplo de preenchimento |
|---|---|
| Arquivo e estado | `sprites/cyra_b/dash.png`, investida da forma B |
| Grade e ordem | Quadro 64 × 64, duas colunas, uma linha, ler da esquerda para a direita |
| Alinhamento e direção | Pés em (32, 56), personagem voltado à direita, pode espelhar |
| Reprodução | 2 quadros a 12 FPS, uma vez |
| Origem | Autor, ferramenta, data e caminho do fonte editável |
| Estado da entrega | Pronto, provisório, reaproveitado de outro arquivo ou pendente |

Os valores da tabela são exemplos. Registre as medidas e os tempos reais da arte já feita.

## Conferência antes de enviar

Confira se os três conjuntos de Cyra distinguem base, pulo duplo e investida e se a aparência permanece coerente em movimento, salto, queda e ataque. Os inimigos A/B precisam de patrulha e pose de atordoamento. Liste a animação de absorção e as ações especiais que já estiverem prontas, com indicação de reaproveitamento onde fizer sentido.

Para o cenário, mande a folha com o tamanho das peças, margens e indicação das peças de piso, parede e cantos. Identifique a barreira intacta da investida e quadros de quebra, se existirem. Mantenha a referência do fundo separada da folha de colisões.

Envie um ZIP com PNGs, fontes editáveis e inventário. Na integração, o primeiro teste será alternar base/A/B no Godot, conferir os pés e a direção, testar salto, investida e ataque e verificar patrulha/atordoamento dos dois inimigos.
