@PROD @UAT @TEST
Feature: Customer Account
	In order to register myself with brother
	As a customer
	I need to create a new online account

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
Scenario: Customer has created a Brother Online account and wishes to change their password
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
Scenario: Customer or Dealer role persists after email address change 
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

@Ignore
# Set this test to ignore as it was causing problems with the cookie test due to BOL login not signing out (Sign out step commented out for some reason)
# Create an account and sign in, change registered email address and sign out, re-sign in again using new address
# @TEST @UAT @PROD 
Scenario Outline: Customer can change their Brother Online email address after registration 
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
Scenario: Customer cannot update the personal details if mandatory fields are left blank
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

#Validate that a user can edit an existing address
Scenario Outline: Customer can edit their entered address details
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
	And I click on Edit link
	And I edit the "<House Number>"
	And I click on the save address button
	Then I can navigate back to Brother Online home page
	And I can sign out of Brother Online

Scenarios: 
| House Number    |
| appt 12         |


@SMOKE
# Create a new user account
Scenario: Customer creates a new account with Brother Online using valid credentials, confirm by email 																				sign in and Sign Out
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

Scenario Outline: Customer cannot register for a Brother Online account using an invalid email address 
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
	# | "  LeadingSpace@guerrillamail.com"        | these are valid email id's, it will trim the space in the front and at the back.
	# | "TrailingSpace@guerrillamail.com     "      |
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
 Scenario Outline: Validate that the correct error messages are displayed when a Confirm Password field contains different password than actual Password 
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
	And I can sign out of Brother Online

# Check maximun username(241) and password(30) length when creating a user account
Scenario: Validate that a user account can be created using the maximun 241 username and 30 password character lengths 																			
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
	Then I should be able to log into ""(.*)"" Brother Online using my max length username and password account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

# Validate that a user is able to accept the cookie information on first visit to brother online to prevent it from being displayed again
Scenario: Validate that a user can view cookie information on first visit to brother online and once accepted does not see it again
	Given I launch Brother Online for "United Kingdom"
	Then I delete all page cookies
	Then I refresh the current page
	Then I can see and click the accept cookies button
	And I refresh the current page
	Then I can no longer see the accept cookies button

# Validate that a user always sees the cookie information bar on subsequent visits to the site unless the information is accepted
Scenario: Validate that a user of Brother online will always see cookie information on subsequent visits to the site if cookies are not accepted
	Given I launch Brother Online for "United Kingdom"
	Then I delete all page cookies
	And I refresh the current page
	Then I can see the cookies information bar
	And I refresh the current page again
	Then I continue to see the cookies information bar

# Validate that a user can click to find out more information about the cookie privacy policy and then go on to view company terms and conditions
Scenario: Validate that a user of Brother online can view the cookie privacy policy and terms and conditions information prior to accepting cookies
	Given I launch Brother Online for "United Kingdom"
	Then I delete all page cookies
	And I refresh the current page
	Then I can see the cookies information bar
	And I can see and click the find out more button on the cookies information bar
	Then I am navigated to the privacy policy for cookies
	And I click to view the company terms and conditions
	Then I am navigated to the company terms and conditions page

@ignore
Scenario: Log in as a Printer On dealer and ensure that they can see the required permissions BBAU-2189
# (ensure that a customer cannot see the same permissions)
	
@ignore
Scenario: Create a user but test for BPID 
	# Create a new user account but add a check for the Users BPID in the dbo.Users table


@TEST @UAT @PROD 
# Create an account for Brother Online for different language sites
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on multi lingual sites																				sign in and Sign Out
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
	And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country  |	
| United Kingdom    |
| Ireland           |
| Denmark		    |
| Portugal		    |
| Finland		    |
# | Slovenia			|
# | Slovakia 		|
| Belgium  			|
| Netherlands		|
# | Poland			|



@TEST @UAT @PROD 
# Create an account for Brother Online for spain sites
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Spain site																			sign in and Sign Out
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address and ID number
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	| NumeroDNI		  | 00000023T	   |
	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country |
|Spain	  | 

@TEST @UAT @PROD 
# Create an account for Brother Online for spain sites
Scenario Outline: Customer creates a new account with Brother Online using valid credentials, confirm by email on Italy site																			sign in and Sign Out
	Given I want to create a new account with Brother Online "<Country>"
	When I click on Create Account for "<Country>"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address and ID number for italy
	| field           | value           |
	| FirstName       | AutoTest        |
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	| CodiceFiscale	  |MRTMTT25D09F205Z	|
	
	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	And Once I have Validated an Email was received and verified my account
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page
Scenarios: 
| Country |
| Italy   |


