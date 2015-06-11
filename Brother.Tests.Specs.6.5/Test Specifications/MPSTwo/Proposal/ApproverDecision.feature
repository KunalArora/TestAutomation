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
@ignore
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

#
# Approve Signed Contract
#
# Accept1
@ignore
Scenario Outline: Bank can decide to reject or approve the contract
	Given Dealer have created Leasing and Click contract
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Contract Awaiting Acceptance page from Bank DashBoard
	Then I can view all the contracts that have been signed by dealer
	And I can either reject or approve the contract
	Scenarios:

	| Role             | Country        |
	| Cloud MPS Bank   | United Kingdom |

# Accept2
### LOApprover

# Accept3

# Accept4
@ignore
Scenario Outline: Bank can approve the contract
	Given Dealer have created Leasing and Click contract
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Contract Awaiting Acceptance page from Bank DashBoard
	Then I can view all the contracts that have been signed by dealer
	And I can successfully approve the contract
	And the accepted contract is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	Scenarios:

	| Role             | Country        |
	| Cloud MPS Bank   | United Kingdom |
# Accept5
### LOApprover

# Accept6
### LOApprover

# Reject1
@ignore
Scenario Outline: Bank can reject the contract
	Given Dealer have created Leasing and Click contract
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Contract Awaiting Acceptance page from Bank DashBoard
	Then I can view all the contracts that have been signed by dealer
	And I can successfully reject the contract
	And the rejected contract is displayed on contract Rejected screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role             | Country        |
	| Cloud MPS Bank   | United Kingdom |

# Reject2
### LOApprover

# Reject3
@ignore
Scenario Outline: Dealer can resign rejected contract
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Rejected screen
	Then I can successfully re-sign the rejected contract

	Scenarios: 
	| Role               | Country        |
	| Cloud MPS Dealer   | United Kingdom |