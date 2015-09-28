@MPS @UAT @TEST
Feature: InstallerCanNavigateThroughInstallation
	In order to get an installer to begin installation
	As a Dealer 
	I want to be able to complete installation

#@ignore
Scenario Outline: Installer can progress with installation for Cloud Communication
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate "<Type>" installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	And I navigate to the installer page
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |


