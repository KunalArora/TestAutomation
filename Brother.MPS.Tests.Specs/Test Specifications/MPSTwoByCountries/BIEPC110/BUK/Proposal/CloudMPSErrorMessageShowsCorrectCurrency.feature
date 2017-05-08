@MPS @TEST @UAT @BIEPC110
Feature: CloudMPSErrorMessageShowsCorrectUKCurrency
	In order to ensure that error message correctly displayed currency
	As a dealer
	I want to see the currency in error match specified currency

@ignore
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
	And I enter incorrect installation cost of "0.00"
	Then error message displayed contains the "<Currency>" of the specified country
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | CreateOption           | UsageType     | Contract | Billing              | PriceHardware | Printer     | ClickVolume | Currency |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Skip customer creation | Pay As You Go | 3 years  | Quarterly in Arrears | Tick          | MFC-L5750DW | 750         | £        |
	
	                    