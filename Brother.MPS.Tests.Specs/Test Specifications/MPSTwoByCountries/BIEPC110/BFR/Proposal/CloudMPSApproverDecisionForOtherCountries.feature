@MPS @TEST @UAT @BIEPC110 @MEDIUM
Feature: CloudMPSFrenchApproverDecisionFeature
	In order to approve/decline Proposal/Contract
	As a Approver
	I want to decide about Proposal/Contract

#
# Decline
#
Scenario Outline: MPS LO Decline Proposal
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then "<Role>" can decline Awaiting Approval "<Country>" "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"

	Scenarios: 
	| Country | Role                            | ContractType | UsageType                                 | Length | Billing                |
	| France  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata |
	
#
# Approve Signed Contract
#
# Accept1, 2
Scenario Outline: MPS LO Can Reject Or Accept
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can either reject or approve the contract
	And I sign out of Cloud MPS

	Scenarios:
	| Country | Role                            | ContractType | UsageType                                 | Length | Billing                |
	| France  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata |
	

# Accept5, 6
Scenario Outline: MPS LO Approve Contract
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	And I sign out of Cloud MPS

	Scenarios:

	| Country | Role                            | ContractType | UsageType                                 | Length | Billing                |
	| France  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata |
	
# Reject1,2
Scenario Outline: MPS LO Reject Contract
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully reject the contract
	And the rejected contract by Approver is displayed on contract Rejected screen
	And I sign out of Cloud MPS

	Scenarios:

	| Country | Role                            | ContractType | UsageType                                 | Length | Billing                |
	| France  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata |
	
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
	| Country | Role                            | ContractType | UsageType                                 | Length | Billing                | Role2            |
	| France  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata | Cloud MPS Dealer |
	
# LO Approver can view open offers
 @ignore
Scenario Outline: MPS LO View Opened Offers
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to ProposalPage
	And I navigate to Awaiting Approval screen under Proposals page
	Then I should see a list of Proposals on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | France  |
	
# LO Approver can view confirmed/rejected/signed contracts
Scenario Outline: MPS LO View Contracts
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Proposals
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country | Acceptance         |
	| Cloud MPS Local Office Approver | France  | Awating Acceptance |
	| Cloud MPS Local Office Approver | France  | Rejected           |
	| Cloud MPS Local Office Approver | France  | Accepted           |
	