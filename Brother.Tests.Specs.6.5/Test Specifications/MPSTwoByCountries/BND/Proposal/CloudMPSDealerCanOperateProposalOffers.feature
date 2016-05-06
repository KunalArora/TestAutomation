@MPS @TEST @UAT
Feature: CloudMPSDannishDealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals

Scenario Outline: Dealer can see proposal offers 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	Then I can see the Existing Proposal table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: Dealer can edit an existing proposal offer
	Given Dealer have created a Open proposal of "<ContractType>" and "<UsageType>"
	And I navigate to Dealer Dashboard page from Dealer Proposal page
	#Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "<TabName>" Tab in Proposal
	And I edit "<TabName>" Tab in Proposal of "<ContractType>"
	And I go to "Summary" Tab in Proposal
	Then I can confirm "<TabName>" on Summary Tab in Proposal of "Purchase + Click with Service"
	And I can sign out of Brother Online

	Scenarios:
	| ContractType                  | UsageType      | Role             | Country        | TabName             |
	#| Lease & Click with Service    | Minimum Volume | Cloud MPS Dealer | United Kingdom | Description         |
	#| Lease & Click with Service    | Minimum Volume | Cloud MPS Dealer | United Kingdom | CustomerInformation |
	#| Lease & Click with Service    | Minimum Volume | Cloud MPS Dealer | United Kingdom | TermAndType         |
	#| Lease & Click with Service    | Minimum Volume | Cloud MPS Dealer | United Kingdom | Products            |
	#| Lease & Click with Service    | Minimum Volume | Cloud MPS Dealer | United Kingdom | ClickPrice          |
	| Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | United Kingdom | TermAndType         |

##@ignore
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
	| ContractType                  | UsageType      | Role             | Country        | TabName  | Action |
	| Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | United Kingdom | Products | Add    |
	| Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | United Kingdom | Products | Remove |
	

#@ignore
Scenario Outline: Dealer can delete an existing proposal offer
    Given Dealer have created a Open proposal of "<ContractType>" and "<UsageType>"
	When I click the delete button against "<TargetItem>" on Existing Proposal table to be "<Confirm>"
	And I click the "<Confirm>" button on Confirmation Dialog
	Then I can see the deleted item does not exist on the table
	And I can sign out of Brother Online

	Scenarios: 
	| ContractType                  | UsageType      | Confirm | TargetItem       |
	| Purchase & Click with Service | Minimum Volume | OK      | NewlyCreatedItem |
	
	
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
	| Cloud MPS Dealer | Germany | Without   | Without |
	| Cloud MPS Dealer | Austria | Without   | Without |
	

Scenario Outline: Dealer can copy an existing proposal offer for all countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal "<Customer>" Customer detail with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	And I copy the proposal created above "<Status>" customer
	Then the copied proposal above is displayed with appropriate customer status	
	And I sign out of Cloud MPS

	
	Scenarios:

	| Role             | Country        | ContractType                      | UsageType                                 | Length  | Billing                 | Customer               | Status  |
	| Cloud MPS Dealer | France         | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans   | Trimestrale anticipata  | Skip customer creation | Without |
	| Cloud MPS Dealer | France         | Buy & Click                       | Engagement sur un minimum volume de pages | 4 ans   | Trimestrale anticipata  | Create new customer    | With    |
	| Cloud MPS Dealer | Italy          | Acquisto + Consumo con assistenza | Volume minimo                             | 36      | Trimestrale anticipata  | Skip customer creation | Without |
	| Cloud MPS Dealer | Italy          | Acquisto + Consumo con assistenza | Volume minimo                             | 48      | Trimestrale anticipata  | Create new customer    | With    |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service     | Minimum Volume                            | 3 years | Quarterly in Arrears    | Skip customer creation | Without |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service     | Minimum Volume                            | 4 years | Quarterly in Arrears    | Create new customer    | With    |
	| Cloud MPS Dealer | Spain          | Purchase & Click con Service      | Volúmen mínimo                            | 3 años  | Por trimestres vencidos | Skip customer creation | Without |
	| Cloud MPS Dealer | Spain          | Purchase & Click con Service      | Volúmen mínimo                            | 3 años  | Por trimestres vencidos | Create new customer    | With    |
	

