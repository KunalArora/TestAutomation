@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: BusinessScenario_1_WIP_InstallerCompleteWebInstallationRequestSteps
	In order to complete installation of Cloud MPS devices for a contract
	As a Cloud MPS Dealer
	I want to see that an installation request has been completed

Scenario Outline: Business Scenario 1 - Installer Complete Web Installation Request Steps
Given that a Brother installer has navigated to the Web Installation page at "<WebInstallUrl>"
When I verify the Contract Reference for "<ProposalId>" and store Serial Numbers for printers
	| Model		 | SerialNumber     |
	| <Model_1>  | <SerialNumber_1> |
	| <Model_2>  | <SerialNumber_2> | 
And I enter the serial numbers and complete installation
And I have navigated to the Contracts Accepted page as a "Cloud MPS Dealer" from "<Country>"
And I have navigated to the Manage Devices for "<ProposalId>"
And I will be able to see on the Manage Devices page that all devices for the above contract are connected with default Print Counts
And I update the print count for "<SerialNumber_1>" to <MonoPrintCount_1> and <ColorPrintCount_1>
Then I will be able to see on the Manage Devices page that "<SerialNumber_1>" have updated Print Counts

Scenarios: 
		| Country        | ProposalId | Model_1    | SerialNumber_1 | MonoPrintCount_1 | ColorPrintCount_1 | Model_2    | SerialNumber_2 | WebInstallUrl |
		| United Kingdom | 160627     | DCP-8110DN | A3P145602      | 23               | 100               | DCP-8250DN | A3P145617      | https://online65.co.uk.cds.uat.brother.eu.com/mps/web-installation/installation-contract-reference?token=0b82a1812f53425621f0307a392f866f50316 |