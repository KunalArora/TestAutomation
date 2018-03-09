@MPS @UAT @TYPE1 @ENDTOEND
Feature: BusinessScenario_6
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new contract and complete the installation of all devices

Scenario Outline: Business Scenario 6
#---------------
# dealer
#---------------
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"
# 2
When I create a "<ContractType>" proposal
# 2 次画面が 3 になる注意
And I enter the proposal description
# 多分不要
#And I create a new customer for the proposal
# 3
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>", Service Pack type of "<ServicePackType>" and Leasing Billing Cycle of "<LeasingBillingCycle>"
# 4 1機種×N台構成質問中
And I add these printers:
		| Model        | Price  | InstallationPack          | Delivery | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SerialNumber | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | LaserUnit | FuserUnit | PaperFeedingKit1 | PaperFeedingKit2 | PaperFeedingKit3 | IsSwap |
		| DCP-8110DN   | 300.00 |                           | Yes      | 5            | 1000       | 0              | 0            | A3P145600    | 23             | 100             | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| HL-5450DN    | 300.00 |                           | Yes      | 5            | 1000       | 0              | 0            | A3P145601    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| DCP-L8450CDW | 300.00 |                           | Yes      | 5            | 1000       | 20             | 250          | A3P145602    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| MFC-L8650CDW | 300.00 |                           | Yes      | 5            | 1000       | 20             | 200          | A3P145603    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| DCP-8250DN   | 300.00 |                           | Yes      | 5            | 1000       | 0              | 250          | A3P145604    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
		| DCP-L2520DW  | 300.00 |                           | Yes      | 5            | 1000       | 0              | 200          | A3P145605    | 0              | 0               | Normal              | Normal             | Normal                | Normal               | Normal    | Normal    | Normal           | Normal           | Normal           | false  |
# 5,6
And I calculate the click price for each of the above printers
# 7,8 8=sumitではなくSend for release 。次画面が#9になるので注意
And I save the above proposal and submit it for approval
# 9 ここに上記 多分不要 が入るパターンか→不要
#---------------
# bank
#---------------
# loa ではなくてbank実装が必要
#And a Cloud MPS Local Office Approver approves the above proposal
And a Cloud MPS Bank release the above proposal
#---------------
# dealer2
#---------------
And I have navigated to the Approved Proposals page and navigate to the proposal Summary page for this proposal 
And I click the download proposal button and verify if I am able to open the PDF
And a Cloud MPS Local Office Approver Set a Special Pricing:
		| Model        | InstallUnitCost | InstallMargin | InstallUnitPrice | ServiceUnitCost | ServiceMargin | ServiceUnitPrice | MonoClickServiceCost | MonoClickServicePrice | MonoClickCoverage | MonoClickVolume | MonoClickMargin | MonoClick | ColourClickServiceCost | ColourClickServicePrice | ColourClickCoverage | ColourClickVolume | ColourClickMargin | ColourClick |
		| *            | 100             | 50            |                  | 120             | 50            |                  |                      |                       | 10                | 100             | 50.00           | 0.01300   |                        |                         | 40                  | 300               | 50.00             | 0.10700     |
# 3
And I sign the above proposal
# Accept不要
#And a Cloud MPS Local Office Approver accepts the above proposal
# 4
And I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
# 5-9 メール送信まで
And I create a "<InstallationType>" installation request for "<CommunicationMethod>" communication
#---------------
# Installer
#---------------
And I will be able to see the installation request created above on the Manage Devices page for the above proposal
And a Brother installer has navigated to the Web Installation page and verify Contract Reference
And Enter the serial numbers and complete installation
And I navigate to the Accepted Contracts page and I locate the above contract and click Manage Devices button
And I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts
And I update the print count, raise consumable order and service request for above devices
And I will be able to see on the Manage Devices page that above devices have updated Print Counts
#Then a Customer has navigated to the Consumables Devices page to verify that above device have updated Ink Status and Service Request is raised
#Given a Cloud MPS Local Office Admin navigates to the contract end screen 
#When a Cloud MPS Local Office Admin sets the cancellation date and reason and cancels the contract
#Then a Local Office Admin assert the final bill is generated/present


@BUK
Scenarios: 
		| Country | ContractType        | UsageType     | BillingType | ServicePackType         | ContractTerm | Customer | CommunicationMethod | InstallationType | LeasingBillingCycle |
		| Germany | LEASING_AND_SERVICE | PAY_AS_YOU_GO | HALF_YEARLY | ADD_TO_THE_LEASING_RATE | FIVE_YEARS   | New      | Cloud               | Web              | MONTHLY             |

