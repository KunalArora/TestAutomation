@MPS @UAT @TEST @TYPE1 @LOW @MEDIUM
Feature: Type1DownloadDataQueryReportandValidateContent
	In order to sell high quality Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to verify the smooth download of data query report and validate its content
	https://brother-bie.atlassian.net/browse/MPS-4962

Scenario Outline: Type1DownloadDataQueryReportandValidateContent
Given I have navigated to the Open Proposals page as a Cloud MPS Dealer with AccountType is "Type1And3" from "<Country>"
And I will delete all Type 1 contracts that I have
And I create a running contract "1" with below devices:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | 
		| DCP-8110DN   | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            | 
		| HL-5450DN    | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            | 
And I create a running contract "2" with below devices:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-L8450CDW | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 20             | 250          |
When I click the 'Report' tab and click the 'Dealer Contract Report'
Then I can download, open the file and ensure the data is correct

@BUK
Scenarios: 
		| Country        |
		| United Kingdom |

