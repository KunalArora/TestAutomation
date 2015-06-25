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

@ignore
Scenario Outline: Dealer can edit a new customer 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer
	And I click the edit button against "<TargetItem>" on Exisiting Customers table
	And I edit the customer
	Then I can see the edited Customer
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        | TargetItem       |
	| Cloud MPS Dealer | United Kingdom | NewlyCreatedItem |
#	| Sub Dealer | United Kingdom |

@ignore
Scenario Outline: Dealer can delete a customer 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer
	And I click the delete button against "<TargetItem>" on Exisiting Customers table
	And I click the "<Confirm>" button on Confirmation Dialog in Customers
	Then I can see the deleted customer does not exist on the table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |TargetItem		  | Confirm |
	| Cloud MPS Dealer | United Kingdom |NewlyCreatedItem | OK      |
#	| Sub Dealer | United Kingdom |NewlyCreatedItem | OK      |

@ignore
Scenario Outline: Dealer can cansel deleting customer 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	When I click the delete button against "<TargetItem>" on Exisiting Customers table
	And I click the "<Confirm>" button on Confirmation Dialog in Customers
	Then I can see the deleted item still exists on the customer table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        | TargetItem | Confirm |
	| Cloud MPS Dealer | United Kingdom | AnyItem    | Dismiss |
#	| Sub Dealer | United Kingdom | AnyItem    | Dismiss |