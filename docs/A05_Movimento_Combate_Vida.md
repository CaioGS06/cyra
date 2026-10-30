# A05 — Movimento, combate e vida

**Proposta inicial registrada em 30/10/2026, antes da implementação dos valores.** D06/P10/T05. Configuração provisória para teste, aceita por Caio em P12/30/10; sem balanceamento definitivo. Base consultada: `cf5ba4a`; A02 `f145393`, suporte A03 `e0aaeed`, confirmados no Git.

| Ação/parâmetro | Proposta provisória |
|---|---|
| Andar | A/D ou setas esquerda/direita; 220 px/s |
| Pular | Espaço; velocidade inicial vertical −380 px/s; somente no piso |
| Ataque | J; dano 1; janela 0,16 s; intervalo entre inícios 0,45 s |
| Alcance | Área retangular 48 × 44 px, centro a 40 px na direção capturada ao começar o ataque |
| Vida | Jogador 5; inimigo 3; estado em componente independente da UI |
| Dano por contato | 1; proteção do jogador por 0,8 s após dano aceito |
| Inimigo | Patrulha 55 px/s, até 70 px de cada lado da origem; piso/parede detectados pela engine |
| Reiniciar sala | R ou botão; apoio de teste, sem simular morte nem criar save |
| Marcador do coletor | F9, preservado e sem conflito com ações do jogador |

**Entrega implementada e verificada automaticamente; revisão de Caio concluída em P12, sem alterações e com parâmetros aceitos provisoriamente. Lucas ainda sem execução/revisão A05 informada.** Nenhum recurso artístico, absorção, habilidade, seção, bloqueio por habilidade ou persistência foi produzido. As paredes são somente colisões de cenário para RF01. Cronograma e decisões humanas A02/A03 foram preservados, inclusive a ressalva da execução de Lucas (cinco F9, nenhum pulo registrado).

## 1. Componentes e sinais

| Arquivo | Responsabilidade / contrato |
|---|---|
| [Health.cs](../Scripts/Core/Health.cs) | Vida reutilizável em jogador/inimigo, máxima mínima 1, atual entre zero e máximo; rejeita dano não positivo e dano após zero, evita overflow. `Changed(previous,current,maximum)` atualiza observadores; `Depleted()` ocorre somente na passagem de positivo para zero. Alterar máximo pelo Inspector não cura automaticamente. |
| [PlayerController.cs](../Scripts/Player/PlayerController.cs), [Player.tscn](../Scenes/Entities/Player.tscn) | `CharacterBody2D`, gravidade/MoveAndSlide, ações próprias e pulo no piso. Ataque usa volume editável de `Area2D/CollisionShape2D` e consulta física nativa imediata `IntersectShape`, com conjunto de alvos por janela. `AttackStarted(id,direction)` e `Died()`. Proteção de dano fica no jogador, não na UI. |
| [BasicEnemy.cs](../Scripts/Enemies/BasicEnemy.cs), [BasicEnemy.tscn](../Scenes/Entities/BasicEnemy.tscn) | Patrulha local, retorno por alcance, parede e `RayCast2D` antes da borda. Contato por Area2D chama o recebimento de dano do jogador. A zero, emite `Stunned()`, desliga ofensiva e permanece visível sem prazo; gravidade ainda permite repousar no piso. Não absorve, concede habilidade nem remove o alvo. |
| [HealthIndicator.cs](../Scripts/Test/HealthIndicator.cs) | Label técnico passivo; lê o estado inicial real e acompanha `Changed`. Não causa dano, modifica vida ou decide morte. Indicadores separados do jogador e inimigo. |
| [A05RoomController.cs](../Scripts/Test/A05RoomController.cs), [TestRoomA05.tscn](../Scenes/Test/TestRoomA05.tscn) | Uma sala com piso, duas paredes e ponto `a05_safe` em (140,416). Conecta `Died` e botão/R uma vez. Recarrega a cena de modo adiado, desconecta referências antigas e restaura vida/inimigo por novas instâncias. Contador técnico de ciclo em memória, sem save. |
| [TestRunRecorder.cs](../Scripts/Core/TestRunRecorder.cs) | Mesmo autoload A03, mesma sessão/arquivo e contador F9 durante mortes/reinícios. Somente a lista de eventos disponíveis/default de cenário sem rótulo presumido foi adaptada; permanecem limites/fila/falha de escrita. |

O movimento permanece disponível durante o ataque. A direção da janela é capturada no início, mesmo se o jogador virar em seguida; a próxima janela usa a nova direção. Segurar J não cria autoataque. Apertar antes do intervalo é ignorado, sem enfileirar ataques. O intervalo é limitado a pelo menos a duração da janela; valores inválidos de velocidade/duração/dano são limitados na inicialização. O Inspector permite ajustar os valores provisórios sem ampliar as mecânicas.

`Depleted` do jogador encerra velocidade, ataque e visual antes de notificar a sala. Reiniciar recarrega somente a cena atual; o autoload não sai da árvore. **R/botão é reinício manual, distinto de morte**, útil para recuperar uma condição de teste depois de atordoar o único inimigo. A morte real também pode ser repetida deixando o inimigo vivo aplicar contato. Não há infraestrutura antecipada para preservar habilidades: elas ainda não existem e essa integração pertence à A06/A07.

