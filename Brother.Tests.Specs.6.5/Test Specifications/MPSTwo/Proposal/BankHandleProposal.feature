@TEST @UAT
Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@ignore
Scenario Outline: Add two numbers
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to OfferPage
	And I navigate to Awaiting Approval screen under Offer page
	When I select a proposal from "<Name>" of Proposal
	Then I should be able to decline that proposal
	And the decline proposal should be displayed under Declined tab

	Scenarios: 
	| Role           | Country        | Name    |
	| Cloud MPS Bank | United Kingdom | TEST 23 |

