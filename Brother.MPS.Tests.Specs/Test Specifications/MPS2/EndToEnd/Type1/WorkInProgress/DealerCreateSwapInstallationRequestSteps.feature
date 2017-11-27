@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: BusinessScenario_1_WIP_DealerCreateSwapInstallationRequestSteps
	In order to initiate the swap of an installed Cloud MPS device for a contract
	As a Cloud MPS Dealer
	I want to create a swap installation request

Scenario Outline: Business Scenario 1 - Dealer Create Swap Installation Request Steps
Given I have navigated to the Accepted Contracts page as a "Cloud MPS Dealer" from "<Country>"
When I locate the contract with id "<ProposalId>"
And I click Manage Devices in the Actions menu
And I click Swap Device in the Actions menu for device with serial number "<SwapDeviceSerialNumber>"
And I create a "<SwapType>" swap installation request with "<InstallationType>" installation type for "<CommunicationMethod>" communication
Then I will be able to see the status of the installed device is set Being Replaced on the Manage Devices page for the above proposal

Scenarios:
		| Country        | ProposalId | SwapDeviceSerialNumber | SwapType             | CommunicationMethod | InstallationType |
		| United Kingdom | 123252     | A3P145342              | ReplaceWithSameModel | Cloud               | Web              |