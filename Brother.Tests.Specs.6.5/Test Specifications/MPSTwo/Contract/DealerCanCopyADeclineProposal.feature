@MPS @TEST @UAT
Feature: DealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal


Scenario Outline: Dealer Can Copy A Declined Leasing and Click Proposal without customer detail
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Leasing and Click proposal 
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal without customer
	And I am redirected to Customer screen when I start proposal conversion process
	And I sign out of Cloud MPS
	
	Scenarios:

	| Role             | Country        | Role2          |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Bank |



@Ignore
Scenario Outline: Dealer Can Copy A Declined Leasing and Click Proposal with customer detail
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Leasing and Click proposal 
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal with customer
	And I am redirected to Summary page when I start proposal conversion process
	And I sign out of Cloud MPS

	Scenarios:

	| Role             | Country        | Role2          |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Bank |



Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal without customer detail
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created proposal to local office approver for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above as a Local Office Approver
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal without customer
	And I am redirected to Customer screen when I start proposal conversion process
	And I sign out of Cloud MPS
	
	Scenarios:

	| Role             | Country        | Role2                           |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver |


@Ignore
Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal with customer detail
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created proposal to local office approver for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above as a Local Office Approver
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal with customer
	And I am redirected to Summary page when I start proposal conversion process
	And I sign out of Cloud MPS
	
	Scenarios:

	| Role             | Country        | Role2                           |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver |
