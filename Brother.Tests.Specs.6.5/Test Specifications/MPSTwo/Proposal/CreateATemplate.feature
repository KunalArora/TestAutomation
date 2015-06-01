@UAT @TEST
Feature: Proposal Create a Template
	In order to create a proposal from an existing template
	As an MPS Dealer
	I want to create a proposal template

@SMOKE
Scenario Outline: Fill necessary fields on Proposal Description Screen
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	#And I navigate to Dealer Dashboard page
	And I am on MPS New Proposal Page
	When I fill Proposal Description
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I choose "<Printer>" from Products screen
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	And I click Save as Template button on Summary screen
	Then I am directed to Templates screen of Proposal List page
	And the newly created template is displayed on the list
	And I can sign out of Brother Online

	Scenarios: 

	| Role             | Country | Contract | Leasing                    | Billing                    | Printer      | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | 3 Jahre  | 4 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | HL-L8350CDW  | 750         | 2000         |
	#| Cloud MPS Dealer | Germany | 4 Jahre  | 6 Monatlich Mindestvolumen | 4 Monatlich Mindestvolumen | DCP-L8400CDN | 1800        | 2000         |
	
	
		

	
	 



