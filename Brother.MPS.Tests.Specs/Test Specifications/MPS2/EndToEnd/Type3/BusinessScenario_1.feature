@MPS @UAT @TYPE3 @SMOKE
Feature: Type3BusinessScenario_1
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 1
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model     | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | ResetDevice | IsSwap |
		| HL-5450DN | 1        | Yes              | Yes         | 5            | 500        | 0              | 0            | Yes                     | 500            | 0               | Empty               | Normal             | Normal                | Normal               | Yes         | true   |
		| HL-5470DW | 1        | Yes              | Yes         | 5            | 1000       | 0              | 0            | Yes                     | 600            | 0               | Empty               | Normal             | Normal                | Normal               | No          | false  |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data one by one for all devices (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then I can create and send a bulk installation request
When I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to bulk install the devices using "<CommunicationMethod>" communication and "<InstallationType>" installation
And a Cloud MPS Installer resets the devices and reinstalls them
Then I can verify that all devices are installed and responding
When the print counts of the devices are updated
And the toner ink levels of the above devices become low
Then a Cloud MPS Local Office Admin can verify the correct reflection of updated print counts
And a Cloud MPS Local Office Admin can verify the generation of consumable orders alongwith status
When I create and send a "<SwapDeviceType>" swap device installation request
Then a Cloud MPS Installer is able to swap device using "<SwapCommunicationMethod>" communication and "<SwapInstallationType>" installation
And I can verify that the new devices are installed and responding
When the agreement start date gets shifted "<AgreementShiftDays>" days behind
Then a Cloud MPS Local Office Admin can verify the click rate billing invoice
And a Cloud MPS Local Office Admin can verify the service/installation billing invoice
@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service     | OptionalFields_2 | CommunicationMethod | InstallationType | AgreementShiftDays | SwapDeviceType               | SwapCommunicationMethod | SwapInstallationType |
		| United Kingdom | CPP_AGREEMENT | True             | MINIMUM_VOLUME | THREE_YEARS  | PAY_UPFRONT | False            | Cloud               | Web              | 91                 | REPLACE_WITH_DIFFERENT_MODEL | Cloud                   | Bor                  |
