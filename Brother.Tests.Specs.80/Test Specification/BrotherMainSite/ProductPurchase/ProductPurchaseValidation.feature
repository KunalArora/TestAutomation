@TEST
Feature: ProductPurchaseValidation
	In order to poceed through the checkout process
	As a brother online user
	I want to be able to purchase a product through online

@SMOKE-ProductPurchaseValidation
Scenario Outline: Verify that a user can successfully purchase an item through brother online using a credit card
	Given I have navigated to the "<Country>" Brother Main Site
	And I have clicked on Supplies option
	When I select an InkJet cartridge by searching with a valid supplies code "<ItemCode>"
	And I click on Add To Basket button
	And I click on Go to Basket button
	And I click Checkout before loging
	And I am redirected to the Brother Login/Register page
	And I enter an email address containing "<Email Address>"
	And I enter a valid Password "<Password>" into the Password field
	And I click on the signin button to checkout purchase orders
	Then I should see DeliveryAddress page
	When I Choose to deliver to the existing address
	Then I should see the Saved payment details page
	When I click AddANewDebitCard/CreditCard
    #Then I should see the Saved payment details page
	When I click on CardAddress Button
	Then I should see OrderSummary Page
	When I accept terms and conditions
	And I click on proceed to payment button
    #Then I should see summary payment page
	And I fill in creditCard details "<CreditCardNumber>"
	And I select a month as "<ExpiryMonth>"
	And I select a year as "<ExpiryYear>"
	And I fill in security number as  "<CVV>"
	And I click send to submit card details to see order confirmation
	Then I should see the Order Confirmation message along with the order number
Scenarios:
	| Country        | ItemCode | Email Address               | Password   | CreditCardNumber | ExpiryMonth | ExpiryYear | CVV    |
	| United Kingdom | LC1000BK | testdv2uk@guerrillamail.com | Brother123 | 4259917979151326 |     12      |   2018     |  123   |