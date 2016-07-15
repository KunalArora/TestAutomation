@MPS @TEST @UAT
Feature: CloudMPSGermanDealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal


Scenario Outline: Dealer Can Copy A Declined Leasing and Click Proposal without customer detail
	Given I verify and store "<Country>" Lease and click proposal bypass status 
	Then I can copy the declined Lease and Click proposal without customer detail as a "<Role>" from "<Country>" and approved by "<Role2>" 

		
	Scenarios:

	| Role             | Country | Role2          |
	| Cloud MPS Dealer | Germany | Cloud MPS Bank |
	| Cloud MPS Dealer | Austria | Cloud MPS Bank |
	



Scenario Outline: Dealer Can Copy A Declined Leasing and Click Proposal with customer detail
	Given I verify and store "<Country>" Lease and click proposal bypass status 
	Then I can copy the declined Lease and Click proposal as a "<Role>" from "<Country>" and approved by "<Role2>" 
	
	Scenarios:

	| Role             | Country | Role2          |
	| Cloud MPS Dealer | Germany | Cloud MPS Bank |
	| Cloud MPS Dealer | Austria | Cloud MPS Bank |


Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal with customer detail
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy the declined proposal as a "<Role>" from "<Country>" and approved by "<Role2>"
		

	Scenarios:

	| Role             | Country | Role2                           |
	| Cloud MPS Dealer | Germany | Cloud MPS Local Office Approver |
	| Cloud MPS Dealer | Austria | Cloud MPS Local Office Approver |
	

Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal without customer detail
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy the declined proposal without customer detail as a "<Role>" from "<Country>" and approved by "<Role2>"

	
	Scenarios:

	| Role             | Country | Role2                           |
	| Cloud MPS Dealer | Germany | Cloud MPS Local Office Approver |
	| Cloud MPS Dealer | Austria | Cloud MPS Local Office Approver |


	
	