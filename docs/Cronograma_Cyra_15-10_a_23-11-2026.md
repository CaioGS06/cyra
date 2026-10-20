# Cronograma de conclusão de Cyra

Planejamento atualizado em 15/10/2026, com entrega do documento em 16/11/2026 e banca em 23/11/2026.

**Base dos compromissos:** [PDF indicado pelo grupo](<C:/Users/caio/Downloads/(CLV) LES - 5 - Relatorio_Parcial_Final_ADS_assinado (1).pdf>), com a alteração de metodologia determinada pelo grupo em 15/10: retirar a implementação manual independente para comparação. Datas, experiência e disponibilidade vieram da conversa. Os demais anexos e o resumo anterior não fundamentam este planejamento. Horas, responsáveis e datas intermediárias são estimativas de execução.

**O que mudou nesta revisão**

O total semanal garantido continua em 50 horas, mas a capacidade mudou de lugar: Caio tem 21 h/semana, Lucas 11 h e Victor 18 h. Antes, o plano pressupunha aproximadamente 10, 10 e 30 horas semanais, respectivamente. O ganho está na programação e integração de Caio; o principal cuidado passa a ser preservar o tempo de Victor para os recursos humanos e a escrita.

Não serão construídas versões manuais de módulos para um grupo de comparação. A avaliação passa a ser um estudo de caso do desenvolvimento assistido por IA: atendimento aos requisitos, defeitos, revisões humanas, retrabalho, estabilidade, desempenho e adequação da arquitetura. O relatório final deve registrar essa mudança, pois o PDF de base menciona o contraste com programação manual na página 6. Recomenda-se comunicar a metodologia atual à orientação. Não apresentar a etapa retirada como realizada nem concluir que a IA foi superior à programação manual.

**Situação inicial:** jogo em 0%. Nenhum integrante trabalhou com Godot. Caio tem experiência extensa com C#; Lucas e Victor já trabalharam com Java. O plano inclui familiarização com cenas, nós, sinais, entradas, colisões e exportação, além da leitura e revisão dos scripts. Conhecimento da linguagem ajuda na revisão, mas não elimina a aprendizagem da engine.

**Disponibilidade garantida**

| Dia | Caio | Lucas | Victor |
|---|---:|---:|---:|
| Segunda | 1 h | 1 h | 2 h |
| Terça | 1 h | 1 h | 2 h |
| Quarta | 3 h | 4 h | 3,5 h |
| Quinta | 1 h | 1 h | 2 h |
| Sexta | 3 h | 4 h | 3,5 h |
| Sábado | 6 h | 0 h garantidas | 0 h garantidas |
| Domingo | 6 h | 0 h garantidas | 5 h |
| **Total semanal** | **21 h** | **11 h** | **18 h** |

“Indefinido” foi tratado como zero para o planejamento, não como indisponibilidade definitiva. Horário posteriormente confirmado serve primeiro para absorver atraso. Mantive 02/11 sem trabalho obrigatório. As janelas das atividades podem atravessar esse dia e os horários indefinidos, mas as horas são distribuídas nos demais blocos disponíveis.

**Capacidade e margem até o fechamento interno em 13/11**

| Pessoa | Capacidade anterior | Capacidade atual | Trabalho A01–A12 | Reserva atual |
|---|---:|---:|---:|---:|
| Caio | 42 h | 87 h | 65 h | 22 h |
| Lucas | 42 h | 48 h | 35 h | 13 h |
| Victor | 126 h | 75,5 h | 61 h | 14,5 h |
| **Total** | **210 h** | **210,5 h** | **161 h** | **49,5 h** |

As capacidades atuais somam cada data entre 15/10 e 13/11, inclusive, excluindo 02/11. A reserva atende aprendizagem do Godot, correções e revisão, sem ampliar conteúdo. Testes locais, registro e comunicação interna já estão nas estimativas.

Os dias 14–15/11 ficam como contingência: 12 h de Caio e 5 h de Victor confirmadas, sem contar Lucas nem o sábado de Victor. O dia 16/11 fica para conferência e entrega. A preparação principal da banca permanece em 17–20/11; em 21–22/11 também há 12 h de Caio e 5 h de Victor de contingência. O horário oficial da banca prevalece sobre a disponibilidade rotineira.

**Divisão de trabalho atual**

Caio lidera movimentação, combate, integração, exportação e descrição da implementação em C#. Seus fins de semana concentram tarefas extensas. Também ajuda com recursos humanos simples e a documentação técnica, reduzindo a carga de Victor.

Lucas lidera mimetismo, save e testes funcionais e revisa os scripts com Caio. Quarta e sexta concentram desenvolvimento; nos dias de uma hora, priorizar revisão, teste ou correção delimitada. Não há atividade de escrever uma solução independente sem IA.

