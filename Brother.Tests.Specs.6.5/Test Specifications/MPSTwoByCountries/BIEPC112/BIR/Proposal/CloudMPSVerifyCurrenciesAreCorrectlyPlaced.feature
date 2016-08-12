Feature: CloudMPSVerifyIrishCurrenciesAreCorrectlyPlaced
	In order to ensure that currency symbol is rightly placed for each country
	As a math MPS Dealer
	I want to check that all currency symbols are in the right positions


Scenario: Verify that Irish currency is in front of all values
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
