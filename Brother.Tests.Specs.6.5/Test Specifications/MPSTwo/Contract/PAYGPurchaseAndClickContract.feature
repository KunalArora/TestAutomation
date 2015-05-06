@Ignore @TEST @UAT
Feature: PAYGPurchaseAndClickContract
	In order to create a PAYG Purchase and Click contract
	As a Dealer I want to be able to create a PAYG Purchase and Click proposal and convert the proposal to contract
	So that I am able provide more value to the different customers


Scenario: Convert Purchase and Click Proposal to Contract
	Given I sign into Cloud MPS as a "Cloud MPS Local Office" from "Germany"
	And I navigate to Local Office Admin Dashboard page
	And I enable Easy Print Pro contract
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "Cloud MPS Dealer" from "Germany"
	And I navigate to Dealer Dashboard page
	And I am on MPS New Proposal Page
	And I fill Proposal Description for "Purchase-and-Click" program
	And I enter Customer Information Detail for new customer
	And I Enter "Pay As You Go" usage type "3 Jahre" contract length and "3 Monatlich" billing on Term and Type details
	And I choose "DCP-L2500D" from Products screen
	And I type in click price volume of "1500"
	And I click Save Proposal button on Summary screen
	Then I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I can sign out of Brother Online
	And I start the contract conversion process
	And I add a date to the proposal 
	And I save the proposal as a contract
	And the newly converted contract is available on Ready for Bank screen
