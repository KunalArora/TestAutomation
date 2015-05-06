@Ignore @UAT @TEST
Feature: BankRejectsAContract
	In order not to progress with a contract for whatever reason
	As an MPS Bank user
	I want to be able to reject a contract


Scenario Outline: Bank Can Rejects A Contract
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
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I reject the contract above
	And I sign out of Cloud MPS
	And I return to Cloud MPS as a "<Role>" from "<Country>"
	Then the reject contract above is displayed on dealer rejected offer screen


	Scenarios: 

	| Role             | Country | Contract | Leasing                    | Billing                    | Printer     | ClickVolume | ColourVolume | Role2          |
	| Cloud MPS Dealer | Germany | 3 Jahre  | 4 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | HL-L8350CDW | 2000        | 2000         | Cloud MPS Bank |

