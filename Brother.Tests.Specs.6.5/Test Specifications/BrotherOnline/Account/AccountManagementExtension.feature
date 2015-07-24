@TEST @UAT @PROD
Feature: Account Management Test Extension
	In order to change my Brother Online account details
	As a customer
	I need to be able to have account management options


# Validate that a Business Account holder is able to swap to a Customer Account
Scenario: Create a business account change the business account to be Customer Account
Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "IT and telecommunications services"
	And I select number of Employees as "11 - 50"
	And I have Agreed to the Terms and Conditions
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	When I navigate to my account for "United Kingdom"
	When I clicked on Business Details
	And I declare that I do not use this account for business on my account page
	And I click on Update details on business details page
	Then I can verify successfull update message appeared at the top

# Validate that the correct error messages are displayed when address details mandatory fields are not completed
Scenario: Customer get the correct error messages when address details mandatory fields are not completed on my address page
Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"	
	When I click on My Address 
	And I click on Add a New Address Button 
	And I enter tab on the first name field
	Then I should see an error message on the first name field on my address page
	And I enter tab on last name field
	Then I should see an error message on Last name field on my address page
	And I enter tab on postcode field
	Then I should see an error message on postcode field on my address page
	And I enter tab on House number 
	Then I should an error message on house number field on my address page
	And I enter tab on address line one
	Then I should see an error message on Address Line one field on my address page
	And I enter tab on City/Town field
	Then I should see an error message on City/town field on my address page
	And I enter tab on Phone number field
	Then I should see an error message on phone number field on my address page

# Validate that an existing user has the option to change their sign in preferences to social login 
Scenario: Customer has the option to change their sign in preferences to social login
Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"	
	And I click on Sign In Details
	When I click on Social Login Radio button
	Then I should be able to see social login buttons
	


 