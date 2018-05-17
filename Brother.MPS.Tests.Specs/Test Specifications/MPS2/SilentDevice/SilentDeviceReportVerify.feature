@MPS @UAT @TYPE3 @HIGH @FULLDATAQUERY
Feature: SilentDeviceReportVerify
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new agreement and complete the installation of all devices

Scenario Outline: SilentDeviceReportVerify
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model        | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour | SendInstallationRequest | MonoPrintCount | ColorPrintCount | IsSwap |
		| DCP-8110DN   | 1        | No               | No          | 25           | 2000       | 0              | 0            | Yes                     | 2250           | 0               | true   |
		| MFC-L8650CDW | 1        | No               | No          | 25           | 2000       | 25             | 2000         | Yes                     | 1000           | 1250            | false  |
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
Then a Cloud MPS Service Desk can verify the service request 
When a Cloud MPS Service Desk close the service request
Then I can verify that service request has been closed succesfully
When I manually raise a service request for above devices
Then a Cloud MPS Service Desk can verify the service request 
When a Cloud MPS Service Desk close the service request
Then I can verify that service request has been closed succesfully
When I manually raise a service request for above devices
Then a Cloud MPS Service Desk can verify the service request 

@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service                 | OptionalFields_2 | CommunicationMethod | InstallationType | AgreementShiftDays | 
		| United Kingdom | CPP_AGREEMENT | False            | MINIMUM_VOLUME | FOUR_YEARS   | INCLUDED_IN_CLICK_PRICE | False            | Cloud               | Bor              | 91                 | 