﻿@TEST
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

@SMOKE
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
	#Then I can complete my product registration by clicking on complete registration button
	Then I can complete my product registration by clicking on complete registration button and I can deregister the "<SerialNumber>"


Scenarios: 
| Country        | Site Url                  | SerialNumber | PurchaseDate | Email                                | FirstName | LastName |
| United Kingdom | /qa/eubol78/serial-number | U1T004768    | 12/12/2013   | 123orderplacedukaccount@mailinator.com | Test      | Test     |


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


@SMOKE
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
	And I click on continue button on address details page
	And I tick on terms and conditions checkbox on Address details Page
	Then I can complete my product registration by clicking on complete registration button on Address Details Page and I can  deregister the "<SerialNumber>"
	

Scenarios: 
| Country        | Site Url                  | SerialNumber | PurchaseDate | PromoCode | Email					      			| FirstName | LastName | Postcode |
| United Kingdom | /qa/eubol78/serial-number | U1T004768	| 12/12/2013   | warrantyup | testemailidinputfield@mailinator.com | Test      | Test     | M345JE   |


@SMOKE
Scenario Outline: Existing Customer wants to register product with their serial numbers, purchase date and promo code
    Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" for existing user signin page
	And I click on existing customer log in option
    Then I enter an email address as "<Valid Email Address>"
    Then I enter valid passowrd for the account "<Valid Password>"
    And I click on SignIn button



Scenarios:
	| Country        | Site Url        | Valid Email Address                       | Valid Password |
	| United Kingdom | /qa/signintest  | 123orderplacedukaccount@mailinator.com	 |  Hello123      |
