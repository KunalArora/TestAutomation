@MPS @UAT @DEV @TYPE3 @PROD @PRODUCTIONSMOKE @CI_TestMaintenance
Feature: Type3ProductionSmokeTest
	In order to verify successful deployment to the production environment
	As a Cloud MPS Dealer
	I want to create and subsequently delete a new agreement

Scenario Outline: Type3PRODUCTIONSmokeTest
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I input the fields (Fill Optional fields: "<OptionalFields_1>") on Agreement Description Page for "<AgreementType>" type agreement
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model     | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| HL-L2360DN | 1        | Yes              | Yes         | 10           | 1500       | 0              | 0            |
		| HL-L2340DW | 1        | Yes              | Yes         | 10           | 1500       | 0              | 0            |
And I complete the setup of agreement
And I can verify the creation of agreement in the agreement list
When I navigate to edit device data page
And I edit device data using bulk edit option (Fill Optional fields: "<OptionalFields_2>")
And I navigate to the agreement list
Then I can delete the agreement
And I can verify that the agreement is removed from the agreement list

@BUK
Scenarios: 
		| Country        | AgreementType | OptionalFields_1 | UsageType      | ContractTerm | Service     | OptionalFields_2 | CommunicationMethod | InstallationType | 
		| United Kingdom | CPP_AGREEMENT | True             | MINIMUM_VOLUME | THREE_YEARS  | PAY_UPFRONT | False            | Cloud               | Web              | 
 