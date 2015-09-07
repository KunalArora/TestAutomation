@UAT @PROD @TEST
Feature: ProductsFooter
	As a visitor of the Brother main site
	I am able to navigate to each of the
	tab items within the products footer menu

# Printers navigation via page footer
Scenario Outline: User is able to navigate to the printers page via the products footer menu
	Given I have navigated to the Brother Main Site "<country>" footer pages	
	Then I click the printers option under the products page footer
	# Uncomment bottom step when 8.0 link navigation is completed in for printer footer
	# Then I am navigated to the printers page via the footer link
Scenarios:
	|country    |
	|United Kingdom|

# Scanners navigation via page footer
Scenario: User is able to navigate to the scanners page via the products footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the scanners option under the products page footer
	Then I am navigated to the scanners page

# Label printers navigation via page footer
Scenario: User is able to navigate to the label printers page via the products footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the label printers option under the products page footer
	Then I am navigated to the label printers page

# Fax machines navigation via page footer
Scenario: User is able to navigate to the fax machines page via the products footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the fax machines option under the products page footer
	Then I am navigated to the fax machines page

# Supplies and accessories navigation via page footer
Scenario: User is able to navigate to the supplies and accessories page via the products footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the supplies and accessories option under the products page footer
	Then I am navigated to the supplies and accessories page

# Latest promotions navigation via page footer
Scenario: User is able to navigate to the latest promotions page via the products footer menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages	
	Then I click the latest promotions option under the products page footer
	Then I am navigated to the latest promotions page





