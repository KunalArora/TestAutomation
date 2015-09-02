@UAT @PROD @TEST
Feature: AboutFooter
	As a visitor of the Brother main site
	I am able to navigate to each of the
	tab items within the about us footer menu

# Contact us navigation via page footer
Scenario: User is able to navigate to the contact us page via the about footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the contact us option under the about page footer
	Then I am navigated to the contact us page

# About us navigation via page footer
Scenario: User is able to navigate to the about us page via the about footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the about us option under the about page footer
	Then I am navigated to the about us page

# Latest news navigation via page footer
Scenario: User is able to navigate to the latest news page via the about footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the latest news option under the about page footer
	Then I am navigated to the latest news page

# Investor information navigation via page footer
Scenario: User is able to navigate to the investor information page via the about footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the investor information option under the about page footer
	Then I am navigated to the investor information page