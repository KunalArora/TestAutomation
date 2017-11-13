function RunTests(){

    param(
        [string]$TestAssembly = $(throw "Test assembly must be specified"),
        [string]$category = $(throw "Category must be specified"),
        [string]$OutputPath,
        [string]$Env = "UAT",
        [bool]$ExploreOnly
    )

    $date = Get-Date -Format "yyyyMMdd-HHmmss"
    $computerName = hostname
    $exploreOption = ""

    $explodedCats = $Category.Split(",")
    $catSelect = ""

    foreach($cat in $explodedCats){
    if(-Not ($catSelect -eq "")){
        $catSelect = $catSelect + " || "
    }
        $catSelect = $catSelect + "cat = $cat"
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
    $outputPath
    $outputFile
    #Write-Host "ExploreOnly: $ExploreOnly exploreOption: $exploreOption"

    Test-Path $outputPath

    if( -Not (Test-Path $OutputPath ) )
    {
        New-Item $OutputPath -ItemType directory
    }

    .\nunit3-console.exe $TestAssembly --where:"$catSelect" --result=$outputFile --params="env=$Env;output_path='$OutputPath\'" $exploreOption

}