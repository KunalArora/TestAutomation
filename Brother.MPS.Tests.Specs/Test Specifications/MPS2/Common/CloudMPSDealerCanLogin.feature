@MPS @UAT @TEST
Feature: CloudMPSUKDealerCanLogin
	In order to manage my proposals
	As a dealer
	I want to log in to my dashboard

Scenario Outline: MPS Log in to dashboard
	Given I sign into Cloud MPS as a type "<BusinessType>" "<Role>" from "<Country>"
	Given I sign into Cloud MPS as a type "<BusinessType>" "Cloud MPS Local Office Approver" from "<Country>"


@BUKONLY
Scenarios: 
	| Role             | Country        |BusinessType	|
	| Cloud MPS Dealer | United Kingdom |3				|
	
@DYNAMIC_PARAMS
Scenarios: 
	| Role             | Country | BusinessType |
	| Cloud MPS Dealer | Ireland | 1            |