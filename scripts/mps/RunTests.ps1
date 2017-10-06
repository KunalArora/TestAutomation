$env:PSModulePath
Import-Module ".\run-tests.psm1"

RunTests -TestAssembly "C:\projects\bie\automation\BrotherTestAutomation\Brother.MPS.Tests.Specs\bin\release\Brother.Tests.Specs.6.5.dll" -Category "BUKONLY"

"Done. Press any key."
cmd /c pause | out-null