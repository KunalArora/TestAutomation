@ignore @MPS @UAT @TEST
Feature: CloudMPSVerifyBelgianPDFContentsAreCorrect
	In order to ensure that PDF contents are correct when compared with Summary page
	As a MPS Dealer
	I want to be able to compare the values on summary page with PDF contents



Scenario Outline: MPS Verify PDF Correctness
	Given "<Country>" Dealer has created "<Language>" awaiting acceptance "<ContractType>" contract of "<UsageType>" and "<Length>" and "<Billing>"
	When the dealer downloads PDF for the created contract
	Then the noted values above are available in the PDF content
	And I sign out of Cloud MPS


Scenarios:

	| ContractType                  | Country | UsageType      | Length | Billing              | Language |
	| Buy & Click                   | Belgium | Volume minimum | 3 ans  | Quarterly in Arrears | French   |
	| Purchase & Click with Service | Belgium | Minimum Volume | 3 jaar | Quarterly in Arrears | Dutch    |
	
	