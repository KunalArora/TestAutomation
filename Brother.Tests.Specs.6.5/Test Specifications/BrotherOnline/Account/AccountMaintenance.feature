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

#(BBAU-3095) aka (SBAU-189)
#Change Personal details in your created account, go to my account and add your new Email address
Scenario Outline: Customer create a new account and amend their personal details by going into my account page
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

    And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	When I navigate to my account for "United Kingdom"
	And I enter First Name containing <FirstName>
	And I enter the Last Name containing <LastName>
	And I click on update details
	Then my personal details should get updated
	Then I can navigate back to Brother Online home page
	And I can sign out of Brother Online

Scenarios: 
	| FirstName						| LastName							|
	| Test			                | Test				                |

@ignore @SMOKE
Scenario Outline: Customer gets valid error message on BOL Norway site with invalid tax code
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	And I fill in the registration information using a valid email address 
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "<Business Sector>"
	# And I enter my Business Sector as "<Business Sector>"
	And I select number of Employees as "11 - 50"
	And I enter an invalid VAT Number as "<VAT Number>"
	And I have Agreed to the Terms and Conditions 
	When I press Create Your Account
	Then I should see an error message due to an invalid tax code 

Scenarios:
| Country		| Business Sector		| VAT Number       |
| Norway		| Industri				| INVALIDVATNUMBER |


Scenario Outline: Customer create a new B2C account and closes that account on signin details page
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

    And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	Then I should be able to log into "<Country>" Brother Online using my account details
	When I navigate to my account for "<Country>"
	And I click on Sign In Details
	And I click close account
	And I select "<Reason for cancellation>"
	And I click closeaccount button
	Then I should see email sent message	
	Then I can navigate back to Brother Online home page
	And I can sign out of Brother Online

Scenarios: 
| Country       | Reason for cancellation |
| United Kingdom| Other                   | 
