# Contexto do Projeto e Escopo Arquitetural (Cyra)

Estamos desenvolvendo o jogo 2D “Cyra” utilizando Godot Engine 4.7.2 .NET/C#, SDK .NET 8.0.422 e exportação para Windows Desktop x86_64.

Repositório: `C:/Users/caio/GIT/cyra`.

O desenvolvimento faz parte de um estudo de caso acadêmico sobre programação assistida por IA com curadoria humana obrigatória. Arte, animações, áudios e narrativa final são de autoria 100% humana. Não haverá implementação manual independente para comparação.

As atividades anteriores estão documentadas:

- A01: ambiente, cena de validação e exportação Windows aprovados.
- A02: requisitos, percurso e regras revisados pela equipe; T01 aprovado documentalmente com ajustes.
- A03: protocolo simplificado, coleta automática e guia de testes implementados. T02 documental concluído e suporte de coleta validado em T04.
- A execução de Lucas na A03 foi aceita por Caio com ressalvas: cinco marcas F9 e nenhum evento de pulo registrado. Preserve essa limitação.
- Commits de referência: A02 `f145393`; suporte A03 `e0aaeed`; encerramento documental A03 `cf5ba4a`. Confira o Git antes de utilizá-los.

O escopo fechado permanece:

- Movimento, combate, vida separada da UI e inimigo básico — A05.
- Absorção, pulo duplo, investida e troca de forma — A06.
- Três seções, dois bloqueios por habilidade e save local único — A07.
- Recursos humanos e apresentação final — A04/A09.

# Fontes e Decisões Já Aprovadas

Antes de implementar, leia:

- `C:/Users/caio/GIT/cyra/AGENTS.md`.
- `C:/Users/caio/GIT/cyra/docs/Cronograma_Cyra_15-10_a_23-11-2026.md`.
- `C:/Users/caio/GIT/cyra/docs/Guia_atividades_Cyra_2026.md`.
- `C:/Users/caio/GIT/cyra/docs/A02_Escopo_Requisitos_Modelos.md`.
- `C:/Users/caio/GIT/cyra/docs/A03_Protocolo_Avaliacao_Curadoria.md`.
- `C:/Users/caio/GIT/cyra/docs/Guia_Lucas_Testes.md`.
- `C:/Users/caio/GIT/cyra/docs/Diario_Experimento_Cyra.md`.
- `C:/Users/caio/GIT/cyra/docs/Prompts_Utilizados.md`.
- `C:/Users/caio/GIT/cyra/README.md`.

Inspecione também os scripts, cenas, configurações e ferramentas de teste existentes.

Aplique as três skills locais:

- `C:/Users/caio/GIT/cyra/.codex/skills/cyra-gerador-c-sharp/SKILL.md`.
- `C:/Users/caio/GIT/cyra/.codex/skills/cyra-diario-experimento/SKILL.md`.
- `C:/Users/caio/GIT/cyra/.codex/skills/cyra-rastreabilidade-testes/SKILL.md`.

Respeite as decisões humanas da A02:

- Vida permanece entre zero e o máximo, independentemente da UI.
- Dano não pode ser multiplicado indiscriminadamente por quadro.
- Inimigo a zero de vida fica atordoado indefinidamente, sem atacar nem causar dano, disponível para a absorção futura.
- Morte retorna ao ponto seguro atual com vida máxima e reinicia inimigos e obstáculos.
- Habilidades adquiridas e forma ativa serão preservadas na morte quando existirem.
- Valores de vida, dano, velocidade, alcance e intervalos ainda não foram aprovados como balanceamento final.

Nesta A05 existe apenas uma sala de teste: use um ponto seguro local e reinicie seus inimigos. Não implemente antecipadamente seções, habilidades, obstáculos ou persistência.

# Tarefa Atual: Implementar a Atividade A05 — Movimento, Combate e Vida

Implemente RF01 e RF02 no escopo da A05, com código simples, componentes revisáveis e uma sala pequena que permita repetir os testes.

O ator descartável da A01 não é o controlador definitivo do jogador. Preserve a cena A01 e seus testes históricos.

Execute os cinco itens abaixo.

## 1. Jogador, Física e Sala de Teste

