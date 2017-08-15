@TEST
Feature: As a user I want to create an order on BOL Site and
able to checkout with the existing or guest user

@SMOKE_Checkout
Scenario Outline: Customer creates an order and checkout as existing user on UK BOL site
   	Given That I navigate to "<Site Url>" in order to add a product to validate a published page 
	And I click on Add to Basket 
	And I browse to "<Url>" for existing user signin page atyourside
	#And I browse to the "<Url>" BOL checkout page
	#And I click on continue as guest button
	And I click on the login button
	#And I enter "<Email>" in your details
	And I enter the registered "<Email>" in the Email field
	And I enter the registered "<Password>" in the Password field
	And I click on Existing User SiginIn Button
	And I enter "<PhoneNumber>" and "<MobileNumber>" on your details page
	And I click on Continue to Delivery Button
	And I click on Continue to Billing & Payment Button
	And I select Cash On Delivery radio button for the payment
	And I click on Continue to Payment Button	
	#When I fill in creditCard details "<CreditCardNumber>"
	#And I select a month as "<Month>"
	#And I select a year as "<Year>"
	#And I fill in security number as  "123"
	Then I should see the order confirmation message
#	And I click send to submit card details to see order confirmation	
#	Then I have navigated to the Brother online "<Country>"
#	And I should see welcome back page
#	Then I navigate to my account top menu
#	And I click on orders menu to see created orders
#	Then I should see created orders

 Examples:
 | Site Url																		| Url                                                                                | Email                       | Password   | PhoneNumber | MobileNumber | CreditCardNumber | Month | Year |
 | http://main.co.uk.cds.test.brother.eu.com/supplies/inkjet-supplies/lc1000c	| /checkout| testdv2uk@guerrillamail.com | Brother123 | 01234567890 | 01234567890  | 4259917979151326 | 07    | 2019 |
 
#| Site Url																		| Url                                                                                | Email                               | FirstName | LastName | PhoneNumber | MobileNumber | Postcode | House Number | CreditCardNumber |
#| http://main.co.uk.brotherdv2.eu/supplies/laser-supplies/tn2000				| http://atyourside.co.uk.brotherdv2.eu/qa/03-checkout/415existinguserdetailssection | testyourdetailsemail@mailinator.com | Test      | Test     | 01514236589 | 07894540846  | M34 5JE  | 1            | 4259917979151326 |
	