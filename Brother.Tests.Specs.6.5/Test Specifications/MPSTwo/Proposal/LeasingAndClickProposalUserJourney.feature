@TEST @UAT
Feature: LeasingAndClickProposalUserJourney
	In order to create different variety of leasing proposal
	As a dealer 
	I want to be able to use different MPS parameters to derive different leasing proposal


Scenario Outline: Create different varieties of Leasing and Click proposal for new customer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture
	#And I "<Liable>" Private Liable for Company Info
	#And I "<OrderConsumable>" Customer added can order consumables
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details  
	#And Price Hardware radio button is not displayed for leasing contract type
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	#And Service Pack payment method is not displayed
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Leasing>" displayed on proposal Summary Page corresponds to "<Leasing>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS

	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType      | Contract | Leasing                  | Billing                  | Printer     | DeviceScreen | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Minimum Volume | 3 years  | 4 Monthly Minimum Volume | 6 Monthly Minimum Volume | HL-L8350CDW | Full         | 2000        | 2000         |
	

Scenario Outline: Create different varieties of Leasing and Click proposal for new customer on Pay As You Go Term
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture
	#And I "<Liable>" Private Liable for Company Info
	#And I "<OrderConsumable>" Customer added can order consumables
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details  
	#And Price Hardware radio button is not displayed for leasing contract type
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	#And Service Pack payment method is not displayed
	And I type in click price volume of "<ClickVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Leasing>" displayed on proposal Summary Page corresponds to "<Leasing>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS

	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType     | Contract | Leasing   | Billing   | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 4 years  | 6 Monthly | 4 Monthly | DCP-8110DN | Full         | 2000        |


Scenario Outline: Create different varieties of Leasing and Click proposal for an existing customer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details  
	#And Price Hardware radio button is not displayed for leasing contract type
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	#And Service Pack payment method is not displayed
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Leasing>" displayed on proposal Summary Page corresponds to "<Leasing>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | UsageType      | Contract | Leasing                  | Billing                  | Printer     | DeviceScreen | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Minimum Volume | 4 years  | 4 Monthly Minimum Volume | 6 Monthly Minimum Volume | HL-L8350CDW | Full         | 2000        | 2000         |
	
Scenario Outline: Create different varieties of Leasing and Click proposal for an existing customer on Pay As You Go
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details  
	#And Price Hardware radio button is not displayed for leasing contract type
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	#And Service Pack payment method is not displayed
	And I type in click price volume of "<ClickVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Leasing>" displayed on proposal Summary Page corresponds to "<Leasing>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | UsageType     | Contract | Leasing   | Billing   | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Pay As You Go | 5 years  | 6 Monthly | 4 Monthly | DCP-8110DN | Full         | 2000        |
