@MPS @UAT @TEST @BIEPC111
Feature: CloudMPSFullCloudInstallationForSmokeTest
	In order to get an installer to begin cloud installation
	As a Dealer 
	I want to be able to complete cloud installation

## This scenario will be completed by using device simulation
## The device simulator will be used to simulate connection to BOC/Medio


Scenario Outline: MPS BUK Cloud Installation
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
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
	##And I enter mono and colour print count
	##And I enter "1000" mono and "1000" colour print count
	And I enter mono and colour print count for a single device
	And I generate invoices for the contract above
	##And I download customer invoices pdf

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  |

Scenario Outline: MPS BIGAT Cloud Installation
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
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

Scenarios:

	| Role                            | Country     | ContractType                  | UsageType      | Role1            | Method | Type |
	| Cloud MPS Local Office Approver | Germany     | Easy Print Pro & Service      | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  |
	| Cloud MPS Bank                  | Germany     | Leasing & Service             | Mindestvolumen | Cloud MPS Dealer | Cloud  | Web  |
	| Cloud MPS Local Office Approver | Austria     | Easy Print Pro & Service      | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  |
	| Cloud MPS Bank                  | Austria     | Leasing & Service             | Mindestvolumen | Cloud MPS Dealer | Cloud  | Web  |
	

Scenario Outline: MPS Cloud Installation
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
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

	
Scenarios:

	| Role                            | Country     | ContractType                       | UsageType                                 | Role1            | Method | Type | Length     | Billing                   |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 4 ans      | Trimestrale anticipata    |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 5 ans      | Trimestrale anticipata    |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 36         | Trimestrale anticipata    |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | Web  | 48         | Trimestrale anticipata    |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 3 años     | Por trimestres vencidos   |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | Web  | 4 años     | Por trimestres vencidos   |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | Web  | 3 år       | Quarterly in Arrears      |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 4 år       | Quarterly in Arrears      |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | Web  | 36 månader | Kvartalsvis i efterskott  |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 48 månader | Kvartalsvis i efterskott  |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | Web  | 3 jaar     | Per kwartaal achteraf     |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 4 jaar     | Per kwartaal achteraf     |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | Web  | 36         | Quarterly in Arrears      |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 48         | Quarterly in Arrears      |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years    | Quarterly in Arrears      |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years    | Quarterly in Arrears      |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | Web  | 4 lata     | Miesięczny / Monthly      |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 4 lata     | Miesięczny / Monthly      |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | Web  | 3 vuotta   | 3 kk välein käytön mukaan |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | BOR  | 4 vuotta   | 3 kk välein käytön mukaan |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Pay As You Go                             | Cloud MPS Dealer | Cloud  | BOR  | 36         | Quartalsweise             |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Pay As You Go                             | Cloud MPS Dealer | Cloud  | Web  | 48         | Quartalsweise             |
	

@ignore
Scenario Outline: MPS Cloud Installation for SubDealer
	Given subdealer "<SubRole>" from "<Country>" have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	#And I sign back into Cloud MPS as a "<SubRole>" from "<Country>"
	#And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	#And I extract the installer url from Installation Request
	#When I navigate to the installer page
	#And I enter the contract reference number
	#And I enter device serial number for "<Type>" communication 
	#And I enter the device IP address
	#Then I can connect the device to Brother environment
	#And I can complete device installation
	#And I can sign out of Brother Online
	#And I navigate to the Invoice tool homepage
	#And I select "<Country>" of interest
	#And I enter mono and colour print count for a single device
	#And I generate invoices for the contract above

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              | SubRole                                |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | mps-buk-uat-sub-dealer-1@brother.co.uk |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | mps-buk-uat-sub-dealer-10@brother.co.uk |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | mps-buk-uat-sub-dealer-11@brother.co.uk |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | mps-buk-uat-sub-dealer-12@brother.co.uk |
	#

	#| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | Web  | 5 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | mps-bbe-uat-sub-dealer-1@brother.co.uk   |
	#| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | Web  | 5 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | mps-bbe-uat-sub-dealer-10@brother.co.uk   |
	| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | Web  | 5 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | mps-bbe-uat-sub-dealer-11@brother.co.uk   |
	| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | Web  | 5 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | mps-bbe-uat-sub-dealer-12@brother.co.uk   |
	

@ignore
Scenario Outline: BIR Tax Calculation Test
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" using the device "<Device>" using Brother installation
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

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length  | Billing              | Device       |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | HL-S7000DN   |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 4 years | Quarterly in Arrears | HL-S7000DN   |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 5 years | Quarterly in Arrears | HL-S7000DN   |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 5 years | Quarterly in Arrears | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Arrears | MFC-L6900DW  |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 4 years | Quarterly in Arrears | MFC-L6900DW  |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 5 years | Quarterly in Arrears | MFC-L6900DW  |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears | MFC-J5920DW  |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Quarterly in Arrears | MFC-J5920DW  |
	| Cloud MPS Local Office Approver | Ireland | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 5 years | Quarterly in Arrears | MFC-J5920DW  |
	


