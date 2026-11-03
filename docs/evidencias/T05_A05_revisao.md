# T05 — Movimento, combate, vida e reinício A05

**Preparado em:** 30/10/2026. **Vínculos:** D06/P10, C-RF01/C-RF02 da A02 e reinício de apoio A05. **Base Git consultada:** `cf5ba4a`; implementação integrada em `13c7add`; análise Lucas/P13 em 03/11/2026. **Curadoria humana:** Caio concluiu em 30/10/P12, sem alterações no código, parâmetros aceitos provisoriamente e 15 min informados. Execução das 12 etapas confirmada por relato; dez marcas F9 observadas, com esquecimento admitido por Caio. Execução de Lucas recebida e analisada em P13: relato positivo, 11 F9, nenhum salto registrado. Esclarecimentos recebidos: cobertura incompleta aceita, código revisado somente por Caio, tempo/segurança de Lucas não informados; [análise Lucas](T05_A05_validacao_Lucas.md). [Evidência de Caio](T05_A05_validacao_humana_Caio.md).

## 1. Estado automático observado — separado da revisão humana

- Compilação zero avisos/erros; importação/carregamento da sala e exportação final Windows concluídos.
- [56 checagens de comportamento](T05_A05_automatico/behavior_results.json), [34 de integração](T05_A05_automatico/integration_checks.json), sem falhas finais. Física real da engine com entrada simulada/fixtures, em execução sem janela na máquina de Caio pela IA.
- A01: [14 verificações de regressão](T05_A05_automatico/a01_regression.log) passaram; não altera o resultado histórico de T00.
- Quatro mortes/retornos na mesma sessão do coletor (três por contato, uma fixture letal), além de reinício manual; sem nós extras ou emissões duplicadas nas verificações. Vida máxima e inimigo restaurados.
- Modo comum sem sessão; falha de escrita simulada não interrompeu o jogo. D05 de máquina explícita/coleta ausente preservado; pacote errado rejeitado.
- Release atual: pacote `faf55c4951e9ab859d8c13badebd21c7aeeeaa3001a797436f3e3274eac0e029`; execuções sem janela com coleta íntegra, Caio/NaoInformada, cenário A05, sem erros/avisos.
- Tentativas/correções da própria IA estão preservadas e descritas em [A05](../A05_Movimento_Combate_Vida.md). Não são intervenção humana. A01/A03 anteriores, inclusive cinco F9/nenhum pulo de Lucas, permanecem intactos.

**Limites da geração automática original:** naquela entrega não havia validação gráfica/humana; Caio a confirmou posteriormente em P12, registrada abaixo; texto da UI lido em teste não comprova legibilidade; fixtures isolam comportamentos, não são uma partida humana completa. Não é benchmark gráfico nem medição final de RNF04. `summary.json` não atribui aprovação automática.

## 2. Roteiro humano e resultado esperado

Usar o [guia A05 de 12 passos](../Guia_Lucas_Testes.md), pacote completo em `build/a05-test`, CMD atual e seleção correta da máquina. Jogar, F9 após cada etapa e relato curto. Se esquecer marca/faltar evento, registrar a lacuna; não preencher com suposição.

Roteiro de revisão em grupos:

1. Início/vida real; andar nos dois sentidos, colidir com paredes e pular/cair/pousar sem salto extra.
2. Ataque fora/dentro do alcance e para ambos os lados; segurar/pressionar repetidamente respeita janela e intervalo; máximo um acerto no alvo por ataque.
3. Receber dano com intervalo; indicador acompanha vida real, sem decidir regras; chegar a zero não deixa vida negativa.
4. Atordoar inimigo e aguardar/encostar/atacar novamente: sem dano, recuperação por tempo, remoção ou absorção.
5. Reinício manual e morte por contato em outro ciclo: ponto seguro, vida máxima e inimigo restaurado; repetir morte e verificar ausência de duplicações/log novo por morte.
6. Conferir legibilidade, proposta provisória e código; registrar se nenhuma correção for necessária. Conferir cenário A05, F9 e coleta, sem exigir ao executor transcrever métricas.

