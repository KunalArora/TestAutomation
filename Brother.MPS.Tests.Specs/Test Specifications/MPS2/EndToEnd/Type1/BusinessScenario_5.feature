@MPS @UAT @TYPE1 @ENDTOEND
Feature: BusinessScenario_5
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new contract and complete the installation of all devices

Scenario Outline: Business Scenario 5
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"
When I create a "<ContractType>" proposal
And I enter the proposal description
#And I create a new customer for the proposal
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>", Service Pack type of "<ServicePackType>" and Leasing Billing Cycle of "<LeasingBillingCycle>"
And I add these printers for EPP:
		| Model        | Price  | InstallationPack          | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SerialNumber | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | LaserUnit | FuserUnit | PaperFeedingKit1 | PaperFeedingKit2 | PaperFeedingKit3 | IsSwap |
		| DCP-8110DN   | 300.00 |                           | Yes      | 5            | 1000       | 0              | 0            | A3P145600    | 23             | 100             | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| HL-5450DN    | 300.00 |                           | Yes      | 5            | 1000       | 0              | 0            | A3P145601    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| DCP-L8450CDW | 300.00 |                           | Yes      | 5            | 1000       | 20             | 250          | A3P145602    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| MFC-L8650CDW | 300.00 |                           | Yes      | 5            | 1000       | 20             | 200          | A3P145603    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
And I calculate the click price for each of the above printers
And I save the above proposal and submit it for approval
And I have navigated to the Approved Proposals page and navigate to the proposal Summary page for this proposal 
And I click the download proposal button and verify if I am able to open the PDF
And I sign the above proposal
And a Cloud MPS Local Office Approver accepts the above proposal
And I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
And I create a "<InstallationType>" installation request for "<CommunicationMethod>" communication
And I will be able to see the installation request created above on the Manage Devices page for the above proposal
And a Brother installer has navigated to the Web Installation page and verify Contract Reference
And Enter the serial numbers and complete installation
And I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
And I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts
And I update the print count and verify it on the Manage devices page
#step39,40
And a Cloud MPS Bank Cloud MPS Bank Summary Accept 
#step40-42
And a Cloud MPS Bank Populated Maintain Contact
#step43,44
And a Cloud MPS Bank Checking the billing to ensure details are correctly populated


@BUK
Scenarios: 
		| Country | ContractType               | UsageType      | BillingType | ServicePackType   | ContractTerm | Customer | CommunicationMethod | InstallationType |
		| Germany | EASY_PRINT_PRO_AND_SERVICE | MINIMUM_VOLUME | MONTHLY     | TO_PAY_IN_ADVANCE | THREE_YEARS  | New      | Email               | Web              |

