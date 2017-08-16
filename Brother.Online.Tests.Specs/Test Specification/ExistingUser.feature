@TEST
Feature: Existing User Forgotten Password
	In order to change maintain by Brother Online Account
	As a customer
	I need to be able to have account management options


@SMOKE_ExistingUserSignIn @TEST
Scenario Outline: Check Forget Password with various invalid scenarios options throws an error for existing user - Validation Checks
	Given I browse to "<Site Url>" for existing user signin page atyourside 
	#And I click on existing customer log in option
	When I click on Forgot Password
	Then I enter an invalid email address as "<Invalid Email Address>"
	Then I should see the Error Message activated and displaying an Error message

Scenarios:
	| Country        | Site Url       | Invalid Email Address                          |
	| United Kingdom | /sign-in | InvalidEmailContaining aspace@mailinator.com   |


@SMOKE_ExistingUserSignIn @TEST
Scenario Outline: Check Forgotten Password email recieved to the user
	Given I browse to "<Site Url>" for existing user signin page atyourside
	When I click on Forgot Password
	Then I enter an email address as "<Valid Email Address>"
	And I press send email button
	And Once I have Validated "<Valid Email Address>" was received and verified my account
	
Scenarios:
	| Country        | Site Url       | Valid Email Address                           |
	| United Kingdom | /sign-in | 123orderplacedukaccount@guerrillamail.com     |