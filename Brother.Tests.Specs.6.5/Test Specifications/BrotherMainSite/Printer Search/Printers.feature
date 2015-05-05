@UAT @PROD
Feature: Correct printer product listings
	In order to purchase a new Printer
	As a customer
	I want to be able to view the list of available printers

@SMOKE
Scenario Outline: View the list of available Laser Printers on Brother Main sites for languages except Spain and Portugal
	Given I have navigated to the Brother Main Site "<country>" products pages
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	Then I should see a list of Laser printers
	And I can validate that each printer is a valid printer

Scenarios:
	| country     | site                                                        |
	| Ireland     | printers/laser-printers                                     |
	| Belgium     | brother-printers/laser-printers?sc_lang=nl-BE               |
	| Belgium     | imprimantes/imprimantes-laser?sc_lang=fr-BE                 |
	| Slovakia    | printers/laser-printers                                     |
	| Netherlands | printers/laserprinters                                      |
	| Denmark     | printers/all-colour-lasers                                  |
	| Hungary     | printers/laser-printers                                     |
	| France      | imprimantes/imprimantes-multifonctions/multifonctions-laser |
	| Czech       | printers/laser-printers                                     |
	| Poland      | printers/laser-printers                                     |
	| Finland     | printers/laser-printers                                     |
	| Slovenia    | printers/laser-printers                                     |
	| Norway      | printers/all-colour-lasers                                  |
	| Russia      | printers/laser-printers                                     |
	| Germany     | drucker/alle-lasergeraete/monolaser                         |
#(specialCase)	| United Kingdom | printers/all-mono-lasers |
	| Switzerland | drucker/laserdrucker?sc_lang=de-CH                          |
	| Switzerland | imprimantes/imprimantes-laser?sc_lang=fr-CH                 |
	| Romania     | printers/laser-printers                                     |

@SMOKE
Scenario Outline: View the list of available Laser Printers on Brother Main sites for Spain and Portugal
	Given I have navigated to the Brother Main Site "<country>" products pages
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	Then I should see a list of Laser printers
	And I can validate that each printer for Spain and Portugal is a valid printer

Scenarios:
	| country  | site                      |
	| Portugal | printers/laser-printers   |
	| Spain    | impresoras/laser-printers |
