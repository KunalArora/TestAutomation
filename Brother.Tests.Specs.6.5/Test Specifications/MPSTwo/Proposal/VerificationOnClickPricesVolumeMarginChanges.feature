@Ignore @UAT @TEST
Feature: VerificationOnClickPricesVolumeMarginChanges
	In order to make sure that the Javascript around click prices and margin are not broken
	As a dealer
	I want to be see click price, cost price, sell price and margin respond to changes in values


Scenario Outline: Verify that click price and other prices respond to changes in relevant values
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Customer Information Detail for new customer
	And I Enter "<Contract>" contract terms "<Leasing>" leasing and "<Billing>" billing on Term and Type details
	And I changed the Product view to flat list
	When I select "<Printer>" from the product flat list
	Then changes in a field affect the values in the corresponding fields
	#And click prices are changed accordingly


	Scenarios: 

	| Role             | Country | Contract | Leasing                  | Billing                    | Printer     | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Germany | 4 Jahre  | 6 Monatlich Mindestvolumen | 6 Monatlich Mindestvolumen | HL-L8250CDN | 2000        | 2000         |
	

