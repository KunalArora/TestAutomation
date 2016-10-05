@TEST
Feature: ProductRegistration
	In order to register a product
	End user will login to existing account or create a new account

@TEST @SMOKE
Scenario Outline: Verify the Header and Footer of the landing page
#Given I navigate to "<Country>" in order to validate the landing page
Given I navigate to "<Country>" Brother Online landing page
Then I should see the Header and the Footer appearing on the landing Page
Scenarios:
| Country        |
| United Kingdom |

@TEST @SMOKE
Scenario Outline: Customer wants to register product with their serial numbers and promo code
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
	And I have entered my product "<SerialNumber>"
	And clicked on Find Product Button
	And I have entered "<PurchaseDate>" 
	And I entered apply button
	And I click on continue button
	Then I can register my "<Email>" on  user details page  

Scenarios: 
| Country        | Site Url                                          | SerialNumber | PurchaseDate | Email									|
| United Kingdom | /QA/AutomationPleaseDoNotTouch/ProductRegStep-one | U1T004750    | 12/12/2013   | testemailidinputfield@mailinator.com   |

@ignore
#Validate that an existing user has the option to change their sign in preferences to social login 
Scenario Outline: Customer has the option to change their sign in preferences to social login	
Given I want to create a new account with Brother Online "<Country>"
When I click on Create Account for "<Country>"
And I am redirected to the Brother Login/Register page "<Country>"
And I have Checked No I Do Not Have An Account Checkbox "<Country>"
And I fill in the registration information using a valid email address "<Country>"

| field           | value    |
| FirstName       | AutoTest |
| LastName        | AutoTest |
| Password        | @@@@@    |
| ConfirmPassword | @@@@@    |

And I have Agreed to the Terms and Conditions "<Country>"
And I declare that I do not use this account for business "<Country>"
When I press Create Your Account "<Country>"
Then I should see my account confirmation page "<Country>"
And When I Click Go Back "<Country>"
Then I should be able to log into "<Country>" Brother Online using my account details
When I navigate to my account for "<Country>"
And I click on Sign In Details "<Country>"
When I click on Social Login Radio button "<Country>"
Then I should be able to see social login buttons "<Country>"
And I can navigate back to Brother Online home page "<Country>"
And I can sign out of Brother Online "<Country>"
Scenarios:
| Country        |
| United Kingdom |