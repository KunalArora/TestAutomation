@UAT @PROD
Feature: AccessAllProductionSites
	In order to validate the status of a Websites on the Production environment
	As a sanity check
	We need to receive a 200 OK request back from a list of selected sites

@ignore
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
	| Russia         | http://www.brother.ru/    |
	| Slovenia       | http://www.brother.si/    |
	| Luxembourg     | http://www.brother.lu/    |
#	| Hungary        | http://www.brother.hu/    |
#	| Bulgaria       | http://www.brother.bg/    |
#	| Romania        | http://www.brother.ro/    |

@ignore
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
	| Russia         | https://online.brother.ru/    |
	| Slovenia       | https://online.brother.si/    |
	| Luxembourg     | https://online.brother.lu/    |
#	| Hungary        | https://online.brother.hu/    |
#	| Bulgaria       | https://online.brother.bg/    |
#	| Romania        | https://online.brother.ro/    |

@ignore
Scenario Outline: Get 200 OK response back from Web Conferencing "<Country>" on the LIVE environment
	Given The following site "<Site Url>" to validate I should receive an Ok response back	

Scenarios:
	
	| Country        | Site Url                              |
	| United Kingdom | http://webconferencing.brother.co.uk/ |
	| France         | http://webconference.brother.fr/      |
	| Switzerland    | http://visioconference.brother.ch/    |
	| Ireland        | http://webconferencing.brother.ie/    |
	| Germany        | http://videokonferenzen.brother.de/   |
#	| Spain          | http://videoconferencia.brother.es/   |
@ignore
Scenario Outline: Get 200 OK response back from Creative Centre "<Country>" on the LIVE environment
	Given The following site "<Site Url>" to validate I should receive an Ok response back

Scenarios:
	
	| Country        | Site Url                          |
	| United Kingdom | https://creativecenter.brother.eu |

@ignore
Scenario Outline: Test all CD servers on Live Environment
		Given The following site "<Brother Site>" to validate I should receive an Ok response back

Scenarios:

