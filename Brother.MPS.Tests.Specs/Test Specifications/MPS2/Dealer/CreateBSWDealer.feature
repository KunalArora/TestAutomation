@MPS @UAT @TYPE1 @TYPE3 @HIGH @DEALERCREATION @CI_TestMaintenance
Feature: CreateBSWDealer
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Local Office Admin
	I want to create a dealer for bsw-french

Scenario Outline: CreateBSWDealer
Given I navigate to the administration page with culture "<Culture>" from "<Country>"
When I create a new dealer and verify the created dealer details
And I edit the details for created dealer
Then a newly created Cloud MPS dealer can succesfully login with culture "<Culture>" from "<Country>"

@BSW
Scenarios: 
		| Country        | Culture |
		| Switzerland    | fr-CH   |