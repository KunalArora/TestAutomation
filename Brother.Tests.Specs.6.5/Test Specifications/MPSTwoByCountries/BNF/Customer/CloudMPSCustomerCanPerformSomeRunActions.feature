@ignore @TEST @UAT @MPS
Feature: FinnishCustomerCanPerformSomeRunActions
	In order for customer to perform some run portion actions
	As a customer
	I want to be to sign in using my newly generated credentials


Scenario Outline: Customer cannot order consumable before initial communication with device
	#Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	#And I sign into Cloud MPS as a "<Role>" from "<Country>"
	#And the contract created above is approved
	#And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	#And I installed the device in the contract through "<Method>"
	#And I can sign out of Brother Online
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page
	Then it is not possible to order a consumable
	And I can sign out of Brother Online
	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Role2              |
	| Cloud MPS Local Office Approver | Finland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  | Cloud MPS Customer |
	


Scenario Outline: Customer can order consumable after initial communication with device
	Given I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page
	When I order consumables for the device
	Then the newly ordered consumable order has correct details
	And the newly created consumable order has correct details in pop up information
	And the consumable ordered can be successfully progressed
	And I can sign out of Brother Online
	
Scenarios:

	| Role               | Country |
	| Cloud MPS Customer | Finland |
	
