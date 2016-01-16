@ignore @TEST @UAT @MPS
Feature: CloudMPSServiceRequestOperations
	In order to get my devices issues fix by Brother
	As an MPS user
	I want to be able to raise service request which can be worked on


Scenario Outline: Add two numbers
	Given I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to customer request page
	And I can sign out of Brother Online
	
Scenarios:

	| Country        | Role2                  | Method | Role1                           |
	| United Kingdom | Cloud MPS Service Desk | Email  | Cloud MPS Service Desk Customer |
	
