﻿@MPS @TEST @UAT
Feature: CloudMPSPolishDealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals

Scenario Outline: Dealer can see proposal offers 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	Then I can see the Existing Proposal table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Poland |
	

Scenario Outline: Dealer can edit an existing proposal offer
	Given "<Country>" Dealer has created an Open proposal of "<ContractType>", "<UsageType>", "<Length>" and "<Billing>"
	And I navigate to Dealer Dashboard page from Dealer Proposal page
	#Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "<TabName>" Tab in Proposal
	And I edit "<TabName>" Tab in Proposal of "<ContractType>"
	And I go to "Summary" Tab in Proposal
	Then I can confirm "<TabName>" on Summary Tab in Proposal of "Buy + Click"
	And I can sign out of Brother Online

	Scenarios:
	| ContractType | UsageType       | Role             | Country | TabName     | Length | Billing              |
	| Buy + Click  | Pakiet wydruków | Cloud MPS Dealer | Poland  | TermAndType | 3 lata | Quarterly in Arrears |
	
##@ignore
Scenario Outline: Dealer can edit products in an existing proposal offer
	Given "<Country>" Dealer has created an Open proposal of "<ContractType>", "<UsageType>", "<Length>" and "<Billing>"
	And I navigate to Dealer Dashboard page from Dealer Proposal page
	#Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "Products" Tab in Proposal
	And I edit Products Tab and "<Action>" in Proposal
	And I go to "Summary" Tab in Proposal
	Then I can confirm Products and "<Action>" on Summary Tab in Proposal
	And I can sign out of Brother Online

	Scenarios:
	| ContractType | UsageType       | Role             | Country | TabName  | Action | Length | Billing              |
	| Buy + Click  | Pakiet wydruków | Cloud MPS Dealer | Poland  | Products | Add    | 3 lata | Quarterly in Arrears |
	| Buy + Click  | Pakiet wydruków | Cloud MPS Dealer | Poland  | Products | Remove | 3 lata | Quarterly in Arrears |
	

@ignore	
Scenario Outline: Dealer can cancel deleting proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I click the delete button against "<TargetItem>" on Existing Proposal table to be "<Confirm>"
	And I click the "<Confirm>" button on Confirmation Dialog
	Then I can see the deleted item still exists on the table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country | Confirm | TargetItem |
	| Cloud MPS Dealer | Poland  | Dismiss | AnyItem    |

	
@ignore
Scenario Outline: Dealer can copy an existing proposal offer for all countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal "<Customer>" Customer detail with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	And I copy the proposal created above "<Status>" customer
	Then the copied proposal above is displayed with appropriate customer status	
	And I sign out of Cloud MPS

	
	Scenarios:

	| Role             | Country | ContractType | UsageType       | Length | Billing              | Customer               | Status  |
	| Cloud MPS Dealer | Poland  | Buy + Click  | Pakiet wydruków | 3 lata | Quarterly in Arrears | Skip customer creation | Without |
	| Cloud MPS Dealer | Poland  | Buy + Click  | Pakiet wydruków | 4 lata | Quarterly in Arrears | Create new customer    | With    |
	