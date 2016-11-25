#@TEST
@ignore
Feature: ProductPurchaseValidation
	In order to poceed through the checkout process
	As a brother online user
	I want to be able to purchase a product through online

#@SMOKE
Scenario Outline: Verify that a user can successful purchase of an item through brother online using a credit card
	Given I have navigated to the "<Country>" Brother Main Site
	And I have clicked on Supplies option
	And I have entered my valid supplies code for an InkJet cartridge "<Product>"
	When I click on search for supply "LC1000BK"
	And I click on Add To Basket
	And I click on Go to Basket
	And I click Checkout before loging
	And I am redirected to the Brother Login/Register page
	
Scenarios:
	| Country        | Product  |
	| United Kingdom | LC1000BK |