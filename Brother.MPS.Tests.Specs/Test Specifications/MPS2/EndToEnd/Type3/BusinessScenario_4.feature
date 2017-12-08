@MPS @UAT @TYPE3 @ENDTOEND
Feature: BusinessScenario_4
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 4
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields ("<NonMandatory_1>" fields also) on Agreement Description Page
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model        | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-8110DN   | 1        | Yes              | No          | 25           | 2250       | 0              | 0            |
		| MFC-L8650CDW | 1        | No               | Yes         | 25           | 2250       | 25             | 2250         |
		| DCP-L8450CDW | 1        | Yes              | Yes         | 25           | 2250       | 25             | 2250         |
		| DCP-8250DN   | 2        | No               | No          | 25           | 2250       | 0              | 0            |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data using a combination of single device edit, bulk edit and excel edit options ("<NonMandatory_2>" fields also)
Then I can verify that devices are ready for installation

@BUK
Scenarios: 
		| Country        | NonMandatory_1 | UsageType     | ContractTerm | Service     | NonMandatory_2 |
		| United Kingdom | Yes            | Pay As You Go | 3 years      | Pay upfront | Yes            |