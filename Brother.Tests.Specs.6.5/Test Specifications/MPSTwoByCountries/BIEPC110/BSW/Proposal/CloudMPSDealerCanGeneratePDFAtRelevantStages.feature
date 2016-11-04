@MPS @TEST @UAT @BIEPC110
Feature: CloudMPSSwissDealerCanGeneratePDFAtRelevantStages
	In order to generate Proposal PDF
	As a dealer
	I want to create a proposal for which a PDF for which a proposal can be downloaded


Scenario Outline: Dealer Can Generate PDF Purchase and Click Minimum Summary Page
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	#And I choose an existing contact from the list of available contacts
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details  
	And I "<PriceHardware>" Price Hardware radio button
	And I display "<Printer>" device screen
	And "<DeviceScreen>" device screen is displayed
	And I accept the default values of the device
	##And Service Pack payment method is displayed
	##And I choose to pay Service Packs "<PaymentMethod>"
	#And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	And I type click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then I can generate customer PDF for the proposal
	##And I can generate dealer PDF for the proposal
	And I click Save Proposal button on Summary screen
	And I am directed to Proposals screen of Proposal List page
	And the newly created proposal is displayed on the list
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country     | ContractType                 | UsageType      | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod               | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Switzerland | Purchase & Click mit Service | Pay As You Go  | 36       | Quartalsweise        | Tick          | MFC-L8650CDW | Full         | Über den Seitenpreis zahlen | 2000        | 2000         |
	##| Cloud MPS Dealer | Switzerland | Purchase & Click mit Service | Mindestvolumen | 36       | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Über den Seitenpreis zahlen | 2000        | 2000         |
	
	
