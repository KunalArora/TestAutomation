 @ignore @TEST @UAT
Feature: DealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals

@ignore
Scenario Outline: Dealer can see proposal offers 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	Then I can see the Existing Proposal table
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

@ignore
Scenario Outline: Dealer can edit description of existing proposal offer
	Given Dealer have created a Open proposal of "<ContractType>" and "<UsageType>"
	And I navigate to Dealer Dashboard page from Dealer Proposal page
	And I navigate to existing proposal screen
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "<TabName>" Tab in Proposal
	And I edit Proposal Description for "<ContractType>" Contract type
	And I go to "Summary" Tab in Proposal
	Then I can confirm "<TabName>" on Summary Tab in Proposal
	And I can sign out of Brother Online

	Scenarios:
	| ContractType               | UsageType      | Role             | Country        | TabName     |
	| Lease & Click with Service | Minimum Volume | Cloud MPS Dealer | United Kingdom | Description |
	
	#Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	#And I select next button for customer data capture on editing
	#And I Enter usage type of "<Usage>" and "<ContractType>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	#And I edit "<Printer1>" to "<Printer2>" device screen
	#And I accept the default values of the device
	#And I enter click price volume of "<ClickPrice>" and "<Colour>"
	#Then I can sign out of Brother Online
#	| ContractType               | UsageType      | Role             | Country        | Usage   | Leasing   | Billing   | Printer1    | Printer2     | ClickPrice | Colour |
#	| Lease & Click with Service | Minimum Volume | Cloud MPS Dealer | United Kingdom | 4 years | Quarterly | Quarterly | HL-L8350CDW | HL-L9200CDWT | 1000       | 1000   |
#	| Lease & Click with Service | Minimum Volume | Cloud MPS Dealer | United Kingdom | 4 years | Quarterly | Quarterly | HL-L9200CDWT | HL-L8350CDW | 1000       | 1000   |

@ignore
Scenario Outline: Dealer can delete an existing proposal offer
    Given Dealer have created a Open proposal of "<ContractType>" and "<UsageType>"
	When I click the delete button against "<TargetItem>" on Exisiting Proposal table
	And I click the "<Confirm>" button on Confirmation Dialog
	Then I can see the deleted item does not exist on the table
	And I can sign out of Brother Online

	Scenarios: 
	| ContractType               | UsageType      | Confirm | TargetItem       |
	| Lease & Click with Service | Minimum Volume | OK		| NewlyCreatedItem |
	
@ignore	
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

@ignore
Scenario Outline: Dealer can copy an existing proposal offer
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
