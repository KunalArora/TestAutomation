@TEST @UAT @MPS
Feature: CloudMPSEnteringLargeEstimatedVolumeForGermany
	In order to ensure that Click Price page is not broken
	As a dealer 
	I want a friendly error to be displayed when a very large estimated click volume enter through PAYG


Scenario Outline: MPS GermanyAustria Force Error Message By Entering Large Estimated Volume
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details  
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I type in large click volume of "<ClickVolume>"
	Then appropriate error message is displayed
	And calculate button is disabled
	And I can sign out of Brother Online


Scenarios: 
	| Role             | Country | ContractType      | CreateOption        | UsageType     | Contract | Leasing   | Billing      | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | Germany | Leasing & Service | Create new customer | Pay As You Go | 4 Jahre  | Monatlich | Halbjährlich | DCP-8110DN | Full         | 1000000000  |
	| Cloud MPS Dealer | Austria | Leasing & Service | Create new customer | Pay As You Go | 4 Jahre  | Monatlich | Halbjährlich | DCP-8110DN | Full         | 1000000000  |
	
