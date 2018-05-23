Import-Module ".\run-tests.psm1"

# This is an example which shows how to use the RunTests module

RunTests -TestAssembly "Brother.Tests.Specs.6.5.dll" -Category "CRITICAL,HIGH" -UseRelativePath $true -ExploreOnly $true -AdditionalParams 'param1=value1;param2=value2'

"Done. Press any key."
cmd /c pause | out-null