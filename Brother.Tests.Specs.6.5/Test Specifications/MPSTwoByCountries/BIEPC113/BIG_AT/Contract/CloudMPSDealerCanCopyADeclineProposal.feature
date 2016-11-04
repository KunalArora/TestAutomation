@MPS @TEST @UAT @BIEPC113
Feature: CloudMPSGermanDealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal


Scenario Outline: MPS Copy Leasing Declined Proposal No Customer
	Given I verify and store "<Country>" Lease and click proposal bypass status 
	Then I can copy the declined Lease and Click proposal without customer detail as a "<Role>" from "<Country>" and approved by "<Role2>" 

		
	Scenarios:

	| Role             | Country | Role2          |
	| Cloud MPS Dealer | Germany | Cloud MPS Bank |
	| Cloud MPS Dealer | Austria | Cloud MPS Bank |
	



Scenario Outline: MPS Copy Leasing Declined Proposal Customer
	Given I verify and store "<Country>" Lease and click proposal bypass status 
	Then I can copy the declined Lease and Click proposal as a "<Role>" from "<Country>" and approved by "<Role2>" 
	
	Scenarios:

	| Role             | Country | Role2          |
	| Cloud MPS Dealer | Germany | Cloud MPS Bank |
	| Cloud MPS Dealer | Austria | Cloud MPS Bank |


Scenario Outline: MPS Copy Declined Proposal No Customer
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy the declined proposal as a "<Role>" from "<Country>" and approved by "<Role2>"
		

	Scenarios:

	| Role             | Country | Role2                           |
	| Cloud MPS Dealer | Germany | Cloud MPS Local Office Approver |
	| Cloud MPS Dealer | Austria | Cloud MPS Local Office Approver |
	

Scenario Outline: MPS Copy Declined Proposal Customer
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy the declined proposal without customer detail as a "<Role>" from "<Country>" and approved by "<Role2>"

	
	Scenarios:

	| Role             | Country | Role2                           |
	| Cloud MPS Dealer | Germany | Cloud MPS Local Office Approver |
	| Cloud MPS Dealer | Austria | Cloud MPS Local Office Approver |


	
	