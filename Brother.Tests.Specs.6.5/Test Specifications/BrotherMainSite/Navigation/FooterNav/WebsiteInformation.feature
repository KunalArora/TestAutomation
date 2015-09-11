@IGNORE
Feature: WebsiteInformation footer navigation
	As a visitor of the Brother main site
	I am able to navigate to each of the
	links within the website information footer

# Terms and conditions navigation
Scenario: User is able to navigate to the terms and conditions page via the website information footer section
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I have clicked the terms and conditions link within the website information footer
	Then I am navigated to the terms and conditions page

# Brother network navigation
Scenario: User is able to navigate to the brother network page via the website information footer section
	Given I have navigated to the Brother Main Site "United Kingdom" products pages
	Then I have clicked the brother network link within the website information footer
	Then I am navigated to the brother network page
