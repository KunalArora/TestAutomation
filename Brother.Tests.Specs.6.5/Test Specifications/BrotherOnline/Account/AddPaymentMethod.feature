@TEST @UAT	
# Card details page flow has been changed to iframe content
Feature: AddPaymentMethod
	In order to purchase items from Brother
	As a customer
	I need to add a new Payment Method

Background:
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


@TEST 
Scenario Outline: Add payment method with new address and visa credit card details
    Then If I go to My Account
	And I can click on Payment Methods
	Then I can add a new payment method
	And If I click on Add New Address
	Then I can add a new billing address details for "<Country>"
	And I see payment details page
	When I fill in valid credit card details for a Visa Credit card 
	 And I fill in creditCard details "<CreditCardNumber>"
	 And I select a month as "<ExpiryMonth>"
	 And I select a year as "<ExpiryYear>"
	 And I fill in security number as  "<CVV>"
	 And I click send to sumbit card details
	Then I should see added credit card details
     And I can sign out of Brother Online

Examples:
| Country                | CreditCardNumber | ExpiryMonth | ExpiryYear | CVV    |
| United Kingdom         | 4006162717519460 |     12      |   2017     |  624   |


@TEST
Scenario Outline: Add payment method with new address and master credit card details
Then If I go to My Account
	And I can click on Payment Methods
	Then I can add a new payment method
	And If I click on Add New Address
	Then I can add a new billing address details for "<Country>"
	And I see payment details page
	When I fill in valid credit card details for a Master Credit card 
     And I fill in creditCard details "<CreditCardNumber>"
	 And I select a master card option
	 And I select a month as "<ExpiryMonth>"
	 And I select a year as "<ExpiryYear>"
	 And I fill in security number as  "<CVV>"
	 And I click send to sumbit card details
	Then I should see added credit card details
     And I can sign out of Brother Online

Examples:
| Country                | CreditCardNumber | ExpiryMonth | ExpiryYear | CVV    |
| United Kingdom         | 5105781454975390 |     12      |   2017     |  132   |
