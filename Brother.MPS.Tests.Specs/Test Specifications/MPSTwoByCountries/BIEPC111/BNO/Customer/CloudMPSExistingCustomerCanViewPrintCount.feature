@MPS @UAT @TEST @BIEPC111
Feature: CloudMPSCreateAContractWithExistingNorwegianCustomer
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
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to Print Count page
	Then the print counts attached to the device are correct
	And I sign out of Cloud MPS

	
Scenarios:

	| Role                            | Country | ContractType              | UsageType     | Role1            | Method | Type | ExistingCustomer                    | Length | Billing              | Role2              |
	| Cloud MPS Local Office Approver | Norway  | Kjøp og klikk med service | Minimum volum | Cloud MPS Dealer | Cloud  | Web  | Belkis20161011002004@mailinator.com | 36     | Quarterly in Arrears | Cloud MPS Customer |
	