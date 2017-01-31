@TEST
Feature: As a user I want to create an order on BOL Site and
able to checkout with the existing or guest user

@SMOKE_Checkout
Scenario Outline: Customer creates an order and checkout as existing user on UK BOL site
   	Given That I navigate to "<Site Url>" in order to add a product to validate a published page 
	And I click on Add to Basket 
	And I browse to the "<Url>" checkout page
	And I click on continue as guest button
	And I enter "<Email>" in your details
	And I select title in your details
	And I enter "<FirstName>"  and "<LastName>" on your details page
	And I enter "<PhoneNumber>" and "<MobileNumber>" on your details page
	And I click on Continue to Delivery Button
	And I can register my "<Postcode>" on the delivery address step
	And I click on Find Address Button
	And I enter "<House Number>" on delivery address step
	And I click on Continue to Billing & Payment Button
#	When I click on Go to Basket 
#    Then I should see Basket page
#	When I click Checkout on BasketPage
#	Then I should see DeliveryAddress page
#	And I fill in firstname as "<FirstName>"
#	And I fill in lastname as "<LastName>"
#	And I fill in HouseNumber as "<HouseNumber>"
#    And I fill in AddressLine1 as "<AddressLine1>"
#    And I fill in CityTown as "<CityTown>"
#	And I fill in phoneNumber as "<PhoneNumber>"
#	And I Click Save & use address
#   Then I should see the Saved payment details page
#	And I click AddANewDebitCard/CreditCard
#    Then I should see the Saved payment details page
#	And I click on CardAddress Button
#	Then I should see OrderSummary Page
#     And I accept terms and conditions
#     And I click on proceed to payment button
#    Then I should see summary payment page
#	 When I fill in creditCard details "<CreditCardNumber>"
#	 And I select a month as "<ExpiryMonth>"
#	 And I select a year as "<ExpiryYear>"
#	 And I fill in security number as  "<CVV>"
#	 And I click send to submit card details to see order confirmation	
#	Then I have navigated to the Brother online "<Country>"
#	 And I should see welcome back page
#	Then I navigate to my account top menu
#	 And I click on orders menu to see created orders
#	#Then I should see created orders
#

 Examples:
| Site Url                                                       | Url                                           | Email                               | FirstName | LastName | PhoneNumber | MobileNumber | Postcode | House Number |
| http://main.co.uk.brotherdv2.eu/supplies/laser-supplies/tn2000 | /QA/03-Checkout/415ExistingUserDetailsSection | testyourdetailsemail@mailinator.com | Test      | Test     | 01514236589 | 07894540846  | M345 JE  | 1            |
	 
# Examples:
#| Country             |  | Price    | CountChange | FirstName | LastName | HouseNumber | AddressLine1 | CityTown   | PhoneNumber | CreditCardNumber | ExpiryMonth | ExpiryYear | CVV    |
#| United Kingdom      |      | £25.99   | 1           | Test      | user     | 10          | Tame Street  | Manchester | 1234567890  | 4006162717519460 |     12      |   2017     |  624   |

