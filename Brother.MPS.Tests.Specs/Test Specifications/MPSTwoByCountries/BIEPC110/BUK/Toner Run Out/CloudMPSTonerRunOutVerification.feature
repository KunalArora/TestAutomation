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
	And I can also see the details added

 
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
	

##Case 3-1
#@ignore
Scenario Outline: EUM - Engine Threshold Enabled Contract Disabled And Toner Life Equal Engine Threshold
	Given "<Country>" Dealer has created "<ContractType>" contract with Existing Customer "<ExistingCustomer>" with the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>" for "<Type>" communication 
	And I enter the device IP address
	And I can connect device "<Device1>" with serials "<SerialNumber>" and "<Device2>" to serials "<SerialNumber1>" and "<Device3>" with serials "<SerialNumber2>" and "<Device4>" with serials "<SerialNumber3>" to Brother environment
	And I can complete multiple devices installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	And I select "<Country>" as country of interest
	And I enable the mono threshold "<Threshold>"
	And I enable the colour threshold "<Threshold>"
	And I save the changes made above
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for multiple devices
	And I create a consumable order for ink life status for "Cyan" and "20" and "1"
	And I create a consumable order for ink life status for "Black" and "20" and "1"
	And I create a consumable order for ink life status for "Magenta" and "20" and "1"
	And I create a consumable order for ink life status for "Yellow" and "20" and "1"
	And I create a consumable order for ink life status for "Cyan" and "20" and "2"
	And I create a consumable order for ink life status for "Black" and "20" and "2"
	And I create a consumable order for ink life status for "Magenta" and "20" and "2"
	And I create a consumable order for ink life status for "Yellow" and "20" and "2"
	And I create a consumable order for ink life status for "Cyan" and "20" and "3"
	And I create a consumable order for ink life status for "Black" and "20" and "3"
	And I create a consumable order for ink life status for "Magenta" and "20" and "3"
	And I create a consumable order for ink life status for "Yellow" and "20" and "3"
	And I create a consumable order for ink life status for "Cyan" and "20" and "4"
	And I create a consumable order for ink life status for "Black" and "20" and "4"
	And I create a consumable order for ink life status for "Magenta" and "20" and "4"
	And I create a consumable order for ink life status for "Yellow" and "20" and "4"
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | ExistingCustomer                    | Role1            | Method | Type | Length  | Billing              | Device1     | Device2      | Device3     | Device4    | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               | Threshold |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Slater20170629084924@mailinator.com | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | DCP-9020CDW | DCP-L8400CDN | MFC-L2700DW | HL-L6250DN | A1T010536    | A1T010537     | A1T010538     | A1T010539     | Cloud MPS BIE Admin | 20        |
	
##Case 3-2
Scenario Outline: EUM - Engine Threshold Enabled Contract Disabled And Toner Life Less Than Engine Threshold
	Given "<Country>" Dealer has created "<ContractType>" contract with Existing Customer "<ExistingCustomer>" with the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>" for "<Type>" communication 
	And I enter the device IP address
	And I can connect device "<Device1>" with serials "<SerialNumber>" and "<Device2>" to serials "<SerialNumber1>" and "<Device3>" with serials "<SerialNumber2>" and "<Device4>" with serials "<SerialNumber3>" to Brother environment
	And I can complete multiple devices installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	And I select "<Country>" as country of interest
	And I enable the mono threshold "<Threshold>"
	And I enable the colour threshold "<Threshold>"
	And I save the changes made above
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for multiple devices
	And I create a consumable order for ink life status for "Cyan" and "19" and "1"
	And I create a consumable order for ink life status for "Black" and "19" and "1"
	And I create a consumable order for ink life status for "Magenta" and "19" and "1"
	And I create a consumable order for ink life status for "Yellow" and "19" and "1"
	And I create a consumable order for ink life status for "Cyan" and "19" and "2"
	And I create a consumable order for ink life status for "Black" and "19" and "2"
	And I create a consumable order for ink life status for "Magenta" and "19" and "2"
	And I create a consumable order for ink life status for "Yellow" and "19" and "2"
	And I create a consumable order for ink life status for "Cyan" and "19" and "3"
	And I create a consumable order for ink life status for "Black" and "19" and "3"
	And I create a consumable order for ink life status for "Magenta" and "19" and "3"
	And I create a consumable order for ink life status for "Yellow" and "19" and "3"
	And I create a consumable order for ink life status for "Cyan" and "19" and "4"
	And I create a consumable order for ink life status for "Black" and "19" and "4"
	And I create a consumable order for ink life status for "Magenta" and "19" and "4"
	And I create a consumable order for ink life status for "Yellow" and "19" and "4"
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | ExistingCustomer                    | Role1            | Method | Type | Length  | Billing              | Device1     | Device2      | Device3     | Device4    | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               | Threshold |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Slater20170629002409@mailinator.com | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | DCP-9020CDW | DCP-L8400CDN | MFC-L2700DW | HL-L6250DN | A1T010552    | A1T010553     | A1T010554     | A1T010555     | Cloud MPS BIE Admin | 20        |
	
