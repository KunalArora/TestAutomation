@MPS @TEST @UAT @BIEPC110
Feature: CloudMPSFrenchDealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals


@ignore
Scenario Outline: MPS French Dealer can copy an existing proposal offer for all countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal "<Customer>" Customer detail with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	And I copy the proposal created above "<Status>" customer
	Then the copied proposal above is displayed with appropriate customer status	
	And I sign out of Cloud MPS

	
	Scenarios:

	| Role             | Country | ContractType | UsageType                                 | Length | Billing                | Customer               | Status  |
	| Cloud MPS Dealer | France  | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata | Skip customer creation | Without |
	| Cloud MPS Dealer | France  | Buy & Click  | Engagement sur un minimum volume de pages | 4 ans  | Trimestrale anticipata | Create new customer    | With    |
	
