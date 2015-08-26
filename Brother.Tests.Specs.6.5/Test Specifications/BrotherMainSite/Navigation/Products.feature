@UAT @PROD @TEST
Feature: Navigate main site top products menu
	As a visitor of the Brother main site
	I am able to navigate to each of the
	tab items within the top products menu

# Products navigation 
Scenario: User is able to navigate to the products page via the top main site products menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I have clicked the top products menu button
	Then I am navigated to the products page

# Printers navigation
Scenario: User is able to navigate to the printers page via the top main site products menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page

Scenario: User is able to navigate to view the colour laser range of printers
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page
	Then I click the colour laser menu option
	Then I click to view the colour laser range
	Then I click to view all colour lasers
	Then I am navigated to view all colour laser printers


