Feature: SignInAsASalesDealer
	In order to use MPS One successfully
	As a dealer
	I want to be able to sign in to MPS

Scenario: Sign in to MPS one as a Sales Dealer

	Given I launch Brother Online for "Spain"
	When I click on Sign In / Create An Account for "Spain"
	When I sign in as a "Sales Dealer" from "Spain"
	Then I am signed in with "Dealer" priviledges
