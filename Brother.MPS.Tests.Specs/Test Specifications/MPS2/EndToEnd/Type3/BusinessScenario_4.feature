@MPS @UAT @TYPE3 @ENDTOEND
Feature: BusinessScenario_4
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 4
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model        | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoPrintCount | ColorPrintCount |
		| DCP-8110DN   | 1        | Yes              | No          | 25           | 2250       | 0              | 0            | Yes                     | 2250           | 0               |
		| MFC-L8650CDW | 1        | No               | Yes         | 25           | 2250       | 25             | 2250         | No                      | 1000           | 1250            |
		| DCP-L8450CDW | 1        | Yes              | Yes         | 25           | 2250       | 25             | 2250         | Yes                     | 1200           | 1350            |
		| DCP-8250DN   | 2        | No               | No          | 25           | 2250       | 0              | 0            | Yes                     | 2300           | 0               |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data using a combination of single device edit, bulk edit and excel edit options (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then a Cloud MPS Service Desk can create and send installation requests for devices one by one
When a Cloud MPS Local Office Admin enables the "<InstallationType>" installation option for "<CommunicationMethod>" communication
And I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to do both single device and bulk installation using "<CommunicationMethod>" communication and "<InstallationType>" installation
Then I can verify that all devices are installed and responding
When the print counts of the devices are updated
Then I can verify the correct reflection of updated print counts

@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType     | ContractTerm | Service     | OptionalFields_2 | CommunicationMethod | InstallationType |
		| United Kingdom | CPP_AGREEMENT | True             | PAY_AS_YOU_GO | THREE_YEARS  | PAY_UPFRONT | True             | Cloud               | Usb              |