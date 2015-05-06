﻿@UAT @PROD
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
	| country        | site                                                        |
	| Belgium        | brother-printers/laser-printers?sc_lang=nl-BE               |
	| Belgium        | imprimantes/imprimantes-laser?sc_lang=fr-BE                 |
	| Czech          | printers/laser-printers                                     |
	| Denmark        | printers/all-colour-lasers                                  |
	| Finland        | printers/laser-printers                                     |
	| France         | imprimantes/imprimantes-multifonctions/multifonctions-laser |
	| Germany        | drucker/alle-lasergeraete/monolaser                         |
	| Hungary        | printers/laser-printers                                     |
	| Ireland        | printers/laser-printers                                     |
	| Netherlands    | printers/laserprinters                                      |
	| Norway         | printers/all-colour-lasers                                  |
	| Poland         | printers/laser-printers                                     |
	| Romania        | printers/laser-printers                                     |
	| Russia         | printers/laser-printers                                     |
	| Slovakia       | printers/laser-printers                                     |
	| Slovenia       | printers/laser-printers                                     |
	| Switzerland    | drucker/laserdrucker?sc_lang=de-CH                          |
	| Switzerland    | imprimantes/imprimantes-laser?sc_lang=fr-CH                 |
	| United Kingdom | printers/all-mono-lasers                                    |

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
