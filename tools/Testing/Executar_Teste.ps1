param(
    [string]$Executavel = "",
    [ValidateSet('Lucas','Caio','Victor','NaoInformada')][string]$Maquina = 'NaoInformada',
    [ValidateSet('A01','A05','DEMO')][string]$Cenario = 'A05',
    [switch]$VerificacaoSemJanela,
    [switch]$PerguntarMaquina
)
$ErrorActionPreference = 'Stop'

if ($PerguntarMaquina -and -not $PSBoundParameters.ContainsKey('Maquina')) {
    Write-Host 'Computador usado neste teste: 1 - Lucas; 2 - Caio; 3 - Victor; 0 - outro/nao informado'
    $choice = Read-Host 'Escolha o numero'
    switch ($choice) {
        '1' { $Maquina = 'Lucas' }
        '2' { $Maquina = 'Caio' }
        '3' { $Maquina = 'Victor' }
        '0' { $Maquina = 'NaoInformada' }
        default { throw 'Escolha invalida. Nenhum jogo foi iniciado; execute novamente e informe 0, 1, 2 ou 3.' }
    }
}

# A03: inicia uma sessão local; nenhuma permissão, save ou regra do jogo é alterada.
if (-not $Executavel) {
    $Executavel = Join-Path $PSScriptRoot 'Cyra.exe'
    if (-not (Test-Path -LiteralPath $Executavel -PathType Leaf)) {
        $relativePackage = if ($Cenario -eq 'A05') { '..\..\build\a05-test\Cyra.exe' } else { '..\..\build\a03-test\Cyra.exe' }
        $Executavel = Join-Path $PSScriptRoot $relativePackage
    }
}
if (-not (Test-Path -LiteralPath $Executavel -PathType Leaf)) {
    throw 'Pacote atualizado nao encontrado. Para A05 use build/a05-test; para A01 use build/a03-test ou informe -Executavel. Copie as ferramentas atuais junto do pacote completo.'
}
$gamePath = (Resolve-Path -LiteralPath $Executavel).Path
$packagePath = Split-Path -Parent $gamePath
$descriptorPath = Join-Path $packagePath 'test-package.json'
if (Test-Path -LiteralPath $descriptorPath -PathType Leaf) {
    $descriptor = Get-Content -LiteralPath $descriptorPath -Raw -Encoding UTF8 | ConvertFrom-Json
    if ($descriptor.scenario -ne $Cenario) { throw ('Cenario solicitado difere do pacote: ' + $Cenario + ' / ' + $descriptor.scenario) }
}
elseif ($Cenario -eq 'A05') {
    throw 'Pacote A05 sem test-package.json. Use a exportacao A05 preparada; nao rotule um pacote A01 como A05.'
}
$runId = (Get-Date).ToUniversalTime().ToString('yyyyMMddTHHmmssfffZ') + '-' + [Guid]::NewGuid().ToString('N').Substring(0,8)
$resultsPath = Join-Path $packagePath ('TestResults\' + $runId)
New-Item -ItemType Directory -Path $resultsPath -Force | Out-Null

# Identifica os arquivos executáveis/dados, sem exigir Git na máquina do executor.
$files = @(Get-ChildItem -LiteralPath $packagePath -Recurse -File | Where-Object {
    -not $_.FullName.StartsWith((Join-Path $packagePath 'TestResults') + '\', [StringComparison]::OrdinalIgnoreCase) -and
    $_.Extension -in '.exe','.dll','.pck','.json','.ps1','.cmd','.md'
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
# Templates release nao aceitam --scene: a cena principal vem da exportacao.
if ($VerificacaoSemJanela) {
    # Exclusivo do ensaio técnico do coletor, sem benchmark gráfico ou teste humano.
    $arguments = '--headless --max-fps 60 --quit-after 120 ' + $arguments
}
$startedUtc = (Get-Date).ToUniversalTime().ToString('o')
$launch = @{ FilePath = $gamePath; ArgumentList = $arguments; WorkingDirectory = $packagePath; PassThru = $true }
if ($VerificacaoSemJanela) { $launch.WindowStyle = 'Hidden' }
$process = Start-Process @launch
$process.WaitForExit()
$exitCode = $process.ExitCode

Write-JsonFile 'execution.json' ([ordered]@{ schema = 1; machine_label = $Maquina; scenario = $Cenario; protocol = 'A03-v2'; package_id = $packageId; started_utc = $startedUtc; ended_utc = (Get-Date).ToUniversalTime().ToString('o'); status = 'process_exited'; exit_code = $exitCode })
& (Join-Path $PSScriptRoot 'Analisar_Logs.ps1') -Pasta $resultsPath
