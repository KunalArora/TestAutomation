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
	| Comment       | @@@@@        |

	Then I click Create Activation Codes
	And I review the order information
	When I click Confirm
	Then I should see the order success screen
	#Then I can validate the order was processed via SAP
	And I can store the Order Details for "AutomatedTesterDealer1@guerrillamail.com" as they are required later
	Then I can navigate back to the Partner Portal Home Page using breadcrumbs
	Then I can see the Partner Portal Home Page
	And when I click Manage Customers and Orders
	When I Click Add New Customer
	And I enter a new Customer Email Address As "ORP_GENERATED_CUSTOMER"
	When I click Next
	Then I can enter further customer information such as First Name as "ORP_Customer", Last Name as "ORP_Customer", Company Name as "ORP_CompanyName"
	And I can click Add Customer
	And I can store the Customer Account information for use later
	When I can sign out of Brother Online
	And I can verify that the Customer account association email is received
	Then I can validate the correct order emails were received for "AutomatedTesterDealer1@guerrillamail.com" as "order" and as "activation"
	Given I am logged into Brother Online "United Kingdom" using "ORP_GENERATED_CUSTOMER"
	Then I can navigate to the Activate Code page
	And I can activate the stored Activation code
	When I navigate to Manage Plan
	Then I can see my OmniJoin plan
	And I can sign out of Brother Online







	
