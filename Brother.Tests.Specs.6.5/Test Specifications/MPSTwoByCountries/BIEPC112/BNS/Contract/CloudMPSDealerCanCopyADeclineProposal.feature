@MPS @TEST @UAT
Feature: CloudMPSSwedishDealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal

Scenario Outline: MPS Copy Declined Proposal No Customer
	Given I verify and store "<Country>" purchase and click proposal bypass status
	##Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	Then I can copy the declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"

	
	Scenarios:

	| Role             | Country | Role2                           | ContractType                       | UsageType     | Length     | Billing              |
	| Cloud MPS Dealer | Sweden  | Cloud MPS Local Office Approver | Purchase & click inklusive service | Minimum volym | 36 månader | Kvartalsvis i efterskott |
	

Scenario Outline: MPS Copy Declined Proposal Customer
	Given I verify and store "<Country>" purchase and click proposal bypass status
	##Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	Then I can copy the customer detail with the declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"

	
	Scenarios:

	| Role             | Country | Role2                           | ContractType                       | UsageType     | Length     | Billing              |
	| Cloud MPS Dealer | Sweden  | Cloud MPS Local Office Approver | Purchase & click inklusive service | Minimum volym | 36 månader | Kvartalsvis i efterskott |
	