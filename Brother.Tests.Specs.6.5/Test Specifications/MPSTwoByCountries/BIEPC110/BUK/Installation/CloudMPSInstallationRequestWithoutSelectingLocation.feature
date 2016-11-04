@MPS @UAT @TEST @BIEPC110
Feature: UKInstallationRequestCannotBeCreatedWithoutSelectingLocation
	In order to begin installation request creation
	As a Dealer 
	I must select the location of the device 
	

Scenario Outline: MPS Installation Without Location
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I did not select Location but proceed to create installation request
	Then an error message is displayed to prevent further progress
	And I can progress if Location is selected
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | 
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer |
