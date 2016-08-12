﻿@MPS @TEST @UAT
Feature: CloudMPSBelgianDealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal

Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal without customer detail for other countries
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy "<Language>" declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType                  | UsageType      | Length | Billing              | Language |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Buy & Click                   | Volume minimum | 3 ans  | Quarterly in Arrears | French   |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 jaar | Quarterly in Arrears | Dutch    |
	

Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal with customer detail for other countries
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy "<Language>" customer detail with the declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType                  | UsageType      | Length | Billing              | Language |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Buy & Click                   | Volume minimum | 3 ans  | Quarterly in Arrears | French   |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 jaar | Quarterly in Arrears | Dutch    |
	