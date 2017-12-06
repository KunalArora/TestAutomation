@MPS @UAT @TYPE3 @ENDTOEND
Feature: BusinessScenario_2
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 2
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields ("<NonMandatory_1>" fields also) on Agreement Description Page
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model        | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-8110DN   | 2        | No               | No          | 10           | 2000       | 0              | 0            |		
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list

@BUK
Scenarios: 
		| Country        | NonMandatory_1 | UsageType      | ContractTerm | Service                 |
		| United Kingdom | No             | Minimum Volume | 4 years      | Included in Click Price |