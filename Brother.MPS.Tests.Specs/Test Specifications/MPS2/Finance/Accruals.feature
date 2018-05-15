@MPS @UAT @TYPE1 @HIGH
Feature: Type1Accruals
	In order to verify the finance of Cloud MPS service
	As a Cloud MPS Finance
	I can generate the financial reports and verify the content

Scenario Outline: Accruals
Given Country is "<Country>"
When a Cloud MPS Finance navigate to Accruals Page
And a Cloud MPS Finance select run at date and click run report

@BUK
Scenarios: 
		| Country        | 
		| United Kingdom | 

