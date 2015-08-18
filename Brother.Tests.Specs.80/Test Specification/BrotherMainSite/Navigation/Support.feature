@UAT @PROD @TEST
Feature: Navigate main site top support menu
	As a visitor of the Brother main site
	I am able to navigate to each of the
	tab items within the top support menu

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
