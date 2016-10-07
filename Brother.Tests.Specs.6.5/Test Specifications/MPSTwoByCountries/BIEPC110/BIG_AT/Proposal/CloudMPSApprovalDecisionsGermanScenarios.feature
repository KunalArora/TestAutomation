@MPS @TEST @UAT
Feature: CloudMPSApproverFromGermanyDecisionFeature
	In order to approve/decline Proposal/Contract
	As a Approver
	I want to decide about Proposal/Contract

#
# Decline
#
Scenario Outline: MPS LO Decline Proposal
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then "<Role>" can decline "<Country>" Awaiting Approval "<ContractType>" proposal of "<UsageType>" with "<Reason>"
	
	Scenarios: 
	| Role                            | Country | ContractType             | UsageType      | Reason |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen | Andere |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen | Andere |
	
#
# Approve
#
Scenario Outline: MPS Bank Decline Proposal
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then "<Role>" can decline "<Country>" Leasing Awaiting Approval "<ContractType>" proposal of "<UsageType>"
	
	Scenarios: 
	| Role           | Country | ContractType      | UsageType     |
	| Cloud MPS Bank | Germany | Leasing & Service | Pay As You Go |
	| Cloud MPS Bank | Austria | Leasing & Service | Pay As You Go |
	

#
# Approve Signed Contract
#
# Accept1, 2
Scenario Outline: MPS LO Can Reject Or Accept
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can either reject or approve the contract
	And I sign out of Cloud MPS

	Scenarios:
	| Role                            | Country | ContractType             | UsageType      |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen |
	
	
# Accept3

# Accept4


Scenario Outline: MPS Bank Approve Contract
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role           | Country | ContractType      | UsageType     |
	| Cloud MPS Bank | Germany | Leasing & Service | Pay As You Go |
	| Cloud MPS Bank | Austria | Leasing & Service | Pay As You Go |
	
	
# Accept5, 6
Scenario Outline: MPS LO Approve Contract
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role                            | Country | ContractType             | UsageType      |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen |
	| Cloud MPS Bank                  | Germany | Leasing & Service        | Pay As You Go  |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen |
	| Cloud MPS Bank                  | Austria | Leasing & Service        | Pay As You Go  |
	

# Reject1,2
Scenario Outline: MPS LO Reject Contract
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully reject the contract with "<Option>" option
	And the rejected contract by Approver is displayed on contract Rejected screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Option |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Pay As You Go  | Andere |
	| Cloud MPS Bank                  | Germany | Leasing & Service        | Mindestvolumen | Andere |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Pay As You Go  | Andere |
	| Cloud MPS Bank                  | Austria | Leasing & Service        | Mindestvolumen | Andere |
	
	
	
	
# Reject3
Scenario Outline: MPS Resign Rejected Contract
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully reject the contract
	And the rejected contract by Approver is displayed on contract Rejected screen
	And I sign out of Cloud MPS
	Given I sign into Cloud MPS as a "<Role2>" from "<Country>"
	When I navigate to Rejected screen
	Then I can successfully re-sign the rejected contract
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role                            | Country | ContractType             | UsageType      | Option | Role2             |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Pay As You Go  | Andere | Cloud MPS Dealer |
	| Cloud MPS Bank                  | Germany | Leasing & Service        | Mindestvolumen | Andere | Cloud MPS Dealer |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Pay As You Go  | Andere | Cloud MPS Dealer |
	| Cloud MPS Bank                  | Austria | Leasing & Service        | Mindestvolumen | Andere | Cloud MPS Dealer |
	
# View open offers
Scenario Outline: MPS Bank View Opened Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	Then I should see a list of Offers on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country |
	| Cloud MPS Bank | Germany |
	| Cloud MPS Bank | Austria |
	

# View confirmed/rejected/signed offers

Scenario Outline: MPS Bank View Contracts
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Bank Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Offers
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country | Acceptance         |
	| Cloud MPS Bank | Germany | Awating Acceptance |
	| Cloud MPS Bank | Germany | Rejected           |
	| Cloud MPS Bank | Germany | Accepted           |
	| Cloud MPS Bank | Austria | Awating Acceptance |
	| Cloud MPS Bank | Austria | Rejected           |
	| Cloud MPS Bank | Austria | Accepted           |
	
# LO Approver can view open offers
Scenario Outline: MPS LO View Opened Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to ProposalPage
	And I navigate to Awaiting Approval screen under Proposals page
	Then I should see a list of Proposals on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | Germany |
	| Cloud MPS Local Office Approver | Austria |
	
# LO Approver can view confirmed/rejected/signed contracts
Scenario Outline: MPS LO View Contracts
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Proposals
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country | Acceptance         |
	| Cloud MPS Local Office Approver | Germany | Awating Acceptance |
	| Cloud MPS Local Office Approver | Germany | Rejected           |
	| Cloud MPS Local Office Approver | Germany | Accepted           |
	| Cloud MPS Local Office Approver | Austria | Awating Acceptance |
	| Cloud MPS Local Office Approver | Austria | Rejected           |
	| Cloud MPS Local Office Approver | Austria | Accepted           |
	

