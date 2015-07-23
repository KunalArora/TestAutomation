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

@IGNORE
# Create a new user account - NEED TO ADD SCENARIOS for emails with Leading and Trailing spaces
Scenario: Customer creates a new account with Brother Online using valid credentials specified, confirm by email
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

Scenario Outline: Customer cannot register for a Brother Online account using an invalid email address (BOL-180, BBAU-316)
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
	| "specialcharactersüñîçøðé@guerrillamail.com"|
	#| "  LeadingSpace@guerrillamail.com"        | these are valid email id's, it will trim the space in the front and at the back.
	#| "TrailingSpace@guerrillamail.com     "      |
	# simply trim them. No error message is displayed

@SMOKE @ignore
Scenario Outline: Create an account for Brother Online for different language sites
	Given I Need A Brother Online "<Country>" Account In Order To Use Brother Online Services
	When I have clicked on Add Device
	And I am redirected to the Register Device page
	# Note: Invalid serial code will always produce error message
	Given I have entered my Product Serial Code "U1T000000"
	Then I can validate that an error message was displayed
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

Scenarios:
	| Country        |
	| Romania        | 
	| France         |
	| Germany        |
	| Netherlands    |
	| Spain          |
	| Denmark        |
	| Belgium        |
#	| Russia         |- Red warning on page - look into
#	| Hungary        |- unknown error - possibly cannot get to site 
	| Portugal       |
#	| Switzerland    | - need to add specific default language to URL
#	| Slovakia       | - Links for validation set of for UK so needs updating
#	| Slovenia       | - Links for validation set of for UK so needs updating
#	| Czech          | - Links for validation set of for UK so needs updating
#	| Bulgaria       | - Links for validation set of for UK so needs updating - maybe no version in SiteCore on DV2
	| Finland        |
#	| Norway         | - Link for validation of registration links to something completely different
#	| Italy          | - NEEDS to have Número de identificación fiscal added to test otherwise registration fails
	| Austria        |


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


Scenario: Validate that the correct error messages are displayed when a mandatory field Email is missing while creating a User Account
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	When I press tab in the email address field
	Then I should see an error message


Scenario Outline: Validate that the correct error messages are displayed when a mandatory field Password is missing while creating a User Account
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I enter an email address containing <Email Address>
	When I press tab in the password field
	Then I should see an error message on the password field
Scenarios:
	| Email Address                     |
	| "aaa@yahoo.com"					|

@ignore
 Scenario Outline: Validate that the correct error messages are displayed when a Confirm Password field contains different password than actual Password (BBAU-2209)
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I enter an email address containing <Email Address>
	And I enter the password containing <Password>
	When I enter the different password in the confirm password field containing <Confirm Password> and press tab
	Then I should see an error message on the Confirm password field
Scenarios:
	| Email Address                 |Password							 |Confirm Password			|
	| "aaa@yahoo.com"				|"Astwer1234"						 |"aaaahewllo"				|
	

Scenario Outline:Validate that the correct error messages are displayed when a password does not comply the required level 
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I enter an email address containing <Email Address>
	When I enter the password containing <Password>
	Then I should see an error message on the password field
Scenarios:
	| Email Address                 |Password						 |
	| "aaa@yahoo.com"				|"stwer"						 |


Scenario: Validate that the correct error messages are displayed when Terms and Conditions are not selected
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

	When I declare that I do not use this account for business
	And I press create account button
	Then I should get an error message displayed on the Terms and Conditions


# Check mandatory email/password/first name/ last name/company name/business sector fields when creating business account
Scenario: Validate that an error message is displayed for all mandatory fields during creation of a business account
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I declare that I do use this account for business
	When I press tab in the email address field
	Then I should see an error message
	When I press tab in the password field
	Then I should see an error message on the password field
	When I press tab in the first name field
	Then I should see an error message on the first name field
	When I press tab in the last name field
	Then I should see an error message on the last name field
	When I press tab in the company name field
	Then I should see an error message on the company name field
	When I press tab in the business sector field
	Then I should see an error message on the business sector field

# Check mandatory terms and conditions are accepted when creating a business account
Scenario: Validate that an error message is displayed for mandatory terms and conditions if they are not accepted during creation of a business account
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
	And I press create account button
	Then I should get an error message displayed on the Terms and Conditions

# Accounts created on DV2, QAS and Prod for the following test - existinguseraccount@guerrillamail.com/existingbusinessaccount@guerrillamail.com/Password100
# Check that a user account cannot be created with an email address that already exists for another user account 
# Check that a user account cannot be created with an email address that already exists for another business account
Scenario Outline: Customer cannot register for a new user account using an email address that already exists for another user or business account
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information excluding email address
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	
	And I declare that I do not use this account for business
	And I have Agreed to the Terms and Conditions
	And I enter an email address containing <Email Address>
	And I press create account button
	Then I should see the duplicate email error message preventing account creation

Scenarios:
	| Email Address                               |
	| "existinguseraccount@guerrillamail.com"         |
	| "existingbusinessaccount@guerrillamail.com"       |

