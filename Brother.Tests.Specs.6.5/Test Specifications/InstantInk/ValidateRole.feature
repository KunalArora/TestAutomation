@TEST @UAT
Feature: Validate User Role
	In order to utilise the Instant Ink feature
	As a user
	I need to be granted the correct role

Background: 
	# Create an account on BOL and sign in
	Given I am logged onto Brother Online "United Kingdom" using valid credentials

# Note : This scenario needs to be updated to reflect the additional steps below
Scenario: Validate user has correct role for Instant Ink
	Given I cannot see the Instant Ink menu option from the BOL home page
	Then I can sign out of Brother Online
	And If I grant the user account the "Extranet\Brother Online Ink Supply User" role
	When I sign back into Brother Online "United Kingdom" using the same credentials
	Then I can see the Instant Ink menu option from the BOL home page
	Then I can sign out of Brother Online
	
"""Logged into Brother Online with email address Bol-176@mailinator.com, pwd=Abcd1234
Observed that the user does not have access to the Instant Ink menu option
Logged out
in CMS, added the Brother Instant Ink supply role to Bol-176@mailinator.com
Logged back into Brother Online with Bol-176@mailinator.com and observed that the user can see the Instant Ink menu
Changed the Bol-176@mailinator.com email to changedBol-176@mailinator.com
Logged out with the old user, validated the new changes via Mailinator and logged back into Brother Online using changedBol-176@mailinator.com.
Observed the user no longer has access to Instant Ink when it should have.
Logged into CMS and searched for the new user changedBol-176@mailinator.com, and the Brother Instant Ink supply role is no longer granted to that user"""



