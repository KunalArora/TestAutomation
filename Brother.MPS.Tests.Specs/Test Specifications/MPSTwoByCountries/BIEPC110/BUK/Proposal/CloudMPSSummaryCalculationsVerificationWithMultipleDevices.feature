@TEST @UAT @MPS @BIEPC110 @HIGH
Feature: CloudMPSSummaryCalculationsVerificationWithMultipleDevices
	In order to validate that number of devices influences the display of print counts on summary pages
	As a dealer 
	I want to create a proposal with multiple devices


Scenario Outline: Dealer can create a proposal with multiple devices with service pack In Click 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I select service pack "<PaymentMethod>" payment method
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "<PrinterQty>" for accessory for "<Printer1>"
	And enter a quantity of "<PrinterQty>" for accessory for "<Printer2>"
	And I redisplay "<Printer1>" device screen
	And I confirm the values entered for the device
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then hardware unit price is correctly calculated
	And hardware total cost is correctly calculated for "<PrinterQty>"
	And hardware total price is correctly calculated for "<PrinterQty>"
	And accessory unit price is correctly calculated
	And accessory total cost is correctly calculated for "<PrinterQty>"
	And accessory total price is correctly calculated for "<PrinterQty>"
	And device total prices are correctly added up
	And total mono volume is correctly displayed for "<PrinterQty>"
	And total colour volume is correctly displayed for "<PrinterQty>"
	And total mono line price is correctly calculated for "<PrinterQty>"
	And total colour line price is correctly calculated for "<PrinterQty>"
	And total volume correctly added up
	And total price correctly added up
	And contract net grand total is correctly added up
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | UsageType      | Contract | Billing              | PriceHardware | Printer1     | Printer2    | DeviceScreen | PaymentMethod           | ClickVolume | ColourVolume | Basis1                  | Basis2      | PrinterQty |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Minimum Volume | 3 years  | Quarterly in Arrears | Tick          | MFC-L8650CDW | MFC-L5750DW | Full         | Included in Click Price | 800         | 800          | Included in Click Price | Pay upfront | 9           |
	

Scenario Outline: Dealer can create a proposal with multiple devices with upfront service pack 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "<PrinterQty>" for accessory for "<Printer1>"
	And I redisplay "<Printer1>" device screen
	And I confirm the values entered for the device
	And I type in click price volume of "<ClickVolume>"
	Then hardware unit price is correctly calculated
	And hardware total cost is correctly calculated for "<PrinterQty>"
	And hardware total price is correctly calculated for "<PrinterQty>"
	And accessory unit price is correctly calculated
	And accessory total cost is correctly calculated for "<PrinterQty>"
	And accessory total price is correctly calculated for "<PrinterQty>"
	And device total prices are correctly added up
	And total mono volume is correctly displayed for "<PrinterQty>"
	And total colour volume is correctly displayed for "<PrinterQty>"
	And total mono line price is correctly calculated for "<PrinterQty>"
	And total colour line price is correctly calculated for "<PrinterQty>"
	And total volume correctly added up
	And total price correctly added up
	And contract net grand total is correctly added up
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | UsageType     | Contract | Billing              | PriceHardware | Printer1    | DeviceScreen | ClickVolume | PrinterQty |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Pay As You Go | 3 years  | Quarterly in Arrears | Tick          | MFC-L5750DW | Full         | 750         | 9          |
	