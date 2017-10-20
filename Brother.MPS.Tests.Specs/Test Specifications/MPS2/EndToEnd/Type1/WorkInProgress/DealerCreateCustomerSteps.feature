@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: BusinessScenario_1_WIP_DealerCreateCustomerSteps
	In order to sell update my customer base for Cloud MPS
	As a Cloud MPS Dealer
	I want to create a new customer

Scenario Outline: Business Scenario 1 - Dealer Create Customer Steps
Given I have navigated to the Create Customer page as a "Cloud MPS Dealer" from "<Country>"
When I create and save a new Customer
Then I can see the customer created above in the customers & contacts list

Scenarios:
	| Country        |
	| United Kingdom |