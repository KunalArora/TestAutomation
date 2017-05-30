@MPS @UAT @TEST @BIEPC112
Feature: CloudMPSCreateAContractWithExistingBelgianCustomer
	In order to work with customer run portion
	As a dealer
	I want to be able to create a contract with an existing customer


Scenario Outline: MPS Existing Customer For Run Action
	Given "<Country>" Dealer with "<Language>" have created "<ContractType>" contract choosing "<ExistingCustomer>" with "<UsageType>" and "<Length>" and "<Billing>"
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

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | ExistingCustomer                 | Length | Billing                                                            | Role2              | Language |
	| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | BOR  | Omer2017043222810@mailinator.com | 4 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | Cloud MPS Customer | French   |
	| Cloud MPS Local Office Approver | Belgium | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | Omer2017043222810@mailinator.com | 3 jaar | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | Cloud MPS Customer | Dutch    |
	