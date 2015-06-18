@TEST
Feature: AccessALLTestSites
	In order to validate the status of a Websites on the Test environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

# BrotherMainSite
@SMOKE
Scenario Outline: Get 200 OK response back from the following Brother Main Sites on the Test environment
	Given The following site <Language> <Main Site> to validate I should receive an Ok response back	

	Scenarios:
	| Language       | Main Site                |
	| Ireland        | http://ie.brotherdv2.eu/ |
	| United Kingdom | http://uk.brotherdv2.eu/ |
	| Germany        | http://de.brotherdv2.eu/ |
	| Slovakia       | http://sk.brotherdv2.eu/ |
	| Poland         | http://pl.brotherdv2.eu/ |
	| France         | http://fr.brotherdv2.eu/ |
	| Netherlands    | http://nl.brotherdv2.eu/ |
	| Russia         | http://ru.brotherdv2.eu/ |
	| Portugal       | http://pt.brotherdv2.eu/ |
	| Romania        | http://ro.brotherdv2.eu/ |
	| Czech          | http://cz.brotherdv2.eu/ |
	| Hungary        | http://hr.brotherdv2.eu/ |
	| Belgium        | http://be.brotherdv2.eu/ |
	| Denmark        | http://dk.brotherdv2.eu/ |
	| Switzerland    | http://ch.brotherdv2.eu/ |
	#| Austria        | http://as.brotherdv2.eu/ | - site not live
	| Slovenia       | http://si.brotherdv2.eu/ |
	| Spain          | http://es.brotherdv2.eu/ |
	| Italy          | http://it.brotherdv2.eu/ |

# BrotherOnline
@SMOKE
Scenario Outline: Get 200 OK response back from the following Brother Online Sites on the Test environment
	Given The following site <Language> <Brother Online> to validate I should receive an Ok response back
	
	Scenarios:
	| Language       | Brother Online                   |
	| Ireland        | https://online.ie.brotherdv2.eu/ |
	| United Kingdom | https://online.uk.brotherdv2.eu/ |
	| Spain          | https://online.es.brotherdv2.eu/ |
	| Poland         | https://online.pl.brotherdv2.eu/ |
	| Germany        | https://online.de.brotherdv2.eu/ |
	| Slovakia       | https://online.sk.brotherdv2.eu/ |
	| France         | https://online.fr.brotherdv2.eu/ |
	| Netherlands    | https://online.nl.brotherdv2.eu/ |
	| Russia         | https://online.ru.brotherdv2.eu/ |
	| Portugal       | https://online.pt.brotherdv2.eu/ |
	| Romania        | https://online.ro.brotherdv2.eu/ |
	| Czech          | https://online.cz.brotherdv2.eu/ |
	| Hungary        | https://online.hr.brotherdv2.eu/ |
	| Belgium        | https://online.be.brotherdv2.eu/ |
	| Denmark        | https://online.dk.brotherdv2.eu/ |
	| Switzerland    | https://online.ch.brotherdv2.eu/ |
	#| Austria        | https://online.as.brotherdv2.eu/ | - Site not live
	| Slovenia       | https://online.si.brotherdv2.eu/ |
	| Italy          | https://online.it.brotherdv2.eu/ |

# CreativeCentre - UK
@SMOKE
Scenario: Get 200 OK response back from Creative Centre United Kingdom on the Test environment
	Given The following site United Kingdom http://creativecenter.eu.brotherdv2.eu/ to validate I should receive an Ok response back
