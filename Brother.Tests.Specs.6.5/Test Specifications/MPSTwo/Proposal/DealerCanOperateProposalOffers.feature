@TEST @UAT
Feature: DealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals

Scenario Outline: Dealer can see proposal offers 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	Then I can see the Existing Proposal table

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

Scenario Outline: Dealer can edit an existing proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I can edit an item of Exisiting Proposal table

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

Scenario Outline: Dealer can delete an existing proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I click the delete button against an item on Exisiting Proposal table
	And I click the "<Confirm>" button on Confirmation Dialog
	Then I can see the deleted item does not exist on the table

	Scenarios: 
	| Role             | Country        | Confirm |
	| Cloud MPS Dealer | United Kingdom | OK      |
	
	
Scenario Outline: Dealer can cansel deleting proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I click the delete button against an item on Exisiting Proposal table
	And I click the "<Confirm>" button on Confirmation Dialog
	Then I can see the deleted item still exists on the table

	Scenarios: 
	| Role             | Country        | Confirm |
	| Cloud MPS Dealer | United Kingdom | Dismiss |