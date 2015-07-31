@IGNORE @UAT @TEST
Feature: TestTmpTest
	In order to test snippets of code
	As a Developer
	I want to be able to run code in isolation

Background: 
	#Given I already have a set of Brother Online "Spain" account credentials
	#When I click on Sign In / Create An Account for "Spain"
	#And I am redirected to the Brother Login/Register page
	#And I have Checked Yes I Do Have An Account Checkbox
	#And I enter a valid Email Address "laies_es_qas@mailinator.com"  
	#And I enter a valid Password "Welcome1"
	#When I click on "Spain" Sign In
	#Then I am redirected to the Welcome Back page

	#Given I already have a set of Brother Online "United Kingdom" account credentials
	#When I click on Sign In / Create An Account for "United Kingdom"
	#And I am redirected to the Brother Login/Register page
	#And I have Checked Yes I Do Have An Account Checkbox
	#And I enter a valid Email Address "UK_BrotherAutoTest@BrotherAutoTest.com"  
	#And I enter a valid Password "Abcd1234"
	#When I click on "United Kingdom" Sign In
	#Then I am redirected to the Welcome Back page
	#Given I am logged onto Brother Online "United Kingdom" using valid credentials
	
@STAGING @IGNORE
Scenario: Test Code Two
	#Given I want to open a new tab
	Given SqlCall
	Given Setup

@STAGING @IGNORE
Scenario: Simple Parallel Test
	Given I want to run multiple instances of PhantomJs
	Then Navigate to website x, y and z