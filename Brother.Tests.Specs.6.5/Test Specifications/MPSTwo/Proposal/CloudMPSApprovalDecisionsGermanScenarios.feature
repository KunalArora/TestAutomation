﻿@MPS @TEST @UAT
Feature: CloudMPSGerman Approver decision feature
	In order to approve/decline Proposal/Contract
	As a Approver
	I want to decide about Proposal/Contract

#
# Decline
#
Scenario Outline: German Approver Decline Proposal
	Given German Dealer have created a Awaiting Approval proposal of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And Approver navigate to ProposalsPage
	And Approver navigate to Awaiting Approval screen under Proposals page
	When Approver select the proposal on Awaiting Proposal
	Then Approver should be able to decline that proposal with "<Reason>"
	And the decline proposal should be displayed under Declined tab by Approver
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country | ContractType                  | UsageType      | Reason |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume | Andere |
	#| Cloud MPS Bank                  | United Kingdom | Lease & Click with Service    | Pay As You Go  |
	
	

@ignore
Scenario Outline: German Declined proposal is displayed on Declined Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to OfferPage
	#When I navigate to Declined screen under Offer page
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
Scenario Outline: German Bank Approve Proposal
	Given German Dealer have created a Awaiting Approval proposal of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	When I select the proposal on Awaiting Proposal
	Then I should be able to approve that proposal
#	And the approved proposal should be displayed under Approved tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country | ContractType               | UsageType     |
	| Cloud MPS Bank | Germany | Leasing & Service | Pay As You Go |

#
# Approve Signed Contract
#
# Accept1, 2
Scenario Outline: German Approver can decide to reject or approve the contract
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can either reject or approve the contract
	And I sign out of Cloud MPS

	Scenarios:
	| Role                            | Country | ContractType                  | UsageType      |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume |
	#| Cloud MPS Bank                  | United Kingdom | Leasing & Service   | Pay As You Go  |

# Accept3

# Accept4


Scenario Outline: German Bank can approve the contract
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role           | Country | ContractType               | UsageType     |
	| Cloud MPS Bank | Germany | Leasing & Service | Pay As You Go |
	
# Accept5, 6
Scenario Outline: German Approver can approve the contract
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role                            | Country | ContractType                  | UsageType      |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume |
	| Cloud MPS Bank                  | Germany | Leasing & Service    | Pay As You Go  |

# Reject1,2
Scenario Outline: German Approver can reject the contract
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully reject the contract with "<Option>" option
	And the rejected contract by Approver is displayed on contract Rejected screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Option |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Pay As You Go  | Andere |
	| Cloud MPS Bank                  | Germany | Leasing & Service    | Minimum Volume | Andere |
	
	
	
# Reject3
Scenario Outline: German Dealer can resign rejected contract
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Rejected screen
	Then I can successfully re-sign the rejected contract
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country |
	| Cloud MPS Dealer | Germany |
	
# View open offers
Scenario Outline: German Bank can view opened offers
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	Then I should see a list of Offers on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country |
	| Cloud MPS Bank | Germany |
	

# View confirmed/rejected/signed offers

Scenario Outline: German Bank can view confirmed/rejected/signed offers
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Bank Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Offers
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country | Acceptance         |
	| Cloud MPS Bank | Germany | Awating Acceptance |
	| Cloud MPS Bank | Germany | Rejected           |
	| Cloud MPS Bank | Germany | Accepted           |
	
# LO Approver can view open offers
Scenario Outline: German Local Office Approver can view opened offers
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to ProposalPage
	And I navigate to Awaiting Approval screen under Proposals page
	Then I should see a list of Proposals on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | Germany |
	
# LO Approver can view confirmed/rejected/signed contracts
Scenario Outline: German Local Office Approver can view confirmed/rejected/signed contracts
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Proposals
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country | Acceptance         |
	| Cloud MPS Local Office Approver | Germany | Awating Acceptance |
	| Cloud MPS Local Office Approver | Germany | Rejected           |
	| Cloud MPS Local Office Approver | Germany | Accepted           |
	
