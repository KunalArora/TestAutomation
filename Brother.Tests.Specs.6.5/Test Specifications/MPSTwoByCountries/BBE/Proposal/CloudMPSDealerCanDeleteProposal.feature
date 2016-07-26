@MPS @TEST @UAT
Feature: CloudMPSBelgianDealerCanDeleteProposal
	In order to stop the progress of a proposal
	As a math dealer
	I want to be able to delete an open proposal


Scenario Outline: Other Dealers can delete an open Purchase and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed
	And I sign out of Cloud MPS

Scenarios:

	| Role             | Country | Role2                           | ContractType                  | UsageType      | Length | Billing              | Language |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 jaar | Quarterly in Arrears | Dutch    |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Buy & Click                   | Volume minimum | 3 ans  | Quarterly in Arrears | French   |
	