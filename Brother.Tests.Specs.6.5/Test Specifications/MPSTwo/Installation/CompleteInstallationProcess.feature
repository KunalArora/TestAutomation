@MPS @UAT @TEST
Feature: CompleteInstallationProcess
	In order to get an installer to begin installation
	As a Dealer 
	I want to be able to complete installation


Scenario Outline: Dealer can create installation request for Cloud Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume |


Scenario Outline: German Dealer can create installation request for Cloud Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved

Scenarios:

	| Role                            | Country | ContractType                  | UsageType      |
	| Cloud MPS Local Office Approver | Germany | Purchase & Click with Service | Minimum Volume |
	
