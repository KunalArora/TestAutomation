@MPS @UAT @TEST @BIEPC110 @MEDIUM
Feature: CloudMPSUKDealerCanCloseProposal
	In order to discontinue a proposal from creation process
	As a dealer
	I want to be able to cancel proposal before it gets to contract stage


Scenario Outline: MPS Cancel Open Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal
	And I am on Proposal List page
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "Summary" Tab in Proposal
	Then I can close the proposal on the summary page
	And the closed proposal summary page has no error message
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |



Scenario Outline: MPS Cancel Awaiting Approval Proposal
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then "<Role>" can cancel "<Country>" Awaiting Approval proposal
	#Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	#And I have created Purchase and Click proposal 
	#And I am on Proposal List page
	#And I send the created proposal for approval
	#When I navigate to the Summary page of the proposal awaiting approval
	#Then I can close the proposal on the summary page
	#And the closed proposal summary page has no error message
	#And I can sign out of Brother Online


Scenarios:

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: MPS Cancel Approved Proposal
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created proposal for approval
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

	| Role             | Country        | Role2                           |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver |
	
