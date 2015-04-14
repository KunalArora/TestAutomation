@UAT
Feature: MPSBOLMyAccountCheckMPSSalesDealer
	In order to view the account for an MPS Sales Dealer
	As an MPS Sales Dealer
	I want to be able to log in to MPS and see My Account


Scenario: Verify my account detail for MPS Sales Dealer
	Given I sign into MPS as a "Sales Dealer" from "Spain"
	And "Sales Dealer" privileges are available for use
	When I navigate to my account for "Spain"
	Then "Sales Dealer" invoices should be displayed
