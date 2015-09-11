@TEST @UAT @ignore
Feature:BOL - WS - BIT - Test discount ticket - calculation of discounts for single item
As a Brother Supply Club user
I need to add the supply club product to basket and see the club product discounts calculated correctly and displayed in correct order


@TEST  @UAT @ignore
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
	Then I should be able to log into "Italy" Brother Online using my account details
	Given I have navigated to the Brother Main Site "Italy" products pages
	And I have clicked on Supplies
	And I have entered my valid supplies code for an InkJet cartridge "TN2220"
	When I click on search for supply "TN2220"
	When I click on Add to basket button
	And I  click the smart supply basket icon
	And I can see brother supply club benefits checkbox in the basket page
	And I can see the Brother Club discounts offers on basket page
	And I can see the product discount "€ 0,00" before opting in to Brother Supply Club
	And I opt to join Brother Supply Club
	And I can see a positive value in product discount after opting in to Brother Supply Club
	And I can check the sequence of the price labels in the basket page 

	
	  