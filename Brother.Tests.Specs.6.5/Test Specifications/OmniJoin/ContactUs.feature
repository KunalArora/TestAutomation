Feature: ContactUs
	In order to report feedback to customer support
	As a customer
	I need to fill in relevant details into the Contact Us form

@ignore
Scenario: Validate the First and Last name fields accept more than 20 characters
	Given I have navigated to the OmniJoin WebConferencing Home Page
	And I have clicked on Buy
	Then If I click on Contact Us
	Then I can validate that I can enter a First Name longer than 20 characters
	And I can validate that I can enter a Last Name longer than 20 characters
	
	
