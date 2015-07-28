@TEST @UAT
Feature: My Account - Customer
	In order to change my Brother Online account details
	As a customer
	I need to be able to have account management options

@TEST @UAT @PROD
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
	And I can navigate back to Brother Online home page
	And I can sign out of Brother Online

# Sign into Brother Online and change password
@TEST @UAT @PROD
Scenario: Customer has created a Brother Online account and wishes to change their password (BOL-164)
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"
	And I click on Sign In Details
	Then If I enter the current password
	And I enter a new password of "ChangedPassword123"
	When I click on Update Password
	Then My password will be updated 
	Then If I sign out of Brother Online
	And If I sign back into Brother Online "United Kingdom" using the same credentials
	Then I can sign out of Brother Online

# Create an account and use the "Forgotten Password" utility
@TEST @UAT @PROD
Scenario: Customer has created a Brother Online account but has forgotten their password and requires a new one
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	#Given I am logged into my Brother Online account
	Then I can sign out of Brother Online
	When I click on Create Account for "United Kingdom"
	And I click on Forgot Password
	Then I enter my current email address
	And I click on Reset Your Password
	Then If I Click the Reset Password Email Link
	And I reset my password with "ChangedPassword123"
	When I click on Reset Your Password
	And I am redirected to the Brother Login/Register page
	Then I can sign back into Brother Online "United Kingdom" using the updated credentials
	Then I can sign out of Brother Online

# Create account, sign in, note missing menu option, add role to user, sign out and in again, note menu option present
# Instant Ink role used as a baseline
# ***-need to add additional scenario (see ticket number for steps) or ValidateRole Feature test
@TEST @UAT
Scenario: Customer or Dealer role persists after email address change (BOL-176)
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	Then I can sign out of Brother Online
	And If I grant the user account the "Extranet\Brother Online Ink Supply User" role
	When I sign back into Brother Online "United Kingdom" using the same credentials
	Then I can see the Instant Ink menu option from the BOL home page
	When I navigate to my account for "United Kingdom"
	And I click on Sign In Details
	And If I enter a new email address "changed"
	And If I enter the current password for email change
	And I click on Update details
	Then I can verify the email change occurred
	Then I validate the new Business Email changes via email 
	Then I can validate the update was successful
	And I can sign out of Brother Online
	Then If I sign back into Brother Online "United Kingdom" using the same credentials
	And I can see the Instant Ink menu option from the BOL home page
	Then I can sign out of Brother Online

# Create an account and sign in, change registered email address and sign out, re-sign in again using new address
@TEST @UAT @PROD 
Scenario Outline: Customer can change their Brother Online email address after registration (BBAU - 2337)
	Given I am logged onto Brother Online "<Country>" using valid credentials
	When I navigate to my account for "<Country>"
	And I click on Sign In Details
	And If I enter a new email address "<EmailPrefixForChange>"
	And If I enter the current password for email change
	And I click on Update details
	Then I can verify the email change occurred
	When I validate the new Customer Email changes via email
	And I can sign out of Brother Online
	Then If I sign back into Brother Online "<Country>" using the same credentials
	When I navigate to my account for "<Country>"
	And I click on Sign In Details
	Then I can validate the update was successful
	Then I can sign out of Brother Online

Scenarios:
	| Country        | EmailPrefixForChange |
	| United Kingdom | changed              |
	| Ireland        | changed              |

@TEST @UAT @PROD 
# Validate that an existing user has the option to change their sign in preferences to social login 
Scenario: Customer has the option to change their sign in preferences to social login
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"	
	And I click on Sign In Details
	When I click on Social Login Radio button
	Then I should be able to see social login buttons
	And I can navigate back to Brother Online home page
	And I can sign out of Brother Online

@TEST @UAT @PROD 
# Validate that the correct error messages are displayed when business details mandatory fields are not completed
Scenario: : Customer get the correct error message when business details mandator fields are not completed
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"	
	And I clicked on Business Details
	And I am redirected to the Business Details Page
	And I declare that I do use this account for business on my account page
	And I click on Update details on business details page
	Then I get the error message displayed on your company name field
	And I get the error message displayed on Business sector field
	And I can navigate back to Brother Online home page
	And I can sign out of Brother Online

@TEST @UAT @PROD 
#Validate that a user with a Customer Account can amend their personal details
Scenario: Customer cannot updatethe personal details if mandatory fields are left blank
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"
	And I clear the first name field
	Then error message should appear on the first name field
	And I clear the last name field
	Then error mesage should appear on the last name field
	And I can navigate back to Brother Online home page
	And I can sign out of Brother Online

@TEST @UAT @PROD
#User can add their address to their account by manually entering their personal details
Scenario: Customer can add a new address to their account by manually entering address details
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"	
	When I click on My Address 
	And I click on Add a New Address Button
	And I enter all the mandatory fields
		| field           | value          |
		| FirstName       | AutoTest       |
		| LastName        | AutoTest       |
		| Postcode        | m34 5je	       |
		| HouseNumber	  | appt 1		   |
		| HouseName		  | Brother		   |
		| Addressline1	  | TameSt		   |
		| Addressline2	  | Audenshaw	   |
		| City			  | Manchester	   |
		| PhoneNumber	  | 0161 330 6531	   |
	And I click on the save address button
	Then I can navigate back to Brother Online home page
	And I can sign out of Brother Online


