@TEST
Feature: Navigate footer WebsiteInformation menu
	    As a visitor of the Brother main site
       I am able to navigate to each of the
       tab items within the footer website information menu

Scenario Outline: User is able to navigate to the Accessibility via the footer section of Website Information menu
	Given I have navigated to the Brother Main Site "<country>" products pages
	And I have clicked the accessibility link in the footer section
	#Then I am navigated to the accessibility page

Scenarios:
	| country    |
	|United Kingdom|


Scenario: User is able to navigate to the Privacy Policy via the footer section of Website Information menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	#And I have clicked the privacy policy link in the footer section
	#Then I am navigated to the privacy policy page


Scenario: User is able to navigate to the Terms And Conditions via the footer section of Website Information menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the terms and conditions link in the footer section
	Then I am navigated to the terms and conditions page


Scenario Outline: User is able to navigate to the Brother Network via the footer section of Website Information menu
	Given I have navigated to the Brother Main Site "<country>" footer pages
	And I have clicked the brother network link in the footer section
	Then I am navigated to the brother network page

Scenarios:
	| country    |
	|United Kingdom|