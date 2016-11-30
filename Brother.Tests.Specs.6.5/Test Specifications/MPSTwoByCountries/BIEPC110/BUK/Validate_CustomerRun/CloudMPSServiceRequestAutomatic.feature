@ignore @TEST @UAT @MPS @BIEPC110
Feature: CloudMPSServiceRequestAutomatic
	In order to get my devices issues fix by Brother
	As an MPS user
	I want to be able to raise service request which can be worked on



Scenario Outline: MPS Raise Service Request Automatic
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to customer request page
	##When I raise a service request
	When the service request is created and displayed
	And all the functionalities of the service request work
	And I can sign out of Brother Online
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	Then the created service request is displayed for Service Desk 
	##And Service Desk can close the service request
	And I can sign out of Brother Online

	
Scenarios:

	| Country        | Role2                  | Role1                               |
	| United Kingdom | Cloud MPS Service Desk | Coleen20161123042204@mailinator.com |