Victor lidera arte/animações/som humanos e organização do texto. Os desenvolvedores entregam descrições e evidências das próprias tarefas. Victor consolida a redação, sem reconstruir o trabalho técnico a partir do código. A arte fica limitada a 22 h de Victor e 4 h de apoio humano de Caio, com entregas graduais.

**Escopo mínimo mantido**

- Godot com C# e demo exportada para um sistema desktop escolhido pelo grupo.
- Três seções pequenas e interligadas, preservando o RF06, com cenário reaproveitado.
- Dois inimigos copiáveis e duas habilidades, por exemplo pulo duplo e investida. A quantidade de dois é sugestão de economia, não um número imposto pelo PDF.
- Movimento, combate, vida, absorção, mudança visual humana e obstáculos que exigem a habilidade apropriada.
- Um save local com seção/posição segura, habilidades, vida e estados relevantes de obstáculos e inimigos derrotados.
- Aviso ao jogador sobre os módulos assistidos por IA, autoria humana dos recursos e revisão do código antes da integração.
- Avaliação funcional, de estabilidade, desempenho e curadoria humana, sem implementação manual independente.

O percurso sugerido continua curto: seção 1 ensina movimento e combate e concede A; A permite avançar pela seção 2, onde se obtém B; B permite concluir a seção 3. As conclusões serão limitadas ao jogo, versões das ferramentas, condições de teste e experiência desta equipe.

**Cronograma atualizado**

As horas são esforço por pessoa dentro da janela, não horas diárias. A08 deixou de ser implementação manual e passou a ser revisão cruzada da arquitetura e rastreabilidade. Ela reserva a análise entre desenvolvedores; as tarefas de programação já incluem a revisão do próprio autor e testes locais.

| ID | Janela em 2026 | Atividade e resultado esperado | Responsável principal | Horas Caio / Lucas / Victor | Dependência |
|---|---|---|---|---|---|
| A01 | 15–18/10 | Preparar ambiente, aprender fluxo básico do Godot e exportar cena de teste | Caio e Lucas | 7 / 3 / 1 | Nenhuma |
| A02 | 15–18/10 | Conferir requisitos/modelos e definir percurso mínimo | Victor, com os dois devs | 1 / 1 / 4 | Nenhuma; decisões antes da implementação correspondente |
| A03 | 16–20/10 | Fixar avaliação técnica e registros da curadoria humana | Lucas e Caio | 1 / 1 / 2 | A02; inicia com regras já decididas |
| A04 | 19/10–01/11 | Produzir recursos humanos mínimos e entregar gradualmente | Victor, com Caio | 4 / 0 / 22 | A02; primeira entrega em 23/10 |
| A05 | 19–25/10 | Implementar movimento, combate, vida e inimigo básico | Caio | 10 / 2 / 1 | A01 e A02 |
| A06 | 26–28/10 | Implementar absorção, duas habilidades e transformação visual | Lucas, com Caio | 5 / 6 / 2 | A05 e recursos mínimos da A04 |
| A07 | 29/10–03/11 | Integrar três seções, obstáculos e save local | Caio e Lucas | 10 / 5 / 3 | A06 e modelo da A02 |
| A08 | 20/10–08/11 | Revisar arquitetura, interfaces e rastreabilidade do código assistido | Caio e Lucas | 3 / 2 / 1 | A03; revisão gradual dos módulos implementados |
| A09 | 03–04/11 | Integrar recursos finais, aviso, controles e executável completo | Caio | 4 / 1 / 3 | A04 e A07 |
| A10 | 05–10/11 | Testar requisitos, corrigir falhas críticas e medir estabilidade/desempenho | Lucas, com os três | 8 / 6 / 3 | A09; incorpora revisões da A08 |
| A11 | 19/10–11/11 | Escrever durante o desenvolvimento e concluir análise do estudo de caso | Todos; Victor consolida | 8 / 5 / 14 | Começa com A02/A03; resultados finais após A10 |
| A12 | 12–13/11 | Revisar e fechar documento e pacote coerentes | Todos | 4 / 3 / 5 | A10 e A11 |
| A13 | 16/11 | Conferir arquivos, entregar documento e guardar comprovante | Integrante designado | 1 / 1 / 2 | A12 |
| A14 | 17–18/11 | Preparar apresentação e roteiro de demonstração | Victor, com os devs | 3 / 2 / 5 | A13 e resultados efetivamente entregues |
| A15 | 19–20/11 | Ensaiar defesa e testar demonstração fora do editor | Todos | 2 / 2 / 4 | A14 |
| A16 | 23/11 | Apresentar e registrar solicitações da banca | Todos | Conforme horário oficial | A15 |

**Marcos atualizados**

