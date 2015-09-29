@UAT
Feature: Correct printer product listings
	In order to purchase a new Printer
	As a customer
	I want to be able to view the list of available printers

@UAT
Scenario Outline: View the list of available Laser Printers on Brother Main sites for languages except Spain and Portugal
	Given I have navigated to the Brother Main Site "<country>" products pages
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	Then I should see a list of Laser printers
	And I can validate that each printer is a valid printer

Scenarios:
	| country        | site                                                        |
	| Czech          | printers/laser-printers                                     |
	| France         | imprimantes/imprimantes-multifonctions/multifonctions-laser |
	| Hungary        | printers/laser-printers                                     |
	| Ireland        | printers/laser-printers                                     |
	| Netherlands    | printers/laserprinters                                      |
	| Poland         | printers/laser-printers                                     |
	| Romania        | printers/laser-printers                                     |
	| Slovakia       | printers/laser-printers                                     |
	| Slovenia       | printers/laser-printers                                     |
##	| Belgium        | brother-printers/laser-printers?sc_lang=nl-BE               | - language switching problem
##  | Belgium        | imprimantes/imprimantes-laser?sc_lang=fr-BE                 | - language switching problem
##	| Denmark        | printers/all-colour-lasers                                  |
##	| Germany        | drucker/alle-lasergeraete/monolaser                         | - works differently than all other printer listings
##	| Norway         | printers/all-colour-lasers                                  |
#	| Russia         | printers/laser-printers                                     | - No printers listed
##	| Switzerland    | drucker/laserdrucker?sc_lang=de-CH                          | - language switching problem
##	| Switzerland    | imprimantes/imprimantes-laser?sc_lang=fr-CH                 | - language switching problem
##	| United Kingdom | printers/all-mono-lasers                                    |

# Prod only as the urls are different between DV2,QAS and Production
@PROD @SMOKE
Scenario Outline: View the list of available Printers on some Live Brother Main sites
	Given I have navigated to the Brother Main Site "<country>" products pages
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	Then I should see a list of Laser printers
	And I can validate that each printer is a valid printer

Scenarios:
	| country        | site                                                        |
	| Czech          | printers/laser-printers                                     |
	| Finland        | printers/printers/mono-laser-printers                       |
	| France         | imprimantes/imprimantes-multifonctions/multifonctions-laser |
	| Hungary        | printers/laser-printers                                     |
	| Ireland        | printers/laser-printers                                     |
	| Netherlands    | printers/laserprinters                                      |
	| Poland         | printers/laser-printers                                     |
	| Romania        | printers/laser-printers                                     |
	| Slovakia       | printers/laser-printers                                     |
	| Slovenia       | printers/laser-printers                                     |
	| Denmark        | printers/all-mono-lasers                                    |
	| Norway         | printers/all-colour-lasers                                  |
	| Russia         | printers/laser-printers                                     |
	| United Kingdom | printers/all-mono-lasers                                    |	 
##	| Belgium        | brother-printers/laser-printers?sc_lang=nl-BE               | - language switching problem
##  | Belgium        | imprimantes/imprimantes-laser?sc_lang=fr-BE                 | - language switching problem
##	| Germany        | drucker/alle-lasergeraete/monolaser                         | - works differently than all other printer listings
##	| Switzerland    | drucker/laserdrucker?sc_lang=de-CH                          | - language switching problem
##	| Switzerland    | imprimantes/imprimantes-laser?sc_lang=fr-CH                 | - language switching problem


@SMOKE @ignore
Scenario Outline: View the list of available Laser Printers on Brother Main sites for Spain and Portugal
	Given I have navigated to the Brother Main Site "<country>" products pages
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	Then I should see a list of Laser printers
	And I can validate that each printer for Spain and Portugal is a valid printer

Scenarios:
	| country  | site                      |
	| Portugal | printers/laser-printers   |
	| Spain    | impresoras/laser-printers |
