@MPS @TEST @UAT @BIEPC112
Feature: CloudMPSBelgianDealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal

Scenario Outline: MPS Copy Declined Proposal No Customer
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy "<Language>" declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType                  | UsageType      | Length | Billing                                                            | Language |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Buy & Click                   | Volume minimum | 3 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | French   |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 jaar | Jaarlijke afrekening / Décompte annuel                             | Dutch    |
	

Scenario Outline: MPS Copy Declined Proposal Customer
	Given I verify and store "<Country>" purchase and click proposal bypass status
	Then I can copy "<Language>" customer detail with the declined "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>" as a "<Role>" from "<Country>" and approved by "<Role2>"
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType                  | UsageType      | Length | Billing                                                            | Language |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Buy & Click                   | Volume minimum | 3 ans  | Jaarlijke afrekening / Décompte annuel                             | French   |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 jaar | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | Dutch    |
	