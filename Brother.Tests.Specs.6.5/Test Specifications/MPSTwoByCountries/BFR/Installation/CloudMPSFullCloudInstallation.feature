@MPS @UAT @TEST
Feature: CloudMPSFullFrenchCloudInstallationForSmokeTest
	In order to get an installer to begin cloud installation
	As a Dealer 
	I want to be able to complete cloud installation

## This scenario will be completed by using device simulation
## The device simulator will be used to simulate connection to BOC/Medio

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

	| Role                            | Country | ContractType | UsageType                                 | Role1            | Method | Type | Length | Billing                |
	| Cloud MPS Local Office Approver | France  | Buy & Click  | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 3 ans  | Trimestrale anticipata |
	| Cloud MPS Local Office Approver | France  | Buy & Click  | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans  | Trimestrale anticipata |
	