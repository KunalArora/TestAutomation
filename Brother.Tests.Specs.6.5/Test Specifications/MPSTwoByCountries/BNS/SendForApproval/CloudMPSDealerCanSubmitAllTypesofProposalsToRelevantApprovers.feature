@MPS @TEST @UAT
Feature: CloudMPSSwedishDealerSubmitAllTypesofProposalsToRelevantApprovers
	In order to progress a proposal to contract
	As a dealer
	I want to be able to submit different types of proposals to relevant approvers


Scenario Outline: Send certain proposals for approval
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	Then I can click on Convert to Contract button under the Action button
	And I am directed to customer detail page for more data capture
	And I am taken to purchase and click summary where I can enter envisage contract start date
	And I can successfully convert the proposal to contract
	And the newly converted contract is available under Awaiting Approval tab
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Local Approver Awaiting Approval screen under Offer page
	And the converted Purchase and Click and Service proposal above is displayed on the screen
	And I sign out of Cloud MPS

	
	Scenarios:

	| Role             | Country | Role2                           | ContractType | UsageType                                 | Length | Billing                |
	| Cloud MPS Dealer | Sweden  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata |
	

Scenario Outline: Send certain approval for Privately Liable Customer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	Then I can click on Convert to Contract button under the Action button
	And I am directed to customer detail page for "<Private>" privately liable data capture
	And I am taken to purchase and click summary where I can enter envisage contract start date
	And I can successfully convert the proposal to contract
	And the newly converted contract is available under Awaiting Approval tab
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Local Approver Awaiting Approval screen under Offer page
	And the converted Purchase and Click and Service proposal above is displayed on the screen
	And I sign out of Cloud MPS
	
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType | UsageType                                 | Length | Billing                | Private |
	| Cloud MPS Dealer | Sweden  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata | Autre   |
	

Scenario Outline: Send certain proposal for Approval for Customer who can order consumables
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	Then I can click on Convert to Contract button under the Action button
	And I am directed to customer detail page for can order data capture
	And I am taken to purchase and click summary where I can enter envisage contract start date
	And I can successfully convert the proposal to contract
	And the newly converted contract is available under Awaiting Approval tab
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Local Approver Awaiting Approval screen under Offer page
	And the converted Purchase and Click and Service proposal above is displayed on the screen
	And I sign out of Cloud MPS


	Scenarios:

	| Role             | Country | Role2                           | ContractType | UsageType                                 | Length | Billing                |
	| Cloud MPS Dealer | Sweden  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata |

Scenario Outline: Send certain proposal for Approval for Privately Liable Customer who can order consumables
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	Then I can click on Convert to Contract button under the Action button
	And I am directed to capture customer detail page for "<Private>" privately liable customer who can order
	And I am taken to purchase and click summary where I can enter envisage contract start date
	And I can successfully convert the proposal to contract
	And the newly converted contract is available under Awaiting Approval tab
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Local Approver Awaiting Approval screen under Offer page
	And the converted Purchase and Click and Service proposal above is displayed on the screen
	And I sign out of Cloud MPS

	
	Scenarios:

	| Role             | Country | Role2                           | ContractType | UsageType                                 | Length | Billing                | Private |
	| Cloud MPS Dealer | Sweden  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata | Autre   |
	