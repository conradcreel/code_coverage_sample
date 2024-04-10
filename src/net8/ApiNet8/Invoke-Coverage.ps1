if (!(Get-Command reportgenerator -ErrorAction:SilentlyContinue)) {

    Write-Error "Cannot find reportgenerator`n"

    Write-Host "Consider: dotnet tool install --global dotnet-reportgenerator-globaltool --interactive"

    exit

}

 

Push-Location $PSScriptRoot

try {

    $dir = Join-Path $(if ($env:TEMP) { $env:TEMP } else { '/tmp' }) ("coverage-" + (Get-Date -Format s) -replace ':', '.')

    Write-Host "`nRunning Tests..."

    dotnet test --configuration Debug --results-directory $dir --collect "XPlat Code coverage" -- RunConfiguration.DisableAppDomain=true

    if (!$?) { exit }


    Write-Host "`nGenerating Coverage Report..."

    reportgenerator -reports:$dir/**/coverage.cobertura.xml -targetdir:$dir -reporttypes:"Html"


    $outfile = Join-Path $dir "index.html"

    Write-Host "`nViewing Coverage Report $outfile..."

    Invoke-Item $outfile

}

finally {

    Pop-Location

}