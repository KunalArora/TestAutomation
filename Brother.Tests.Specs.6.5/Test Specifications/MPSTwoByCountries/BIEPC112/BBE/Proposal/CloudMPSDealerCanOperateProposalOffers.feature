@MPS @TEST @UAT
Feature: CloudMPSBelgianDealerCanOperateProposalOffers
	In order to view/edit/delete/copy existing proposals
	As an MPS Dealer
	I want to operate existing proposals

Scenario Outline: MPS Belgian Dealer can copy an existing proposal offer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	When I can Copy "<Operation>" Customer an item of Exisiting Proposal table "<Target>" Customer
	Then I can see the Proposal offer which copied "<Operation>" Customer
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country | Operation | Target  | Language |
	| Cloud MPS Dealer | Belgium | Without   | Without | Dutch    |
	| Cloud MPS Dealer | Belgium | Without   | Without | French   |
	#| Cloud MPS Dealer | Belgium   | Without   | Without |
	
	@ignore
Scenario Outline: MPS Belgian Dealer can copy an existing proposal offer for all countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal "<Customer>" Customer detail with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	And I copy the proposal created above "<Status>" customer
	Then the copied proposal above is displayed with appropriate customer status	
	And I sign out of Cloud MPS

	
	Scenarios:

	| Role             | Country | ContractType                  | UsageType      | Length | Billing              | Customer               | Status  | Language |
	| Cloud MPS Dealer | Belgium | Purchase & Click with Service | Minimum Volume | 3 jaar | Quarterly in Arrears | Skip customer creation | Without | Dutch    |
	| Cloud MPS Dealer | Belgium | Purchase & Click with Service | Minimum Volume | 3 jaar | Quarterly in Arrears | Create new customer    | With    | Dutch    |
	| Cloud MPS Dealer | Belgium | Buy & Click                   | Volume minimum | 3 ans  | Quarterly in Arrears | Create new customer    | With    | French   |
	| Cloud MPS Dealer | Belgium | Buy & Click                   | Volume minimum | 3 ans  | Quarterly in Arrears | Skip customer creation | Without | French   |
	