# T04 — Execução de Lucas e análise dos registros recebidos

**Análise:** 30/10/2026, P09, IA/Codex a pedido de Caio. **Executor:** Lucas, conforme envio informado por Caio e `relato.txt`. **Escopo:** cena A01 e suporte de coleta A03-v2; não é teste da demo final. **Base integrada:** `e0aaeed18db26ff106a2f4a4b799c3c3d71320d6`, conferida no Git. Nenhum código do projeto foi alterado nesta análise.

## Identificação e preservação

- Origem local: `tools/Cyra_A03_Teste_Feito/TestResults/20261030T033654411Z-86a000b7`.
- Sessão interna: `20261030T033658956Z-f3e729d6`.
- Execução: **30/10/2026, 00:36:58–00:39:04, America/Sao_Paulo**; UTC 03:36:58–03:39:04. Duração final do coletor: **125,353 s**. Tempo de preparação, correção do ambiente, aprendizagem e revisão humana fora do jogo: **não informado/não medido**.
- Pacote do jogo: `172238021bea85cd8e57dbc0ba8a998153c6f7e972926c4f2e52e31eef84fb1c`. Os **188 arquivos** listados em `package.json` conferem em tamanho e SHA-256; a identidade foi recalculada. São os mesmos arquivos do jogo usados por Caio em P08.
- [Sessão bruta](T04_Lucas_20261030T033654411-86a000b7/session.jsonl), [resumo recebido](T04_Lucas_20261030T033654411-86a000b7/summary.json), [relato de Lucas](T04_Lucas_20261030T033654411-86a000b7/relato.txt), [execução](T04_Lucas_20261030T033654411-86a000b7/execution.json), [pacote](T04_Lucas_20261030T033654411-86a000b7/package.json), [engine](T04_Lucas_20261030T033654411-86a000b7/engine.log), [conferência independente](T04_Lucas_20261030T033654411-86a000b7/analise_P09.json) e [manifesto das evidências](T04_Lucas_20261030T033654411-86a000b7/SHA256.txt).

Os arquivos recebidos foram copiados sem alteração. A pasta completa com executável e bibliotecas permanece local e é ignorada pelo Git; as evidências selecionadas acima são versionáveis. Nenhum executável ou script recebido foi executado para esta análise.

## Máquina e condições observadas

| Campo | Registrado |
|---|---|
| Perfil e CPU | Lucas; AMD Ryzen 7 8700G w/ Radeon 780M Graphics. |
| GPU | A engine informa literalmente **Radeon 7**, sem identificar o modelo completo nesse campo. A configuração humana MR02 continua Radeon 780M; não substituir silenciosamente um dado pelo outro. |
| Memória física | **25.348.083.712 bytes**, aproximadamente 23,61 GiB reportados ao coletor. A ficha humana informa 32 GB instalados/5600 MHz; capacidade instalada e memória reportada não são equiparadas. Causa da diferença e frequência efetiva não aferidas. |
| SO/runtime/engine | Windows `10.0.26200`, compatível com a ficha humana Windows 11; .NET runtime 8.0.28; Godot 4.7.2-stable. |
| Modo | Release, fora do editor, sem headless; Compatibility; janela 960 × 540; VSync Enabled; max_fps 0, sem limite explícito. |

## Esperado versus observado

Esperado: iniciar o pacote com coleta, seguir as seis etapas do guia usando F9, observar queda/piso, botão antes de movimento, deslocamento, pulo/pouso, duas entradas no gatilho e botão final; encerrar e enviar relato breve. Marcadores apenas numeram pressionamentos, sem identificar automaticamente cada ação.

