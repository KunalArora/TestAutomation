 @TEST @UAT @MPS @BIEPC110
Feature: CloudMPSTonerRunOutVerification
	In order to ensure toner does not run out for any customer
	As a BIE Admin
	I want to be set both global and individual toner run out level


Scenario Outline: EUM - All Countries Are Selectable
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	When I select the "<Country>" printer engine
	Then all the printer engine for that country is displayed


Scenarios: 
 | Role                | Country        |
 | Cloud MPS BIE Admin | United Kingdom |
 #| Cloud MPS BIE Admin | Poland         |


@ignore
Scenario Outline: EUM - Put a Threshold on a Printer Engine
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	When I tick the Enable checkbox
	And I enter "20" into threshold field
	And I save the changes
	Then The values entered are displayed
	And I can also the details added

 
Scenarios: 
 | Role                | Country        |
 | Cloud MPS BIE Admin | United Kingdom |

 
Scenario Outline: EUM - Search By Contract Id
	Given "<Country>" Dealer has created "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter device serial number "<SerialNumber>" for "<Method>" communication
	And I enter the device IP address
	##Then I can connect device "<Device1>" with serials "<SerialNumber>" to Brother environment
	And I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I search for contract using contract id
	Then contract printer details are displayed
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | Role1            | Method | Length  | Billing              | Device1     | SerialNumber | Role2               |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Cloud MPS Dealer | Email  | 4 years | Quarterly in Arrears | DCP-9015CDW | A1T010273    | Cloud MPS BIE Admin |
	


Scenario Outline: EUM - Search For An Invalid Contract Id
	Given I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	When I search for an invalid contract id "9856"
	Then an error message is displayed
	And I can sign out of Brother Online

Scenarios:
	| Country        |  Role2               |
	| United Kingdom |  Cloud MPS BIE Admin |


Scenario Outline: EUM - Enable And Disable Contract Threshold
	Given "<Country>" Dealer has created "<ContractType>" contract the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	And I enter the device IP address
	##Then I can connect device "<Device1>" with serials "<SerialNumber>" to Brother environment
	And I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I search for contract using contract id
	Then contract printer details are displayed
	And I can enter a threshold of "30.00" into all the thresholds
	And I can enabled all the devices
	And I can verify that all the changes made are with threshold of "30.00"
	And I can disable all the thresholds
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | Role1            | Method | Length  | Billing              | Device1     | Device2     | Device3      | Device4     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Cloud MPS Dealer | Email  | 4 years | Quarterly in Arrears | DCP-9020CDW | MFC-L5750DW | MFC-L8650CDW | MFC-J6930DW | A1T010386    | A1T010387     | A1T010388     | A1T010389     | Cloud MPS BIE Admin |
	

	
