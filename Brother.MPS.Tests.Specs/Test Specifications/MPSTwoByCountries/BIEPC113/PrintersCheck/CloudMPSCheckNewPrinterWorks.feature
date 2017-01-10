	@ignore @TEST @UAT @MPS @BIEPC113
	Feature: CloudMPSCheckNewPrinterWorks
	In order to ensure that new printers work as expected
	As a dealer
	I want to perform a thorough check on new printers


Scenario Outline: MPS Printer Checks
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I am on MPS New Proposal Page
	When I fill Proposal Description for "<ContractType>" Contract type
	And I choose an existing contact from the list of available contacts
	And I Enter "<UsageType>" usage type "<Contract>" contract length and "<Billing>" billing on Term and Type details
	And I select service pack "<PaymentMethod>" payment method  
	And I "<PriceHardware>" Price Hardware radio button
	And I accept the default value of printer "<Printer>"
	And Service Pack In Click line is displayed
	And I enter click price volume of "<ClickVolume>" and "<ColourVolume>"
	Then clicking on the displayed printer "<Printer>" link takes me back to the device screen
	And I sign out of Cloud MPS
	

	Scenarios: 
	| Role             | Country | ContractType           | UsageType       | Contract | Billing              | PriceHardware | Printer     | ClickVolume | ColourVolume |
	| Cloud MPS Dealer | Denmark | Køb & Klik med service | Minimumsvolumen | 3 år     | Quarterly in Arrears | Tick          | MFC-J5330DW | 800         | 800          |
	


##@ignore
Scenario Outline: Single Installation With New Printer
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
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online
	And I navigate to the Invoice tool homepage
	And I select "<Country>" of interest
	And I enter "<Mono>" and "<Colour>" print count for a single device
	And I generate invoices for the contract above

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType                | Role1            | Method | Length   | Billing               | Device1     | SerialNumber | Mono | Colour |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 år     | Quarterly in Arrears  | MFC-J5330DW | A1T010391    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 år     | Quarterly in Arrears  | MFC-J5730DW | A1T010392    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 år     | Quarterly in Arrears  | MFC-J5930DW | A1T010393    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 år     | Quarterly in Arrears  | MFC-J6530DW | A1T010394    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 år     | Quarterly in Arrears  | MFC-J6930DW | A1T010395    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 år     | Quarterly in Arrears  | MFC-J6935DW | A1T010396    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service | Maksu tulosteiden mukaan | Cloud MPS Dealer | Email  | 4 vuotta | Quarterly in Arrears  | MFC-J5330DW | A1T010397    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service | Maksu tulosteiden mukaan | Cloud MPS Dealer | Email  | 4 vuotta | Quarterly in Arrears  | MFC-J5335DW | A1T010398    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service | Maksu tulosteiden mukaan | Cloud MPS Dealer | Email  | 4 vuotta | Quarterly in Arrears  | MFC-J5730DW | A1T010399    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service | Maksu tulosteiden mukaan | Cloud MPS Dealer | Email  | 4 vuotta | Quarterly in Arrears  | MFC-J5930DW | A1T010400    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service | Maksu tulosteiden mukaan | Cloud MPS Dealer | Email  | 4 vuotta | Quarterly in Arrears  | MFC-J6530DW | A1T010401    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service | Maksu tulosteiden mukaan | Cloud MPS Dealer | Email  | 4 vuotta | Quarterly in Arrears  | MFC-J6930DW | A1T010402    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service | Maksu tulosteiden mukaan | Cloud MPS Dealer | Email  | 4 vuotta | Quarterly in Arrears  | MFC-J6935DW | A1T010403    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 years  | Quarterly in Arrears  | MFC-J5330DW | A1T010404    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 years  | Quarterly in Arrears  | MFC-J5730DW | A1T010405    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 years  | Quarterly in Arrears  | MFC-J5930DW | A1T010406    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 years  | Quarterly in Arrears  | MFC-J6530DW | A1T010407    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 years  | Quarterly in Arrears  | MFC-J6930DW | A1T010408    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go            | Cloud MPS Dealer | Email  | 4 years  | Quarterly in Arrears  | MFC-J6935DW | A1T010409    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service  | Betalen naar verbruik    | Cloud MPS Dealer | Email  | 4 jaar   | Per kwartaal achteraf | MFC-J5330DW | A1T010410    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service  | Betalen naar verbruik    | Cloud MPS Dealer | Email  | 4 jaar   | Per kwartaal achteraf | MFC-J5730DW | A1T010411    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service  | Betalen naar verbruik    | Cloud MPS Dealer | Email  | 4 jaar   | Per kwartaal achteraf | MFC-J5930DW | A1T010412    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service  | Betalen naar verbruik    | Cloud MPS Dealer | Email  | 4 jaar   | Per kwartaal achteraf | MFC-J6530DW | A1T010413    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service  | Betalen naar verbruik    | Cloud MPS Dealer | Email  | 4 jaar   | Per kwartaal achteraf | MFC-J6930DW | A1T010414    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service  | Betalen naar verbruik    | Cloud MPS Dealer | Email  | 4 jaar   | Per kwartaal achteraf | MFC-J6935DW | A1T010415    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service     | Betale ved forbruk       | Cloud MPS Dealer | Email  | 48       | Quarterly in Arrears  | MFC-J5330DW | A1T010416    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service     | Betale ved forbruk       | Cloud MPS Dealer | Email  | 48       | Quarterly in Arrears  | MFC-J5335DW | A1T010417    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service     | Betale ved forbruk       | Cloud MPS Dealer | Email  | 48       | Quarterly in Arrears  | MFC-J5730DW | A1T010418    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service     | Betale ved forbruk       | Cloud MPS Dealer | Email  | 48       | Quarterly in Arrears  | MFC-J5930DW | A1T010419    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service     | Betale ved forbruk       | Cloud MPS Dealer | Email  | 48       | Quarterly in Arrears  | MFC-J6530DW | A1T010420    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service     | Betale ved forbruk       | Cloud MPS Dealer | Email  | 48       | Quarterly in Arrears  | MFC-J6930DW | A1T010421    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service     | Betale ved forbruk       | Cloud MPS Dealer | Email  | 48       | Quarterly in Arrears  | MFC-J6935DW | A1T010422    | 5000 | 5000   |
	#