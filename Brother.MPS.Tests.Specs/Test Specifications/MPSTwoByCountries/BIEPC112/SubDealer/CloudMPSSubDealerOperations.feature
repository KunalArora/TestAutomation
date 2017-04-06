@MPS @TEST @UAT @BIEPC112
Feature: CloudMPSSubDealerOperations
	In order to assign responsibility to sub dealer
	As a dealer
	I want the ability to create and manage subdealer


##Scenario 1.1 - 1.3
Scenario Outline: Dealer can view dealership users
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Admin page using tab
	When I navigate to Dealership Users page
	Then the list of existing subdealer is displayed
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom | 


##Scenario 1.1 - 1.3
Scenario Outline: Local Office can view dealership users
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to LO Admin Administration page using tab
	When I navigate to LO Admin Dealership Users page
	And I search for dealership "<Dealership>" on LO dealership page
	And I proceed to dealership users page for that dealer
	Then the list of existing subdealer is displayed for that dealer
	And I sign out of Cloud MPS


	Scenarios: 
	| Role                   | Country        | Dealership          |
	| Cloud MPS Local Office | United Kingdom | MPS-BUK-UAT-Dealer1 |
	
##Scenario 2.1
Scenario Outline: Local Office Admin can create dealership users
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to LO Admin Administration page using tab
	When I navigate to LO Admin Dealership Users page
	And I search for dealership "<Dealership>" on LO dealership page
	And I proceed to dealership users page for that dealer
	And I begin subdealer creation for the dealer
	And I enter all details with "<UserPermission>" for new subdealer
	And I submit the detail for creation of the new subdealer
	Then the subdealer created is shown on the dealer list of subdealers 
	And I sign out of Cloud MPS


	Scenarios: 
	| Role                   | Country        | UserPermission   | Dealership          |
	| Cloud MPS Local Office | United Kingdom | Full             | MPS-BUK-UAT-Dealer1 |
	| Cloud MPS Local Office | United Kingdom | Contract Manager | MPS-BUK-UAT-Dealer1 |
	| Cloud MPS Local Office | United Kingdom | Restricted       | MPS-BUK-UAT-Dealer1 |
	
##Scenario 2.2
Scenario Outline: Dealer can create dealership users
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Admin page using tab
	When I navigate to Dealership Users page
	And I begin subdealer creation process
	And I enter all details with "<UserPermission>" as the permission
	And I submit the detail for creation
	Then the subdealer created is shown on the list of subdealers
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        | UserPermission   |
	| Cloud MPS Dealer | United Kingdom | Full             |
	| Cloud MPS Dealer | United Kingdom | Contract Manager |
	| Cloud MPS Dealer | United Kingdom | Restricted       |


	@ignore
Scenario Outline: SubDealer Fields Validation
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Admin page using tab
	When I navigate to Dealership Users page
	And I begin subdealer creation process
	And I click on submit button without any data 
	And error message is displayed
	And I enter first name as part of the mandatory detail
	And I click on submit button without any data
	And error message is displayed
	And I enter last name as part of the mandatory detail
	And I click on submit button without any data
	And error message is displayed
	And I enter telephone as part of the mandatory detail
	And I click on submit button without any data
	And error message is displayed
	And I enter email as part of the mandatory detail
	And I submit the detail for creation
	Then the subdealer created is shown on the list of subdealers
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        | UserPermission   |
	| Cloud MPS Dealer | United Kingdom | Full             |
	| Cloud MPS Dealer | United Kingdom | Contract Manager |
	| Cloud MPS Dealer | United Kingdom | Restricted       |


	@ignore
Scenario Outline: Dealer can Delete dealership users
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Admin page using tab
	When I navigate to Dealership Users page
	And I begin subdealer creation process
	And I enter all details with "<UserPermission>" as the permission
	And I submit the detail for creation
	And the subdealer created is shown on the list of subdealers
	Then I can delete the subdealer successfully
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        | UserPermission   |
	| Cloud MPS Dealer | United Kingdom | Full             |
	| Cloud MPS Dealer | United Kingdom | Contract Manager |
	| Cloud MPS Dealer | United Kingdom | Restricted       |
	
