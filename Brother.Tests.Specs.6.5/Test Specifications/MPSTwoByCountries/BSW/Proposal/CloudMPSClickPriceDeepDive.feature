@MPS @TEST @UAT
Feature: CloudMPSSwissClickPriceDeepDive
	In order to create different variety of click price
	As a dealer 
	I want to be able to use different MPS parameters to derive different leasing proposal

#
# Service Pack Display
#
# 1
@ignore
Scenario Outline: Lease + Click, PAYG, Service Pack not displayed
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	Then Service Pack payment method is not displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN   | Full         |  Pay upfront  | 0           | 2000         |

# 2
@ignore
Scenario Outline: Lease + Click, Minimum Volume, Service Pack not displayed
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	Then Service Pack payment method is not displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN   | Full         |  Pay upfront  | 0           | 2000         |


# 3
Scenario Outline: Purchase + Click, PAYG, Service Pack not displayed
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
Scenario Outline: Purchase + Click, Minimum Volume, Service Pack not displayed
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


# 5
@ignore
# why not displayed?
Scenario Outline: Variation of "In Click" and "Upfront Payment" click price(1)
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
	| Role             | Country        | ContractType                  | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN   | Full         |  Pay upfront  | 0           | 2000         |

# 6
@ignore
# why not displayed service pack selection?
Scenario Outline: Variation of "In Click" and "Upfront Payment" click price(2)
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
	Then the click price displayed for the Mono is changed accordingly
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        | ContractType                  | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer       | DeviceScreen | PaymentMethod             | MonoCoverage | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN     | Full         |  Included in Click Price  | 6            | 2000        | 2000         |



# 7
Scenario Outline: Variation of "In Click" and "Upfront Payment" click price(3)
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
Scenario Outline: Variation of "In Click" and "Upfront Payment" click price(4)
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
Scenario Outline: No Variation of "In Click" and "Upfront Payment" click price(Purchase & Click)
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

# 11-14
@ignore
Scenario Outline: Lease + Click, Minimum Volume, Service Pack Payment Method not displayed
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	Then Service Pack payment method is not displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod           | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN   | Full         | Pay upfront             | 0           | 2000         |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Pay upfront             | 0           | 2000         |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go  | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN   | Full         | Included in Click Price | 2000        | 2000         |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go  | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Included in Click Price | 2000        | 2000         |
	
# Click Price Boundaries
# 15
@ignore
Scenario Outline: Mono Volume Boundaries for Minimum Volume
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter "<MonoCoverage>" into Mono Coverage field
	And I select "<ClickVolume1>" from Mono Volume field
	And I calculate click price for the printer
	And I select "<ClickVolume2>" from Mono Volume field
	And I calculate click price for the printer
	And I select "<ClickVolume3>" from Mono Volume field
	And I calculate click price for the printer
	Then the Click Price value for Volume value become smaller and smaller
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType       | Contract | Leasing   | Billing   | PriceHardware | Printer    | DeviceScreen | PaymentMethod | MonoCoverage | ClickVolume1 | ClickVolume2 | ClickVolume3 |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Minimum Volume  | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN  | Full         | Pay upfront   | 6            | 500          | 1500         | 3500         | 

#16
@ignore
Scenario Outline: Colour and Mono Volume Boundaries for Minimum Volume
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer1>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I add the device that changed the default values
	And I display "<Printer2>" device screen
	And I accept the default values of the device
	And I enter "<MonoCoverage>" into Mono Coverage field
	And I select "<ClickVolume1>" from Mono Volume field
	And I select "<ClickVolume2>" from Mono Volume field by indicating row1
	And I select "<ClickVolume2>" from Colour Volume field by indicating row1
	And I calculate click price for the printer
	And I select "<ClickVolume3>" from Mono Volume field
	And I select "<ClickVolume3>" from Mono Volume field by indicating row1
	And I select "<ClickVolume3>" from Colour Volume field by indicating row1
	And I calculate click price for the printer
	Then the click price for Mono field0 is changed
	And the click price for Colour field1 is changed
	And the click price for Mono field1 is not changed

	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer1   | Printer2   | DeviceScreen | PaymentMethod | MonoCoverage | ClickVolume1 | ClickVolume2 | ClickVolume3 |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Minimum Volume | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN | MFC-L8650CDW |Full          | Pay upfront   | 6            | 500          | 1000         | 2000         | 

