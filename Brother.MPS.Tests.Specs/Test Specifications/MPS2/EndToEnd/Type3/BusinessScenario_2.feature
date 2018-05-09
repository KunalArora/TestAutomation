@MPS @UAT @TYPE3 @ENDTOEND
Feature: Type3BusinessScenario_2
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 2
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model      | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus |
		| HL-5470DW  | 2        | No               | No          | 10           | 2000       | 0              | 0            | Yes                     | 2100           | 0               | Empty               | Normal             | Normal                | Normal               |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data using bulk edit option (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then I can create and send installation requests for devices one by one
When I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to install devices one by one using "<CommunicationMethod>" communication and "<InstallationType>" installation
Then I can verify that all devices are installed and responding
When the print counts of the devices are updated
Then I can verify the correct reflection of updated print counts
When I manually raise a consumable order for above devices
Then I can verify the generation of consumable orders alongwith status
When I manually raise a service request for above devices
Then a Cloud MPS Service Desk can verify the service request and close it
And I can verify that service request has been closed succesfully
When the agreement start date gets shifted "<AgreementShiftDays>" days behind
Then I can verify the click rate billing invoice
And I can verify the service/installation billing invoice

@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service                 | OptionalFields_2 | CommunicationMethod | InstallationType | AgreementShiftDays |
		| United Kingdom | CPP_AGREEMENT | False            | MINIMUM_VOLUME | FOUR_YEARS   | INCLUDED_IN_CLICK_PRICE | True             | Cloud               | Bor              | 63                 |