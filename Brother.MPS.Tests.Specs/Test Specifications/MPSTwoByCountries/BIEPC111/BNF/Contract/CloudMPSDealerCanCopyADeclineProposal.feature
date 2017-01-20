@MPS @TEST @UAT @BIEPC111
Feature: CloudMPSFinnishDealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal


Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal without customer detail for other countries
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy "<Language>" declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType         | UsageType           | Length   | Billing              |
	| Cloud MPS Dealer | Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | 3 kk välein käytön mukaan |
	

Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal with customer detail for other countries
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy "<Language>" declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType         | UsageType           | Length   | Billing              |
	| Cloud MPS Dealer | Finland | Cloud MPS Local Office Approver | Click tarvikesopimus | Minimitulostusmäärä | 3 vuotta | 3 kk välein käytön mukaan |
	