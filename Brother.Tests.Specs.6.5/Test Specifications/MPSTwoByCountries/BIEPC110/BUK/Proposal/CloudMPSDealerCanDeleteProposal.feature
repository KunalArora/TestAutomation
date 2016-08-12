@MPS @TEST @UAT
Feature: CloudMPSUKDealerCanDeleteProposal
	In order to stop the progress of a proposal
	As a math dealer
	I want to be able to delete an open proposal


Scenario Outline: Dealer can delete an open proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed
	And I sign out of Cloud MPS


Scenarios:

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

