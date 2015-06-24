﻿@Ignore	@TEST @UAT
Feature: DealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals

@Ignore
Scenario Outline: Dealer can see proposal offers 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	Then I can see the Existing Proposal table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

@Ignore
Scenario Outline: Dealer can edit an existing proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I can edit an item of Exisiting Proposal table
	Then I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

@Ignore
Scenario Outline: Dealer can delete an existing proposal offer
    Given Dealer have created a Open proposal of "<ContractType>" and "<UsageType>"
	When I click the delete button against "<TargetItem>" on Exisiting Proposal table
	And I click the "<Confirm>" button on Confirmation Dialog
	Then I can see the deleted item does not exist on the table
	And I can sign out of Brother Online

	Scenarios: 
	| ContractType               | UsageType      | Confirm | TargetItem       |
	| Lease & Click with Service | Minimum Volume | OK		| NewlyCreatedItem |
	
@Ignore	
Scenario Outline: Dealer can cansel deleting proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I click the delete button against "<TargetItem>" on Exisiting Proposal table
	And I click the "<Confirm>" button on Confirmation Dialog
	Then I can see the deleted item still exists on the table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        | Confirm | TargetItem |
	| Cloud MPS Dealer | United Kingdom | Dismiss | AnyItem    |

@Ignore	
Scenario Outline: Dealer can copy an existing proposal offer without customer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I can Copy "<Operation>" Customer an item of Exisiting Proposal table "<Target>" Customer
	Then I can see the Proposal offer which copied "<Operation>" Customer
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        | Operation | Target  |
	| Cloud MPS Dealer | United Kingdom | Without   | Without |
	| Cloud MPS Dealer | United Kingdom | Without   | With    |
	| Cloud MPS Dealer | United Kingdom | With      | With    |