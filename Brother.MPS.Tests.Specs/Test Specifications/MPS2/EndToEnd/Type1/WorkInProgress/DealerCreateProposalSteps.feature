@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: BusinessScenario_1_WIP_DealerCreateProposalSteps
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new proposal

Scenario Outline: Business Scenario 1 - Dealer Create Proposal Steps
Given I have navigated to the Create Proposal page as a "Cloud MPS Dealer" from "<Country>"
When I create a "<ContractType>" proposal
#during development of task MPS-4837 remove dependency on customer creation
And I enter the proposal description
And I skip customer creation for the proposal
And I select Usage Type of "<UsageType>", Contract Term of "<ContractTerm>", Billing Type of "<BillingType>" and Service Pack type of "<ServicePackType>"
And I add these printers:
		| Model            | Price            | Installation            | Delivery            | CoverageMono            | VolumeMono            | CoverageColour            | VolumeColour            |
		| <PrinterModel_1> | <PrinterPrice_1> | <PrinterInstallation_1> | <PrinterDelivery_1> | <PrinterCoverageMono_1> | <PrinterVolumeMono_1> | <PrinterCoverageColour_1> | <PrinterVolumeColour_1> |
		| <PrinterModel_2> | <PrinterPrice_2> | <PrinterInstallation_2> | <PrinterDelivery_2> | <PrinterCoverageMono_2> | <PrinterVolumeMono_2> | <PrinterCoverageColour_2> | <PrinterVolumeColour_2> |
		| <PrinterModel_3> | <PrinterPrice_3> | <PrinterInstallation_3> | <PrinterDelivery_3> | <PrinterCoverageMono_3> | <PrinterVolumeMono_3> | <PrinterCoverageColour_3> | <PrinterVolumeColour_3> |
		| <PrinterModel_4> | <PrinterPrice_4> | <PrinterInstallation_4> | <PrinterDelivery_4> | <PrinterCoverageMono_4> | <PrinterVolumeMono_4> | <PrinterCoverageColour_4> | <PrinterVolumeColour_4> |
And I calculate the click price for each of the above printers
#same steps until this point
And I save the proposal
Then I can see the proposal created above in the open proposals list

Scenarios: 
		| Country        | ContractType     | UsageType      | BillingType          |ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterDelivery_1 | PrinterCoverageMono_1 | PrinterVolumeMono_1 | PrinterCoverageColour_1 | PrinterVolumeColour_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterDelivery_2 | PrinterCoverageMono_2 | PrinterVolumeMono_2 | PrinterCoverageColour_2 | PrinterVolumeColour_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterDelivery_3 | PrinterCoverageMono_3 | PrinterVolumeMono_3 | PrinterCoverageColour_3 | PrinterVolumeColour_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 | PrinterDelivery_4 | PrinterCoverageMono_4 | PrinterVolumeMono_4 | PrinterCoverageColour_4 | PrinterVolumeColour_4 |
		| United Kingdom | Purchase & Click | Minimum Volume | Quarterly in Arrears |Pay upfront     | 3 years      | New      | DCP-8110DN     | 1000.00        | Brother-Install       | Yes               | 5                     | 1000                | 0                       | 0                     | HL-5450DN      | 1000           | Brother-Install       | Yes               | 5                     | 1000                | 0                       | 0                     | DCP-L8450CDW   | 1000           | Brother-Install       | Yes               | 5                     | 1000                | 20                      | 250                   | MFC-L8650CDW   | 1000           | Brother-Install       | Yes               | 5                     | 1000                | 20                      | 200                   |
