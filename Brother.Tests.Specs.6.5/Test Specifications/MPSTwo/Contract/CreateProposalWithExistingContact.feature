@TEST @UAT
Feature: Proposal - Create a Proposal from an existing contact
	In order to create a contract from an existing contact 
	As an MPS Dealer
	I want to create a proposal which re-uses an existing contact


Scenario Outline: Create a proposal with an existing contact
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Dealer Dashboard page
	And I am on MPS New Proposal Page
	When I fill Proposal Description
	And I choose an existing contact from the list of available contacts
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I choose "<Printer>" from Products screen
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	Then I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I can sign out of Brother Online

	Scenarios: 

	| Role             | Country | Contract | Leasing                    | Billing                    | Printer      | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | 3 Jahre  | 4 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | HL-L8350CDW  | 750         | 1000         |
	| Cloud MPS Dealer | Germany | 4 Jahre  | 6 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | DCP-L8400CDN | 1600        | 2000         |


