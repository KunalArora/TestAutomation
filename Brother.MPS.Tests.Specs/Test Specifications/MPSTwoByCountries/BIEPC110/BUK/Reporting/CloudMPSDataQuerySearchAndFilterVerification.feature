	@MPS @TEST @UAT @BIEPC110 @CRITICAL
	Feature: CloudMPSDataQuerySearchAndFilterVerification
	In order verify that all search and filters are working on Data Query page
	As a LO Approver
	I want to be able to filter all the results displayed on the Data Query page

Scenario Outline: Data Query searches
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	When Approver navigate to Data Query page
	Then I can search with contract id "115287"
	And search using serial number "A1T010233"
	And I can change the search dates
	And I can search with show ending contracts 
	And I sign out of Cloud MPS

	Scenarios: 
	| Country        | Role                            |
	| United Kingdom | Cloud MPS Local Office Approver |
	


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
	| Country        | Role                            | 
	| United Kingdom | Cloud MPS Local Office Approver | 


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
	| Country        | Role                            | 
	| United Kingdom | Cloud MPS Local Office Approver | 


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