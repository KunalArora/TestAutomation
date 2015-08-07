@ignore
Feature:BOL - WS - BIT - Test discount ticket - calculation of discounts for single item
As a Brother Supply Club user
I need to add the supply club product to basket and see the club product discounts calculated correctly and displayed in correct order


@ignore
Scenario: View Brother Supply Club product - calculation of discounts for single item on Basket Page
Given I want to create a new account with Brother Online "Italy"
	When I click on Create Account for "Italy"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address and ID number for italy
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	| CodiceFiscale	  |MRTMTT25D09F205Z	|
	
	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	#And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "Italy" Brother Online using my account details
	#And I can sign out of Brother Online
	#Then I am redirected to the Brother Home Page
	Given I have navigated to the Brother Main Site "Italy" products pages
	And I have clicked on Supplies
	And I have entered my valid supplies code for an InkJet cartridge "TN2220"
	When I click on search for supply "TN2220"
	When I click on Add to basket button
	And I  click the smart supply basket icon
	And I can see brother supply club benefits checkbox in the basket page
	
	
	#When I click on Add To Basket
	#Then I should see the item "TN2220" in the Basket
	#And I should see the Basket item count change to "1"
	#When I click on Go to Basket
	#Then I should see the item "TN2220" in the item list
	#And I should see the Basket items count is "1"
	#When I click Checkout  