#17
@ignore
Scenario Outline: Mono Volume Boundaries for PAYG
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter "<MonoCoverage>" into Mono Coverage field
	And I enter "<ClickVolume1>" into Mono Volume field
	And I calculate click price for the printer
	And I enter "<ClickVolume2>" into Mono Volume field
	And I calculate click price for the printer
	And I enter "<ClickVolume3>" into Mono Volume field
	And I calculate click price for the printer
	Then the Click Price value for Volume value is all equal
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType      | Contract | Leasing     | Billing   | PriceHardware | Printer   | DeviceScreen | PaymentMethod | MonoCoverage | ClickVolume1 | ClickVolume2 | ClickVolume3 |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go  | 3 years  | Quarterly in Arrears   | Quarterly in Arrears | Tick          | MFC-8510DN | Full         | Pay upfront   | 6            | 500          | 1500         | 3500         | 


#18
@ignore
Scenario Outline: Colour and Mono Volume Boundaries for PAYG
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer1>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I add the device that changed the default values
	And I display "<Printer2>" device screen
	And I accept the default values of the device
	And I enter "<MonoCoverage>" into Mono Coverage field
	And I enter "<ClickVolume1>" from Mono Volume field by indicating row0
	And I enter "<ClickVolume1>" from Mono Volume field by indicating row1
	And I enter "<ClickVolume1>" from Colour Volume field by indicating row1
	And I calculate click price for the printer
	And I enter "<ClickVolume2>" from Mono Volume field by indicating row0
	And I enter "<ClickVolume2>" from Mono Volume field by indicating row1
	And I enter "<ClickVolume2>" from Colour Volume field by indicating row1
	And I calculate click price for the printer
	Then the click price for Mono field0 is not changed
	And the click price for Colour field1 is not changed
	And the click price for Mono field1 is not changed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType      | Contract | Leasing   | Billing   | PriceHardware | Printer1  | Printer2    | DeviceScreen | PaymentMethod | MonoCoverage | ClickVolume1 | ClickVolume2 | ClickVolume3 |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go  | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN | MFC-L8650CDW |Full          | Pay upfront   | 6            | 800          | 1200         | 2000         | 


# 4. Coverage
# 19-20
@ignore
Scenario Outline: Mono Coverage calculated correctly
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter "<MonoCoverage>" into Mono Coverage field
	And I enter "<ClickVolume>" into Mono Volume field
	And I calculate click price for the printer
	Then Service Pack payment method is not displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer   | DeviceScreen | PaymentMethod | MonoCoverage | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN | Full         | Pay upfront   | 6            | 2           |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN | Full         | Pay upfront   | 99           | 2           |

# 21-22
@ignore
Scenario Outline: Mono Coverage calculated then error occurs
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter "<MonoCoverage>" into Mono Coverage field
	And I enter "<ClickVolume>" into Mono Volume field
	And I calculate click price for the printer
	Then the coverage error is displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer   | DeviceScreen | PaymentMethod | MonoCoverage | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN | Full         | Pay upfront   | 4            | 2           |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-8510DN | Full         | Pay upfront   | 101          | 2           |

# 23-24
@ignore
Scenario Outline: Colour Coverage calculated correctly
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter "<MonoCoverage>" into Colour Coverage field
	And I enter "<ClickVolume>" into Colour Volume field
	And I calculate click price for the printer
	Then Service Pack payment method is not displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod | MonoCoverage | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Pay upfront   | 21           | 2           |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Pay upfront   | 99           | 2           |

# 25-26
@ignore
Scenario Outline: Colour Coverage calculated then error occurs
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I select "<CreateOption>" button for customer data capture 
	And I Enter usage type of "<UsageType>" and "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And I enter "<MonoCoverage>" into Colour Coverage field
	And I enter "<ClickVolume>" into Colour Volume field
	And I calculate click price for the printer
	Then the coverage error is displayed
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country        | ContractType               | CreateOption        | UsageType     | Contract | Leasing   | Billing   | PriceHardware | Printer     | DeviceScreen | PaymentMethod | MonoCoverage | ClickVolume |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Pay upfront   | 19           | 2           |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service | Create new customer | Pay As You Go | 3 years  | Quarterly in Arrears | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Pay upfront   | 101          | 2           |
