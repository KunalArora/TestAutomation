@MPS @UAT @TEST @BIEPC110 @CRITICAL 
Feature: CloudMPSResetInstallation
	In order for an installer to be able to redo installation
	As a installer 
	I want to be able to reset installation

## This scenario will be completed by using device simulation
## The device simulator will be used to simulate connection to BOC/Medio


Scenario Outline: MPS BUK Reset Installation Before Completing Installation
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	##And I enter device serial number for "<Type>" communication 
	And I enter device serial number "<SerialNumber>" for "<Type>" communication
	And I enter the device IP address
	And I can connect device with serials "<SerialNumber>" to Brother environment
	##And I can complete device installation
	Then I can reset the installation done above
	And reinstall the device with serial number "<SerialNumber>" for communication "<Type>"
	And I can sign out of Brother Online
	

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type | SerialNumber |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | A1T010559    |


@ignore
Scenario Outline: MPS BUK Reset Installation After Completing Installation
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	##And I enter device serial number for "<Type>" communication 
	And I enter device serial number "<SerialNumber>" for "<Type>" communication 
	And I enter the device IP address
	Then I can connect device with serials "<SerialNumber>" to Brother environment
	Then I can reset the installation done above and begin installation again
	And I enter the contract reference number
	And reinstall the device with serial number "<SerialNumber>" for communication "<Type>"
	And I can sign out of Brother Online
	

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type | SerialNumber |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | A1T010560    |
