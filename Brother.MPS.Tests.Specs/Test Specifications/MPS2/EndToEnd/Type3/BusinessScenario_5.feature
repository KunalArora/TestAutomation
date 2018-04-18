@MPS @UAT @TYPE3 @ENDTOEND
Feature: BusinessScenario_5
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 5
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model         | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | ResetDevice | IsSwap | BocModel     |
		| DCP-8110DN    | 1        | Yes              | Yes         | 5            | 4000       | 0              | 0            | Yes                     | 500            | 0               | Empty               | Normal             | Normal                | Normal               | No          | false  |              |
		| DCP-L8450CDW  | 1        | Yes              | No          | 5            | 1000       | 20             | 1000         | Yes                     | 500            | 0               | Empty               | Normal             | Normal                | Normal               | No          | false  |              |
		| MFC-L9550CDWT | 1        | Yes              | Yes         | 5            | 500        | 20             | 250          | Yes                     | 600            | 0               | Empty               | Normal             | Normal                | Normal               | No          | false  | MFC-L8850CDW |
		| DCP-8250DN    | 1        | Yes              | No          | 5            | 2000       | 0              | 0            | Yes                     | 600            | 0               | Empty               | Normal             | Normal                | Normal               | No          | false  |              |
And I can validate service and installation pack status on the agreement summary page
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data bulk for all devices (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then I can create and send a bulk installation request
When I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to bulk install the devices using "<CommunicationMethod>" communication and "<InstallationType>" installation
Then a Cloud MPS Installer Verify Single Quantity Model Serial Number are auto assigned

@BUK
Scenarios:
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service     | OptionalFields_2 | CommunicationMethod | InstallationType | AgreementShiftDays | SwapDeviceType               | SwapCommunicationMethod | SwapInstallationType |
		| United Kingdom | CPP_AGREEMENT | True             | MINIMUM_VOLUME | THREE_YEARS  | PAY_UPFRONT | False            | Cloud               | Bor              | 91                 | REPLACE_WITH_DIFFERENT_MODEL | Cloud                   | Bor                  |