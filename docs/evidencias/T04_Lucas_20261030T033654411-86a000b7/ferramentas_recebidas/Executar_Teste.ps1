param(
    [string]$Executavel = "",
    [ValidateSet('Lucas','Caio','Victor')][string]$Maquina = 'Lucas',
    [ValidateSet('A01','DEMO')][string]$Cenario = 'A01',
    [switch]$VerificacaoSemJanela
)
$ErrorActionPreference = 'Stop'

# A03: inicia uma sessão local; nenhuma permissão, save ou regra do jogo é alterada.
if (-not $Executavel) {
    $Executavel = Join-Path $PSScriptRoot 'Cyra.exe'
    if (-not (Test-Path -LiteralPath $Executavel -PathType Leaf)) {
        $Executavel = Join-Path $PSScriptRoot '..\..\build\windows\Cyra.exe'
    }
}
if (-not (Test-Path -LiteralPath $Executavel -PathType Leaf)) {
    throw 'Cyra.exe não encontrado. Copie os quatro arquivos de tools/Testing junto do pacote exportado.'
}
$gamePath = (Resolve-Path -LiteralPath $Executavel).Path
$packagePath = Split-Path -Parent $gamePath
$runId = (Get-Date).ToUniversalTime().ToString('yyyyMMddTHHmmssfffZ') + '-' + [Guid]::NewGuid().ToString('N').Substring(0,8)
$resultsPath = Join-Path $packagePath ('TestResults\' + $runId)
New-Item -ItemType Directory -Path $resultsPath -Force | Out-Null

# Identifica os arquivos executáveis/dados, sem exigir Git na máquina do executor.
$files = @(Get-ChildItem -LiteralPath $packagePath -Recurse -File | Where-Object {
    -not $_.FullName.StartsWith((Join-Path $packagePath 'TestResults') + '\', [StringComparison]::OrdinalIgnoreCase) -and
    $_.Extension -in '.exe','.dll','.pck','.json'
} | Sort-Object FullName | ForEach-Object {
    [pscustomobject]@{ path = $_.FullName.Substring($packagePath.Length + 1).Replace('\','/'); sha256 = (Get-FileHash -LiteralPath $_.FullName -Algorithm SHA256).Hash; bytes = $_.Length }
})
$identityText = ($files | ForEach-Object { $_.path + ':' + $_.sha256 }) -join "`n"
$hasher = [System.Security.Cryptography.SHA256]::Create()
try { $packageId = ([BitConverter]::ToString($hasher.ComputeHash([Text.Encoding]::UTF8.GetBytes($identityText)))).Replace('-','').ToLowerInvariant() }
finally { $hasher.Dispose() }
$buildLabel = 'package-' + $packageId.Substring(0,12)
$utf8 = New-Object System.Text.UTF8Encoding($false)
function Write-JsonFile($Name, $Value) {
    [IO.File]::WriteAllText((Join-Path $resultsPath $Name), ($Value | ConvertTo-Json -Depth 12), $utf8)
}
Write-JsonFile 'package.json' ([ordered]@{ schema = 1; package_id = $packageId; files = $files })
Write-JsonFile 'execution.json' ([ordered]@{ schema = 1; machine_label = $Maquina; scenario = $Cenario; protocol = 'A03-v2'; package_id = $packageId; started_utc = (Get-Date).ToUniversalTime().ToString('o'); status = 'started' })

Write-Host 'Teste iniciado. Siga o Guia_Lucas_Testes.md; F9 marca a próxima etapa.'
Write-Host ('Resultados: ' + $resultsPath)
$arguments = '--log-file "' + (Join-Path $resultsPath 'engine.log') + '" -- --cyra-test --cyra-machine=' + $Maquina + ' --cyra-scenario=' + $Cenario + ' --cyra-protocol=A03-v2 --cyra-build=' + $buildLabel + ' --cyra-output="' + $resultsPath + '"'
if ($VerificacaoSemJanela) {
    # Exclusivo do ensaio técnico do coletor, sem benchmark gráfico ou teste humano.
    $arguments = '--headless --max-fps 60 --quit-after 120 ' + $arguments
}
$startedUtc = (Get-Date).ToUniversalTime().ToString('o')
$process = Start-Process -FilePath $gamePath -ArgumentList $arguments -WorkingDirectory $packagePath -PassThru
$process.WaitForExit()
$exitCode = $process.ExitCode

Write-JsonFile 'execution.json' ([ordered]@{ schema = 1; machine_label = $Maquina; scenario = $Cenario; protocol = 'A03-v2'; package_id = $packageId; started_utc = $startedUtc; ended_utc = (Get-Date).ToUniversalTime().ToString('o'); status = 'process_exited'; exit_code = $exitCode })
& (Join-Path $PSScriptRoot 'Analisar_Logs.ps1') -Pasta $resultsPath
