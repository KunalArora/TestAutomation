@UAT
Feature: AccessAllUATSites
	In order to validate the status of a Websites on the UAT environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

# BrotherMainSite
@SMOKE
Scenario Outline: Get 200 OK response back from the following Brother Main Sites on the UAT environment
	Given The following site <Country> <Main Site> to validate I should receive an Ok response back	

	Scenarios:
	| Country        | Main Site                |
	| United Kingdom | http://uk.brotherqas.eu/ |
	| Germany        | http://de.brotherqas.eu/ |
	| Slovakia       | http://sk.brotherqas.eu/ |
	| Poland         | http://pl.brotherqas.eu/ |
	| France         | http://fr.brotherqas.eu/ |
	| Netherlands    | http://nl.brotherqas.eu/ |
	| Russia         | http://ru.brotherqas.eu/ |
	| Portugal       | http://pt.brotherqas.eu/ |
	| Romania        | http://ro.brotherqas.eu/ |
	| Czech          | http://cz.brotherqas.eu/ |
	| Belgium        | http://be.brotherqas.eu/ |
	| Denmark        | http://dk.brotherqas.eu/ |
	| Switzerland    | http://ch.brotherqas.eu/ |
	| Slovenia       | http://si.brotherqas.eu/ |
	| Spain          | http://es.brotherqas.eu/ |
	| Italy          | http://it.brotherqas.eu/ |
	| Ireland        | http://ie.brotherqas.eu/ |
	| Hungary        | http://hr.brotherqas.eu/ |
#	| Austria        | http://as.brotherqas.eu/ |

# BrotherOnline
@SMOKE
Scenario Outline: Get 200 OK response back from the following Brother Online Sites on the UAT environment
	Given The following site <Country> <Brother Online> to validate I should receive an Ok response back
	
	Scenarios:
	| Country        | Brother Online                   |
	| United Kingdom | https://online.uk.brotherqas.eu/ |
	| Spain          | https://online.es.brotherqas.eu/ |
	| Poland         | https://online.pl.brotherqas.eu/ |
	| Germany        | https://online.de.brotherqas.eu/ |
	| Netherlands    | https://online.nl.brotherqas.eu/ |
	| Russia         | https://online.ru.brotherqas.eu/ |
	| Slovakia       | https://online.sk.brotherqas.eu/ |
	| Portugal       | https://online.pt.brotherqas.eu/ |
	| Romania        | https://online.ro.brotherqas.eu/ |
	| Czech          | https://online.cz.brotherqas.eu/ |
	| Belgium        | https://online.be.brotherqas.eu/ |
	| Denmark        | https://online.dk.brotherqas.eu/ |
	| Switzerland    | https://online.ch.brotherqas.eu/ |
	| France         | https://online.fr.brotherqas.eu/ |
	| Slovenia       | https://online.si.brotherqas.eu/ |
	| Italy          | https://online.it.brotherqas.eu/ |
	| Ireland        | https://online.ie.brotherqas.eu/ |
#	| Hungary        | https://online.hr.brotherqas.eu/ |
#	| Austria        | https://online.as.brotherqas.eu/ |

# CreativeCentre - UK
@SMOKE
Scenario: Get 200 OK response back from Creative Centre United Kingdom on the UAT environment
	Given The following site "United Kingdom" https://creativecenter.eu.brotherqas.eu/ to validate I should receive an Ok response back