@Ignore @UAT
Feature: MPSAuthorisedDealerAccountSetupPortalAuthorisationCheckADMINDealer
	In order to navigate to Contract Overview page
	As a Dealer
	I want to be able sign in with relevant privileges that will enable me to view contract


Scenario: Portal Authotization Check - Dealer 
	Given I sign into MPS as a "Dealer" from "Spain"
	And "Dealer" privileges are available for use
	When I navigate to "Contract" page from "Spain" Welcome page
	Then "Contract" page is displayed 
	And I can get to "Spain" contract overview page for the contract