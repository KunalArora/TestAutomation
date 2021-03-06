﻿@MPS @UAT @TEST @BIEPC113 @MEDIUM
Feature: CloudMPSDealerFromGermanyCanCloseProposal
	In order to discontinue a proposal from creation process
	As a dealer
	I want to be able to cancel proposal before it gets to contract stage


Scenario Outline: MPS Cancel Leasing Open Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Leasing and Click proposal 
	And I am on Proposal List page
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "Summary" Tab in Proposal
	Then I can close the proposal on the summary page	
	And the closed proposal summary page has no error message
	And I can sign out of Brother Online



Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Austria |
	| Cloud MPS Dealer | Germany |

Scenario Outline: MPS Cancel Purchase Open Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Purchase and Click proposal 
	And I am on Proposal List page
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "Summary" Tab in Proposal
	Then I can close the proposal on the summary page
	And the closed proposal summary page has no error message
	And I can sign out of Brother Online

Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany |
	| Cloud MPS Dealer | Austria |

Scenario Outline: MPS Cancel Leasing Awaiting Approval Proposal
	Given I verify and store "<Country>" Lease and click proposal bypass status
	Then I can close an awaiting proposal without error on summary page as "<Country>" "<Role>"

Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany |
	| Cloud MPS Dealer | Austria |


Scenario Outline: MPS Cancel Purchase Awaiting Approval Proposal
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can close a purchase and click awaiting proposal without error on summary page as "<Country>" "<Role>"

	
Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany |
	| Cloud MPS Dealer | Austria |


Scenario Outline: MPS Cancel Leasing Approved Proposal
	Given I verify and store "<Country>" Lease and click proposal bypass status
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Leasing and Click proposal 
	And I am on Proposal List page
	And I send the created German proposal for approval
	And I sign out of Cloud MPS
	And I approve Leasing and Click proposal as a "<Role2>" from "<Country>"
	#And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	#And I approve the proposal created above
	#And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer approved proposal page
	And I identify and navigate to the approved proposal summary
	Then I can close the proposal on the summary page
	And the closed proposal summary page has no error message
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country | Role2          |
	| Cloud MPS Dealer | Germany  | Cloud MPS Bank |
	| Cloud MPS Dealer | Austria  | Cloud MPS Bank |


Scenario Outline: MPS Cancel Purchase Approved Proposal
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created German proposal for approval
	And I sign out of Cloud MPS
	And I approve purchase and click proposal as a "<Role2>" from "<Country>"
	#And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	#And I approve the purchase and click proposal created above
	#And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer approved proposal page
	And I identify and navigate to the approved proposal summary
	Then I can close the proposal on the summary page
	And the closed proposal summary page has no error message
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country | Role2                           |
	| Cloud MPS Dealer | Germany | Cloud MPS Local Office Approver |
	| Cloud MPS Dealer | Austria | Cloud MPS Local Office Approver |
	

	
