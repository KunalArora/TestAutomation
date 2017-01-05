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


Scenario Outline: Awaiting Approval Proposal Special Pricing
	Given "<Country>" dealer has created "<ContractType>" proposal of awaiting proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	And Approver navigate to Data Query page
	When Approver navigates to special pricing page for the proposal
	And Approver makes changes to installation costing
	And Approver makes changes to Service Pack costing
	And Approver makes changes to Click Price costing
	Then the changes made are displayed on the summary page
	And audit log is displayed on report proposal summary page
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to existing proposal screen
	And the dealer navigates to Proposal Summary page
	And the changes are also on Proposal Summary page 
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |
	
	
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
	| Country        | Role                            | ContractType         | UsageType           | Length   | Billing              |
	| United Kingdom | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | Quarterly in Arrears |
	 
