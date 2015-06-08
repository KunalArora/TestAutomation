@Ignore @Test @QAS
Feature: SubmitAllTypesofProposalsToRelevantApprovers
	In order to progress a proposal to contract
	As a dealer
	I want to be able to submit different types of proposals to relevant approvers


Scenario Outline: Send Leasing and Click proposal to bank
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Leasing and Click proposal
	And I am on Proposal List page
	When I click on Action button against the proposal created above
	Then I can click on Convert to Contract button under the Action button
	And I am taken to the proposal summary where I can enter envisage contract start date
	And I can successfully convert the proposal to contract
	And the newly converted contract is available under Awaiting Approval tab
	And I sign out of Cloud MPS
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to bank Awaiting Approval screen under Offer page
	And the converted Leasing and Click and Service proposal above is displayed on the screen

	
	Scenarios:

	| Role             | Country        | ContractType                 | Role2          |
	| Cloud MPS Dealer | United Kingdom | Leasing & Click with Service | Cloud MPS Bank |


Scenario Outline: Send Purchase and Click proposal to bank
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created "<ContractType>" proposal
	When I click on Action button against the proposal created above
	Then I can click on Convert to Contract button under the Action button
	And I am taken to the proposal summary where I can enter envisage contract start date
	And I can successfully convert the proposal to contract
	And the newly converted contract is available under Awaiting Approval tab
	And I sign out of Cloud MPS
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Local Approver Awaiting Approval screen under Offer page
	And the converted Purchase and Click and Service proposal above is displayed on the screen

	
	Scenarios:

	| Role             | Country        | ContractType                  | Role2                                |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | mpslocalofficeapprover@brother.co.uk |
	