Os visuais são ColorRect/Label: jogador azul, faixa amarela durante a janela de ataque, flash vermelho ao receber dano, inimigo laranja e amarelo ao atordoar. São indicações técnicas, sem sprites, áudio ou narrativa final.

## 2. Camadas e máscaras

Valores são bitmasks do Godot, não números de requisito.

| Elemento | Camada / máscara | Efeito |
|---|---|---|
| Piso e paredes | Camada 1 (bit 0), máscara 0 | Cenário sólido para a física dos atores. |
| Corpo do jogador | Camada 2 (bit 1), máscara 1 | Colide com cenário; contato com inimigo não vira parede física. |
| Corpo do inimigo | Camada 4 (bit 2), máscara 1 | Colide com cenário; continua detectável pelo ataque quando atordoado, mas vida rejeita novo dano. |
| AttackArea/consulta | Camada 0, máscara 4, corpos somente | Volume 48×44, deslocamento ±40; consulta nativa imediata evita cache antigo ao virar. Não atinge piso, jogador ou UI. Monitoring fica desligado porque a consulta usa a forma e a transformação. |
| ContactArea do inimigo | Camada 0, máscara 2 | Detecta o jogador; dano é limitado por `HurtInterval`. Monitoring é desligado ao atordoar, com guarda lógica imediata no inimigo. |
| FloorAhead | Máscara 1 | RayCast2D em frente aos pés; retorna antes da borda, além do limite local da patrulha. |

## 3. Coleta e pacote

Reutiliza A03-v2/JSONL; nenhum coletor paralelo. Eventos disponíveis A05: `room_ready`, `movement`, `jump`, `landing`, `attack`, `damage_applied`, `damage_received`, `health_changed`, `stunned`, `death`, `safe_return`, `room_reset`, todos com prefixo `A05_`. Eventos A01 permanecem disponíveis. A lista do cabeçalho descreve suporte, não prova que todos ocorreram numa sessão.

Movimento registra apenas início/parada/troca de direção real, inclusive parar na parede; não todo quadro. Ataque tem ID por instância, e `room_ready.cycle` separa reinícios. Dano registra solicitado, diferença real e vida anterior/posterior; IDs e posições são valores simples, não nós serializados. Os eventos não aprovam gráficos/controle humano. F9 continua `human_step_marker`; no ensaio automatizado a única marca foi simulada, não humana.

O cenário é passado como A05 pelo iniciador; chamada bruta sem esse argumento não presume A01. `summary.json` conta eventos efetivamente presentes, mantém `automatic_test_verdict = not_assigned`, distingue headless e telemetria ausente. D05 permanece: máquina explícita/pergunta no CMD, NaoInformada quando omitida e aviso se faltar coleta. O pacote A05 exige descritor compatível; não troca cena com `--scene`, opção indisponível nos templates release oficiais.

**Exportação:** preset `A05 Windows Desktop`, pasta `build/a05-test/`, separado de `build/a03-test` e evidências históricas. `Preparar_Pacote_A05.ps1` copia três ferramentas atuais e o guia, e grava `test-package.json` com cenário/base de código, sem inventar commit integrado. O iniciador aplica o mecanismo SHA-256 existente também a `.ps1`, `.cmd` e `.md` para identificar ferramentas/guia além de EXE/PCK/DLL/JSON; exclui TestResults. Logs de sessões novas não mudam o identificador do pacote.

Pacote verificado nesta entrega: `faf55c4951e9ab859d8c13badebd21c7aeeeaa3001a797436f3e3274eac0e029`. Os manifestos por arquivo estão nas evidências de release. Isso identifica a exportação testada, não um commit humano. Modificação posterior de ferramenta/guia/dados gera novo identificador na próxima sessão.

Modo comum: abrir Cyra.exe, sem arquivos de sessão do coletor; a engine pode manter seus logs normais. Modo teste: abrir **build/a05-test/Executar_Teste.cmd**, escolher máquina, seguir o [guia A05](Guia_Lucas_Testes.md), marcar F9 e preencher relato curto. Enviar a pasta da sessão completa; nenhuma necessidade de transcrever FPS ou preencher grandes tabelas por Lucas.

## 4. Verificações executadas pela IA em 30/10/2026

Ensaios locais na máquina de Caio, **sem janela**, com entrada simulada e posicionamentos de fixtures explicitamente identificados. Sem execução humana, sem benchmark gráfico ou medição da demo final.