- Crie uma cena própria do jogador em `res://Scenes/Entities/` e scripts em `res://Scripts/Player/`.
- Use `CharacterBody2D`, colisões nativas, gravidade e `MoveAndSlide()`.
- Implemente andar nos dois sentidos, pular somente quando permitido e cair.
- Configure ações próprias no Input Map para movimento, pulo e ataque. Documente as teclas e evite conflitos com F9.
- Crie uma sala A05 em `res://Scenes/Test/`, com piso, parede, espaço para salto, inimigo e ponto inicial seguro.
- Garanta que os testes possam ser repetidos sem ficar preso ou precisar editar a cena.
- Use exclusivamente formas nativas simples para os elementos sem recursos humanos disponíveis.
- Aponte a execução principal para a sala A05 e mantenha a A01 acessível por F6, documentando a mudança.

Antes de implementar os valores, registre uma proposta inicial enxuta de controles e parâmetros. Use valores ajustáveis pelo Inspector e prossiga com essa proposta como configuração provisória, sujeita à revisão humana. Não a apresente como decisão já aprovada pela equipe.

Não acrescente mecânicas como corrida, esquiva, salto extra ou investida.

## 2. Vida, Dano e Ataque Básico

- Separe o estado de vida da sua representação visual.
- Use um componente de vida reutilizável quando isso simplificar jogador e inimigo.
- Mantenha `0 ≤ vidaAtual ≤ vidaMaxima`.
- Emita sinais para mudança de vida e chegada a zero, evitando emissões repetidas de morte/derrota.
- Faça o indicador inicializar com o valor real e acompanhar as alterações por sinais.
- A UI apenas apresenta os dados; não decide dano, morte ou regras de combate.
- Implemente um ataque básico de curto alcance, orientado para a direção do jogador, usando detecção nativa.
- Defina uma janela de ataque e intervalo ajustáveis. Cada ataque deve atingir o mesmo alvo no máximo uma vez.
- Defina um intervalo simples para dano recebido, impedindo que o contato elimine toda a vida em poucos quadros.
- Trate entradas repetidas, ataque fora de alcance e ataques após morte/atordoamento de forma coerente.
- Documente camadas e máscaras para distinguir cenário, corpos e áreas de dano.
- Não acrescente combos, projéteis, armas ou sistemas genéricos além do necessário.

Use uma indicação visual técnica simples de ataque e dano, suficiente para revisão humana, sem gerar sprites, sons ou narrativa.

## 3. Inimigo Básico, Atordoamento e Reinício

- Crie uma cena reutilizável de inimigo em `res://Scenes/Entities/` e scripts em `res://Scripts/Enemies/`.
- Implemente um comportamento simples, como patrulha curta e dano por contato, suficiente para testar o ciclo.
- Faça a detecção de paredes e piso usar os recursos da engine.
- Ao chegar a zero de vida, entre em estado atordoado: pare o comportamento ofensivo e impeça novos danos ao jogador.
- Mantenha o inimigo identificável em posição estável, sem recuperação por tempo.
- Não remova o inimigo como se já tivesse sido absorvido. Não implemente absorção ou concessão de habilidade nesta etapa.
- Impeça que ataques adicionais produzam derrotas repetidas ou vida negativa.

Ao morrer, o jogador deve encerrar suas ações, retornar ao ponto seguro local com vida máxima e reiniciar a sala/inimigos. Uma solução simples de reinicialização da sala é aceitável nesta etapa, desde que documentada e sem duplicar sinais ou nós.

O coletor autoload deve continuar funcionando durante o reinício. Não reinicie nem sobrescreva a sessão de logs a cada morte.

Não implemente save ou infraestrutura de habilidades apenas para simular as regras futuras.

## 4. Integração com a Coleta Automática e Testes

Reutilize o suporte A03 existente. Não crie outro coletor ou diário paralelo.

- Registre eventos reais e pouco frequentes de movimento/salto/pouso, ataque, dano aplicado, vida alterada, atordoamento, morte e retorno seguro.
- Inclua identificadores técnicos e valores anteriores/posteriores quando úteis.
- Não registre movimento a cada quadro nem serialize nós/cenas.
- Atualize a identificação dos eventos disponíveis para refletir o que foi implementado.
- Preserve o modo comum sem coleta e as proteções contra falha de gravação.
- Identifique o cenário como A05; não rotule esta sala como A01 ou demo completa.
- Ajuste iniciador/analisador apenas no necessário para reconhecer A05 e selecionar a exportação correta.
- Preserve as correções D05 de escolha explícita de máquina e detecção de coleta ausente.
- Não use como fonte de desenvolvimento os iniciadores antigos recebidos na pasta de testes de Lucas.

