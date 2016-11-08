@TEST
Feature: ProductRegistration
	In order to register a product
	End user will login to existing account or create a new account

@SMOKE
Scenario Outline: Verify the Header and Footer of the landing page
#Given I navigate to "<Country>" in order to validate the landing page
Given I navigate to "<Country>" Brother Online landing page
Then I should see the Header and the Footer appearing on the landing Page
Scenarios:
| Country        |
| United Kingdom |

@SMOKE
Scenario Outline: New Customer wants to register product with their serial numbers and purchase date
	
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
	And I have entered my product "<SerialNumber>"
	And clicked on Find Product Button
	And I have entered "<PurchaseDate>" 
	And I entered apply button
	And I click on continue button
	Then I can register my "<Email>" on  user details page  
	And I enter "<FirstName>"  and "<LastName>" on  user details page
	And I tick on terms and conditions checkbox
	Then I can complete my product registration by clicking on complete registration button

Scenarios: 
| Country        | Site Url                  | SerialNumber | PurchaseDate | Email                                | FirstName | LastName |
| United Kingdom | /qa/eubol78/serial-number | U1T004758    | 12/12/2013   | testemailidinputfield@mailinator.com | Test      | Test     |


@SMOKE
Scenario Outline: New Customer wants to register product with their serial numbers and purchase date in the file
	Given I navigate to "<Country>" Brother Online landing page
	And I browse to the "<Site Url>" product registration page
	And I have entered my product SerialNumber reading from the environmental variable
	And clicked on Find Product Button
	And I have entered "<PurchaseDate>" 
	And I entered apply button
	And I click on continue button
	Then I can register my "<Email>" on  user details page  
	And I enter "<FirstName>"  and "<LastName>" on  user details page
	And I tick on terms and conditions checkbox
	Then I can complete my product registration by clicking on complete registration button

Scenarios: 
| Country        | Site Url                  | PurchaseDate | Email                                | FirstName | LastName |
| United Kingdom | /qa/eubol78/serial-number | 12/12/2013   | testemailidinputfield@mailinator.com | Test      | Test     |