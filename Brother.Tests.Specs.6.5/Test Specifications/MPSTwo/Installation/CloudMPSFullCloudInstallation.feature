@MPS @UAT @TEST
Feature: CloudMPSFullCloudInstallation
	In order to get an installer to begin cloud installation
	As a Dealer 
	I want to be able to complete cloud installation

## This scenario will be completed by using device simulation
## The device simulator will be used to simulate connection to BOC/Medio


Scenario Outline: Installer can complete installation for Cloud Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Type>" communication 
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |

Scenario Outline: German Installer can complete installation for Cloud Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Type>" communication 
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  |
	| Cloud MPS Bank                  | Germany | Leasing & Service        | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |
	| Cloud MPS Bank                  | Austria | Leasing & Service        | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |

Scenario Outline: Installer can complete installation for Cloud Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Type>" communication 
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                      | UsageType                                 | Role1            | Method | Type | Length | Billing                |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 3 ans  | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | France  | Buy & Click                       | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans  | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 36     | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | Italy   | Acquisto + Consumo con assistenza | Volume minimo                             | Cloud MPS Dealer | Cloud  | Web  | 48     | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | Spain   | Purchase & Click con Service      | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  |  BOR  |3 años | Quarterly in Arrears   |
	| Cloud MPS Local Office Approver | Spain   | Purchase & Click con Service      | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  |  Web  |3 años | Quarterly in Arrears   |
	