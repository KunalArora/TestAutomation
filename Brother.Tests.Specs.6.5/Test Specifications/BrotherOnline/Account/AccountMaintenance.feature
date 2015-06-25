@TEST @UAT @PROD
Feature: Account Maintenance
	In order to change maintain by Brother Online Account
	As a customer
	I need to be able to have account management maintenance options

Scenario Outline: Check Forget Password with various invalid scenarios options (BOL-177, BBAU-2339)
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I click on Forgot Password
	Then I enter an invalid email address as <Invalid Email Address>
	Then I should see the Error Message activated and displaying an Error message
	And I can navigate to the Brother Online Home Page "<Country>"

Scenarios:
	| Country        | Invalid Email Address                                                                                                                                                                                                              |
	| United Kingdom | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                     |
	| United Kingdom | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                   |
	| United Kingdom | "InvalidEmailForUser"                                                                                                                                                                                                              |
#	| United Kingdom | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed@mailinator.com" |
	| France         | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                     |
	| France         | "InvalidEmailForUser"                                                                                                                                                                                                              |
	| France         | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                   |
#	| France         | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed@mailinator.com" |
	| Germany        | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                     |
	| Germany        | "InvalidEmailForUser"                                                                                                                                                                                                              |
	| Germany        | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                   |
#	| Germany        | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed@mailinator.com" |
	| Netherlands    | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                     |
	| Netherlands    | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                   |
	| Netherlands    | "InvalidEmailForUser"                                                                                                                                                                                                              |
#	| Netherlands    | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed@mailinator.com" |
	| Spain          | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                     |
	| Spain          | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                   |
	| Spain          | "InvalidEmailForUser"                                                                                                                                                                                                              |
#	| Spain          | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed@mailinator.com" |
