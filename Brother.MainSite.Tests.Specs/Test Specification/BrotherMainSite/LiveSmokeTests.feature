@PROD
Feature: All sites on all Webservers are Up and Running
	In order to purchase a new brother item
	As a customer
	I want to be able to browse through brother website

@ACCESSIBILITY
Scenario Outline: Verify the home page for all brother domains are loading properly
	Given I have navigated to the "<Country>" Brother Main Site
	Then I shold see the tilte of the page is displayed
	#And the slides on the home page are displayed properly
	And the footer of the home page is displayed properly
Scenarios:
	| Country        |
	| United Kingdom |
	| France         |
	| Italy          |
	| Netherlands    |
	| Spain          |
	| Denmark        |
	| Norway         |
	| Sweden         |
	| Finland        |
	| Estonia        |
	| Iceland        |
	| Latvia         |
	| Portugal       |
	| Germany        |
	| Austria        |
	| Poland         |
	| Romania        |
	| Czech Republic |
	| Slovakia       |
	| Slovenia       |
	| Hungary        |

@ACCESSIBILITY
Scenario Outline: Verify that the printer listing page is displayed with the list of printers
	Given I have navigated to the "<Country>" Brother Main Site
	And I navigated to the "<Country>" all printers page "<PageUrl>"
	Then I should see a list of all printers loaded
Scenarios:
	| Country        | PageUrl                                    |
	| United Kingdom | printers/all-Printers                      |
	| Denmark        | printers/all-printers                      |
	| Norway         | printers/all-printers                      |
	| Sweden         | printers/all-printers                      |
	| Finland        | printers/all-printers                      |
	| Estonia        | printers/all-printers                      |
	| Iceland        | printers/all-printers                      |
	| Poland         | printers/all-printers                      |
	| Romania        | printers/all-printers                      |
	| Czech Republic | printers/all-printers                      |
	| Slovakia       | printers/all-printers                      |
	| Slovenia       | printers/all-printers                      |
	| Hungary        | printers/all-printers                      |
	| Netherlands    | printers/all-in-ones                       |
	| France         | imprimantes/imprimantes-laser              |
	| Italy          | printers-and-all-in-one/lasermono-printers |
	| Spain          | multifuncion/gama-completa                 |
	| Portugal       | multifuncoes/gama-impressoras-multifuncoes |
	| Latvia         | printeri/visi-printeri                     |