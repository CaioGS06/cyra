# Guia curto de testes — Lucas

Coleta A03-v2; roteiro A05/D06, atualizado em 30/10/2026. Referência: Lucas/Ryzen 7 8700G/Radeon 780M/32 GB/Windows 11. O executor joga, marca F9 e relata ocorrências; a aprovação permanece humana. A execução anterior de Lucas/A03 teve cinco F9 e nenhum pulo registrado, aceita por Caio com ressalvas; este roteiro não corrige retroativamente essa lacuna.

## 1. Preparação pelo desenvolvedor/IA

Entregar `build/a05-test` completo (Cyra.exe, Cyra.pck, bibliotecas, `test-package.json`) com CMD/PowerShell/analisador **atuais** de `tools/Testing` e este guia. Depois de exportar, o desenvolvedor executa `tools/Testing/Preparar_Pacote_A05.ps1`, que copia essas ferramentas e identifica o cenário. Não usar os iniciadores antigos recebidos de Lucas.

O iniciador pergunta qual computador está sendo usado: 1 Lucas, 2 Caio, 3 Victor ou 0 não informado. Sem seleção/argumento explícito, não atribui a sessão a Lucas. O responsável também pode informar `-Maquina Caio` ou `-Maquina Victor`. **A05 é o padrão atual.** A opção A01 seleciona a exportação histórica `build/a03-test` ao usar tools; não altera a cena de um executável release. O descritor A05 impede rotular esse pacote como outro cenário. DEMO ainda não é a demo final implementada.

O pacote A05 separado fica em `build/a05-test`, fora do Git e distinto do pacote A03. Não é a demo final. O responsável pode fornecer caminho explícito ao iniciador. A cena A01 continua acessível no editor por F6 e sua exportação anterior não é sobrescrita.

O modo de teste não apaga nem edita saves. Para partida nova, arquivo inválido ou falha de gravação futura, o desenvolvedor/IA prepara uma condição identificada, preservando o save pessoal. Não é tarefa de Lucas improvisar edição de JSON ou permissões. Duplicar a pasta do executável não garante outro save.

## 2. O que Lucas faz

1. Abra `Executar_Teste.cmd` em `build/a05-test` e escolha o computador (1 para Lucas, 2 para Caio ou 3 para Victor). Em tools/Testing, o padrão também é A05. A tela deve identificar **teste A05** e vida inicial **5/5**, inimigo **3/3** na configuração provisória. Se o pacote/cenário estiver errado ou não abrir, informe a mensagem; não precisa configurar ferramentas de desempenho.
2. Siga somente o roteiro disponível. Após cada etapa numerada, pressione **F9 uma vez** com o jogo em primeiro plano. F9 marca o momento/etapa, não aprovação. Informe no relato se esquecer uma marca.
3. Feche o jogo normalmente ao terminar. Se travar/precisar encerrar à força, relate isso; o log parcial ainda pode ajudar.
4. Abra `TestResults/<sessão>/relato.txt`, no local indicado pelo iniciador. Responda: concluiu? algo diferente do esperado? houve interrupção externa? Se nada percebeu, escreva isso.
5. Envie a pasta inteira da sessão para análise. Não precisa transcrever FPS/memória nem calcular médias/preencher tabelas.

Se o Windows impedir o iniciador, informe a mensagem ao responsável; não precisa alterar políticas globais do Windows.

## 3. Roteiro atual — A05 / T05

Controles provisórios: **A/D ou setas** andar, **Espaço** pular, **J** ataque, **R** reiniciar sala. Azul = jogador, laranja = inimigo; faixa amarela = janela/volume de ataque; flash vermelho no jogador = dano. O alvo fica amarelo e identificado ao atordoar. F9 é somente marcador e não inicia ataque/reinício. Não há absorção, pulo duplo ou investida.

Após cada etapa abaixo, pare quando possível e pressione **F9 uma vez**. Se não concluir ou esquecer marca, descreva no relato em vez de inventar aprovação. Poucos minutos bastam; sem séries longas obrigatórias.

| Etapa | Ação | Resultado esperado / momento do F9 |
|---|---|---|
| 1 | Espere o início no piso. | Jogador no ponto seguro; vida 5/5 e inimigo 3/3. F9. |
| 2 | Ande à esquerda até a parede e solte. | A parede impede atravessar. F9. |
| 3 | Ande à direita até perto do ponto seguro e solte, longe do inimigo. | Movimento nos dois sentidos responde. F9. |
| 4 | Pressione Espaço e espere pousar; tente outro pulo ainda no ar. | Apenas um salto por pouso, queda/pouso sobre o piso. F9 após pousar. |
| 5 | Longe do inimigo, pressione/segure J e solte. | Faixa amarela breve à frente; vida do inimigo não cai; segurar não repete ataques. F9. |
| 6 | Aproxime-se até tocar o inimigo e afaste-se. | Vida real e indicador diminuem, com flash; não zera indiscriminadamente em poucos quadros. Pode haver mais de um dano se demorar. F9 afastado. |
| 7 | Aponte para o inimigo e ataque de perto com toques separados em J (cerca de meio segundo entre eles). | Cada ataque acerta no máximo uma vez; três acertos na configuração inicial levam a 0/3 e atordoamento. Se morrer, retome a etapa após o retorno e relate. F9 ao atordoar. |
| 8 | Encoste no atordoado e aguarde alguns segundos. | Ele não ataca, não causa dano nem se recupera. F9. |
| 9 | Ataque novamente o atordoado. | Vida permanece zero, inimigo continua visível; nenhuma absorção. F9. |
| 10 | Pressione R ou clique “Reiniciar sala”. | Volta ao ponto seguro com vida 5/5 e inimigo vivo 3/3. É reinício manual, não morte. F9. |
| 11 | Aproxime-se do inimigo sem atacar e permaneça em contato até morrer. | Danos espaçados, morte e retorno automático ao ponto seguro, vida máxima e inimigo reiniciado. F9 após retornar. |
| 12 | Repita o contato até morrer mais uma vez. | Novo retorno sem duplicar jogador, inimigo ou HUD; coleta continua. F9 e depois feche normalmente. |

