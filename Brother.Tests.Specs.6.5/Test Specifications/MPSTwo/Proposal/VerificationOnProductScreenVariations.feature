@UAT @TEST
Feature: Proposal - Add a devices to a proposal during creation
	In order to create a contract with a device 
	As an MPS Dealer
	I want to create a proposal that has a device

Scenario Outline: Should be able to display full detail screen
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And I display "<Printer>" device screen
	Then on product page all the device have full detail screen
#	And all the SRP are not editable
#	And the QTY for Delivery Cost, Installation Cost and Service Pack are not editable

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

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

@Ignore
Scenario Outline: Total Price calulation is verified
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And enter a quantity value into an accessory field
	Then on product page the Total Price is the product of QTY and Unit Price

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

@Ignore
Scenario Outline: The sum of Total Price is equal to the Grand Total Price
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	Then on product page the sum of the Total Price is equal to the Grand Total Price displayed.

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

@Ignore
Scenario Outline: All Zero QTY fileds are not displayed on summary page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I tick Price Hardware radio button
	And on product page all the accessories all left with zero QTY
	Then all the components of device with zero QTY are not displayed on summary page

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |

@Ignore
Scenario Outline: hoge
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I enter Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms and "<Billing>" billing on Term and Type details
	And I untick Price Hardware radio button
	Then on product page all the devices have reduced detail screen
	And all the SRP fields are ineditable
	And a change in product quantity affect the product TotalPrice

	Scenarios: 

	| Role             | Country        | ContractType       | Contract |  Billing                  | Printer      |
	| Cloud MPS Dealer | United Kingdom | Purchase-and-Click | 3 years  |  6 Monthly Minimum Volume | MFC-L8850CDW |
