@MPS @UAT @TYPE3 @ENDTOEND
Feature: BusinessScenario_1
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 1
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model        | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-8110DN   | 1        | Yes              | Yes         | 5            | 500        | 0              | 0            |
		| DCP-8250DN   | 1        | Yes              | Yes         | 5            | 1000       | 0              | 0            |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data one by one for all devices (Fill Optional fields: "<OptionalFields_2>")
Then I can verify that devices are ready for installation


@BUK
Scenarios: 
		| Country        | OptionalFields_1 | UsageType      | ContractTerm | Service     | OptionalFields_2 |
		| United Kingdom | True             | Minimum Volume | 3 years      | Pay upfront | False            |