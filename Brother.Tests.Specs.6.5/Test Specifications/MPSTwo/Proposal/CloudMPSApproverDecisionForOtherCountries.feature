﻿@ignore @MPS @TEST @UAT
Feature: CloudMPSApprover decision feature for other Countries
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
	| Country | Role                           | ContractType | UsageType                                 | Length | Billing              |
	| France  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Quarterly in Arrears |
	#| Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Quarterly in Advance |
	

@ignore
Scenario Outline: Declined proposal is displayed on Declined Page for other Countries
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
@ignore
Scenario Outline: Bank Approve Proposal for other Countries
	Given Dealer have created a Awaiting Approval proposal of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	When I select the proposal on Awaiting Proposal
	Then I should be able to approve that proposal
#	And the approved proposal should be displayed under Approved tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country        | ContractType                | UsageType      |
	| Cloud MPS Bank | United Kingdom | Lease & Click with Service  | Pay As You Go  |

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
	| Country | Role                           | ContractType                      | UsageType                                 | Length | Billing              |
	| France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Quarterly in Arrears |
	#| Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Quarterly in Advance |
	

# Accept3

# Accept4

@ignore
Scenario Outline: Bank can approve the contract for other Countries
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role             | Country        | ContractType                  | UsageType      |
	| Cloud MPS Bank   | United Kingdom | Lease & Click with Service    | Pay As You Go  |

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

	| Country | Role                           | ContractType                      | UsageType                                 | Length | Billing              |
	| France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Quarterly in Arrears |
	#| Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Quarterly in Advance |
	
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

	| Country | Role                           | ContractType                      | UsageType                                 | Length | Billing              |
	| France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Quarterly in Arrears |
	#| Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Quarterly in Advance |
	
# Reject3
Scenario Outline: Dealer can resign rejected contract for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Rejected screen
	Then I can successfully re-sign the rejected contract
	And I sign out of Cloud MPS

	Scenarios: 
	| Role               | Country        |
	| Cloud MPS Dealer   | France |

# View open offers
Scenario Outline: Bank can view opened offers for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	Then I should see a list of Offers on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country        |
	| Cloud MPS Bank | United Kingdom |


# View confirmed/rejected/signed offers
@ignore
Scenario Outline: Bank can view confirmed/rejected/signed offers for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Bank Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Offers
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country        | Acceptance         |
	| Cloud MPS Bank                  | United Kingdom | Awating Acceptance |
	| Cloud MPS Bank                  | United Kingdom | Rejected           |
	| Cloud MPS Bank                  | United Kingdom | Accepted           |

# LO Approver can view open offers
Scenario Outline: Local Office Approver can view opened offers for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to ProposalPage
	And I navigate to Awaiting Approval screen under Proposals page
	Then I should see a list of Proposals on Awaiting Approval Tab
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country        |
	| Cloud MPS Local Office Approver | United Kingdom |

# LO Approver can view confirmed/rejected/signed contracts
Scenario Outline: Local Office Approver can view confirmed/rejected/signed contracts for other Countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver Contracts screen on "<Acceptance>" Tab
	Then I should see a list of Proposals
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country        | Acceptance         |
	| Cloud MPS Local Office Approver | United Kingdom | Awating Acceptance |
	| Cloud MPS Local Office Approver | United Kingdom | Rejected           |
	| Cloud MPS Local Office Approver | United Kingdom | Accepted           |
