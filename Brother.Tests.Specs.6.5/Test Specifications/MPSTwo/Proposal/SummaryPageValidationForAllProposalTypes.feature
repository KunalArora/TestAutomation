@MPS @TEST @UAT 
Feature: SummaryPageValidationForAllProposalTypes
	In order to avoid ambiguity on proposal summary page
	As a dealer
	I want to be verify that proposal summary page is correct for all types of proposal


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
	Then the billing basis for product is "Add to lease rental cost"
	And the billing basis for Accessory is "Add to lease rental cost"
	And the billing basis for Installation is "Add to lease rental cost"
	And the billing basis for Service Pack is "Add to lease rental cost"
	And the installation type displayed is correct
	And the installation cost displayed is correct
	And the quantity displayed is the same as the one entered
	And the service pack name and price displayed are correct
	And the displayed volume value for mono click price is "<ClickVolume>"
	And the displayed volume value for colour click price is "<ColourVolume>"
	And the displayed mono click price is correct
	And the displayed colour click price is correct
	And the bank displayed for leasing is "BNP Paribas"
	And the calculated consumable net totals are equal in all places
	And the calculated consumable gross totals are equal in all places
	And the calculations are not based on estimated values
	And leasing panels displayed
	And clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS

	

	Scenarios: 
	| Role             | Country        | ContractType               | UsageType      | Contract | Leasing   | Billing   | Printer     | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Minimum Volume | 3 years  | Quarterly | Quarterly | HLL8350CDW | 750         | 750          |


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
	| Role             | Country        | ContractType               | CreateOption        | UsageType     | Contract | Leasing   | Billing   | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 4 years  | Quarterly | Quarterly | DCP8110DN | Full         | 750        |



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
	Then the billing basis for product is "Pay upfront"
	And the billing basis for Accessory is "Pay upfront"
	And the billing basis for Installation is "Pay upfront"
	And the billing basis for Service Pack is "Included in Click Price"
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
	| Role             | Country        | ContractType                  | UsageType      | Contract | Leasing                  | Billing                  | PriceHardware | Printer      | DeviceScreen | PaymentMethod           | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Minimum Volume | 3 years  | Quarterly | Quarterly | Tick          | MFCL8650CDW | Full         | Included in Click Price | 800        | 800         |


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
	Then the billing basis for product is "Pay upfront"
	And the billing basis for Accessory is "Pay upfront"
	And the billing basis for Installation is "Pay upfront"
	And the billing basis for Service Pack is "Pay upfront"
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
	| Role             | Country        | ContractType                  | UsageType      | Contract | Leasing                  | Billing                  | PriceHardware | Printer      | DeviceScreen | PaymentMethod           | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Minimum Volume | 3 years  | Quarterly | Quarterly | Tick          | MFCL8650CDW | Full         | Pay Upfront | 800        | 800         |

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
	Then the billing basis for product is "Pay upfront"
	And the billing basis for Accessory is "Pay upfront"
	And the billing basis for Installation is "Pay upfront"
	And the billing basis for Service Pack is "Pay upfront"
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
	| Role             | Country        | ContractType                  | CreateOption        | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer    | DeviceScreen | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Pay As You Go | 4 years  | Quarterly | Quarterly | Tick        | MFC8510DN | Full     | 800        |
