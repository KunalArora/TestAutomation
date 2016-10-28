@TEST 
Feature: Existing User
	In order to change maintain by Brother Online Account
	As a customer
	I need to be able to have account management options

@SMOKE @TEST
Scenario Outline: Check Forget Password with various invalid scenarios options throws an error for existing user - Validation Checks
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" for existing user signin page
	And I click on existing customer log in option
	When I click on Forgot Password
	Then I enter an invalid email address as "<Invalid Email Address>"
	Then I should see the Error Message activated and displaying an Error message


Scenarios:
	| Country        | Site Url       | Invalid Email Address                          |
	| United Kingdom | /qa/signintest | "InvalidEmailContaining aspace@mailinator.com" |

@SMOKE @TEST
Scenario Outline: Check Forgotten Password email recieved to the user
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" for existing user signin page
	And I click on existing customer log in option
	When I click on Forgot Password
	Then I enter an email address as "<Valid Email Address>"
	And Once I have Validated an Email was received and verified my account
	Then I should see the Error Message activated and displaying an Error message


Scenarios:
	| Country        | Site Url       | Valid Email Address                          |
	| United Kingdom | /qa/signintest | "InvalidEmailContaining aspace@mailinator.com" |
