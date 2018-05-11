Import-Module ".\run-tests.psm1"

RunTests -TestAssembly "..\Brother.Tests.Specs.6.5.dll" -Env PROD -Category "SERVER1" -UseRelativePath $true

"Done. Press any key."
cmd /c pause | out-null