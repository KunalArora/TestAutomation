@MPS @UAT @TEST @TYPE3
Feature: CloudMPSDealerCanCreateAnAgreement
	In order to initiate a customer agreement
	As a Type 3 dealer
	I want to create a new agreement

Scenario Outline: MPS Dealer Create Agreement
Given I have navigated to the Create Agreement page as a Cloud MPS Dealer from "<Country>"
When I enter the agreement description
And I select the Usage Type of "<UsageType>", Contract Term of "<ContractTerm>" and Service of "<Service>"
And I add these printers and verify click price:
		| Model        | Quantity | InstallationPack | ServicePack | CoverageMono | VolumeMono | CoverageColour | VolumeColour |
		| DCP-8110DN   | 1        | Yes              | Yes         | 5            | 1000       | 0              | 0            |
And I complete the setup of agreement
Then I can verify the creation of agreement in the agreement list

@BUK
Scenarios: 
		| Country        | UsageType      | ContractTerm | Service     |
		| United Kingdom | Minimum Volume | 3 years      | Pay upfront |
	
#@DYNAMIC_PARAMS
#Scenarios: 
#	| Role             | Country |BusinessType|
#	| Cloud MPS Dealer | Ireland |1|