#@ignore
Scenario Outline: EUM - Engine Threshold Enabled Contract Enabled And Toner Life Equal Engine Threshold 
	Given "<Country>" Dealer has created "<ContractType>" contract with Existing Customer "<ExistingCustomer>" with the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>" for "<Type>" communication 
	And I enter the device IP address
	And I can connect device "<Device1>" with serials "<SerialNumber>" and "<Device2>" to serials "<SerialNumber1>" and "<Device3>" with serials "<SerialNumber2>" and "<Device4>" with serials "<SerialNumber3>" to Brother environment
	And I can complete multiple devices installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	And I select "<Country>" as country of interest
	And I enable the mono threshold "<Threshold>"
	And I enable the colour threshold "<Threshold>"
	And I save the changes made above
	And I navigate to installed printer page
	And I search for contract using contract id
	And I enter toner ink threshold of "15" for all the printers  
	And I enable the threshold for all the printers
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for multiple devices
	And I create a consumable order for ink life status for "Cyan" and "20" and "1"
	And I create a consumable order for ink life status for "Black" and "20" and "1"
	And I create a consumable order for ink life status for "Magenta" and "20" and "1"
	And I create a consumable order for ink life status for "Yellow" and "20" and "1"
	And I create a consumable order for ink life status for "Cyan" and "20" and "2"
	And I create a consumable order for ink life status for "Black" and "20" and "2"
	And I create a consumable order for ink life status for "Magenta" and "20" and "2"
	And I create a consumable order for ink life status for "Yellow" and "20" and "2"
	And I create a consumable order for ink life status for "Cyan" and "20" and "3"
	And I create a consumable order for ink life status for "Black" and "20" and "3"
	And I create a consumable order for ink life status for "Magenta" and "20" and "3"
	And I create a consumable order for ink life status for "Yellow" and "20" and "3"
	And I create a consumable order for ink life status for "Cyan" and "20" and "4"
	And I create a consumable order for ink life status for "Black" and "20" and "4"
	And I create a consumable order for ink life status for "Magenta" and "20" and "4"
	And I create a consumable order for ink life status for "Yellow" and "20" and "4"
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | ExistingCustomer                      | Role1            | Method | Type | Length  | Billing              | Device1     | Device2      | Device3     | Device4    | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               | Threshold |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Smarties20170629005346@mailinator.com | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | DCP-9020CDW | DCP-L8400CDN | MFC-L2700DW | HL-L6250DN | A1T010556    | A1T010557     | A1T010558     | A1T010559     | Cloud MPS BIE Admin | 20        |
	

	
#@ignore
Scenario Outline: EUM - Engine Threshold Enabled Contract Enabled And Toner Life Less Than Engine Threshold 
	Given "<Country>" Dealer has created "<ContractType>" contract with Existing Customer "<ExistingCustomer>" with the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>" for "<Type>" communication 
	And I enter the device IP address
	And I can connect device "<Device1>" with serials "<SerialNumber>" and "<Device2>" to serials "<SerialNumber1>" and "<Device3>" with serials "<SerialNumber2>" and "<Device4>" with serials "<SerialNumber3>" to Brother environment
	And I can complete multiple devices installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	And I select "<Country>" as country of interest
	And I enable the mono threshold "<Threshold>"
	And I enable the colour threshold "<Threshold>"
	And I save the changes made above
	And I navigate to installed printer page
	And I search for contract using contract id
	And I enter toner ink threshold of "15" for all the printers  
	And I enable the threshold for all the printers
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for multiple devices
	And I create a consumable order for ink life status for "Cyan" and "17" and "1"
	And I create a consumable order for ink life status for "Black" and "17" and "1"
	And I create a consumable order for ink life status for "Magenta" and "17" and "1"
	And I create a consumable order for ink life status for "Yellow" and "17" and "1"
	And I create a consumable order for ink life status for "Cyan" and "17" and "2"
	And I create a consumable order for ink life status for "Black" and "17" and "2"
	And I create a consumable order for ink life status for "Magenta" and "17" and "2"
	And I create a consumable order for ink life status for "Yellow" and "17" and "2"
	And I create a consumable order for ink life status for "Cyan" and "17" and "3"
	And I create a consumable order for ink life status for "Black" and "17" and "3"
	And I create a consumable order for ink life status for "Magenta" and "17" and "3"
	And I create a consumable order for ink life status for "Yellow" and "17" and "3"
	And I create a consumable order for ink life status for "Cyan" and "17" and "4"
	And I create a consumable order for ink life status for "Black" and "17" and "4"
	And I create a consumable order for ink life status for "Magenta" and "17" and "4"
	And I create a consumable order for ink life status for "Yellow" and "17" and "4"
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | ExistingCustomer                   | Role1            | Method | Type | Length  | Billing              | Device1     | Device2      | Device3     | Device4    | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               | Threshold |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Lonna20170629011852@mailinator.com | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | DCP-9020CDW | DCP-L8400CDN | MFC-L2700DW | HL-L6250DN | A1T010548    | A1T010549     | A1T010550     | A1T010551     | Cloud MPS BIE Admin | 20        |
	

