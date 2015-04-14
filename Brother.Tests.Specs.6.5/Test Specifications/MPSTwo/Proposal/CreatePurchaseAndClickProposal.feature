@TEST @UAT
Feature: CreatePurchaseAndClickProposal
	In order to create Purchase and Click contract type
	As a Dealer I want to be able to create an Purchase and Click proposal
	So that I am able to give customers multiple contract options


Scenario: Create an Purchase and Click Proposal type
	Given I sign into Cloud MPS as a "Cloud MPS Local Office" from "Germany"
	And I navigate to Local Office Admin Dashboard page
	And I enable Easy Print Pro contract
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "Cloud MPS Dealer" from "Germany"
	And I navigate to Dealer Dashboard page
	And I am on MPS New Proposal Page
	And I fill Proposal Description for "Purchase-and-Click" program
	And I enter Customer Information Detail for new customer
	And I Enter "Mindestvolumen" usage type "3 Jahre" contract length and "3 Monatlich Mindestvolumen" billing on Term and Type details
	And I choose "DCP-L2520DW" from Products screen
	And I select click price volume of "1500"
	And I click Save Proposal button on Summary screen
	Then I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I can sign out of Brother Online



