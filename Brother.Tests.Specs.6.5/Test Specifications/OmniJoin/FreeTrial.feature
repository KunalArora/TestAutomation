﻿@PROD @UAT @TEST @DEV
Feature: FreeTrial
	In order to try out OmniJoin for 30 days
	As a customer
	I need to sign up for a Free trial

@SMOKE
Scenario: Sign Up for 14 day Free trial already signed into Brother Online
	# Create an account on BOL and sign in
	Given I am logged onto Brother Online "United Kingdom" using valid credentials
	And I have navigated to the OmniJoin WebConferencing Home Page
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
Scenario: Sign Up for 14 day Free trial without an existing Brother Online account
	Given I have navigated to the OmniJoin WebConferencing Home Page
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
	And Once I have Validated a Free Trial confirmation Email was received


@ignore
Scenario: Validate Free Trial form accepts correct amount of characters and displays error messages

@ignore
Scenario: Validate Free Trial form displays error messages when an invalid email is entered

@ignore
Scenario: Validate Free Trial form displays error messages when invalid First and Last names are entered

@ignore
Scenario: Validate Free Trial form displays error messages when Terms and Conditions are not checked on Commit

@ignore
Scenario: Validate Free Trial form displays error messages when an invalid Password is entered

@ignore
Scenario: Validate Free Trial form displays error messages when Passwords do not match

@ignore 
Scenario: Validate Free Trial form displays error messages when a mandatory field is missing

@ignore 
Scenario: Validate Free Trial form when already signed into Brother Online and a Free-trial is already in progress

@ignore 
Scenario: Validate Free Trial form when already signed into Brother Online and a Free-trial has expired

@ignore 
Scenario: Validate Free Trial form when already signed into Brother Online, Free-trial has expired but is within the wait time for a new trial
