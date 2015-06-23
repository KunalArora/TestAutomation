Feature: ProductPurchaseValidation
	In order to prevent incorrect purchase process information
	As an Automated Test
	I want to validate Address Field information

@PROD @UAT @TEST
Scenario Outline: Field Validation for Delivery Address
	Given I am logged into Brother Online <Country> using <Email Address>
	Given I have navigated to the Brother Main Site <Country> products pages
	And I have clicked on Supplies
	And I have entered my valid supplies code for an InkJet cartridge "LC1000BK"
	When I click on search for supply "LC1000BK"
	Then I should see the selected item information page priced at "€25.31" inc vat
	When I click on Add To Basket
	Then I should see the item "LC1000BK" in the Basket
	And I should see the Basket item count change to "1"
	When I click on Basket
	And I click Checkout
	Then I should see the enter Delivery Address details page
	Then I can validate selected "<Fields>" for <Country> with varying valid and invalid data examples from file DeliveryAddressFieldValidation\.xml

Examples:
	| Country          | Email Address                            | Fields                                             |
	| "Ireland"        | "IE_ValidationTesting@guerrillamail.com" | PhoneNumber, FirstName, LastName |
#	| "United Kingdom" | "UK_ValidationTesting@guerrillamail.com" | "PhoneNumber", "FirstName", "LastName", "PostCode" |
#	| "France"         | "FR_ValidationTesting@guerrillamail.com" | "PhoneNumber", "FirstName", "LastName", "PostCode" |
#	| "Netherlands"    | "NL_ValidationTesting@guerrillamail.com" | "PhoneNumber", "FirstName", "LastName", "PostCode" |
#	| "Russia"         | "RU_ValidationTesting@guerrillamail.com" | "PhoneNumber", "FirstName", "LastName", "PostCode" | 

	Then I can clear the Basket
	Then I can navigate back to Brother Online home page
	Then I can sign out of Brother Online

