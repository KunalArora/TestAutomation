@MPS @TEST @UAT
Feature: CloudMPSPolishDealerCanDeleteProposal
	In order to stop the progress of a proposal
	As a dealer
	I want to be able to delete an open proposal


Scenario Outline: MPS Polish Dealers can delete an open Purchase and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed
	And I sign out of Cloud MPS

Scenarios:

	| Role             | Country | Role2                           | ContractType | UsageType       | Length | Billing              |
	| Cloud MPS Dealer | Poland  | Cloud MPS Local Office Approver | Buy + Click  | Pakiet wydruków | 3 lata | Quarterly in Arrears |
	

