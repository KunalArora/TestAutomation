@MPS @UAT @TYPE3 @ENDTOEND
Feature: Type3BusinessScenario_5
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 5
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model         | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | IsSwap | BocModel     |
		| DCP-8110DN    | 1        | Yes              | Yes         | 5            | 4000       | 0              | 0            | Yes                     | 500            | 0               | Empty               | Normal             | Normal                | Normal               | true   |              |
		| DCP-L8450CDW  | 1        | No               | No          | 5            | 1000       | 20             | 1000         | Yes                     | 500            | 0               | Empty               | Normal             | Normal                | Normal               | false  |              |
		| MFC-L9550CDWT | 1        | Yes              | No          | 5            | 500        | 20             | 250          | Yes                     | 600            | 0               | Empty               | Normal             | Normal                | Normal               | false  | MFC-L8850CDW |
		| DCP-8250DN    | 1        | No               | Yes         | 5            | 2000       | 0              | 0            | Yes                     | 600            | 0               | Empty               | Normal             | Normal                | Normal               | false  |              |
And I complete the setup of agreement
And a Cloud MPS LO Approver applies special pricing by difference current value(+/-) or absolute value:
		| Model        | InstallUnitPrice | ServiceUnitPrice | MonoClickCoverage | MonoClickVolume | ColourClickCoverage | ColourClickVolume | 
		| *            | -10.00           | -10.00           | +10               | +100            | +10                 | +100              | 
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data bulk for all devices (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then I can create and send a bulk installation request
When I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to bulk install the devices using "<CommunicationMethod>" communication and "<InstallationType>" installation
Then I can verify that all devices are installed and responding
When I create and send a "<SwapDeviceType>" swap device installation request
Then a Cloud MPS Installer is able to swap device using "<SwapCommunicationMethod>" communication and "<SwapInstallationType>" installation
And I can verify that the new devices are installed and responding

@BUK
Scenarios:
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service     | OptionalFields_2 | CommunicationMethod | InstallationType | SwapDeviceType  | SwapCommunicationMethod | SwapInstallationType |
		| United Kingdom | CPP_AGREEMENT | True             | MINIMUM_VOLUME | THREE_YEARS  | PAY_UPFRONT | False            | Cloud               | Bor              | REPLACE_THE_PCB | Cloud                   | Web                  |