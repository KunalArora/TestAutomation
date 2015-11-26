@UAT @PROD @TEST
Feature: Access 8.0 Dev environmemnt sites
	In order to validate the status of a Website on the 8.0 Dev environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

@SMOKE @TEST @UAT
Scenario Outline: Get 200 OK response back from the following Brother Main Sites on the Test environment
	Given The following site "<Site Url>" to validate I should receive an Ok response back	on mainsite login
	And I enter an username containing "<UserName>"
	And I enter password containing "<Password>"
	#When I press login button 
	#Then I should be able to see the experience editor page


Scenarios: 
	
	| country        | Site Url                                       | UserName   | Password  |
	| United Kingdom | http://main.co.uk.brotherdv2.eu/sitecore/login | Automation | Password1 |