@MPS @TEST @UAT @BIEPC110
Feature: CloudMPSSpecialPricing
	In order to give customers special discount
	As a LO Approver
	I want to be able to change the prices on some types of proposal

Scenario Outline: Awaiting Approval Proposal Special Pricing Pay Upfront
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
	And the dealer navigates to Proposal Summary page from Proposal Awaiting Approval page
	And the changes are also on Proposal Summary page 
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |
	
	

Scenario Outline: Approved Proposal Special Pricing
	Given "<Country>" Dealer has created an approved "<ContractType>" proposal of "<UsageType>" and "<Length>" and "<Billing>"
	And I navigate to Report page from Approved proposal page
	And Approver navigate to Data Query page
	When Approver navigates to special pricing page for the proposal
	And Approver makes changes to installation costing
	And Approver makes changes to Service Pack costing
	And Approver makes changes to Click Price costing
	Then the changes made are displayed on the summary page
	And audit log is displayed on report proposal summary page
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to dealer contract approved proposal page
	And the dealer navigates to Proposal Summary page from Approved Proposal page
	And the changes are also on Approved Proposal Summary page 
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |
	


Scenario Outline: Validate Special Pricing Calculation
	Given "<Country>" Dealer has created an approved "<ContractType>" proposal of "<UsageType>" and "<Length>" and "<Billing>"
	And I navigate to Report page from Approved proposal page
	And Approver navigate to Data Query page
	When Approver navigates to special pricing page for the proposal
	And Approver validates installation unit price calculation
	And Approver validates Service Pack unit price calculation
	And Approver makes changes to Click Price costing
	Then the changes made are displayed on the summary page
	And audit log is displayed on report proposal summary page
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |



Scenario Outline: Approved Proposal Special Pricing Using Multiple Devices
	Given "<Country>" Dealer has created an approved "<ContractType>" proposal of "<UsageType>" and "<Length>" and "<Billing>" with four devices
	And I navigate to Report page from Approved proposal page
	And Approver navigate to Data Query page
	When Approver navigates to special pricing page for the proposal
	And Approver makes changes to multiple installation costing
	And Approver makes changes to multiple Service Pack costing
	And Approver makes changes to multiple Click Price costing
	Then the changes made are displayed on the summary page
	Then the changes to installation cost made are displayed on the summary page
	And the changes to service pack cost made are displayed on the summary page
	And the changes to mono click price made are displayed on the summary page
	And the changes to colour click price made are displayed on the summary page
	And audit log is displayed on report proposal summary page
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |
