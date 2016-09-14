@TEST
Feature: ProductRegistration
	In order to register a product
	End user will login to existing account or create a new account

@TEST @SMOKE
Scenario Outline: Verify the Header and Footer of the landing page
Given I navigate to "<Site Url>" in order to validate the landing page
Then I should see the Header and the Footer appearing on the landing Page
Scenarios:
| Country        | Site Url                               |
| United Kingdom | http://atyourside.co.uk.brotherdv2.eu/ |

@TEST @SMOKE
Scenario Outline: Customer wants to register product with their serial numbers and promo code
	Given I navigate to "<Site Url>" in order to validate the landing page
	And I have entered my product "<SerialNumber>"
	And clicked on Find Product Butoon



	#| Purchase Date    | 01/01/2015      |
	#| PromoCode        |                 |
	#| Supplier         | PrintersRUs.Com |
	#| ExtendedWarranty | False           |
	#And I have Agreed to Brothers Warranty Conditions
	#When I click Continue
	#Then my device should be successfully registered	
	#And If I click Back To Brother online
	#And I can sign out of Brother Online
	#Then I am redirected to the Brother Home Page  

Scenarios: 
| Country        | Site Url                                                                     | SerialNumber |
| United Kingdom | http://atyourside.co.uk.brotherdv2.eu/QA/AutomationPleaseDoNotTouch/Step-one | U1T004747    |