@TEST @UAT @PROD
Feature: CreativeCenterTests

# Validate that the creation of a new family creative center account also creates a validated brother online user account
Scenario: (Failing on Prod - BBAU-2575) Validate that a user can create a family creative center account and that this action automatically creates a brother online account that is already validated
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	And I click the family center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	# Then I click to remove browser confirmation dialogue
	Then I am navigated to the creative center login page			
	Then I have checked no to having a creative center account
	And I fill in the creative center registration information using a valid email address
	| field           | value			|
	| FirstName       | CcFamilyAutoTest|
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	Then I declare that I do not use this creative center account for business
	And I have Agreed to the creative center Terms and Conditions
	Then I click the creative center create your account button
	Then I am logged into creative center
	Then I sign out of creative center	
	Given I launch Brother Online for "United Kingdom"
	Then I click on the sign in / create account button
	Then I should be able to log into ""(.*)"" Brother Online using my creative center account details
	When I have clicked on add device whilst logged in with the creative center account
	And I am redirected to the Register device page with the creative center login
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

# Validate that the creation of a new business creative center account also creates a validated brother online business account
Scenario: (Failing on Prod - BBAU-2575) Validate that a user can create a business creative center account and that this action automatically creates a brother online business account that is already validated
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	Then I click the business center link
	Then I am taken to the creative center home page
	Then I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page			
	Then I have checked no to having a creative center account	
	And I declare that I do use this creative center account for business
	And I fill in the creative center registration information using a valid email address
	| field           | value			  |
	| FirstName       | CcBusinessAutoTest|
	| LastName        | AutoTest		  |
	| Password        | @@@@@			  |
	| ConfirmPassword | @@@@@		      |		
	And I add my company name into creative center as "AutoTestLtd"
	And I select my Business Sector on creative center as "IT and telecommunications services"		
	And I select number of Employees on creative center as "11 - 50"
	Then I have Agreed to the creative center Terms and Conditions
	Then I click the creative center create your account button
	Then I am logged into creative center
	Then I sign out of creative center		
	Given I launch Brother Online for "United Kingdom"
	Then I click on the sign in / create account button	
	Then I should be able to log into ""(.*)"" Brother Online using my creative center account details		
	When I navigate to my account using creative center details
	When I clicked on Business Details
	When I am redirected to the Business Details Page
	Then I can see that use account for business is selected
	Then If I navigate back to the Brother Online My Account page
	When I have clicked on Add Device				
	When I am redirected to the Register Device page
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

 # Check mandatory email/password/first name/ last name/ fields when creating a creative center family account
 Scenario: (Failing on Prod - BBAU-2575) Validate that an error message is displayed for all mandatory fields during creation of a creative center family account
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	And I click the family center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page			
	Then I have checked no to having a creative center account
	When I press tab in the creative center password field
	Then I should see an error message on the creative center password field
	When I press tab in the creative center email address field
	Then I should see an error message on the creative center email field
	When I press tab in the creative center first name field
	Then I should see an error message on the creative center first name field
	When I press tab in the creative center last name field
	Then I should see an error message on the creative center last name field

 # Check mandatory email/password/first name/ last name/company name/business sector fields when creating a creative center business account
Scenario: (Failing on Prod - BBAU-2575) Validate that an error message is displayed for all mandatory fields during creation of a creative center business account
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	Then I click the business center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page			
	Then I have checked no to having a creative center account
	And I declare that I do use this creative center account for business
	When I press tab in the creative center password field
	Then I should see an error message on the creative center password field
	When I press tab in the creative center email address field
	Then I should see an error message on the creative center email field
	When I press tab in the creative center first name field
	Then I should see an error message on the creative center first name field
	When I press tab in the creative center last name field
	Then I should see an error message on the creative center last name field
	When I press tab in the creative center company name field
	Then I should see an error message on the creative center company name field
	When I press tab in the creative center business sector field
	Then I should see an error message on the creative center business sector field
		 

# Validate that the creation of a new family creative center account requires the terms and conditions to be accepted
Scenario: (Failing on Prod - BBAU-2575) Validate that a user cannot create a family creative center account unless terms and conditions are accepted
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	And I click the family center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page			
	Then I have checked no to having a creative center account
	And I fill in the creative center registration information using a valid email address
	| field           | value			|
	| FirstName       | CcFamilyAutoTest|
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	Then I declare that I do not use this creative center account for business
	Then I click the creative center create your account button
	Then I should get an error message displayed on the creative center Terms and Conditions

# Validate that the creation of a new business creative center account requires the terms and conditions to be accepted
Scenario: (Failing on Prod - BBAU-2575) Validate that a user cannot create a business creative center account unless terms and conditions are accepted
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	And I click the family center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page			
	Then I have checked no to having a creative center account
	Then I declare that I do use this creative center account for business
	And I fill in the creative center registration information using a valid email address
	| field           | value			|
	| FirstName       | CcFamilyAutoTest|
	| LastName        | AutoTest		|
	| Password        | @@@@@			|
	| ConfirmPassword | @@@@@			|
	And I add my company name into creative center as "AutoTestLtd"
	And I select my Business Sector on creative center as "IT and telecommunications services"		
	And I select number of Employees on creative center as "11 - 50"
	Then I click the creative center create your account button
	Then I should get an error message displayed on the creative center Terms and Conditions


