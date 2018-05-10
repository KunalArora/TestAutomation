Import-Module ".\run-tests.psm1"

# USAGE NOTES
# Ensure -TestAssembly path is correct for the machine on which the tests are running. If this script is in the same folder as the test assembly, just specify the assembly filename and -UseRelativePath $true
# The -Category parameter specifies one or more categories to run, separated by commas. Required.
# -Env is one of DEV, TEST, UAT or PROD. Default is UAT.
# -LoggingLevel is one of DEBUG,INFO,WARNING or FAILURE. Default is INFO.
# -ExploreOnly is $true by default here, this allows you to examine the list of tests in the specified categories without actually running them. Set to $false when you want to pull the trigger!
# -UseRelativePath is $false by default which requires a full path to be supplied for -TestAssembly

RunTests -TestAssembly "Brother.Tests.Specs.6.5.dll" -Category "CRITICAL,HIGH" -UseRelativePath $true -ExploreOnly $true 

"Done. Press any key."
cmd /c pause | out-null