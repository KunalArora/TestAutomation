@Ignore @TEST @UAT
Feature: OutputContractPDFAllUsers
	In order to view paper version of contract summary
	As an MPS User
	I want to be able to download contract summary


Scenario Outline: Bank can download Contract PDFs
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to bank contract Awaiting Acceptance page





	Scenarios: 
	| Role             | Country        | Role2          |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Bank |
