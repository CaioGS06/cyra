# T05 — Execução A05 de Lucas e conferência P13

**Execução:** 01/11/2026. **Análise documental:** 03/11/2026, IA/Codex, P13. **Executor:** Lucas, conforme envio informado por Caio, perfil e relato recebido. **A05 integrada:** `13c7add`, conferido no Git. Nenhum código ou configuração do produto alterado nesta análise.

## Fontes e preservação

Origem: `docs/evidencias/Cyra_A05_Teste_Feito/a05-test/TestResults/20261101T193728237Z-dd1de6b1`. Sessão interna: `20261101T193733064Z-bfa40d2a`. Execução entre **16:37:32 e 16:41:30 de 01/11/2026**, America/Sao_Paulo (UTC 19:37:32–19:41:30). Coletor: **236,934 s**, sem representar esforço de revisão/correção fora do jogo.

[Sessão bruta](T05_Lucas_20261101T193728237-dd1de6b1/session.jsonl), [resumo recebido](T05_Lucas_20261101T193728237-dd1de6b1/summary.json), [relato de Lucas](T05_Lucas_20261101T193728237-dd1de6b1/relato.txt), [execução](T05_Lucas_20261101T193728237-dd1de6b1/execution.json), [engine](T05_Lucas_20261101T193728237-dd1de6b1/engine.log), [pacote](T05_Lucas_20261101T193728237-dd1de6b1/package.json), [conferência independente](T05_Lucas_20261101T193728237-dd1de6b1/analise_P13.json) e [manifesto das evidências](T05_Lucas_20261101T193728237-dd1de6b1/SHA256.txt).

Os arquivos recebidos foram copiados sem alteração. O pacote completo permanece local, excluído do Git; as evidências selecionadas acima são versionáveis. Nenhum script/executável recebido foi executado para esta análise.

Pacote `5d244af2a99b595feb8e92d8390923839ecd4a1483c2acfdd3cd4b941e8112b5`: identidade recalculada, **193 arquivos** conferidos por tamanho/SHA-256 contra o recebido, todos iguais ao pacote usado por Caio em P12. Inclui ferramentas e guia, além dos arquivos do jogo. Não exige nova compilação ou exportação para analisar esta sessão.

## Máquina e condições

Ryzen 7 8700G w/ Radeon 780M Graphics; o campo GPU da engine informa literalmente **Radeon 7**. Memória física reportada **25.348.083.712 bytes**, diferente dos 32 GB instalados informados na ficha MR02; não foi aferida a razão da diferença nem a frequência efetiva. Windows `10.0.26200`, ficha humana Windows 11, runtime 8.0.28 e Godot 4.7.2. Release, fora do editor e sem headless, Compatibility, janela 960 × 540, VSync Enabled e max_fps 0 (sem limite explícito).

## Esperado, observado e limites

Esperado: executar as 12 etapas do guia com F9, observando movimento/colisão, salto/pouso, ataque, dano/vida, atordoamento, reinício manual e mortes/retornos repetidos. O resultado visual é informado pelo humano; eventos corroboram somente comportamentos instrumentados.

| Item | Observado |
|---|---|
| Relato humano | Lucas informou que concluiu o roteiro sem problemas e não percebeu anomalias de controle/visual. |
| Integridade | Cabeçalho e rodapé únicos, um session_id e tempos crescentes; 235 amostras, zero linhas inválidas, descartes ou parada por limite. Encerramento normal, exit_code 0. Resumo conferido independentemente. |
| Erros/avisos | Nenhum registrado na sessão ou no engine.log recebido; não cobre falhas anteriores ao início do jogo. |
| Movimento/salto | 136 mudanças de movimento, cinco pousos/inicializações da sala, **nenhum A05_jump**, apesar de o evento ser suportado. Não declarar salto executado com base apenas no relato geral. |
| Ataques | Nove ataques, todos à direita; quatro danos do jogador ao inimigo, sem repetição por ataque/alvo no mesmo ciclo. Ataque à esquerda e parede direita complementares não corroborados. |
| Vida/dano | 22 mudanças de vida dentro dos limites e 18 danos recebidos. Intervalo mínimo entre contatos no mesmo ciclo próximo de 0,8 s (0,799606 s); sem dano multiplicado por quadro observado. |
| Atordoamento | Um atordoamento a zero; relato positivo da execução preservado. |
| Reinício/retorno | Um reinício manual, três mortes e três retornos seguros; cinco inicializações da sala. Retornos com vida 5/5, inimigo 3/3, ponto (140,416) e mesma sessão de logs. |
| F9 | **11 marcas sequenciais 1–11**, para roteiro de 12 etapas. Não reconstruir a marca ausente nem associar automaticamente cada marca a uma etapa do guia. |

