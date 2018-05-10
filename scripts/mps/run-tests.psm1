function RunTests(){

	# USAGE NOTES
	# Ensure -TestAssembly path is correct for the machine on which the tests are running. If this script is in the same folder as the test assembly, just specify the assembly filename and -UseRelativePath $true
	# The -Category parameter specifies one or more categories to run, separated by commas. Required. 
	# -Env is one of DEV, TEST, UAT or PROD. Default is UAT.
	# -LoggingLevel is one of DEBUG,INFO,WARNING or FAILURE. Default is INFO.
	# -ExploreOnly is $true by default here, this allows you to examine the list of tests in the specified categories without actually running them. Set to $false when you want to pull the trigger!
	# -UseRelativePath is $false by default which requires a full path to be supplied for -TestAssembly
	# -AdditionalParams is used to pass arbitrary command line parameters to Nunit

    param(
        [string]$TestAssembly = $(throw "Test assembly must be specified"),
        [string]$Category = $(throw "Category must be specified"),
        [string]$OutputPath,
        [string]$Env = "UAT",
		[string]$LoggingLevel = "INFO",
		[bool]$UseRelativePath = $false,
        [bool]$ExploreOnly,
		[string]$AdditionalParams
    )

    $date = Get-Date -Format "yyyyMMdd-HHmmss"
    $computerName = hostname
    $exploreOption = ""
	$scriptPath = Get-Location

	if(-Not [string]::IsNullOrEmpty($AdditionalParams)){
		$AdditionalParams = ';' + $AdditionalParams
	}
	
	if($UseRelativePath){
		$TestAssembly = $scriptPath.Path + "\$TestAssembly"
	}
	
    $explodedCats = $Category.Split(",")
    $catSelect = ""

    foreach($cat in $explodedCats){
    if(-Not ($catSelect -eq "")){
        $catSelect = $catSelect + " & "
    }
        $catSelect = $catSelect + "cat = $cat & cat = MPS"
    }

    if($ExploreOnly)
    {
        $exploreOption = "--explore"
    }

    if([string]::IsNullOrEmpty($OutputPath)){
        $OutputPath = "\\bie02s\erp\MPS-PrintSmart\MPS2 2015 Project Directory\test automation\$computerName\$date"
    }

    $nunitPath = "C:\program files (x86)\NUnit.org\nunit-console\"
    $nunitCommand = "C:\program files (x86)\NUnit.org\nunit-console\nunit3-console"
    $outputFile = "$outputPath\log-$date.txt"

    cd $nunitPath
	
    if( -Not (Test-Path $OutputPath ) )
    {
        New-Item $OutputPath -ItemType directory
    }

    .\nunit3-console.exe $TestAssembly --where:"$catSelect" --result=$outputFile --params="env=$Env;output_path='$OutputPath\';logging_level=$LoggingLevel$AdditionalParams" $exploreOption

}