@UAT @TEST 
Feature: AddPaymentMethod
	In order to purchase items from Brother
	As a customer
	I need to add a new Payment Method

Background:
	Given I am logged onto Brother Online "United Kingdom" using valid credentials

Scenario: Add payment method with new address
	Given I am logged into my Brother Online account
	Then If I click on My Account menu
	And I click on My Personal Details
	And I can click on Payment Methods
	Then I can add a new payment method
	And If I click on Add New Address
	Then I can add a new billing address details for Country "United Kingdom"
	When I enter valid credit card details for a Visa Credit Card with an expired date of ""
	When I click Send to commit the new card details
	Then I can see the Credit Card details I have added
	And I can sign out of Brother Online

@PROD @UAT @TEST
Scenario: Add payment method with new address and Cancel before submitting
	Given I am logged into my Brother Online account
	Then If I click on My Account menu
	And I click on My Personal Details
	And I can click on Payment Methods
	Then I can add a new payment method
	And If I click on Add New Address
	Then I can add a new billing address details for Country "United Kingdom"
	When I enter valid credit card details for a Visa Credit Card with an expired date of ""
	When I click Cancel submit card details I should return to the My Payment Method page
	Then I can sign out of Brother Online

@ignore
Scenario: Add payment method with existing address
	Given I am logged into my Brother Online account
	Then If I click on My Account menu
	And I click on My Personal Details
	And I can click on Payment Methods
	Then I can add a new payment method

