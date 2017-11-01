﻿@MPS @UAT @TYPE1 @ENDTOEND
Feature: BusinessScenario_1
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new contract and complete the installation of all devices

Scenario Outline: Business Scenario 1
Given I have navigated to the Create Proposal page as a "Cloud MPS Dealer" from "<Country>"
When I create a "<ContractType>" proposal
And I create a new customer for the proposal
#note that 'And' steps bind to either Given or When attributes depending on the preceding steps
And I select Usage Type of <UsageType>, Contract Term of <ContractTerm>, Billing Type of <BillingType> and Service Pack type of <ServicePackType>
And I add these printers:
		| Model            | Price            | Installation            | Delivery            | CoverageMono            | VolumeMono            | CoverageColour            | VolumeColour            |
		| <PrinterModel_1> | <PrinterPrice_1> | <PrinterInstallation_1> | <PrinterDelivery_1> | <PrinterCoverageMono_1> | <PrinterVolumeMono_1> | <PrinterCoverageColour_1> | <PrinterVolumeColour_1> |
		| <PrinterModel_2> | <PrinterPrice_2> | <PrinterInstallation_2> | <PrinterDelivery_2> | <PrinterCoverageMono_2> | <PrinterVolumeMono_2> | <PrinterCoverageColour_2> | <PrinterVolumeColour_2> |
		| <PrinterModel_3> | <PrinterPrice_3> | <PrinterInstallation_3> | <PrinterDelivery_3> | <PrinterCoverageMono_3> | <PrinterVolumeMono_3> | <PrinterCoverageColour_3> | <PrinterVolumeColour_3> |
		| <PrinterModel_4> | <PrinterPrice_4> | <PrinterInstallation_4> | <PrinterDelivery_4> | <PrinterCoverageMono_4> | <PrinterVolumeMono_4> | <PrinterCoverageColour_4> | <PrinterVolumeColour_4> |
And I calculate the click price for each of the above printers
And I save the above proposal and submit it for approval
And a Cloud MPS Local Office Approver approves the above proposal
And I sign the above proposal
And a Cloud MPS Local Office Approver accepts the above proposal
And I create an installation request for the above proposal

@BUK
Scenarios: 
		| Country        | ContractType     | UsageType      | ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterDelivery_1 | PrinterCoverageMono_1 | PrinterVolumeMono_1 | PrinterCoverageColour_1 | PrinterVolumeColour_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterDelivery_2 | PrinterCoverageMono_2 | PrinterVolumeMono_2 | PrinterCoverageColour_2 | PrinterVolumeColour_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterDelivery_3 | PrinterCoverageMono_3 | PrinterVolumeMono_3 | PrinterCoverageColour_3 | PrinterVolumeColour_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 | PrinterDelivery_4 | PrinterCoverageMono_4 | PrinterVolumeMono_4 | PrinterCoverageColour_4 | PrinterVolumeColour_4 |
		| United Kingdom | Purchase & Click | Minimum Volume | Upfront         | 3 years      | New      | DCP-8110DN     | 1000.00        | Brother               | Yes               | 5                     | 1000                | 0                       | 0                     | HL-5450DN      |                | Brother               | Yes               | 5                     | 1000                | 0                       | 0                     | DCP-L8450CDW   |                | Brother               | Yes               | 5                     | 1000                | 10                      | 250                   | MFC-L8650CDW   |                | Brother               | Yes               | 5                     | 1000                | 10                      | 250                   |

@BFR
Scenarios:
		| Country | ContractType     | UsageType      | ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterDelivery_1 | PrinterCoverageMono_1 | PrinterVolumeMono_1 | PrinterCoverageColour_1 | PrinterVolumeColour_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterDelivery_2 | PrinterCoverageMono_2 | PrinterVolumeMono_2 | PrinterCoverageColour_2 | PrinterVolumeColour_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterDelivery_3 | PrinterCoverageMono_3 | PrinterVolumeMono_3 | PrinterCoverageColour_3 | PrinterVolumeColour_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 | PrinterDelivery_4 | PrinterCoverageMono_4 | PrinterVolumeMono_4 | PrinterCoverageColour_4 | PrinterVolumeColour_4 |
		| France  | Purchase & Click | Minimum Volume | Upfront         | 3 years      | New      | ABC1234        | 1000.00        | Brother               | Yes               | 5                     | 1000                | 0                       | 0                     |                |                |                       |                   |                       |                     |                         |                       |                |                |                       |                   |                       |                     |                         |                       |                |                |                       |                   |                       |                     |                         |                       |