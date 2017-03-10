@MPS @UAT @TEST @BIEPC113
Feature: LocalOfficeApproverChangeCustomerAddress
	In order to change customer address
	As a Local Office Approver
	I want to be able to manipulate customer address from Special pricing page


Scenario Outline: Local Office Approver can change customer address
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" using the device "<Device1>" using Brother installation
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Type>" communication 
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online
	And I navigate to the Invoice tool homepage
	And I select "<Country>" of interest
	And I enter mono and colour print count for a single device
	And I generate invoices for the contract above
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	And Approver navigate to Data Query page
	When Approver navigates to customer information page for the proposal
	Then I can edit customer street name
	And I can edit customer contact first name
	And I can edit customer contact last name
	And I can update the changes made to customer details
	And the changes made above are displayed on summary page
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to existing customer screen
	And I navigate to the details of the newly edited customer
	And customer property town edited name is correctly displayed
	And customer contact edited first name is correctly displayed
	And customer contact edited last name is correctly displayed
	And I sign out of Cloud MPS


Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | Role1            | Method | Type | Length  | Billing              | Device1      | SerialNumber | Mono | Colour |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Cloud MPS Dealer | Cloud  | Web  | 4 years | Quarterly in Arrears | MFC-L8650CDW | A1T010289    | 5000 | 5000   |
	

Scenario Outline: Local Office Approver can change customer multiple addresses
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" using the device "<Device1>" using Brother installation
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Type>" communication 
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I navigate to customer and contact page
	And I navigate to the details of the newly edited customer
	And I add additional address to the customer
	And the newly added additional address is displayed
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Report page
	And Approver navigate to Data Query page
	When Approver navigates to customer information page for the proposal
	And Approver navigate to manage customer page for the first address
	Then approver can edit first customer street name
	And approver can edit first customer town name
	And approver can edit first customer area name
	And approver can edit first customer cost centre
	And approver can update the changes made to customer details
	##And the changes made above are displayed on summary page
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to existing customer screen
	And I navigate to the details of the newly edited customer
	And customer edited details are displayed
	And I sign out of Cloud MPS


Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | Role1            | Method | Type | Length  | Billing              | Device1      | SerialNumber | Mono | Colour |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Cloud MPS Dealer | Cloud  | Web  | 4 years | Quarterly in Arrears | MFC-L8650CDW | A1T010289    | 5000 | 5000   |
	
