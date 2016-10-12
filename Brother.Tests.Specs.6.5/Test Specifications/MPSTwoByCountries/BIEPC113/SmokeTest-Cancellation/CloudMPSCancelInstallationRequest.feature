@MPS @UAT @TEST
Feature: CloudMPSCancelInstallationRequestForSmokeTest
	In order to stop an installer from beginning installation
	As a Dealer 
	I want to be able to cancel installation request


Scenario Outline: MPS BUK Cancel Email Installation
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


Scenario Outline: MPS BUK Cancel Cloud Installation
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




Scenario Outline: MPS Cancel Cloud Installation
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

	| Role                            | Country     | ContractType                       | UsageType                                 | Role1            | Method | Type | Length     | Billing                  |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 3 ans      | Trimestrale anticipata   |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans      | Trimestrale anticipata   |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 36         | Trimestrale anticipata   |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | Web  | 48         | Trimestrale anticipata   |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | Web  | 3 años     | Por trimestres vencidos  |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 4 años     | Por trimestres vencidos  |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | Web  | 3 år       | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 4 år       | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | Web  | 36 månader | Kvartalsvis i efterskott |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 48 månader | Kvartalsvis i efterskott |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | Web  | 3 jaar     | Per kwartaal achteraf    |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 4 jaar     | Per kwartaal achteraf    |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | Web  | 36         | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 48         | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years    | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 years    | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | Web  | 3 lata     | Miesięczny / Monthly     |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 4 lata     | Miesięczny / Monthly     |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | Web  | 3 vuotta   | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | BOR  | 4 vuotta   | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 36         | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | Web  | 36         | Quarterly in Arrears     |
	



Scenario Outline: MPS BIGAT Cancel Cloud Installation
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
	
	


Scenario Outline: MPS BIGAT Cancel Email Installation
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
	


Scenario Outline: MPS BIGAT Cancel Email Installation Signed Contract
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
	
	


Scenario Outline: MPS BIGAT LO Cancel Email Installation
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
	


Scenario Outline: MPS BIGAT LO Cancel Cloud Installation
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


Scenario Outline: MPS BUK LO Cancel Email Installation
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



Scenario Outline: MPS LO Cancel Email Installation
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
	

Scenario Outline: MPS LO Cancel Cloud Installation
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

	| Role                            | Country     | ContractType                       | UsageType                                 | Role1            | Method | Length     | Billing                  | Type |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | 3 ans      | Trimestrale anticipata   | Web  |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | 3 ans      | Trimestrale anticipata   | BOR  |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | 36         | Trimestrale anticipata   | Web  |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | 36         | Trimestrale anticipata   | BOR  |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | 3 años     | Por trimestres vencidos  | Web  |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | 4 años     | Por trimestres vencidos  | BOR  |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | 3 år       | Quarterly in Arrears     | Web  |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | 4 år       | Quarterly in Arrears     | BOR  |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | 36 månader | Kvartalsvis i efterskott | Web  |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | 48 månader | Kvartalsvis i efterskott | BOR  |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | 3 jaar     | Per kwartaal achteraf    | Web  |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | 4 jaar     | Per kwartaal achteraf    | BOR  |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | 36         | Quarterly in Arrears     | Web  |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | 48         | Quarterly in Arrears     | BOR  |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | 3 years    | Quarterly in Arrears     | Web  |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | 4 years    | Quarterly in Arrears     | BOR  |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | 3 lata     | Miesięczny / Monthly     | Web  |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | 4 lata     | Miesięczny / Monthly     | BOR  |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | 3 vuotta   | Quarterly in Arrears     | Web  |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | 4 vuotta   | Quarterly in Arrears     | BOR  |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | 36         | Quarterly in Arrears     | BOR  |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | 36         | Quarterly in Arrears     | Web  |
	


Scenario Outline: MPS Cancel MLang Cloud Installation
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

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length | Billing                                                            | Language |
	| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | Web  | 3 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | French   |
	| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | BOR  | 4 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | French   |
	| Cloud MPS Local Office Approver | Belgium | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar | Jaarlijke afrekening / Décompte annuel                             | Dutch    |
	| Cloud MPS Local Office Approver | Belgium | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 4 jaar | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | Dutch    |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | Web  | 3 Jahre | Quarterly in Arrears | Deutsch  |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans   | Quarterly in Arrears | Français |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears | Deutsch  |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 4 ans   | Quarterly in Arrears | Français |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | Suomi    |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | Suomi    |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | Svenska  |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | Svenska  |
	#
	

Scenario Outline: MPS Cancel Email Installation
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
	
