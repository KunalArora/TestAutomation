@UAT @PROD @TEST
Feature: CMS website access
	In order to validate that the CMS site is accessible a number of content editor actions are conducted

@SMOKE @TEST @UAT
Scenario Outline: Verify that a user is able to login to the CMS system	
	Given That I navigate to "<Site Url>" in order to validate the CMS site
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	And I press login button "<country>"
	Then I should be able to see the experience editor page "<country>"
	And I click on the Content Editor option "<country>"
	Then I should be able to see the content editor page "<country>"


Scenarios: 
	
	| country        | Site Url                                       | UserName   | Password  |
	| United Kingdom | http://main.co.uk.brotherdv2.eu/sitecore/login | Automation | Password1 |

