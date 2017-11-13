$env:PSModulePath
Import-Module ".\run-tests.psm1"

# USAGE NOTES
# Ensure -TestAssembly path is correct for the machine on which the tests are running
# The -Category parameter specifies one or more categories to run, separated by commas
# -ExploreOnly is $true by default here, this allows you to examine the list of tests in the specified categories without actually running them. Set to $false when you want to pull the trigger!

RunTests -TestAssembly "C:\projects\bie\automation\BrotherTestAutomation\Brother.MPS.Tests.Specs\bin\release\Brother.Tests.Specs.6.5.dll" -Category "CRITICAL,HIGH" -ExploreOnly $true

"Done. Press any key."
cmd /c pause | out-null