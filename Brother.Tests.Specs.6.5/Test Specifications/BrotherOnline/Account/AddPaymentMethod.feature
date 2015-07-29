@UAT @TEST 
Feature: AddPaymentMethod
	In order to purchase items from Brother
	As a customer
	I need to add a new Payment Method

Background:
	Given I am logged onto Brother Online "United Kingdom" using valid credentials

Scenario: Add payment method with new address
	Given I am logged into my Brother Online account
	Then If I go to My Account
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
	Then If I go to My Account
	And I can click on Payment Methods
	Then I can add a new payment method
	And If I click on Add New Address
	Then I can add a new billing address details for Country "United Kingdom"
	When I enter valid credit card details for a Visa Credit Card with an expired date of ""
	When I click Cancel submit card details I should return to the My Payment Method page
	Then I can sign out of Brother Online

#Validate that the correct error messages are displayed on the add payment method mandatory fields
Scenario: Customer get the error message if mandatory fields are not completed by a customer
Given I am logged into my Brother Online account
	Then If I go to My Account
	And I can click on Payment Methods
	Then I can add a new payment method
	And If I click on Add New Address
	Then I can add a new billing address details for Country "United Kingdom"
	And I am redirtected to the card details page
	When I click Send to commit the new card details
	Then I should get error message to enter the card details


@ignore
Scenario: Add payment method with existing address
	Given I am logged into my Brother Online account
	Then If I go to My Account
	And I can click on Payment Methods
	Then I can add a new payment method

@ignore
Scenario: Update Credit Card from expired card

#BBAU-121 - need to add a test for this scenario

"""If the payment card for an OmniJoin subscription expires and the new card has the same number but a different expiry date then when the Manage Plan screen is updated to use the new card the Orders table in the Sitecore database is not updated to use the new payment method and SAP is not informed either.

Switching to a different card number works okay so the hypothesis is that the problem is that this fails because the card number is the same for the old and new cards.

*EDIT: Adding steps to replicate*
1. Purchase any OJ plan using one of the fake Digital River cards
2. In the database (PaymentMethods table I think) set the credit card's expiry date to be in the past
3. Add a new credit card to the BOL account using the same number but a different expiry date
4. Change the credit card used for OJ in the payment part of the Manage Subscription screens
5. The credit card used for OJ should now be the new card not the expired card and this should have also been passed to SAP (you'll need someone in the SAP team to verify) for the next automated billing cycle.

If in step 3 you use a different fake Digital River credit card with a different number it all works okay.

This has only been looked at in Production as far as I know - with live customer data. Hopefully it can be replicated okay in local dev environments!"""
