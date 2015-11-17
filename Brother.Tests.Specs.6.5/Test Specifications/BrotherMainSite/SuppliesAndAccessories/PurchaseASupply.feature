@IGNORE
#Payment method page has been changed.
Feature: PurchaseANewInkCartridge
	In order to continue to use my printer once the ink has run out
	As a user
	I need to purchase a new ink cartridge

#Background: 
#	# Create an account on BOL and sign in
#	Given I am logged onto Brother Online "United Kingdom" using valid credentials

@SMOKE
# Valid Supply code with valid CC details, addresses etc
Scenario: (BBAU-2877) Purchase a new Inkjet Cartridge with a valid supply code and valid credit card details
   Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	#Given I am logged onto Brother Online "Ireland" using valid credentials
	Given I have navigated to the Brother Main Site "Ireland" products pages
	And I have clicked on Supplies
	And I have entered my valid supplies code for an InkJet cartridge "LC1000BK"
	When I click on search for supply "LC1000BK"
	Then I should see the selected item information page priced at "€25.31" inc vat
	When I click on Add To Basket
	Then I should see the item "LC1000BK" in the Basket
	And I should see the Basket item count change to "1"
	When I click on Go to Basket
	Then I should see the item "LC1000BK" in the item list
	And I should see the Basket items count is "1"
	When I click Checkout
	Then I should see the enter Delivery Address details page
	When I enter the delivery details
	| field        | value              |
	| FirstName    | AutoTest           |
	| LastName     | AutoTest           |
	| HouseNumber  | 10			        |
	| HouseName    | AutoTestHouse      |
	| AddressLine1 | 29,Selenium Street |
	| AddressLine2 | PhantomJSVille     |
	| CityTown     | Manchester         |
	| County	   | KILKENNY           |
	| Phone        | 12345678910        |
	
	And I Click Save & use address
	Then I should see the Saved payment details page
	When I click on Add Payment Address
	And I click on Add New Address
	Then I can add billing address details for Country "Ireland"
	Then I should see the Order Summary page
	And I click Place Your Order
	When I enter valid credit card details for a Visa Credit Card
	When I click Send
	Then I should see the Order Confirmation page
	And I can validate I have ordered "1" of "LC1000BK" @ "€25.31"
	And If I click on My Account
	And I can click on Orders
	And I can validate the order "1" of "LC1000BK" @ "€25.31" on My Account page
	And If I sign out of Brother Online
	Then I am redirected to the Brother Home Page
	And I can validate an Order Confirmation email was received

@TEST @UAT
# On DV2 payment method page has been changed.
#Valid Model code with valid CC details, addresses etc
Scenario: (BBAU-2877) - Purchase a new Inkjet Cartridge with a valid device code and valid credit card details 
Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	Then I should be able to log into "United Kingdom" Brother Online using my account details
    #Given I am logged onto Brother Online "Ireland" using valid credentials
	Given I have navigated to the Brother Main Site "Ireland" products pages 
	And I have clicked on Supplies
	And I have entered my valid device code for an InkJet printer "DCP-J715W"
	When I click on search for model "DCP-J715W"
	Then I should see an a list of associated items for model "DCP-J715W"
	And If I click on the item "LC1100BK" 
	Then I should see the selected item information page priced at "€22.53" inc vat 
	When I click on Add To Basket
	Then I should see the item "LC1100BK" in the Basket
	And I should see the Basket item count change to "1"
	When I click on Go to Basket
	Then I should see the item "LC1100BK" in the item list
	And I should see the Basket items count is "1"
	When I click Checkout
	Then I should see the enter Delivery Address details page
	When I enter the delivery details
	| field        | value              |
	| FirstName    | AutoTest           |
	| LastName     | AutoTest           |
	| HouseNumber  | 10			        |
	| HouseName    | AutoTestHouse      |
	| AddressLine1 | 29,Selenium Street |
	| AddressLine2 | PhantomJSVille     |
	| CityTown     | Manchester         |
	| County	   | KILKENNY           |
	| Phone        | 12345678910        |
	
	And I Click Save & use address
	Then I should see the Saved payment details page
	When I click on Add Payment Address
	And I click on Add New Address
	Then I can add billing address details for Country "Ireland"
	Then I should see the Order Summary page
	And I click Place Your Order
	When I enter valid credit card details for a Visa Credit Card
	When I click Send
	Then I should see the Order Confirmation page
	And I can validate I have ordered "1" of "LC1100BK" @ "€22.53"
	And If I click on My Account
	And I can click on Orders
	And I can validate the order "1" of "LC1100BK" @ "€22.53" on My Account page
	And If I sign out of Brother Online
	Then I am redirected to the Brother Home Page
	And I can validate an Order Confirmation email was received

