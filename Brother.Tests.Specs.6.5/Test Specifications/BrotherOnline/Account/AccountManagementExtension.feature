﻿@TEST @UAT
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