@TEST @UAT @PROD
Feature: Account Maintenance
	In order to change maintain by Brother Online Account
	As a customer
	I need to be able to have account management maintenance options

Scenario Outline: Check Forget Password with various invalid scenarios options 
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I click on Forgot Password
	Then I enter an invalid email address as <Invalid Email Address>
	Then I should see the Error Message activated and displaying an Error message
	And I can navigate to the Brother Online Home Page "<Country>"

Scenarios:
	| Country        | Invalid Email Address                                                                                                                                                                                                                                              |
	| United Kingdom | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                                                     |
	| United Kingdom | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                                                   |
	| United Kingdom | "InvalidEmailForUser"                                                                                                                                                                                                                                              |
	| United Kingdom | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com" |
	| France         | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                                                     |
	| France         | "InvalidEmailForUser"                                                                                                                                                                                                                                              |
	| France         | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                                                   |
	| France         | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com" |
	| Germany        | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                                                     |
	| Germany        | "InvalidEmailForUser"                                                                                                                                                                                                                                              |
	| Germany        | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                                                   |
	| Germany        | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com" |
	| Netherlands    | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                                                     |
	| Netherlands    | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                                                   |
	| Netherlands    | "InvalidEmailForUser"                                                                                                                                                                                                                                              |
	| Netherlands    | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com" |
	| Spain          | "InvalidEmailContaining aspace@mailinator.com"                                                                                                                                                                                                                     |
	| Spain          | "InvalidEmailForUser@mailinator"                                                                                                                                                                                                                                   |
	| Spain          | "InvalidEmailForUser"                                                                                                                                                                                                                                              |
	| Spain          | "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com" |

#Change Personal details in your created account, go to my account and add your new Email address
Scenario Outline: Customer create a new account and amend their personal details by going into my account page
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"
	And I enter First Name containing <FirstName>
	And I enter the Last Name containing <LastName>
	And I click on update details
	Then my personal details should get updated
	Then I can navigate back to Brother Online home page
	And I can sign out of Brother Online

Scenarios: 
	| FirstName						|LastName							|
	| Test						    |Test								|