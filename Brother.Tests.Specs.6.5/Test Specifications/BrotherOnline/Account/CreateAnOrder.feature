@TEST @UAT
Feature:
As a user I want to register and create an order on BOL Site.
 

@TEST @UAT
Scenario Outline: Customer creates an account and places an order on UK BOL site
   Given I launch Brother Online for "United Kingdom"
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
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	Given I have navigated to the Brother Main Site "United Kingdom" products pages 
	And I have clicked on Supplies
	And I have entered supply code "LC1000BK"
	Then I should see an a list of associated items for entered supply code
	When I click on search for"LC1000BK"
	Then I should see the selected item information page priced at "£25.99" inc vat on basket page
	When I click on Add To Basket 
	Then I should see the item "LC1000BK" in the Basket
	And I should see the Basket item count change to "1"
	When I click on Go to Basket 
    Then I should see Basket page
	When I click Checkout on BasketPage
	Then I should see DeliveryAddress page
	And I fill in firstname as "Test"
	And I fill in LastName as "user"
	And I fill in HouseNumber as "10"
	And I fill in AddressLine1 as " Tame Street "
	And I fill in CityTown as "Manchester"
	And I fill in PhoneNumber as "1234567890"
	And I Click Save & use address
   Then I should see the Saved payment details page
	And I click AddANewDebitCard/CreditCard
    Then I should see the Saved payment details page
	And I click on CardAddress Button
	Then I should see OrderSummary Page
     And I accept terms and conditions
     And I click on proceed to payment button
    Then I should see summary payment page
	 When I fill in creditCard details "<CreditCardNumber>"
	 And I select a month as "<ExpiryMonth>"
	 And I select a year as "<ExpiryYear>"
	 And I fill in security number as  "<CVV>"
	 And I click send to sumbit card details to see order confirmation	
	#Then I should see order confirmation page
	# When If I click on My Account
	# When I navigate to my account
	# And I clicked on orders menu
	# Then I should see created orders
	 
 Examples:
| CreditCardNumber | ExpiryMonth | ExpiryYear | CVV    |
| 4006162717519460 |     12      |   2017     |  624   |


