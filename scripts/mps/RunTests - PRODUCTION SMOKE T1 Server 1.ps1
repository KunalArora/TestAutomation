Import-Module ".\run-tests.psm1"

RunTests -TestAssembly "..\Brother.Tests.Specs.6.5.dll" -Env PROD -Category "PRODUCTIONSMOKE,TYPE1" -UseRelativePath $true -AdditionalParams 'base_url=http://p1.online.brother.co.uk;dealer_username=MPS-BUK-Prod-Dealer1@brother.co.uk;dealer_password=UKdealer1;local_office_approver_username=MPS-BUK-PROD-LOApprover@brother.co.uk;local_office_approver_password=UKloapprover1'

"Done. Press any key."
cmd /c pause | out-null