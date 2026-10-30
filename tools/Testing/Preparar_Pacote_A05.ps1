param([string]$Destino = '')
$ErrorActionPreference = 'Stop'
$projectRoot = (Resolve-Path -LiteralPath (Join-Path $PSScriptRoot '..\..')).Path
if (-not $Destino) { $Destino = Join-Path $projectRoot 'build\a05-test' }
$packagePath = (Resolve-Path -LiteralPath $Destino).Path
foreach ($name in @('Cyra.exe','Cyra.pck')) {
    if (-not (Test-Path -LiteralPath (Join-Path $packagePath $name) -PathType Leaf)) {
        throw ('Exportacao A05 incompleta: falta ' + $name)
    }
}
# Apenas ferramentas atuais; nunca copiar iniciadores recebidos nas evidencias.
foreach ($name in @('Executar_Teste.cmd','Executar_Teste.ps1','Analisar_Logs.ps1')) {
    Copy-Item -LiteralPath (Join-Path $PSScriptRoot $name) -Destination (Join-Path $packagePath $name) -Force
}
Copy-Item -LiteralPath (Join-Path $projectRoot 'docs\Guia_Lucas_Testes.md') -Destination (Join-Path $packagePath 'Guia_Lucas_Testes.md') -Force
$baseline = (& git -C $projectRoot rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0) { throw 'Nao foi possivel identificar a base Git da exportacao.' }
$descriptor = [ordered]@{
    schema = 1; scenario = 'A05'; main_scene = 'res://Scenes/Test/TestRoomA05.tscn'
    source_baseline = $baseline; source_generation = 'D06'
    source_state = 'Conferir alteracoes locais; base Git nao e commit integrado desta geracao.'
    human_validation = 'pending'; identity = 'package.json por sessao, gerado pelo iniciador'
}
[IO.File]::WriteAllText((Join-Path $packagePath 'test-package.json'), ($descriptor | ConvertTo-Json -Depth 4), [Text.UTF8Encoding]::new($false))
Write-Host ('Pacote A05 preparado em ' + $packagePath + '; enviar a pasta completa. Revisao humana pendente.')