#@ignore
Scenario Outline: EUM - Engine Threshold Enabled Contract Enabled And Toner Life Equal Contract Threshold 
	Given "<Country>" Dealer has created "<ContractType>" contract with Existing Customer "<ExistingCustomer>" with the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>" for "<Type>" communication 
	And I enter the device IP address
	And I can connect device "<Device1>" with serials "<SerialNumber>" and "<Device2>" to serials "<SerialNumber1>" and "<Device3>" with serials "<SerialNumber2>" and "<Device4>" with serials "<SerialNumber3>" to Brother environment
	And I can complete multiple devices installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	And I select "<Country>" as country of interest
	And I enable the mono threshold "<Threshold>"
	And I enable the colour threshold "<Threshold>"
	And I save the changes made above
	And I navigate to installed printer page
	And I search for contract using contract id
	And I enter toner ink threshold of "15" for all the printers  
	And I enable the threshold for all the printers
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for multiple devices
	And I create a consumable order for ink life status for "Cyan" and "15" and "1"
	And I create a consumable order for ink life status for "Black" and "15" and "1"
	And I create a consumable order for ink life status for "Magenta" and "15" and "1"
	And I create a consumable order for ink life status for "Yellow" and "15" and "1"
	And I create a consumable order for ink life status for "Cyan" and "15" and "2"
	And I create a consumable order for ink life status for "Black" and "15" and "2"
	And I create a consumable order for ink life status for "Magenta" and "15" and "2"
	And I create a consumable order for ink life status for "Yellow" and "15" and "2"
	And I create a consumable order for ink life status for "Cyan" and "15" and "3"
	And I create a consumable order for ink life status for "Black" and "15" and "3"
	And I create a consumable order for ink life status for "Magenta" and "15" and "3"
	And I create a consumable order for ink life status for "Yellow" and "15" and "3"
	And I create a consumable order for ink life status for "Cyan" and "15" and "4"
	And I create a consumable order for ink life status for "Black" and "15" and "4"
	And I create a consumable order for ink life status for "Magenta" and "15" and "4"
	And I create a consumable order for ink life status for "Yellow" and "15" and "4"
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | ExistingCustomer                    | Role1            | Method | Type | Length  | Billing              | Device1     | Device2      | Device3     | Device4    | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               | Threshold |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Delsie20170629075227@mailinator.com | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | DCP-9020CDW | DCP-L8400CDN | MFC-L2700DW | HL-L6250DN | A1T010544    | A1T010545     | A1T010546     | A1T010547     | Cloud MPS BIE Admin | 20        |
	
