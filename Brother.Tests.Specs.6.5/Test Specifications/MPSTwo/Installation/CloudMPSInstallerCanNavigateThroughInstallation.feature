@MPS @UAT @TEST
Feature: CloudMPSInstallerCanNavigateThroughInstallation
	In order to get an installer to begin installation
	As a Dealer 
	I want to be able to complete installation

#@ignore
Scenario Outline: Installer can progress with installation for Email Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Method>" communication
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  |


Scenario Outline: German And Austria Installer can progress with installation for Email Communication
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Method>" communication 
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Email  |
	



Scenario Outline: German And Austria Dealer can create installation request for Cloud Communication
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
	| Cloud MPS Bank                  | Germany | Leasing & Service        | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Bank                  | Austria | Leasing & Service        | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	


