@ignore
Feature: In order to view the Supply Club benefits on any environment
	As an anonymous user
	I need to add the supply club product to basket and see the club product benefits

@ignore
Scenario: View Brother Supply Club product benefits on any environment
	Given I have navigated to the Brother Main Site "Italy" products pages
	And I have clicked on Supplies
	And I have entered my valid supplies code for an InkJet cartridge "TN2220"
	When I click on search for supply "TN2220"
	Then I will see text information relating to the benefit I will receive
	When I click on Add to basket button
	Then I hover the mouse on the basket icon to see text information relating to the benefit I will receive
	#Then I can see the benefit text as  "Discount 11% TN-2220" and "Free Delivery Over £30"
	#Then I can see the benefit text as  "Sconto 10% TN-2220" and "Spedizione gratuita sopra i 30€"
	Then I can see the product name with the benefits text 

	