#@ignore
Scenario Outline: EUM - Engine Threshold Enabled Contract Enabled And Toner Life Less Than Contract Threshold 
	Given "<Country>" Dealer has created "<ContractType>" contract with Existing Customer "<ExistingCustomer>" with the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>" for "<Type>" communication 
	And I enter the device IP address
	And I can connect device "<Device1>" with serials "<SerialNumber>" and "<Device2>" to serials "<SerialNumber1>" and "<Device3>" with serials "<SerialNumber2>" and "<Device4>" with serials "<SerialNumber3>" to Brother environment
	And I can complete multiple devices installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	And I select "<Country>" as country of interest
	And I enable the mono threshold "<Threshold>"
	And I enable the colour threshold "<Threshold>"
	And I save the changes made above
	And I navigate to installed printer page
	And I search for contract using contract id
	And I enter toner ink threshold of "15" for all the printers  
	And I enable the threshold for all the printers
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for multiple devices
	And I create a consumable order for ink life status for "Cyan" and "14" and "1"
	And I create a consumable order for ink life status for "Black" and "14" and "1"
	And I create a consumable order for ink life status for "Magenta" and "14" and "1"
	And I create a consumable order for ink life status for "Yellow" and "14" and "1"
	And I create a consumable order for ink life status for "Cyan" and "14" and "2"
	And I create a consumable order for ink life status for "Black" and "14" and "2"
	And I create a consumable order for ink life status for "Magenta" and "14" and "2"
	And I create a consumable order for ink life status for "Yellow" and "14" and "2"
	And I create a consumable order for ink life status for "Cyan" and "14" and "3"
	And I create a consumable order for ink life status for "Black" and "14" and "3"
	And I create a consumable order for ink life status for "Magenta" and "14" and "3"
	And I create a consumable order for ink life status for "Yellow" and "14" and "3"
	And I create a consumable order for ink life status for "Cyan" and "14" and "4"
	And I create a consumable order for ink life status for "Black" and "14" and "4"
	And I create a consumable order for ink life status for "Magenta" and "14" and "4"
	And I create a consumable order for ink life status for "Yellow" and "14" and "4"
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | ExistingCustomer                    | Role1            | Method | Type | Length  | Billing              | Device1     | Device2      | Device3     | Device4    | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               | Threshold |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Bradon20170629055306@mailinator.com | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | DCP-9020CDW | DCP-L8400CDN | MFC-L2700DW | HL-L6250DN | A1T010540    | A1T010541     | A1T010542     | A1T010543     | Cloud MPS BIE Admin | 20        |
	

##Disabled Engine Threshold Enabled Contract Threshold
Scenario Outline: EUM - Engine Threshold Disabled Contract Enabled And Toner Life Equal Contract Threshold 
	Given "<Country>" Dealer has created "<ContractType>" contract with Existing Customer "<ExistingCustomer>" with the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>" for "<Type>" communication 
	And I enter the device IP address
	And I can connect device "<Device1>" with serials "<SerialNumber>" and "<Device2>" to serials "<SerialNumber1>" and "<Device3>" with serials "<SerialNumber2>" and "<Device4>" with serials "<SerialNumber3>" to Brother environment
	And I can complete multiple devices installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	And I select "<Country>" as country of interest
	And I disable Engine threshold
	And I save the changes made above
	And I navigate to installed printer page
	And I search for contract using contract id
	And I enter toner ink threshold of "15" for all the printers  
	And I enable the threshold for all the printers
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for multiple devices
	And I create a consumable order for ink life status for "Cyan" and "15" and "1"
	And I create a consumable order for ink life status for "Black" and "15" and "1"
	And I create a consumable order for ink life status for "Magenta" and "15" and "1"
	And I create a consumable order for ink life status for "Yellow" and "15" and "1"
	And I create a consumable order for ink life status for "Cyan" and "15" and "2"
	And I create a consumable order for ink life status for "Black" and "15" and "2"
	And I create a consumable order for ink life status for "Magenta" and "15" and "2"
	And I create a consumable order for ink life status for "Yellow" and "15" and "2"
	And I create a consumable order for ink life status for "Cyan" and "15" and "3"
	And I create a consumable order for ink life status for "Black" and "15" and "3"
	And I create a consumable order for ink life status for "Magenta" and "15" and "3"
	And I create a consumable order for ink life status for "Yellow" and "15" and "3"
	And I create a consumable order for ink life status for "Cyan" and "15" and "4"
	And I create a consumable order for ink life status for "Black" and "15" and "4"
	And I create a consumable order for ink life status for "Magenta" and "15" and "4"
	And I create a consumable order for ink life status for "Yellow" and "15" and "4"
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | ExistingCustomer                      | Role1            | Method | Type | Length  | Billing              | Device1     | Device2      | Device3     | Device4    | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Epifania20170629010026@mailinator.com | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | DCP-9020CDW | DCP-L8400CDN | MFC-L2700DW | HL-L6250DN | A1T010281    | A1T010282     | A1T010283     | A1T010284     | Cloud MPS BIE Admin |
	
