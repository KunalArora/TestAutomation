@MPS @TEST @UAT
Feature: CloudMPSUKDealerCanUpdateProfile
	In order to personalise detail
	As a dealer
	I want to be able to add dealer profile


Scenario Outline: Dealer can successfully add profile
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Admin page using tab
	And I navigate to Dealership Profile page
	When I enter new profile into the profile box
	And I save the profile
	Then the new profile is same as the recently entered profile
	And I sign out of Cloud MPS


	Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom | 



