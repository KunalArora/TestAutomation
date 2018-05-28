@MPS @UAT @HIGH @TYPE1 @CI_TestMaintenance
Feature: SubDealerCreationAndProposalTillInstallation
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new sub dealer, then a proposal under this sub dealer and complete the installation of all devices

Scenario Outline: SubDealerCreationAndProposalTillInstallation
Given I have navigated to the Dealership User page in admin tab as a Cloud MPS Dealer from "<Country>"
When I create a new sub dealer
Then I can verify that the Sub dealer is successfully created
Given a Sub dealer has navigated to the create proposal page from "<Country>"
When a Sub dealer create a "<ContractType>" proposal
And a Sub dealer enter the proposal description
And a Sub dealer create a new customer for the proposal
And a Sub dealer select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>" and Service Pack type of "<ServicePackType>"
And a Sub dealer add these printers:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SerialNumber | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | LaserUnit | FuserUnit | PaperFeedingKit1 | PaperFeedingKit2 | PaperFeedingKit3 | IsSwap |
		| DCP-L8450CDW | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 20             | 250          | A3P145602    | 3000           | 1500            | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
And a Sub dealer calculate the click price for each of the above printers
And a Sub dealer save the above proposal and submit it for approval
And a Cloud MPS Local Office Approver approves the above proposal
And a Sub dealer sign the above proposal
And a Cloud MPS Local Office Approver accepts the above proposal
And a Sub dealer navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
And a Sub dealer create a "<InstallationType>" installation request for "<CommunicationMethod>" communication
And a Sub dealer will be able to see the installation request created above on the Manage Devices page for the above proposal
And a Brother installer has navigated to the Web Installation page and verify Contract Reference
And Enter the serial numbers and complete installation
And a Sub dealer navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
Then a Sub dealer will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts

@BUK
Scenarios: 
		| Country        | ContractType       | UsageType      | BillingType          | ServicePackType | ContractTerm | Customer | CommunicationMethod | InstallationType |
		| United Kingdom | PURCHASE_AND_CLICK | MINIMUM_VOLUME | QUARTERLY_IN_ARREARS | PAY_UPFRONT     | THREE_YEARS  | New      | Cloud               | Web              | 
		