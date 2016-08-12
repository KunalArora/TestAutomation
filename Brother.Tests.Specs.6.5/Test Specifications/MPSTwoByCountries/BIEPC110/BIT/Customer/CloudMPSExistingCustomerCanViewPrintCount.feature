﻿@MPS @UAT @TEST
Feature: CloudMPSCreateAContractWithExistingItalianCustomer
	In order to work with customer run portion
	As a dealer
	I want to be able to create a contract with an existing customer


Scenario Outline: Existing Belgian Customer can be used to create a new contract for Run purpose
	Given "<Country>" Dealer have created "<ContractType>" contract choosing "<ExistingCustomer>" with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I install the device on the contract with "<Method>" communication and "<Type>" installation 
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to Print Count page
	Then the print counts attached to the device are correct
	And I sign out of Cloud MPS

	
Scenarios:

	| Role                            | Country | ContractType                      | UsageType     | Role1            | Method | Type | ExistingCustomer                 | Length | Billing                | Role2              |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo | Cloud MPS Dealer | Cloud  | Web  | Colonial Avenue_160322121421 Ltd | 36     | Trimestrale anticipata | Cloud MPS Customer |
	