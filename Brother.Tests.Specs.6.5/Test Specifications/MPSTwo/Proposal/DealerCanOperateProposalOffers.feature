@TEST @UAT
Feature: DealerCanOperateProposalOffers
	#

Scenario Outline: Dealer can see proposal offers 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	Then I can see the Existing Proposal table

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
	