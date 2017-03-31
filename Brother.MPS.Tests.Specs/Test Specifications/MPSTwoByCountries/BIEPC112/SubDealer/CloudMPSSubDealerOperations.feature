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
	And I navigate to Admin page using tab
	When I navigate to Dealership Users page
	Then the list of existing subdealer is displayed
	And I sign out of Cloud MPS


	Scenarios: 
	| Role                            | Country        |
	| Cloud MPS Local Office Approver | United Kingdom |
	
##Scenario 2.1
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
	
##Scenario 2.2
Scenario Outline: Local Office can create dealership users
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
	
