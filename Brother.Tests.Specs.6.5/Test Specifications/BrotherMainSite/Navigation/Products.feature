@IGNORE
# @TEST @UAT
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

# Colour lasers
Scenario: User is able to navigate to view the colour laser range of printers
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page
	Then I click the colour laser menu option
	Then I click to view the colour laser range
	Then I click to view all colour lasers
	Then I am navigated to view all colour laser printers

# Mono lasers
Scenario: User is able to navigate to view the mono laser range of printers
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page
	Then I click the mono laser menu option
	Then I click to view the mono laser range
	Then I click to view all mono lasers
	Then I am navigated to view all mono laser printers

# Inkjet
Scenario: User is able to navigate to view the inkjet range of printers
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page
	Then I click the inkjet menu option
	Then I click to view the inkjet range
	Then I click to view all inkjet printers
	Then I am navigated to view all inkjet printers

# Portable
Scenario: User is able to navigate to view the portable range of printers
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page
	Then I click the portable menu option
	Then I click to view the portable range
	Then I click to view all portable printers
	Then I am navigated to view all portable printers

# Workgroup
@TEST @UAT
Scenario: User is able to navigate to view the workgroup printer
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page
	Then I click the workgroup menu option
	Then I click to view the workgroup printer
	Then I am navigated to view the workgroup printer

# All printers
Scenario: User is able to navigate to view all the printer range
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the printers option
	Then I am navigated to the printers page
	Then I click the all printers menu option
	Then I click to view the full printer range
	Then I am navigated to view all the printers

# Scannners navigation
Scenario: User is able to navigate to the scanners page via the top main site products menu
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the scanners option
	Then I am navigated to the scanners page

# View all scanners
Scenario: User is able to navigate to view all the scanners 
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the scanners option
	Then I click to view all the scanners
	Then I am navigated to view all the scanners

# Portable scanners
Scenario: User is able to navigate to view portable scanners 
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the scanners option
	Then I click to view portable scanners
	Then I am navigated to view portable scanners

# Compact scanners
Scenario: User is able to navigate to view compact scanners 
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the scanners option
	Then I click to view compact scanners
	Then I am navigated to view compact scanners

# Desktop scanners
Scenario: User is able to navigate to view desktop scanners 
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I hover over the top products menu button
	Then I hover and click the scanners option
	Then I click to view desktop scanners
	Then I am navigated to view desktop scanners






