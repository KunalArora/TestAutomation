@PROD @UAT @TEST
Feature: CreateNewAccount 
	In order to register myself with brother
	As a customer
	I need to create a new online account

@SMOKE
# Create a new business account
Scenario: Customer creates a new Business account with Brother Online using valid credentials (NO VAT NUMBER), confirm by email
																				sign in and Sign Out
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
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

@SMOKE
# Create a new user account
Scenario: Customer creates a new account with Brother Online using valid credentials, confirm by email
																				sign in and Sign Out
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
	And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

# Create an account and sign in, change registered email address and sign out, try to Register a new account using
# the changed email addrress. It should not be possible

Scenario Outline: Customer cannot register for a Brother Online account using an invalid email address (BOL-180)
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	When I enter an email address containing <Email Address>
	Then I should see an error message
	Then I should refresh the current page to clear all error messages

Scenarios:
	| Email Address                               |
	| "This is a space@guerrillamail.com"         |
	| "CannotUsePercent%@guerrillamail.com"       |
	| "CannotUseCurlyBraces{}@guerrillamail.com"  |
	| "CannotUsePlus+@guerrillamail.com"          |
	| "CannotUseDollar$@guerrillamail.com"        |
	| "CannotUsePound£@guerrillamail.com"         |
	| "CannotUseQuotes"@guerrillamail.com"        |
	| "CannotUseAsterix*@guerrillamail.com"       |
	| "CannotUseTwoAmpersands@@guerrillamail.com" |
	| "CannotUseQuestionMark?@guerrillamail.com"  |
	| "CannotUseOpenBrace(@guerrillamail.com"     |
	| "CannotUseEquals=@guerrillamail.com"        |
	| " LeadingSpace@guerrillamail.com"           |
	| "TrailingSpace@guerrillamail.com "          |

@SMOKE
Scenario Outline: Create an account for Brother Online for different language sites
	Given I Need A Brother Online "<Country>" Account In Order To Use Brother Online Services

Scenarios:
	| Country |
	| France  |
	| Germany |
	| Poland  |
	| Spain   |          

@SMOKE
# Create a new user account and check Add Device so that we know the user registration was successful
Scenario: Customer creates a new account with Brother Online using valid credentials, and validates the user is validated so it can create a device registration but not actually register
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
	And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	When I have clicked on Add Device
	And I am redirected to the Register Device page
	# Note: Invalid serial code will always produce error message
	Given I have entered my Product Serial Code "U1T000000"
	Then I can validate that an error message was displayed
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

@SMOKE
# Create a new Business user account and check Add Device so that we know the user registration was successful
Scenario: Business customer creates a new account with Brother Online using valid credentials, and validates the user is validated so it can create a device registration but not actually register
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

	And I declare that I do use this account for business
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "IT and telecommunications services"
	And I select number of Employees as "11 - 50"
	When I add my company VAT number as "GB145937540" 
	And I have Agreed to the Terms and Conditions
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	When I have clicked on Add Device
	And I am redirected to the Register Device page
	# Note: Invalid serial code will always produce error message
	Given I have entered my Product Serial Code "U1T000000"
	Then I can validate that an error message was displayed
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page


Scenario: Validate that the correct error messages are displayed when a mandatory field is missing while creating a User Account
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	When I press tab in the email address field
	Then I should see an error message

@ignore
Scenario: Validate that the correct error messages are displayed when a mandatory field is incorrect

@ignore
Scenario: Validate that the correct error messages are displayed when passwords do not match

@ignore
Scenario: Validate that the correct error messages are displayed when a password does not comply the required level

@ignore
Scenario: Validate that the correct error messages are displayed when Terms and Conditions are not selected

	


