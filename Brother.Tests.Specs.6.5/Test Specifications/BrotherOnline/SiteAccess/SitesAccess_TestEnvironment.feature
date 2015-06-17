@TEST
Feature: AccessALLTestSites
	In order to validate the status of a Websites on the Test environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

# BrotherMainSite
@SMOKE
Scenario Outline: Get 200 OK response back from Brother Main Site <"Language"> on the Test environment
	Given The following site <"Language"> <"Main Site"> to validate I should receive an Ok response back	

	Scenarios:
	| Language | Main Site|
	| Ireland        | http://ie.brotherdv2.eu/ |
	| United Kingdom | http://uk.brotherdv2.eu/ |

# BrotherOnline
@SMOKE
Scenario: Get 200 OK response back from Brother Online <"Language"> on the Test environment
	Given The following site <"Language"> <"Brother Online"> to validate I should receive an Ok response back
	
	Scenarios:
	| Language       | Brother Online                   |
	| Ireland        | https://online.ie.brotherdv2.eu/ |
	| United Kingdom | https://online.uk.brotherdv2.eu/ |
	| Spain          | https://online.es.brotherdv2.eu/ |
	| Poland         | https://online.pl.brotherdv2.eu/ |

# CreativeCentre - UK
@SMOKE
Scenario: Get 200 OK response back from Creative Centre United Kingdom on the Test environment
	Given The following site "http://creativecenter.eu.brotherdv2.eu/" to validate I should receive an Ok response back
