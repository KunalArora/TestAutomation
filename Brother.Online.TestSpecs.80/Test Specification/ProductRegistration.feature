@SMOKE @TEST
Feature: ProductRegistration
	In order to register a product
	End user will login to existing account or create a new account

@SMOKE
Scenario Outline: Verify the Header and Footer of the landing page
#Given I navigate to "<Country>" in order to validate the landing page
Given I navigate to "<Country>" Brother Online landing page
Then I should see the Header and the Footer appearing on the landing Page
Scenarios:
| Country        |
| United Kingdom |


@SMOKE @TEST
Scenario Outline: New Customer wants to register product with their serial numbers and purchase date
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
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


Scenarios: 
| Country        | Site Url                  | SerialNumber | PurchaseDate | Email                                  | FirstName | LastName |
| United Kingdom | /qa/eubol78/serial-number | U1T004723  | 12/12/2013   | 123orderplacedukaccount@mailinator.com | Test      | Test     |


@ignore
#This is same test but serial numbers are stored in the environment variables and it increements itself by plus one everytime tests run
Scenario Outline: New Customer wants to register product with their serial numbers in the file
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
	And I have entered my product SerialNumber reading from the environmental variable
	And clicked on Find Product Button
	And I have entered "<PurchaseDate>" 
	And I entered apply button
	And I click on continue button on brother product page
	Then I can register my Email on user details page  
	And I enter "<FirstName>"  and "<LastName>" on  user details page
	And I tick on terms and conditions checkbox
	Then I can complete my product registration by clicking on complete registration button

Scenarios: 
| Country        | Site Url                  | PurchaseDate | Email                                | FirstName | LastName |
| United Kingdom | /qa/eubol78/serial-number | 12/12/2013   | testemailidinputfield@mailinator.com | Test      | Test     |


@SMOKE @TEST
Scenario Outline: New Customer wants to register product with their serial numbers, purchase date and promo code
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
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
| Country        | Site Url                  | SerialNumber | PurchaseDate | PromoCode  | Email                                | FirstName | LastName | Postcode | House Number |
| United Kingdom | /qa/eubol78/serial-number | U1T004763    | 12/12/2013   | warrantyup | testemailidinputfield@mailinator.com | Test      | Test     | M345JE   | 1            |


@SMOKE @TEST
Scenario Outline: Existing Customer wants to register product with their serial numbers, purchase date and promo code and also bank details entered for the user
    Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" for existing user signin page
	And I click on existing customer log in option
    Then I enter an email address as "<Valid Email Address>"
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
	And I click on tickbox to confirm I will send my proof of purchase 
	And I click on continue button on address details page
	And I enter "<Account Holder Name>" and "<Sort Code>" and "<Account Number>" on address details page
	And I tick on terms and conditions checkbox on Address details Page
	Then I can complete my product registration by clicking on complete registration button on Address Details Page and I can  deregister the "<SerialNumber>"
	

Scenarios:
	| Country        | Site Url       | Valid Email Address                    | Valid Password | SerialNumber | PromoCode | PurchaseDate | Account Holder Name | Sort Code | Account Number | Postcode | House Number |
	| United Kingdom | /qa/signintest | 123orderplacedukaccount@mailinator.com | Hello123       | U1T004721    | cash50    | 12/12/2013   | Test                | 400699    | 54116897       | M345JE   | 1            |


@SMOKE @TEST
Scenario Outline: Existing Customer wants to register product with their serial numbers, purchase date
    Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" for existing user signin page
	And I click on existing customer log in option
    Then I enter an email address as "<Valid Email Address>"
    Then I enter valid passowrd for the account "<Valid Password>"
    And I click on SignIn button
	And I have entered my product "<SerialNumber>"
	And clicked on Find Product Button
	And I retreive data product id from Product Page
	And I have entered "<PurchaseDate>"
	And I entered apply button
	Then I can complete my product registration by clicking on continue button and I can  deregister the "<SerialNumber>"
	And I can verify registration confirmaiton message is present
	

Scenarios:
	| Country        | Site Url       | Valid Email Address                    | Valid Password | SerialNumber |  PurchaseDate | Account Holder Name | Sort Code | Account Number | Postcode |
	| United Kingdom | /qa/signintest | 123orderplacedukaccount@mailinator.com | Hello123       | U1T004781    |  12/12/2013   | Test                | 400699    | 54116897       | M345JE   |
