@MPS @TEST @UAT @BIEPC110
Feature: CloudMPSReportingVeification
	In order to verified that reporting is working as expect
	As a user with reporting access
	I want to be to download categorized reports


Scenario Outline: Users Can interact with Report download
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Report page
	Then I can download "<Report1>" from the page
	And I can download "<Report2>" from the page
	And I can download "<Report3>" from the page
	And I can download "<Report4>" from the page
	And I can download "<Report5>" from the page
	And I sign out of Cloud MPS

Scenarios: 
	| Role                            | Country        | Report1           | Report2       | Report3                | Report4             | Report5                |
	| Cloud MPS Local Office Approver | United Kingdom | Basic Data Report | Dealer Report | Supplies Orders Report | Print Volume Report | Service Request Report |

	
@ignore
Scenario Outline: Awaiting Approval Proposal Special Pricing
	Given "<Country>" dealer has created "<ContractType>" proposal of awaiting proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And Approver navigate to ProposalsPage
	And Approver navigate to Awaiting Approval screen under Proposals page
	When Approver select the proposal on Awaiting Proposal
	Then Approver should be able to decline that proposal
	And the decline proposal should be displayed under Declined tab by Approver
	And I sign out of Cloud MPS

	Scenarios: 
	| Country | Role                            | ContractType         | UsageType           | Length   | Billing              |
	| Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | Quarterly in Arrears |

@ignore
Scenario Outline: Approved Proposal Special Pricing
	Given "<Country>" dealer has created "<ContractType>" proposal of awaiting proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And Approver navigate to ProposalsPage
	And Approver navigate to Awaiting Approval screen under Proposals page
	When Approver select the proposal on Awaiting Proposal
	Then Approver should be able to decline that proposal
	And the decline proposal should be displayed under Declined tab by Approver
	And I sign out of Cloud MPS

	Scenarios: 
	| Country | Role                            | ContractType         | UsageType           | Length   | Billing              |
	| Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | Quarterly in Arrears |
	 
