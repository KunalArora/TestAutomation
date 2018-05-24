@MPS @UAT @TYPE1 @SMOKE @TEST
Feature: Type1BusinessScenario_1
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new contract and complete the installation of all devices

Scenario Outline: Business Scenario 1
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"
When I create a "<ContractType>" proposal
And I enter the proposal description
And I create a new customer for the proposal
#note that 'And' steps bind to either Given or When attributes depending on the preceding steps
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>" and Service Pack type of "<ServicePackType>"
And I add these printers:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SerialNumber | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | LaserUnit | FuserUnit | PaperFeedingKit1 | PaperFeedingKit2 | PaperFeedingKit3 | IsSwap |
		| DCP-8110DN   | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            | A3P145600    | 23             | 0               | Empty               | Normal             | Normal                | Normal               | Normal    | Empty     | Normal           | Normal           | Normal           | true   |
		| HL-5450DN    | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            | A3P145601    | 10             | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| DCP-L8450CDW | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 20             | 250          | A3P145602    | 3000           | 1500            | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| MFC-L8650CDW | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 20             | 200          | A3P145603    | 10             | 10              | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
And I calculate the click price for each of the above printers
And I save the above proposal and submit it for approval
And a Cloud MPS Local Office Approver approves the above proposal
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
And a Cloud MPS Local Office Approver apply and verify the Overusage
And I will raise consumable order and service request for above devices
And a Customer has navigated to the Consumables Devices page to verify that above device have updated Ink Status and Service Request is raised
And I click Swap Device in the Actions menu for device to be swapped on the Manage devices page
And I create a "<SwapType>" swap installation request with "<InstallationType>" installation type for "<CommunicationMethod>" communication
And I will be able to see the status of the installed device is set Being Replaced on the Manage Devices page for the above proposal
And a Brother installer has navigated to the Web Swap Installation page and verify Contract Reference
And Enter the serial number for new device "<SwapNewDeviceSerialNumber>" with new Mono "<SwapNewDeviceMonoPrintCount>" and color "<SwapNewDeviceColorPrintCount>" print count and complete Installation 
Then I will be able to see the status of the swap device is set Being Swapped with updated print counts on the Manage Devices page for the above proposal

@BUK
Scenarios: 
		| Country        | ContractType       | UsageType      | BillingType          | ServicePackType | ContractTerm | Customer | CommunicationMethod | InstallationType | SwapType                | SwapNewDeviceSerialNumber | SwapNewDeviceMonoPrintCount | SwapNewDeviceColorPrintCount |
		| United Kingdom | PURCHASE_AND_CLICK | MINIMUM_VOLUME | QUARTERLY_IN_ARREARS | PAY_UPFRONT     | THREE_YEARS  | New      | Cloud               | Web              | REPLACE_WITH_SAME_MODEL | A3P145606                 | 100                         | 0                            |

#@BFR
#Scenarios:
#		| Country | ContractType     | UsageType      | ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterDelivery_1 | PrinterCoverageMono_1 | PrinterVolumeMono_1 | PrinterCoverageColour_1 | PrinterVolumeColour_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterDelivery_2 | PrinterCoverageMono_2 | PrinterVolumeMono_2 | PrinterCoverageColour_2 | PrinterVolumeColour_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterDelivery_3 | PrinterCoverageMono_3 | PrinterVolumeMono_3 | PrinterCoverageColour_3 | PrinterVolumeColour_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 | PrinterDelivery_4 | PrinterCoverageMono_4 | PrinterVolumeMono_4 | PrinterCoverageColour_4 | PrinterVolumeColour_4 |
#		| France  | Purchase & Click | Minimum Volume | Upfront         | 3 years      | New      | ABC1234        | 1000.00        | Brother               | Yes               | 5                     | 1000                | 0                       | 0                     |                |                |                       |                   |                       |                     |                         |                       |                |                |                       |                   |                       |                     |                         |                       |                |                |                       |                   |                       |                     |                         |                       |
