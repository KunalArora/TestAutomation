@UAT @PROD @TEST
Feature: CMS website access
	In order to validate that the CMS site is accessible a number of content editor actions are conducted

Scenario Outline: Verify that a user is able to login to the CMS system	
	Given That I navigate to "<Site Url>" in order to validate the CMS site
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	And I press login button "<country>"
	Then I should be able to see the experience editor page "<country>"
	And I click on the Content Editor option "<country>"
	Then I should be able to see the content editor page "<country>"
	And I navigate to the url "http://main.co.uk.brotherdv2.eu/?sc_mode=edit&sc_itemid={4BAA835A-AB17-410E-BAE8-66821388806B}&sc_lang=en"

	 


Scenarios: 
	
	| country        | Site Url                                       | UserName   | Password  |
	| United Kingdom | http://main.co.uk.brotherdv2.eu/sitecore/login | Automation | Password1 |


Scenario Outline: Verify that a user is able to add grid on the page
	Given That I navigate to "<Site Url>" in order to validate the CMS site
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	And I press login button "<country>"
	And I click on the Main Header placeholder "<country>"
    And I click on the add here option "<country>"
	And I click on the Select a Rendering "<country>"
    Then I should be able to add grid from the grid option "<country>"

Scenarios: 
	
	| country        | Site Url                                       | UserName   | Password  |
	| United Kingdom | http://main.co.uk.brotherdv2.eu/?sc_mode=edit&sc_itemid={4BAA835A-AB17-410E-BAE8-66821388806B}&sc_lang=en | Automation | Password1 |