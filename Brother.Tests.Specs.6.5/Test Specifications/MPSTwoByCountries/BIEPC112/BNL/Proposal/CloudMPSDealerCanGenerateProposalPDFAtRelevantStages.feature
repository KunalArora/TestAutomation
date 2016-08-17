@MPS @TEST @UAT
Feature: CloudMPSDutchDealerCanGeneratePDFAtRelevantStages
	In order to generate Proposal PDF
	As a dealer
	I want to create a proposal for which a PDF for which a proposal can be downloaded

Scenario Outline: MPS Dutch Dealer Can Generate PDF Purchase and Click Minimum Summary Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	And Service Pack payment method is displayed
	And I choose to pay Service Packs "<PaymentMethod>"
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then I can generate customer PDF for the proposal
	##And I can generate dealer PDF for the proposal
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country     | ContractType                 | UsageType     | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod          | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Netherlands | Purchase + Click met Service | Minimumvolume | 3 jaar   | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Opgenomen in klikprijs | 2000        | 2000         |
	

Scenario Outline: MPS Dutch Dealer Can Generate PDF for Purchase and Click in Awaiting Approval Status for other countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I send the created proposal for approval
	And I navigate to the Summary page of the proposal awaiting approval
	And I download the generated proposal PDF
	Then the contents of the PDF is correct including correct "<ContractType>"
	And I sign out of Cloud MPS
	
	
	Scenarios: 
	| Role             | Country     | Role2                           | ContractType                 | UsageType     | Length | Billing              |
	| Cloud MPS Dealer | Netherlands | Cloud MPS Local Office Approver | Purchase + Click met Service | Minimumvolume | 3 jaar | Quarterly in Arrears |
	