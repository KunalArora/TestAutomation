@MPS @TEST @UAT @BIEPC110
Feature: CloudMPSSwissApproverDecisionFeature
	In order to approve/decline Proposal/Contract
	As a Approver
	I want to decide about Proposal/Contract

#
# Decline
#
Scenario Outline: Approver Decline Proposal for other Countries
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then "<Role>" can decline Awaiting "<Language>" Approval "<Country>" "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"

	Scenarios:

	| Country     | Role                            | ContractType                  | UsageType      | Length | Billing              | Language |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Volume minimal | 36     | Quarterly in Arrears | Français |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Mindestvolumen | 36     | Quarterly in Arrears | Deutsch  |
	
#
# Approve Signed Contract
#
# Accept1, 2
Scenario Outline: Approver can decide to reject or approve the contract for other Countries
	Given "<Country>" Dealer with "<Language>" language have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can either reject or approve the contract
	And I sign out of Cloud MPS

	Scenarios:

	| Country     | Role                            | ContractType                  | UsageType      | Length | Billing              | Language |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Volume minimal | 36     | Quarterly in Arrears | Français |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Mindestvolumen | 36     | Quarterly in Arrears | Deutsch  |

# Accept5, 6
Scenario Outline: Approver can approve the contract for other Countries
	Given "<Country>" Dealer with "<Language>" language have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	And I sign out of Cloud MPS

	Scenarios:

	| Country     | Role                            | ContractType                  | UsageType      | Length | Billing              | Language |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Volume minimal | 36     | Quarterly in Arrears | Français |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Mindestvolumen | 36     | Quarterly in Arrears | Deutsch  |
	
# Reject1,2
Scenario Outline: Approver can reject the contract for other Countries
	Given "<Country>" Dealer with "<Language>" language have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully reject the contract
	And the rejected contract by Approver is displayed on contract Rejected screen
	And I sign out of Cloud MPS

	Scenarios:

	| Country     | Role                            | ContractType                  | UsageType      | Length | Billing              | Language |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Volume minimal | 36     | Quarterly in Arrears | Français |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Mindestvolumen | 36     | Quarterly in Arrears | Deutsch  |
	
# Reject3
Scenario Outline: Dealer can resign rejected contract for other Countries
	Given "<Country>" Dealer with "<Language>" language have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
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

	| Country     | Role                            | ContractType                  | UsageType      | Length | Billing              | Language |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Volume minimal | 36     | Quarterly in Arrears | Français |
	| Switzerland | Cloud MPS Local Office Approver | Purchase & Click with Service | Mindestvolumen | 36     | Quarterly in Arrears | Deutsch  |
	
		
# LO Approver can view open offers
Scenario Outline: Local Office Approver can view opened offers for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to ProposalPage
	And I navigate to Awaiting Approval screen under Proposals page
	Then I should see a list of Proposals on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country     |
	| Cloud MPS Local Office Approver | Switzerland |
	
# LO Approver can view confirmed/rejected/signed contracts
Scenario Outline: Local Office Approver can view confirmed/rejected/signed contracts for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Proposals
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country     | Acceptance         |
	| Cloud MPS Local Office Approver | Switzerland | Awating Acceptance |
	| Cloud MPS Local Office Approver | Switzerland | Rejected           |
	| Cloud MPS Local Office Approver | Switzerland | Accepted           |
	