| PRODUCTION CD SERVERS | Brother Site                                  |
#| 10.91.0.131           | https://web1.online.brother.at                |
#| 10.91.0.131           | https://web1.online.brother.ch                |
#| 10.91.0.131           | https://web1.online.brother.de                |
#| 10.91.0.131           | https://web1.online.brother.es                |
#| 10.91.0.131           | https://web1.online.brother.fr                |
| 10.91.0.131           | https://web1.online.brother.ie                |
| 10.91.0.131           | https://web1.online.brother.co.uk             |
#| 10.91.0.131           | https://web1.online.brother.cz                |
#| 10.91.0.131           | https://web1.online.brother.dk                |
#| 10.91.0.131           | https://web1.online.brother.nl                |
#| 10.91.0.131           | https://web1.online.brother.hu                |
#| 10.91.0.131           | https://web1.online.brother.it                |
#| 10.91.0.131           | https://web1.online.brother.no                |
#| 10.91.0.131           | https://web1.online.brother.pl                |
#| 10.91.0.131           | https://web1.online.brother.pt                |
#| 10.91.0.131           | https://web1.online.brother.ru                |
#| 10.91.0.131           | https://web1.online.brother.se                |
#| 10.91.0.131           | https://web1.online.brother.fi                |
#| 10.91.0.131           | https://web1.online.brother.be                |
#| 10.91.0.131           | https://web1.online.brother.lu                |
#| 10.91.0.131           | https://web1.online.brother.bg                |
#| 10.91.0.131           | https://web1.online.brother.ro                |
#| 10.91.0.131           | https://web1.online.brother.sk                |
#| 10.91.0.131           | https://web1.online.brother.si                |
#| 10.91.0.131           | http://www.web1.brother.co.uk                 |
#| 10.91.0.131           | http://www.web1.brother.de                    |
#| 10.91.0.131           | http://www.web1.brother.at                    |
#| 10.91.0.131           | http://www.web1.brother.fr                    |
#| 10.91.0.131           | http://www.web1.brother.ie                    |
#| 10.91.0.131           | http://www.web1.brother.it                    |
#| 10.91.0.131           | http://www.web1.brother.nl                    |
#| 10.91.0.131           | http://www.web1.brother.be                    |
#| 10.91.0.131           | http://www.web1.brother.lu                    |
#| 10.91.0.131           | http://www.web1.brother.ch                    |
#| 10.91.0.131           | http://www.web1.brother.pt                    |
#| 10.91.0.131           | http://www.web1.brother.es                    |
#| 10.91.0.131           | http://www.web1.brother.dk                    |
#| 10.91.0.131           | http://www.web1.brother.no                    |
#| 10.91.0.131           | http://www.web1.brother.se                    |
#| 10.91.0.131           | http://www.web1.brother.fi                    |
#| 10.91.0.131           | http://www.web1.brother.lt                    |
#| 10.91.0.131           | http://www.web1.brother.ee                    |
#| 10.91.0.131           | http://www.web1.brother.is                    |
#| 10.91.0.131           | http://www.web1.brother.lv                    |
#| 10.91.0.131           | http://www.web1.brother.cz                    |
#| 10.91.0.131           | http://www.web1.brother.pl                    |
#| 10.91.0.131           | http://www.web1.brother.sk                    |
#| 10.91.0.131           | http://www.web1.brother.si                    |
#| 10.91.0.131           | http://www.web1.brother.hu                    |
#| 10.91.0.131           | http://www.web1.brother.hr                    |
#| 10.91.0.131           | http://www.web1.brother.bg                    |
#| 10.91.0.131           | http://www.web1.brother.ro                    |
#| 10.91.0.132           | https://web2.online.brother.at                |
#| 10.91.0.132           | https://web2.online.brother.ch                |
#| 10.91.0.132           | https://web2.online.brother.de                |
#| 10.91.0.132           | https://web2.online.brother.es                |
#| 10.91.0.132           | https://web2.online.brother.fr                |
#| 10.91.0.132           | https://web2.online.brother.ie                |
#| 10.91.0.132           | https://web2.online.brother.co.uk             |
#| 10.91.0.132           | https://web2.online.brother.cz                |
#| 10.91.0.132           | https://web2.online.brother.dk                |
#| 10.91.0.132           | https://web2.online.brother.nl                |
#| 10.91.0.132           | https://web2.online.brother.hu                |
#| 10.91.0.132           | https://web2.online.brother.it                |
#| 10.91.0.132           | https://web2.online.brother.no                |
#| 10.91.0.132           | https://web2.online.brother.pl                |
#| 10.91.0.132           | https://web2.online.brother.pt                |
#| 10.91.0.132           | https://web2.online.brother.ru                |
#| 10.91.0.132           | https://web2.online.brother.se                |
#| 10.91.0.132           | https://web2.online.brother.fi                |
#| 10.91.0.132           | https://web2.online.brother.be                |
#| 10.91.0.132           | https://web2.online.brother.lu                |
#| 10.91.0.132           | https://web2.online.brother.ru                |
#| 10.91.0.132           | https://web2.online.brother.se                |
#| 10.91.0.132           | https://web2.online.brother.bg                |
#| 10.91.0.132           | https://web2.online.brother.ro                |
#| 10.91.0.132           | https://web2.online.brother.sk                |
#| 10.91.0.132           | https://web2.online.brother.si                |
#| 10.91.0.132           | http://www.web2.brother.de                    |
#| 10.91.0.132           | http://www.web2.brother.at                    |
#| 10.91.0.132           | http://www.web2.brother.fr                    |
#| 10.91.0.132           | http://www.web2.brother.ie                    |
#| 10.91.0.132           | http://www.web2.brother.it                    |
#| 10.91.0.132           | http://www.web2.brother.nl                    |
#| 10.91.0.132           | http://www.web2.brother.be                    |
#| 10.91.0.132           | http://www.web2.brother.ch                    |
#| 10.91.0.132           | http://www.web2.brother.pt                    |
#| 10.91.0.132           | http://www.web2.brother.es                    |
#| 10.91.0.132           | http://www.web2.brother.no                    |
#| 10.91.0.132           | http://www.web2.brother.se                    |
#| 10.91.0.132           | http://www.web2.brother.dk                    |
#| 10.91.0.132           | http://www.web2.brother.fi                    |
#| 10.91.0.132           | http://www.web2.brother.lt                    |
#| 10.91.0.132           | http://www.web2.brother.lv                    |
#| 10.91.0.132           | http://www.web2.brother.is                    |
#| 10.91.0.132           | http://www.web2.brother.ee                    |
#| 10.91.0.132           | http://www.web2.brother.cz                    |
#| 10.91.0.132           | http://www.web2.brother.pl                    |
#| 10.91.0.132           | http://www.web2.brother.sk                    |
#| 10.91.0.132           | http://www.web2.brother.si                    |
#| 10.91.0.132           | http://www.web2.brother.hu                    |
#| 10.91.0.132           | http://www.web2.brother.hr                    |
#| 10.91.0.132           | http://www.web2.brother.bg                    |
#| 10.91.0.132           | http://www.web2.brother.ro                    |
#| 10.91.0.132           | http://www.web2.brother.ru                    |
#| 172.27.16.133         | https://web5.online.brother.at                |
#| 172.27.16.133         | https://web5.online.brother.ch                |
#| 172.27.16.133         | https://web5.online.brother.de                |
#| 172.27.16.133         | https://web5.online.brother.es                |
#| 172.27.16.133         | https://web5.online.brother.fr                |
#| 172.27.16.133         | https://web5.online.brother.ie                |
#| 172.27.16.133         | https://web5.online.brother.co.uk             |
#| 172.27.16.133         | https://web5.online.brother.cz                |
#| 172.27.16.133         | https://web5.online.brother.dk                |
#| 172.27.16.133         | https://web5.online.brother.nl                |
#| 172.27.16.133         | https://web5.online.brother.hu                |
#| 172.27.16.133         | https://web5.online.brother.it                |
#| 172.27.16.133         | https://web5.online.brother.no                |
#| 172.27.16.133         | https://web5.online.brother.pl                |
#| 172.27.16.133         | https://web5.online.brother.pt                |
#| 172.27.16.133         | https://web5.online.brother.ru                |
#| 172.27.16.133         | https://web5.online.brother.ch                |
#| 172.27.16.133         | https://web5.online.brother.se                |
#| 172.27.16.133         | https://web5.online.brother.fi                |
#| 172.27.16.133         | https://web5.online.brother.be                |
#| 172.27.16.133         | https://web5.online.brother.lu                |
#| 172.27.16.133         | https://web5.online.brother.bg                |
#| 172.27.16.133         | https://web5.online.brother.ro                |
#| 172.27.16.133         | https://web5.online.brother.sk                |
#| 172.27.16.133         | https://web5.online.brother.si                |
#| 172.27.16.133         | http://www.web5.brother.co.uk                 |
#| 172.27.16.133         | http://www.web5.brother.de                    |
#| 172.27.16.133         | http://www.web5.brother.at                    |
#| 172.27.16.133         | http://www.web5.brother.fr                    |
#| 172.27.16.133         | http://www.web5.brother.ie                    |
#| 172.27.16.133         | http://www.web5.brother.it                    |
#| 172.27.16.133         | http://www.web5.brother.be                    |
#| 172.27.16.133         | http://www.web5.brother.lu                    |
#| 172.27.16.133         | http://www.web5.brother.ch                    |
#| 172.27.16.133         | http://www.web5.brother.pt                    |
#| 172.27.16.133         | http://www.web5.brother.es                    |
#| 172.27.16.133         | http://www.web5.brother.dk                    |
#| 172.27.16.133         | http://www.web5.brother.no                    |
#| 172.27.16.133         | http://www.web5.brother.se                    |
#| 172.27.16.133         | http://www.web5.brother.fi                    |
#| 172.27.16.133         | http://www.web5.brother.lt                    |
#| 172.27.16.133         | http://www.web5.brother.lv                    |
#| 172.27.16.133         | http://www.web5.brother.is                    |
#| 172.27.16.133         | http://www.web5.brother.ee                    |
#| 172.27.16.133         | http://www.web5.brother.cz                    |
#| 172.27.16.133         | http://www.web5.brother.pl                    |
#| 172.27.16.133         | http://www.web5.brother.sk                    |
#| 172.27.16.133         | http://www.web5.brother.si                    |
#| 172.27.16.133         | http://www.web5.brother.hu                    |
#| 172.27.16.133         | http://www.web5.brother.hr                    |
#| 172.27.16.133         | http://www.web5.brother.bg                    |
#| 172.27.16.133         | http://www.web5.brother.ro                    |
#| 172.27.16.133         | http://www.web5.brother.ru                    |
#| 172.27.16.134         | https://web6.online.brother.at                |
#| 172.27.16.134         | https://web6.online.brother.ch                |
#| 172.27.16.134         | https://web6.online.brother.de                |
#| 172.27.16.134         | https://web6.online.brother.ie                |
#| 172.27.16.134         | https://web6.online.brother.co.uk             |
#| 172.27.16.134         | https://web6.online.brother.cz                |
#| 172.27.16.134         | https://web6.online.brother.dk                |
#| 172.27.16.134         | https://web6.online.brother.nl                |
#| 172.27.16.134         | https://web6.online.brother.hu                |
#| 172.27.16.134         | https://web6.online.brother.it                |
#| 172.27.16.134         | https://web6.online.brother.no                |
#| 172.27.16.134         | https://web6.online.brother.pl                |
#| 172.27.16.134         | https://web6.online.brother.pt                |
#| 172.27.16.134         | https://web6.online.brother.ru                |
#| 172.27.16.134         | https://web6.online.brother.se                |
#| 172.27.16.134         | https://web6.online.brother.fi                |
#| 172.27.16.134         | https://web6.online.brother.be                |
#| 172.27.16.134         | https://web6.online.brother.lu                |
#| 172.27.16.134         | https://web6.online.brother.bg                |
#| 172.27.16.134         | https://web6.online.brother.ro                |
#| 172.27.16.134         | https://web6.online.brother.sk                |
#| 172.27.16.134         | https://web6.online.brother.si                |
#| 172.27.16.134         | http://www.web6.brother.co.uk                 |
#| 172.27.16.134         | http://www.web6.brother.de                    |
#| 172.27.16.134         | http://www.web6.brother.at                    |
#| 172.27.16.134         | http://www.web6.brother.fr                    |
#| 172.27.16.134         | http://www.web6.brother.ie                    |
#| 172.27.16.134         | http://www.web6.brother.it                    |
#| 172.27.16.134         | http://www.web6.brother.nl                    |
#| 172.27.16.134         | http://www.web6.brother.be                    |
#| 172.27.16.134         | http://www.web6.brother.ch                    |
#| 172.27.16.134         | http://www.web6.brother.pt                    |
#| 172.27.16.134         | http://www.web6.brother.es                    |
#| 172.27.16.134         | http://www.web6.brother.dk                    |
#| 172.27.16.134         | http://www.web6.brother.se                    |
#| 172.27.16.134         | http://www.web6.brother.fi                    |
#| 172.27.16.134         | http://www.web6.brother.lu                    |
#| 172.27.16.134         | http://www.web6.brother.lt                    |
#| 172.27.16.134         | http://www.web6.brother.lv                    |
#| 172.27.16.134         | http://www.web6.brother.is                    |
#| 172.27.16.134         | http://www.web6.brother.ee                    |
#| 172.27.16.134         | http://www.web6.brother.cz                    |
#| 172.27.16.134         | http://www.web6.brother.pl                    |
#| 172.27.16.134         | http://www.web6.brother.sk                    |
#| 172.27.16.134         | http://www.web6.brother.si                    |
#| 172.27.16.134         | http://www.web6.brother.hu                    |
#| 172.27.16.134         | http://www.web6.brother.hr                    |
#| 172.27.16.134         | http://www.web6.brother.bg                    |
#| 172.27.16.134         | http://www.web6.brother.ru                    |

