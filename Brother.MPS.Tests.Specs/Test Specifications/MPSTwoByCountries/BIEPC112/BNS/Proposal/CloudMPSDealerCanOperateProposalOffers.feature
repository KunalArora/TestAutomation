@MPS @TEST @UAT @BIEPC112
Feature: CloudMPSSwedishDealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals


@ignore
Scenario Outline: MPS Swedish Dealer can copy an existing proposal offer for all countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal "<Customer>" Customer detail with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	And I copy the proposal created above "<Status>" customer
	Then the copied proposal above is displayed with appropriate customer status	
	And I sign out of Cloud MPS

	
	Scenarios:

	| Role             | Country | ContractType                       | UsageType     | Length     | Billing              | Customer               | Status  |
	| Cloud MPS Dealer | Sweden  | Purchase & click inklusive service | Minimum volym | 36 månader | Kvartalsvis i efterskott | Skip customer creation | Without |
	| Cloud MPS Dealer | Sweden  | Purchase & click inklusive service | Minimum volym | 48 månader | Kvartalsvis i efterskott | Create new customer    | With    |
	