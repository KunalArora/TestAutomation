@TEST @UAT
Feature: Approver decision feture
	In order to approve/decline Proposal/Contract
	As a Approver
	I want to decide about Proposal/Contract

@ignore
# Contract name should be removed by feature
Scenario Outline: Bank Decline Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	When I select a proposal from "<Name>" of Proposal
	Then I should be able to decline that proposal
	And the decline proposal should be displayed under Declined tab

	Scenarios: 
	| Role           | Country        | Name    |
	| Cloud MPS Bank | United Kingdom | TEST 23 |

#
# Decline
#

@ignore
# Contract name should be removed by feature
Scenario Outline: LO Approver Decline Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	When I select a proposal from "<Name>" of Proposal
	Then I should be able to decline that proposal
	And the decline proposal should be displayed under Declined tab

	Scenarios: 
	| Role           | Country        | Name    |
	| Cloud MPS Bank | United Kingdom | TEST 23 |

@ignore
Scenario Outline: Declined proposal is displayed on Declined Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to OfferPage
	When I navigate to Declined screen under Offer page
#	Then I can view all the proposals declined by both Bank and LocalOffice Approver

	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

#
# Pending
#

#
# Approve
#
# Contract name should be removed by feature
Scenario Outline: Bank Approve Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	When I select a proposal from "<Name>" of Proposal
	Then I should be able to approve that proposal
#	And the approved proposal should be displayed under Approved tab

	Scenarios: 
	| Role           | Country        | Name    |
	| Cloud MPS Bank | United Kingdom | MPS_Ross-2015069074732 |
