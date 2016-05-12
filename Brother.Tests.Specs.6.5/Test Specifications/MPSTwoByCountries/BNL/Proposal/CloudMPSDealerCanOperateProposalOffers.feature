@MPS @TEST @UAT
Feature: CloudMPSDutchDealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals


Scenario Outline: Dealer can edit products in an existing proposal offer
	Given Dealer have created a Open proposal of "<ContractType>" and "<UsageType>"
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
	| ContractType                  | UsageType      | Role             | Country     | TabName  | Action |
	| Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Netherlands | Products | Add    |
	| Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Netherlands | Products | Remove |
	
	
Scenario Outline: Dealer can cancel deleting proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I click the delete button against "<TargetItem>" on Existing Proposal table to be "<Confirm>"
	And I click the "<Confirm>" button on Confirmation Dialog
	Then I can see the deleted item still exists on the table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        | Confirm | TargetItem |
	| Cloud MPS Dealer | United Kingdom | Dismiss | AnyItem    |

Scenario Outline: Dealer can copy an existing proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I can Copy "<Operation>" Customer an item of Exisiting Proposal table "<Target>" Customer
	Then I can see the Proposal offer which copied "<Operation>" Customer
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country | Operation | Target  |
	| Cloud MPS Dealer | Netherlands | Without   | Without |
	| Cloud MPS Dealer | Netherlands | Without   | Without |
	
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

	| Role             | Country     | ContractType | UsageType                                 | Length | Billing                | Customer               | Status  |
	| Cloud MPS Dealer | Netherlands | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata | Skip customer creation | Without |
	| Cloud MPS Dealer | Netherlands | Buy & Click  | Engagement sur un minimum volume de pages | 4 ans  | Trimestrale anticipata | Create new customer    | With    |
	