| Verificação | Resultado observado / evidência |
|---|---|
| Compilação e importação | `dotnet build Cyra.sln`: zero avisos/erros; importação e execução principal A05 sem erro. |
| Comportamentos | **56 checagens aprovadas, zero falhas** na versão final: [resultado](evidencias/T05_A05_automatico/behavior_results.json) e [log](evidencias/T05_A05_automatico/behavior_engine.log). Incluem Input Map, gravidade, piso/duas paredes, pulo sem salto extra, patrulha em borda/parede, alcance/direção, ataque único, segurar/repetir, vida/overflow/zero, UI por sinais, atordoamento, contato espaçado e reinícios. |
| Ciclos e coleta | **34 checagens de integração aprovadas**: [relatório](evidencias/T05_A05_automatico/integration_checks.json). Uma sessão/ID/cabeçalho/rodapé, quatro mortes/retornos (três por contato e uma fixture letal), um reinício manual, seis salas prontas, sem nós extras/duplicação de callbacks, perdas/erros ou limite de log na sessão final. |
| A01 compartilhada | 14 checagens de regressão passaram: [log novo](evidencias/T05_A05_automatico/a01_regression.log). Cena/scripts A01 não alterados; T00 e evidências antigas preservados. |
| Modos e falhas | Modo comum não criou pasta de coleta. Caminho de saída propositalmente inválido gerou aviso de IOException e jogo encerrou normalmente. Coleta ausente continuou indisponível, com FPS nulo; cenário divergente/A05 sem descritor rejeitados. Fixtures não são falhas reais da partida. |
| Release separado | Exportação final com `--quit`: exit 0. Pacote iniciou/encerrou pelo iniciador atual com máquina Caio e NaoInformada, cabeçalho/fim/amostras/sala A05, sem erros/avisos e sem atribuir veredicto automático. [Resumo Caio](evidencias/T05_A05_automatico/release_Caio/summary.json), [sem máquina](evidencias/T05_A05_automatico/release_NaoInformada/summary.json). |

O teste permanente [VerifyA05.gd](../tools/Testing/VerifyA05.gd) é apenas harness de física/entrada simulada, não controlador de jogo, coletor ou recurso da cena exportada. Algumas checagens congelam patrulha/reposicionam corpos para isolar alcance; outras usam contato e morte reais da física. Os testes leem o texto da UI, não validam sua legibilidade em pixels. Os dados de FPS/memória dos ensaios headless não aprovam RNF04.

### Correções da própria IA durante a geração

A primeira tentativa marcou 35 checagens positivas e 18 falhas: dois códigos de setas estavam incorretos no Input Map; o harness lia `IsOnWall` depois de soltar a direção e simulava reinício só com estado de ação, sem evento de input, causando falhas em cascata nas etapas seguintes. A IA corrigiu os códigos conforme os enums da engine e o harness para observar colisão enquanto pressionado e enviar evento R real. Reteste intermediário: 53/0. Depois, acrescentou atualização da UI ao mudar máximo, valores reais de dano aplicado e duas fixtures de patrulha; versão final: 56/0. [Primeiro resultado preservado](evidencias/T05_A05_automatico/attempt01_results.json), [intermediário](evidencias/T05_A05_automatico/attempt02_results.json).

A primeira partida release falhou porque o iniciador usava `--scene`, não aceito pelo template; a proteção D05 apontou coleta ausente, sem aprovação falsa. A IA removeu essa opção e conferiu cenário por descritor/exportação correta. [Tentativa preservada](evidencias/T05_A05_automatico/release_attempt01/engine.log). O primeiro wrapper de exportação permaneceu aguardando após empacotar e foi interrompido; a exportação final com `--quit` terminou com exit 0. Nenhuma dessas correções é atribuída à equipe como curadoria humana.

## 5. Curadoria e preservação

T05 cobre C-RF01/C-RF02 e o reinício de apoio da A05; não substitui T00/T01/T02/T04 e não reutiliza T03 histórico. [Ficha humana atualizada](evidencias/T05_A05_revisao.md): Caio confirmou as 12 etapas e leitura do código em P12 (15 min informados), com dez F9 observados e esquecimento de marcas esclarecido. [Sessão e análise](evidencias/T05_A05_validacao_humana_Caio.md). Lucas pendente. O roteiro orienta conferir movimento, alcance/direção/repetição, vida real/indicador, atordoamento, morte/reinício, legibilidade/parâmetros, coleta/F9 e leitura do código, com ou sem correção.

Capturas úteis **a produzir**, sem alegar existência: `docs/evidencias/T05_A05_vida_antes.png`, `T05_A05_vida_depois.png` e `T05_A05_atordoado.png`, identificadas por versão/executor. Revisão de Caio: 15 min informados, código sem alterações, 12 etapas funcionando; Lucas/tempo de aprendizagem separado ainda não informados. Capturas novas não fornecidas. Geração/edição IA não medidas como esforço humano. Duração automática da sessão não é esforço de revisão.

[P10 integral](prompts/P10_A05_implementacao.md), D06 no [diário principal](Diario_Experimento_Cyra.md), [original D06](saidas_originais/D06_A05.zip) e [manifesto SHA-256](saidas_originais/D06_SHA256.txt) preservam a saída antes da futura curadoria. Nenhum ZIP/prompt/evidência/tempo anterior foi regravado. Não foi feito commit nem envio ao GitHub. A revisão humana de Caio foi preenchida em P12; preservar a distinção da revisão/execução ainda não informada de Lucas e das coberturas complementares não confirmadas, sem antecipar A06/A07 ou afirmar aprovação de RF01/RF02 por testes automáticos apenas.
