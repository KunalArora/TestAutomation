@MPS @TEST @UAT
Feature: CloudMPSBelgianDealerCanGeneratePDFAtRelevantStages
	In order to generate Proposal PDF
	As a dealer
	I want to create a proposal for which a PDF for which a proposal can be downloaded


Scenario Outline: MPS Generate Summary PDF
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" "<Language>"proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I send the created proposal for approval
	And I navigate to the Summary page of the proposal awaiting approval
	And I download the generated proposal PDF
	Then the contents of the PDF is correct including correct "<ContractType>"
	And I sign out of Cloud MPS
	
	
	Scenarios: 
	| Role             | Country | Role2                           | ContractType                  | UsageType      | Length | Billing              | Language |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Purchase & Click with Service | Minimum Volume | 3 jaar | Quarterly in Arrears | Dutch    |
	| Cloud MPS Dealer | Belgium | Cloud MPS Local Office Approver | Buy & Click                   | Volume minimum | 3 ans  | Quarterly in Arrears | French   |
	