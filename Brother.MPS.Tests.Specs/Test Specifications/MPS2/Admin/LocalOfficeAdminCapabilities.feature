@MPS @UAT @TEST @TYPE1 @LOW @ADMIN @BPL @CI_TestMaintenance
Feature: LocalOfficeAdminCapabilities
	In order to test the Cloud MPS local office Admin capabilities
	Verify the different options of local office admin

Scenario Outline: LocalOfficeAdminCapabilities
Given I have navigated to the dashboard page as a Cloud MPS Local office admin with culture "<Culture>" from "<Country>"  
# Enable Lease & Click program, verify and then disable it
When I navigate to the lease and click program settings page and enable the program
And a Cloud MPS Dealer navigated to the create proposal page with culture "<Culture>" from "<Country>"
Then a Cloud MPS Dealer can verify the program "<ContractType>" is being displayed as contract type
And I disable the program that was previously enabled

# Create a billing profile, verify and then delete it
When I navigate to the purchase and click program settings page
And I create a billing cycle with billing type as "<BillingType>", billing usage type as "<BillingUsageType>" and billing payment type as "<BillingPaymentType>"


@BUK
Scenarios: 
		| Country | Culture | ContractType    | BillingType | BillingUsageType | BillingPaymentType |
		| Poland  | pl-PL   | LEASE_AND_CLICK | MONTHLY     | MINIMUM_VOLUME   | RECURRING          |