| Conferência | Evidência observada | Conclusão e limite |
|---|---|---|
| Integridade da coleta | Cabeçalho e rodapé únicos, ID consistente e tempos crescentes; 124 amostras; encerramento `scene_tree_exit`, exit_code 0; zero linhas inválidas, descartes ou parada por limite. | Coleta completa desta execução; resumo recebido conferido independentemente. |
| Erros/avisos durante a sessão | Nenhum no coletor ou no `engine.log` recebido. | Não cobre um erro anterior ao início do processo nem prova ausência de todo defeito. |
| Cena/piso | Uma cena pronta e um pouso inicial aos 0,498 s. | Inicialização e pouso instrumentados. |
| UI e movimento | Dois eventos de botão; o primeiro, aos 68,986 s, antecede a primeira entrada, aos 74,418 s. | Ordem compatível com botão antes de movimento; o evento de primeira entrada não comprova sozinho deslocamento nos dois sentidos. |
| Gatilho | Duas entradas, aos 83,636 e 85,102 s. | Reentrada corroborada pelos registros. |
| F9 | **Cinco** marcas sequenciais, aos 51,851; 71,902; 78,685; 89,086; 96,420 s. | O roteiro prevê seis. Não atribuir a cada marca uma etapa sem confirmação humana. |
| Pulo/pouso da etapa 4 | **Nenhum `A01_jump`** e nenhum pouso posterior ao inicial. O cabeçalho declara suporte a esses eventos. | Etapa não corroborada nesta sessão; não é possível distinguir omissão de tentativa sem efeito apenas pelo log. Não declarar pulo aprovado por Lucas nesta execução. |
| Percepção humana | Lucas respondeu que conseguiu concluir e não percebeu nada fora do comum. | Relato preservado; não elimina a lacuna de evidência do pulo/F9. Não houve relato de revisão do código por Lucas. |

## Ocorrência de inicialização e versão das ferramentas

Lucas relatou um erro de execução de script na máquina, corrigido antes da sessão bem-sucedida. **Mensagem, causa, procedimento e tempo da correção não foram fornecidos.** Nenhum log dessa tentativa anterior foi recebido; não atribuir a falha a política do PowerShell, código do jogo ou à correção D05 sem evidência. A sessão analisada iniciou e terminou normalmente.

Os arquivos CMD/PowerShell e o guia recebidos são **idênticos byte a byte à saída original D04**, anterior à correção D05. Foram preservados em [ferramentas_recebidas](T04_Lucas_20261030T033654411-86a000b7/ferramentas_recebidas/Executar_Teste.cmd). O iniciador antigo usa Lucas por padrão e fallback para `build/windows`; nesta execução havia `Cyra.exe` ao lado, com coletor, e a identidade do executor também vem do relato/envio. Portanto a coleta é válida, mas **não valida a escolha explícita de perfil e o fallback corrigidos em D05**. O hash do pacote cobre arquivos do jogo, não CMD/PS1/guia; estes foram conferidos e arquivados separadamente.

Para novas execuções, distribuir os três arquivos atuais de `tools/Testing` e o guia atual de `docs` junto ao jogo. O guia de trabalho foi ajustado para orientar Lucas a selecionar seu próprio perfil, mantendo o guia recebido como histórico.

## Dados descritivos de desempenho

FPS mediano **60**, mínimo **6** na primeira amostra, aos 1,024 s; as outras amostras ficaram em pelo menos 55 FPS. Memória privada: primeira **260.182.016**, última/máxima **266.121.216**, diferença **5.939.200 bytes**. Não confundir essa diferença com memória total, crescimento contínuo ou prova de vazamento.

Houve **quatro perdas e quatro retomadas de foco**, com 45 das 124 amostras fora de foco. Inicialização, sessão curta, mudanças de foco e cobertura funcional parcial limitam os números. Nenhuma amostra foi excluída. Não há comparação de desempenho entre Caio/Lucas nem aprovação final de RNF04.

## Situação e encaminhamento

**Suporte de coleta A03/A01: validado também na máquina de Lucas nesta sessão, com ressalvas documentadas.** T04 permanece aprovado no escopo entregue, já sustentado pela revisão de código e pelas seis etapas de Caio em P08. **Roteiro funcional de Lucas: aceito por Caio com ressalvas**, com base no relato positivo de Lucas, embora o pulo e uma marca F9 não estejam corroborados pela telemetria. Isso não desfaz os resultados anteriores nem transforma a ausência de registro em defeito comprovado.

Após conhecer as lacunas, **Caio decidiu em P09 prosseguir sem nova execução nesta etapa inicial**, aceitando o relato positivo de Lucas. A hipótese de esquecimento de F9 é de Caio, sem confirmação de qual etapa. Esta é uma decisão humana de aceitar evidência incompleta, não um novo dado observado nem confirmação do pulo. Não há repetição pendente para encerrar A03; lacunas permanecem para transparência. Os detalhes do erro inicial continuam não informados, sem bloquear a integração. Em testes futuros das mecânicas reais, conferir cobertura e marcadores desde o início.

**A03 (método e suporte) encerrada no escopo atual e pronta para integração documental por decisão humana com ressalvas**; não declarar que todas as seis etapas foram comprovadas por Lucas. Eventos A05–A07 e piloto da demo final continuam futuros. Não foram alterados código/cena/save, ZIPs originais ou cronograma; nenhum commit/envio foi feito pela IA.
