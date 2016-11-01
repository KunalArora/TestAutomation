@MPS @TEST @UAT
Feature: CloudMPSSwissDealerCanDeleteProposal
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

	| Role             | Country     | Role2                           | ContractType                 | UsageType     | Length | Billing       |
	| Cloud MPS Dealer | Switzerland | Cloud MPS Local Office Approver | Purchase & Click mit Service | Pay As You Go | 36     | Quartalsweise |
	
