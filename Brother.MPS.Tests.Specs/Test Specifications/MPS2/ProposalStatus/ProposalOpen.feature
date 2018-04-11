@MPS @UAT @DEV @TYPE1 @PROPOSALSTATUS
Feature: Open Proposal
	In order to clearly monitor the progress of created proposals
	As a Cloud MPS Dealer
	I want to see a proposal which has been open in the Lo Admin dataquery list

Scenario Outline: Open proposal
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"
When I create a "<ContractType>" proposal
And I enter the proposal description
And I create a new customer for the proposal
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>" and Service Pack type of "<ServicePackType>"
And I add these printers:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-8110DN   | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            |
And I calculate the click price for each of the above printers
And I save the proposal 
And a Cloud MPS Local Office Admin navigates to the contract end screen

@BUK
Scenarios: 
		| Country        | ContractType       | UsageType      | BillingType          | ServicePackType | ContractTerm | 
		| United Kingdom | PURCHASE_AND_CLICK | MINIMUM_VOLUME | QUARTERLY_IN_ARREARS | PAY_UPFRONT     | THREE_YEARS  | 