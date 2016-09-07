@TEST
Feature: ProductRegistration
	In order to register a product
	End user will login to existing account or create a new account


@TEST @SMOKE
Scenario Outline: Existing Customer/New Customer redirected to the product details
Given I navigate to "<Site Url>" in order to validate a Product Registration page when I want to create a new account or existing account with Brother Online 
#When I click on Create Account for "<Country>"
#When I sign in using the sign in details created above "<Country>"
#Then I should be able to be redirected to the product details "<Country>"
#And I can sign out of Brother Online "<Country>"
Scenarios:
|Country|			Site Url                                                                                    |
| United Kingdom |  http://atyourside.co.uk.brotherdv2.eu/														|

@ignore
#Validate that an existing user has the option to change their sign in preferences to social login 
Scenario Outline: Customer has the option to change their sign in preferences to social login	
Given I want to create a new account with Brother Online "<Country>"
When I click on Create Account for "<Country>"
And I am redirected to the Brother Login/Register page "<Country>"
And I have Checked No I Do Not Have An Account Checkbox "<Country>"
And I fill in the registration information using a valid email address "<Country>"

|field				|value|
|FirstName			|AutoTest|
|LastName			|AutoTest|
|Password			|@@@@@|
|ConfirmPassword	|@@@@@|

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


