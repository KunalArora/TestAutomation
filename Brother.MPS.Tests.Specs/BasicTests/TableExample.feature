@MPS_EXAMPLES @UAT @MPS
Feature: TableExample
	In order to generate revenue
	As a dealer
	I want to create new contracts

Scenario Outline: Create a new proposal
	Given I create a proposal with these printers:
		| Model            | Price            | Installation            |
		| <PrinterModel_1> | <PrinterPrice_1> | <PrinterInstallation_1> |
		| <PrinterModel_2> | <PrinterPrice_2> | <PrinterInstallation_2> |
		| <PrinterModel_3> | <PrinterPrice_3> | <PrinterInstallation_3> |
		| <PrinterModel_4> | <PrinterPrice_4> | <PrinterInstallation_4> |

Scenarios: 
		| ContractType     | UsageType      | ServicePackType | ContractTerm | Customer | PrinterModel_1 | PrinterPrice_1 | PrinterInstallation_1 | PrinterModel_2 | PrinterPrice_2 | PrinterInstallation_2 | PrinterModel_3 | PrinterPrice_3 | PrinterInstallation_3 | PrinterModel_4 | PrinterPrice_4 | PrinterInstallation_4 |
		| Purchase & Click | Minimum Volume | Upfront         | 3 years      | New      | ABC1234        | 1000.00        | Brother               |                |                |                       |                |                |                       |                |                |                       |
		| Lease & Click    | Pay As You Go  | Upfront         | 5 years      | Existing |                |                |                       |                |                |                       |                |                |                       |                |                |                       |
		| Lease & Click    | Minimum Volume | In click        | 5 years      | Skip     |                |                |                       |                |                |                       |                |                |                       |                |                |                       |
