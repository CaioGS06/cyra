# T04 — Verificação técnica do suporte de coleta A03

**Data:** 27/10/2026. **Pedido:** P06. **Saída:** D04. T02 é a revisão documental; T03 permanece alias histórico da ficha antiga no ZIP D03 e não foi reutilizado.

**Executor das verificações automáticas abaixo:** IA/Codex no ambiente de Caio, em headless; não são benchmark gráfico. **Validação humana posterior:** Caio confirmou execução gráfica das seis etapas/F9 e revisão de código sem alterações em P08; evidência vinculada ao final.

## Resultado automático

Compilação final: `dotnet build Cyra.sln --no-restore`, sucesso, zero avisos/erros.

| Ensaio técnico | Observado | Limite |
|---|---|---|
| Coletor habilitado na cena existente | JSONL com início/fim, amostras, mensagens e eventos de cena, entrada, pulo, pouso, botão e gatilho. | Roteiro automatizado temporário; entrada/sinais simulados. Não substitui execução humana. |
| Marcador | F9 simulado produz human_step_marker com etapa 1. | Conferência gráfica/F9 físico posteriormente confirmada por Caio em P08. |
| Logger nativo | Capturou aviso e erro intencional T04_expected_warning/T04_expected_error. | Injeções de teste, não falhas reais observadas no jogo. Logger é instalado após início do autoload; não captura retroativamente toda inicialização. |
| Modo comum | Cena inicializa e encerra sem criar pasta de sessão optativa. | Não comprova toda experiência gráfica. |
| Escrita indisponível | Arquivo bloqueador no caminho produz aviso IOException; cena continua e encerra normalmente. | Sem alterar permissões do sistema; falha provocada em caminho de ensaio. |
| Pacote release | Iniciador executou pacote sem janela e criou package/execution/session/engine/summary/relato; exit_code 0 e collector_complete true. | Headless explicitamente identificado; performance_assessment not_applicable_headless e sem veredicto de teste automático. |
| Análise parcial | Cópia de ensaio sem rodapé e com linha JSON truncada é sinalizada incompleta, sem crash do analisador. | Fixture sintética derivada; não é corrupção real de uma sessão de Lucas. |
| Reanálise | Texto de controle em relato.txt foi preservado. | Texto de controle automatizado, não relato humano. |

[Relatório de 24 checagens](T04_A03_verificacao_automatica.json). [Amostra release sem janela](T04_A03_amostra_automatica.jsonl). [Eventos e erros simulados](T04_A03_eventos_simulados.jsonl). Não consolidar os valores dessas amostras como resultado de RNF04.

## Condições e reprodução

Usados Godot .NET 4.7.2 e SDK 8.0.422. O runtime efetivo é registrado pela própria execução; build de editor e pacote release podem carregar runtimes diferentes e não são misturados como benchmark. Exportação separada em `build/a03-test`, com `.exe`, `.pck` e bibliotecas, fora do Git. Os comandos do console wrapper chegaram ao empacotamento completo mas permaneceram aguardando; foram interrompidos e o pacote resultante foi executado/validado pelo iniciador com êxito.

O modo `-VerificacaoSemJanela` de Executar_Teste.ps1 é exclusivo de checagem técnica: acrescenta headless e saída automática. Lucas usa o iniciador comum, sem essa opção. O ensaio de eventos usa `.godot/validation/A03Probe.gd`/`.tscn`, temporários fora da exportação; cópias de reprodução ficam no ZIP D04, em validation/. Esse auxiliar instancia a cena A01, emite botão/gatilho, simula pulo/F9 e injeta aviso/erro esperados antes de encerrar.

As assinaturas dos callbacks Logger foram conferidas no SDK local. A primeira compilação teve ambiguidades Godot/.NET corrigidas pela IA; a importação inicial no sandbox falhou por acesso à configuração/assemblies do ambiente. São ocorrências da geração/ambiente, sem atribuição de correção humana.

## Curadoria humana e encaminhamentos

- [x] Caio confirmou revisão do código solicitado, sem necessidade de alterações (P08); tempo não medido.
- [x] Caio repetiu graficamente as seis etapas/F9; sessão e logs conferidos em 27/10/2026, com identificação/manifesto de evidências.
- [ ] Fazer piloto de integração/overhead e configuração na máquina de Lucas quando as mecânicas de A05–A07 existirem; conectar eventos reais dessas atividades.

**Situação atual:** T04 aprovado no escopo do suporte entregue, com verificação automática e validação/revisão humana de Caio em P08. A03/T02 registra a revisão metodológica distinta. Piloto da demo em Lucas é trabalho futuro. Nenhum benchmark final ou teste de Lucas foi inventado; nenhum commit/envio automático.

## Verificação gráfica relatada e achado posterior — P07

Caio informou execução sem problemas lógicos/gráficos pelo CMD da pasta tools. A inspeção das duas sessões mostrou que o fallback escolhia o pacote antigo build/windows: a cena funcionou, mas o coletor não existia nesse pacote. O iniciador também atribuía Lucas por padrão. Essa falha do iniciador foi corrigida em D05/P07; os registros originais permanecem com a anotação do erro de perfil em [correção do iniciador](T04_A03_correcao_iniciador.md).

O reteste automático do novo padrão produziu telemetria completa. Na etapa P07, a repetição gráfica e revisão humana ainda estavam pendentes; foram confirmadas depois por Caio em P08. O relato visual de Caio é preservado, sem ampliá-lo para aprovação da coleta. D04 original não foi sobrescrito.

## Encerramento humano — P08

[Validação humana de Caio](T04_A03_validacao_humana_Caio.md): seis etapas/F9 funcionando, código revisado sem alterações e tempo humano não medido. Logs gráficos release: perfil Caio, seis marcadores, 68 amostras, zero erros/avisos/descartes e encerramento normal. Quatro mudanças de foco são preservadas como limitação; não é benchmark da demo. Originais e ensaios anteriores mantidos. T04 liberado para integração por commit humano no escopo desta entrega.
