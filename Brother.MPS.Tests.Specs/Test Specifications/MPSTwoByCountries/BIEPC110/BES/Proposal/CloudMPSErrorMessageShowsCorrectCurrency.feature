@MPS @TEST @UAT @BIEPC110 @MEDIUM
Feature: CloudMPSErrorMessageShowsCorrectSpanishCurrency
	In order to ensure that error message correctly displayed currency
	As a dealer
	I want to see the currency in error match specified currency


Scenario Outline: Currency in product screen error message
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And enter a quantity of "2" for model
	And I enter some values for the device
	##And I enter incorrect installation cost of "0.00"
	##Then error message displayed contains the "<Currency>" of the specified country
	Then Brother installation cost price ca not be changed by a dealer 
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country | ContractType                 | CreateOption           | UsageType    | Contract | Billing                 | PriceHardware | Printer     | ClickVolume | Currency |
	| Cloud MPS Dealer | Spain   | Purchase & Click con Service | Skip customer creation | Pago por Uso | 3 años   | Por trimestres vencidos | Tick          | MFC-L5750DW | 750         | €        |
	
