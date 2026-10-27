param([Parameter(Mandatory=$true)][string]$Pasta)
$ErrorActionPreference = 'Stop'
$resultsPath = (Resolve-Path -LiteralPath $Pasta).Path
$execution = Get-Content -LiteralPath (Join-Path $resultsPath 'execution.json') -Raw -Encoding UTF8 | ConvertFrom-Json
$Maquina = $execution.machine_label
$Cenario = $execution.scenario
$packageId = $execution.package_id
$exitCode = $execution.exit_code
$utf8 = New-Object System.Text.UTF8Encoding($false)
function Write-JsonFile($Name, $Value) {
    [IO.File]::WriteAllText((Join-Path $resultsPath $Name), ($Value | ConvertTo-Json -Depth 12), $utf8)
}
# Analisa somente registros realmente presentes; uma última linha incompleta é relatada.
$records = @()
$invalidLines = 0
$sessionPath = Join-Path $resultsPath 'session.jsonl'
if (Test-Path -LiteralPath $sessionPath) {
    $records = @(Get-Content -LiteralPath $sessionPath -Encoding UTF8 | ForEach-Object {
        try { $_ | ConvertFrom-Json -ErrorAction Stop } catch { $invalidLines++ }
    })
}
$samples = @($records | Where-Object { $_.kind -eq 'sample' })
$fps = @($samples | ForEach-Object { $_.data.fps_last_second } | Sort-Object)
$private = @($samples | Where-Object { $null -ne $_.data.private_bytes } | ForEach-Object { [long]$_.data.private_bytes })
$median = $null
if ($fps.Count) {
    $middle = [int][Math]::Floor($fps.Count / 2)
    if ($fps.Count % 2) { $median = $fps[$middle] }
    else { $median = ($fps[$middle-1] + $fps[$middle]) / 2 }
}
$start = @($records | Where-Object { $_.kind -eq 'session_start' })
$end = @($records | Where-Object { $_.kind -eq 'session_end' })
$truncated = @($records | Where-Object { $_.kind -eq 'logging_stopped' }).Count -gt 0
$dropped = 0
foreach ($record in $records) {
    if ($record.data -and $record.data.dropped_records -gt $dropped) { $dropped = $record.data.dropped_records }
}
$complete = $start.Count -eq 1 -and $end.Count -eq 1 -and -not $truncated -and $invalidLines -eq 0 -and $dropped -eq 0
$memory = $null
if ($private.Count) {
    $memory = [ordered]@{ samples = $private.Count; first_bytes = $private[0]; last_bytes = $private[-1]; max_bytes = ($private | Measure-Object -Maximum).Maximum; delta_bytes = $private[-1] - $private[0] }
}
Write-JsonFile 'summary.json' ([ordered]@{
    schema = 1; protocol = 'A03-v2'; machine_label = $Maquina; scenario = $Cenario; package_id = $packageId
    exit_code = $exitCode; collector_complete = $complete; invalid_json_lines = $invalidLines; dropped_records = $dropped
    headless = if ($start.Count) { $start[0].data.headless } else { $null }
    performance_assessment = if (-not $start.Count -or -not $samples.Count) { 'unavailable_missing_telemetry' } elseif ($start[0].data.headless) { 'not_applicable_headless' } else { 'descriptive_only_requires_review' }
    sample_count = $samples.Count; fps_median = $median; fps_sample_min = if ($fps.Count) { $fps[0] } else { $null }
    private_memory = $memory
    engine_errors = @($records | Where-Object { $_.kind -eq 'engine_error' -and $_.data.error_type -ne 1 }).Count
    engine_warnings = @($records | Where-Object { $_.kind -eq 'engine_error' -and $_.data.error_type -eq 1 }).Count
    human_markers = @($records | Where-Object { $_.kind -eq 'human_step_marker' }).Count
    automatic_test_verdict = 'not_assigned'
    limitations = 'FPS agregado, memória do processo e eventos instrumentados. Ausência de erro não comprova aprovação funcional; dados do editor/headless não são benchmark release; sem prova de ausência de vazamento.'
})
$note = @"
Relato curto de Lucas (ou executor):
1. Conseguiu concluir o roteiro? Se não, até qual etapa?
2. Algo visual/de controle diferente do esperado? Etapa/F9 e descrição, ou "nada percebido".
3. Houve interrupção externa, mudança de foco ou erro ao iniciar? Descreva, se houve.

Não é necessário transcrever FPS/memória nem preencher tabelas manualmente.
Os dados não medem tempo de revisão/correção fora do jogo.
"@
if (-not (Test-Path -LiteralPath (Join-Path $resultsPath 'relato.txt'))) {
    [IO.File]::WriteAllText((Join-Path $resultsPath 'relato.txt'), $note, $utf8)
}
Write-Host 'Coleta encerrada. Preencha somente relato.txt e envie a pasta inteira para análise.'
Write-Host ('Resultados: ' + $resultsPath)
if (-not $start.Count) {
    Write-Warning 'O jogo nao iniciou o coletor: session.jsonl ausente/sem cabecalho. Pacote antigo ou falha de inicializacao; conferir engine.log e usar o pacote atualizado. A partida visual nao valida a coleta.'
}
elseif (-not $complete) { Write-Warning 'Coleta incompleta/limitada: conferir summary.json antes de interpretar os dados.' }
