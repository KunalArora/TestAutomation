@TEST @UAT @MPS
Feature: CloudMPSSpanishPurchaseAndClickProposalUserJourney
	In order to create different variety of purchase and click proposal
	As a dealer 
	I want to be able to use different MPS parameters to derive different leasing proposal


Scenario Outline: Create different varieties of Purchase and Click proposal for new customer on Minimum Volume Term
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
	| Role             | Country        | ContractType                  | CreateOption        | UsageType                                 | Contract | Billing                 | PriceHardware | Printer      | DeviceScreen | PaymentMethod        | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Minimum Volume                            | 3 years  | Quarterly in Arrears    | Tick          | MFC-L8650CDW | Full         | Pay upfront          | 800         | 800          |
	| Cloud MPS Dealer | France         | Buy & Click                   | Create new customer | Engagement sur un minimum volume de pages | 4 ans    | Trimestrale anticipata  | Tick          | MFC-L8650CDW | Full         | Pay upfront          | 800         | 800          |
	| Cloud MPS Dealer | Italy          | Acquisto & Consumo            | Create new customer | Volume minimo                             | 48       | Trimestrale anticipata  | Tick          | MFC-L8650CDW | Full         | Pagamento anticipato | 800         | 800          |
	| Cloud MPS Dealer | Spain          | Purchase & Click con Service  | Create new customer | Volúmen mínimo                            | 3 años   | Por trimestres vencidos | Tick          | MFC-L8650CDW | Full         | Pago por adelantado  | 800         | 800          |
	
	
 
	
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
	| Role             | Country        | ContractType                  | CreateOption        | UsageType                                      | Contract | Billing                        | PriceHardware | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Pay As You Go                                  | 4 years  | Quarterly in Arrears           | Tick          | MFC-8510DN | Full         | 750         |
	| Cloud MPS Dealer | France         | Buy & Click                   | Create new customer | Paiement selon la consommation réelle de pages | 4 ans    | Trimestriellement à terme échu | Tick          | MFC-8510DN | Full         | 750         |
	| Cloud MPS Dealer | Spain          | Purchase & Click con Service  | Create new customer | Pago por Uso                                   | 4 años   | Por trimestres vencidos        | Tick          | MFC-8510DN | Full         | 750         |
	
	## Italy does not have Pay as you Go facility
	#| Cloud MPS Dealer | Italy          | Acquisto & Consumo            | Create new customer | Pagamento a consumo                            | 48       | Quarterly in Advance | Tick          | MFC-8510DN | Full         | 750         |
	

Scenario Outline: Create different varieties of Purchase and Click proposal for an existing customer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
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
	| Role             | Country        | ContractType                  | UsageType                                 | Contract | Billing                 | PriceHardware | Printer      | DeviceScreen | PaymentMethod                 | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Minimum Volume                            | 3 years  | Quarterly in Arrears    | Tick          | MFC-L8650CDW | Full         | Included in Click Price       | 800         | 800          |
	| Cloud MPS Dealer | France         | Buy & Click                   | Engagement sur un minimum volume de pages | 3 ans    | Trimestrale anticipata  | Tick          | MFC-L8650CDW | Full         | Inclus dans le coût à la page | 800         | 800          |
	| Cloud MPS Dealer | Italy          | Acquisto & Consumo            | Volume minimo                             | 36       | Trimestrale anticipata  | Tick          | MFC-L8650CDW | Full         | Incluso nel click             | 800         | 800          |
	| Cloud MPS Dealer | Spain          | Purchase & Click con Service  | Volúmen mínimo                            | 3 años   | Por trimestres vencidos | Tick          | MFC-L8650CDW | Full         | Pago por adelantado           | 800         | 800          |
	

Scenario Outline: Create different varieties of Purchase and Click proposal for an existing customer on Pay As You Go Term
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
	And "<Billing>" displayed on proposal Summary Page corresponds to "<Billing>"
	And "<Printer>" displayed on proposal Summary Page corresponds to "<Printer>"
	And "<ClickVolume>" displayed on proposal Summary Page corresponds to "<ClickVolume>"
	And "<ColourVolume>" displayed on proposal Summary Page corresponds to "<ColourVolume>"
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | UsageType                                      | Contract | Billing                        | PriceHardware | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Pay As You Go                                  | 5 years  | Quarterly in Arrears           | Tick          | MFC-8510DN | Full         | 750         |
	| Cloud MPS Dealer | France         | Buy & Click                   | Paiement selon la consommation réelle de pages | 5 ans    | Trimestriellement à terme échu | Tick          | MFC-8510DN | Full         | 750         |
	| Cloud MPS Dealer | Spain          | Purchase & Click con Service  | Pago por Uso                                   | 5 años   | Por trimestres vencidos        | Tick          | MFC-8510DN | Full         | 750         |
	
	## Italy does not have Pay as you Go facility
	#| Cloud MPS Dealer | Italy          | Acquisto & Consumo            | Create new customer | Pagamento a consumo                            | 48       | Quarterly in Advance | Tick          | MFC-8510DN | Full         | 750         |
	