@TEST @UAT @PROD
Feature: CreativeCenterTests

# Validate that the creation of a new family creative center test also creates a validated brother online user account
Scenario: Validate that a user can create a family creative center account and that this action automatically creates a brother online account that is already validated (Failing - BBAU-2318)
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
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
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
	Then I have entered my Product Serial Code whilst logged in with a creative center account "U1T000000"
	# Note invalid serial number gives an error howeer seeing this error confirms that the account is validated and enables user to access the register account functionality
	Then I can validate that an error message is displayed due to serial number
	Then I can sign out of Brother Online
	 Then I am redirected to the Brother Home Page

# Validate that the creation of a new business creative center test also creates a validated brother online business account
Scenario: Validate that a user can create a business creative center account and that this action automatically creates a brother online business account that is already validated (Failing - BBAU-2318)
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
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |		
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
	Then If I navigate back to the Brother Online My Account page
	When I clicked on Business Details
	And I am redirected to the Business Details Page
	Then I can see that use account for business is selected
	Then I can navigate back to Brother Online home page
	When I have clicked on Add Device				
	When I am redirected to the Register Device page
	Given I have entered my Product Serial Code "U1T000000"
	# Note invalid serial number gives an error howeer seeing this error confirms that the account is validated and enables user to access the register account functionality
	Then I can validate that an error message is displayed due to serial number
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page


	
		 