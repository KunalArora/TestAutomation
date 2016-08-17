﻿@MPS @UAT @TEST
Feature: CloudMPSSwapDeviceForIrishDealer
	In order to remove a broken device from a contract
	As an installer
	I want to be able to swap contract's current device to a new device


Scenario Outline: MPS Swap Device
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I have completed installation for "<Type>" communication
	And I begin device swapping process
	And I generate swapping device request
	And installer installed the new swap device for "<Type>" communication
	Then the newly installed device is displayed on Managed Device screen
	And I can complete the swap process
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears |
	
