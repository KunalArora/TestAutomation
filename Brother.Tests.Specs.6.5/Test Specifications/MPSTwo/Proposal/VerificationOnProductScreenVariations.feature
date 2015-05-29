@UAT @TEST
Feature: Proposal - Add a devices to a proposal during creation
	In order to create a contract with a device 
	As an MPS Dealer
	I want to create a proposal that has a device

#
# 1 Screen Variations
#
# 1)
@Ignore
Scenario Outline: Should be able to display full detail screen
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page all the device have full detail screen
#	And all the SRP are not editable
#	And the QTY for Delivery Cost, Installation Cost and Service Pack are not editable

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

# 2)
@Ignore
Scenario Outline: Default value of full detail screen are verified
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page QTY for accessories are default to zero
	And the default total for all accessories are defaulted to zero

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

# 3)
@Ignore
Scenario Outline: Total Price calulation is verified
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And enter a quantity value into an accessory field
#	Then on product page the Total Price is the product of QTY and Unit Price

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

# 4)
@Ignore
Scenario Outline: The sum of Total Price is equal to the Grand Total Price
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page the sum of the Total Price is equal to the Grand Total Price displayed

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

# 5)
@Ignore
Scenario Outline: All Zero QTY fields are not displayed on summary page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
#	And on product page all the accessories all left with zero QTY
	And I Add the device to Proposal
	And I Calculate Click Price
	Then the selected devices above are displayed on Summary Screen
#	Then all the components of device with zero QTY are not displayed on summary page

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

# 6)
@Ignore
Scenario Outline: Should be able to display Reduced detail screen
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I untick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page all the devices have reduced detail screen
#	And all the SRP fields are ineditable
#	And a change in product quantity affect the product TotalPrice

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

# 7)
@Ignore
Scenario Outline: Lease and Click product screen validation
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details(only input)
	Then I should not see Price Hardware radio button on Term and Type screen
	And I display "<Printer>" device screen
	And on product page all the device have full detail screen
#	And all the SRP are not editable
#	And the QTY for Delivery Cost, Installation Cost and Service Pack are not editable

	Scenarios: 

	| Role             | Country        | ContractType | Contract | Leasing                  | Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Leasing      | 3 years  | 4 Monthly Minimum Volume | 6 Monthly Minimum Volume | DCP-8250DN   |

#
# Enable Printers Scenario 
#
# 8) under consideration
@Ignore
Scenario Outline: asdf
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to the "Product screen" for "<ContractType>" Contract type
	When hogehoge
	Then the printers are not displayed in the Local Office are 

	Scenarios: 

	| Role                   | Country        | ContractType | Contract | Leasing                  | Billing                  | Printer      |
	| Cloud MPS Local Office | United Kingdom | Leasing      | 3 years  | 4 Monthly Minimum Volume | 6 Monthly Minimum Volume | DCP-8250DN   |

# 9-15: under consideration

#
# 4 Installation Cost
#
# 16)

#
# 5 Product-Accessories Relationship
#
# 17) under consideration
@Ignore
Scenario Outline: asd
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
#	Then Accessories displayed for a paticular product must be correct

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

#
# 6 Service Pack
#
# 18)
@Ignored
Scenario Outline: Cannot input Installation Pack Unit Cost less than default
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Installation Pack Unit Cost displayed to a value lower than the displayed Unit Cost
	And I Click Add to Proposal button
	Then InstallationPackUnitCostLessThanError is displayed
	And the product can not be added to the proposal

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

# 19)

@Ignore
Scenario Outline: When input 100% into Margin field, "Add to proposal" button become grayout
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I changed the Margin on any field to 100
	Then Add to proposal button become grayout

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

# 20)
@Ignore
Scenario Outline: When change Unit Price so that Margin is 100, "Add to proposal" button become grayout
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I changed a Unit Price 10 so that Margin is 100
	Then Add to proposal button become grayout

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

#
# 7 Margin Defaults
#
# 21) under construction
@Ignore
Scenario Outline: When login as a dealer, One-time set-up and used by all dealers
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to Dealer Defaults page
	And I can set the default margins for all contracts
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I am on MPS New Proposal Page
	And I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
#	And on product page all the accessories all left with zero QTY
#	And I Add the device to Proposal
	Then all the margin set above should be displayed in the right fields

	Scenarios: 

	| Role1                  | Country        | Role2            | ContractType       | Contract     | Leasing                  |  Billing                 | Printer      |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer | Purchase-and-Click | 3 years      | 4 Monthly Minimum Volume | 6 Monthly Minimum Volume | MFC-L8850CDW |

# 22-23: under consideration

#
# 8 Unit Cost vs Margin% vs Unit Price
#
# 24
@Ignored
Scenario Outline: Change in Unit Cost impacts Unit Price
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Unit Cost of an item
	Then the Unit Price changed accordingly
	And the associated margin does not changed


	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

# 25
@Ignored
Scenario Outline: Change in Unit Price impacts Margin
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Unit Price of an item
	Then the Margin changes accordingly
	And the associated Unit Cost dos not changed

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

#26
@Ignored
Scenario Outline: Change in Margin impacts Unit Price (1)
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Margin of an item whose Unit Cost bigger than zero
	Then the Unit Price changed accordingly
	And the associated Unit Cost dos not changed

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

# 27

Scenario Outline: Change in Margin impacts Unit Price (2)
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Margin of an item whose Unit Cost is equal to zero
	Then the Unit Price and Unit Cost does not change

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |
#
# 9 Filters
#
# 29
@Ignored
Scenario Outline: Fax filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I check Fax checkbox
	Then All printers that have Fax facility are returned

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

# 28-34

#
# 10 Change Display
#
# 35-36