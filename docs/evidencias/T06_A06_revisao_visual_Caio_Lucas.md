# T06 — Revisão visual da A06 com sprites de Victor

Caio e Lucas testaram em 16/11/2026 a exportação com a arte da Cyra base, da forma A e do inimigo A, integrada no commit `0eeac22`. Ambos concluíram o roteiro visual de oito etapas com F9. [Análise P19](T06_D08_revisao_visual/analise_P19.json) e [manifesto SHA-256](T06_D08_revisao_visual/SHA256.txt).

| Executor | Janela da execução em São Paulo | F9 / amostras | Relato |
|---|---|---|---|
| Caio | 12:49:17–12:53:45 | 8 / 264 | Concluiu as oito etapas. Percebeu inconsistências nos desenhos, sem apontar problemas de implementação ou de abertura. [Sessão e relato](T06_D08_revisao_visual/Caio_20261116T154917240Z-7cfd08bb/relato.txt) |
| Lucas | 18:27:09–18:28:41 | 0 / 89 | Sessão anterior preservada com o formulário em branco. [Coleta](T06_D08_revisao_visual/Lucas_20261116T212705787Z-a5ab7c25/session.jsonl) |
| Lucas | 18:30:01–18:32:57 | 8 / 172 | Relatou concluir o roteiro e observou que o sprite do capanga parecia cortado na cintura ao andar. Não relatou problema ao iniciar. [Sessão e relato](T06_D08_revisao_visual/Lucas_20261116T213000867Z-09178ec7/relato.txt) |

As três sessões encerraram normalmente, com coleta íntegra, zero erros, avisos ou descartes. Nas duas sessões marcadas, os eventos de atordoamento, aquisição de A, salto extra, aquisição de B, reinício manual e retorno com A ativa aparecem nos trechos esperados do roteiro. A aparência observada vem dos relatos. A sessão marcada de Lucas registra 16 perdas e retomadas de foco. A causa não foi informada. O tempo de revisão humana fora do jogo não foi medido.

Os 193 arquivos de cada pacote conferem por caminho, tamanho e SHA-256 com o release do ensaio automático D08. As sessões humanas registram `cbdffb739507…`, enquanto o ensaio registrou `d0a4c6175046…`. A diferença vem da ordem de duas bibliotecas no manifesto.

## Ocorrência visual em acompanhamento

Lucas descreveu um aparente corte na cintura do capanga durante a caminhada. O relato não identifica quadro, direção ou imagem da ocorrência. A folha de caminhada do inimigo A tem três células ocupadas de 500 × 500, e as três regiões do atlas correspondem a essas células. Essa inspeção confirma o recorte configurado e deixa em aberto a origem do sintoma em jogo.

O registro da revisão pode ser commitado com a ocorrência aberta. Para investigar a aparência, basta uma captura ou um vídeo curto da patrulha. Com esse trecho, Victor pode conferir os quadros do desenho e Caio pode confrontá-los com a reprodução no jogo. A execução visual de Victor ainda não foi informada. RF04 segue parcial enquanto faltar a arte da forma B e do inimigo B.
