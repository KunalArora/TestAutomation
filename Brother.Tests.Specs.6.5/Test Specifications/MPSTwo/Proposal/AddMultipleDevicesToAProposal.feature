@Ignore @UAT @TEST
Feature: Proposal - Add multiple devices to a proposal during creation
	In order to create a contract with multiple devices 
	As an MPS Dealer
	I want to create a proposal that has multiple devices


Scenario Outline: Create a proposal with multiple devices
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Dealer Dashboard page
	And I am on MPS New Proposal Page
	When I fill Proposal Description
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I choose three devices from Products screen
	And I enter multiple click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then the three devices selected above are displayed on Summary Screen
	And the newly created proposal is displayed on the list

	Scenarios: 

	| Role             | Country | Contract | Leasing                    | Billing                    | Printer     | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | 3 Jahre  | 6 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | HL-L8350CDW | 2000        | 2000         |