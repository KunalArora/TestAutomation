@UAT @TEST
Feature: Named Host Activation Keys
	In order for Customers to use OmniJoin using Named Host licenses
	As a dealer
	I want to be able to purchase Named Host Licenses for different OmniJoin Plans

@SMOKE @ignore
Scenario: Order and validate a new subscription activation code for Named Host licensing, with Professional Plan and Annual Term
	Given I am logged into Brother Online "United Kingdom" using "AutomatedTesterDealer1@guerrillamail.com"
	And I click on the Partner Portal menu option
	When I click on the Partner Portal button
	Then I can see the Partner Portal Home Page
	When I click on Manage Services
	Then I should see the OmniJoin Services page
	When I click on Purchase Activation Codes
	Then I should see the Activation Codes creation page
	When I enter the following information	
	| field         | value        |
	| LicenseType   | Named Host   |
	| OJProductPlan | OmniJoin Pro |
	| Term          | Annual       |
	| Qty           | 1            |
	| Comment       | AutoTest     |

	Then I click Create Activation Codes
	And I review the order information
	When I click Confirm
	Then I should see the order success screen
	And I can validate the correct order emails were received for "AutomatedTesterDealer1@guerrillamail.com" as "order" and as "activation"
#	And I can validate the order is displayed in the Orders tab under my account
	Then I can validate the order was processed via SAP
	And I can store the Dealer Activation Code for using later
	When I create a new Customer Account using the same customer name I created as a Dealer
	Then I can navigate to the Activate Code page
	And I can activate the stored Activation code
	When I navigate to Manage Plan
	Then I can see my OmniJoin plan









	
