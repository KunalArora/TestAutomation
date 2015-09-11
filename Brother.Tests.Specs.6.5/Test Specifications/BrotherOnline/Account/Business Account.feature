@TEST @UAT @PROD
Feature: Business Account
	In order to change my Brother Online Business account details
	As a Business customer
	I need to be able to have account management options

#Validate that a Business Account holder is able to swap to a Customer Account
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
	And I can navigate back to Brother Online home page
	And I can sign out of Brother Online

# Accounts created on DV2, QAS and Prod for the following test - existingbusinessaccwithorder@guerrillamail.com 
# Validate that a Business Account holder who has made an order is not able to swap to a Customer account
Scenario Outline: Business account holder is unable to switch to a customer account once and order has been placed
	Given I launch Brother Online for "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I enter an email address containing <Email Address>
	When I enter a valid Password <Password>
	And I press sign in with invalid details
	Then I should be able to successfully log into brother online
	When I navigate to my account
	When I clicked on Business Details
	Then An error message is displayed advising user that and account with order cannot be switched
	And I can navigate back to Brother Online home page
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

	Scenarios:
		| Email Address										| Password      |
		| "existingbusinessaccwithorder@guerrillamail.com"	| "Password100" |
		

# Change Business details in your created account, go to my account and change/add your business details
Scenario: Business Customer can change their business details after logging into account
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"
	When I clicked on Business Details
	And I am redirected to the Business Details Page
	And I declare that I do use this account for business on my account page
	And I add my company name as "AutoTestLtd" on Business Details page
	And I add my company VAT number as "GB145937540" on Business Details Page
	And I select my Business Sector as "IT and telecommunications services" on Business Details Page
	And I select number of Employees as "11 - 50" on Business Details Page
	And I click on Update details on business details page
	Then I can verify successfull update message appeared at the top
	Then I can sign out of Brother Online

# Create a new user account - Add business details for new user 
Scenario: Business user creates a new account with Brother Online and add Business details in My account page
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	When I navigate to my account for "United Kingdom"	
	And I clicked on Business Details
	And I am redirected to the Business Details Page
	And I declare that I do use this account for business on my account page
	And I add my company name as "AutoTestLtd" on Business Details page
	And I add my company VAT number as "GB145937540" on Business Details Page
	And I select my Business Sector as "IT and telecommunications services" on Business Details Page
	And I select number of Employees as "11 - 50" on Business Details Page
	And I click on Update details on business details page
	Then I can verify successfull update message appeared at the top
	Then I can sign out of Brother Online


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

# Check mandatory terms and conditions when creating a business account
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
	And I can sign out of Brother Online

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
# Check that existing brother online user and business account holders can still login with a username that has leading/trailing spaces or mixed letter casing
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


# Check maximun username(241) and password(30) length when creating a business account
Scenario: Validate that a business account can be created using the maximun 241 username and 30 password character lengths 																		
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
	Then I should be able to log into ""(.*)"" Brother Online using my max length username and password account details
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

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
	Then I validate the new Business Email changes via email 
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
