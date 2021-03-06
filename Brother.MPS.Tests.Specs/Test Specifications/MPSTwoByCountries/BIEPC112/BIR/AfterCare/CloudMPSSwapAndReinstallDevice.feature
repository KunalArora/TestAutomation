﻿@MPS @UAT @TEST @BIEPC112
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
	And I begin device swapping process for same device 
	And I generate swapping device request with "<Method>" and "<Type>"
	And installer installed the new swap device for "<Type>" communication
	And I enter new swap mono print count as "700" and colour print count as "800"
	Then the newly installed device is displayed on Managed Device screen
	##And I can complete the swap process
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears |


Scenario Outline: MPS PCB Swap Device
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I have completed installation for "<Type>" communication
	And I begin device PCB swapping process for same device 
	And I generate PCB swapping device request with "<Method>" and "<Type>"
	And installer installed new PCB swap device for "<Type>" communication
	And I enter new swap mono print count as "700" and colour print count as "800"
	Then the newly installed device is displayed on Managed Device screen
	##And I can complete PCB swap process
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears |


Scenario Outline: MPS Swap Device with Different Device
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I have completed installation for "<Type>" communication
	And I begin device swapping process for different device "<NewDevice>" 
	And I generate swapping device request with "<Method>" and "<Type>"
	And installer installed the new swap device for "<Type>" communication
	And I enter new swap mono print count as "700" and colour print count as "800"
	Then the newly installed device is displayed on Managed Device screen
	##And I can complete the swap process
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              | NewDevice   |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | HL-L8350CDW |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | HL-L8350CDW |
	

Scenario Outline: MPS Swap Device Cancellation
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I have completed installation for "<Type>" communication
	And I begin device swapping process for same device 
	And I generate swapping device request with "<Method>" and "<Type>"
	Then the swap installation request can be cancelled
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears |


Scenario Outline: MPS Swap Device with Different Device Cancellation
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I have completed installation for "<Type>" communication
	And I begin device swapping process for different device "<NewDevice>" 
	And I generate swapping device request with "<Method>" and "<Type>"
	Then the swap installation request can be cancelled
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              | NewDevice   |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | HL-L8350CDW |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | HL-L8350CDW |


Scenario Outline: MPS Device Reinstallation
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I have completed installation for "<Type>" communication
	And I begin device reinstallation process for same device 
	And I generate reinstall device request with "<Method>" and "<Type>"
	And installer installed the new reinstall device for "<Type>" communication
	Then the newly installed device is displayed on Managed Device screen
	##And I can complete the swap process
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears |


Scenario Outline: MPS Device Reinstallation Cancellation
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I have completed installation for "<Type>" communication
	And I begin device reinstallation process for same device 
	And I generate reinstall device request with "<Method>" and "<Type>"
	Then the swap installation request can be cancelled
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears |


Scenario Outline: MPS Swap Device With Existing Customer
	Given "<Country>" Dealer have created "<ContractType>" contract choosing "<ExistingCustomer>" with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I have completed installation for "<Type>" communication
	And I begin device swapping process for same device 
	And I generate swapping device request with "<Method>" and "<Type>"
	And installer installed the new swap device for "<Type>" communication
	And I enter new swap mono print count as "700" and colour print count as "800"
	Then the newly installed device is displayed on Managed Device screen
	##And I can complete the swap process
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to Print Count page
	Then the print counts attached to the device are correct
	And I sign out of Cloud MPS

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              | ExistingCustomer                    |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | Jeffie20170629012050@mailinator.com |
	