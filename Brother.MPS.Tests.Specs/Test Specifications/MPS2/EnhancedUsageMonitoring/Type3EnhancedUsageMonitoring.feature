@MPS @UAT @HIGH @TYPE3 @EUM @CI_TestMaintenance
Feature: Type3EnhancedUsageMonitoring
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to ensure the correct working of the default order threshold functionality

Scenario Outline: Type3EnhancedUsageMonitoring
Given a Cloud MPS BIE Admin has navigated to the Dashboard page
When a Cloud MPS BIE Admin navigates to the Printer Engine tab under Manage Device Order Threshold section
And a Cloud MPS BIE Admin selects the country as "<Country>"
Then a Cloud MPS BIE Admin can set the threshold value for printer engines types as follows and saves the details
		| PrinterEngine | SupplyItemType | Threshold | Enabled |
		| BC2 Step      | Mono           | 12.00     | true    |
		| BC2 Step      | Colour         | 15.00     | true    |
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model        | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoThresholdValue | ColourThresholdValue | TonerInkBlackRemLife | TonerInkCyanRemLife | TonerInkMagentaRemLife | TonerInkYellowRemLife |
		| DCP-L8450CDW | 1        | Yes              | Yes         | 25           | 2500       | 25             | 2500         | Yes                     | 15.00              | 20.00                | 14                   | 100                 | 19                     | 100                   |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data one by one for all devices (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then I can create and send a bulk installation request
When I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to install devices one by one using "<CommunicationMethod>" communication and "<InstallationType>" installation
Then I can verify that all devices are installed and responding
When a Cloud MPS BIE Admin navigates to the Installed Printer tab under Manage Device Order Threshold section
Then a Cloud MPS BIE Admin searches for the agreement and ensures correct printer and threshold details
And a Cloud MPS BIE Admin updates the threshold value for printers and saves the details
When I automatically raise a consumable order for above devices
Then I can verify the generation of automatic consumable orders alongwith status


@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service     | OptionalFields_2 | CommunicationMethod | InstallationType |
		| United Kingdom | CPP_AGREEMENT | True             | MINIMUM_VOLUME | THREE_YEARS  | PAY_UPFRONT | True             | Cloud               | Bor              |
		