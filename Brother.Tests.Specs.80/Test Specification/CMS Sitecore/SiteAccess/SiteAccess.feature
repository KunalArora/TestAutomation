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
	
	| country        | Site Url                                           | UserName   | Password  |
	| United Kingdom | http://main.co.uk.brotherdv2.eu/sitecore/login     | Automation | Password1 | 
	#| United Kingdom | http://main.co.uk.cms.brotherqas.eu/sitecore/login | Automation | Password1 | 
	
@ignore
Scenario Outline: Verify that a user is able to login to the CMS system	and check page exists
Given That I navigate to "<Site Url>" in order to validate the CMS site
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	And I press login button "<country>"
	Then I can verify that the page header is displayed on the experience editor "<country>"
	
Scenarios: 
| country        | Site Url                                                                                                      | UserName | Password | 
| United Kingdom | http://main.co.uk.brotherdv2.eu/?sc_mode=edit&sc_itemid=%7bF1D22F29-BECF-4ADF-A8FF-A5411095D2B3%7d&sc_lang=en |Automation | Password1 | 


@ignore
Scenario Outline: Verify that a user is able to login to the CMS system	- Germany
	Given That I navigate to "<Site Url>" in order to validate the CMS site
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	And I press login button "<country>"
	Then I should be able to see the experience editor page "<country>"
	And I click on the Content Editor option "<country>"
	Then I should be able to see the content editor page "<country>"
	

Scenarios: 
	
	| country | Site Url                                        | UserName   | Password  |
	| Germany | http://main.de.brotherdv2.eu/sitecore/login     | Automation | Password1 |
	#| Germany | http://main.de.cms.brotherqas.eu/sitecore/login | Automation | Password1 |

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
	
	| country        | Site Url                            | UserName   | Password  |
	| France | http://main.fr.brotherdv2.eu/sitecore/login | Automation | Password1 |
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
	
	| country        | Site Url                           | UserName   | Password  |
	| Italy | http://main.it.brotherdv2.eu/sitecore/login | Automation | Password1 |
	#| Italy | http://main.it.cms.brotherqas.eu/sitecore/login | Automation | Password1 |
	
@ignore
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