# Accounts created on DV2, QAS and Prod for the following test - existinguseraccount@guerrillamail.com/existingbusinessaccount@guerrillamail.com/Password100
# Check that a business account cannot be created with an email address that already exists for another business account
# Check that a business account cannot be created with an email address that already exists for another user account
Scenario Outline: Customer cannot register for a new business account using an email address that already exists for another business or user account
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information excluding email address
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
	And I enter an email address containing <Email Address>
	And I press create account button
	Then I should see the duplicate email error message preventing account creation	

Scenarios:
	| Email Address                               |
	| "existingbusinessaccount@guerrillamail.com"         |
	| "existinguseraccount@guerrillamail.com"       |

# Check that a user account which is not validated does not have the ability to register a device
Scenario: User account which is not validated does not permit device registration
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
	When I have clicked on Add Device
	Then I should see the account not validated error message preventing device registration

# Check that a business account which is not validated does not have the ability to register a device		
Scenario: Business account which is not validated does not permit device registration
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
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	When I have clicked on Add Device
	Then I should see the account not validated error message preventing device registration

# Accounts created on DV2, QAS and Prod for the following test - existinguseraccount@guerrillamail.com/existingbusinessaccount@guerrillamail.com/Password100
# Check that existing brother online user and business account holders cannot login with valid/invalid username/password combinations
Scenario Outline: Validate that user or business account holders are unable to login to brother online with invalid credentials
Given I launch Brother Online for "United Kingdom"
When I click on Create Account for "United Kingdom"
And I am redirected to the Brother Login/Register page
And I enter an email address containing <Email Address>
When I enter a valid Password <Password>
And I press sign in with invalid details
Then I should see the invalid credentials error message preventing login to brother online

Scenarios:
	| Email Address                                 | Password                 |
	| "existinguseraccount@guerrillamail.com"       | "InvalidPasswordEntered" |
	| "existingbusinessaccount@guerrillamail.wrong" | "Password100"            |
	| "existinguseraccount@guerrillamail.com"       | "PaSsWoRd100"			   |
	| "existingbusinessaccount@guerrillamail.com"	| "   Password100   "      |
	| "existinguseraccount@guerrillamail.com"       | "Pass  word  100"	       |
	 		
# Accounts created on DV2, QAS and Prod for the following test - existinguseraccount@guerrillamail.com/existingbusinessaccount@guerrillamail.com/Password100
# Check that existing brother online user and business account holders can still login with a username that leading/trailing spaces or mixed letter casing
Scenario Outline: Validate that user or business account holders can still login to brother online with spaces or different case in the username providing the password is correct
Given I launch Brother Online for "United Kingdom"
When I click on Create Account for "United Kingdom"
And I am redirected to the Brother Login/Register page
And I enter an email address containing <Email Address>
When I enter a valid Password <Password>
And I press sign in with invalid details
Then I should be able to successfully log into brother online
And I can sign out of Brother Online
Then I am redirected to the Brother Home Page

Scenarios:
	| Email Address											| Password      |
	| "     existinguseraccount@guerrillamail.com    "		| "Password100" |
	| "ExIsTiNgBuSiNeSsAcCoUnT@gUeRrIlLaMaIl.CoM"			| "Password100" |



# Check maximun username(241) and password(30) length when creating a user account
Scenario: Validate that a user account can be created using the maximun 241 username and 30 password character lengths (Failing due to BBAU-2522)																				
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a maximum length email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | Max30CharacterPasswooooooooord |
	| ConfirmPassword | Max30CharacterPasswooooooooord |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

# Check maximun username(241) and password(30) length when creating a business account
Scenario: Validate that a business account can be created using the maximun 241 username and 30 password character lengths (Failing due to BBAU-2522)																				
	Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a maximum length email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | Max30CharacterPasswooooooooord |
	| ConfirmPassword | Max30CharacterPasswooooooooord |

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
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

@ignore
Scenario: Log in as a Printer On dealer and ensure that they can see the required permissions BBAU-2189
# (ensure that a customer cannot see the same permissions)


# Change Personal details in your created account, go to my account and add your new Email address
Scenario: Business Customer can change their Email Address   (BBAU - 2377, 2355)
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
	And I click on Sign In Details
	And If I enter a new email address "changed"
	And If I enter the current password for email change
	And I click on Update details
	Then I can verify the email change occurred
	And If I validate the new changes via email
	Then I can validate the update was successful
	And I can sign out of Brother Online
	Then If I sign back into Brother Online "United Kingdom" using the same credentials

#Change Sign In details in your created account, go to my account and change/add your new password
Scenario: Business Customer can reset their password 
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
	And I click on Sign In Details
	Then If I enter the current password
	And I enter a new password of "ChangedPassword123"
	When I click on Update Password
	Then My password will be updated 
	Then If I sign out of Brother Online
	And If I sign back into Brother Online "United Kingdom" using the same credentials
	Then I can sign out of Brother Online
	



	
@ignore
Scenario: Create a user but test for BPID 
	# Create a new user account but add a check for the Users BPID in the dbo.Users table
