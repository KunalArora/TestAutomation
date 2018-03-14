Import-Module '.\ExecuteMpsWebTool.psm1'
$date = Get-Date -Format "yyyyMMdd-HHmmss"
$computerName = hostname
$OutputPath = "\\bie02s\erp\MPS-PrintSmart\MPS2 2015 Project Directory\test automation\$computerName\$date"
$TestAssembly = "C:\automation\mps-release\Brother.Tests.Specs.6.5.dll"

$nunitPath = "C:\program files (x86)\NUnit.org\nunit-console\"
$nunitCommand = "C:\program files (x86)\NUnit.org\nunit-console\nunit3-console"
$outputFile = "$outputPath\log-$date.txt"
$agreementDeletionThreshold = 20

cd $nunitPath
$outputPath
$outputFile

Test-Path $outputPath

if( -Not (Test-Path $OutputPath ) )
{
	New-Item $OutputPath -ItemType directory
}

$result = (.\nunit3-console.exe $TestAssembly --where:"cat = ENDTOEND && cat = TYPE3" --result=$outputFile --params="env=UAT;logging_level=DEBUG;output_path='$OutputPath\'")

##Example of how to run a specific test
#.\nunit3-console.exe $TestAssembly --where:"cat = ENDTOEND && cat = TYPE3 && name == BusinessScenario4" --result=$outputFile --params="env=UAT;logging_level=DEBUG;output_path='$OutputPath\'"

$result

if((@($result) -like '*Overall result: Passed').Count -gt 0){
    "All tests passed - removing agreements with threshold $agreementDeletionThreshold"
    ExecuteMpsWebTool -WebToolPath "automation/deletet3agreementsfordealership.aspx" -Querystring "dealershipemail=mps-buk-uat-dealer9@brother.co.uk&threshold=$agreementDeletionThreshold" -Env 'UAT'
}else{
    "One or more tests failed"
}

"Done. Press any key."
cmd /c pause | out-null