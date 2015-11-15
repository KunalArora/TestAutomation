@TEST @UAT @MPS
Feature: CustomerCanPerformSomeRunActions
	In order for customer to perform some run portion actions
	As a customer
	I want to be to sign in using my newly generated credentials


Scenario Outline: Installer can progress with installation for Email Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I installed the device in the contract through "<Method>"
	And I can sign out of Brother Online
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page
	Then it is not possible to order a consumable
	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Role2              |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  | Cloud MPS Customer |


Scenario Outline: German And Austria Installer can progress with installation for Email Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I installed the device in the contract through "<Method>"
	And I can sign out of Brother Online
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page
	Then it is not possible to order a consumable

	
Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method | Role2              |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  | Cloud MPS Customer |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  | Cloud MPS Customer |