O alcance e os tempos são provisórios. Se a faixa amarela não alcançar o alvo, atacar não deve causar dano; virar muda a direção do próximo ataque. A janela em curso mantém a direção capturada no início. Se quiser repetir outro ciclo, R funciona sem editar a cena. Informe no relato a etapa e o comportamento, sem precisar calcular intervalos ou preencher tabelas de desempenho.

Capturas úteis **a produzir durante a revisão humana**, quando ajudarem: vida antes/depois do contato e alvo atordoado com indicador zero. Não há capturas humanas novas produzidas pela IA nesta entrega.

## 4. Roteiro histórico — A01 e coleta

Para regressão A01, o responsável deve abrir a cena A01 no editor/F6 ou selecionar `-Cenario A01` com sua exportação própria. Não usar o roteiro A01 para aprovar A05. As seis etapas históricas permanecem abaixo:

| Etapa / F9 ao concluir | Ação | Conferência visual |
|---|---|---|
| 1 | Espere o retângulo cair e pousar. | Título visível, retângulo sobre o piso. |
| 2 | Clique em “Testar sinal de UI” antes de mover. | Sinal confirmado; entrada pendente até movimento/pulo. |
| 3 | Ande para os dois lados com setas. | Movimento responde e respeita piso. Evite extremidades: A01 não tem reinício automático. |
| 4 | Pule com Espaço e espere pousar. | Pulo e retorno ao piso. |
| 5 | Entre na área verde, saia e entre novamente. | Gatilho confirma; controle continua disponível. |
| 6 | Clique no botão novamente e feche normalmente. | Confirmação responde. F9 antes de fechar. |

Se falhar uma etapa, não a declare aprovada: marque F9 quando possível, informe o número e continue somente se fizer sentido. Poucos minutos bastam para conferir o coletor; não é benchmark final.

## 5. Demo — roteiro previsto, ainda não disponível

O responsável libera as etapas conforme A05–A07 existirem e identifica a versão. Item ausente não é executado.

1. Partida inicial preparada: andar, pular, receber dano e conferir vida.
2. Tentar absorver vivo; depois atordoar e absorver por comando.
3. Com A ativa, usar pulo duplo e superar O1 para S2.
4. Atordoar/absorver B, trocar formas, usar investida e superar O2 para S3.
5. Concluir e voltar S3→S2→S1, conferindo estados mantidos na sessão.
6. Em condição preparada, morrer: conferir checkpoint atual/vida máxima/habilidades e ativa mantidas/mundo reiniciado, e retorno sem ficar preso.
7. Após evento de save normal, fechar e abrir por **nova sessão de teste**. Relacionar pastas no relato; conferir vida/ativa/checkpoint salvos e mundo reiniciado.
8. Casos especiais de save/bloqueios: executar apenas passos preparados, com esperado explícito. Não induzir falha na máquina por conta própria.

F9 ao concluir cada etapa da sessão; relato liga pastas quando houver reabertura. Uma repetição/período extra pode ser solicitado para esclarecer achado, sem quota de séries longas.

## 6. Arquivos e limites da análise

`package.json`: arquivos do pacote; `execution.json`: execução; `session.jsonl`: configuração/eventos/amostras/tempos; `engine.log`: mensagens complementares; `summary.json`: resumo; `relato.txt`: percepção. Reanalisar não apaga relato.

O resumo não aprova testes automaticamente. Evento do código não prova sprite/colisão/experiência corretos. Falta de amostras/eventos/rodapé, limite de tamanho ou registros descartados limita a conclusão. Editor/headless e pacote gráfico são condições diferentes.

Os eventos disponíveis cobrem A01 e a sala A05: movimento, salto/pouso, ataque, dano, vida, atordoamento, morte, retorno seguro e reinício manual. Absorção, habilidades, seções, obstáculos e save continuam futuros. `summary.json` inclui contagens dos eventos realmente presentes, sem aprovar a etapa. Coleta/análise assistidas não eliminam curadoria humana. Tempo de revisão/correção fora do jogo depende de relato medido ou “não medido”.
