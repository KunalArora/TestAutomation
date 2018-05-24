@MPS @UAT @TYPE1 @ENDTOEND @TEST
Feature: Type1BusinessScenario_4
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new contract and complete the installation of all devices

Scenario Outline: Business Scenario 4
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"
When I create a "<ContractType>" proposal
And I enter the proposal description
And I create a new customer for the proposal
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>" and Service Pack type of "<ServicePackType>"
And I add these printers:
		| Model        | Price   | InstallationPack     | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SerialNumber | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | LaserUnit | FuserUnit | PaperFeedingKit1 | PaperFeedingKit2 | PaperFeedingKit3 | IsSwap |
		| DCP-8110DN   | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            | A3P145600    | 23             | 100             | Empty               | Normal             | Normal                | Normal               | Normal    | Empty     | Normal           | Normal           | Normal           | true   |
		| HL-5450DN    | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 0              | 0            | A3P145601    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| DCP-L8450CDW | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 20             | 250          | A3P145602    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| MFC-L8650CDW | 1000.00 | BROTHER_INSTALLATION | Yes      | 5            | 1000       | 20             | 200          | A3P145603    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
And I calculate the click price for each of the above printers
And I save the above proposal and submit it for approval
And a Cloud MPS Local Office Approver approves the above proposal
And I have navigated to the Approved Proposals page and navigate to the proposal Summary page for this proposal 
And I click the download proposal button and verify if I am able to open the PDF
#Referred values of Evidence-Case8xxx.xlsx in https://brother-bie.atlassian.net/browse/MPS-3585 
And a Cloud MPS Local Office Approver Set a Special Pricing:
		| Model        | InstallUnitCost | InstallMargin | InstallUnitPrice | ServiceUnitCost | ServiceMargin | ServiceUnitPrice | MonoClickServiceCost | MonoClickServicePrice | MonoClickCoverage | MonoClickVolume | MonoClickMargin | MonoClick | ColourClickServiceCost | ColourClickServicePrice | ColourClickCoverage | ColourClickVolume | ColourClickMargin | ColourClick |
		| *            | 100             | 50            |                  | 120             | 50            |                  |                      |                       | 10                | 100             | 50.00           | 0.01300   |                        |                         | 40                  | 300               | 50.00             | 0.10700     |

And I sign the above proposal
And a Cloud MPS Local Office Approver accepts the above proposal
And I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
And I create a "<InstallationType>" installation request for "<CommunicationMethod>" communication
And I will be able to see the installation request created above on the Manage Devices page for the above proposal
And a Brother installer has navigated to the Web Installation page and verify Contract Reference
And Enter the serial numbers and complete installation
And I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
And I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts
And I update the print count, raise consumable order and service request for above devices
And I will be able to see on the Manage Devices page that above devices have updated Print Counts
Then a Customer has navigated to the Consumables Devices page to verify that above device have updated Ink Status and Service Request is raised
Given a Cloud MPS Local Office Admin navigates to the contract end screen 
When a Cloud MPS Local Office Admin sets the cancellation date and reason and cancels the contract
Then a Local Office Admin assert the final bill is generated/present


@BUK
Scenarios: 
		| Country        | ContractType       | UsageType      | BillingType          | ServicePackType | ContractTerm | Customer | CommunicationMethod | InstallationType |
		| United Kingdom | PURCHASE_AND_CLICK | PAY_AS_YOU_GO  | QUARTERLY_IN_ARREARS | PAY_UPFRONT     | THREE_YEARS  | New      | Cloud               | Web              |

#@BFR
#Scenarios:
#		| Country | ContractType     | UsageType      | ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterDelivery_1 | PrinterCoverageMono_1 | PrinterVolumeMono_1 | PrinterCoverageColour_1 | PrinterVolumeColour_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterDelivery_2 | PrinterCoverageMono_2 | PrinterVolumeMono_2 | PrinterCoverageColour_2 | PrinterVolumeColour_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterDelivery_3 | PrinterCoverageMono_3 | PrinterVolumeMono_3 | PrinterCoverageColour_3 | PrinterVolumeColour_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 | PrinterDelivery_4 | PrinterCoverageMono_4 | PrinterVolumeMono_4 | PrinterCoverageColour_4 | PrinterVolumeColour_4 |
#		| France  | Purchase & Click | Minimum Volume | Upfront         | 3 years      | New      | ABC1234        | 1000.00        | Brother               | Yes               | 5                     | 1000                | 0                       | 0                     |                |                |                       |                   |                       |                     |                         |                       |                |                |                       |                   |                       |                     |                         |                       |                |                |                       |                   |                       |                     |                         |                       |
