@TEST @UAT
Feature: CreateAProposalViaFlatListView
	In order to create a proposal via flat list view
	As an MPS Dealer
	I want to be to change the view of product page to flat list view


Scenario Outline: Dealer can create proposal from flat list view
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to the Term and Type page
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	When I changed the Product view to flat list
	And I select "<Printer>" from the product flat list
	Then I can successfully create the proposal above with "<ClickVolume>" and "<ColourVolume>"


	Scenarios: 

	| Role             | Country | Contract | Leasing                    | Billing                    | Printer     | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | 3 Jahre  | 4 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | HL-L8250CDN | 800         | 2000         |