FPS mediano 60/mínimo 14; memória privada de 253.067.264 para 265.220.096 bytes, diferença de 12.152.832 bytes. Houve uma perda/retomada de foco. Os valores são descritivos de sessão curta, sem comparação com Caio, diagnóstico de vazamento ou aprovação final de RNF04.

## Ocorrência de ambiente e confirmações pendentes

Lucas relatou continuação do problema de não conseguir executar o script sem “desativação da segurança”. Não informou mensagem, comando/configuração alterada, duração ou se a mudança foi revertida. Não presumir que foi política do PowerShell, antivírus ou outra proteção; não registrar essa intervenção como alteração do código do jogo nem como falha resolvida definitivamente. Nenhuma proteção foi alterada pela IA. A sessão recebida demonstra inicialização e encerramento bem-sucedidos depois dessa intervenção relatada.

Foram solicitados em P13:

1. Confirmação do salto e da marca ausente, ou aceitação explícita da cobertura incompleta, considerando a validação anterior de Caio.
2. Se Lucas leu código ou apenas jogou, aceitação dos parâmetros provisórios, eventuais ajustes e tempo humano medido ou não medido.
3. Detalhes da ocorrência de segurança e se a alteração permaneceu ativa. Se desconhecidos, registrar como não informados.

**Situação após a conferência, antes dos esclarecimentos finais abaixo:** coleta A05 verificada também em Lucas; relato funcional positivo, com cobertura parcial documentada. A aprovação de Caio/P12 permanece válida. A execução de Lucas já está registrada e não está mais pendente de envio; leitura de código/aceite de parâmetros/tempo e decisão sobre as lacunas ainda dependem de esclarecimento. Não declarar revisão arquitetural apenas por jogar. Complementos não comprovados permanecem separados dos testes automáticos existentes.

O fechamento documental do T05 será atualizado com as respostas humanas, sem exigir medições retrospectivas nem alterações artificiais de código. Nenhum novo D07, ZIP original regravado, commit ou envio automático ao GitHub nesta análise.

## Encerramento humano — esclarecimentos de Caio/P13

Caio aceitou encerrar com cobertura incompleta do salto em Lucas, pois já o havia validado em P12. A décima segunda marca F9 continua ausente, sem reconstrução. Lucas **apenas testou o executável**; a única validação de código confirmada é a de Caio, sem alterações. Não há aceite específico de parâmetros por Lucas informado; permanece o aceite provisório de Caio. Tempo de Lucas não informado/não medido. Detalhes da alteração de segurança permanecem não informados por decisão de Caio, sem presumir causa ou reversão.

**T05/A05 encerrado no escopo atual, com ressalvas aceitas por Caio**, combinando revisão de código/teste de Caio e teste funcional de Lucas. Não declara roteiro integralmente corroborado nos logs de Lucas, leitura de código por ele, revisão cruzada arquitetural A08 concluída ou desempenho final aprovado. Não há nova execução/correção obrigatória para este fechamento. A ocorrência de ambiente fica registrada para acompanhamento em futuras distribuições; não exige inventar dados para commitar a documentação. Nenhum commit/envio automático.
