# T06 — Validação de Caio e análise da sessão (P16)

Caio jogou em **03/11/2026**, leu o código e visualizou as cenas. Relatou concluir as 16 etapas com o comportamento esperado e sem necessidade de correções. Informou **37 minutos para leitura do roteiro e execução dos testes**. Tempo específico da leitura do código e inspeção de cenas não foi discriminado. Análise documental em 04/11/2026.

Sessão `20261103T153822827Z-bdc7ca26`, interna `20261103T153824197Z-4cc8cdb8`. Execução gráfica release das 12:38:23 às 12:49:38, America/Sao_Paulo, em i5-12400F/GTX 750, Compatibility, 960 × 540, VSync ativo. Coletor durou **674,298 s**, registrados separadamente dos 37 minutos. [Relato](T06_Caio_20261103T153822827-bdc7ca26/relato.txt), [sessão](T06_Caio_20261103T153822827-bdc7ca26/session.jsonl), [resumo](T06_Caio_20261103T153822827-bdc7ca26/summary.json), [pacote](T06_Caio_20261103T153822827-bdc7ca26/package.json), [análise](T06_Caio_20261103T153822827-bdc7ca26/analise_P16.json) e [SHA-256](T06_Caio_20261103T153822827-bdc7ca26/SHA256.txt).

- 16 marcas F9 em ordem, 667 amostras, uma sessão contínua e encerramento normal. Zero erros, avisos, linhas inválidas e descartes. Duas perdas/retomadas de foco registradas, sem interrupção percebida no relato.
- Duas aquisições únicas, uma para A e outra para B. Absorções rejeitadas por distância, alvo vivo e indisponibilidade. Reabsorção de A com B ativa preservou B.
- 38 saltos adicionais e 89 investidas aceitas, 39 no ar. Houve rejeição por uso aéreo gasto, intervalo e ação ocupada. Trocas registram aceitações e rejeições, inclusive por ação ocupada ou habilidade ainda não adquirida.
- Um reinício manual e três mortes com retorno ao ponto seguro, vida 5/5 e ambos os inimigos restaurados. Ativa após os retornos A, B e A, com as aquisições correspondentes preservadas.
- Os 193 arquivos do pacote conferem com o release automático anterior. Os identificadores diferem pela ordem dos arquivos no manifesto. Ambos foram recalculados e o conteúdo por caminho é idêntico.

As marcas indicam momentos do teste. A confirmação das 16 etapas e da revisão do código vem do relato de Caio. As métricas de desempenho permanecem descritivas.

**Decisão atual.** Caio validou o comportamento testado e manteve os parâmetros provisórios. Para discutir com a equipe após a entrega dos sprites, propôs ajustar a duração da absorção conforme os quadros da animação e considerar uma investida que preserve a altura durante a ação e retome a gravidade ao terminar, inspirada em Hollow Knight. Outros ajustes ficam para essa discussão. Essas propostas ficam registradas como futuras, com a implementação atual validada para o roteiro.

**Situação.** Validação funcional de Caio concluída. RF04 permanece parcial, aguardando sprites humanos e integração visual. Execução de Lucas ainda sem relato nesta etapa. A análise atual foi documental e as evidências originais foram copiadas byte a byte.
