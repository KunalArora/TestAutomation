@MPS @UAT @TYPE1 @ENDTOEND
Feature: BusinessScenario_1
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new contract and complete installation of all devices

Scenario Outline: Business Scenario 1
Given I have navigated to the Create Proposal page as a "Cloud MPS Dealer" from "<Country>"
When I create a "<ContractType>" proposal
And I skip customer creation
And I select Usage Type of <UsageType>, Contract Term of <ContractTerm>, Billing Type of <BillingType> and Service Pack type of <ServicePackType>
And I add printers 
		| Model            | Price            | Installation            |
		| <PrinterModel_1> | <PrinterPrice_1> | <PrinterInstallation_1> |
		| <PrinterModel_2> | <PrinterPrice_2> | <PrinterInstallation_2> |
		| <PrinterModel_3> | <PrinterPrice_3> | <PrinterInstallation_3> |
		| <PrinterModel_4> | <PrinterPrice_4> | <PrinterInstallation_4> |

@BUK
Scenarios: 
		| Country        | ContractType     | UsageType      | ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 |
		| United Kingdom | Purchase & Click | Minimum Volume | Upfront         | 3 years      | New      | ABC1234        | 1000.00        | Brother               |                |                |                       |                |                |                       |                |                |                       |

@BFR
Scenarios: 
		| Country | ContractType     | UsageType      | ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 |
		| France  | Purchase & Click | Minimum Volume | Upfront         | 3 years      | New      | ABC1234        | 1000.00        | Brother               |                |                |                       |                |                |                       |                |                |                       |