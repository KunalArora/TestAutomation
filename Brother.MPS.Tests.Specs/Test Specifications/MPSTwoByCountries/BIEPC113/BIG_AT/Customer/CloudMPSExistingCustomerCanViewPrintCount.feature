@MPS @UAT @TEST @BIEPC113
Feature: CloudMPSCreateAContractWithExistingGermanCustomer
	In order to work with customer run portion
	As a dealer
	I want to be able to create a contract with an existing customer

Scenario Outline: MPS Existing Customer For Run Action
	Given "<Country>" Dealer have created a "<ContractType>" contract choosing "<UsageType>" with "<ExistingCustomer>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I install the device on the contract with "<Method>" communication and "<Type>" installation 
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to Print Count page
	Then the print counts attached to the device are correct
	And I sign out of Cloud MPS

	
Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method | Type | ExistingCustomer                     | Role2              |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | Web  | Arnulfo20170410213539@mailinator.com | Cloud MPS Customer |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | Web  | Roxanna20170413013130@mailinator.com | Cloud MPS Customer |
	