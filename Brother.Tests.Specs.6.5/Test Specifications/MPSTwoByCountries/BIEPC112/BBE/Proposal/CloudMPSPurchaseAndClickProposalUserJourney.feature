@TEST @UAT @MPS
Feature: CloudMPSBelgianPurchaseAndClickProposalUserJourney
	In order to create different variety of purchase and click proposal
	As a dealer 
	I want to be able to use different MPS parameters to derive different leasing proposal


Scenario Outline: MPS Create MV Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I change the language to "<Language>"
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
	| Role             | Country | ContractType                  | CreateOption        | UsageType      | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod                         | ClickVolume | ColourVolume | Language |
	| Cloud MPS Dealer | Belgium | Purchase & Click with Service | Create new customer | Minimum Volume | 3 jaar   | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Betaling bij aanvang van het contract | 800         | 800          | Dutch    |
	| Cloud MPS Dealer | Belgium | Buy & Click                   | Create new customer | Volume minimum | 3 ans    | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Paiement au démarrage du contrat      | 800         | 800          | French   |
	

Scenario Outline: MPS Create Proposal With Existing Customer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I change the language to "<Language>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
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
	| Role             | Country | ContractType                  | UsageType      | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod               | ClickVolume | ColourVolume | Language |
	| Cloud MPS Dealer | Belgium | Purchase & Click with Service | Minimum Volume | 3 jaar   | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Inbegrepen in de clickprijs | 800         | 800          | Dutch    |
	| Cloud MPS Dealer | Belgium | Buy & Click                   | Volume minimum | 3 ans    | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Inclus dans le prix click   | 800         | 800          | French   |
	