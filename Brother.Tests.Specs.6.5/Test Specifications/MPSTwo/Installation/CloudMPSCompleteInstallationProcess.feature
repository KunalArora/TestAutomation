@ignore @MPS @UAT @TEST
Feature: CloudMPSCompleteInstallationProcess
	In order to get an installer to begin installation
	As a Dealer 
	I want to be able to complete installation


Scenario Outline: Dealer can create installation request for Cloud Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I set device installation type as "<Type>"
	And I completed the create installation process for "<Type>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |




Scenario Outline: Dealer can create installation request for Cloud Communication for other countries
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
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                      | UsageType                                 | Role1            | Method | Type | Length | Billing                |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 3 ans  | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans  | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 36     | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Cloud  | Web  | 48     | Trimestrale anticipata |
	



Scenario Outline: Dealer can create installation request for Email Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  |



Scenario Outline: German and Austria Dealer can create installation request for Cloud Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I set device installation type as "<Type>"
	And I completed the create installation process for "<Type>"
	Then the installation request for that device is completed 
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |
	| Cloud MPS Bank                  | Germany | Leasing & Service        | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |
	| Cloud MPS Bank                  | Austria | Leasing & Service        | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	
	
	


Scenario Outline: German and Austria Dealer can create installation request for Email Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  |
	


Scenario Outline: German and Austria Dealer can create installation request for Email Communication after the contract has been signed
	Given German Dealer have created a signed "<Country>" contract of "<ContractType>" and "<UsageType>"
	When I navigate to the signed contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  |
	
	


Scenario Outline: German and Austria Local Office Approver can create installation request for Email Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved without signing out
	When I navigate to the Local Office Approver device management Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  |
	


Scenario Outline: Local Office can create installation request for Cloud Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved without signing out
	When I navigate to the Local Office Approver device management Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I set device installation type as "<Type>"
	And I completed the create installation process for "<Type>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |


Scenario Outline: Local Office Approver can create installation request for Email Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved without signing out
	When I navigate to the Local Office Approver device management Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  |



Scenario Outline: Local Office Approver can create installation request for Email Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved without signing out
	When I navigate to the Local Office Approver device management Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType                      | UsageType                                 | Role1            | Method | Length | Billing                |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Email  | 3 ans  | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Email  | 36     | Trimestrale anticipata |
	

Scenario Outline: Local Office can create installation request for Cloud Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved without signing out
	When I navigate to the Local Office Approver device management Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I set device installation type as "<Type>"
	And I completed the create installation process for "<Type>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                      | UsageType                                 | Role1            | Method | Length | Billing                | Type |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | 3 ans  | Trimestrale anticipata | Web  |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | 3 ans  | Trimestrale anticipata | BOR  |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Cloud  | 36     | Quarterly in Advance   | Web  |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Cloud  | 48     | Quarterly in Advance   | BOR  |
	

Scenario Outline: Dealer can create installation request for Email Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I navigate to the contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                      | UsageType                                 | Role1            | Method | Length | Billing                |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Email  | 3 ans  | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Email  | 36     | Quarterly in Advance   |
	