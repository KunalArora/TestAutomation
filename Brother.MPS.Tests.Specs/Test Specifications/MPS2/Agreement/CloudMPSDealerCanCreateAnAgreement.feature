@MPS @UAT @TEST
Feature: CloudMPSDealerCanCreateAnAgreement
	In order to initiate a customer agreement
	As a Type 3 dealer
	I want to create a new agreement

Scenario Outline: MPS Dealer Create Agreement
	Given I have navigated to the Create Agreement page as a "<Role>" from "<Country>"
	When I enter the agreement description
	#And I have selected "<UsageType>" as the Usage Type
	#And I have selected "<ContractTerm>" as the Contract Term
	#And I have selected "<ServicePackPayment>" as the Service Pack Payment

@BUKONLY
Scenarios: 
	| Role             | Country        | UsageType      | ContractTerm | ServicePackPayment |
	| Cloud MPS Dealer | United Kingdom | Minimum Volume | 1 year       | Upfront            |
	
#@DYNAMIC_PARAMS
#Scenarios: 
#	| Role             | Country |BusinessType|
#	| Cloud MPS Dealer | Ireland |1|