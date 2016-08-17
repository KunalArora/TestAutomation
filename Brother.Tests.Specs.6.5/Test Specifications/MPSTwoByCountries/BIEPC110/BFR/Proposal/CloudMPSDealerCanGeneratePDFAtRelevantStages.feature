@MPS @TEST @UAT
Feature: CloudMPSFrenchDealerCanGeneratePDFAtRelevantStages
	In order to generate Proposal PDF
	As a dealer
	I want to create a proposal for which a PDF for which a proposal can be downloaded


Scenario Outline: MPS Generate Summary PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I send the created proposal for approval
	And I navigate to the Summary page of the proposal awaiting approval
	And I download the generated proposal PDF
	Then the contents of the PDF is correct including correct "<ContractType>"
	And I sign out of Cloud MPS
	
	
	Scenarios: 
	| Role             | Country | Role2                           | ContractType | UsageType                                 | Length | Billing                |
	| Cloud MPS Dealer | France  | Cloud MPS Local Office Approver | Buy & Click  | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata |
	