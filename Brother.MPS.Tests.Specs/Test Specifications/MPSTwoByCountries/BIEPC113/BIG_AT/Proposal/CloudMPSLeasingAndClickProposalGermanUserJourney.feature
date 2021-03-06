﻿@TEST @UAT @MPS @BIEPC113 @HIGH
Feature: CloudMPSGermanLeasingAndClickProposalUserJourney
	In order to create different variety of leasing proposal
	As a dealer 
	I want to be able to use different MPS parameters to derive different leasing proposal


Scenario Outline: MPS Create Leasing Proposal 5Years
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details  
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Leasing>" displayed on proposal Summary Page corresponds to "<Leasing>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS

	

	Scenarios: 
	| Role             | Country | ContractType      | CreateOption        | UsageType     | Contract | Leasing         | Billing      | Printer     | DeviceScreen | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | Leasing & Service | Create new customer | Pay As You Go | 5 Jahre  | Vierteljährlich | Halbjährlich | HL-L8350CDW | Full         | 750         | 750          |
	| Cloud MPS Dealer | Austria | Leasing & Service | Create new customer | Pay As You Go | 5 Jahre  | Vierteljährlich | Halbjährlich | HL-L8350CDW | Full         | 750         | 750          |
	
	
	


Scenario Outline: MPS Create Leasing Proposal 4Years
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details  
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I type in click price volume of "<ClickVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Leasing>" displayed on proposal Summary Page corresponds to "<Leasing>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS

	
	Scenarios: 
	| Role             | Country | ContractType      | CreateOption        | UsageType     | Contract | Leasing   | Billing      | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | Germany | Leasing & Service | Create new customer | Pay As You Go | 4 Jahre  | Monatlich | Halbjährlich | DCP-8110DN | Full         | 750         |
	| Cloud MPS Dealer | Austria | Leasing & Service | Create new customer | Pay As You Go | 4 Jahre  | Monatlich | Halbjährlich | DCP-8110DN | Full         | 750         |
	
	

Scenario Outline: MPS Create Leasing Proposal 3Years
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then "<ContractType>" displayed on proposal Summary Page corresponds to "<ContractType>"
	And "<UsageType>" displayed on proposal Summary Page corresponds to "<UsageType>"
	And "<Contract>" displayed on proposal Summary Page corresponds to "<Contract>"
	And "<Leasing>" displayed on proposal Summary Page corresponds to "<Leasing>"
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country | ContractType      | UsageType     | Contract | Leasing         | Billing      | Printer     | DeviceScreen | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | Leasing & Service | Pay As You Go | 3 Jahre  | Vierteljährlich | Halbjährlich | HL-L8350CDW | Full         | 750         | 750          |
	| Cloud MPS Dealer | Austria | Leasing & Service | Pay As You Go | 3 Jahre  | Vierteljährlich | Halbjährlich | HL-L8350CDW | Full         | 750         | 750          |
	
	
