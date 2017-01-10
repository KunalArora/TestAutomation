Feature: CloudMPSAddLocationToUKCustomerInformation
	In order to use multiple location for products
	As a dealer
	I want to be able to add several location to a customer


Scenario Outline: MPS English Add Multiple Locations to customer 
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
