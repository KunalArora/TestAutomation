@MPS @UAT @DEV @TYPE1 @PROPOSALSTATUS @HIGH
Feature: Reject Contract
	In order to clearly monitor the progress of created proposals
	As a Cloud MPS Dealer
	I want to see a contract which has been rejected in the Rejected list

Scenario Outline: Reject contract
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"
When I create a "<ContractType>" proposal
And I enter the proposal description
And I create a new customer for the proposal
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>" and Service Pack type of "<ServicePackType>"
And I add these printers:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-8110DN   | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            |
And I calculate the click price for each of the above printers
And I save the above proposal and submit it for approval
And a Cloud MPS Local Office Approver approves the above proposal
And I have navigated to the Approved Proposals page and navigate to the proposal Summary page for this proposal 
And I sign the above proposal
And a Cloud MPS Local Office Approver rejects the above proposal
Then I can see the above proposal in the Rejected list

@BUK
Scenarios:
		| Country        | ContractType       | UsageType      | BillingType          | ServicePackType | ContractTerm | 
		| United Kingdom | PURCHASE_AND_CLICK | MINIMUM_VOLUME | QUARTERLY_IN_ARREARS | PAY_UPFRONT     | THREE_YEARS  | 