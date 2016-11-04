@MPS @TEST @UAT @BIEPC111
Feature: CloudMPSFinnishApproverDecisionFeature
	In order to approve/decline Proposal/Contract
	As a Approver
	I want to decide about Proposal/Contract

#
# Decline
#
Scenario Outline: Approver Decline Proposal for other Countries
	Given "<Country>" dealer has created "<ContractType>" proposal of awaiting proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And Approver navigate to ProposalsPage
	And Approver navigate to Awaiting Approval screen under Proposals page
	When Approver select the proposal on Awaiting Proposal
	Then Approver should be able to decline that proposal
	And the decline proposal should be displayed under Declined tab by Approver
	And I sign out of Cloud MPS

	Scenarios: 
	| Country | Role                            | ContractType         | UsageType           | Length   | Billing              |
	| Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | Quarterly in Arrears |
	
#
# Approve Signed Contract
#
# Accept1, 2
Scenario Outline: Approver can decide to reject or approve the contract for other Countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can either reject or approve the contract
	And I sign out of Cloud MPS

	Scenarios:
	| Country | Role                            | ContractType         | UsageType           | Length   | Billing              |
	| Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | Quarterly in Arrears |
	

# Accept5, 6
Scenario Outline: Approver can approve the contract for other Countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	And I sign out of Cloud MPS

	Scenarios:

	| Country | Role                            | ContractType         | UsageType           | Length   | Billing              |
	| Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | Quarterly in Arrears |
	
# Reject1,2
Scenario Outline: Approver can reject the contract for other Countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully reject the contract
	And the rejected contract by Approver is displayed on contract Rejected screen
	And I sign out of Cloud MPS

	Scenarios:

	| Country | Role                            | ContractType         | UsageType           | Length   | Billing              |
	| Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | Quarterly in Arrears |
	

# Reject3
Scenario Outline: Dealer can resign rejected contract for other Countries
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
	| Country | Role                            | ContractType         | UsageType           | Length   | Billing              | Role2            |
	| Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | Quarterly in Arrears | Cloud MPS Dealer |
	
		
# LO Approver can view open offers
Scenario Outline: Local Office Approver can view opened offers for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to ProposalPage
	And I navigate to Awaiting Approval screen under Proposals page
	Then I should see a list of Proposals on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country |
	| Cloud MPS Local Office Approver | Finland |
	
# LO Approver can view confirmed/rejected/signed contracts
Scenario Outline: Local Office Approver can view confirmed/rejected/signed contracts for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Proposals
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country | Acceptance         |
	| Cloud MPS Local Office Approver | Finland | Awating Acceptance |
	| Cloud MPS Local Office Approver | Finland | Rejected           |
	| Cloud MPS Local Office Approver | Finland | Accepted           |
	