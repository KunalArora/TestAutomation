	@ignore @MPS @TEST @UAT @BIEPC110
	Feature: CloudMPSDataQuerySearchAndFilterVerification
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: Data Query searches
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	When Approver navigate to Data Query page
	Then I can search with contract id "72502"
	And search using serial number "A1T010233"
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
	


Scenario Outline: Data Query Proposal Status filters
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	When Approver navigate to Data Query page
	Then I can filter out Open Proposals
	And I can filter out Awaiting Approval Proposal
	And I can filter out Approved Proposal
	And I can filter out Closed Proposal
	And I can filter out Decline Proposal
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |

Scenario Outline: Data Query Contract Status filters
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	When Approver navigate to Data Query page
	Then I can filter out Awaiting Acceptance Contract
	And I can filter out Accepted Contract
	And I can filter out Running Contract
	And I can filter out Closed Contract
	And I can filter out Rejected Contract
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |

Scenario Outline: Data Query Contract Type filters
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	When Approver navigate to Data Query page
	Then I can filter out Lease + Click with Service Contract
	And I can filter out Purchase + Click with Service Contract
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |

Scenario Outline: Data Query Usage Type filters
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	When Approver navigate to Data Query page
	Then I can filter out Minimum Volume Usage
	And I can filter out Pay As You Go Usage
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            | ContractType                  | UsageType      | Length  | Billing              | Role1            |
	| United Kingdom | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 years | Quarterly in Arrears | Cloud MPS Dealer |