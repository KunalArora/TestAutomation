@UAT @TEST
Feature: VerificationsOnProductsPage
	In order to verify that products can be view in flat list mode
	As a dealer
	I want to be able to click a button and the products are listed in a flat list

Background: Get to MPS Product Page for verification
	Given I sign into Cloud MPS as a "Cloud MPS Dealer" from "Germany"
	And I navigate to Customer Information Detail for new customer
	And I Enter "4 Jahre" contract terms "6 Monatlich Mindestvolumen" leasing and "6 Monatlich Mindestvolumen" billing on Term and Type details
	When I changed the Product view to flat list

Scenario: Should be able to display products in flat list and do some verifications
	Then Products are displayed in flat list mode
	And I can sign out of Brother Online

Scenario: The Product's fields are pre-populated
	When I select "HL-L8250CDN" from the product flat list
	Then the fields on "Model" screen are prepopulated
	#And the fields on "Installation" screen are prepopulated
	And the fields on "Options" screen are prepopulated
	#And the fields on "Click Price" screen are prepopulated
