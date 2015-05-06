@Ignore @UAT @TEST
Feature: BankCanMaintainCustomerAfterADealerSignsContract
	In order to fully set-up a contract
	As an MPS Bank user
	I want to be able to maintain a customer after a contract has been signed


Scenario Outline: Bank Can Maintain Offer After A Dealer Signs A Contract
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
	And I accept the contract above
	And I sign out of Cloud MPS
	And I return to Cloud MPS as a "<Role>" from "<Country>"
	And I sign the contract
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	Then I can successfully maintain the customer for the signed contract

	Scenarios: 

	| Role             | Country | Contract | Leasing                    | Billing                    | Printer     | ClickVolume | ColourVolume | Role2          |
	| Cloud MPS Dealer | Germany | 3 Jahre  | 4 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | HL-L8350CDW | 2000        | 2000         | Cloud MPS Bank |
	