Prepare uma exportação separada em `C:/Users/caio/GIT/cyra/build/a05-test/`, com as ferramentas atuais e o guia, sem sobrescrever evidências da A03. Identifique os arquivos do pacote conforme o mecanismo existente.

Realize as verificações automatizadas viáveis:

- Compilação e carregamento da cena.
- Movimento, salto/pouso e colisão com piso/parede.
- Ataque válido, ataque fora de alcance e prevenção de dano duplicado por ataque.
- Dano recebido com intervalo, limites da vida e chegada a zero.
- Inimigo atordoado sem causar dano ou recuperar-se sozinho.
- Morte/retorno com vida máxima e reinício dos inimigos, repetido para detectar conexões duplicadas.
- Eventos e integridade da coleta durante esse ciclo.
- Preservação do funcionamento da A01 quando houver alteração compartilhada.

Use testes ligados a comportamentos relevantes. Diferencie entrada simulada, execução sem janela e teste gráfico humano. Não declare aprovação visual ou humana com base em execução automática.

Atualize o guia com um roteiro curto e numerado específico da A05. Para cada etapa, descreva ação, resultado esperado e quando pressionar F9. Evite etapas que misturem muitas ações difíceis de identificar nos logs.

Lucas deve precisar apenas jogar, marcar as etapas e relatar brevemente ocorrências. A IA organiza e analisa os dados; a aprovação continua humana. Não imponha séries longas ou novos limites rígidos de desempenho.

## 5. Documentação, Preservação e Revisão Humana

- Registre este prompt integral e a geração no diário usando os próximos IDs disponíveis.
- Na base atual, os próximos esperados são **P10, D06 e T05**. Confira os registros antes de reservar; não reutilize T03, alias histórico da revisão A03.
- Vincule T05 aos cenários C-RF01/C-RF02 e ao reinício de apoio da A05.
- Separe resultados automáticos já observados dos campos ainda pendentes de execução humana.
- Prepare a ficha de revisão e a matriz de rastreabilidade, incluindo responsáveis ainda não confirmados como pendentes.
- Documente componentes, sinais, camadas/máscaras, controles e parâmetros provisórios.
- Atualize README e guia para abrir, executar, exportar e testar a A05.
- Preserve uma cópia identificável da saída original, com manifesto SHA-256, antes da curadoria humana.
- Não regrave os ZIPs, prompts originais, evidências ou tempos das etapas anteriores.
- Registre correções feitas pela própria IA como parte da geração assistida, sem atribuí-las aos desenvolvedores.
- Não invente participantes, duração de revisão, capturas ou resultados. Use “não medido” quando necessário.
- Use a data real de execução e mantenha o cronograma original, sem deslocar suas datas automaticamente.

Prepare um checklist humano enxuto para Caio e Lucas conferirem:

- Movimento, salto e colisões.
- Alcance, direção e repetição do ataque.
- Dano e correspondência entre vida real e indicador.
- Atordoamento sem dano posterior.
- Morte, retorno e reinício dos inimigos.
- Legibilidade e adequação dos parâmetros provisórios.
- Coleta, marcadores e ausência de conflitos entre controles.
- Leitura do código, com ou sem necessidade de correção.

Indique as capturas úteis de vida antes/depois e atordoamento, sem apresentá-las como já produzidas.

# Critério de Conclusão e Entrega

A entrega deve permitir executar e repetir:

**andar/pular/cair → aproximar-se do inimigo → receber dano e observar a vida → atacar e atordoar o inimigo → morrer em outro ciclo → retornar com vida máxima e inimigo reiniciado.**

Compilação e testes automáticos não encerram a curadoria humana.

Ao concluir, informe:

- Arquivos criados ou alterados.
- Estrutura dos componentes e principais sinais.
- Controles e parâmetros provisórios adotados.
- Verificações executadas, resultados e limitações.
- Local do pacote exportado e como iniciar o teste A05 com logs.
- Roteiro curto para revisão humana e preenchimento do T05.
- Pendências reais para o commit, sem antecipar A06/A07.

Não gere assets artísticos, não implemente atividades futuras, não faça commit e não envie alterações ao GitHub.

Siga as skills na pasta [skills](.codex/skills/) e o [AGENTS.md](AGENTS.md).
