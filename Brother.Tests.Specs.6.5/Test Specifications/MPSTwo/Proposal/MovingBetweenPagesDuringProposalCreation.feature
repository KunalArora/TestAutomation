@Ignore
Feature: MovingBetweenPagesDuringProposalCreation
	In order to correct an earlier entered value on a previous page
	As an MPS Dealer
	I want to the ability to return the previous page and still be presented with the earlier enter values for correction


Scenario: It should be possible to return back to Proposal Description from Summary screen
	Given I am on MPS New Proposal Summary Screen
	When I click the back button on Proposal Summary Screen
	Then I am redirected to Products screen with earlier selected printer
	And I can go back to "Term & Type" screen which retain earlier selected values
	And I can go back to "Customer Information" screen which retain earlier selected values
	And I can go back to "Proposal Description" screen which retain earlier selected values
	And I can still create a proposal with the information above

