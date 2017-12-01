@MPS @UAT @TEST @TYPE3 @SMOKE
Feature: CloudMPSDealerCanCreateAnAgreement
	In order to initiate a customer agreement
	As a Type 3 dealer
	I want to create a new agreement

Scenario Outline: MPS Dealer Create Agreement
	Given I have navigated to the Create Agreement page as a "<Role>" from "<Country>"
	When I enter the agreement description
	And I select "<UsageType>" as the Usage Type and I select "<ContractTerm>" as the Contract Term
	And I add a printer to the agreement
	And I enter coverage and volume values on the click price calculation page
	#And I have selected "<ServicePackPayment>" as the Service Pack Payment


#TODO: add support for table values for printers
Scenarios: 
	| Role             | Country        | UsageType     | ContractTerm | ServicePackPayment |
	| Cloud MPS Dealer | United Kingdom | Pay As You Go | 2 years      | Upfront            |
	
#@DYNAMIC_PARAMS
#Scenarios: 
#	| Role             | Country |BusinessType|
#	| Cloud MPS Dealer | Ireland |1|