#| 10.91.0.131           | http://web1.webconferencing.brother.co.uk     | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.videokonferenzen.brother.at       | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.videokonferenzen.brother.ch       | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.visioconference.brother.ch        | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.videokonferenzen.brother.de       | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.videoconferencia.brother.es       | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.webconference.brother.fr          | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.visioconference.brother.fr        | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.webconferencing.brother.ie        | | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://www.web1.omnijoin.eu                   | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://web1.eu.brother.eu                     | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.131           | http://www.web1.creativecenter.brother.eu     | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.132           | http://www.web2.webconferencing.brother.co.uk | # Site exists but cannot be accessed via web2. reference
#| 10.91.0.132           | http://www.web2.videokonferenzen.brother.at   | # Site exists but cannot be accessed via web2. reference
#| 10.91.0.132           | http://www.web2.videokonferenzen.brother.ch   | # Site exists but cannot be accessed via web2. reference
#| 10.91.0.132           | http://www.web2.visioconference.brother.ch    | # Site exists but cannot be accessed via web2. reference
#| 10.91.0.132           | http://www.web2.videokonferenzen.brother.de   | # Site exists but cannot be accessed via web2. reference
#| 10.91.0.132           | http://www.web2.videoconferencia.brother.es   | # Site exists but cannot be accessed via web2. reference
#| 10.91.0.132           | http://www.web2.webconferencing.brother.ie    | # Site exists but cannot be accessed via web2. reference
#| 10.91.0.132           | http://www.web2.omnijoin.eu                   | # Site exists but cannot be accessed via web2. reference
#| 10.91.0.132           | http://www.web2.eu.brother.eu                 | # Site exists but cannot be accessed via web1. reference
#| 10.91.0.132           | http://web2.creativecenter.brother.eu         | # Site exists but cannot be accessed via web1. reference
#| 172.27.16.133         | http://www.web5.webconferencing.brother.co.uk | # Site exists but cannot be accessed via web5. reference
#| 172.27.16.133         | http://www.web5.videokonferenzen.brother.at   | # Site exists but cannot be accessed via web5. reference
#| 172.27.16.133         | http://www.web5.videokonferenzen.brother.ch   | # Site exists but cannot be accessed via web5. reference
#| 172.27.16.133         | http://www.web5.videokonferenzen.brother.de   | # Site exists but cannot be accessed via web5. reference
#| 172.27.16.133         | http://www.web5.videoconferencia.brother.es   | # Site exists but cannot be accessed via web5. reference
#| 172.27.16.133         | http://www.web5.webconference.brother.fr      | # Site exists but cannot be accessed via web5. reference
#| 172.27.16.133         | http://www.web5.webconferencing.brother.ie    | # Site exists but cannot be accessed via web5. reference
#| 172.27.16.133         | http://www.web5.omnijoin.eu                   | # Site exists but cannot be accessed via web2. reference
#| 172.27.16.133         | http://www.web5.eu.brother.eu                 | # Site exists but cannot be accessed via web1. reference
#| 172.27.16.133         | http://www.web5.creativecenter.brother.eu     | # Site exists but cannot be accessed via web1. reference
#| 172.27.16.134         | http://www.web6.webconferencing.brother.co.uk | # Site exists but cannot be accessed via web6. reference
#| 172.27.16.134         | http://www.web6.videokonferenzen.brother.at   | # Site exists but cannot be accessed via web6. reference
#| 172.27.16.134         | http://www.web6.videokonferenzen.brother.ch   | # Site exists but cannot be accessed via web6. reference
#| 172.27.16.134         | http://www.web6.videokonferenzen.brother.de   | # Site exists but cannot be accessed via web6. reference
#| 172.27.16.134         | http://www.web6.videoconferencia.brother.es   | # Site exists but cannot be accessed via web6. reference
#| 172.27.16.134         | http://www.web6.webconference.brother.fr      | # Site exists but cannot be accessed via web6. reference
#| 172.27.16.134         | http://www.web6.webconferencing.brother.ie    | # Site exists but cannot be accessed via web6. reference
#| 172.27.16.134         | http://www.web6.omnijoin.eu                   | # Site exists but cannot be accessed via web2. reference
#| 172.27.16.134         | http://www.web6.eu.brother.eu                 | # Site exists but cannot be accessed via web1. reference
#| 172.27.16.134         | http://www.web6.creativecenter.brother.eu     | # Site exists but cannot be accessed via web1. reference



