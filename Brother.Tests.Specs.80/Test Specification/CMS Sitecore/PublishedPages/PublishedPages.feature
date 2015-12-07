@UAT @PROD @TEST
Feature: PublishedPages
	In order to validate the success of a new build, 
	previously published pages are verified to ensure 
	a CMS code change has not had an adverse effect	

@SMOKE
Scenario Outline: Navigate to published page to verify all page components 
	# Given I have navigated to the published url "http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseLeave"
	Given That I navigate to "<Site Url>" in order to validate a published page
	Then I can verify that the page header is displayed
	Then I can verify that the search icon is displayed
	Then I can verify that the top navigation component is displayed
	Then I can verify that the accordion compoment is displayed
	Then I can verify that the features carousel component is displayed
	Then I can verify that a features carousel tile is displayed
	Then I can verify that a banner bar component is displayed
	Then I can verify that a banner bar tile is displayed
	Then I can verify that an info image text module component is displayed
	Then I can verify that the secondary navigation component is displayed


Scenarios: 
	
	 |Site Url													   |
	 |http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseLeave |