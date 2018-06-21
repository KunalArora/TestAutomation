@MPS @UAT @HIGH @TYPE1 @EUM @CI_TestMaintenance
Feature: Type1EnhancedUsageMonitoring
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer with the help of Cloud MPS LO Admin
	I want to ensure the correct working of the default order threshold functionality for Type 1

Scenario Outline: Type1EnhancedUsageMonitoring
Given a Cloud MPS Local Office Admin has navigated to the Dashboard page
When a Cloud MPS Local Office Admin navigates to the Printer Engine tab under Manage Device Order Threshold section
Then a Cloud MPS Local Office Admin can set the threshold value for printer engines types as follows and saves the details
		| PrinterEngine | SupplyItemType | Threshold | Enabled |
		| BC2 Step      | Mono           | 14.00     | true    |
		| BC2 Step      | Colour         | 12.00     | true    |
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"
When I create a "<ContractType>" proposal
And I enter the proposal description
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>", Service Pack type of "<ServicePackType>" and Leasing Billing Cycle of "<LeasingBillingCycle>"
And I add these printers:
		| Model        | Price  | InstallationPack | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | MonoThresholdValue | ColourThresholdValue | TonerInkBlackRemLife | TonerInkCyanRemLife | TonerInkMagentaRemLife | TonerInkYellowRemLife |
		| DCP-L8450CDW | 300.00 |                  | Yes      | 5            | 1000       | 0              | 0            | 12.00              | 10.00                | 11                   | 100                 | 9                      | 100                   |
And I calculate the click price for each of the above printers
And I save the above proposal and submit it for approval
And a Cloud MPS Bank release the above proposal
Then I have navigated to the Approved Proposals page and navigate to the proposal Summary page for this proposal
When a Cloud MPS Local Office Approver navigates to Manage Device Order Threshold section and ensures correct display of tabs
Then a Cloud MPS Local Office Approver can search for the proposal and ensure printer details are not displayed
When I sign the above proposal
And a Cloud MPS Local Office Approver searches for the agreement and ensures correct printer and threshold details
Then a Cloud MPS Local Office Approver updates the threshold value for printers and saves the details
When I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
And I create a "<InstallationType>" installation request for "<CommunicationMethod>" communication
And I will be able to see the installation request created above on the Manage Devices page for the above proposal
And a Brother installer has navigated to the Web Installation page and verify Contract Reference
And Enter the serial numbers and complete installation
And I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
And I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts
And a Cloud MPS Bank Cloud MPS Bank Summary Accept
And a Cloud MPS Bank Populated Maintain Contact
Then I set the Contract in the running state
When I automatically raise a consumable order for above devices
Then I can verify the generation of automatic consumable orders alongwith status


@BIG
Scenarios: 
		| Country | ContractType        | UsageType     | BillingType            | ServicePackType         | ContractTerm | Customer | CommunicationMethod | InstallationType | LeasingBillingCycle |
		| Germany | LEASING_AND_SERVICE | PAY_AS_YOU_GO | HALF_YEARLY_IN_ARREARS | ADD_TO_THE_LEASING_RATE | FIVE_YEARS   | New      | Cloud               | Web              | MONTHLY             |
		