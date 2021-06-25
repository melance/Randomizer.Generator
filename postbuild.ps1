Write-Host("Randomizer.Generator Post Build");
Write-Host("Copying Randomizer.Generator.CmdLine");
If (!(Test-Path .\bin\Debug\net5.0))
{
    New-Item -Path .\bin\Debug\net5.0
}
Copy-Item -Path ..\Randomizer.Generator.CmdLine\bin\Debug\net5.0\* -Destination .\bin\Debug\net5.0 -Recurse -Force
Write-Host("Copying Randomizer.Generator.UITermincal");
Copy-Item -Path .\bin\Debug\net5.0\* -Destination ..\bin\Debug\net5.0 -Recurse -Force