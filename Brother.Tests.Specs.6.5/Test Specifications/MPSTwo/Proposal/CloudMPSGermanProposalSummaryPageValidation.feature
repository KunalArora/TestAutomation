@TEST @UAT @MPS
Feature: CloudMPSGermanProposalSummaryPageValidation
	In order to avoid ambiguity on proposal summary page
	As a dealer
	I want to be verify that proposal summary page is correct for all types of proposal


Scenario Outline: Summary Page Validation For German And Austria Leasing and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I confirm the values entered for the device
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then the billing basis for product is "<Basis>"
	And the billing basis for Accessory is "<Basis>"
	And the billing basis for Installation is "<Basis>"
	And the billing basis for Service Pack is "<Basis>"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	And the service pack name and price displayed are correct
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the displayed volume value for colour click price is "<ColourVolume>"
	And the displayed mono click price is correct
	And the displayed colour click price is correct
	And the bank displayed for leasing is "<Bank>"
	And the calculated consumable net totals are equal in all places
	#And the calculated consumable gross totals are equal in all places
	And the calculations are based on estimated values
	And leasing panels displayed
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country | ContractType      | UsageType      | Contract | Leasing         | Billing      | Printer     | ClickVolume | ColourVolume | Basis                    | Bank                         |
	| Cloud MPS Dealer | Germany | Leasing & Service | Minimum Volume | 3 Jahre  | Vierteljährlich | Halbjährlich | HL-L8350CDW | 750         | 750          | zur Leasingrate addieren | BNP PARIBAS LEASE GROUP S.A. |
	| Cloud MPS Dealer | Austria | Leasing & Service | Minimum Volume | 3 Jahre  | Vierteljährlich | Halbjährlich | HL-L8350CDW | 750         | 750          | zur Leasingrate addieren | BNP PARIBAS LEASE GROUP S.A. |
	

Scenario Outline: Summary Page Validation For Minimum Volume German And Austria Purchase and Click proposal In Click Payment
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I confirm the values entered for the device
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "über den Seitenpreis zahlen"
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then the billing basis for product is "<PaymentMethod>"
	And the billing basis for Accessory is "<PaymentMethod>"
	And the billing basis for Installation is "<PaymentMethod>"
	And the billing basis for Service Pack is "über den Seitenpreis zahlen"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	And the service pack name and price displayed are correct
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the displayed volume value for colour click price is "<ColourVolume>"
	And the calculated consumable net totals are equal in all places
	#And the calculated consumable gross totals are equal in all places
	And the displayed mono click price is correct
	And the displayed colour click price is correct
	And the calculations are not based on estimated values
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country | ContractType                  | UsageType      | Contract | Billing      | PriceHardware | Printer      | PaymentMethod      | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | Easy Print Pro & Service | Minimum Volume | 5 Jahre  | Halbjährlich | Tick          | MFC-L8650CDW | im Voraus bezahlen | 800         | 800          |
	| Cloud MPS Dealer | Austria | Easy Print Pro & Service | Minimum Volume | 5 Jahre  | Halbjährlich | Tick          | MFC-L8650CDW | im Voraus bezahlen | 800         | 800          |
	
	

Scenario Outline: Summary Page Validation For Minimum Volume German And Austria Purchase and Click proposal Upfront Payment
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I confirm the values entered for the device
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "<PaymentMethod>"
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then the billing basis for product is "<PaymentMethod>"
	And the billing basis for Accessory is "<PaymentMethod>"
	And the billing basis for Installation is "<PaymentMethod>"
	And the billing basis for Service Pack is "<PaymentMethod>"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	And the service pack name and price displayed are correct
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the displayed volume value for colour click price is "<ColourVolume>"
	And the calculated consumable net totals are equal in all places
	#And the calculated consumable gross totals are equal in all places
	And the displayed mono click price is correct
	And the displayed colour click price is correct
	And the calculations are not based on estimated values
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country | ContractType                  | UsageType      | Contract | Billing         | PriceHardware | Printer      | PaymentMethod      | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | Easy Print Pro & Service | Minimum Volume | 4 Jahre  | Vierteljährlich | Tick          | MFC-L8650CDW | im Voraus bezahlen | 800         | 800          |
	| Cloud MPS Dealer | Austria | Easy Print Pro & Service | Minimum Volume | 4 Jahre  | Vierteljährlich | Tick          | MFC-L8650CDW | im Voraus bezahlen | 800         | 800          |
	
