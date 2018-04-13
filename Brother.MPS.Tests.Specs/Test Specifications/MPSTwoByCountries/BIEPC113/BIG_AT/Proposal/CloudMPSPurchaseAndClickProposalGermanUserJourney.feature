@TEST @UAT @MPS @BIEPC113 @CRITICAL
Feature: CloudMPSGermanPurchaseAndClickProposalUserJourney
	In order to create different variety of purchase and click proposal
	As a dealer 
	I want to be able to use different MPS parameters to derive different leasing proposal


Scenario Outline: MPS Create MV Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details 
	And I select service pack "<PaymentMethod>" payment method
	And I "<PriceHardware>" Price Hardware radio button
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
	| Role             | Country | ContractType             | CreateOption        | UsageType      | Contract | Billing         | PriceHardware | Printer      | DeviceScreen | PaymentMethod | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Austria | Easy Print Pro & Service | Create new customer | Mindestvolumen | 5 Jahre  | Vierteljährlich | Tick          | MFC-L8650CDW | Full         | im Voraus bezahlen   | 800         | 800          |
	| Cloud MPS Dealer | Germany | Easy Print Pro & Service | Create new customer | Mindestvolumen | 5 Jahre  | Vierteljährlich | Tick          | MFC-L8650CDW | Full         | im Voraus bezahlen   | 800         | 800          |
	
@Ignore
Scenario Outline: MPS GermanAustria Create different varieties of German And Austria Purchase and Click proposal for new customer on Pay As You Go Term
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	#And enter a quantity of "2" for model
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
	| Role             | Country | ContractType             | CreateOption        | UsageType     | Contract | Billing      | PriceHardware | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | Germany | Easy Print Pro & Service | Create new customer | Pay As You Go | 3 Jahre  | Halbjährlich | Tick          | MFC-8510DN | Full         | 750         |


Scenario Outline: MPS Create Proposal With Existing Customer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And Customer Information tab is not displayed
	When I fill Proposal Description for "<ContractType>" Contract type
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details 
	And I select service pack "<PaymentMethod>" payment method 
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And Service Pack In Click line is displayed
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
	| Role             | Country | ContractType             | CreateOption        | UsageType      | Contract | Billing         | PriceHardware | Printer      | DeviceScreen | PaymentMethod               | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | Easy Print Pro & Service | Create new customer | Mindestvolumen | 5 Jahre  | Vierteljährlich | Tick          | MFC-L8650CDW | Full         | über den Seitenpreis zahlen | 800         | 800          |
	| Cloud MPS Dealer | Austria | Easy Print Pro & Service | Create new customer | Mindestvolumen | 5 Jahre  | Vierteljährlich | Tick          | MFC-L8650CDW | Full         | über den Seitenpreis zahlen | 800         | 800          |
	
@Ignore
Scenario Outline: MPS GermanAustria Create different varieties of German And Austria Purchase and Click proposal for an existing customer on Pay As You Go Term
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts  
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
	| Role             | Country | ContractType             | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | Germany | Easy Print Pro & Service | Pay As You Go | 5 years  | Quarterly | Quarterly | Tick          | MFC-8510DN | Full         | 3000        |
	
	