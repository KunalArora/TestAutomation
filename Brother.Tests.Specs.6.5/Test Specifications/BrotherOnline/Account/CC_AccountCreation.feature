@TEST @UAT @PROD
Feature: Creative Center Tests

@IGNORE
# Validate that the creation of a new family creative center test also creates a validated brother online user account
Scenario: Validate that a user can create a family creative center account and that this action automatically creates a brother online account that is already validated (In Progress)
	Given I launch Brother Online for "United Kingdom"
	Then I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	And I click the family center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	And I click the creative center register/login link
	When I fill in the registration information using a valid email address
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	And I declare that I do not use this account for business
	And I have Agreed to the Terms and Conditions
	Then I click the creative center create your account button
	Then I am logged into creative center
	Given I launch Brother Online for "United Kingdom"
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	When I have clicked on Add Device
	And I am redirected to the Register Device page
	Given I have entered my Product Serial Code "U1T000000"
	Then I can validate that an error message was displayed
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

	@IGNORE
# Validate that the creation of a new family creative center test also creates a validated brother online user account
Scenario: Validate that a user can create a business creative center account and that this action automatically creates a brother online account that is already validated (In Progress)
	Given I launch Brother Online for "United Kingdom"
	Then I navigate to and click the creative center link
	Then I am taken to the creative center landing page
	And I click the family center link
	Then I am taken to the creative center home page
	And I click to not participate in the survey
	And I click the creative center register/login link
	When I fill in the registration information using a valid email address
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	And I declare that I do use this account for business
	And I add my company name as "AutoTestLtd"
	And I select my Business Sector as "IT and telecommunications services"
	And I select number of Employees as "11 - 50"
	And I have Agreed to the Terms and Conditions
	Then I click the creative center create your account button
	Then I am logged into creative center
	Given I launch Brother Online for "United Kingdom"
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	When I have clicked on Add Device
	And I am redirected to the Register Device page
	Given I have entered my Product Serial Code "U1T000000"
	Then I can validate that an error message was displayed
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

	
		 