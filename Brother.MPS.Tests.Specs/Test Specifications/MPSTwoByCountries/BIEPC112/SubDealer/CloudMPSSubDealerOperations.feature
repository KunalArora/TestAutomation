Feature: CloudMPSSubDealerOperations
	In order to assign responsibility to sub dealer
	As a dealer
	I want the ability to create and manage subdealer


##Scenario 1.1 - 1.3
Scenario Outline: Dealer And Local Office can view dealership users
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Admin page using tab
	When I navigate to Dealership Users page
	Then the list of existing subdealer is displayed
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom | 
