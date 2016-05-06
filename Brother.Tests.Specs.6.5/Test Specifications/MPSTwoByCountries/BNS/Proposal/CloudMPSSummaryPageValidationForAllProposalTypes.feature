@MPS @TEST @UAT 
Feature: CloudMPSSummaryPageValidationForAllSwedishProposalTypes
	In order to avoid ambiguity on proposal summary page
	As a dealer
	I want to be verify that proposal summary page is correct for all types of proposal

@ignore
Scenario Outline: Summary Page Validation For Minimum Volume Leasing and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
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
	And the calculated consumable gross totals are equal in all places
	And the calculations are not based on estimated values
	And leasing panels displayed
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS

	

	Scenarios: 
	| Role             | Country        | ContractType               | UsageType      | Contract | Leasing              | Billing              | Printer     | ClickVolume | ColourVolume | Basis                    | Bank        |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | HL-L8350CDW | 750         | 750          | Add to lease rental cost | BNP Paribas |
	

@ignore
Scenario Outline: Summary Page Validation For Pay As You Go Leasing and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And enter a quantity of "1" for accessory for "<Printer>"
	And I redisplay "<Printer>" device screen
	And I confirm the values entered for the device
	And I type in click price volume of "<ClickVolume>"
	Then the billing basis for product is "Add to lease rental cost"
	And the billing basis for Accessory is "Add to lease rental cost"
	And the billing basis for Installation is "Add to lease rental cost"
	And the billing basis for Service Pack is "Add to lease rental cost"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the service pack name and price displayed are correct
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the bank displayed for leasing is "BNP Paribas"
	And the quantity displayed is the same as the one entered
	And the calculated consumable net totals are equal in all places
	And the calculated consumable gross totals are equal in all places
	And the displayed mono click price is correct
	And the calculations are based on estimated values
	And leasing panels displayed
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType     | Contract | Leasing              | Billing              | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 4 years  | Quarterly in Arrears | Quarterly in Arrears | DCP-8110DN | Full         | 750         |
	


Scenario Outline: Summary Page Validation For Minimum Volume Purchase and Click proposal In Click Payment
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
	| Role             | Country        | ContractType                  | UsageType                                 | Contract | Billing                 | PriceHardware | Printer      | DeviceScreen | PaymentMethod                    | ClickVolume | ColourVolume | Basis1                        | Basis2                           |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Minimum Volume                            | 3 years  | Quarterly in Arrears    | Tick          | MFC-L8650CDW | Full         | Included in Click Price          | 800         | 800          | Included in Click Price       | Pay upfront                      |
	| Cloud MPS Dealer | France         | Buy & Click                   | Engagement sur un minimum volume de pages | 3 ans    | Trimestrale anticipata  | Tick          | MFC-L8650CDW | Full         | Paiement au démarrage du contrat | 800         | 800          | Inclus dans le coût à la page | Paiement au démarrage du contrat |
	| Cloud MPS Dealer | Italy          | Acquisto & Consumo            | Volume minimo                             | 36       | Trimestrale anticipata  | Tick          | MFC-L8650CDW | Full         | Incluso nel click                | 800         | 800          | Incluso nel click             | Pagamento anticipato             |
	| Cloud MPS Dealer | Spain          | Purchase & Click con Service  | Volúmen mínimo                            | 3 años   | Por trimestres vencidos | Tick          | MFC-L8650CDW | Full         | Pago por adelantado              | 800         | 800          | Pago por adelantado           | Pago por adelantado              |
	

Scenario Outline: Summary Page Validation For Minimum Volume Purchase and Click proposal Upfront Payment
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
	| Role             | Country        | ContractType                  | UsageType                                 | Contract | Billing                | PriceHardware | Printer      | DeviceScreen | PaymentMethod                 | ClickVolume | ColourVolume | Basis1                           |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Minimum Volume                            | 3 years  | Quarterly in Arrears   | Tick          | MFC-L8650CDW | Full         | Pay upfront                   | 800         | 800          | Pay upfront                      |
	| Cloud MPS Dealer | France         | Buy & Click                   | Engagement sur un minimum volume de pages | 3 ans    | Trimestrale anticipata | Tick          | MFC-L8650CDW | Full         | Inclus dans le coût à la page | 800         | 800          | Paiement au démarrage du contrat |
	| Cloud MPS Dealer | Italy          | Acquisto & Consumo            | Volume minimo                             | 36       | Trimestrale anticipata | Tick          | MFC-L8650CDW | Full         | Pagamento anticipato          | 800         | 800          | Pagamento anticipato             |
	
	
	##Spain has no Service Pack Payment Method
	##| Cloud MPS Dealer | Spain          | Purchase & Click con Service  | Pago por Uso	                            | 3 años   | Quarterly in Arrears   | Tick          | MFC-L8650CDW | Full         | Pago por adelantado           | 800         | 800          | Pago por adelantado			  | 
	




Scenario Outline: Summary Page Validation For Pay As you Go Purchase and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
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
	| Role             | Country        | ContractType                  | CreateOption        | UsageType                                      | Contract | Billing                        | PriceHardware | Printer    | DeviceScreen | ClickVolume | Basis1                           |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Pay As You Go                                  | 4 years  | Quarterly in Arrears           | Tick          | MFC-8510DN | Full         | 800         | Pay upfront                      |
	| Cloud MPS Dealer | France         | Buy & Click                   | Create new customer | Paiement selon la consommation réelle de pages | 4 ans    | Trimestriellement à terme échu | Tick          | MFC-8510DN | Full         | 800         | Paiement au démarrage du contrat |
	| Cloud MPS Dealer | Spain          | Purchase & Click con Service  | Create new customer | Pago por Uso                                   | 3 años   | Por trimestres vencidos        | Tick          | MFC-8510DN | Full         | 800         | Pago por adelantado              |
	