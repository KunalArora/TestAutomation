@UAT @TEST
Feature: Proposal - Add a devices to a proposal during creation
	In order to create a contract with a device 
	As an MPS Dealer
	I want to create a proposal that has a device

#
# 1 Screen Variations
#
# 1)
@ignore
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
@ignore
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
@ignore
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
@ignore
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
@ignore
Scenario Outline: All Zero QTY fields are not displayed on summary page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
#	When I fill Proposal Description for "<ContractType>" Contract type
#	And I enter Customer Information Detail for new customer
#	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And on product page all the accessories all left with zero QTY
	And I Add the device to Proposal
#	And I Calculate Click Price
#	Then the selected devices above are displayed on Summary Screen
#	Then all the components of device with zero QTY are not displayed on summary page

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

# 6)
@ignore
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
@ignore
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
@ignore
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
@ignore
Scenario Outline: Change Installation cost type
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change device installation type
	Then installation SRP value should change

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

#
# 5 Product-Accessories Relationship
#
# 17)
# under construction
# blocked until the correct specification is cleared
@ignore
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
@ignore
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

@ignore
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
@ignore
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
# 21
@ignore
Scenario Outline: When login as a dealer, One-time set-up and used by all dealers
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to Dealer Defaults page
	And I can set the default margins for all contracts
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And on product page all the accessories all left with zero QTY
	Then all the margin set above should be displayed in the right fields

	Scenarios: 

	| Role1                  | Country        | Role2            | Printer      |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer | MFC-L8850CDW |

# 22
@ignore
Scenario Outline: Can be set-up as often as possible but used as a one-off margin
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I changed the Margin on any field to 30
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then this change to dealer margin is reverted to the original value

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |
# 23
@ignore
Scenario Outline: One-off set-up by a dealer and used by just the dealer
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Admin page
	And I navigate to Dealer Admin Default Margin page
	And I can change the dealer margin for use of the dealer
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then this change to dealer margin is retained

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

#
# 8 Unit Cost vs Margin% vs Unit Price
#
# 24
@ignore
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
@ignore
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
@ignore
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
@ignore
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
# TODO: Should implement Enabling correct printers as a local office admin.

# 28
@ignore
Scenario Outline: Free Text Filter
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I type in "<Printer>" into the top RHS free-text filter
	Then All printers that contain "<Printer>" is returned

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

# 29
@ignore
Scenario Outline: Fax filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Fax checkbox
	Then All printers that have Fax facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

# 30
@ignore
Scenario Outline: Scanner filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Scanner checkbox
	Then All printers that have Scanner facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

# 31
@ignore
Scenario Outline: Duplex filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Duplex checkbox
	Then All printers that have Duplex facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

#32
@ignore
Scenario Outline: Additional Tray filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Additional Tray checkbox
	Then All printers that have Additional Tray facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

# 33
@ignore
Scenario Outline: A4 filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check A4 checkbox
	Then All printers that have A4 facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

# 34
# Which is A3 model?
@ignore
Scenario Outline: A3 filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check A3 checkbox
	Then All printers that have A3 facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

# 35
@ignore
Scenario Outline: Mono filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Mono checkbox
	Then All printers that have Mono facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

# 36
@ignore
Scenario Outline: Colour filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Colour checkbox
	Then All printers that have Colour facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

# 37
@ignore
Scenario Outline: Fax and Scanner filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Fax and Scanner checkbox
	Then All printers that have Fax and Scanner facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

# 38
@ignore
Scenario Outline: Duplex and Colour filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Duplex and Colour checkbox
	Then All printers that have Duplex and Colour facility are returned

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

#
# 10 Change Display
#
# 39
@ignore
Scenario Outline: verify that Products are displayed according to LO selection (flat list)
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I enable product to be displayed as a flat list for a paticular contract type
	When I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	Then all products are displayed as a flat list with no images

	Scenarios: 

	| Role1                  | Country        | Role2            |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer |

# 40
@ignore
Scenario Outline: verify that Products are displayed according to LO selection (with images)
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And the products are displayed as Flat List
	And I changed the Product view to with images
	Then all products are displayed with images

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |