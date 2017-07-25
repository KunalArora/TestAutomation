@SMOKE_ProductRegistration @TEST
Feature: ProductRegistration
	In order to register a product
	End user will login to existing account or create a new account

@TEST
Scenario Outline: Verify the Header and Footer of the landing page
#Given I navigate to "<Country>" in order to validate the landing page
Given I navigate to "<Country>" Brother Online landing page
Then I should see the Header and the Footer appearing on the landing Page
Scenarios:
| Country        |
| United Kingdom |


@TEST
Scenario Outline: New Customer wants to register product with their serial numbers and purchase date
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
	And I deregister the serial number using the "<ProdId>" on Product Registration page
	And I have entered my product "<SerialNumber>"
	And clicked on Find Product Button
	And I retreive data product id from Product Page 
	And I have entered "<PurchaseDate>" 
	And I entered apply button
	And I click on continue button on brother product page
	Then I can register my Email on user details page 
	And I enter "<FirstName>"  and "<LastName>" on  user details page
	And I tick on terms and conditions checkbox
	Then I can complete my product registration by clicking on complete registration button and I can deregister the "<SerialNumber>"
	#And Once I have Validated "<Email>" was received and verified my account for Product Registration Email
	
Scenarios: 
| Country        | Site Url                  | SerialNumber | PurchaseDate | Email                                  | FirstName | LastName |ProdId  |
| United Kingdom | /qa/eubol78/serial-number | U1T004731    | 12/12/2013   | testemailidinputfield@guerrillamail.com| Test      | Test     |c3beeb53-d80a-1a4c-e100-0000ac1b10d3 |

@SMOKE_ProductRegistration @TEST
Scenario Outline: New Customer wants to register product with their serial numbers, purchase date and promo code
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
	And I deregister the serial number using the "<ProdId>" on Product Registration page
	And I have entered my product "<SerialNumber>"
	And clicked on Find Product Button
	And I retreive data product id from Product Page 
	And I have entered "<PurchaseDate>"
	And I entered apply button
	And I enter "<PromoCode>" 
	And I click on add code button
	And I click on continue button on brother product page
	Then I can register my Email on user details page  
	And I enter "<FirstName>"  and "<LastName>" on  user details page
	And I click on continue button on user details page
	And I can register my "<Postcode>" on the address details page
	And I click on Find Address Button
	And I enter "<House Number>" on address page
	And I click on continue button on address details page
	And I tick on terms and conditions checkbox on Address details Page
	Then I can complete my product registration by clicking on complete registration button on Address Details Page and I can  deregister the "<SerialNumber>"
	
Scenarios: 
| Country        | Site Url                  | SerialNumber | PurchaseDate | PromoCode  | Email                                | FirstName | LastName | Postcode | House Number |ProdId |
| United Kingdom | /qa/eubol78/serial-number | U1T004731    | 12/12/2013   | warrantyup | testemailidinputfield@mailinator.com | Test      | Test     | M345JE   | 1            |c3beeb53-d80a-1a4c-e100-0000ac1b10d3 |

@SMOKE_ProductRegistration @TEST
Scenario Outline: Existing Customer wants to register product with their serial numbers, purchase date and promo code and also bank details entered for the user
    Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" for existing user signin page
	And I deregister the serial number using the "<ProdId>"
	And I click on existing customer log in option
    Then I enter an email address as "<Valid Email Address>" on existing customer page
    Then I enter valid passowrd for the account "<Valid Password>"
    And I click on SignIn button
	And I have entered my product "<SerialNumber>"
	And clicked on Find Product Button
	And I retreive data product id from Product Page
	And I have entered "<PurchaseDate>"
	And I entered apply button
	And I enter "<PromoCode>" 
	And I click on add code button
	And I click on continue button on brother product page to go to address details page
	And I can register my "<Postcode>" on the address details page
	And I click on Find Address Button
	And I enter "<House Number>" on address page
	#And I click on tickbox to confirm I will send my proof of purchase
	And I click on continue button on address details page
	And I enter "<Account Holder Name>" and "<Sort Code>" and "<Account Number>" on address details page
	And I tick on terms and conditions checkbox on Address details Page
	Then I can complete my product registration by clicking on complete registration button on Address Details Page and I can  deregister the "<SerialNumber>"
	#And I can verify registration confirmaiton message is present

