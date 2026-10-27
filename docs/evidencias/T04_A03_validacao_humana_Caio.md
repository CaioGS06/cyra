# T04 — Validação humana de Caio e conferência da sessão

**Relato/revisão:** P08, 27/10/2026. **Executor e revisor:** Caio. As seis etapas com F9 funcionaram, conforme relato; código revisado sem necessidade de alteração. **Tempo da revisão humana: não medido.**

**Sessão do iniciador:** 20261027T191317657Z-1b393526. **Sessão interna do coletor:** 20261027T191318719Z-3a8297b5. **Pacote:** 172238021bea85cd8e57dbc0ba8a998153c6f7e972926c4f2e52e31eef84fb1c. Configuração: i5-12400F/GTX 750/Windows 11, janela 960 × 540, Compatibility, VSync Enabled e max_fps 0 (sem limite explícito). Release, fora do editor e sem headless.

[Arquivos brutos selecionados](T04_Caio_20261027T191317657-1b393526/session.jsonl), [resumo original](T04_Caio_20261027T191317657-1b393526/summary.json), [identidade do pacote](T04_Caio_20261027T191317657-1b393526/package.json), [manifesto](T04_Caio_20261027T191317657-1b393526/SHA256.txt) e [relato confirmado por P08](T04_Caio_20261027T191317657-1b393526/relato_confirmado_P08.md). A pasta original em build não foi alterada.

## Conferência assistida dos registros

| Item | Observado |
|---|---|
| Integridade | Cabeçalho e rodapé únicos; encerramento normal; exit_code 0 e collector_complete true. |
| Marcadores F9 | Seis, em ordem 1–6, aos 15,716; 32,128; 40,927; 47,660; 60,142; 67,424 s da sessão. |
| Eventos da A01 | Cena pronta; botão 2 vezes; primeira entrada; 2 saltos; 3 pousos; gatilho 4 vezes. O primeiro botão precede o primeiro comando de entrada. |
| Telemetria | 68 amostras; zero linhas JSON inválidas e zero registros descartados. |
| Erros/avisos | Nenhum registrado pelo coletor nesta sessão; isso não prova ausência universal de defeitos. |
| Relato humano | Caio confirmou seis etapas funcionando e revisão de código sem alterações. |

Duração automática do coletor: aproximadamente **69,074 s**, das **16:13:18 às 16:14:27 de 27/10/2026**, America/Sao_Paulo. Não é tempo medido de revisão de código ou duração de toda a atividade A03.

## Limites e resultado

Houve **quatro perdas e quatro retomadas de foco**. O resumo bruto registra FPS mediano 60, mínimo agregado 27 e variação de Private Bytes de 5.283.840 bytes entre primeira e última amostra; o primeiro FPS registrado foi 27. Esses dados curtos, com inicialização e mudanças de foco, não constituem benchmark controlado da demo, diagnóstico de vazamento ou aprovação final de RNF04. Não excluir amostras nem atribuir causalidade sem investigação.

**Resultado T04 no escopo entregue:** aprovado para o suporte de coleta A03/A01, combinando verificações técnicas automáticas anteriores, conferência dos logs, execução gráfica e revisão de código confirmadas por Caio. A leitura humana sem alterações não é falta de curadoria. O erro anterior do iniciador permanece no histórico D05/P07 e não foi ocultado.

Permanecem como trabalhos futuros, sem bloquear o commit desta entrega: eventos das mecânicas A05–A07, piloto na máquina principal de Lucas e medições da demo nas condições então registradas. Não foram declarados testes de Lucas/Victor nem resultados de funcionalidades ainda ausentes.