## 3. Checklist humano — revisão de Caio em P12

- [x] Caio: movimento, salto, queda, piso e parede esquerda; 12 etapas relatadas funcionando. Parede direita complementar não confirmada individualmente.
- [x] Caio: funcionamento do ataque no roteiro e código revisados. Log registra ataques à direita; complemento de ataque à esquerda não confirmado individualmente.
- [x] Caio: dano e indicador funcionando no roteiro, conforme relato; logs com vida limitada e contato próximo de 0,8 s.
- [x] Caio: atordoamento funcionando nas etapas relatadas; dois eventos de atordoamento nos logs.
- [x] Caio: duas mortes/retornos confirmados nos logs, com vida máxima e inimigo restaurado.
- [x] Caio: funcionamento visual relatado e parâmetros aceitos por enquanto. Conferência específica do Inspector não informada.
- [x] Coleta de Caio íntegra e contínua nos reinícios, cenário A05; dez F9 para 12 etapas relatadas. Esquecimento de algumas marcas informado, sem inventar as ausentes.
- [x] Caio confirmou leitura do código sem necessidade de alteração; 15 minutos informados para a revisão, sem decomposição.
- [x] Execução A05 de Lucas em 01/11 recebida e conferida em P13: coleta completa, 235 amostras, um atordoamento e três mortes/retornos, zero erros/avisos; relato positivo.
- [x] Caio aceitou as lacunas de Lucas; esclareceu que só ele validou código. Tempo/detalhes de segurança de Lucas não informados; aceite dos parâmetros continua sendo o de Caio.
- [ ] Complementos humanos de parede direita/ataque à esquerda não confirmados individualmente; cobertura automática preservada separadamente.

## 4. Preenchimento após execução/revisão real

| Campo | Registro humano |
|---|---|
| Executor/revisor efetivo, máquina, data e versão/pacote | Caio, 30/10/2026, i5-12400F/GTX 750; sessão 20261030T213551976Z-671326e4, pacote 5d244af2a99b595feb8e92d8390923839ecd4a1483c2acfdd3cd4b941e8112b5; A05 integrada em 13c7add; Lucas em sessão própria descrita no complemento P13. |
| Resultado observado e etapa/F9 ou lacuna | Caio confirma 12 etapas funcionando; 10 F9 reais, com esquecimento relatado. 181 amostras, oito saltos, 15 ataques, dois atordoamentos, três resets manuais e duas mortes/retornos. |
| Achados, decisão, ajustes humanos ou pedidos de correção à IA | Código revisado sem alterações; parâmetros aceitos provisoriamente. Preservar lacuna das marcas e complementos não confirmados, sem correção solicitada. |
| Reteste e evidência, quando necessário | Sessão gráfica e relato P12 preservados com manifesto; nenhuma correção exigiu reteste nesta revisão. |
| Tempo de aprendizagem/revisão/correção, se medido; senão “não medido” | Caio informou 15 min para a revisão relatada, sem decomposição; aprendizagem não aferida separadamente. Duração do coletor 183,714 s não somada. |
| Situação humana do T05 e limitações aceitas explicitamente | Validado por Caio, com lacuna de F9 esclarecida; execução Lucas registrada em P13 com lacunas aceitas por Caio; etapa encerrada com ressalvas. Parede direita/ataque à esquerda/Inspector não confirmados individualmente. |
| Versão integrada/commit após curadoria, quando existir | A05 integrada em 13c7add; base anterior cf5ba4a. Atualização P13 sem novo commit. |

**Resultado Observado humano:** Caio confirmou as 12 etapas funcionando, leitura do código sem alterações e parâmetros adequados por enquanto; 15 min informados. [Logs e análise P12](T05_A05_validacao_humana_Caio.md).

