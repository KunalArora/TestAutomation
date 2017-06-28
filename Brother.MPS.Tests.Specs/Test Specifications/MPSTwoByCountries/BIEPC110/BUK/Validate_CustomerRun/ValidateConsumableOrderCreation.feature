@MPS @UAT @TEST @BIEPC110
Feature: ValidateConsumableOrderCreation
	In order to work with customer run portion
	As a dealer
	I want to be able to create a contract with an existing customer

Scenario Outline: MPS Existing Customer Validate Consumable Creation
	Given I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	When I navigate to customer dashboard page
	And I navigate to consumable ordering page for "<SerialNumber>"
	Then the newly created order is displayed
	##And initial SAP order number is not created
	And SAP order number is created only after relevant job is ran
	And order progress status is correct
	And I sign out of Cloud MPS


Scenarios:

	| Country        | ExistingCustomer                    | SerialNumber |
	| United Kingdom | Bradon20170613053736@mailinator.com | A1T010265    |


Scenario Outline: MPS Service Request By Email
	Given I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	When I navigate to customer dashboard page
	And I navigate to customer request page
	Then consumable can be automatically created
	And I can sign out of Brother Online
	
	
Scenarios:

	| Country        | ExistingCustomer                 |
	| United Kingdom | Omer2017067101751@mailinator.com |
	

	
	
	
