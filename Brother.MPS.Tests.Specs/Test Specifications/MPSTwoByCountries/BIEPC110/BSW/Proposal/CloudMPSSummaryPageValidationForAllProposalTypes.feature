﻿@MPS @TEST @UAT @BIEPC110
Feature: CloudMPSSummaryPageValidationForAllSwissProposalTypes
	In order to avoid ambiguity on proposal summary page
	As a dealer
	I want to be verify that proposal summary page is correct for all types of proposal

@ignore
Scenario Outline: Summary Page Validation For Mindestvolumen Purchase and Click proposal In Click Payment
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I confirm the values entered for the device
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "<PaymentMethod>"
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then the billing basis for product is "<Basis2>"
	And the billing basis for Accessory is "<Basis2>"
	And the billing basis for Installation is "<Basis2>"
	And the billing basis for Service Pack is "<Basis1>"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	##And the service pack name and price displayed are correct
	And service pack cost is included click as "CHF 0.00"
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the displayed volume value for colour click price is "<ColourVolume>"
	And the calculated consumable net totals are equal in all places
	And the calculated consumable gross totals are equal in all places
	And the displayed mono click price is correct
	And the displayed colour click price is correct
	And the calculations are not based on estimated values
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country     | ContractType                 | UsageType      | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod               | ClickVolume | ColourVolume | Basis1                      | Basis2             |
	| Cloud MPS Dealer | Switzerland | Purchase & Click mit Service | Mindestvolumen | 36       | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Über den Seitenpreis zahlen | 800         | 800          | Über den Seitenpreis zahlen | Im Voraus bezahlen |
	
@ignore
Scenario Outline: Summary Page Validation For Mindestvolumen Purchase and Click proposal Upfront Payment
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I confirm the values entered for the device
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "<PaymentMethod>"
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then the billing basis for product is "<Basis1>"
	And the billing basis for Accessory is "<Basis1>"
	And the billing basis for Installation is "<Basis1>"
	And the billing basis for Service Pack is "<Basis1>"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	And the service pack name and price displayed are correct
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the displayed volume value for colour click price is "<ColourVolume>"
	And the calculated consumable net totals are equal in all places
	And the calculated consumable gross totals are equal in all places
	And the displayed mono click price is correct
	And the displayed colour click price is correct
	And the calculations are not based on estimated values
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country     | ContractType                 | UsageType      | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod      | ClickVolume | ColourVolume | Basis1             |
	| Cloud MPS Dealer | Switzerland | Purchase & Click mit Service | Mindestvolumen | 36       | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Im Voraus bezahlen | 800         | 800          | Im Voraus bezahlen |
	

Scenario Outline: Summary Page Validation For Pay As you Go Purchase and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I select service pack "<Basis1>" payment method
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I confirm the values entered for the device
	And I type in click price volume of "<ClickVolume>"
	Then the billing basis for product is "<Basis1>"
	And the billing basis for Accessory is "<Basis1>"
	And the billing basis for Installation is "<Basis1>"
	And the billing basis for Service Pack is "<Basis1>"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	And the service pack name and price displayed are correct
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the calculated consumable net totals are equal in all places
	And the calculated consumable gross totals are equal in all places
	And the displayed mono click price is correct
	And the calculations are based on estimated values
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country     | ContractType                 | CreateOption        | UsageType     | Contract | Billing       | PriceHardware | Printer    | DeviceScreen | ClickVolume | Basis1             |
	| Cloud MPS Dealer | Switzerland | Purchase & Click mit Service | Create new customer | Pay As You Go | 48       | Quartalsweise | Tick          | HL-L5100DN | Full         | 800         | Im Voraus bezahlen |
	