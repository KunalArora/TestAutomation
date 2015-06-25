@ignore @TEST @UAT
Feature: DealerCanOperateCustomers
	In order to view/create/edit/delete customers
	As an MPS Dealer or Sub-Dealer
	I want to operate customers

@ignore
Scenario Outline: Dealer can see customers 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	Then I can see the Existing Customers table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
#	| Sub Dealer | United Kingdom |

@ignore
Scenario Outline: Dealer can create a new customer 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer
	Then I can see the Created Customer
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
#	| Sub Dealer | United Kingdom |