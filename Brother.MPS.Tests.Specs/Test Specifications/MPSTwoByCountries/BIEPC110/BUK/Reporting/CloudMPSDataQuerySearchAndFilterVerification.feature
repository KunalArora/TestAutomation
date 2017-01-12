	@ignore @MPS @TEST @UAT @BIEPC110
	Feature: CloudMPSDataQuerySearchAndFilterVerification
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Awaiting Approval Proposal Special Pricing
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	When Approver navigate to Data Query page
	Then I can search with contract id
	And search using serial number
	And I can change the search dates
	And I can search with show ending contracts
	#When Approver navigates to special pricing page for the proposal
	#And Approver makes changes to installation costing
	#And Approver makes changes to Service Pack costing
	#And Approver makes changes to Click Price costing
	#Then the changes made are displayed on the summary page
	#And audit log is displayed on report proposal summary page
	#And I sign out of Cloud MPS
	#And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	#And I navigate to existing proposal screen
	#And the dealer navigates to Proposal Summary page from Proposal Awaiting Approval page
	#And the changes are also on Proposal Summary page 
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |
	