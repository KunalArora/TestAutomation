@MPS @UAT @TEST
Feature: Proposal - Add a devices to a proposal during creation
	In order to create a contract with a device 
	As an MPS Dealer
	I want to create a proposal that has a device

#
# 1 Screen Variations
#
Scenario Outline: Should be able to display full detail screen
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page all the device have full detail screen
	And all the SRP are not editable
	And the QTY for Delivery Cost, Installation Cost and Service Pack are not editable
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


Scenario Outline: Default value of full detail screen are verified
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page QTY for accessories are default to zero
	And the default total for all accessories are defaulted to zero
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | 3 years  |  Quarterly | MFC-L8850CDW |


Scenario Outline: Total Price calulation is verified
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And enter a quantity value into an accessory field
	Then on product page the Total Price is the product of QTY and Unit Price
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | 3 years  |  Quarterly | MFC-L8850CDW |


Scenario Outline: The sum of Total Price is equal to the Grand Total Price
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page the sum of the Total Price is equal to the Grand Total Price displayed
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | 3 years  |  Quarterly | MFC-L8850CDW |


Scenario Outline: All Zero QTY fields are not displayed on summary page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And on product page all the accessories all left with zero QTY
	And I Add the device to Proposal
	And I enter click price volume of "1000" and "1000"
	Then the selected devices <Printer> above are displayed on Summary Screen
#	Then all the components of device with zero QTY are not displayed on summary page
    And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | 3 years  |  Quarterly | MFC-L8850CDW |

Scenario Outline: All input Margins on prodocut page is displayed on summary page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change all the margin
	And I Add the device to Proposal
	And I enter click price volume of "1000" and "1000"
	Then the entered margins on Product Screen are displayed on Summary Screen
    And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


Scenario Outline: Should be able to display Reduced detail screen
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I untick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page all the devices have reduced detail screen
	And all the SRP are not editable
	And a change in product quantity affect the product TotalPrice
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase & Click with Service | 3 years  |  Quarterly | MFC-L8850CDW |


Scenario Outline: Lease and Click product screen validation
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details(only input)
	Then I should not see Price Hardware radio button on Term and Type screen
	And I display "<Printer>" device screen
	And on product page all the device have full detail screen
	And all the SRP are not editable
	And the QTY for Delivery Cost, Installation Cost and Service Pack are not editable
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | ContractType | Contract | Leasing                  | Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Lease & Click with Service      | 3 years  | Quarterly | Quarterly | DCP-8250DN   |

#
# Enable Printers Scenario 
#
Scenario Outline: Enable Printer of Lease + Click as a Local Office Admin, then can display in Lease + Click Service
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to Lease And Click page
	And I navigate to Printers page on Lease And Click as a Local Office Admin
	And I enabled "<Printer>" within the Printer screen
	And I save printers on Available Printers page
    And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Lease + Click Service
	And I display "<Printer>" device screen
	Then the printers "<Printer>" enabled in Local Office Admin are displayed on product screen
	And I sign out of Cloud MPS

	Scenarios: 
	| Role1                  | Country        | Role2            | Printer     |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer | MFC-J4510DW |

Scenario Outline: Selected printer which is enabled on Lease + Click above can display in Purchase + Click Service
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I am on MPS New Proposal Page
	When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	Then the printers "<Printer>" enabled in Local Office Admin are not displayed on product screen
	And I sign out of Cloud MPS

	Scenarios: 

	| Role1            | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-J4510DW  |

Scenario Outline: Disable Printer of Lease + Click as a Local Office Admin, then can not display in Lease + Click Service
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to Lease And Click page
	And I navigate to Printers page on Lease And Click as a Local Office Admin
	And I disabled "<Printer>" within the Printer screen
	And I save printers on Available Printers page
    And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Lease + Click Service
	Then the printers "<Printer>" disabled in Local Office Admin are not displayed on product screen
    And I sign out of Cloud MPS

	Scenarios: 

	| Role1                  | Country        | Role2            | Printer      |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer | MFC-J4510DW  |


Scenario Outline: Selected printer which is disabled on Lease + Click above can display in Purchase + Click Service
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I am on MPS New Proposal Page
	When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	Then the printers "<Printer>" disabled in Local Office Admin are not displayed on product screen
	And I sign out of Cloud MPS

	Scenarios: 

	| Role1            | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-J4510DW  |

Scenario Outline: Enable Printer of Purchase + Click as a Local Office Admin, then can display in Purchase + Click Service
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to Purchase And Click page
	And I navigate to Printers page on Purchase And Click as a Local Office Admin
	And I enabled "<Printer>" within the Printer screen
	And I save printers on Available Printers page
    And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then the printers "<Printer>" enabled in Local Office Admin are displayed on product screen
	And I sign out of Cloud MPS

	Scenarios: 

	| Role1                  | Country        | Role2            | Printer      |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer | MFC-J4510DW  |


