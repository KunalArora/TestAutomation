@TEST @UAT
Feature: Correct printer product listings
	In order to purchase a new Printer
	As a customer
	I want to be able to view the list of available printers

@SMOKE_ProductListings
Scenario Outline: View the list of available Laser Printers on Brother Main sites
	Given I have navigated to the Brother Main Site "<country>" products pages
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	Then I should see a list of Laser printers
#	And I can validate that each printer is a valid printer

Scenarios:
	| country        | site                  |
	| United Kingdom | printers/all-Printers |
#	| Italy   | labelling-machines/home-small-office |
#	| Belgium        | brother-printers/laser-printers?sc_lang=nl-BE               | - language switching problem
#   | Belgium        | imprimantes/imprimantes-laser?sc_lang=fr-BE                 | - language switching problem
#	| Czech          | printers/laser-printers                                     |
#	| Denmark        | printers/all-colour-lasers                                  |
#	| Finland        | printers/laser-printers                                     |
#	| France         | imprimantes/imprimantes-multifonctions/multifonctions-laser |
#	| Germany        | drucker/alle-lasergeraete/monolaser                         | - works differently than all other printer listings
#	| Hungary        | printers/laser-printers                                     |
#	| Ireland        | printers/laser-printers                                     |
#	| Netherlands    | printers/laserprinters                                      |
#	| Norway         | printers/all-colour-lasers                                  |
#	| Poland         | printers/laser-printers                                     |
#	| Romania        | printers/laser-printers                                     |
#	| Russia         | printers/laser-printers                                     | - No printers listed
#	| Slovakia       | printers/laser-printers                                     |
#	| Slovenia       | printers/laser-printers                                     |
#	| Switzerland    | drucker/laserdrucker?sc_lang=de-CH                          | - language switching problem
#	| Switzerland    | imprimantes/imprimantes-laser?sc_lang=fr-CH                 | - language switching problem
#	| United Kingdom | printers/all-mono-lasers                                    |

#Scenario Outline: View the list of available Printers on the Brother Main site Printer Linsting Page
#	Given I have navigated to the Brother Main Site "<country>" products pages
#	Given I have navigated to the "<site>" MainSite URL for country "<country>"
#	Then I should see a list of Laser printers
#	And I can validate that each printer is a valid printer
#	And I can validate that each printer for Spain and Portugal is a valid printer

#Scenarios:
#	| country        | site                  |
	#| Portugal                 | printers/laser-printers   |
	#| Spain                    | impresoras/laser-printers |