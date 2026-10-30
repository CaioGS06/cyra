# Guia curto de testes — Lucas

Versão A03-v2, 27/10/2026. Referência: Lucas/Ryzen 7 8700G/Radeon 780M/32 GB/Windows 11. O guia reduz anotações; o executor ainda confere o que vê e sente ao jogar.

## 1. Preparação pelo desenvolvedor/IA

Entregar o pacote completo exportado (Cyra.exe, Cyra.pck e bibliotecas) com `Executar_Teste.cmd`, `Executar_Teste.ps1` e `Analisar_Logs.ps1`, de `tools/Testing`, e uma cópia deste guia, ao lado do executável.

Lucas é a máquina padrão do iniciador. O responsável prepara testes complementares com `-Maquina Caio` ou `-Maquina Victor`. `-Cenario A01` é o padrão atual; quando a demo existir, o responsável preparará `-Cenario DEMO`. Não misturar resultados de máquinas/versões diferentes.

Há uma exportação A01 separada em `build/a03-test` nesta entrega, após a conclusão da exportação. Não é a demo final. O iniciador também pode ser usado da pasta tools com o caminho do executável fornecido pelo responsável.

O modo de teste não apaga nem edita saves. Para partida nova, arquivo inválido ou falha de gravação futura, o desenvolvedor/IA prepara uma condição identificada, preservando o save pessoal. Não é tarefa de Lucas improvisar edição de JSON ou permissões. Duplicar a pasta do executável não garante outro save.

## 2. O que Lucas faz

1. Abra `Executar_Teste.cmd`. Se aparecer erro/jogo não abrir, copie a mensagem ao responsável; não precisa configurar ferramentas de desempenho.
2. Siga somente o roteiro disponível. Após cada etapa numerada, pressione **F9 uma vez** com o jogo em primeiro plano. F9 marca o momento/etapa, não aprovação. Informe no relato se esquecer uma marca.
3. Feche o jogo normalmente ao terminar. Se travar/precisar encerrar à força, relate isso; o log parcial ainda pode ajudar.
4. Abra `TestResults/<sessão>/relato.txt`, no local indicado pelo iniciador. Responda: concluiu? algo diferente do esperado? houve interrupção externa? Se nada percebeu, escreva isso.
5. Envie a pasta inteira da sessão para análise. Não precisa transcrever FPS/memória nem calcular médias/preencher tabelas.

Se o Windows impedir o iniciador, informe a mensagem ao responsável; não precisa alterar políticas globais do Windows.

## 3. Roteiro disponível agora — A01 e coleta

| Etapa / F9 ao concluir | Ação | Conferência visual |
|---|---|---|
| 1 | Espere o retângulo cair e pousar. | Título visível, retângulo sobre o piso. |
| 2 | Clique em “Testar sinal de UI” antes de mover. | Sinal confirmado; entrada pendente até movimento/pulo. |
| 3 | Ande para os dois lados com setas. | Movimento responde e respeita piso. Evite extremidades: A01 não tem reinício automático. |
| 4 | Pule com Espaço e espere pousar. | Pulo e retorno ao piso. |
| 5 | Entre na área verde, saia e entre novamente. | Gatilho confirma; controle continua disponível. |
| 6 | Clique no botão novamente e feche normalmente. | Confirmação responde. F9 antes de fechar. |

Se falhar uma etapa, não a declare aprovada: marque F9 quando possível, informe o número e continue somente se fizer sentido. Poucos minutos bastam para conferir o coletor; não é benchmark final.

## 4. Demo — roteiro previsto, ainda não disponível

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

## 5. Arquivos e limites da análise

`package.json`: arquivos do pacote; `execution.json`: execução; `session.jsonl`: configuração/eventos/amostras/tempos; `engine.log`: mensagens complementares; `summary.json`: resumo; `relato.txt`: percepção. Reanalisar não apaga relato.

O resumo não aprova testes automaticamente. Evento do código não prova sprite/colisão/experiência corretos. Falta de amostras/eventos/rodapé, limite de tamanho ou registros descartados limita a conclusão. Editor/headless e pacote gráfico são condições diferentes.

Hoje os eventos cobrem A01. Combate, vida, habilidades, mundo e save terão eventos integrados nas atividades correspondentes. Coleta/análise assistidas não eliminam curadoria humana das conclusões. Esforço de revisão/correção fora do jogo precisa de relato breve, medido ou “não medido”.
