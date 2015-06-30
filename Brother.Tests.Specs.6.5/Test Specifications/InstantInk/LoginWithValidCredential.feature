@TEST
Feature: Log in to Ink with valid user
	In order to utilise the Status Monitor feature
	As a valid user
	I need to login to BOL and see the status monitor screen


Background: 
Create an account on BOL and add Ink Supply user role to it
	 Given I am logged onto "United Kingdom" BOL with "inktestmarko@mailinator.com" username and "Password999" password
	 #Given I am logged onto Brother Online "United Kingdom" using valid credentials	

@TEST
Scenario:Validate a valid user can sign in to Ink
   
	And I can see the Ink Supply menu option from the Bol home page
	When I click Ink Supply button
    And I can see the Ink Supply header with name "Status Monitor"
	#And I click on the Status Monitor
	#Then I can see the Status Monitor page
	#When there is an online connected device
	#Then device name should be displayed 
	Then device name "MFC-J5720DW"should be displayed 
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
	
