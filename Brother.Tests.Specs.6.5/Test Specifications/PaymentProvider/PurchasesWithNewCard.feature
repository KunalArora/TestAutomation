@ignoew @SMOKE @TEST @UAT
Feature: Payments made for Online Purchases with newly Add Card
	In order to make Payments
	As an online customer
	I want to be able to add a valid Credit Card to my user account

Scenario: Verify the successful purchase of an order as an unsubscribed/newly registered user
	Given I have navigated to the Brother Main Site "United Kingdom" products pages 
	And I have clicked on Supplies
	And I have entered my valid supplies code for an InkJet cartridge "LC1000BK"
	When I click on search for supply "LC1000BK"
	And I click on Add To Basket
	And I click on Go to Basket
	And I click Checkout before loging
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
	And I press create account button to continue checkout
	And I click Checkout

#Scenario: Verify the successful purchase of an order as a subscribed/existing user but No Cards added
#Scenario: Verify the successful purchase of an order as a subscribed/existing user with an existing Card
#Scenario: Verify the successful purchase of an order as a subscribed/existing user with a new card but user has already got a card
#Scenario: Verify adding valid card to an existing user
#Scenario: Verify adding an expired card to an existing user
#Scenario: Verify adding a valid card but by choosing a different type to an existing user
#Scenario: Verify the error messages are displayed for all the mandetory fields while adding the card
#Scenario: Verify the order details are displayed correctly for a successful payment transaction
#Scenario: Verify the error messages are displayed properly when the payments are not gone through

#Brother Online
#Scenario: Verify the successful purchase of an order after registring as new user
#Scenario: Verify the successful purchase of an order after signing in as an existing user