Scenario Outline: Selected printer which is enabled on Purchase + Click above can display in Lease + Click Service
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I am on MPS New Proposal Page
	When I begin the proposal creation process for Lease + Click Service
	And I display "<Printer>" device screen
	Then the printers "<Printer>" enabled in Local Office Admin are displayed on product screen
	And I sign out of Cloud MPS

	Scenarios: 

	| Role1            | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-J4510DW  |


Scenario Outline: Disable Printer as a Local Office Admin, then can display in Purchase + Click Service
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to Purchase And Click page
	And I navigate to Printers page on Purchase And Click as a Local Office Admin
	And I disabled "<Printer>" within the Printer screen
	And I save printers on Available Printers page
    And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	Then the printers "<Printer>" disabled in Local Office Admin are not displayed on product screen
    And I sign out of Cloud MPS

	Scenarios: 

	| Role1                  | Country        | Role2            | Printer      |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer | MFC-J4510DW  |


Scenario Outline: Selected printer which is disabled on Purchase + Click above can not display in Lease + Click Service
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I am on MPS New Proposal Page
	When I begin the proposal creation process for Lease + Click Service
	Then the printers "<Printer>" disabled in Local Office Admin are not displayed on product screen
	And I sign out of Cloud MPS

	Scenarios: 

	| Role1            | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-J4510DW  |

#
# 4 Installation Cost
#
Scenario Outline: Change Installation cost type
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change device installation type
	Then installation SRP value should change
	And I sign out of Cloud MPS

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
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

#
# 6 Service Pack
#
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
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


Scenario Outline: When input 100% into Margin field, "Add to proposal" button become grayout
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I changed the Margin on any field to 100
	Then Add to proposal button become grayout
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


Scenario Outline: When change Unit Price so that Margin is 100, "Add to proposal" button become grayout
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I changed a Unit Price 10 so that Margin is 100
	Then Add to proposal button become grayout
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

#
# 7 Margin Defaults
#
Scenario Outline: As a Local Office Admin, sign-in and enable printer for Purchase + Click Service
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
	And I sign out of Cloud MPS

	Scenarios: 

	| Role1                  | Country        | Role2            | Printer      |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer | MFC-L8850CDW |


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
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


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
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |

#
# 8 Unit Cost vs Margin% vs Unit Price
#
Scenario Outline: Change in Unit Cost impacts Unit Price
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Unit Cost of an item
	Then the Unit Price changed accordingly
	And the associated margin does not changed
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


Scenario Outline: Change in Unit Price impacts Margin
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Unit Price of an item
	Then the Margin changes accordingly
	And the associated Unit Cost dos not changed
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


Scenario Outline: Change in Margin impacts Unit Price (1)
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Margin of an item whose Unit Cost bigger than zero
	Then the Unit Price changed accordingly
	And the associated Unit Cost dos not changed
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


Scenario Outline: Change in Margin impacts Unit Price (2)
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	And I change the Margin of an item whose Unit Cost is equal to zero
	Then the Unit Price and Unit Cost does not change
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |
#
# 9 Filters
#
# TODO: Should implement Enabling correct printers as a local office admin.
Scenario Outline: Free Text Filter
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I type in "<Printer>" into the top RHS free-text filter
	Then All printers that contain "<Printer>" is returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        | Printer      |
	| Cloud MPS Dealer | United Kingdom | MFC-L8850CDW |


Scenario Outline: Fax filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Fax checkbox
	Then All printers that have Fax facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: Scanner filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Scanner checkbox
	Then All printers that have Scanner facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: Duplex filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Duplex checkbox
	Then All printers that have Duplex facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: Additional Tray filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Additional Tray checkbox
	Then All printers that have Additional Tray facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: A4 filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check A4 checkbox
	Then All printers that have A4 facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


# Which is A3 model?
Scenario Outline: A3 filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check A3 checkbox
	Then All printers that have A3 facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: Mono filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Mono checkbox
	Then All printers that have Mono facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: Colour filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Colour checkbox
	Then All printers that have Colour facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: Fax and Scanner filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Fax and Scanner checkbox
	Then All printers that have Fax and Scanner facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: Duplex and Colour filter checkbox 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And I check Duplex and Colour checkbox
	Then All printers that have Duplex and Colour facility are returned
	And I sign out of Cloud MPS

	Scenarios: 

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

#
# 10 Change Display
#

Scenario Outline: verify that Products are displayed according to LO selection (flat list)
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I enable product to be displayed as a flat list for a paticular contract type
	When I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I am on MPS New Proposal Page
	And I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	Then all products are displayed as a flat list with no images
	And I sign out of Cloud MPS

	Scenarios: 

	| Role1                  | Country        | Role2            |
	| Cloud MPS Local Office | United Kingdom | Cloud MPS Dealer |


Scenario Outline: verify that Products are displayed according to LO selection (with images)
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I am on MPS New Proposal Page
    When I begin the proposal creation process for Purchase + Click Service
	And I tick Price Hardware radio button
	And the products are displayed as Flat List
	And I changed the Product view to with images
	Then all products are displayed with images
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I enable product to be displayed with images for a paticular contract type
	And I sign out of Cloud MPS

	Scenarios: 

	| Role1            | Country        | Role2                  |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office |