@ignore
Scenario Outline: Pro Rata Accepted Contracts
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" using the device "<Device>" using Brother installation
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	#And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	#And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	#And I extract the installer url from Installation Request
	#When I navigate to the installer page
	#And I enter the contract reference number
	#And I enter device serial number for "<Type>" communication 
	#And I enter the device IP address
	#Then I can connect the device to Brother environment
	#And I can complete device installation
	#And I can sign out of Brother Online
	#And I navigate to the Invoice tool homepage
	#And I select "<Country>" of interest
	#And I enter mono and colour print count for a single device
	#And I generate invoices for the contract above

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType       | Role1            | Method | Type | Length  | Billing              | Device       |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                   | Pakiet wydruków | Cloud MPS Dealer | Cloud  | Web  | 4 lata  | Miesięczny / Monthly | DCP-8110DN   |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                   | Pakiet wydruków | Cloud MPS Dealer | Cloud  | Web  | 4 lata  | Miesięczny / Monthly | DCP-8110DN   |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                   | Pakiet wydruków | Cloud MPS Dealer | Cloud  | Web  | 4 lata  | Quarterly in Arrears | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                   | Pakiet wydruków | Cloud MPS Dealer | Cloud  | Web  | 4 lata  | Quarterly in Arrears | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go   | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Monthly In Arrears   | DCP-8110DN   |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Pay As You Go   | Cloud MPS Dealer | Cloud  | BOR  | 5 years | Monthly In Arrears   | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Advance | DCP-8110DN   |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | Web  | 4 years | Half Yearly          | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | Web  | 5 years | Quarterly in Advance | DCP-8110DN   |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Monthly in Advance   | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Half Yearly          | DCP-8110DN   |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | BOR  | 5 years | Quarterly in Advance | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | Web  | 3 years | Poland 6 monthly     | DCP-8110DN   |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | Web  | 4 years | Monthly              | DCP-8110DN   |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | Web  | 5 years | Poland 6 monthly     | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | Web  | 3 years | Quarterly in Advance | MFC-L8650CDW |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume  | Cloud MPS Dealer | Cloud  | Web  | 4 years | Monthly in Advance   | DCP-8110DN   |
	
	


Scenario Outline: MPS MLang Cloud Installation
	Given "<Country>" Dealer with "<Language>" language have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
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

	
Scenarios:

	| Role                            | Country | ContractType                  | UsageType      | Role1            | Method | Type | Length | Billing                                                            | Language |
	| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | Web  | 5 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | French   |
	| Cloud MPS Local Office Approver | Belgium | Buy & Click                   | Volume minimum | Cloud MPS Dealer | Cloud  | BOR  | 4 ans  | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | French   |
	| Cloud MPS Local Office Approver | Belgium | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | BOR  | 5 jaar | Jaarlijke afrekening / Décompte annuel                             | Dutch    |
	| Cloud MPS Local Office Approver | Belgium | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Cloud  | Web  | 4 jaar | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | Dutch    |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | Web  | 3 vuotta | Quarterly in Arrears | Suomi    |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | BOR  | 4 vuotta | Quarterly in Arrears | Suomi    |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years  | Quarterly in Arrears | Svenska  |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years  | Quarterly in Arrears | Svenska  |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | Web  | 3 Jahre  | Quarterly in Arrears | Deutsch  |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans    | Quarterly in Arrears | Français |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Quarterly in Arrears | Deutsch  |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 4 ans    | Quarterly in Arrears | Français |
	#



Scenario Outline: Multiple Installation
	Given "<Country>" Dealer have created "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	#And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I generate installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	And I enter the device IP address
	##Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online
	And I navigate to the Invoice tool homepage
	And I select "<Country>" of interest
	##And I enter mono and colour print count
	And I enter "<Mono>" mono and "<Colour>" colour print count
	And I generate invoices for the contract above
	##And I download customer invoices pdf

	
