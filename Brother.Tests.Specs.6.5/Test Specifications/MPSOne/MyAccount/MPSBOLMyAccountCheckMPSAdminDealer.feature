@UAT
Feature: MPSBOLMyAccountCheckMPSAdminDealer
	In order to view the account for an Admin Dealer
	As an MPS Admin Dealer
	I want to be able to log in to MPS and see My Account

Scenario: Verify my account detail for Admin Dealer
	Given I sign into MPS as a "Dealer" from "Spain"
	And "Dealer" privileges are available for use
	When I navigate to my account for "Spain"
	Then "Dealer" invoices should be displayed
