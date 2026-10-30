# T05 — Conferência técnica e preparação da revisão humana (P11)

**Data:** 30/10/2026. **Executor da conferência:** Codex/IA no ambiente de Caio. **Base Git:** `cf5ba4a`; A05 ainda sem commit. Não constitui revisão humana nem aprovação gráfica do T05.

## Resultado da conferência

- Lidos Health, PlayerController, BasicEnemy, A05RoomController, HealthIndicator, cenas, coletor e ferramentas de pacote/coleta. Na leitura, não foi identificado defeito impeditivo para iniciar a revisão humana. Isso não garante ausência de defeitos.
- Compilação repetida: `dotnet build Cyra.sln --no-restore`, exit 0, zero erros e zero avisos.
- Ensaio atual repetido com VerifyA05.gd: **56 checagens aprovadas, zero falhas**, sem janela, entrada simulada e fixtures. [Resultado desta conferência](T05_A05_automatico/p11_behavior_results.json). O resultado automático original não foi substituído. As 34 verificações de integração originais foram consultadas, não reexecutadas nesta conferência.
- Manifesto D06: 54 entradas conferidas contra o ZIP; arquivos de trabalho correspondentes ainda iguais ao original antes desta atualização documental.
- Pacote A05 local: 193 arquivos conferidos por tamanho e SHA-256 contra o manifesto release_Caio. Identificador `faf55c4951e9ab859d8c13badebd21c7aeeeaa3001a797436f3e3274eac0e029`. Ferramentas e guia do pacote correspondem às fontes atuais no início da conferência.
- A primeira tentativa de executar o ensaio com acesso restrito falhou ao escrever o log local e carregar assemblies .NET. A repetição com acesso à configuração local da engine terminou com exit 0 e 56/0. Não foi necessário alterar código; ocorrência do ambiente da automação, não observação de uma partida humana.

## Escopo da revisão restante

O T05 continua **pendente de execução e decisão humanas**. Utilizar a [ficha T05](T05_A05_revisao.md) e o [guia](../Guia_Lucas_Testes.md). A conferência não marca checklists humanos nem atribui participantes, tempos ou aprovação.

O pacote já está pronto para abrir `C:/Users/caio/GIT/cyra/build/a05-test/Executar_Teste.cmd`; selecionar 2 para Caio ou 1 para Lucas. Abrir somente Cyra.exe executa o modo comum, sem coleta optativa. F5/F6, sem argumentos de teste, também não equivalem a iniciar esta coleta.

O roteiro tem 12 etapas, com F9 ao concluir cada uma. Para complementar a cobertura, conferir a parede direita e ataque com alvo à esquerda/direita, ataque voltado para o lado errado e toques rápidos antes do intervalo. Essas observações podem ser realizadas em ciclo adicional com R e relatadas como complemento; não precisam ser forçadas para dentro da sequência original de 12 marcas. Informar marcas extras, ausentes, mortes imprevistas e repetições no relato. Marcador não comprova ação ou aprovação.

Na A05 o jogador e o inimigo podem se atravessar: seus corpos colidem com cenário; o dano é detectado pela área de contato. Não existe repulsão física entre eles nesta proposta. A direção do ataque é capturada ao iniciar; virar muda a próxima janela. Segurar J não gera ataque contínuo. O botão/R reinicia manualmente a sala, enquanto contato com inimigo vivo permite testar morte real. Nada disso implementa absorção, habilidades ou save.

## Informações humanas mínimas

1. Quem executou em cada máquina, em qual data; enviar a pasta completa de cada sessão com relato preenchido.
2. Etapas concluídas e ocorrências, incluindo perdas de marca e complementos de direção/parede. Registrar nada percebido quando realmente for o caso.
3. Quem leu quais scripts/cenas ou conferiu o Inspector; ajustes e decisões, inclusive revisão sem alterações. Teste do executável não comprova leitura de código.
4. Aceitação dos controles/valores como configuração provisória, ou ajustes desejados. Não exige balanceamento definitivo nesta etapa.
5. Tempo de aprendizagem/revisão/correção medido, ou não medido. Duração automática do jogo não substitui esse dado.
6. Decisão humana sobre o T05 e eventuais ressalvas. Capturas de vida antes/depois e atordoamento são úteis; quando ausentes, documentar a limitação.

Caio pode concentrar a leitura dos componentes/Inspector e Lucas repetir a execução no pacote. Identificar o que cada um efetivamente revisou; não atribuir revisão arquitetural a Lucas apenas por jogar. A IA analisará eventos, contagens, dano e continuidade dos logs; percepção visual e aceitação dos parâmetros dependem dos humanos.

Nenhum código/cena/configuração do produto foi alterado nesta conferência. ZIPs/manifestos/prompts e evidências anteriores preservados. Somente novos registros documentais e cópia do resultado automático atual, sem novo D07, commit ou envio ao GitHub.
