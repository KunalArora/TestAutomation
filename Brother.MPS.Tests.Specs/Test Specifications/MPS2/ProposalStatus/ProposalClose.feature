@MPS @UAT @TYPE1 @PROPOSALSTATUS @HIGH @CI_TestMaintenance
Feature: Close Proposal
	In order to clearly monitor the progress of created proposals
	As a Cloud MPS Dealer
	I want to verify a proposal successfully goes into the closed state

Scenario Outline: Close Proposal
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
And I cancel the above proposal and verify the proposal is in closed state
Then I can verify the proposal is present in the dataquery page



@BUK
Scenarios: 
		| Country        | ContractType       | UsageType      | BillingType          | ServicePackType | ContractTerm | 
		| United Kingdom | PURCHASE_AND_CLICK | MINIMUM_VOLUME | QUARTERLY_IN_ARREARS | PAY_UPFRONT     | THREE_YEARS  | 