# Accounts created on DV2, QAS and Prod for the following test - existinguseraccount@guerrillamail.com/existingbusinessaccount@guerrillamail.com/Password100
# Check that existing creative center family and business account holders cannot login with valid/invalid username/password combinations
Scenario Outline: (Failing on Prod - BBAU-2575) Validate that family or business account holders are unable to login to creative center with invalid credentials
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	Then I click the business center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page	
	When I enter a creative center email address containing <Email Address>
	When I enter a valid Password for creative center <Password>
	And I press the creative center sign in with invalid details
	Then I should see the invalid credentials error message preventing login to creative center

	Scenarios:
		| Email Address                                 | Password                 |
		| "existinguseraccount@guerrillamail.com"       | "InvalidPasswordEntered" |
		| "existingbusinessaccount@guerrillamail.wrong" | "Password100"            |
		| "existinguseraccount@guerrillamail.com"       | "PaSsWoRd100"			   |
		| "existingbusinessaccount@guerrillamail.com"	| "   Password100   "      |
		| "existinguseraccount@guerrillamail.com"       | "Pass  word  100"	       |


# Accounts created on DV2, QAS and Prod for the following test - existinguseraccount@guerrillamail.com/existingbusinessaccount@guerrillamail.com/Password100
# Check that existing family and business account holders can still login with a username that has leading/trailing spaces or mixed letter casing
Scenario Outline: (Failing on Prod - BBAU-2575) (Failing BBAU-2601) Validate that family or business account holders can still login to creative center with spaces or different case in the username providing the password is correct
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	Then I click the business center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page
	When I enter a creative center email address containing <Email Address>
	When I enter a valid Password for creative center <Password>
	And I press the creative center sign in
	Then I click the business center link
	Then I am logged into creative center
	Then I sign out of creative center	

	Scenarios:
		| Email Address											| Password      |
		| "ExIsTiNgBuSiNeSsAcCoUnT@gUeRrIlLaMaIl.CoM"			| "Password100" |
		| "     existinguseraccount@guerrillamail.com    "		| "Password100" |


# Check creative center password and confirm password fields need to match
Scenario Outline: (Failing on Prod - BBAU-2575) Validate that an error message is displayed on creative center if the password and create password fields do not match
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	Then I click the business center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page
	And I have checked no to having a creative center account
	When I enter a new Password for creative center <Password>
	When I enter the different password in the creative center confirm password field containing <Confirm Password> and press tab
	Then I should get an error message displayed on the creative center confirm password field

	Scenarios:
		| Email Address                               | Password      | Confirm Password |
		| "existingbusinessaccount@guerillamail.com"  | "Password100" | "Password200"	 |

# Customer cannot register for a creative center account using an invalid email format	
Scenario Outline: Customer cannot register for creative center account with invalid email formats
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	Then I click the business center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page
	When I enter a creative center email address containing <Email Address>
	And I press the creative center sign in
	Then I should see an error message on the creative center email field
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

# Customer cannot register for a family creative center account using a duplicate email address 
Scenario Outline: Customer cannot register for a new family creative center account using an email address that already exists for another brother online user or business account				
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	And I click the family center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page			
	Then I have checked no to having a creative center account
	When I fill in the creative center registration information excluding email address
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	When I enter a creative center email address containing <Email Address>
	Then I declare that I do not use this creative center account for business
	And I have Agreed to the creative center Terms and Conditions
	Then I click the creative center create your account button
	Then I should see the creative center duplicate email error message preventing account creation

Scenarios:
	| Email Address                               |
	| "existinguseraccount@guerrillamail.com"     |
	| "existingbusinessaccount@guerrillamail.com" |


# Customer cannot register for a business creative center account using a duplicate email address 
Scenario Outline: Customer cannot register for a new business creative center account using an email address that already exists for another brother online business or user account				
	Given I launch Brother Online for "United Kingdom"
	When I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	And I click the business center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	Then I click the creative center register/login link
	Then I am navigated to the creative center login page			
	Then I have checked no to having a creative center account
	And I declare that I do use this creative center account for business
	When I fill in the creative center registration information excluding email address
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	Then I add my company name into creative center as "AutoTestLtd"
	And I select my Business Sector on creative center as "IT and telecommunications services"		
	And I select number of Employees on creative center as "11 - 50"
	When I enter a creative center email address containing <Email Address>
	Then I have Agreed to the creative center Terms and Conditions
	Then I click the creative center create your account button
	Then I should see the creative center duplicate email error message preventing account creation

Scenarios:
	| Email Address                               |
	| "existinguseraccount@guerrillamail.com"     |
	| "existingbusinessaccount@guerrillamail.com" |