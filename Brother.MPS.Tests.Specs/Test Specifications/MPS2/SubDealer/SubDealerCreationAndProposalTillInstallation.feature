@MPS @UAT @HIGH @TYPE1
Feature: SubDealerCreationAndProposalTillInstallation
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new sub dealer, then a proposal under this sub dealer and complete the installation of all devices

Scenario Outline: SubDealerCreationAndProposalTillInstallation
Given I have navigated to the Dealership User page in admin tab as a Cloud MPS Dealer from "<Country>"
When I create a new sub dealer
Then I can verify that the Sub dealer is successfully created
Given I have navigated to the create proposal page as a Sub dealer from "<Country>"

@BUK
Scenarios: 
		| Country        |
		| United Kingdom |
		