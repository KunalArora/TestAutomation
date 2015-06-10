@Ignore @TEST @UAT
Feature: DealerCanSignContract
	In order to progress an approved proposal to contract
	As a dealer
	I want to be able to sign an approve proposal


Scenario: Dealer Can Sign A Leasing And Click Contract
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
