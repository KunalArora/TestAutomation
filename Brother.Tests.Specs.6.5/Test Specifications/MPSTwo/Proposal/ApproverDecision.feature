@MPS @TEST @UAT
Feature: Approver decision feture
	In order to approve/decline Proposal/Contract
	As a Approver
	I want to decide about Proposal/Contract

#
# Decline
#
Scenario Outline: Approver Decline Proposal
    Given Dealer have created a Awaiting Approval proposal of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And Approver navigate to ProposalsPage
	And Approver navigate to Awaiting Approval screen under Proposals page
	When Approver select the proposal on Awaiting Proposal
	Then Approver should be able to decline that proposal
	And the decline proposal should be displayed under Declined tab by Approver
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country        | ContractType                  | UsageType      |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume |
	| Cloud MPS Bank                  | United Kingdom | Lease & Click with Service    | Pay As You Go  |

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
Scenario Outline: Bank Approve Proposal
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
Scenario Outline: Approver can decide to reject or approve the contract
    Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can either reject or approve the contract
	And I sign out of Cloud MPS

	Scenarios:
	| Role                            | Country        | ContractType                  | UsageType      |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume |
	| Cloud MPS Bank                  | United Kingdom | Lease & Click with Service    | Pay As You Go  |

# Accept3

# Accept4
Scenario Outline: Bank can approve the contract
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
Scenario Outline: Approver can approve the contract
    Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully approve the contract
	And the accepted contract by Approver is displayed on contract Accepted screen
#	And the accepted contract is displayed on proposal Approved screen
    And I sign out of Cloud MPS

	Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume |
	| Cloud MPS Bank                  | United Kingdom | Lease & Click with Service    | Pay As You Go  |

# Reject1,2
Scenario Outline: Approver can reject the contract
    Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	When Approver navigate to Contract Awaiting Acceptance page from Dashboard
	Then Approver can view all the contracts that have been signed by dealer
	And Approver can successfully reject the contract
	And the rejected contract by Approver is displayed on contract Rejected screen
	And I sign out of Cloud MPS

	Scenarios:

	| Role                            | Country        | ContractType                  | UsageType       |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go   |
	| Cloud MPS Bank                  | United Kingdom | Lease & Click with Service    | Minimum Volume  |

# Reject3
Scenario Outline: Dealer can resign rejected contract
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Rejected screen
	Then I can successfully re-sign the rejected contract
	And I sign out of Cloud MPS

	Scenarios: 
	| Role               | Country        |
	| Cloud MPS Dealer   | United Kingdom |

# View open offers
@Ignore
Scenario Outline: Bank can view opened offers
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
  Then I should see a list of Offers on Awaiting Approbal Tab
  And I sign out of Cloud MPS

	Scenarios: 
	| Role           | Country        |
	| Cloud MPS Bank | United Kingdom |

# View confirmed/rejected/signed offers
@Ignore
Scenario Outline: Bank can view confirmed/rejected/signed offers
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Contracts screen on "<Contract>" Tab
  Then I should see a list of Offers
  And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country        | Contract           |
	| Cloud MPS Bank                  | United Kingdom | Awating Acceptance |
	| Cloud MPS Bank                  | United Kingdom | Rejected           |
	| Cloud MPS Bank                  | United Kingdom | Accepted           |
	| Cloud MPS Local Office Approver | United Kingdom | Awating Acceptance |
	| Cloud MPS Local Office Approver | United Kingdom | Rejected           |
	| Cloud MPS Local Office Approver | United Kingdom | Accepted           |