Scenario Outline: Test CD servers on Live Environment to check user registration
   Given I navigate to BOL "<Web>" for "<Country>"
	When I have Checked No I Do Not Have An Account Checkbox
	When I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

    And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And Once I have Validated an Email was received and verified my account
	And When I Click Go Back
	Then I should be able to log into "<Country>" Brother Online using my account details
	When I navigate to my account for "<Country>"
	And I enter First Name containing <FirstName>
	And I enter the Last Name containing <LastName>
	And I click on update details
	Then my personal details should get updated
	Then I can navigate back to Brother Online home page
	And I can sign out of Brother Online

Scenarios:
| Country        | Web                               | ServerName | FirstName | LastName |
| Ireland        | https://web1.online.brother.ie    | Web_1      | Test      | User     |
| France         | https://web2.online.brother.ie    | Web_1      | Test      | User     |
| United Kingdom | https://web1.online.brother.co.uk | Web_2      | Test      | User     |
| Netherlands    | https://web2.online.brother.co.uk | Web_2      | Test      | User     |
| Ireland        | https://web5.online.brother.fr    | Web_5      | Test      | User     |
| Belgium        | https://web6.online.brother.fr    | Web_5      | Test      | User     |
| United Kingdom | https://web5.online.brother.de    | Web_5      | Test      | User     |
| Poland         | https://web6.online.brother.de    | Web_6      | Test      | User     |


