# T06 — Execução de Lucas e diagnóstico do iniciador

Lucas jogou em **05/11/2026**, das 13:32:30 às 13:39:50 no horário de São Paulo. A análise P17 foi feita em 10/11/2026, com a implementação A06 integrada em `a31fac0`. Os 193 arquivos recebidos conferem com o manifesto da sessão e com o pacote usado por Caio em P16.

[Relato de Lucas](T06_Lucas_20261105T163226995-2a8811ab/relato.txt), [sessão](T06_Lucas_20261105T163226995-2a8811ab/session.jsonl), [resumo](T06_Lucas_20261105T163226995-2a8811ab/summary.json), [pacote](T06_Lucas_20261105T163226995-2a8811ab/package.json), [análise](T06_Lucas_20261105T163226995-2a8811ab/analise_P17.json) e [SHA-256](T06_Lucas_20261105T163226995-2a8811ab/SHA256.txt).

- Lucas relatou concluir o roteiro, com leve dificuldade nas trocas e nos testes de habilidades no ar devido à janela curta do pulo. Não percebeu problema visual ou de controle.
- A coleta terminou normalmente, com 434 amostras, 15 marcas F9 em ordem, um par de eventos de perda/retomada de foco e zero erros, avisos, descartes ou linhas inválidas. Há uma marca a menos que as 16 etapas previstas. A correspondência exata entre marca e etapa ficou indeterminada.
- Duas aquisições únicas, 15 saltos adicionais e 23 investidas aceitas, 13 delas no ar. Houve rejeições de troca por ação ocupada e de investida por intervalo, ação ocupada e habilidade ativa incorreta. A sessão de Lucas não contém a rejeição `air_use_spent`, que já aparece na execução de Caio.
- Dois reinícios manuais e três mortes com retorno seguro. O jogador voltou com 5/5 de vida e ambos os inimigos restaurados. As formas ativas nos retornos foram A, B e A, com as aquisições correspondentes preservadas.
- Duração do coletor de 438,228 s. Esforço humano e leitura de código por Lucas ficaram sem informação. A revisão de código/cenas e os 37 min de leitura do roteiro e testes de Caio permanecem registrados em P16.

O T06 registra as duas execuções funcionais e suas coberturas. A validação funcional da implementação atual pode ser encerrada com a lacuna de marcação e a dificuldade no ar documentadas. RF04 permanece parcial até a importação e conferência visual dos sprites humanos.

## Bloqueio ao iniciar o pacote

Na primeira tentativa, Lucas recebeu `UnauthorizedAccess` com a mensagem de que a execução de scripts estava desabilitada. O `Executar_Teste.cmd` chama `powershell.exe -NoProfile -File` para rodar `Executar_Teste.ps1`. A mensagem recebida identifica um bloqueio na carga do script antes da abertura do jogo. O relato confirma que Lucas mexeu na configuração de ExecutionPolicy antes da sessão bem-sucedida. O escopo, valor e eventual reversão dessa mudança ficaram sem informação.

Os dois arquivos `.ps1` recebidos têm `Zone.Identifier` com `ZoneId=3` na cópia local. Essa marca pode impedir a execução de scripts não assinados sob `RemoteSigned`. Ela não identifica a política efetiva de Lucas na primeira tentativa. Para levantar essa informação em outra ocorrência, abrir o **Windows PowerShell** e executar `Get-ExecutionPolicy -List`, que apenas consulta os escopos. [Políticas de execução do PowerShell](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-5.1)

O guia anterior orientava preservar a política de execução. Agora ele também inclui um caminho para as máquinas em que ela bloqueia o script.

## Alternativa para este pacote A06

Abra o **Prompt de Comando** na pasta descompactada que contém `Cyra.exe`. Use um nome de pasta novo para cada sessão e mantenha o mesmo nome nas três ocorrências do comando.

```bat
mkdir "TestResults\A06_Lucas_01"
start "" /wait "Cyra.exe" --log-file "%CD%\TestResults\A06_Lucas_01\engine.log" -- --cyra-test --cyra-machine=Lucas --cyra-scenario=A06 --cyra-build=package-5952a35952ec --cyra-output="%CD%\TestResults\A06_Lucas_01"
```

Siga o roteiro com F9 e feche o jogo normalmente. Escreva um `relato.txt` curto na pasta criada e devolva a pasta. A abertura direta gera `session.jsonl` e `engine.log`. O manifesto, o resumo e o formulário automático são funções do iniciador PowerShell. Informe qual pacote usou para a análise poder relacionar a sessão.

Em 10/11, a IA testou a abertura direta do executável local do mesmo pacote com `--headless --max-fps 60 --quit-after 120`. O processo retornou código 0, carregou a sala A06 e gravou início e fim da sessão. A abertura gráfica no computador de Lucas ainda precisa ser observada em uma próxima execução. [Registro do teste sem janela](T06_Lucas_20261105T163226995-2a8811ab/execucao_direta_sem_janela_P17.jsonl)
