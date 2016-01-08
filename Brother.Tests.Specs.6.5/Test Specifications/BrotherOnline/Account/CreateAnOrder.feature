@TEST
Feature:
As a user I want to register and create an order on BOL Site.
 

@TEST
Scenario Outline: Customer creates an account and places an order on UK BOL site
   Given I launch Brother Online for "<Country>"
    When I click on Create Account for "<Country>"
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
	Given I have navigated to the Brother Main Site "<Country>" products pages 
	And I have clicked on Supplies	
	And I have entered supply code as "<SupplyNumber>"
	Then I should see an a list of associated items for entered supply code	
	When I click on search for supply code as "<SupplyNumber>"
	Then I should see the selected item information page priced at "<Price>" inc vat on basket page
	When I click on Add To Basket 
	Then I should see the item with "<SupplyNumber>" in the Basket
	And I should see the Basket item count change to "<CountChange>"
	When I click on Go to Basket 
    Then I should see Basket page
	When I click Checkout on BasketPage
	Then I should see DeliveryAddress page
	And I fill in firstname as "<FirstName>"
	And I fill in lastname as "<LastName>"
	And I fill in HouseNumber as "<HouseNumber>"
    And I fill in AddressLine1 as "<AddressLine1>"
    And I fill in CityTown as "<CityTown>"
	And I fill in phoneNumber as "<PhoneNumber>"
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
	 And I click send to submit card details to see order confirmation	
	Then I have navigated to the Brother online "<Country>"
	 And I should see welcome back page
	Then I navigate to my account top menu
	 And I click on orders menu to see created orders
	#Then I should see created orders
	 
 Examples:
| Country             | SupplyNumber | Price    | CountChange | FirstName | LastName | HouseNumber | AddressLine1 | CityTown   | PhoneNumber | CreditCardNumber | ExpiryMonth | ExpiryYear | CVV    |
| United Kingdom      | LC1000BK     | £25.99   | 1           | Test      | user     | 10          | Tame Street  | Manchester | 1234567890  | 4006162717519460 |     12      |   2017     |  624   |

@TEST
Scenario Outline: Customer creates an account and places an order on France BOL site
   Given I launch Brother Online for "<Country>"
    When I click on Create Account for "<Country>"
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
	Given I have navigated to the Brother Main Site "<Country>" products pages 
	And I have entered supply code as "<SupplyNumber>" on home page global search 	
	Then I should see a resultlist of associated items for entered supply code number
	And I click on search result
	Then I should see the selected item information page priced at "<Price>" inc vat on basket page
	When I click on AddToBasket button
	Then I should see the item with "<SupplyNumber>" in the Basket
	And I should see the Basket item count change to "<CountChange>"
	When I click on Go to Basket 
    Then I should see Basket page
	When I click Checkout on BasketPage
	Then I should see DeliveryAddress page
	And I fill in firstname as "<FirstName>"
	And I fill in lastname as "<LastName>"
	#And I fill in HouseNumber as "<HouseNumber>"
    And I fill in AddressLine1 as "<AddressLine1>"
    And I fill in Postal code as "<PostalCode>"
	And I fill in CityTown as "<CityTown>"
	And I fill in phoneNumber as "<PhoneNumber>"
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
	 And I click send to submit card details to see order confirmation	
	Then I have navigated to the Brother online "<Country>"
	 And I should see welcome back page
	Then I navigate to my account top menu
	 And I click on orders menu to see created orders
	#Then I should see created orders
	 
 Examples:
| Country | SupplyNumber | Price    | CountChange | FirstName | LastName | AddressLine1 | PostalCode |  CityTown | PhoneNumber | CreditCardNumber  | ExpiryMonth | ExpiryYear | CVV  |
| France  | LC900C       | 6,05 €   | 1           | Test      | user     | asdsadsd     | 75008      |   paris   | 1234567890  | 4006162717519460  |     12      |   2017     |  624 |


