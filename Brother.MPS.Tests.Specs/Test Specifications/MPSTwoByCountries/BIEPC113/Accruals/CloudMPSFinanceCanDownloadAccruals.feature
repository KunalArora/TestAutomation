@ignore @UAT @MPS @TEST @HIGH
Feature: CloudMPSFinanceCanDownloadAccruals
	In order to know how much have been accrued
	As a Finance Role
	I want the ability to download Accruals spreadsheet


Scenario Outline: Finance can download Accrual Spreadsheet
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver Reporting page
	And Approver navigate to Data Query page
	And I click on the first proposal link displayed
	And I click on Edit Comment button on summary page
	And I enter "<Text>" in the comment box
	Then the "<Text>" added to the comment box is displayed on summary page
	And I sign out of Cloud MPS

	Scenarios: 
	| Role              | Country     | Text                                             |
	| Cloud MPS Finance | Switzerland | Test Automation created this for testing purpose |
	