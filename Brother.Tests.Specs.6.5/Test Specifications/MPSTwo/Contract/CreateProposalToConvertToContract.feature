@Ignore @TEST @UAT
Feature: Proposal - Create a Proposal that will be used for Contract
	In order to create a contract 
	As an MPS Dealer
	I want to create a proposal


Scenario Outline: Create a contract from a newly created proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I choose "<Printer>" from Products screen
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	When I create the proposal with details above
	Then I start the contract conversion process
	And I add a date to the proposal 
	And I save the proposal as a contract
	And the newly converted contract is available on Ready for Bank screen
	And I can send the converted contract to bank


	Scenarios: 

	| Role             | Country | Contract | Leasing                  | Billing                    | Printer      | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | 4 Jahre  | 6 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | DCP-L8400CDN | 1800        | 2000         |
	
	

