# Contexto do Projeto e Escopo Arquitetural (Cyra)

Estamos desenvolvendo o jogo 2D “Cyra” utilizando Godot Engine 4.7.2 .NET/C#, SDK .NET 8.0.422 e exportação para Windows Desktop x86_64.

Repositório: `C:/Users/caio/GIT/cyra`.

O projeto faz parte de um estudo de caso acadêmico sobre programação assistida por IA com curadoria humana obrigatória. Arte, animações, áudio e narrativa final são de autoria 100% humana. Não haverá implementação manual independente para comparação.

Estado anterior:

- A01: ambiente, cena de validação e exportação aprovados.
- A02: regras e modelos revisados pela equipe; T01 aprovado documentalmente.
- A03: protocolo simplificado, coleta automática e guia de testes disponíveis.
- A05: movimento, combate, vida, atordoamento e reinício local implementados. Caio revisou o código sem alterações e aceitou os parâmetros provisórios; Caio e Lucas executaram testes.
- T05 encerrado com ressalvas documentadas. Lucas apenas jogou; não realizou leitura do código. Sua sessão não registra salto e tem 11 marcas F9; Caio aceitou essa cobertura incompleta considerando sua validação anterior.
- Commits: implementação A05 `13c7add`; encerramento documental `4253d7c`. Confira o Git antes de utilizá-los.

O escopo fechado permanece:

- Movimento, combate e vida — A05.
- Absorção, duas habilidades e troca de aparência — A06.
- Três seções, dois bloqueios por habilidade e save local único — A07.
- Recursos humanos e apresentação final — A04/A09.

# Fontes e Decisões Já Aprovadas

Antes de implementar, leia:

- `C:/Users/caio/GIT/cyra/AGENTS.md`.
- `C:/Users/caio/GIT/cyra/docs/Cronograma_Cyra_15-10_a_23-11-2026.md`.
- `C:/Users/caio/GIT/cyra/docs/Guia_atividades_Cyra_2026.md`.
- `C:/Users/caio/GIT/cyra/docs/A02_Escopo_Requisitos_Modelos.md`.
- `C:/Users/caio/GIT/cyra/docs/A03_Protocolo_Avaliacao_Curadoria.md`.
- `C:/Users/caio/GIT/cyra/docs/A05_Movimento_Combate_Vida.md`.
- `C:/Users/caio/GIT/cyra/docs/evidencias/T05_A05_revisao.md`.
- `C:/Users/caio/GIT/cyra/docs/Guia_Lucas_Testes.md`.
- `C:/Users/caio/GIT/cyra/docs/Diario_Experimento_Cyra.md`.
- `C:/Users/caio/GIT/cyra/docs/Prompts_Utilizados.md`.
- `C:/Users/caio/GIT/cyra/README.md`.

Inspecione os componentes, cenas, Input Map, recursos humanos e ferramentas de teste existentes.

Aplique as três skills locais:

- `C:/Users/caio/GIT/cyra/.codex/skills/cyra-gerador-c-sharp/SKILL.md`.
- `C:/Users/caio/GIT/cyra/.codex/skills/cyra-diario-experimento/SKILL.md`.
- `C:/Users/caio/GIT/cyra/.codex/skills/cyra-rastreabilidade-testes/SKILL.md`.

Respeite as regras humanas da A02:

- Inimigo a zero fica atordoado indefinidamente, sem atacar nem causar dano.
- Absorção exige jogador vivo, proximidade e comando explícito.
- Ao adquirir uma habilidade nova, ela fica disponível e é equipada imediatamente.
- Apenas uma habilidade fica ativa; trocar preserva as aquisições.
- Pulo duplo: um salto adicional entre pousos.
- Investida: uma utilização por fase aérea, recuperada ao pousar; no chão, repetir somente após término e intervalo.
- Sem cargas permanentes consumíveis.
- Trocar de forma não recupera usos gastos.
- Durante ataque, absorção ou investida, a troca é rejeitada até terminar a ação.
- Reabsorver um inimigo reiniciado não duplica aquisições, cura ou restaura usos do ciclo.
- Morte mantém adquiridas/ativa, restaura vida e usos transitórios no ponto seguro e reinicia o mundo.
- Inimigos e obstáculos serão mantidos em memória ao transitar, mas reiniciados na morte/reabertura.
- Save pertence à A07 e não incluirá estados de inimigos/obstáculos.

# Tarefa Atual: Implementar a Atividade A06 — Mimetismo, Habilidades e Aparência

Implemente somente RF03/RF04 no escopo da A06 e as adaptações necessárias à integração com A05.

Reutilize Health, jogador, combate, inimigo e coletor existentes. Preserve a sala A05 como teste de regressão. Não substitua o projeto por outra implementação.

Crie uma sala A06 pequena para testar as duas habilidades. Não construa o mapa de três seções, bloqueios por chave ou save.

Execute os cinco itens abaixo.

## 1. Dois Tipos Copiáveis e Absorção

