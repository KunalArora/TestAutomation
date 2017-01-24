@MPS @UAT @TEST @BIEPC113
Feature: CloudMPSVerifyGermanPDFContentsAreCorrect
	In order to ensure that PDF contents are correct when compared with Summary page
	As a MPS Dealer
	I want to be able to compare the values on summary page with PDF contents


Scenario Outline: MPS Verify PDF Correctness
	Given German Dealer have created a "<Country>" awating acceptance contract of "<ContractType>" and "<UsageType>"
	When the dealer downloads PDF for the created contract
	Then the noted values above are available in the PDF content
	And I sign out of Cloud MPS

	Scenarios:

	| Country | ContractType             | UsageType      | 
	| Germany | Easy Print Pro & Service | Mindestvolumen | 
	| Germany | Leasing & Service        | Mindestvolumen | 
	| Austria | Easy Print Pro & Service | Mindestvolumen | 
	#| Austria | Leasing & Service        | Mindestvolumen | 