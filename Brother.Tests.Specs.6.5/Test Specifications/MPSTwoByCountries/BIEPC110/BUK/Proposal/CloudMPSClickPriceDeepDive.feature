@MPS @TEST @UAT
Feature: CloudMPSUKClickPriceDeepDive
	In order to create different variety of click price
	As a dealer 
	I want to be able to use different MPS parameters to derive different leasing proposal

#
# Service Pack Display
#

# 3
Scenario Outline: MPS PAYG SP Not Displayed
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	Then Service Pack payment method is not displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | CreateOption        | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN   | Full         |  Pay upfront  | 0           | 2000         |

# 4
Scenario Outline: MPS Minimum Volume SP Not Displayed
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	Then Service Pack payment method is not displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN   | Full         |  Pay upfront  | 0           | 2000         |



# 7
Scenario Outline: MPS In Click And Upfront CP Displayed
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details 
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	Then Service Pack payment method is displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer       | DeviceScreen | PaymentMethod | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW   | Full         |  Pay upfront  | 0           | 2000         |


# 8
Scenario Outline: MPS In Click And Upfront Mono Changes
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
	And I enter "<MonoCoverage>" into Mono Coverage field
	And I calculate click price for the printer
	And I choose to pay Service Packs "<PaymentMethod>"
	And I calculate click price for the printer
	Then the click price displayed for the Colour is changed accordingly
	And the click price for Mono is not changed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer        | DeviceScreen | PaymentMethod             | MonoCoverage | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW   | Full         |  Included in Click Price  | 6            | 2000        | 2000         |


# 9-10
Scenario Outline: MPS CP Variation
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details 
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	Then Service Pack payment method is not displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType                  | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod             | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Pay As You Go  | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN   | Full         |  Included in Click Price  | 2000        | 2000         |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Pay As You Go  | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         |  Included in Click Price  | 2000        | 2000         |

