@UAT @PROD @TEST
Feature: Navigate main site top products menu
	As a visitor of the Brother main site
	I am able to navigate to each of the
	tab items within the top products menu


Scenario: User is able to navigate to the products page via the top main site products menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the top products menu button
	Then I am navigated to the products page

Scenario: User is able to navigate to the printers page via the top main site products menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page
	