| Data | Resultado verificável |
|---|---|
| 18/10 | Ambiente comum, cena exportada, noções básicas do Godot e escopo fechado |
| 20/10 | Protocolo de avaliação e registro de prompts/revisões definidos |
| 23/10 | Verificação intermediária: movimento funcional e recursos humanos básicos disponíveis |
| 25/10 | Movimento, combate e vida formando um ciclo jogável |
| 28/10 | Absorção, transformação e habilidades funcionando |
| 03/11 | Percurso nas três seções e save integrados |
| 04/11 | Demo completa exportada; encerrar novas funcionalidades |
| 10/11 | Medições encerradas e falhas críticas tratadas |
| 11/11 | Texto completo, com resultados e limitações |
| 13/11 | Documento e pacote revisados e fechados |
| **16/11** | **Documento de projeto final entregue** |
| 20/11 | Apresentação e demonstração ensaiadas |
| **23/11** | **Banca de TCC** |

Os primeiros marcos ganharam o fim de semana de familiarização e implementação. Os marcos finais de 04/11, 13/11, 16/11 e 23/11 foram mantidos. Encaminhar uma versão parcial para orientação em 06/11, se houver acompanhamento disponível; a escrita não deve depender de receber retorno.

**Como usar os dias com horas diferentes**

| Bloco | Caio | Lucas | Victor |
|---|---|---|---|
| Segunda, terça e quinta | Uma revisão ou correção delimitada | Teste pequeno, revisão de script ou evidência | Recurso humano pontual ou trecho do texto |
| Quarta e sexta | Implementar, testar e documentar uma funcionalidade | Desenvolvimento de habilidade/save e testes | Arte/animação ou redação com meta definida |
| Sábado | Integração, mapa, exportação e descrição técnica | Nenhuma dependência nesse dia | Nenhuma dependência nesse dia |
| Domingo | Encerrar integração e preparar tarefas da semana | Nenhuma dependência nesse dia | Completar recursos e consolidar escrita/evidências |

Os blocos de 6 horas incluem pausas e registro, sem serem seis horas líquidas de programação. No domingo, Victor pode preparar os recursos que Caio integra, mas Caio não deve depender de revisão imediata de Lucas. Antecipar o que precisará da quarta ou sexta seguinte.

**Avaliação técnica sem versão manual independente**

O roteiro é: requisito e critério definidos → saída da IA preservada → revisão humana registrada → correção/adaptação quando necessária → teste → integração → medição e análise.

Medir atendimento aos requisitos, tipos de falha, tempo de geração/revisão/correção/integração, testes aprovados, estabilidade, FPS/tempo de quadro e memória em cenário definido. Analisar responsabilidades, acoplamento e mudanças necessárias para integrar os scripts ao Godot.

Antes/depois de uma correção pode ilustrar o problema e sua resolução. Isso não equivale a comparar IA com uma solução independente escrita por um desenvolvedor. Código original que não executa tem uma falha registrada, não um FPS inventado. Sem referência manual, o estudo não mede economia de tempo frente ao desenvolvimento sem IA nem comprova superioridade sobre ele. Separar, quando possível, o tempo aprendendo Godot do tempo corrigindo código gerado.

**Ajustes caso haja atraso**

Se movimento e combate não fecharem em 25/10, reduzir salas, variedade de ataques, quadros de animação e detalhes visuais. Se mimetismo não fechar em 28/10, usar a reserva técnica e impedir expansão do cenário. Se recursos humanos atrasarem, usar o apoio de Caio para elementos simples; não compensar com geração de imagens ou sons por IA.

Preservar mudança visual, progressão por habilidades, persistência, transparência e avaliação técnica. A retirada da implementação manual é uma alteração de método registrada, não uma dispensa do restante dos testes. Se o atraso ultrapassar a reserva, explicitar o ponto afetado à orientação e reduzir volume de conteúdo primeiro.

Depois de 04/11, apenas correções e legibilidade. Após a entrega, preservar a versão analisada. Correção para a banca que altere comportamento ou medições exige retestar os cenários afetados e explicar a diferença entre versões. A contingência de 14–15/11 e 21–22/11 não deve ser comprometida com recursos extras.

**Documentação que acompanha o trabalho**

1. Texto principal com requisitos, modelos, metodologia atualizada, implementação, pesquisa já relatada no PDF, resultados do estudo de caso, discussão e limitações.
2. Diário com prompt, ferramenta/modelo, saída original, revisão/correção humana, tempo por etapa, aprendizagem do Godot e versão do código.
3. Testes/medições com cenário, equipamento, versão, esperado, observado, falhas e evidência.
4. Inventário de arte/animação/áudio com autoria humana, origem/editável e utilização.
5. README com versões, execução, controles, exportação e aviso de assistência de IA.

Cada pessoa documenta sua própria tarefa. Os registros são instrumentos propostos, não cinco novos trabalhos acadêmicos. O passo a passo, com documentação e exemplos atualizados, está no [guia](C:/Users/caio/Desktop/cyra/docs/Guia_atividades_Cyra_2026.md).