Scenarios:
	| Country        | Site Url       | Valid Email Address                    | Valid Password | SerialNumber | PromoCode | PurchaseDate | Account Holder Name | Sort Code | Account Number | Postcode | House Number |ProdId |
	| United Kingdom | /qa/signintest | 123orderplacedukaccount@mailinator.com | Hello123       | U1T004731   | cash50    | 12/12/2013   | Test                | 400699    | 54116897       | M345JE   | 1            |c3beeb53-d80a-1a4c-e100-0000ac1b10d3 |


@SMOKE_ProductRegistration @TEST
Scenario Outline: Existing Customer wants to register product with their serial numbers, purchase date
    Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" for existing user signin page
	And I deregister the serial number using the "<ProdId>"
	And I click on existing customer log in option
    Then I enter an email address as "<Valid Email Address>" on existing customer page
    Then I enter valid passowrd for the account "<Valid Password>"
    And I click on SignIn button
	And I have entered my product "<SerialNumber>"
	And clicked on Find Product Button
	And I retreive data product id from Product Page
	And I have entered "<PurchaseDate>"
	And I entered apply button
	Then I can complete my product registration by clicking on continue button and I can  deregister the "<SerialNumber>"
	#And I can verify registration confirmaiton message is present
	
Scenarios:
	| Country        | Site Url       | Valid Email Address                    | Valid Password | SerialNumber |  PurchaseDate | Account Holder Name | Sort Code | Account Number | Postcode |ProdId |
	| United Kingdom | /qa/signintest | 123orderplacedukaccount@mailinator.com | Hello123       | U1T004731   |  12/12/2013   | Test                | 400699    | 54116897       | M345JE   |c3beeb53-d80a-1a4c-e100-0000ac1b10d3 |


@SMOKE_ProductRegistration @TEST
Scenario Outline: Deregister Serial Numbers using prod id
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
	And I deregister the serial number using the "<ProdId>" on Product Registration page

Scenarios:
	| Country        | Site Url       | ProdId                               |
	| United Kingdom | /qa/signintest | c3beeb53-d80a-1a4c-e100-0000ac1b10d3 |
	| United Kingdom | /qa/signintest | 1c43ec57-5cda-db34-e100-0000ac1b10d3 |
	| United Kingdom | /qa/signintest | 7343ec57-5cda-db34-e100-0000ac1b10d3 |
	| United Kingdom | /qa/signintest | c243ec57-5cda-db34-e100-0000ac1b10d3 |
	| United Kingdom | /qa/signintest | 1144ec57-5cda-db34-e100-0000ac1b10d3 |
	| United Kingdom | /qa/signintest | 6044ec57-5cda-db34-e100-0000ac1b10d3 |
	| United Kingdom | /qa/signintest | af44ec57-5cda-db34-e100-0000ac1b10d3 |
	| United Kingdom | /qa/signintest | A1D1EC57-45DA-D234-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | A5EEEC57-0DDB-5637-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | 07EEEC57-0DDB-5637-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | AAB7EC57-E4BA-7B5D-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | E1ECEC57-0DDB-5537-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | EFACEC57-ABDA-FC35-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | 02ACEC57-ABDA-FC35-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | 35FDEC57-13D7-662B-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | AAFBEC57-13D7-662B-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | 0CFBEC57-13D7-662B-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | B4A80058-9890-A70F-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | D0380058-F3BC-7F0C-E100-0000AC1B10D3 |
	| United Kingdom | /qa/signintest | 81380058-F3BC-7F0C-E100-0000AC1B10D3 |