﻿@PROD @UAT @TEST @DEV
Feature: FreeTrial
	In order to try out OmniJoin for 30 days
	As a customer
	I need to sign up for a Free trial

@SMOKE
Scenario: Sign Up for 14 day Free trial already signed into Brother Online
	# Create an account on BOL and sign in
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	And I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
	Then I should be directed to the OmniJoin Free Trial page
	When I have entered a valid First and Last name, "AutoTest", "AutoTest"
	And I have entered a valid email address
	And I have entered a valid phone number "01555 522522"
	And I have Agreed to the Free Trial Terms and Conditions
	And if I click Submit
	Then I should be directed to the download page indicating I have 14 days Free trial
	And Once I have Validated a Free Trial confirmation Email was received
	Then If I go back to Brother Online Home Page 
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

@ignore
Scenario: Sign Up for 14 day Free trial with a Brother Online account but start from Purchase plans page

@SMOKE
#@STAGING
# This does not sign you into Brother Online it merely creates the account as part of the Free Trial process.
Scenario: Sign Up for 14 day Free trial without an existing Brother Online account(BBAU-2533)
	Given I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
	Then I should be directed to the OmniJoin Free Trial page
	When I have entered a valid First and Last name, "AutoTest", "AutoTest"
	And I have entered a Free Trial AutoGenerated email address
	And I enter a Free Trial Password of "Abcd1234"
	And I enter a Free Trial Password confirmation of "Abcd1234"
	And I have entered a valid phone number "01555 522522"
	And I have Agreed to the Free Trial Terms and Conditions
	And if I click Submit
	Then I should be directed to the download page indicating I have 14 days Free trial
	Then If I go back to Brother Online Home Page 
	And Once I have Validated a Free Trial confirmation Email was received


@PROD @UAT @TEST @DEV
#Once the defect is fixed take out the last comments off the test
Scenario Outline: Validate Free Trial form displays error messages when an invalid email is entered (BBAU-2721)
	Given I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
	Then I should be directed to the OmniJoin Free Trial page
	When I have entered a valid First and Last name, "AutoTest", "AutoTest"
	Then I enter an invalid email address as <Invalid Email Address> for omnijoin free trial
	Then I should see the Error Message displayed on the Email Address field


Scenarios:
	| Invalid Email Address  |                                                                                                                                                                                                                                            
	| "InvalidEmailContaining aspace@mailinator.com" |
	| "InvalidEmailForUser@mailinator"|
	| "InvalidEmailForUser"|
	#| "ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com" |	

@ignore
#BBAU-2272 Defect raised again this feature
Scenario: Validate Free Trial form displays error messages when invalid First and Last names are entered
Given I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
	Then I should be directed to the OmniJoin Free Trial page
	When I have entered a valid First and Last name, "$%&£^GRYIR&^T*$UOITUJO$J", "*$%*"^%*"£^%(*$^GHWGKD"
	Then I should see an error message on the first name and last name field

@TEST @UAT @PROD
Scenario: Validate Free Trial form displays error messages when Terms and Conditions are not checked on Commit
	Given I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
	Then I should be directed to the OmniJoin Free Trial page
	When I have entered a valid First and Last name, "AutoTest", "AutoTest"
	And I have entered a Free Trial AutoGenerated email address
	And I enter a Free Trial Password of "Abcd1234"
	And I enter a Free Trial Password confirmation of "Abcd1234"
	And I have entered a valid phone number "01555 522522"
	And I click Submit without ticking the terms and conditions field
	Then I should see an error message on Terms and Conditions field



@TEST @UAT @PROD
Scenario: Validate Free Trial form displays error messages when Passwords do not match
Given I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
	Then I should be directed to the OmniJoin Free Trial page
	When I have entered a valid First and Last name, "AutoTest", "AutoTest"
	And I have entered a Free Trial AutoGenerated email address
	And I enter a Free Trial Password of "Abcd1234"
	And I enter a Free Trial Password confirmation of "Abcd1235"
	And I have entered a valid phone number "01555 522522"
	And I have Agreed to the Free Trial Terms and Conditions
	Then I should see an error message on Password Confirmation field

@TEST @UAT @PROD
Scenario: Validate Free Trial form displays error messages when an invalid Password is entered
Given I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
	Then I should be directed to the OmniJoin Free Trial page
	When I have entered a valid First and Last name, "AutoTest", "AutoTest"
	And I have entered a Free Trial AutoGenerated email address
	And I enter a Free Trial Password of "Abcd"
	And I enter a Free Trial Password confirmation of "Abcd1235"
	Then I should see an error message on Password field


@ignore 
Scenario: Validate Free Trial form displays error messages when a mandatory field is missing

@ignore 
Scenario: Validate Free Trial form when already signed into Brother Online and a Free-trial is already in progress

@ignore 
Scenario: Validate Free Trial form when already signed into Brother Online and a Free-trial has expired

@ignore 
Scenario: Validate Free Trial form when already signed into Brother Online, Free-trial has expired but is within the wait time for a new trial
