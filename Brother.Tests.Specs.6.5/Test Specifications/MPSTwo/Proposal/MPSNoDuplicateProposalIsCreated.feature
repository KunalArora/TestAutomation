@MPS @UAT @TEST
Feature: MPSNoDuplicateProposalIsCreated
	In order to ensure duplicate proposal is not created for proposals and contracts
	As a MPS user
	I want to check that distinct proposal/contracts are displayed on each view


Scenario Outline: Ensure Duplicate Proposal is not created for Decline Proposals
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I navigate to dealer proposal rejected page
	Then there is no duplicate proposal on the page
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
	| Cloud MPS Dealer | Germany        |
	 

Scenario Outline: Ensure Duplicate Proposal is not created for Open Proposals
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to existing proposal screen
	Then there is no duplicate proposal on Open Proposals page
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country        |
	#| Cloud MPS Dealer | United Kingdom |
	| Cloud MPS Dealer | Germany        |