@MPS @UAT @TEST
Feature: CloudMPSVerifyIrishPDFContentsAreCorrect
	In order to ensure that PDF contents are correct when compared with Summary page
	As a MPS Dealer
	I want to be able to compare the values on summary page with PDF contents


Scenario Outline: Verify Spanish PDF Contents Are Correct
	Given Dealer has created an awaiting acceptance contract of "<ContractType>" and "<UsageType>"
	When the dealer downloads PDF for the created contract
	Then the noted values above are available in the PDF content
	And I sign out of Cloud MPS


Scenarios:

	| ContractType                  | UsageType      |
	| Purchase & Click with Service | Minimum Volume |


#Scenario Outline: Verify Belgian PDF Contents Are Correct
#	Given "<Country>" Dealer has created an awaiting acceptance "<ContractType>" contract of "<UsageType>" and "<Length>" and "<Billing>"
#	When the dealer downloads PDF for the created contract
#	Then the noted values above are available in the PDF content
#	And I sign out of Cloud MPS
#
#
#Scenarios:
#
#	| ContractType                      | Country | UsageType                                 | Length | Billing                 |
#	| Buy & Click                       | France  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata  |
#	| Acquisto + Consumo con assistenza | Italy   | Volume minimo                             | 36     | Trimestrale anticipata  |
#	| Purchase & Click con Service      | Spain   | Volúmen mínimo                            | 3 años | Por trimestres vencidos |
#	
#
#Scenario Outline: Verify Belgian PDF Contents Are Correct
#	Given German Dealer have created a "<Country>" awating acceptance contract of "<ContractType>" and "<UsageType>"
#	When the dealer downloads PDF for the created contract
#	Then the noted values above are available in the PDF content
#	And I sign out of Cloud MPS
#
#	Scenarios:
#
#	| Country | ContractType             | UsageType      | 
#	| Germany | Easy Print Pro & Service | Mindestvolumen | 
#	| Germany | Leasing & Service        | Mindestvolumen | 
#	| Austria | Easy Print Pro & Service | Mindestvolumen | 
#	| Austria | Leasing & Service        | Mindestvolumen | 