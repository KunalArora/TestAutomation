@MPS @TEST @UAT
Feature: CloudMPSDannishDealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal


Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal without customer detail for other countries
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy the declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"
	
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType           | UsageType       | Length | Billing              |
	| Cloud MPS Dealer | Denmark | Cloud MPS Local Office Approver | Køb & Klik med service | Minimumsvolumen | 3 år   | Quarterly in Arrears |
	


Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal with customer detail for other countries
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy the customer detail with the declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"
	
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType           | UsageType       | Length | Billing              |
	| Cloud MPS Dealer | Denmark | Cloud MPS Local Office Approver | Køb & Klik med service | Minimumsvolumen | 3 år   | Quarterly in Arrears |
	