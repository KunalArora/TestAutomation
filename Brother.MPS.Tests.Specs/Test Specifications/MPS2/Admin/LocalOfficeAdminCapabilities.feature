@MPS @UAT @TEST @TYPE1 @LOW @ADMIN @BPL @CI_TestMaintenance
Feature: LocalOfficeAdminCapabilities
	In order to test the Cloud MPS local office Admin capabilities
	Verify the different options of local office admin

Scenario Outline: LocalOfficeAdminCapabilities
Given I have navigated to the dashboard page as a Cloud MPS Local office admin with culture "<Culture>" from "<Country>"  
When I navigate to the lease and click program settings page and enable the program
And a Cloud MPS Dealer navigated to the create proposal page with culture "<Culture>" from "<Country>"
Then a Cloud MPS Dealer can verify the program "<ContractType>" is being displayed as contract type
And I disable the program that was previously enabled

@BUK
Scenarios: 
		| Country | Culture | ContractType    |
		| Poland  | pl-PL   | LEASE_AND_CLICK |