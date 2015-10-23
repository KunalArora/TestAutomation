@MPS @TEST @UAT
Feature: MPSDealerCanDeleteProposal
	In order to stop the progress of a proposal
	As a math dealer
	I want to be able to delete an open proposal


Scenario Outline: Dealer can delete an open proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed


Scenarios:

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

Scenario Outline: German Dealer can delete an open Leasing and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Leasing and Click proposal 
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed

Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany |

Scenario Outline: German Dealer can delete an open Purchase and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Purchase and Click proposal 
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed

Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany |