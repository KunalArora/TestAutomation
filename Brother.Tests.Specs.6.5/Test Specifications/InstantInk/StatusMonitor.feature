@ignore
Feature: Validate User Roles with Ink Supply
	In order to utilise the Status Monitor feature
	As a user
	I need to be granted the correct role to see the status of my printer


Background: Create an account on BOL and add Ink Supply user role to it
	Given I am logged onto Brother Online "United Kingdom" using valid credentials	

@ignore
Scenario:Validate when clicking on "Status Monitor" the user should be able to see what device have been set up against "Brother Ink Supply"
    Given I have been granted the user account with the "Extranet\Brother Online Ink Supply User" role	
	Then If I click on My Account menu
	Then I can see the Ink Supply menu option from the Bol home page
	And Ink Supply is clicked
    Then I can see the Ink Supply Status Monitor button
	When I click on Status Monitor
	Then I can see the Status Monitor page
	And I can navigate back to Brother Online home page
	Then I can sign out of Brother Online
	