- Reutilize o comportamento básico de inimigo com duas configurações copiáveis, evitando duplicar toda a lógica.
- Associe A a `habilidade_A_pulo_duplo` e B a `habilidade_B_investida`.
- Use identificadores técnicos estáveis, coerentes com a A02.
- Preserve a possibilidade de inimigos sem habilidade na sala A05.
- Diferencie visualmente A/B por indicação técnica enquanto não houver sprites humanos.
- Permita alcançar e derrotar ambos sem possuir a habilidade que concedem.

Implemente absorção por comando:

- Rejeitar alvo vivo, fora do alcance, já absorvido ou jogador morto.
- Aceitar somente alvo atordoado e disponível.
- Se houver mais de um candidato, selecionar de forma determinística e documentada.
- Ao concluir, retirar o alvo da disponibilidade da sessão e adquirir/equipar a habilidade nova.
- Impedir concessões ou sinais duplicados por repetição do comando.
- Não permitir dano posterior por um alvo absorvido.
- Não acrescentar cura, recompensa, inventário ou animação longa de finalização.

Registre antes da implementação uma proposta provisória de teclas, alcance, duração e intervalos. Use valores ajustáveis e prossiga com essa proposta sujeita à curadoria humana, sem apresentá-la como já aprovada.

## 2. Estado das Habilidades, Pulo Duplo e Investida

Separe:

- Habilidades adquiridas e habilidade ativa.
- Usos e intervalos transitórios.
- Representação visual e indicadores.

A lógica não deve depender do texto do HUD ou do sprite exibido.

**Pulo duplo:**

- Manter o salto básico da A05.
- Exigir novo pressionamento no ar e A ativa para o salto adicional.
- Permitir somente um salto adicional entre pousos.
- Segurar Espaço não concede saltos repetidos.
- Trocar A→B→A no ar não recupera o salto adicional.
- Não conceder o salto extra com habilidade ausente ou B ativa.

**Investida:**

- Usar deslocamento horizontal curto pela física nativa, respeitando paredes.
- Exigir B ativa e comando próprio.
- Capturar a direção ao iniciar e definir duração/velocidade/intervalo provisórios.
- Uma utilização no ar, recuperada ao pousar.
- Trocar B→A→B no ar não recupera a utilização.
- No solo, permitir novo uso somente após a ação e o intervalo.
- Não conceder dano, invulnerabilidade ou passagem através de paredes por consequência não solicitada.
- Documentar o comportamento vertical durante a ação como proposta ajustável.

Defina uma prioridade simples para comandos simultâneos e ações incompatíveis. Preserve a rejeição de troca durante ataque, absorção e investida, sem enfileirar uma troca oculta para depois.

Não acrescente terceira habilidade ou sistema genérico de habilidades além do necessário para A/B.

## 3. Troca de Forma, Aparência e Morte

- Implemente troca apenas entre habilidades adquiridas.
- Sem aquisição, permanecer na forma base.
- Manter estado lógico, habilidade executável, indicação visual e HUD sincronizados.
- Rejeitar troca inválida sem mudar parcialmente o visual.
- Dano não altera a habilidade ativa.
- Reabsorção de habilidade já adquirida não renova usos, cura ou duplica progresso. Documente explicitamente o tratamento da habilidade ativa nesse caso, distinguindo proposta operacional de decisão humana anterior.

Adapte o reinício da sala A06:

- Morte encerra ações, retorna ao ponto seguro com vida máxima, preserva adquiridas/ativa e reinicia ambos os inimigos.
- O estado de habilidades deve sobreviver à recarga da sala em memória.
- Usos transitórios são recompostos no retorno seguro, sem restaurá-los por simples troca.
- O reinício manual de teste deve ter efeito documentado e não apagar aquisições silenciosamente.
- Uma nova execução começa sem aquisições enquanto o save ainda não existir.
- Não declare persistência entre aberturas implementada; isso pertence à A07.
- Preserve a continuidade da sessão de logs durante os reinícios.

Quanto à aparência:

- Inspecione se existem sprites/animações humanos com autoria identificada e integre somente os recursos disponíveis.
- Não gere, redesenhe ou substitua arte por IA.
- Sem recursos humanos, use ColorRect/Polygon2D/Label para distinguir base/A/B e preparar a ligação entre estado e apresentação.
- Registre a aparência final como pendência da A04 e o atendimento de RF04 como parcial quando depender desses recursos.
- Não declare troca de sprites humanos validada usando apenas retângulos de cores diferentes.

## 4. Sala, Logs e Testes Repetíveis

Crie a sala A06 em `res://Scenes/Test/`, reutilizando as cenas de entidades e componentes existentes.

Inclua ambos os inimigos e geometria simples para testar salto/investida, sem implementar os obstáculos finais da A07.

