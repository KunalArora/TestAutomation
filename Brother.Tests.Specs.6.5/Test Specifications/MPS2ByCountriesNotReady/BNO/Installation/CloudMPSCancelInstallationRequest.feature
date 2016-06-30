@MPS @UAT @TEST
Feature: CloudMPSNorwegianDealerCancelInstallationRequest
	In order to stop an installer from beginning installation
	As a Dealer 
	I want to be able to cancel installation request


Scenario Outline: Dealer can cancel installation request for Cloud Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I set device installation type as "<Type>"
	And I completed the create installation process for "<Type>"
	Then the installation request for that device is completed
	And I can cancel the above created installation request
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType | UsageType                                 | Role1            | Method | Type | Length | Billing                |
	| Cloud MPS Local Office Approver | Norway  | Buy & Click  | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 3 ans  | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | Norway  | Buy & Click  | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans  | Trimestrale anticipata |
	

Scenario Outline: Local Office Approver can cancel installation request for Email Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved without signing out
	When I navigate to the Local Office Approver device management Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can cancel the above created installation request
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType | UsageType                                 | Role1            | Method | Length | Billing                |
	| Cloud MPS Local Office Approver | Norway  | Buy & Click  | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Email  | 3 ans  | Trimestrale anticipata |
	

Scenario Outline: Local Office can cancel installation request for Cloud Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved without signing out
	When I navigate to the Local Office Approver device management Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I set device installation type as "<Type>"
	And I completed the create installation process for "<Type>"
	Then the installation request for that device is completed
	And I can cancel the above created installation request
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType | UsageType                                 | Role1            | Method | Length | Billing                | Type |
	| Cloud MPS Local Office Approver | Norway  | Buy & Click  | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | 3 ans  | Trimestrale anticipata | Web  |
	| Cloud MPS Local Office Approver | Norway  | Buy & Click  | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | 3 ans  | Trimestrale anticipata | BOR  |
	
	

Scenario Outline: Dealer can cancel installation request for Email Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can cancel the above created installation request
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType | UsageType                                 | Role1            | Method | Length | Billing                |
	| Cloud MPS Local Office Approver | Norway  | Buy & Click  | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Email  | 3 ans  | Trimestrale anticipata |
	