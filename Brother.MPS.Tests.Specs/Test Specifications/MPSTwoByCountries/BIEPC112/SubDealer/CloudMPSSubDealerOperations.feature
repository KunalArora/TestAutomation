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
	| Role                   | Country        | UserPermission   | Dealership                        |
	| Cloud MPS Local Office | United Kingdom | Full             | MPS-BUK-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | United Kingdom | Contract Manager | MPS-BUK-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | United Kingdom | Restricted       | MPS-BUK-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Germany        | Full             | MPS-BIG-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Germany        | Contract Manager | MPS-BIG-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Germany        | Restricted       | MPS-BIG-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Austria        | Full             | MPS-BAT-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Austria        | Contract Manager | MPS-BAT-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Austria        | Restricted       | MPS-BAT-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Belgium        | Full             | MPS-BBE-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Belgium        | Contract Manager | MPS-BBE-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Belgium        | Restricted       | MPS-BBE-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Belgium        | Full             | MPS-BBE-UAT-Dealer3@brother.co.uk |
	| Cloud MPS Local Office | Belgium        | Contract Manager | MPS-BBE-UAT-Dealer3@brother.co.uk |
	| Cloud MPS Local Office | Belgium        | Restricted       | MPS-BBE-UAT-Dealer3@brother.co.uk |
	| Cloud MPS Local Office | Spain          | Full             | MPS-BES-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Spain          | Contract Manager | MPS-BES-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Spain          | Restricted       | MPS-BES-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Netherlands    | Full             | MPS-BNL-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Netherlands    | Contract Manager | MPS-BNL-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Netherlands    | Restricted       | MPS-BNL-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | France         | Full             | MPS-BFR-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | France         | Contract Manager | MPS-BFR-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | France         | Restricted       | MPS-BFR-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Sweden         | Full             | MPS-BNS-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Sweden         | Contract Manager | MPS-BNS-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Sweden         | Restricted       | MPS-BNS-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Italy          | Full             | MPS-BIT-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Italy          | Contract Manager | MPS-BIT-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Italy          | Restricted       | MPS-BIT-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Poland         | Full             | MPS-BPL-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Poland         | Contract Manager | MPS-BPL-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Poland         | Restricted       | MPS-BPL-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Finland        | Full             | MPS-BNF-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Finland        | Contract Manager | MPS-BNF-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Finland        | Restricted       | MPS-BNF-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Norway         | Full             | MPS-BNN-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Norway         | Contract Manager | MPS-BNN-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Norway         | Restricted       | MPS-BNN-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Ireland        | Full             | MPS-BIR-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Ireland        | Contract Manager | MPS-BIR-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Ireland        | Restricted       | MPS-BIR-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Denmark        | Full             | MPS-BND-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Denmark        | Contract Manager | MPS-BND-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Denmark        | Restricted       | MPS-BND-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Switzerland    | Full             | MPS-BSW-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Switzerland    | Contract Manager | MPS-BSW-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Switzerland    | Restricted       | MPS-BSW-UAT-Dealer1@brother.co.uk |
	| Cloud MPS Local Office | Switzerland    | Full             | MPS-BSW-UAT-Dealer3@brother.co.uk |
	| Cloud MPS Local Office | Switzerland    | Contract Manager | MPS-BSW-UAT-Dealer3@brother.co.uk |
	| Cloud MPS Local Office | Switzerland    | Restricted       | MPS-BSW-UAT-Dealer3@brother.co.uk |
	
	

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


Scenario Outline: Dealer can Edit dealership users
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Admin page using tab
	When I navigate to Dealership Users page
	And I begin subdealer creation process
	And I enter all details with "<UserPermission>" as the permission
	And I submit the detail for creation
	And the subdealer created is shown on the list of subdealers
	Then I can edit the subdealer with "<NewUserPermission>" successfully
	And I submit the detail for creation
	And the subdealer is edited
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        | UserPermission   | NewUserPermission |
	| Cloud MPS Dealer | United Kingdom | Full             | Contract Manager  |
	| Cloud MPS Dealer | United Kingdom | Contract Manager | Full              |
	| Cloud MPS Dealer | United Kingdom | Restricted       | Contract Manager  |
	
