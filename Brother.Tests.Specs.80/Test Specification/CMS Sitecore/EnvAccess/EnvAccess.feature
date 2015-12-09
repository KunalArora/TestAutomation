@UAT @PROD @TEST @SMOKE
Feature: Environmemnt access
	In order to validate that the environments are available a 200 response is returned from all related URLs	

# BrotherMainSite
@SMOKE
Scenario Outline: Get 200 OK response back from the following Brother Main Sites on the Test environment
	Given The following site <Language> <Main Site> to validate then I should receive an Ok response back	

	Scenarios:
	| Language       | Main Site										  |
	| United Kingdom | http://main.co.uk.brotherdev.eu/sitecore/login	  |
	| United Kingdom | http://main.co.uk.brotherdv2.eu/sitecore/login	  |
	| United Kingdom | http://main.co.uk.cms.brotherqas.eu/sitecore/login |
	| United Kingdom | http://main.co.uk.cms.brother.eu/sitecore/login	  |



