@MPS @UAT @TEST @BIEPC110
Feature: CloudMPSCreateAContractWithExistingUKCustomer
	In order to work with customer run portion
	As a dealer
	I want to be able to create a contract with an existing customer


Scenario Outline: MPS Existing Customer For Run Action
	Given "<Country>" Dealer have created "<ContractType>" contract choosing "<ExistingCustomer>" with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I install the device on the contract with "<Method>" communication and "<Type>" installation 
	And I can sign out of Brother Online
	And I navigate to the Invoice tool homepage
	And I refresh daily print counts
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to Print Count page
	Then the print counts attached to the device are correct
	And I sign out of Cloud MPS

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type | ExistingCustomer                      | Length  | Billing              | Role2              |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | Lashonda20170412013818@mailinator.com | 3 years | Quarterly in Arrears | Cloud MPS Customer |


Scenario Outline: MPS Existing Customer Consumable Actions
	Given "<Country>" Dealer have created "<ContractType>" contract choosing "<ExistingCustomer>" with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I install the device with "<SerialNumber>" on the contract with "<Method>" communication and "<Type>" installation 
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for "<SerialNumber>"
	And I change the ordering procedure to automatic
	And I create a consumable order for "Cyan"
	And I sign out of Cloud MPS

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type | ExistingCustomer                   | Length  | Billing              |  SerialNumber |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | Randi20161010065802@mailinator.com | 3 years | Quarterly in Arrears |  A1T010265    |
	