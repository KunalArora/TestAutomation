@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: BusinessScenario_1_WIP_InstallerCompleteWebInstallationRequestSteps
	In order to complete installation of Cloud MPS devices for a contract
	As a Cloud MPS Dealer
	I want to see that an installation request has been completed

Scenario Outline: Business Scenario 1 - Installer Complete Web Installation Request Steps
Given that a Brother installer has navigated to the Web Installation page at "<WebInstallUrl>"
When the installer completes the installation for contract "<ProposalId>"
Then I will be able to see on the Manage Devices page that all devices for the above contract are connected

Scenarios: 
		| Country        | ProposalId | WebInstallUrl                                                                                                    |
		| United Kingdom | xxxx       | https://online65.co.uk.cds.uat.brother.eu.com/mps/web-installation/installation-contract-reference?token=xxxxxxx |