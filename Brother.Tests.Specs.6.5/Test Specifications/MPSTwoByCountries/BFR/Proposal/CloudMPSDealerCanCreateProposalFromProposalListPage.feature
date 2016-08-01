@MPS @UAT @TEST
Feature: CloudMPSFrenchDealerCanCreateProposalFromProposalListPage
	In order to create a proposal from proposal list page
	As a dealer
	I want create new porposal button on proposal list page

Scenario Outline: Dealer Can Create Proposal From Proposal List Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	And I begin the process of proposal creation process
	When I fill Proposal Description for "<ContractType>" Contract type
	And I skip contact creation process
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I move to Click Price page
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "<PaymentMethod>"
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then the billing basis for product is "<Basis2>"
	And the billing basis for Accessory is "<Basis2>"
	And the billing basis for Installation is "<Basis2>"
	And the billing basis for Service Pack is "<Basis2>"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	And the service pack name and price displayed are correct
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the displayed volume value for colour click price is "<ColourVolume>"
	And the calculated consumable net totals are equal in all places
	And the calculated consumable gross totals are equal in all places
	And the displayed mono click price is correct
	And the displayed colour click price is correct
	And the calculations are not based on estimated values
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS

	


Scenarios: 
	| Role             | Country        | ContractType                  | UsageType                                 | Contract | Billing                 | PriceHardware | Printer      | DeviceScreen | PaymentMethod                    | ClickVolume | ColourVolume | Basis1                        | Basis2                           |
	| Cloud MPS Dealer | France         | Buy & Click                   | Engagement sur un minimum volume de pages | 3 ans    | Trimestrale anticipata  | Tick          | MFC-L8650CDW | Full         | Paiement au démarrage du contrat | 800         | 800          | Inclus dans le coût à la page | Paiement au démarrage du contrat |
	
