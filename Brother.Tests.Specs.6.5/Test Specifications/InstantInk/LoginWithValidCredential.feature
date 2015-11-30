@ignore @TEST
Feature: Log in to Ink with valid user
	In order to utilise the Status Monitor feature
	As a valid user
	I need to login to BOL and see the status monitor screen


Background: Create an account on BOL and add Ink Supply user role to it
	 Given I am logged onto "United Kingdom" BOL with "inktestmarko@mailinator.com" username and "Password999" password
#user doesnt exist anymore
@ignore @TEST
Scenario:Validate a valid user can sign in to Ink
	And I can see the Ink Supply menu option from the Bol home page
	When I click Ink Supply button
    And I can see the Ink Supply header with name "Status Monitor"
	Then device name "MFC-J5720DW"should be displayed
	Then device serial number "E73183G4F387882" should be displayed
	Then I can sign out of Brother Online
