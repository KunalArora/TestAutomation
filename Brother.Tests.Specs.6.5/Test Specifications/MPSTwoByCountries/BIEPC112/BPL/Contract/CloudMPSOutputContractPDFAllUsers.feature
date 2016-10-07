@MPS @TEST @UAT
Feature: CloudMPSOutputContractPDFAllPolishUsers
	In order to view paper version of contract summary
	As an MPS User
	I want to be able to download contract PDFs

Scenario Outline: MPS LO Download Awaiting Acceptance Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver contract Awaiting Acceptance page
	Then I can successfully download a Local Approver Contract PDF
	And I can successfully verify that Contract is downloaded
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | Poland  |
	

Scenario Outline: MPS LO Download Rejected Contract PDF
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully reject the contract
	And the rejected contract by Approver is displayed on contract Rejected screen
	#And I sign out of Cloud MPS
	#Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	#When I navigate to Local Office Approver contract Rejected page
	Then I can successfully download a Local Approver Contract PDF
	And I sign out of Cloud MPS

	Scenarios:

	| Country | Role                            | ContractType | UsageType       | Length | Billing              |
	| Poland  | Cloud MPS Local Office Approver | Buy + Click  | Pakiet wydruków | 3 lata | Miesięczny / Monthly |
	
Scenario Outline: MPS Contract PDF on Approved Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Approved Acceptance page
	Then I can successfully download a dealer Contract PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Poland  |
	
	
Scenario Outline: MPS Download Contract PDF on Awaiting Acceptance
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Awaiting Acceptance page
	Then I can successfully download a dealer Contract PDF
	#And I can successfully download a dealer Contract Invoice PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Poland  |
	
	

Scenario Outline: MPS Download Rejected Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Rejected page
	Then I can successfully download a dealer Contract PDF
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Poland  |
	
	