﻿@MPS @UAT @TEST
Feature: CloudMPSCancelInstallationRequestForSmokeTest
	In order to stop an installer from beginning installation
	As a Dealer 
	I want to be able to cancel installation request


Scenario Outline: Dealer can cancel installation request for Email Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
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

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  |


Scenario Outline: Dealer can cancel installation request for Cloud Communication
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
	And I can cancel the above created installation request
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |




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

	| Role                            | Country     | ContractType                       | UsageType                                 | Role1            | Method | Type | Length  | Billing                 |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 3 ans   | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans   | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 36      | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | Web  | 48      | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | Web  | 3 años  | Por trimestres vencidos |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 4 años  | Por trimestres vencidos |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | Web  | 3 år    | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 4 år    | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | Web  | 36      | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 48      | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | Web  | 3 jaar  | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 4 jaar  | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | Web  | 36      | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 48      | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears    |
	



Scenario Outline: German and Austria Dealer can cancel installation request for Cloud Communication
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
	And I can cancel the above created installation request 
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  |
	| Cloud MPS Bank                  | Germany | Leasing & Service        | Mindestvolumen | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  |
	| Cloud MPS Bank                  | Austria | Leasing & Service        | Mindestvolumen | Cloud MPS Dealer | Cloud  | Web  |
	
	
	


Scenario Outline: German and Austria Dealer can cancel installation request for Email Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
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

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Email  |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Email  |
	


Scenario Outline: German and Austria Dealer can cancel installation request for Email Communication after the contract has been signed
	Given German Dealer have created a signed "<Country>" contract of "<ContractType>" and "<UsageType>"
	When I navigate to the signed contract Manage Device Screen
	And I select Location in order to create installation request
	And I set device communication method as "<Method>"
	And I completed the create installation process for "<Method>"
	Then the installation request for that device is completed
	And I can cancel the above created installation request
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Email  |
	#| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Email  |
	
	


Scenario Outline: German and Austria Local Office Approver can cancel installation request for Email Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
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

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Email  |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Email  |
	


Scenario Outline: Local Office can cancel installation request for Cloud Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
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

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |


Scenario Outline: Local Office Approver can cancel installation request for Email Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
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

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  |



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

	| Role                            | Country | ContractType                      | UsageType                                 | Role1            | Method | Length  | Billing                 |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Email  | 3 ans   | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Email  | 36      | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Spain   | Purchase & Click con Service      | Volúmen mínimo                            | Cloud MPS Dealer | Email  | 5 años  | Por trimestres vencidos |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service     | Minimum Volume                            | Cloud MPS Dealer | Email  | 3 years | Quarterly in Arrears    |
	

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

	| Role                            | Country     | ContractType                       | UsageType                                 | Role1            | Method | Length  | Billing                 | Type |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | 3 ans   | Trimestrale anticipata  | Web  |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | 3 ans   | Trimestrale anticipata  | BOR  |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | 36      | Trimestrale anticipata  | Web  |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | 36      | Trimestrale anticipata  | BOR  |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | 3 años  | Por trimestres vencidos | Web  |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | 4 años  | Por trimestres vencidos | BOR  |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | 3 år    | Quarterly in Arrears    | Web  |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | 4 år    | Quarterly in Arrears    | BOR  |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | 36      | Quarterly in Arrears    | Web  |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | 48      | Quarterly in Arrears    | BOR  |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | 3 jaar  | Quarterly in Arrears    | Web  |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | 4 jaar  | Quarterly in Arrears    | BOR  |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | 36      | Quarterly in Arrears    | Web  |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | 48      | Quarterly in Arrears    | BOR  |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | 3 years | Quarterly in Arrears    | Web  |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | 3 years | Quarterly in Arrears    | BOR  |
	




Scenario Outline: Installer can cancel installation request for Cloud Communication for Multiple Languages
	Given "<Country>" Dealer with "<Language>" language have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
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

	| Role                            | Country     | ContractType                  | UsageType                                 | Role1            | Method | Type | Length  | Billing              | Language |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | Suomi    |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | Suomi    |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | Svenska  |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | Svenska  |
	| Cloud MPS Local Office Approver | Belgium     | Buy & Click                   | Volume minimum                            | Cloud MPS Dealer | Cloud  | Web  | 3 ans   | Quarterly in Arrears | French   |
	| Cloud MPS Local Office Approver | Belgium     | Buy & Click                   | Volume minimum                            | Cloud MPS Dealer | Cloud  | BOR  | 4 ans   | Quarterly in Arrears | French   |
	| Cloud MPS Local Office Approver | Belgium     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar  | Quarterly in Arrears | Dutch    |
	| Cloud MPS Local Office Approver | Belgium     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 4 jaar  | Quarterly in Arrears | Dutch    |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | Web  | 3 Jahre | Quarterly in Arrears | Deutsch  |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans   | Quarterly in Arrears | Français |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears | Deutsch  |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 4 ans   | Quarterly in Arrears | Français |
	
	

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

	| Role                            | Country | ContractType                      | UsageType                                 | Role1            | Method | Length  | Billing                 |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Email  | 3 ans   | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Email  | 36      | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Spain   | Purchase & Click con Service      | Volúmen mínimo                            | Cloud MPS Dealer | Email  | 5 años  | Por trimestres vencidos |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service     | Minimum Volume                            | Cloud MPS Dealer | Email  | 3 years | Quarterly in Arrears    |
	
