@MPS @UAT @DEV @TYPE1 @PARTIALSCENARIOS
Feature: LoginAsDealer
	In order to view the dashboard
	As a Cloud MPS Dealer
	I want to login to MPS

Scenario Outline: Login as dealer
Given I have navigated to the Create Proposal page as a Cloud MPS Dealer from "<Country>"

Scenarios: 
		| Country        |
		| United Kingdom |