Scenario Outline: View  list of available Laser Printers 
    Given I navigate to  "<Web>" for "<country>"
	When I have navigated to the "<site>" MainSite URL for country "<country>"
	Then I should see list of printers once loaded page
	#And I can validate that each printer is a valid printer

Scenarios:
| country             | site                                                   | Web                            |
| United Kingdom      | printers/all-mono-lasers                               | http://www.web1.brother.co.uk/ |
| Germany             | drucker/alle-lasergeraete/farblaser                    | http://www.web2.brother.de     |
| France              | imprimantes/imprimantes-laser                          | http://www.web5.brother.fr     |
| Ireland             | printers/laser-printers/mono-laser-printers            | http://www.web6.brother.ie     |
| Netherlands         | printers/laserprinters/zwart-wit                       | http://www.web1.brother.nl     |
| Norway              | printers/all-mono-lasers                               | http://www.web2.brother.no     |
| Belgium             | printers/all-in-one-printers                           | http://www.web5.brother.be     |
| Russia              | printers/laser-printers/mono-laser-printers            | http://www.web6.brother.ru     |
| Spain               | impresoras/impresoras-laser/impresoras-laser-monocromo | http://www.web1.brother.es     |
| Italy               | printers-and-all-in-one/gamma-stampanti                | http://www.web2.brother.it     |
| Poland              | printers/laser-printers/                               | http://www.web1.brother.pl     |
| Switzerland         | drucker/laserdrucker/mono-laser-printers               | http://www.web2.brother.ch     |


