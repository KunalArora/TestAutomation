@UAT @TEST
Feature: Purchase A Plan
	In order to continue to use OmniJoin
	As a Customer
	I need to purchase one of the available purchase plans

# Add check for an OmnoJoin license using Web Service 
# Notes from Markus as follows 

#There is a web service for OJ which can check licenses:
#Get Account service – field WClicense 

# Create an account on BOL and log in
Background: 
#Given I am logged onto Brother Online "United Kingdom" using valid credentials
Given I want to create a new account with Brother Online "United Kingdom"
	When I click on Create Account for "United Kingdom"
	And I am redirected to the Brother Login/Register page
	And I have Checked No I Do Not Have An Account Checkbox
	And I fill in the registration information using a valid email address 
	| field           | value          |
	| FirstName       | AutoTest       |
	| LastName        | AutoTest       |
	| Password        | @@@@@	       |
	| ConfirmPassword | @@@@@		   |

	And I have Agreed to the Terms and Conditions
	And I declare that I do not use this account for business
	When I press Create Your Account
	Then I should see my account confirmation page
	And When I Click Go Back
	Then I should be able to log into "United Kingdom" Brother Online using my account details
	
## OmniJoin plan purchase - 
Scenario: Purchase a Lite Use plan on Monthly Billing but click Cancel before submitting payment
	 And I have navigated to the OmniJoin home page
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