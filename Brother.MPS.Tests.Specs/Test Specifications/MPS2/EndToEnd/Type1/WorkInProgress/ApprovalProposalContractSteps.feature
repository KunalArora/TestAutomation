@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: BusinessScenario_1_WIP_ApprovalProposalContractSteps
	This task relates to completing the process of approval of proposal and contract (using LO Approver)


#Scenario Outline: Business Scenario 1 - Approval of Proposal and Contract
#	# create proposal customer and approval  (Dealer)
#	Given I have navigated to the Create Proposal page as a "Cloud MPS Dealer" from "<Country>"
#	When I create a "<ContractType>" proposal
#	And I enter the proposal description
#	##When I create and save a new Customer
#	And I create a new customer for the proposal
#	And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>" and Service Pack type of "<ServicePackType>"
#	And I add these printers:
#			| Model            | Price            | Installation            | Delivery            | CoverageMono            | VolumeMono            | CoverageColour            | VolumeColour            |
#			| <PrinterModel_1> | <PrinterPrice_1> | <PrinterInstallation_1> | <PrinterDelivery_1> | <PrinterCoverageMono_1> | <PrinterVolumeMono_1> | <PrinterCoverageColour_1> | <PrinterVolumeColour_1> |
#			| <PrinterModel_2> | <PrinterPrice_2> | <PrinterInstallation_2> | <PrinterDelivery_2> | <PrinterCoverageMono_2> | <PrinterVolumeMono_2> | <PrinterCoverageColour_2> | <PrinterVolumeColour_2> |
#			| <PrinterModel_3> | <PrinterPrice_3> | <PrinterInstallation_3> | <PrinterDelivery_3> | <PrinterCoverageMono_3> | <PrinterVolumeMono_3> | <PrinterCoverageColour_3> | <PrinterVolumeColour_3> |
#			| <PrinterModel_4> | <PrinterPrice_4> | <PrinterInstallation_4> | <PrinterDelivery_4> | <PrinterCoverageMono_4> | <PrinterVolumeMono_4> | <PrinterCoverageColour_4> | <PrinterVolumeColour_4> |
#	And I calculate the click price for each of the above printers
#	And I save the above proposal and submit it for approval
#	And a Cloud MPS Local Office Approver approves the above proposal
#	And I sign the above proposal
#	And a Cloud MPS Local Office Approver accepts the above proposal
#	Then I navigate to Accepted Contracts page and validate its existence
#	#And I create an installation request for the above proposal
#
#
#Scenarios:
#	| Country        | ContractType     | UsageType      | BillingType          |ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterDelivery_1 | PrinterCoverageMono_1 | PrinterVolumeMono_1 | PrinterCoverageColour_1 | PrinterVolumeColour_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterDelivery_2 | PrinterCoverageMono_2 | PrinterVolumeMono_2 | PrinterCoverageColour_2 | PrinterVolumeColour_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterDelivery_3 | PrinterCoverageMono_3 | PrinterVolumeMono_3 | PrinterCoverageColour_3 | PrinterVolumeColour_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 | PrinterDelivery_4 | PrinterCoverageMono_4 | PrinterVolumeMono_4 | PrinterCoverageColour_4 | PrinterVolumeColour_4 |
#	| United Kingdom | Purchase & Click | Minimum Volume | Quarterly in Arrears |Pay upfront     | 3 years      | New      | DCP-8110DN     | 1000.00        | Brother-Install       | Yes               | 5                     | 1000                | 0                       | 0                     | HL-5450DN      | 1000           | Brother-Install       | Yes               | 5                     | 1000                | 0                       | 0                     | DCP-L8450CDW   | 1000           | Brother-Install       | Yes               | 5                     | 1000                | 20                      | 250                   | MFC-L8650CDW   | 1000           | Brother-Install       | Yes               | 5                     | 1000                | 20                      | 200                   |


Scenario Outline: Business Scenario 1B - Approval of Proposal and Contract
	Given I have navigated to the Open Proposals page as a "Cloud MPS Dealer" from "<Country>"
	When I locate the proposal with id "<ProposalId>" and submit it for approval
	And a Cloud MPS Local Office Approver approves the above proposal
	And I sign the above proposal
	And a Cloud MPS Local Office Approver accepts the above proposal
	Then I navigate to Accepted Contracts page and validate its existence

Scenarios:
	| Country        | ProposalId |
	| United Kingdom | 160611     |
