# T06 — Conferência de prontidão para revisão humana (P15)

**Data:** 03/11/2026. **Executor:** IA/Codex, no ambiente de Caio. **Base:** 4253d7c; A06 ainda sem commit. Não constitui execução ou aprovação humana.

## Conferências atuais

- Lidos componentes de aquisição/ativa, absorção/usos, apresentação, jogador, reinício e roteiro de 16 etapas. Nenhum bloqueio foi identificado nesta leitura para iniciar a revisão humana; isso não garante ausência de defeitos.
- Compilação repetida: dotnet build Cyra.sln --no-restore, exit 0, zero avisos/erros.
- D07: 51 entradas conferidas contra o ZIP e SHA-256 do ZIP também válido. Arquivos de trabalho correspondentes iguais à saída original antes desta atualização documental.
- Pacote A06: 193 arquivos conferidos por tamanho/SHA-256, sem divergência em relação ao manifesto da execução release registrada. Identidade recalculada: 18ee9a8744ec1d4c2391426696c3f1345163c0c6b02ed9a27caceae083dc7811. Ferramentas/guia do pacote correspondem às fontes atuais.
- Resultados existentes consultados: 57 comportamentos A06 sem falhas e 18 verificações de integração aprovadas; regressões A05/A01 registradas separadamente. Esses ensaios não foram reexecutados em P15. A nova compilação e conferência de integridade não são um novo teste funcional humano.

**Prontidão:** entrega técnica e pacote prontos para revisão humana. RF03 não recebe aprovação humana antecipada; RF04 continua parcial enquanto faltarem sprites/animações humanos e integração visual.

## Como executar

Abrir C:/Users/caio/GIT/cyra/build/a06-test/Executar_Teste.cmd, selecionar 2 para Caio ou 1 para Lucas. Confirmar tela A06, jogador base e nenhuma aquisição. Abrir somente Cyra.exe é modo comum sem a coleta optativa.

Seguir as 16 etapas do guia que acompanha o pacote, com F9 ao final de cada etapa. R reinicia sala/vida/usos e preserva adquiridas/ativa; para partida realmente nova, fechar e iniciar outra execução pelo CMD, gerando outra sessão. A06 ainda não tem save. Mortes devem preservar aquisições/ativa e reiniciar ambos os inimigos sem reiniciar o coletor.

Etapas 12 e 14 têm janelas curtas: se pousar antes de testar uso aéreo ou não conseguir tentar troca durante os 0,20 s de absorção, informar a limitação. Não declarar cobertura manual por ter pressionado F9 ou por uma fixture automática ter passado. Tentativas com J/K e troca também exigem observar se a ação ainda estava em curso.

Após fechar normalmente, preencher o relato.txt da sessão e enviar a pasta inteira, sem transcrever FPS/memória. Se ocorrer bloqueio ao iniciar, registrar a mensagem e não desativar proteções por orientação deste roteiro.

## Preenchimento humano necessário

- Executor/máquina/data e sessão; quem leu código/cenas ou conferiu Inspector, separadamente de quem apenas jogou.
- Resultado por etapa, marcas ausentes/extras, mortes inesperadas e tentativas que não conseguiu conferir.
- Aceite ou ajustes dos parâmetros novos e das propostas operacionais descritas na A06: gravidade durante investida, absorção curta, reabsorção mantendo ativa, R preservando aquisições, prioridades e rejeição sem fila.
- Correções necessárias ou leitura sem alterações; esforço medido ou não medido, sem inferir tempo de revisão pela duração do jogo.
- Decisão sobre RF03/comportamento lógico e sobre aparência técnica; manter RF04 parcial até arte humana, sem confundir cores com sprites finais.

Caio e Lucas podem usar o mesmo pacote, cada um com perfil e sessão próprios. Não atribuir leitura de código a Lucas somente por testar. Capturas de A adquirida, B ativa e antes/depois da morte são úteis, mas não foram produzidas nesta conferência.

[T06](T06_A06_revisao.md) continua com campos/checklists humanos pendentes. Nenhum script/cena/configuração, pacote, guia distribuído ou original D07 foi alterado; somente documentação da conferência. Sem D08 de geração, commit ou envio automático.
