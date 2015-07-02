# Device tests cannot be automated due to lack of device codes and everytime new device code has to be generated.

@ignore @UAT @TEST
Feature: AddDevice 
	In order to register my product with Brother
	As a customer
	I need to add my device in Brother Online

Background: 
	# Create an account on BOL and log in
	Given I am logged onto Brother Online "United Kingdom" using valid credentials

@ignore 
Scenario: Add My Device with no extended warranty
	Given I am redirected to the Welcome Back page
	When I have clicked on Add Device
	And I am redirected to the Register Device page
	And I have entered my product information
	| field            | value           |
	| SerialNumber     | - FromFile      |
	| Purchase Date    | 01/01/2015      |
	| PromoCode        |                 |
	| Supplier         | PrintersRUs.Com |
	| ExtendedWarranty | False           |
	And I have Agreed to Brothers Warranty Conditions
	When I click Continue
	Then my device should be successfully registered	
	And If I click Back To Brother online
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page  

@ignore @UAT @TEST
Scenario: Add My Device with an extended warranty pack
	Given I am redirected to the Welcome Back page
	When I have clicked on Add Device
	And I am redirected to the Register Device page
	And I have entered my product information
	| field            | value           |
	| SerialNumber     | - FromFile      |
	| Purchase Date    | 01/01/2014      |
	| PromoCode        |                 |
	| Supplier         | PrintersRUs.Com |
	| ExtendedWarranty | True            |
	And I have Agreed to Brothers Warranty Conditions
	When I click Continue
	And I have entered my extended warranty pack details
	When I click Continue
	Then I should be able to see my device registered with the warranty details attached
	And If I click Back To Brother online
	And If I sign out of Brother Online
	Then I am redirected to the Brother Home Page  
		
@ignore @UAT @TEST 
Scenario: Add My Device with an promotional code (work in progress)
Given I am redirected to the Welcome Back page
	When I have clicked on Add Device
	And I am redirected to the Register Device page
	And I have entered my product information
	| field            | value           |
	| SerialNumber     | - FromFile      |
	| Purchase Date    | 01/01/2015      |
	| PromoCode        | CASH 50         |
	| Supplier         | PrintersRUs.Com |
	| ExtendedWarranty | False           |
	And I have Agreed to Brothers Warranty Conditions
	When I click Continue
	Then my device should be successfully registered	
	And If I click Back To Brother online
	And I can sign out of Brother Online
	Then I am redirected to the Brother Home Page  



@ignore @UAT @TEST
Scenario: Add an Invalid device and check for correct error messages

