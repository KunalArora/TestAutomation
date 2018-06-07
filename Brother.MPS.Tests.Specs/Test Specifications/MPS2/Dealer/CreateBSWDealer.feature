﻿@MPS @UAT @TYPE1 @TYPE3 @HIGH @DEALERCREATION @CI_TestMaintenance
Feature: CreateDealer
	In order to sell Cloud MPS services to customers
	As a Cloud MPS Local Office Admin
	I want to create a new dealer 

Scenario Outline: CreateDealer
Given I navigate to the administration page with culture "<Culture>" from "<Country>"
When I create a new dealer and verify the created dealer details
And I edit the details for created dealer
Then a newly created Cloud MPS dealer can succesfully login with culture "<Culture>" from "<Country>"
And a created Cloud MPS dealer can verify the dashboard icons properly shown

#@BSW
#Scenarios: 
#		| Country        | Culture |
#		| Switzerland    | fr-CH   |

@BUK
Scenarios: 
		| Country        | Culture |
		| United Kingdom |         |
