@UAT @TEST
Feature: Validate User Roles with Ink Supply
	In order to utilise the Status Monitor feature
	As a user
	I need to be granted the correct role to see the status of my printer


Background: 
Create an account on BOL and add Ink Supply user role to it
 #Given I am logged onto BOL
 Given I am logged onto Brother Online "United Kingdom" using valid credentials	

@TEST
Scenario:Validate when clicking on "Status Monitor" the user should be able to see what device have been set up against "Brother Ink Supply"
    Given I have been granted the user account with the "Extranet\Brother Online Ink Supply User" role	
	#Given that I have an Ink Supply role to my Bol account
	Then If I click on My Account menu
	Then I can see the Ink Supply menu option from the Bol home page
	And Ink Supply is clicked
    Then I can see the Ink Supply Status Monitor button
	When I click on Status Monitor
	Then I can see the Status Monitor page
	#When there is an online connected device
	#Then device name should be displayed 
	#Then the device nw status should be shown as online 
	#Then the device serial no. should be displayed.
	#Then the device contract should be displayed.
	And I can navigate back to Brother Online home page
	Then I can sign out of Brother Online
	


	#When the device is offline connected device
	#Then the status is shown as offline.
	#Then the serial no. should be displayed.
	#Then the product title should be displayed.
	#When no device is found for the user
	#Then a message should be displayed to inform the user.
	#Then no status details should be displayed.
	
