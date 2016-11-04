@MPS @UAT @TEST @BIEPC110
Feature: CloudMPSVerifyUKPDFContentsAreCorrect
	In order to ensure that PDF contents are correct when compared with Summary page
	As a MPS Dealer
	I want to be able to compare the values on summary page with PDF contents


Scenario Outline: MPS Verify PDF Correctness
	Given Dealer has created an awaiting acceptance contract of "<ContractType>" and "<UsageType>"
	When the dealer downloads PDF for the created contract
	Then the noted values above are available in the PDF content
	And I sign out of Cloud MPS


Scenarios:

	| ContractType                  | UsageType      |
	| Purchase & Click with Service | Minimum Volume |