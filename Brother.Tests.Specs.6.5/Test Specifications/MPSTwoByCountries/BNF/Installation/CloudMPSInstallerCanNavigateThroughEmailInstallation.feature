﻿@MPS @UAT @TEST
Feature: CloudMPSFinnishInstallerCanNavigateThroughEmailInstallation
	In order to get an installer to begin installation
	As a Dealer 
	I want to be able to complete installation


Scenario Outline: Installer can progress with installation for Email Communication for other countries
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
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

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Length  | Billing              |
	| Cloud MPS Local Office Approver | Finland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  | 3 years | Quarterly in Arrears |
	