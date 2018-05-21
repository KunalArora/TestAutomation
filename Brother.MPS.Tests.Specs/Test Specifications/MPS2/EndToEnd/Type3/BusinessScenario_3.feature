@MPS @UAT @TYPE3 @ENDTOEND
Feature: Type3BusinessScenario_3
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: Business Scenario 3
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model      | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoPrintCount | ColorPrintCount | ResetDevice | ReInstallDevice |
		| DCP-8110DN | 2        | Yes              | Yes         | 100          | 4000       | 0              | 0            | Yes                     | 4000           | 0               | Yes         | No              |
		| DCP-8250DN | 1        | Yes              | Yes         | 100          | 4000       | 0              | 0            | Yes                     | 4000           | 0               | No          | Yes             |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data using excel edit option (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then a Cloud MPS LO Approver can create and send a bulk installation request
And a Cloud MPS LO Approver applies special pricing using relative values(+/- w.r.t. current values) or absolute values:
		| Model        | InstallUnitPrice | ServiceUnitPrice | MonoClickCoverage | MonoClickVolume | ColourClickCoverage | ColourClickVolume | 
		| *            | -10.00           | -10.00           | -10               | -100            | -10                 | -100              | 
Then a Cloud MPS LO Approver can verify that special pricing is correctly applied
When I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to bulk install the devices using "<CommunicationMethod>" communication and "<InstallationType>" installation
And a Cloud MPS Installer resets the devices and reinstalls them
Then I can verify that all devices are installed and responding
#And I can verify the device details using show device details option
And I can verify the device details on device dashboard page
When a Cloud MPS LO Approver can create and send a device reinstallation request
And a Cloud MPS Installer is able to reinstall devices using "<CommunicationMethod>" communication and "<InstallationType>" installation
Then I can verify that the reinstalled devices are responding
When the print counts of the devices are updated
Then I can verify the correct reflection of updated print counts
And I can verify the Print Summary and Consumables on device dashboard page
When the agreement start date gets shifted "<AgreementShiftDays>" days behind
Then I can verify the click rate billing invoice
And I can verify the service/installation billing invoice

@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service                 | OptionalFields_2 | CommunicationMethod | InstallationType | AgreementShiftDays |
		| United Kingdom | CPP_AGREEMENT | True             | MINIMUM_VOLUME | FIVE_YEARS   | INCLUDED_IN_CLICK_PRICE | True             | Cloud               | Bor              | 40                 |