- Torne a A06 a execução principal e preserve A01/A05 acessíveis no editor.
- Integre eventos reais de tentativa/resultado de absorção, aquisição, troca aceita/rejeitada, salto adicional, investida, consumos/restaurações e retorno após morte.
- Inclua IDs, estado anterior/posterior e motivo de rejeição quando útil.
- Evite eventos a cada quadro ou repetição de mensagens por permanência em uma área.
- Preserve F9, modo comum sem coleta, limites do coletor e tratamento não fatal de falha de gravação.
- Atualize eventos disponíveis e resumo para reconhecer A06, sem atribuir aprovação automática.
- Atualize iniciador e preparador para cenário A06 e pacote correto, mantendo seleção explícita da máquina e proteção contra pacote divergente.
- Preserve ferramentas/evidências anteriores. Não utilize os pacotes recebidos como fonte de desenvolvimento.
- Não altere políticas de segurança do computador para executar scripts; se houver impedimento, registre a mensagem e a limitação real.

Exporte separadamente para `C:/Users/caio/GIT/cyra/build/a06-test/`, com jogo, bibliotecas, ferramentas atuais, descritor e guia. Não sobrescreva os pacotes A03/A05.

Realize verificações automatizadas relevantes:

- Regressão de movimento, combate, vida e atordoamento da A05.
- Absorção rejeitada em alvo vivo, distante, indisponível ou com jogador morto.
- Aquisição/equipamento de A e B, sem duplicação.
- Pulo básico versus adicional, restauração ao pousar e ausência de recuperação por troca.
- Investida no chão/ar, intervalo, restauração ao pousar e colisão com paredes.
- Troca válida e rejeitada durante ações incompatíveis.
- Ausência de cura ou renovação indevida ao reabsorver.
- Morte após cada aquisição e com cada habilidade ativa.
- Mundo reiniciado com aquisições/ativa preservadas e logs contínuos.
- Sincronização entre estado, HUD e representação disponível.
- Pacote release com cenário e coleta corretos.

Diferencie entrada simulada, fixtures, execução sem janela e observação humana. Não trate número de marcas como prova automática de conclusão.

Atualize o guia com roteiro numerado e manejável. Se houver partida nova e ciclos com aquisições, deixe explícita a preparação de cada condição. Inclua testes negativos sem exigir edição manual de estado ou JSON por Lucas.

O executor deve apenas jogar, marcar F9 e relatar ocorrências. Não exigir séries longas ou transcrição manual de FPS/memória.

## 5. Documentação, Preservação e Revisão Humana

- Registre este prompt integral com o próximo ID disponível.
- Na base atual, os IDs esperados são **P14, D07 e T06**. Confira antes de reservar; T03 continua alias histórico e não deve ser reutilizado.
- Vincule T06 a C-RF03/C-RF04, à integração com A05 e às regras de morte aplicáveis.
- Documente componentes, sinais, ações, parâmetros provisórios e regras efetivamente implementadas.
- Registre a situação dos recursos humanos e pendências de aparência, com autoria quando houver integração.
- Separe verificações automáticas observadas de campos ainda pendentes de teste/revisão humana.
- Prepare matriz de rastreabilidade e checklist sem atribuir execução, leitura de código ou aprovação a quem ainda não as confirmou.
- Preserve saída original identificável em ZIP com manifesto SHA-256 antes da curadoria.
- Não regrave originais, prompts, logs ou tempos anteriores.
- Atualize README e guia com controles, preparação e caminhos do teste A06.
- Use a data real de execução, sem retroagir à janela planejada ou deslocar o cronograma automaticamente.
- Registre alterações da própria IA como geração/correção assistida, sem atribuí-las a humanos.
- Use “não medido” para esforço não aferido.

Prepare revisão humana de:

- Absorção válida e rejeitada.
- Duas aquisições, equipamento e troca.
- Pulo duplo e investida, incluindo limites por ciclo.
- Tentativas de renovar usos trocando de forma ou reabsorvendo.
- Ações incompatíveis e comandos simultâneos.
- Morte, reinício dos inimigos e preservação das habilidades.
- Coerência do HUD/aparência e pendências de arte humana.
- Código, parâmetros provisórios, logs e pacote.

# Critério de Conclusão e Entrega

A entrega deve permitir repetir:

**derrotar/atordoar A → absorver por comando → usar pulo duplo → derrotar/atordoar B → absorver → usar investida → trocar entre adquiridas → morrer → retornar com habilidades/ativa preservadas e inimigos reiniciados.**

A lógica funcional pode avançar com representação provisória. A integração da aparência humana deve permanecer explicitamente pendente quando os recursos não existirem; não declarar RF04 integralmente concluído nessa condição.

Ao concluir, informe:

- Arquivos criados ou alterados.
- Componentes, sinais e integração com A05.
- Controles e valores provisórios adotados.
- Testes executados, resultados e limitações.
- Recursos humanos integrados e pendências de aparência.
- Local do pacote e como iniciar A06 com logs.
- Roteiro de revisão humana e preenchimento do T06.
- Pendências reais para integração.

Não implemente A07, save, mapa final, bloqueios por habilidade ou apresentação final A09. Não gere assets artísticos, não faça commit e não envie alterações ao GitHub. Siga as skills na pasta
