@PROD
Feature: AccessAllProductionSites
	In order to validate the status of a Websites on the Production environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites


@SMOKE
Scenario Outline: Get 200 OK response back from Brother Main Site "<Country>" on the LIVE environment
	Given The following site "<Site Url>" to validate I should receive an Ok response back	

Scenarios: 
	
	| Country        | Site Url                  |
	| Ireland        | http://www.brother.ie/    |
	| Germany        | http://www.brother.de/    |
	| United Kingdom | http://www.brother.co.uk/ |
	| France         | http://www.brother.fr/    |
	| Austria        | http://www.brother.at/    |
	| Poland         | http://www.brother.pl/    |
	| Switzerland    | http://www.brother.ch/    | 
	| Belgium        | http://www.brother.be/    |
	| Italy          | http://www.brother.it/    |
	| Netherlands    | http://www.brother.nl/    |
	| Denmark        | http://www.brother.dk/    |
	| Finland        | http://www.brother.fi/    |
	| Norway         | http://www.brother.no/    |
	| Sweden         | http://www.brother.se/    |
	| Portugal       | http://www.brother.pt/    |
	| Czech Republic | http://www.brother.cz/    |
	| Hungary        | http://www.brother.hu/    |
	| Russia         | http://www.brother.ru/    |
	| Bulgaria       | http://www.brother.bg/    |
	| Romania        | http://www.brother.ro/    |
	| Slovenia       | http://www.brother.si/    |
	| Luxembourg     | http://www.brother.lu/    |

@SMOKE
Scenario Outline: Get 200 OK response back from Brother Online "<Country>" on the LIVE environment
	Given The following site "<Site Url>" to validate I should receive an Ok response back	

Scenarios: 
	
	| Country        | Site Url                      |
	| Ireland        | https://online.brother.ie/    |
	| Spain          | https://online.brother.es/    |
	| Poland         | https://online.brother.pl/    |
	| France         | https://online.brother.fr/    |
	| United Kingdom | https://online.brother.co.uk/ |
	| Germany        | https://online.brother.de/    |
	| Switzerland    | https://online.brother.ch/    |
	| Austria        | https://online.brother.at/    |
	| Belgium        | https://online.brother.be/    |
	| Italy          | https://online.brother.it/    |
	| Netherlands    | https://online.brother.nl/    |
	| Denmark        | https://online.brother.dk/    |
	| Finland        | https://online.brother.fi/    |
	| Norway         | https://online.brother.no/    |
	| Sweden         | https://online.brother.se/    |
	| Portugal       | https://online.brother.pt/    |
	| Czech Republic | https://online.brother.cz/    |
	| Hungary        | https://online.brother.hu/    |
	| Russia         | https://online.brother.ru/    |
	| Bulgaria       | https://online.brother.bg/    |
	| Romania        | https://online.brother.ro/    |
	| Slovenia       | https://online.brother.si/    |
	| Luxembourg     | https://online.brother.lu/    |

@SMOKE
Scenario Outline: Get 200 OK response back from Web Conferencing "<Country>" on the LIVE environment
	Given The following site "<Site Url>" to validate I should receive an Ok response back	

Scenarios:
	
	| Country        | Site Url                              |
	| United Kingdom | http://webconferencing.brother.co.uk/ |
	| France         | http://webconference.brother.fr/      |
	| Switzerland    | http://visioconference.brother.ch/    |
	| Spain          | http://videoconferencia.brother.es/   |
	| Ireland        | http://webconferencing.brother.ie/    |
	| Germany        | http://videokonferenzen.brother.de/   |

@SMOKE
Scenario Outline: Get 200 OK response back from Creative Centre "<Country>" on the LIVE environment
	Given The following site "<Site Url>" to validate I should receive an Ok response back

Scenarios:
	
	| Country        | Site Url                          |
	| United Kingdom | https://creativecenter.brother.eu |

