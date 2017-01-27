@ignore
#@TEST
Feature: Personal Information
	In order to maintain my Brother Online Account
	As a customer
	I need to be able able to update my Personal Information

@SMOKE_MyAccountInformation
Scenario Outline: Customer can change their personal details by going into my account page
Given I navigate to "<Country>" Brother Online landing page
And I browse to the "<Site Url>" for existing user signin page

Scenarios:
	| Country        | Site Url            | Invalid Email Address |
	| United Kingdom | /sign-in-automation |                       |

@SMOKE_MyAccountInformation
Scenario: Customer cannot update the personal details if mandatory fields are left blank