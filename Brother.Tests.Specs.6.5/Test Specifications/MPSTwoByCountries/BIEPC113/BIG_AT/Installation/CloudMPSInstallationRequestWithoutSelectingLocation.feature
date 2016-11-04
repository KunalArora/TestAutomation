@MPS @UAT @TEST @BIEPC113
Feature: GermanInstallationRequestCannotBeCreatedWithoutSelectingLocation
	In order to begin installation request creation
	As a Dealer 
	I must select the location of the device 
	

Scenario Outline: MPS Installation Without Location
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I did not select Location but proceed to create installation request
	Then an error message is displayed to prevent further progress
	And I can progress if Location is selected
	And I can sign out of Brother Online

	
Scenarios:

	| Role           | Country | ContractType      | UsageType      | Role1            |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer |
	
