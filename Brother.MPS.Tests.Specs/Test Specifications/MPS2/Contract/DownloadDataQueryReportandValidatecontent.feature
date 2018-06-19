@MPS @UAT @TEST @TYPE1 @LOW @MEDIUM
Feature: Type1DownloadDataQueryReportandValidatecontent
	In order to verify the finance of Cloud MPS service
	As a Cloud MPS Finance
	I can generate the financial reports and verify the content

Scenario Outline: Type1DownloadDataQueryReportandValidatecontent
Given I have navigated to the Open Proposals page as a Cloud MPS Dealer with AccountType is "Type1And3" from "<Country>"
And I will delete all Type 1 contracts that I have
And I Create a running contract "1" with below devices:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | 
		| DCP-8110DN   | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            | 
		| HL-5450DN    | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            | 
And I Create a running contract "2" with below devices:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-L8450CDW | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 20             | 250          |
When I click the 'Report' tab and click the 'Dealer Contract Report'
Then I is downloaded , open the file and ensure the the data are correct

@BUK
Scenarios: 
		| Country        |
		| United Kingdom |

