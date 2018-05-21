Import-Module ".\run-tests.psm1"

RunTests -TestAssembly "..\Brother.Tests.Specs.6.5.dll" -Category "SMOKE,TYPE3" -UseRelativePath $true

"Done. Press any key."
cmd /c pause | out-null