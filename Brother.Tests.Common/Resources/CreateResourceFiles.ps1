$supportedCultures = "da-dk",
"de-at",
"de-ch",
"de-de",
"en",
"en-ie",
"es-es",
"fi-fi",
"fr-be",
"fr-ch",
"fr-fr",
"it-it",
"nb-no",
"nl-be",
"nl-nl",
"pl-pl",
"sv-se"

function CreateResourceFiles(){
    
    param(
        [string] $DestinationPath,
        [string] $DefaultCultureFileName
    )

    $sourceFile = $DefaultCultureFileName + ".resx"

    cd $DestinationPath

    if(-Not (Test-Path $sourceFile)){
        $(throw "Source file '$sourceFile' not found")
        
    }

    Foreach($culture in $supportedCultures){
        $destinationFileName = "$DefaultCultureFileName.$culture.resx"
        if(Test-Path $destinationFileName){
            Write-Host "Skipping culture $culture, file already exists"
        }else{
            Write-Host $sourceFile
            Write-Host "Creating file $destinationFileName"
            Copy-Item -Path $sourceFile -Destination $destinationFileName
        }
    }
}

#ContractType used as example - change params to actual folder and filename (without .resx extension) as required
CreateResourceFiles -DestinationPath ".\ContractType\" -DefaultCultureFileName "ContractType" 

pause