@TEST @UAT
Feature: Account Management
	In order to change my Brother Online account details
	As a customer
	I need to be able to have account management options

Background: 
	Given I am logged onto Brother Online "United Kingdom" using valid credentials

# Sign into Brother Online and change password
@TEST @UAT @PROD
Scenario: Customer has created a Brother Online account and wishes to change their password (BOL-164)
	Given I am logged into my Brother Online account
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
	Given I am logged into my Brother Online account
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
@TEST @UAT
Scenario: Customer or Dealer role persists after email address change (BOL-176)
	Given I am logged into my Brother Online account
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
	And If I validate the new changes via email
	Then I can validate the update was successful
	And I can sign out of Brother Online
	Then If I sign back into Brother Online "United Kingdom" using the same credentials
	And I can see the Instant Ink menu option from the BOL home page
	Then I can sign out of Brother Online

# Create an account and sign in, change registered email address and sign out, re-sign in again using new address
@TEST @UAT @PROD
Scenario: Customer can change their Brother Online UK email address after registration 
	Given I am logged into my Brother Online account
	When I navigate to my account for "United Kingdom"
	And I click on Sign In Details
	And If I enter a new email address "changed"
	And If I enter the current password for email change
	And I click on Update details
	Then I can verify the email change occurred
	When I validate the new changes via email
	And I can sign out of Brother Online
	Then If I sign back into Brother Online "United Kingdom" using the same credentials
	When I navigate to my account for "United Kingdom"
	And I click on Sign In Details
	Then I can validate the update was successful
	Then I can sign out of Brother Online

# Create an account and sign in, change registered email address and sign out, re-sign in again using new address
@TEST @UAT @PROD @ignore
Scenario: Customer can change their Brother Online Ireland email address after registration 
	Given I am logged into my Brother Online account
	When I navigate to my account for "Ireland"
	And I click on Sign In Details
	And If I enter a new email address "changed"
	And If I enter the current password for email change
	And I click on Update details
	Then I can verify the email change occurred
	And If I validate the new changes via email
	Then I can validate the update was successful
	And I can sign out of Brother Online
	Then If I sign back into Brother Online "Ireland" using the same credentials
	Then I can sign out of Brother Online

@ignore
# Change Business details in your created account, go to my account and change/add your business details
Scenario: Customer can change their business details after logging into account
	Given I am logged into my Brother Online account
	When I navigate to my account for "United Kingdom"
	When I clicked on Business Details
	And I redirected to the Business Details Page
	And I declare that I do use this account for business on my account page
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "IT and telecommunications services"
	And I select number of Employees as "11 - 50"
	And I add my company VAT number as "GB145937540" 
	#When I press update button
	#Then I can verify successfull update message appeared at the top
	

	# resetting a password

	# change email

	# changing address

	# create account for different countries

	# changing business details





