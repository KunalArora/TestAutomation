@MPS @UAT @TEST
Feature: CloudMPSVerifyPDFContentsAreCorrect
	In order to ensure that PDF contents are correct when compared with Summary page
	As a MPS Dealer
	I want to be able to compare the values on summary page with PDF contents


Scenario Outline: Verify PDF Contents Are Correct
	Given Dealer has created an awaiting acceptance contract of "<ContractType>" and "<UsageType>"
	When the dealer downloads PDF for the created contract
	Then the noted values above are available in the PDF content
	And I sign out of Cloud MPS


Scenarios:

	| ContractType                  | UsageType      |
	| Purchase & Click with Service | Minimum Volume |


Scenario Outline: Verify Other Countries PDF Contents Are Correct
	Given "<Country>" Dealer has created an awaiting acceptance "<ContractType>" contract of "<UsageType>" and "<Length>" and "<Billing>"
	When the dealer downloads PDF for the created contract
	Then the noted values above are available in the PDF content
	And I sign out of Cloud MPS


Scenarios:

	| ContractType                      | Country | UsageType                                 | Length | Billing                |
	#| Buy & Click                       | France  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata |
	| Acquisto + Consumo con assistenza | Italy   | Volume minimo                             | 36     | Quarterly in Advance   |


Scenario Outline: Verify German PDF Contents Are Correct
	Given German Dealer have created a "<Country>" awating acceptance contract of "<ContractType>" and "<UsageType>"
	When the dealer downloads PDF for the created contract
	Then the noted values above are available in the PDF content
	And I sign out of Cloud MPS

	Scenarios:

	| Country | ContractType             | UsageType      | 
	| Germany | Easy Print Pro & Service | Minimum Volume | 
	| Germany | Leasing & Service        | Minimum Volume | 
	| Austria | Easy Print Pro & Service | Minimum Volume | 
	| Austria | Leasing & Service        | Minimum Volume | 