﻿@MPS @UAT @TEST @BIEPC112
Feature: CloudMPSDannishDealerCanCreateProposalFromProposalListPage
	In order to create a proposal from proposal list page
	As a dealer
	I want create new porposal button on proposal list page

Scenario Outline: MPS Create Proposal From List Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing proposal screen
	And I begin the process of proposal creation process
	When I fill Proposal Description for "<ContractType>" Contract type
	And I skip contact creation process
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I select service pack "<PaymentMethod>" payment method
	And I "<PriceHardware>" Price Hardware radio button
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I move to Click Price page
	And Service Pack In Click line is displayed
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then the billing basis for product is "<Basis2>"
	And the billing basis for Accessory is "<Basis2>"
	And the billing basis for Installation is "<Basis2>"
	And the billing basis for Service Pack is "<Basis1>"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	##And the service pack name and price displayed are correct
	And service pack cost is included click as "kr. 0,00"
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
	| Role             | Country | ContractType           | UsageType       | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod         | ClickVolume | ColourVolume | Basis1                | Basis2            |
	| Cloud MPS Dealer | Denmark | Køb & Klik med service | Minimumsvolumen | 3 år     | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Inkluderet i klikpris | 800         | 800          | Inkluderet i klikpris | Betale på forskud |
	
	
	