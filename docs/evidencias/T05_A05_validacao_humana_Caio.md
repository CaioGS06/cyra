# T05 — Revisão e execução humanas de Caio (P12)

**Data:** 30/10/2026. **Executor e revisor:** Caio. **Resultado:** revisão de Caio concluída, com funcionamento das 12 etapas confirmado, código revisado sem alterações e parâmetros aceitos provisoriamente. **Tempo humano informado: 15 minutos**, sem decomposição entre leitura/teste/outras parcelas; aprendizagem não aferida separadamente. Não somar automaticamente a duração do jogo. Execução/revisão de Lucas na A05 ainda não informada.

## Identificação e fontes

- Sessão do iniciador: `20261030T213551976Z-671326e4`; sessão interna: `20261030T213554078Z-b07bc009`.
- Execução: 30/10/2026, **18:35:53–18:38:57, America/Sao_Paulo**; duração final do coletor **183,714 s**. Não representa os 15 minutos da revisão.
- Pacote registrado: `5d244af2a99b595feb8e92d8390923839ecd4a1483c2acfdd3cd4b941e8112b5`. Base Git `cf5ba4a`, A05 ainda sem commit integrado.
- [Relato confirmado em P12](T05_Caio_20261030T213551976-671326e4/relato_confirmado_P12.md), [sessão bruta](T05_Caio_20261030T213551976-671326e4/session.jsonl), [resumo recebido](T05_Caio_20261030T213551976-671326e4/summary.json), [execução](T05_Caio_20261030T213551976-671326e4/execution.json), [pacote](T05_Caio_20261030T213551976-671326e4/package.json), [engine](T05_Caio_20261030T213551976-671326e4/engine.log), [conferência independente](T05_Caio_20261030T213551976-671326e4/analise_P12.json) e [manifesto das evidências](T05_Caio_20261030T213551976-671326e4/SHA256.txt).

Arquivos brutos copiados sem alteração. `relato.txt` original continua como formulário; a confirmação humana veio pela conversa e foi preservada separadamente. Não foram recebidas novas capturas de tela.

## Conferência dos logs

| Item | Observado |
|---|---|
| Identificação | Perfil Caio, i5-12400F, GTX 750, Windows 10.0.26200 (ficha humana Windows 11), runtime 8.0.28 e Godot 4.7.2. Release, fora do editor e sem headless; Compatibility, janela 960 × 540, VSync Enabled, max_fps 0. |
| Integridade | Cabeçalho e rodapé únicos, mesmo session_id e tempos crescentes durante reinícios. 181 amostras, zero linhas inválidas/descartes; encerramento normal, exit_code 0. Resumo conferido independentemente. |
| Erros/avisos | Nenhum registrado pelo coletor ou no engine.log desta sessão. |
| Movimento | 156 mudanças de movimento e oito saltos, com pousos. Registros de movimento chegam à parede esquerda; não comprovam teste da parede direita. |
| Ataque | 15 ataques, todos registrados para a direita; seis danos do jogador ao inimigo, sem duplicação de dano por ataque/alvo dentro de cada ciclo. Ataque à esquerda não foi corroborado nesta sessão. |
| Vida e contato | 20 mudanças de vida dentro dos limites, 14 danos recebidos; intervalos de contato no mesmo ciclo próximos de 0,8 s (mínimo observado 0,79953 s). Não há dano multiplicado por quadro nesta execução. |
| Atordoamento | Dois atordoamentos a zero. O relato confirma o comportamento visual esperado; o log não substitui a observação humana. |
| Reinícios | Três reinícios manuais, duas mortes e dois retornos seguros; seis inicializações da sala. Retornos com vida 5/5, inimigo 3/3 e ponto (140,416), na mesma sessão de coleta. |
| F9 | **Dez marcas sequenciais 1–10**, para 12 etapas declaradas concluídas. Caio esclareceu: “Devo ter esquecido de algumas, mas fiz o teste de todas as etapas.” Não reconstruir duas marcas nem associar as dez marcas automaticamente aos números do roteiro. |

Os **193 arquivos do pacote** conferem por tamanho/SHA-256 com a pasta executada e com o conteúdo do pacote automático original. O identificador anterior era `faf55c4951e9ab859d8c13badebd21c7aeeeaa3001a797436f3e3274eac0e029`: a diferença vem da ordem de duas bibliotecas no manifesto, pois o cálculo atual depende da lista ordenada. Ambos os identificadores foram recalculados e preservados; não houve diferença de conteúdo entre esses pacotes. Não inferir mudança de código apenas pela diferença do identificador.

## Decisão humana e limites

**T05: validado por Caio no escopo A05, com ressalva de rastreabilidade dos marcadores.** O relato confirma as 12 etapas; não há necessidade de atribuir aprovação apenas à automação. Código revisado sem necessidade de correção; controles e parâmetros aceitos para esta fase, sem declarar balanceamento definitivo. Nenhuma alteração de código/cena/configuração foi feita nesta atualização.

Os complementos propostos em P11 (parede direita, ataque à esquerda e conferência específica do Inspector) não foram confirmados individualmente por Caio. Permanecem cobertura humana complementar não confirmada; as verificações automáticas desses comportamentos continuam separadas. Não marcar leitura de código como confirmação de todas as ações físicas adicionais.

Houve duas perdas/retomadas de foco, com uma amostra fora de foco. FPS mediano 60/mínimo 18 e memória privada de 172.920.832 para 184.209.408 bytes (máxima 189.210.624) são apenas dados descritivos; não aprovam RNF04 nem demonstram vazamento. Lucas ainda deve ter sua própria execução/revisão A05 registrada; nenhum resultado ou tempo foi atribuído a ele.

P10/D06 e evidências automáticas anteriores preservados, sem regravar ZIP/manifesto original. Atualizados T05, diário/matriz, P12, documento A05 e README. Sem novo registro de geração de código D07, commit ou envio ao GitHub.

**Diferença de configuração local observada:** scripts C#, cenas e ferramentas continuam idênticos ao D06. O `project.godot` de trabalho já apresenta os InputEventKey expandidos com propriedades adicionais (incluindo device=16), mantendo a mesma lista de teclas físicas. Não foi aferida a autoria dessa diferença nem presumida equivalência de todos os metadados; o arquivo foi preservado sem edição nesta atualização. A sessão humana valida o pacote release identificado acima, sem alegar uma nova exportação dessa configuração local.