@Ignore
Scenario Outline: Create B2C account and sign Up for 14 day Free trial on uk
	Given I navigate to BOL "<Web>" for "<Country>"
	When I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |
	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	Then I should be able to log into "<Web>" and "<Country>" Brother site using my account details
	And I have navigated to the OmniJoin home page
	And If I click on Start Free Trial
    Then I should be directed to the OmniJoin Free Trial page
   When I have entered a valid First and Last name, "AutoTest", "AutoTest"
   And I have entered a valid email address
   And I have entered a valid password and confirmpassword, "Brother123", "Brother123"
   When I have entered a valid phone number "01555 522522"
    And I have Agreed to the Free Trial Terms and Conditions
	And if I click Submit
	Then I should be directed to the download page indicating I have 14 days Free trial
	#And Once I have Validated a Free Trial confirmation Email was received
	#Then If I go back to Brother Online Home Page 
	#Then I can sign out of Brother Online
	#Then I am redirected to the Brother Home Page
	
Scenarios:
| Country        | Web                               |
| United Kingdom | https://web1.online.brother.co.uk |


 
 Scenario Outline: Create a B2C account and Sign Up for 14 day Free trial already signed into Ireland Brother site on Test CD servers Live Environment
	Given I navigate to BOL "<Web>" for "<Country>"
	When I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	Then I should be able to log into "<Country>" Brother Online using my account details
	And I click on Try Now
	Then I should see OmniJOin Free trail page
	When I have entered a valid FirstName as "<FirstName>"
	And I have  entered a valid LastName as "<LastName>"
	And I entered a valid email address
	And I agreed to the free trail terms and services
 	And I click start free trail button
	Then I should be on download page
	And Once I have Validated a Free Trial confirmation Email was received
	Then If I go back to Brother Online Home Page 
	Then If I go back to Brother Site home page on "<Web>" and "<Country>"
	Then I can sign out of Brother Online
	Then I am redirected to the Brother Home Page

Scenarios:
| Country | Web                            | FirstName | LastName |
| Ireland | https://web1.online.brother.ie | Test      | User     |
| Ireland | https://web2.online.brother.ie | Test      | User     |
| Ireland | https://web5.online.brother.ie | Test      | User     |
| Ireland | https://web6.online.brother.ie | Test      | User     |