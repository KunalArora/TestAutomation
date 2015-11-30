@TEST 
Feature: 
	In order to view the Supply Club benefits
	As an anonymous user
	I need to add the supply club product to basket and see the club product benefits

@TEST 
Scenario: View Brother Supply Club product benefits 
	 Given I have navigated to the url "http://it.brotherdv2.eu/supplies/laser/toner/tn/tn2220"
     Then I will see text information relating to the benefit I will receive
	 When I click on Add to basket button
	 Then I hover the mouse on the basket icon to see text information relating to the benefit I will receive
	 #Then I can see the benefit text as  "Discount 11% TN-2220" and "Free Delivery Over £30"
	 Then I can see the product name with the benefits text 