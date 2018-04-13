@MPS @UAT @TYPE1 @ENDTOEND
Feature: Type1BusinessScenario_6
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new contract and complete the installation of all devices

Scenario Outline: Business Scenario 6
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"
When I create a "<ContractType>" proposal
And I enter the proposal description
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>", Service Pack type of "<ServicePackType>" and Leasing Billing Cycle of "<LeasingBillingCycle>"
And I add these printers:
		| Model        | Price  | InstallationPack          | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SerialNumber | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | LaserUnit | FuserUnit | PaperFeedingKit1 | PaperFeedingKit2 | PaperFeedingKit3 | IsSwap |
#		| DCP-8110DN   | 300.00 |                           | Yes      | 5            | 1000       | 0              | 0            | A3P145600    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
#		| HL-5450DN    | 300.00 |                           | Yes      | 5            | 1000       | 0              | 0            | A3P145601    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| DCP-L8450CDW | 300.00 |                           | Yes      | 5            | 1000       | 20             | 250          | A3P145602    | 23             | 100             | Normal              | Empty              | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
#		| MFC-L8650CDW | 300.00 |                           | Yes      | 5            | 1000       | 20             | 200          | A3P145603    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
#		| DCP-8250DN   | 300.00 |                           | Yes      | 5            | 1000       | 0              | 250          | A3P145604    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
#		| DCP-L2520DW  | 300.00 |                           | Yes      | 5            | 1000       | 0              | 200          | A3P145605    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
And I calculate the click price for each of the above printers
And I save the above proposal and submit it for approval
And a Cloud MPS Bank release the above proposal
And I have navigated to the Approved Proposals page and navigate to the proposal Summary page for this proposal 
And I click the download proposal button and verify if I am able to open the PDF
And a Cloud MPS Local Office Approver Set a Special Pricing:
		| Model        | InstallUnitCost | InstallMargin | InstallUnitPrice | ServiceUnitCost | ServiceMargin | ServiceUnitPrice | MonoClickServiceCost | MonoClickServicePrice | MonoClickCoverage | MonoClickVolume | MonoClickMargin | MonoClick | ColourClickServiceCost | ColourClickServicePrice | ColourClickCoverage | ColourClickVolume | ColourClickMargin | ColourClick |
		| *            | 100             | 50            |                  | 120             | 50            |                  |                      |                       | 10                | 100             | 50.00           | 0.01300   |                        |                         | 40                  | 300               | 50.00             | 0.10700     |
And I sign the above proposal
And a Cloud MPS Bank Cloud MPS Bank Summary Accept
And a Cloud MPS Bank Populated Maintain Contact
And I navigate to Accepted Contracts Page and click Manage devices button
And I create a "<InstallationType>" installation request for "<CommunicationMethod>" communication
And I will be able to see the installation request created above on the Manage Devices page for the above proposal
And a Brother installer has navigated to the Web Installation page and verify Contract Reference
And Enter the serial numbers and complete installation
And I navigate to Accepted Contracts Page and click Manage devices button
And I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts
And I update the print count 
And I navigate to the contract summary page in the reports section 
And I verify updated print count and consumable order status
And I update the Consumable Order and verify it.
#step43,44
And a Cloud MPS Bank Checking the billing to ensure details are correctly populated


@BUK
Scenarios: 
		| Country | ContractType        | UsageType     | BillingType            | ServicePackType         | ContractTerm | Customer | CommunicationMethod | InstallationType | LeasingBillingCycle |
		| Germany | LEASING_AND_SERVICE | PAY_AS_YOU_GO | HALF_YEARLY_IN_ARREARS | ADD_TO_THE_LEASING_RATE | FIVE_YEARS   | New      | Cloud               | Web              | MONTHLY             |

