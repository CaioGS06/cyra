# T04 — Sessões iniciais sem coleta e correção do iniciador

Em 27/10/2026, Caio relatou abertura pelo CMD em tools/Testing e teste sem problemas lógicos/gráficos. A inspeção encontrou duas sessões em build/windows: ambas executaram a cena antiga, sem session.jsonl/amostras/marcadores. Não foram aprovadas como coleta automática. O rótulo Lucas era o padrão indevido do iniciador, não identificação do executor; o relato é de Caio e o engine.log mostra GTX 750. Os arquivos brutos não foram reescritos.

| Sessão original | Resultado preservado |
|---|---|
| 20261027T185433341Z-b494a1e5 | exit_code 0; collector_complete false; zero amostras/F9; machine_label Lucas incorreto; pacote 5ddd3da995a42ba3f9ba5f4e2d91e1a5a79202c88b1f0caac4f2ddd58a9f4b6d. |
| 20261027T185757356Z-d013da9c | exit_code 0; collector_complete false; zero amostras/F9; machine_label Lucas incorreto; pacote 5ddd3da995a42ba3f9ba5f4e2d91e1a5a79202c88b1f0caac4f2ddd58a9f4b6d. |

## Correção e reteste

D05/P07: destino padrão em tools/Testing passa a build/a03-test, ou executável ao lado quando distribuído. CMD pergunta o computador; chamada direta sem perfil registra NaoInformada. Analisador sinaliza ausência de session.jsonl/início como telemetria indisponível, sem confundir partida normal com coleta válida.

Reteste automático sem janela pelo caminho padrão, em build/a03-test/TestResults/20261027T190814598Z-36a7630f: collector_complete true, máquina Caio, amostras presentes e exit_code 0. Não é teste gráfico humano nem benchmark.

Encaminhamento na fase P07: repetir as seis etapas/F9 e confirmar revisão de código. **Concluído em P08:** Caio confirmou ambas, sem alterações e tempo não medido; logs da nova sessão foram conferidos. Não é necessário esperar piloto da demo ou uso das máquinas complementares para commitar esta etapa após essa curadoria.

Reteste adicional: Windows PowerShell do CMD com escolha 2, execução sem janela em build/a03-test/TestResults/20261027T191051613Z-d614559d; perfil Caio e coleta completa. Analisador em cópia sem telemetria retornou unavailable_missing_telemetry. [Registro do reteste](T04_A03_reteste_D05.json).

**Encerramento:** [P08 — validação humana de Caio](T04_A03_validacao_humana_Caio.md) conclui revisão/execução do coletor corrigido, preservando as duas tentativas iniciais sem telemetria.
