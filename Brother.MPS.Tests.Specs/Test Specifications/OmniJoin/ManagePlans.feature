﻿@UAT @TEST
Feature: Manage Plan 
	As a customer 
	I would like to upgrade or cancel my OmniJoin subscription

Background: 
	# Create an account on BOL and log in
	#Given I am logged onto Brother Online "United Kingdom" using valid credentials

@ignore
# Order an OmniJoin plan, change the plan term to a different term (e.g Monthly to Annualy)
Scenario: Change Plan Term
	Given I have navigated to the OmniJoin home page
	When I purchase an OmniJoin "Lite" plan with "Monthly" billing with valid payment details
	Then I can navigate to the Brother Online Home Page "United Kingdom"
	When I sign back into Brother Online "United Kingdom" using the same credentials		
	When I click on OmniJoin home
	Then I can click on Manage Plan		
	And If I click on Change Plan or Term
	Then I can validate the correct plan is displayed "OmniJoin Lite" "Monthly"
	Then I can switch plans to "OmniJoin Lite" "Annual"
	And I can validate that the plan was changed "OmniJoin Lite" "Annual"
	Then I can validate that SAP has accepted the change of OmniJoin plan
	Then I can validate that an OmniJoin Plan Change email was received
	Then If I sign out of Brother Online
	Then I am redirected to the Brother Home Page


@IGNORE
#Payment method page has been changed
Scenario: Change Payment Method 
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
	 And I have navigated to the OmniJoin home page
	When I purchase an OmniJoin "Lite" plan with "Monthly" billing with valid payment details
	Then I can navigate to the Brother Online Home Page "United Kingdom"
	When I sign back into Brother Online "United Kingdom" using the same credentials
	When I click on OmniJoin home
	Then I can click on Manage Plan	
	And If I click on Edit Payment Method
	Then I check that the correct number of payment methods exist as "1"
	When I click Add Payment Method
	When I add a new Payment Method
	And I click on Use This Address
	When I enter valid credit card details for a MasterCard Credit Card with an expired date of "12-2014"
	# As the previous card is invalid, there will only be a single card visible in the list
	And I click on Send for Payment Information on Edit Payment page
	Then I can navigate back to Brother Online home page
	When I click on OmniJoin home
	Then I can click on Manage Plan	
	And If I click on Edit Payment Method
	# As the last card entered had an invalid expiry date (expired) then this should not be displayed
	Then I check that the correct number of payment methods exist as "1"
	And I select a payment Method from the Drop Down list as "VISA - ********9460"
	When I click Add Payment Method
	When I add a new Payment Method
	And I click on Use This Address
	When I enter valid credit card details for a MasterCard Credit Card with an expired date of "12-2016"
	And I click on Send for Payment Information on Edit Payment page
	# As the previous card is valid, there will now be 2 valid cards present
	Then I can navigate back to Brother Online home page
	When I click on OmniJoin home
	Then I can click on Manage Plan	
	And If I click on Edit Payment Method
	Then I check that the correct number of payment methods exist as "2"
	And I select a payment Method from the Drop Down list as "MasterCard - ********5390"
	When I can click on Update for Payment Method
	Then I can navigate back to Brother Online home page
	Then I can sign out of Brother Online
	And I am redirected to the Brother Home Page

@ignore 
Scenario: Edit Payment SAP validation
	# Edit Payment Method needs more thorough checks and also a SAP check. Cards with the same number are not getting updated
	# See BOL-234

@ignore
Scenario: Cancel Plan
	# Order Plan
	# My Account
	# Change Plan
	# Cancel subscription
	# Update
	# Validate message
	# Check my account for correct updates
	# Validate new order number via SAP

