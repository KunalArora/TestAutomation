@ignore
Feature: Validate User Role
	In order to utilise the Instant Ink feature
	As a user
	I need to be granted the correct role

Background: 
	# Create an account on BOL and sign in
	Given I am logged onto Brother Online "United Kingdom" using valid credentials

@ignore
Scenario: Validate user has correct role for Instant Ink
	Given I cannot see the Instant Ink menu option from the BOL home page
	Then I can sign out of Brother Online
	And If I grant the user account the "Extranet\Brother Online Ink Supply User" role
	When I sign back into Brother Online "United Kingdom" using the same credentials
	Then I can see the Instant Ink menu option from the BOL home page
	Then I can sign out of Brother Online
	


