@TEST @UAT @MPS @BIEPC110
Feature: CloudMPSUKServiceRequestOperations
	In order to get my devices issues fix by Brother
	As an MPS user
	I want to be able to raise service request which can be worked on


Scenario Outline: MPS Actions For Customers
	Given "<Country>" Dealer have created "<ContractType>" contract choosing "<ExistingCustomer>" with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I install the device with "<SerialNumber>" on the contract with "<Method>" communication and "<Type>" installation
	Then I can create automatic service request for "<Component>" 
	And I can sign out of Brother Online
	
	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type | ExistingCustomer                    | Length  | Billing              | SerialNumber | Component |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | Slater20170119031946@mailinator.com | 3 years | Quarterly in Arrears | A1T010237    | FuserUnit |
	

@ignore
Scenario Outline: MPS Actions For Customers By Email
	Given "<Country>" Dealer have created "<ContractType>" contract choosing "<ExistingCustomer>" with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I install the device with "<SerialNumber>" on the contract with "<Method>" communication and "<Type>" installation
	Then I can use "<Model>" to create automatic service request for "<Component>" through email with "<SerialNumber>"
	And I can sign out of Brother Online
	
	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | ExistingCustomer                 | Length  | Billing              | SerialNumber | Component     | Model        |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  | Omer2017067101751@mailinator.com | 3 years | Quarterly in Arrears | A1T010237    | Belt End Soon | MFC-L8650CDW |
	


Scenario Outline: MPS Actions To Create Contract for Service Request
	Given "<Country>" Dealer have created "<ContractType>" contract choosing "<ExistingCustomer>" with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	When I install the device with "<SerialNumber>" on the contract with "<Method>" communication and "<Type>" installation
	And I can sign out of Brother Online
	
	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type | ExistingCustomer                    | Length  | Billing              | SerialNumber |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | Lonna20170210045259@mailinator.com  | 3 years | Quarterly in Arrears | A1T010390    |
	

Scenario Outline: MPS Close Service Request
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to customer request page
	When I raise a service request
	And the service request is created and displayed
	And all the functionalities of the service request work
	And I can sign out of Brother Online
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	Then the created service request is displayed for Service Desk 
	##And Service Desk can close the service request
	And I can sign out of Brother Online

	
Scenarios:

	| Country        | Role2                  | Method | Role1                               |
	| United Kingdom | Cloud MPS Service Desk | Email  | Lonna20170210045259@mailinator.com  |
	

Scenario Outline: MPS Service Desk Response
	Given I sign into Cloud MPS as a "<Role1>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to customer request page
	When I raise a service request
	And the service request is created and displayed
	And I can send message to Service Desk user
	And I can sign out of Brother Online
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	Then the created service request is displayed for Service Desk 
	And I can see the message sent by customer and reply
	And I can sign out of Brother Online
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I can see the reply from Service Desk
	And I can sign out of Brother Online
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And the created service request is displayed for Service Desk 
##	And Service Desk can close the service request
	And I can sign out of Brother Online

	
Scenarios:

	| Country        | Role2                  | Method | Role1                               |
	| United Kingdom | Cloud MPS Service Desk | Email  | Lonna20170210045259@mailinator.com  |



	