**Situação humana:** validado por Caio com ressalva de rastreabilidade (10 F9 para 12 etapas); execução de Lucas registrada em P13, com relato positivo e cobertura parcial; lacunas aceitas por Caio em P13, encerrando esta etapa no escopo atual. Não é aprovação final da demo/RNF04.

Sugestões de captura, **não produzidas nesta entrega**: vida antes/depois e inimigo atordoado, com versão/executor. Guardar nova sessão inteira (`package.json`, `execution.json`, `session.jsonl`, `summary.json`, `engine.log`, `relato.txt`) sem sobrescrever as tentativas anteriores. Não exigir alteração artificial do código para comprovar revisão.

## 5. Conferência técnica e orientação — P11, 30/10/2026

[Conferência P11](T05_A05_conferencia_P11.md): compilação sem erros/avisos, original D06 e pacote conferidos; ensaio atual de 56 comportamentos repetido sem falhas, em execução automática sem janela. Não altera os campos humanos acima.

Além das 12 etapas, conferir parede direita e ataques pelos dois lados, direção errada e tentativa antes do intervalo. Se necessário, usar R em ciclo complementar e explicar marcas/repetições extras no relato. Não declarar essas ações executadas apenas por completar as 12 marcas. Atravessar o corpo do inimigo é possível nesta implementação; colisão sólida é com o cenário e dano usa área de contato.

Ao concluir, informar executor/data por sessão, responsáveis pela leitura de código/Inspector, observações/ajustes e aceitação ou mudança dos parâmetros provisórios. Tempo não medido é um registro válido. Não é necessário Lucas transcrever FPS/memória ou preencher os números desta ficha; a IA pode organizá-los a partir da pasta recebida. Aprovação e limitações permanecem humanas.

## 6. Execução de Lucas — P13, análise em 03/11/2026

[Análise e fontes de Lucas](T05_A05_validacao_Lucas.md): executou em 01/11, 16:37:32–16:41:30 America/Sao_Paulo. Mesmo pacote de Caio, 193 arquivos conferidos. Coleta completa, 235 amostras, 11 F9, nenhum A05_jump, nove ataques à direita, um atordoamento e três mortes/retornos na mesma sessão; zero erros/avisos/descartes. Relato confirma conclusão sem problemas e nada percebido de anormal. Isso registra o teste de Lucas sem inventar salto/marca ou revisão de código.

Lucas relatou dificuldade de executar script sem desativar segurança, sem detalhar configuração/mensagem/reversão. Perguntas P13 solicitam esclarecimento de cobertura, leitura/aceite/tempo e ocorrência de ambiente. Tempo humano não informado; 236,934 s do coletor não são esforço de revisão. Caio mantém os 15 min originais, sem somar sessões ou atribuir tempo a Lucas. Aguardando respostas, sem reprovar o jogo por ausência de evento ou aprovar automaticamente o roteiro completo. Integração A05: 13c7add.

## Encerramento humano — esclarecimentos de Caio/P13

Caio aceitou encerrar com cobertura incompleta do salto em Lucas, pois já o havia validado em P12. A décima segunda marca F9 continua ausente, sem reconstrução. Lucas **apenas testou o executável**; a única validação de código confirmada é a de Caio, sem alterações. Não há aceite específico de parâmetros por Lucas informado; permanece o aceite provisório de Caio. Tempo de Lucas não informado/não medido. Detalhes da alteração de segurança permanecem não informados por decisão de Caio, sem presumir causa ou reversão.

**T05/A05 encerrado no escopo atual, com ressalvas aceitas por Caio**, combinando revisão de código/teste de Caio e teste funcional de Lucas. Não declara roteiro integralmente corroborado nos logs de Lucas, leitura de código por ele, revisão cruzada arquitetural A08 concluída ou desempenho final aprovado. Não há nova execução/correção obrigatória para este fechamento. A ocorrência de ambiente fica registrada para acompanhamento em futuras distribuições; não exige inventar dados para commitar a documentação. Nenhum commit/envio automático.
