@MPS @TEST @UAT
Feature: CloudMPSOutputContractPDFAllSwedishUsers
	In order to view paper version of contract summary
	As an MPS User
	I want to be able to download contract PDFs

Scenario Outline:  MPS LO Download Awaiting Acceptance Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver contract Awaiting Acceptance page
	Then I can successfully download a Local Approver Contract PDF
	And I can successfully verify that Contract is downloaded
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | Sweden  |
	

Scenario Outline: MPS LO Download Rejected Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver contract Rejected page
	Then I can successfully download a Local Approver Contract PDF
	And I sign out of Cloud MPS


	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | Sweden  |
	
	

Scenario Outline: MPS Contract PDF on Approved Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Approved Acceptance page
	Then I can successfully download a dealer Contract PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Sweden  |
	
	
	
Scenario Outline: MPS Download Contract PDF on Awaiting Acceptance
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Awaiting Acceptance page
	Then I can successfully download a dealer Contract PDF
	#And I can successfully download a dealer Contract Invoice PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Sweden  |
	
	

Scenario Outline: MPS Download Rejected Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Rejected page
	Then I can successfully download a dealer Contract PDF
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Sweden  |
	
