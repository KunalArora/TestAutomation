@UAT @PROD @TEST
Feature: Access 8.0 Dev environmemnt sites
	In order to validate the status of a Website on the 8.0 Dev environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

@SMOKE @TEST @UAT
Scenario Outline: Get 200 OK response back from the following Brother Main Sites on the Test environment
	#Given I have navigated to the Brother Main Site "<country>" products pages
	Given The following site "<Site Url>" to validate I should receive an Ok response back	on mainsite
	#And I fill in username and password using valid credentials
	When I enter an email address containing <User Name>

	#| field           | value          |
	#| UserName        | AutoTest       |
	#| LastName        | AutoTest       |

Scenarios: 
	
	| country        | Site Url                                       | User Name |
	| United Kingdom | http://main.co.uk.brotherdv2.eu/sitecore/login | AutoTest |