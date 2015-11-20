@TEST @UAT	
# Card details page flow has been changed to iframe content
Feature: AddPaymentMethod
	In order to purchase items from Brother
	As a customer
	I need to add a new Payment Method

Background:
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

@TEST @UAT
# Card details page flow has been changed to iframe content
Scenario: Add payment method with new address
    Then If I go to My Account
	And I can click on Payment Methods
	Then I can add a new payment method
	And If I click on Add New Address
	Then I can add a new billing address details for Country "United Kingdom"
	When I enter valid credit card details for a Visa Credit Card with an expired date of ""
	When I click Send to commit the new card details
	Then I can see the Credit Card details I have added
	And I can sign out of Brother Online

@IGNORE
# Card details page flow has been changed to iframe content
Scenario: Add payment method with new address and Cancel before submitting
	Then If I go to My Account
	And I can click on Payment Methods
	Then I can add a new payment method
	And If I click on Add New Address
	Then I can add a new billing address details for Country "United Kingdom"
	When I enter valid credit card details for a Visa Credit Card with an expired date of ""
	When I click Cancel submit card details I should return to the My Payment Method page
	Then I can sign out of Brother Online

@IGNORE
#Validate that the correct error messages are displayed on the add payment method mandatory fields
Scenario: Customer get the error message if mandatory fields are not completed by a customer
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
