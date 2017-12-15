@MPS @UAT @TYPE3 @ENDTOEND
Feature: BusinessScenario_3
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 3
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model      | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | Installation |
		| DCP-8110DN | 2        | Yes              | Yes         | 100          | 4000       | 0              | 0            | Yes          |
		| DCP-8250DN | 1        | Yes              | Yes         | 100          | 4000       | 0              | 0            | Yes          |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data using excel edit option (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then a Cloud MPS LO Approver can create and send a bulk installation request


@BUK
Scenarios: 
		| Country        | OptionalFields_1 | UsageType      | ContractTerm | Service                 | OptionalFields_2 |
		| United Kingdom | True             | Minimum Volume | 5 years      | Included in Click Price | True             |