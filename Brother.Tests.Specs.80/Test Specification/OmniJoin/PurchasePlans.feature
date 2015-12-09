@IGNORE
Feature: Purchase A Plan
	In order to continue to use OmniJoin
	As a Customer
	I need to purchase one of the available purchase plans

# Add check for an OmnoJoin license using Web Service 
# Notes from Markus as follows 

#There is a web service for OJ which can check licenses:
#Get Account service – field WClicense 

Background: 
	# Create an account on BOL and log in
	Given I am logged onto Brother Online "United Kingdom" using valid credentials

@SMOKE
Scenario Outline: Purchase OmniJoin subscription plan for <country> for a <Plan Type> plan on <Billing Type> billing
	Given I have navigated to the OmniJoin home page
	And I have clicked on Buy
	Then I should be redirected to the Plans page
	And If I then Choose the "<Plan Type>" Plan option column
	Then I should be directed to the relevant plan page
	And I check the correct billing type as "<Billing Type>"
	When I click Agree to terms and conditions
	And I Click Buy Now At Brother Online
	Then I should be directed to the Brother Online Basket page
	And When I click CheckOut
	Then I can add billing address details for Country "<Country>"
	And I can go through the order process for Country "<Country>" with order info "<Qty>"
	Then I should see the Order Confirmation page
	And The purchased plan billing type is correct "<Billing Type>"
	And If I click on My Account
	And I can click on Orders
	And I can validate the order "<Qty>" of "<Order Name>" @ "<Price>" on My Account page
	And If I sign out of Brother Online
	Then I am redirected to the Brother Home Page
	And I can validate an Order Confirmation email was received

Scenarios: 
	
	| Plan Type    | Country        | Billing Type | Qty | Order Name            | Price   |
	| Lite         | United Kingdom | Monthly      | 1   | OmniJoin Lite         | £18.00  |
	| Lite         | United Kingdom | Annual       | 1   | OmniJoin Lite         | £144.00 |
	| Business     | United Kingdom | Monthly      | 1   | OmniJoin Pro          | £70.80  |
	| Business     | United Kingdom | Annual       | 1   | OmniJoin Pro          | £678.00 |
	| Professional | United Kingdom | Monthly      | 1   | OmniJoin              | £34.80  |
	| Professional | United Kingdom | Annual       | 1   | OmniJoin              | £331.20 |

@PROD @UAT @TEST
## OmniJoin plan purchase - 
Scenario: Purchase a Lite Use plan on Monthly Billing but click Cancel before submitting payment
	Given I have navigated to the OmniJoin home page
	And I have clicked on Buy
	Then I should be redirected to the Plans page
	And If I then Choose the "Lite" Plan option column
	Then I should be directed to the relevant plan page
	When I click Agree to terms and conditions
	And I Click Buy Now At Brother Online
	Then I should be directed to the Brother Online Basket page
	And When I click CheckOut
	Then I can add billing address details for Country "United Kingdom"
	And I can go through a dummy order process for Country "United Kingdom" with order info "1"
	Then I can navigate back to Brother Online home page
	Then I can sign out of Brother Online

@ignore
Scenario: Purchase a Professional Use plan but check that correct error message are displayed if Terms of use are not selected

@ignore
Scenario: Purchase a Professional Use plan using alternative path to purchase page