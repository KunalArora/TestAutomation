﻿@MPS @TEST @UAT @BIEPC113 @MEDIUM
Feature: CloudMPSOutputContractPDFAllGermanUsers
	In order to view paper version of contract summary
	As an MPS User
	I want to be able to download contract PDFs

#@ignore
Scenario Outline: MPS Bank Download Awaiting Acceptance Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Contract Awaiting Acceptance page from Bank DashBoard
	Then I can successfully download a Contract PDF On Bank Contract Page
	And I can successfully verify that Bank Contract is downloaded
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country        |
	| Cloud MPS Bank | Germany        |
	| Cloud MPS Bank | Austria        |

#@ignore
Scenario Outline: MPS Bank Download Rejected Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to bank contract Rejected page
	Then I can successfully download a Contract PDF On Bank Contract Page
	And I sign out of Cloud MPS


	Scenarios: 
	| Role           | Country        |
	| Cloud MPS Bank | Germany        |
	| Cloud MPS Bank | Austria        |

	


Scenario Outline: MPS LO Download Awaiting Acceptance Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver contract Awaiting Acceptance page
	Then I can successfully download a Local Approver Contract PDF
	And I can successfully verify that Contract is downloaded
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | Germany |
	| Cloud MPS Local Office Approver | Austria |
	


Scenario Outline: MPS LO Download Rejected Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver contract Rejected page
	Then I can successfully download a Local Approver Contract PDF
	And I sign out of Cloud MPS


	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | Austria |
	| Cloud MPS Local Office Approver | Germany |
	


Scenario Outline: MPS Contract PDF on Approved Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Approved Acceptance page
	Then I can successfully download a dealer Contract PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Austria |
	| Cloud MPS Dealer | Germany |
	
Scenario Outline: MPS Download Contract PDF on Awaiting Acceptance
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Awaiting Acceptance page
	Then I can successfully download a dealer Contract PDF
	#And I can successfully download a dealer Contract Invoice PDF
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Austria |
	| Cloud MPS Dealer | Germany |
	

Scenario Outline: MPS Download Rejected Contract PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract Rejected page
	Then I can successfully download a dealer Contract PDF
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Austria |
	| Cloud MPS Dealer | Germany |
	