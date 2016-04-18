Feature: CloudMPSVerifyProposalPDFContentsAreCorrect
	In order to ensure that Proposal PDF contents are correct when compared with Proposal Summary page
	As a MPS Dealer
	I want to be able to compare the values on Proposal Summary page with Proposal PDF contents


Scenario Outline: Dealer Can Download Proposal PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal
	When I download the generated proposal PDF
	Then the PDF is downloaded 
	And the contents of the PDF are correct


Scenarios: 
	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |
