﻿@TEST @UAT @MPS @BIEPC110
Feature: CloudMPSSwissPurchaseAndClickProposalUserJourney
	In order to create different variety of purchase and click proposal
	As a dealer 
	I want to be able to use different MPS parameters to derive different leasing proposal

@ignore
Scenario Outline: Create different varieties of Purchase and Click proposal for new customer on Mindestvolumen Term
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details 
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "<PaymentMethod>"
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country     | ContractType                 | CreateOption        | UsageType      | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod      | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Switzerland | Purchase & Click mit Service | Create new customer | Mindestvolumen | 36       | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Im Voraus bezahlen | 800         | 800          |
	
	
 
	
Scenario Outline: Create different varieties of Purchase and Click proposal for new customer on Pay As You Go Term
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And enter a quantity of "2" for model
	And I accept the default values of the device
	And I type in click price volume of "<ClickVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country     | ContractType                 | CreateOption        | UsageType     | Contract | Billing       | PriceHardware | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | Switzerland | Purchase & Click mit Service | Create new customer | Pay As You Go | 48       | Quartalsweise | Tick          | HL-L5100DN | Full         | 750         |
	

