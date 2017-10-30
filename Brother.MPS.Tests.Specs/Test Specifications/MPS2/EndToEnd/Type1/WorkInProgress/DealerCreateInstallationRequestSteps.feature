@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: BusinessScenario_1_WIP_DealerCreateInstallationRequestSteps
	In order to initiate installation of Cloud MPS devices for a contract
	As a Cloud MPS Dealer
	I want to create an installation request

Scenario Outline: Business Scenario 1 - Dealer Create Installation Request Steps
Given I have navigated to the Accepted Contracts page as a "Cloud MPS Dealer" from "<Country>"
When I locate the contract with id "<ProposalId>"
And I click Manage Devices in the Actions menu
And I create a "<InstallationType>" installation request for "<CommunicationMethod>" communication
Then I will be able to see the installation request created above on the Manage Devices page for the above proposal

Scenarios: 
		| Country        | ProposalId | CommunicationMethod | InstallationType |
		| United Kingdom | xxxx       | Cloud               | Web              |