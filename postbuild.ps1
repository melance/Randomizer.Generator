Write-Host("Randomizer.Generator Post Build");
Write-Host("Copying Randomizer.Generator.CmdLine");
If (!(Test-Path C:\Users\me_la\source\repos\Randomizer.Generator\bin\Debug\net5.0))
{
    New-Item -Path C:\Users\me_la\source\repos\Randomizer.Generator\bin\Debug\net5.0
}
Copy-Item -Path C:\Users\me_la\source\repos\Randomizer.Generator\Randomizer.Generator.CmdLine\bin\Release\net5.0\* -Destination C:\Users\me_la\source\repos\Randomizer.Generator\bin\Release\net5.0 -Recurse -Force
Write-Host("Copying Randomizer.Generator.UI.Terminal");
Copy-Item -Path C:\Users\me_la\source\repos\Randomizer.Generator\Randomizer.Generator.UITerminal\bin\Release\net5.0\* -Destination C:\Users\me_la\source\repos\Randomizer.Generator\bin\Release\net5.0 -Recurse -Force