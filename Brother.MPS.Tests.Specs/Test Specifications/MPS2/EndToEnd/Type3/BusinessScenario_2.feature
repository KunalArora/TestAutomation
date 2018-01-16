@MPS @UAT @TYPE3 @ENDTOEND
Feature: BusinessScenario_2
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 2
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model      | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest |
		| DCP-8110DN | 2        | No               | No          | 10           | 2000       | 0              | 0            | Yes                     |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data using bulk edit option (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then I can create and send installation requests for devices one by one
When I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to install devices one by one using "<CommunicationMethod>" communication and "<InstallationType>" installation
Then I can verify that all devices are installed and responding

@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service                 | OptionalFields_2 | CommunicationMethod | InstallationType |
		| United Kingdom | CPP_AGREEMENT | False            | MINIMUM_VOLUME | FOUR_YEARS   | INCLUDED_IN_CLICK_PRICE | True             | Cloud               | Bor              |