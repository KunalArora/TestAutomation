@MPS @TEST @UAT
Feature: CloudMPSOutputContractPDFAllUsers
	In order to view paper version of contract summary
	As an MPS User
	I want to be able to download contract PDFs

#@ignore
Scenario Outline: Bank can download Contract PDFs on Awaiting Acceptance page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Contract Awaiting Acceptance page from Bank DashBoard
	Then I can successfully download a Contract PDF On Bank Contract Page
	#And I can successfully download a Contract Invoice PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country        |
	| Cloud MPS Bank | Germany        |
	#| Cloud MPS Bank | United Kingdom |

#@ignore
Scenario Outline: Bank can download Contract PDFs on Rejected page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to bank contract Rejected page
	Then I can successfully download a Contract PDF On Bank Contract Page
	And I sign out of Cloud MPS


	Scenarios: 
	| Role           | Country        |
	| Cloud MPS Bank | Germany        |
	#| Cloud MPS Bank | United Kingdom |

	


Scenario Outline: Local Office Approver can download Contract PDFs on Awaiting Acceptance page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver contract Awaiting Acceptance page
	Then I can successfully download a Local Approver Contract PDF
	#And I can successfully download a Local Approver Contract Invoice PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country        |
	| Cloud MPS Local Office Approver | United Kingdom |
	| Cloud MPS Local Office Approver | Germany        |
	


Scenario Outline: Local Office Approver can download Contract PDFs on Rejected page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver contract Rejected page
	Then I can successfully download a Local Approver Contract PDF
	And I sign out of Cloud MPS


	Scenarios: 
	| Role                            | Country        |
	| Cloud MPS Local Office Approver | United Kingdom |
	| Cloud MPS Local Office Approver | Germany        |
	



Scenario Outline: Dealer can download Contract PDFs on Approved proposal page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Approved Acceptance page
	Then I can successfully download a dealer Contract PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
	| Cloud MPS Dealer | Germany        |
	

Scenario Outline: Dealer can download Contract PDFs on Awaiting Acceptance page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Awaiting Acceptance page
	Then I can successfully download a dealer Contract PDF
	#And I can successfully download a dealer Contract Invoice PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
	| Cloud MPS Dealer | Germany        |


Scenario Outline: Dealer can download Contract PDFs on Rejected page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Rejected page
	Then I can successfully download a dealer Contract PDF
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
	| Cloud MPS Dealer | Germany        |
	