#@ignore
Scenario Outline: EUM - Engine Threshold Disabled Contract Enabled And Toner Life Less Than Contract Threshold 
	Given "<Country>" Dealer has created "<ContractType>" contract with Existing Customer "<ExistingCustomer>" with the following "<UsageType>" and "<Length>" and "<Billing>" and "<Device1>" and "<Device2>" and "<Device3>" and "<Device4>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>" for "<Type>" communication 
	And I enter the device IP address
	And I can connect device "<Device1>" with serials "<SerialNumber>" and "<Device2>" to serials "<SerialNumber1>" and "<Device3>" with serials "<SerialNumber2>" and "<Device4>" with serials "<SerialNumber3>" to Brother environment
	And I can complete multiple devices installation
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<Role2>" from "<Country>"
	And I navigate to Enhanced Usage Monitoring Installed Page
	And I navigate to Enhanced Usage Monitoring Printer Engine Page
	And I select "<Country>" as country of interest
	And I disable Engine threshold
	And I save the changes made above
	And I navigate to installed printer page
	And I search for contract using contract id
	And I enter toner ink threshold of "15" for all the printers  
	And I enable the threshold for all the printers
	And I can sign out of Brother Online
	And I sign into Cloud MPS as a "<ExistingCustomer>" from "<Country>"
	And I navigate to customer dashboard page
	And I navigate to consumable ordering page for multiple devices
	And I create a consumable order for ink life status for "Cyan" and "14" and "1"
	And I create a consumable order for ink life status for "Black" and "14" and "1"
	And I create a consumable order for ink life status for "Magenta" and "14" and "1"
	And I create a consumable order for ink life status for "Yellow" and "14" and "1"
	And I create a consumable order for ink life status for "Cyan" and "14" and "2"
	And I create a consumable order for ink life status for "Black" and "14" and "2"
	And I create a consumable order for ink life status for "Magenta" and "14" and "2"
	And I create a consumable order for ink life status for "Yellow" and "14" and "2"
	And I create a consumable order for ink life status for "Cyan" and "14" and "3"
	And I create a consumable order for ink life status for "Black" and "14" and "3"
	And I create a consumable order for ink life status for "Magenta" and "14" and "3"
	And I create a consumable order for ink life status for "Yellow" and "14" and "3"
	And I create a consumable order for ink life status for "Cyan" and "14" and "4"
	And I create a consumable order for ink life status for "Black" and "14" and "4"
	And I create a consumable order for ink life status for "Magenta" and "14" and "4"
	And I create a consumable order for ink life status for "Yellow" and "14" and "4"
	And I can sign out of Brother Online

Scenarios:
	| Role                            | Country        | ContractType                  | UsageType     | ExistingCustomer                    | Role1            | Method | Type | Length  | Billing              | Device1     | Device2      | Device3     | Device4    | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Role2               |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go | Delsie20170629084038@mailinator.com | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | DCP-9020CDW | DCP-L8400CDN | MFC-L2700DW | HL-L6250DN | A1T010285    | A1T010286     | A1T010287     | A1T010288     | Cloud MPS BIE Admin |
	
