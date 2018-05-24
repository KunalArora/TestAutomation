#@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: BusinessScenario_1_WIP_InstallerCompleteWebInstallationSwapRequestSteps
	In order to complete the swap of a Cloud MPS device for a contract
	As a Cloud MPS Dealer
	I want to see that a swap device request has been completed

Scenario Outline: Business Scenario 1 - Installer Complete Web Installation Swap Request Steps
Given that a Brother installer has navigated to the Web Installation page at "<WebInstallUrl>"
When the installer completes the swap for device with serial number "<SerialNumber>" in contract "<ProposalId>"
Then I will be able to see on the Manage Devices page that the above device is connected

Scenarios: 
		| Country        | ProposalId | SerialNumber | WebInstallUrl |
		| United Kingdom | xxxx       | xxxxxxxxx    | https://online65.co.uk.cds.uat.brother.eu.com/mps/web-installation/installation-contract-reference?token=xxxxxxx |