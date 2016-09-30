@SMOKE @UAT @PROD @TEST 
Feature: CMS website access
	In order to validate that the CMS site is accessible a number of content editor actions are conducted

@SMOKE
Scenario Outline: Verify that a user is able to login to the CMS system	
	Given That I navigate to "<Site Url>" in order to validate the CMS site
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	And I press login button "<country>"
	Then I should be able to see the experience editor page "<country>"
	And I click on the Content Editor option "<country>"
	Then I should be able to see the content editor page "<country>"
	
	
Scenarios: 
	
	| country        | Site Url        | UserName   | Password  |
	| United Kingdom | /sitecore/login | Automation | Password1 |
	#| United Kingdom | http://main.co.uk.cms.brotherqas.eu/sitecore/login | Automation | Password1 | 
	
@SMOKE
Scenario Outline: Verify that a user is able to login to the CMS system	- France
	Given That I navigate to "<Site Url>" in order to validate the CMS site
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	And I press login button "<country>"
	Then I should be able to see the experience editor page "<country>"
	And I click on the Content Editor option "<country>"
	Then I should be able to see the content editor page "<country>"
	

Scenarios: 
	
	| country | Site Url        | UserName   | Password  |
	| France  | /sitecore/login | Automation | Password1 |
	#| France | http://main.fr.cms.brotherqas.eu/sitecore/login | Automation | Password1 |

@SMOKE
Scenario Outline: Verify that a user is able to login to the CMS system	- Italy
	Given That I navigate to "<Site Url>" in order to validate the CMS site
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	And I press login button "<country>"
	Then I should be able to see the experience editor page "<country>"
	And I click on the Content Editor option "<country>"
	Then I should be able to see the content editor page "<country>"
	

Scenarios: 
	
	| country | Site Url        | UserName   | Password  |
	| Italy   | /sitecore/login | Automation | Password1 |
	#| Italy | http://main.it.cms.brotherqas.eu/sitecore/login | Automation | Password1 |
	