@MPS @UAT @TEST
Feature: CloudMPSGermanDealerCanCreateProposalFromProposalListPage
	In order to create a proposal from proposal list page
	As a dealer
	I want create new porposal button on proposal list page

Scenario Outline: MPS GermanAustria Dealer Can Create Proposal From Proposal List Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	And I begin the process of proposal creation process
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details 
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I move to Click Price page
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "<PaymentMethod>"
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
	| Role             | Country | ContractType             | CreateOption        | UsageType      | Contract | Billing         | PriceHardware | Printer      | DeviceScreen | PaymentMethod | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Austria | Easy Print Pro & Service | Create new customer | Mindestvolumen | 5 Jahre  | Vierteljährlich | Tick          | MFC-L8650CDW | Full         | Pay upfront   | 800         | 800          |
	| Cloud MPS Dealer | Germany | Easy Print Pro & Service | Create new customer | Mindestvolumen | 5 Jahre  | Vierteljährlich | Tick          | MFC-L8650CDW | Full         | Pay upfront   | 800         | 800          |
	