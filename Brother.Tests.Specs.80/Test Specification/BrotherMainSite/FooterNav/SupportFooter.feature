@TEST
Feature: Navigate footer Support menu
	    As a visitor of the Brother main site
       I am able to navigate to each of the
       tab items within the footer support menu

Scenario: User is able to navigate to the Creative Centre via the footer section of Support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the creative centre link in the footer section
	Then I am navigated to the Creative Centre page


Scenario: User is able to navigate to the Downloads/Software via the footer section of Support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the Downloads/Software link in the footer section
	Then I am navigated to the Downloads/Software page

# creative link
Scenario Outline: User is able to navigate to the Find a Service Centre via the footer section of Support menu
	Given I have navigated to the Brother Main Site "<country>" products pages
	And I have clicked the Find a Service Centre link in the footer section
	#Then I am navigated to the Find a Service Centre page

Scenarios:
	| country    |
	|United Kingdom|


Scenario: User is able to navigate to the Manuals via the footer section of Support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the Manuals link in the footer section
	Then I am navigated to the Manuals page


Scenario: User is able to navigate to the Product Registration via the footer section of Support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the Product Registration link in the footer section
	Then I am navigated to the Product Registration page


Scenario: User is able to navigate to the Recycling via the footer section of Support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the Product Recycling link in the footer section
	Then I am navigated to the Recycling page