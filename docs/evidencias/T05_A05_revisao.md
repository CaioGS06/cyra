# T05 — Movimento, combate, vida e reinício A05

**Preparado em:** 30/10/2026. **Vínculos:** D06/P10, C-RF01/C-RF02 da A02 e reinício de apoio A05. **Base Git consultada:** `cf5ba4a`; implementação ainda sem commit. **Curadoria humana:** Caio concluiu em 30/10/P12, sem alterações no código, parâmetros aceitos provisoriamente e 15 min informados. Execução das 12 etapas confirmada por relato; dez marcas F9 observadas, com esquecimento admitido por Caio. Lucas ainda não tem execução/revisão A05 informada. [Evidência de Caio](T05_A05_validacao_humana_Caio.md).

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
- [ ] Execução/revisão A05 de Lucas ainda não informada; não atribuída a ele.
- [ ] Complementos humanos de parede direita/ataque à esquerda não confirmados individualmente; cobertura automática preservada separadamente.

## 4. Preenchimento após execução/revisão real

| Campo | Registro humano |
|---|---|
| Executor/revisor efetivo, máquina, data e versão/pacote | Caio, 30/10/2026, i5-12400F/GTX 750; sessão 20261030T213551976Z-671326e4, pacote 5d244af2a99b595feb8e92d8390923839ecd4a1483c2acfdd3cd4b941e8112b5; A05 sem commit. |
| Resultado observado e etapa/F9 ou lacuna | Caio confirma 12 etapas funcionando; 10 F9 reais, com esquecimento relatado. 181 amostras, oito saltos, 15 ataques, dois atordoamentos, três resets manuais e duas mortes/retornos. |
| Achados, decisão, ajustes humanos ou pedidos de correção à IA | Código revisado sem alterações; parâmetros aceitos provisoriamente. Preservar lacuna das marcas e complementos não confirmados, sem correção solicitada. |
| Reteste e evidência, quando necessário | Sessão gráfica e relato P12 preservados com manifesto; nenhuma correção exigiu reteste nesta revisão. |
| Tempo de aprendizagem/revisão/correção, se medido; senão “não medido” | Caio informou 15 min para a revisão relatada, sem decomposição; aprendizagem não aferida separadamente. Duração do coletor 183,714 s não somada. |
| Situação humana do T05 e limitações aceitas explicitamente | Validado por Caio, com lacuna de F9 esclarecida; Lucas pendente. Parede direita/ataque à esquerda/Inspector não confirmados individualmente. |
| Versão integrada/commit após curadoria, quando existir | Ainda sem commit A05; base cf5ba4a. |

**Resultado Observado humano:** Caio confirmou as 12 etapas funcionando, leitura do código sem alterações e parâmetros adequados por enquanto; 15 min informados. [Logs e análise P12](T05_A05_validacao_humana_Caio.md).

**Situação humana:** validado por Caio com ressalva de rastreabilidade (10 F9 para 12 etapas); aguardando execução/revisão A05 de Lucas. Não é aprovação final da demo/RNF04.

Sugestões de captura, **não produzidas nesta entrega**: vida antes/depois e inimigo atordoado, com versão/executor. Guardar nova sessão inteira (`package.json`, `execution.json`, `session.jsonl`, `summary.json`, `engine.log`, `relato.txt`) sem sobrescrever as tentativas anteriores. Não exigir alteração artificial do código para comprovar revisão.

## 5. Conferência técnica e orientação — P11, 30/10/2026

[Conferência P11](T05_A05_conferencia_P11.md): compilação sem erros/avisos, original D06 e pacote conferidos; ensaio atual de 56 comportamentos repetido sem falhas, em execução automática sem janela. Não altera os campos humanos acima.

Além das 12 etapas, conferir parede direita e ataques pelos dois lados, direção errada e tentativa antes do intervalo. Se necessário, usar R em ciclo complementar e explicar marcas/repetições extras no relato. Não declarar essas ações executadas apenas por completar as 12 marcas. Atravessar o corpo do inimigo é possível nesta implementação; colisão sólida é com o cenário e dano usa área de contato.

Ao concluir, informar executor/data por sessão, responsáveis pela leitura de código/Inspector, observações/ajustes e aceitação ou mudança dos parâmetros provisórios. Tempo não medido é um registro válido. Não é necessário Lucas transcrever FPS/memória ou preencher os números desta ficha; a IA pode organizá-los a partir da pasta recebida. Aprovação e limitações permanecem humanas.
