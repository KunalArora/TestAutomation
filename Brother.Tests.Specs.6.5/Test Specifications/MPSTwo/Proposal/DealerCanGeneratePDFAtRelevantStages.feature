@MPS @TEST @UAT
Feature: DealerCanGeneratePDFAtRelevantStages
	In order to generate Proposal PDF
	As a dealer
	I want to create a proposal for which a PDF for which a proposal can be downloaded

Scenario Outline: Dealer Can Generate PDF on Leasing Minimum Volume Summary Page 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details  
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then I can generate dealer PDF for the proposal
	And I can generate customer PDF for the proposal
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | UsageType      | Contract | Leasing                  | Billing                  | Printer     | DeviceScreen | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Minimum Volume | 4 years  | Quarterly | Quarterly | HLL8350CDW | Full         | 2000        | 2000         |
	
Scenario Outline: Dealer Can Generate PDF Leasing PAYG Summary Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details 
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I type in click price volume of "<ClickVolume>"
	Then I can generate customer PDF for the proposal
	And I can generate dealer PDF for the proposal
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | UsageType     | Contract | Leasing   | Billing   | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Pay As You Go | 5 years  | Quarterly | Quarterly | DCP8110DN | Full         | 2000        |


Scenario Outline: Dealer Can Generate PDF Purchase and Click Minimum Summary Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "<PaymentMethod>"
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then I can generate customer PDF for the proposal
	And I can generate dealer PDF for the proposal
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | UsageType      | Contract | Leasing                  | Billing                  | PriceHardware | Printer      | DeviceScreen | PaymentMethod           | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Minimum Volume | 3 years  | Quarterly | Quarterly | Untick          | MFC-L8650CDW | Reduced        | Included in Click Price | 2000        | 2000         |

Scenario Outline: Dealer Can Generate PDF Purchase and Click PAYG Summary Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts  
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And enter a quantity of "2" for model
	And I accept the default values of the device
	And I type in click price volume of "<ClickVolume>"
	Then I can generate customer PDF for the proposal
	And I can generate dealer PDF for the proposal
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Pay As You Go | 5 years  | Quarterly | Quarterly | Tick          | MFC-8510DN | Full         | 3000        |
	