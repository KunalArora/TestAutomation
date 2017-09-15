@MPS @UAT @TEST
Feature: CloudMPSUKDealerCanLogin
	In order to manage my proposals
	As a dealer
	I want to log in to my dashboard

Scenario Outline: MPS Log in to dashboard
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"


@BUKONLY
Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
	
@DYNAMIC_PARAMS
Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |