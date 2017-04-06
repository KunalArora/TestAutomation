@TEST
Feature: As a user I want to create an order on BOL Site and
able to checkout with the existing or guest user

@SMOKE_Checkout
Scenario Outline: Customer creates an order and checkout as existing user on UK BOL site
   	Given That I navigate to "<Site Url>" in order to add a product to validate a published page 
	And I click on Add to Basket 
	And I browse to the "<Url>" BOL checkout page
	#And I click on continue as guest button
	And I click on the login button
	#And I enter "<Email>" in your details
	And I enter the registered "<Email>" in the Email field
	And I enter the registered "<Password>" in the Password field
	And I click on Existing User SiginIn Button
	And I enter "<PhoneNumber>" and "<MobileNumber>" on your details page
	And I click on Continue to Delivery Button
	And I click on Continue to Billing & Payment Button
	And I click on Continue to Payment Button
	When I fill in creditCard details "<CreditCardNumber>"
	And I select a month as "<Month>"
	And I select a year as "<Year>"
	And I fill in security number as  "123"
	And I click the Confirm My Payment button
	Then I should see the order confirmation message
	#And I select title in your details
	#And I enter "<FirstName>"  and "<LastName>" on your details page
	#And I enter "<PhoneNumber>" and "<MobileNumber>" on your details page
	#And I click on Continue to Delivery Button
	#And I can register my "<Postcode>" on the delivery address step
	#And I click on Find Address Button
	#And I enter "<House Number>" on delivery address step
	#And I click on Continue to Billing & Payment Button
	#And I click on Checkbox to use the same delivery address
	#And I click on Continue to Payment As A Guest Button
	#When I fill in creditCard details "<CreditCardNumber>"
	#And I select a month as 07
	#And I select a year as "2018"
	#And I fill in security number as  "123"
	#And I click the Confirm My Payment button
	#Then I should see the order confirmation message
#	When I click on Go to Basket 
#   Then I should see Basket page
#	When I click Checkout on BasketPage
#	Then I should see DeliveryAddress page
#	And I fill in firstname as "<FirstName>"
#	And I fill in lastname as "<LastName>"
#	And I fill in HouseNumber as "<HouseNumber>"
#   And I fill in AddressLine1 as "<AddressLine1>"
#   And I fill in CityTown as "<CityTown>"
#	And I fill in phoneNumber as "<PhoneNumber>"
#	And I Click Save & use address
#   Then I should see the Saved payment details page
#	And I click AddANewDebitCard/CreditCard
#   Then I should see the Saved payment details page
#	And I click on CardAddress Button
#	Then I should see OrderSummary Page
#   And I accept terms and conditions
#   And I click on proceed to payment button
#   Then I should see summary payment page
#	When I fill in creditCard details "<CreditCardNumber>"
#	And I select a month as "<ExpiryMonth>"
#	And I select a year as "<ExpiryYear>"
#	And I fill in security number as  "<CVV>"
#	And I click send to submit card details to see order confirmation	
#	Then I have navigated to the Brother online "<Country>"
#	And I should see welcome back page
#	Then I navigate to my account top menu
#	And I click on orders menu to see created orders
#	Then I should see created orders

 Examples:
 | Site Url                                                          | Url                                                                                | Email                       | Password   | PhoneNumber | MobileNumber | CreditCardNumber | Month | Year |
 | http://main.co.uk.brotherdv2.eu/supplies/inkjet-supplies/lc1000bk | http://atyourside.co.uk.brotherdv2.eu/qa/03-checkout/415existinguserdetailssection | testdv2uk@guerrillamail.com | Brother123 | 01234567890 | 01234567890  | 4259917979151326 | 07    | 2019 |
 
#| Site Url                                                       | Url                                                                                | Email                               | FirstName | LastName | PhoneNumber | MobileNumber | Postcode | House Number | CreditCardNumber |
#| http://main.co.uk.brotherdv2.eu/supplies/laser-supplies/tn2000 | http://atyourside.co.uk.brotherdv2.eu/qa/03-checkout/415existinguserdetailssection | testyourdetailsemail@mailinator.com | Test      | Test     | 01514236589 | 07894540846  | M34 5JE  | 1            | 4259917979151326 |
	 
# Examples:
#| Country             |  | Price    | CountChange | FirstName | LastName | HouseNumber | AddressLine1 | CityTown   | PhoneNumber | CreditCardNumber | ExpiryMonth | ExpiryYear | CVV    |
#| United Kingdom      |      | £25.99   | 1           | Test      | user     | 10          | Tame Street  | Manchester | 1234567890  | 4006162717519460 |     12      |   2017     |  624   |

