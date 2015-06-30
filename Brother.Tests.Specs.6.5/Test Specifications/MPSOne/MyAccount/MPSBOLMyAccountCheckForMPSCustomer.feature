Feature: MPSBOLMyAccountCheckForMPSCustomer
	In order to view the account for an MPS Customer
	As an MPS Customer
	I want to be able to log in to MPS and see My Account


Scenario: Verify my account detail for MPS Customer
	Given I sign into MPS as a "Customer" from "Spain"
	And "Customer" privileges are available for use
	When I navigate to my account for "Spain"
	Then "Customer" invoices should be displayed
