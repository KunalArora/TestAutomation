@Ignore
Feature: MPSContractSearch
	In order to select a specific contract from a list
	As a math an MPS Dealer
	I want to be able to search for contract with some criteria


Background: Navigate to Contract Page
	Given I sign into MPS as a "Dealer" from "Spain"
	And I navigate to "Contract" page from "Spain" Welcome page

Scenario Outline: Search for contract with different contract elements

	When I search for a contract element '<value>'
	Then that contract '<element>' of '<value>' should be displayed

	Examples: 
	| element	| value   |
	| Id		| 1004758 |
	| Name		| Greece  |
	

Scenario Outline: Search for contract using multiple contract elements
	When I filter contracts using contract status '<status>'
	And the result for the contract status '<status>' is displayed
	And I filter those contracts above using organisation '<organisation>'
	Then the result is filtered more to only show organisation '<organisation>' with contract status '<status>'

	Examples: 
	| status           | organisation |
	| Contract created | 1216         |