Scenarios:

	| Role                            | Country        | ContractType                       | UsageType                                      | Role1            | Method | Length     | Billing                                                            | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 | Mono | Colour |
	| Cloud MPS Local Office Approver | France         | Buy & Click                        | Paiement selon la consommation réelle de pages | Cloud MPS Dealer | Email  | 4 ans      | Trimestriellement à terme échu                                     | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010197    | A1T010198     | A1T010199     | A1T010200     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Pago por Uso                                   | Cloud MPS Dealer | Email  | 4 años     | Por trimestres vencidos                                            | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010205    | A1T010206     | A1T010207     | A1T010208     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Løbende betaling                               | Cloud MPS Dealer | Email  | 4 år       | Quarterly in Arrears                                               | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5200DW  | A1T010209    | A1T010210     | A1T010211     | A1T010212     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Betala per utskrift                            | Cloud MPS Dealer | Email  | 48 månader | Kvartalsvis i efterskott                                           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5100DN  | A1T010213    | A1T010214     | A1T010215     | A1T010216     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Betalen naar verbruik                          | Cloud MPS Dealer | Email  | 4 jaar     | Per kwartaal achteraf                                              | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010217    | A1T010218     | A1T010219     | A1T010220     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Email  | 4 years    | Quarterly in Arrears                                               | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010225    | A1T010226     | A1T010227     | A1T010228     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pakiet wydruków                                | Cloud MPS Dealer | Email  | 4 lata     | Miesięczny / Monthly                                               | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010229    | A1T010230     | A1T010231     | A1T010232     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Email  | 4 years    | Quarterly in Arrears                                               | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010233    | A1T010234     | A1T010235     | A1T010236     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Volume minimum                                 | Cloud MPS Dealer | Email  | 4 ans      | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010241    | A1T010242     | A1T010243     | A1T010244     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen                                 | Cloud MPS Dealer | Email  | 4 Jahre    | Halbjährlich                                                       | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010249    | A1T010250     | A1T010251     | A1T010252     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Pay As You Go                                  | Cloud MPS Dealer | Email  | 5 Jahre    | Halbjährlich                                                       | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010253    | A1T010254     | A1T010255     | A1T010256     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Email  | 48         | Quartalsweise                                                      | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5200DW  | A1T010245    | A1T010246     | A1T010247     | A1T010248     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Maksu tulosteiden mukaan                       | Cloud MPS Dealer | Email  | 4 vuotta   | 3 kk välein käytön mukaan                                          | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-8950DW  | A1T010237    | A1T010238     | A1T010239     | A1T010240     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Betale ved forbruk                             | Cloud MPS Dealer | Email  | 48         | Quarterly in Arrears                                               | Pay upfront | Brother      | Yes      | MFC-L8650CDW | DCP-L5500DN | A1T010221    | A1T010222     | A1T010223     | A1T010224     | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Volume minimo                                  | Cloud MPS Dealer | Email  | 48         | Trimestrale anticipata                                             | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010201    | A1T010202     | A1T010203     | A1T010204     | 5000 | 5000   |
	
@ignore
Scenario Outline: Single Installation With Specified Printer
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

	| Role                            | Country        | ContractType                       | UsageType                                      | Role1            | Method | Length     | Billing                                                            | Device1     | SerialNumber | Mono | Colour |
	#| Cloud MPS Local Office Approver | France         | Buy & Click                        | Paiement selon la consommation réelle de pages | Cloud MPS Dealer | Email  | 4 ans      | Trimestriellement à terme échu                                     | DCP-9015CDW | A1T010266    | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Pago por Uso                                   | Cloud MPS Dealer | Email  | 4 años     | Por trimestres vencidos                                            | MFC-J6935DW | A1T010267    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Email  | 4 år       | Quarterly in Arrears                                               | DCP-9015CDW | A1T010268    | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Betala per utskrift                            | Cloud MPS Dealer | Email  | 48 månader | Kvartalsvis i efterskott                                           | MFC-J5730DW | A1T010269    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Betalen naar verbruik                          | Cloud MPS Dealer | Email  | 4 jaar     | Per kwartaal achteraf                                              | DCP-9015CDW | A1T010270    | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Email  | 4 years    | Quarterly in Arrears                                               | MFC-J5330DW | A1T010271    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pakiet wydruków                                | Cloud MPS Dealer | Email  | 4 lata     | Miesięczny / Monthly                                               | DCP-9015CDW | A1T010272    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Email  | 4 years    | Quarterly in Arrears                                               | DCP-9015CDW | A1T010273    | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Volume minimum                                 | Cloud MPS Dealer | Email  | 4 ans      | Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance | MFC-J5930DW | A1T010274    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen                                 | Cloud MPS Dealer | Email  | 4 Jahre    | Halbjährlich                                                       | DCP-9015CDW | A1T010275    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Pay As You Go                                  | Cloud MPS Dealer | Email  | 5 Jahre    | Halbjährlich                                                       | DCP-9015CDW | A1T010278    | 5000 | 5000   |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Email  | 48         | Quartalsweise                                                      | MFC-J6930DW | A1T010279    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Maksu tulosteiden mukaan                       | Cloud MPS Dealer | Email  | 4 vuotta   | Quarterly in Arrears                                               | DCP-9015CDW | A1T010276    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Betale ved forbruk                             | Cloud MPS Dealer | Email  | 48         | Quarterly in Arrears                                               | DCP-9015CDW | A1T010277    | 5000 | 5000   |
	#| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Volume minimo                                  | Cloud MPS Dealer | Email  | 48         | Trimestrale anticipata                                             | DCP-9015CDW | A1T010280    | 5000 | 5000   |
	#



