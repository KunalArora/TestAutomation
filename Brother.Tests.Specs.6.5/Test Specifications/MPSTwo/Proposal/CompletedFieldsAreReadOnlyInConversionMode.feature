@UAT @TEST
Feature: CompletedFieldsAreReadOnlyInConversionMode
	In order to prevent new values being entered into contracts during conversion
	As an MPS Dealer
	I want all previously completed fields within a proposal to be read-only during contract conversion

Scenario Outline: Completed Fields Are Read Only During Contract Conversion Mode
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I choose "<Printer>" from Products screen
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	When I create the proposal with details above
	When I start the contract conversion process
	Then only the previously selected printer has Details button
	And fields on "Click Price" screen are disabled
	And fields on "Term & Type" screen are disabled
	And fields on "Customer Information" screen are disabled
	And fields on "Proposal Description" screen are disabled


	Scenarios: 

	| Role             | Country | Contract | Leasing                  | Billing                    | Printer      | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | 4 Jahre  | 4 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | DCP-L8400CDN | 1800        | 2000         |

	
