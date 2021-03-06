﻿@ignore @MPS @TEST @UAT @BIEPC112
Feature: CloudMPSDutchDealerCanOperateCustomers
	In order to view/create/edit/delete customers
	As an MPS Dealer or Sub-Dealer
	I want to operate customers


Scenario Outline: MPS Dutch Dealer can see customers 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	Then I can see the Existing Customers table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | Netherlands |
#	| Sub Dealer | United Kingdom |


Scenario Outline: MPS Dutch Dealer can create a new customer 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer
	Then I can see the Created Customer
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | Netherlands |
#	| Sub Dealer | United Kingdom |


#@ignore
Scenario Outline: MPS Dutch Dealer can edit a new customer 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer
	And I click the edit button against "<TargetItem>" on Exisiting Customers table
	And I edit the customer
	Then I can see the edited Customer
	And I click the edit button against "<TargetItem>" on Exisiting Customers table
	And I can confirm the edited Cusotemr in detail
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country     | TargetItem       |
	| Cloud MPS Dealer | Netherlands | NewlyCreatedItem |
	

@ignore
Scenario Outline: MPS Dutch Dealer can delete a customer 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer
	And I click the delete button against "<TargetItem>" on Exisiting Customers table
	And I click the "<Confirm>" button on Confirmation Dialog in Customers
	Then I can see the deleted customer does not exist on the table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country     | TargetItem       | Confirm |
	| Cloud MPS Dealer | Netherlands | NewlyCreatedItem | OK      |

@ignore
Scenario Outline: MPS Dutch Dealer can cancel deleting customer 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	##And I navigate to existing customer screen
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer
	When I click the delete button against "<TargetItem>" on Exisiting Customers table
	And I click the "<Confirm>" button on Confirmation Dialog in Customers
	Then I can see the deleted item still exists on the customer table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country     | TargetItem       | Confirm |
	| Cloud MPS Dealer | Netherlands | NewlyCreatedItem | Dismiss |
	

@ignore
Scenario Outline: MPS Dutch Dealer cannot delete a customer who is bound to an existing proposal
    Given Dealer have created a Open proposal of "<ContractType>" and "<UsageType>"
	And I navigate to Dealer Dashboard page from Dealer Proposal page
	And I navigate to existing customer screen
	When I click the delete button against "<TargetItem>" on Exisiting Customers table
	And I click the "<Confirm>" button on Confirmation Dialog in Customers
	Then I can see the deleted item still exists on the customer table
	And I can sign out of Brother Online

	Scenarios: 
	| ContractType                  | UsageType      | Confirm | TargetItem                   |
	| Purchase & Click with Service | Minimum Volume | OK      | NewlyCreatedProposalCustomer |
	