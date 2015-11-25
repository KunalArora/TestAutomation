@UAT @PROD @TEST
Feature: Access 8.0 Dev environmemnt sites
	In order to validate the status of a Website on the 8.0 Dev environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

Scenario Outline: Get 200 OK response back from the following Brother Main Sites on the Test environment
	Given The following site <Language> <Main Site> to validate I should receive an Ok response back	
	When I have entered a valid username and password, "AutoTest", "AutoTest"
	# Then I am logged into CMS 8.0 homepage
	Scenarios:
	| Language       | Main Site                |
	| United Kingdom | http://main.co.uk.brotherdev.eu/sitecore/login |