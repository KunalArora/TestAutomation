@MPS @UAT @TYPE3 @HIGH @FULLDATAQUERY @CI_TestMaintenance
Feature: SilentDeviceReportVerify
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: SilentDeviceReportVerify
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model        | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoPrintCount | ColorPrintCount | TonerInkBlackStatus | TonerInkCyanStatus | TonerInkMagentaStatus | TonerInkYellowStatus | TonerInkBlackRemLife | TonerInkCyanRemLife | TonerInkMagentaRemLife | TonerInkYellowRemLife | TonerInkBlackReplaceCount | TonerInkCyanReplaceCount | TonerInkMagentaReplaceCount | TonerInkYellowReplaceCount |
		| DCP-8110DN   | 1        | No               | No          | 25           | 2000       | 0              | 0            | Yes                     | 2250           | 0               | Normal              | Normal             | Normal                | Normal               | 2                    | 100                 | 100                    | 100                   | 2                         | 0                        | 0                           | 0                          |
		| MFC-L8650CDW | 1        | No               | No          | 25           | 2000       | 25             | 2000         | Yes                     | 1000           | 1250            | Normal              | Empty              | Normal                | Normal               | 100                  | 100                 | 2                      | 100                   | 0                         | 1                        | 0                           | 0                          | 
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data using bulk edit option (Fill Optional fields: "<OptionalFields_2>")
And I can verify that devices are ready for installation
Then I can create and send a bulk installation request
When I export the device data into excel and retrieve installation information
And a Cloud MPS Installer is able to bulk install the devices using "<CommunicationMethod>" communication and "<InstallationType>" installation
Then I can verify that all devices are installed and responding
When the print counts of the devices are updated
Then I can verify the correct reflection of updated print counts
#According to the scenario, have to raise service request for 3 times and close it for first 2 times so, a repetition of same steps is followed
When I manually raise a service request for above devices
When a Cloud MPS Service Desk closes the service request
Then I can verify that service request has been closed succesfully
When I manually raise a service request for above devices
And a Cloud MPS Service Desk closes the service request
Then I can verify that service request has been closed succesfully
When I manually raise a service request for above devices
Then a Cloud MPS Service Desk can verify the service request
When I manually raise a consumable order for above devices
Then I can verify the generation of manual consumable orders alongwith status
When I automatically raise a consumable order for above devices
Then I can verify the generation of automatic consumable orders alongwith status
When the agreement start date gets shifted "<AgreementShiftDays>" days behind without generating invoice
Then I can verify the device status being silent
And I can verify the device details on device dashboard page
And I can verify the device details and graphui details



@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service                 | OptionalFields_2 | CommunicationMethod | InstallationType | AgreementShiftDays | 
		| United Kingdom | CPP_AGREEMENT | False            | MINIMUM_VOLUME | FOUR_YEARS   | INCLUDED_IN_CLICK_PRICE | False            | Cloud               | Bor              | 5                  | 