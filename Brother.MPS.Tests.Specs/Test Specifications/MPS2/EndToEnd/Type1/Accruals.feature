@MPS @UAT @TYPE1 @ENDTOEND
Feature: Type1Accruals
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Dealer
	I want to create a new contract and complete the installation of all devices

Scenario Outline: Accruals
Given Country is "<Country>"
When a Cloud MPS Finance navigate to Accruals Page
And a Cloud MPS Finance select run at date and click run report

@BUK
Scenarios: 
		| Country        | 
		| United Kingdom | 