@PROD @SMOKE
## Product Purchase by Product ID - see main BrotherMainSite->SuppliesAndAccessories->PurchaseASupply feature file for TEST and UAT versions
Scenario: Purchase a product by product number on Brother "Ireland" but click Cancel before submitting payment
	Given I am logged onto Brother Online "Ireland" using valid credentials
	Given I have navigated to the Brother Main Site "Ireland" products pages
	And I have clicked on Supplies
	And I have entered my valid supplies code for an InkJet cartridge "LC1000BK"
	When I click on search for supply "LC1000BK"
	Then I should see the selected item information page priced at "€25.31" inc vat
	When I click on Add To Basket
	Then I should see the item "LC1000BK" in the Basket
	And I should see the Basket item count change to "1"
	When I click on Go to Basket
	Then I should see the item "LC1000BK" in the item list
	And I should see the Basket items count is "1"
	When I click Checkout
	Then I should see the enter Delivery Address details page
	When I enter the delivery details
	| field        | value              |
	| FirstName    | AutoTest           |
	| LastName     | AutoTest           |
	| HouseNumber  | 10			        |
	| HouseName    | AutoTestHouse      |
	| AddressLine1 | 29,Selenium Street |
	| AddressLine2 | PhantomJSVille     |
	| CityTown     | Manchester         |
	| County	   | KILKENNY           |
	| Phone        | 12345678910        |
	
	And I Click Save & use address
	Then I should see the Saved payment details page
	When I click on Add Payment Address
	And I click on Add New Address
	Then I can add billing address details for Country "Ireland"
	Then I should see the Order Summary page
	And I click Place Your Order
	When I enter valid credit card details for a Visa Credit Card
	When I click Cancel I should return to the Order Summary page
	Then I can navigate back to Brother Online home page
	Then I can sign out of Brother Online

@UAT @TEST @ignore
# Valid Supply code with valid CC details, addresses etc - For UK site
Scenario Outline: Purchase a new Inkjet Cartridge with valid credit card details
	Given I am logged onto Brother Online "<Country>" using valid credentials
	Given I have navigated to the Brother Main Site "<Country>" products pages
	And I have clicked on Supplies
	And I have entered my valid supplies code for an InkJet cartridge "LC1000BK"
	When I click on search for supply "<SupplyCode>"
	Then I should see the selected item information page
	When I click on Add To Basket
	Then I should see the item "<SupplyCode>" in the Basket
	And I should see the Basket item count change to "1"
	When I click on Go to Basket
	Then I should see the item "<SupplyCode>" in the item list
	And I should see the Basket items count is "1"
	When I click Checkout
	Then I should see the enter Delivery Address details page
	When I enter the delivery address details "<FirstName>", "<LastName>", "<HouseNumber>", "<HouseName>", "<AddrLine1>", "<AddrLine2>", "<CityTown>", "<County>", <PhoneNum>
	And I Click Save & use address
	Then I should see the Saved payment details page
	When I click on Add Payment Address
	And I click on Add New Address
	Then I can add billing address details for Country "<Country>"
	Then I should see the Order Summary page
	And I click Place Your Order
	When I enter valid credit card details for a Visa Credit Card
	When I click Send
	Then I should see the Order Confirmation page
	And I can validate I have ordered "1" of "<SupplyCode>" @ "€25.31"
	And If I click on My Account
	And I can click on Orders
	And I can validate the order "1" of "<SupplyCode>" @ "€25.31" on My Account page
	And If I sign out of Brother Online
	Then I am redirected to the Brother Home Page
	And I can validate an Order Confirmation email was received

Scenarios:
	| Country        | Type     | SupplyCode | FirstName | LastName | HouseNumber | HouseName     | AddrLine1             | AddrLine2             | CityTown   | County   | PhoneNum     |
	| Ireland        | Supplies | LC1000BK   | Otto      | Tiest    | 10          | Testing House | 30, Its a Test Street | Village Of Automation | Manchester | KILKENNY | 012345678910 |
	| United Kingdom | Supplies | LC1000BK   | Otto      | Tiest    | 10          | Testing House | 30, Its a Test Street | Village Of Automation | Manchester |          | 012345678910 |

@ignore
Scenario: Attempt to purchase an ink cartridge by product serial number using invalid credit card credentials
	
@ignore
Scenario: Attempt to purchase an ink cartridge by model code using invalid credit card credentials

@ignore
Scenario: Attempt to purchase an ink cartridge by product serial number using invalid Billing Addresse details

@ignore
Scenario: Attempt to purchase an ink cartridge by product serial number using invalid Delivery Addresse details

@ignore
Scenario: Attempt to purchase an ink cartridge by product serial number which is out of stock

@ignore
Scenario: Attempt to purchase an ink cartridge by an invalid product serial number

@ignore
Scenario: Attempt to purchase an ink cartridge by an invalid Model code number

@ignore
Scenario: Cancel order transaction at Checkout

@ignore
Scenario: Cancel order transaction at Credit Card Details page

@ignore
Scenario: Remove item from Basket and add another item

@ignore
Scenario: Purchase numerous items by Product serial code

@ignore
Scenario: Purchase numerous items by Model code




