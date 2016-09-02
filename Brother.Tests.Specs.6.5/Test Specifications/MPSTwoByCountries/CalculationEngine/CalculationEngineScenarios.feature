@TEST @UAT @MPS
Feature: CalculationEngineScenarios
	In order to verify that the calculation on MPS are working as expected
	As an MPS user
	I want to go through all the screens and all the PDFs


Scenario Outline: Scenario One
	Given "<Country>" Dealer have created "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                       | UsageType                                 | Role1            | Method | Type | Length   | Billing                 | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Local Office Approver | France         | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 3 ans    | Trimestrale anticipata  | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010021    | A1T010022     | A1T010023     | A1T010024     |
	| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 36       | Trimestrale anticipata  | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010025    | A1T010026     | A1T010027     | A1T010028     |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 3 años   | Por trimestres vencidos | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010029    | A1T010030     | A1T010031     | A1T010032     |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 3 år     | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5200DW  | A1T010033    | A1T010034     | A1T010035     | A1T010036     |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 36       | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5100DN  | A1T010037    | A1T010038     | A1T010039     | A1T010040     |
	| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar   | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010041    | A1T010042     | A1T010043     | A1T010044     |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 years  | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010049    | A1T010050     | A1T010051     | A1T010052     |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 3 lata   | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 years  | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010053    | A1T010054     | A1T010055     | A1T010056     |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 ans    | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010061    | A1T010062     | A1T010063     | A1T010064     |
	| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Halbjährlich            | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010069    | A1T010070     | A1T010071     | A1T010072     |
	| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Halbjährlich            | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010073    | A1T010074     | A1T010075     | A1T010076     |
	| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 36       | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010045    | A1T010046     | A1T010047     | A1T010048     |
	| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | BOR  | 3 vuotta | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-8950DW  | A1T010057    | A1T010058     | A1T010059     | A1T010060     |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 36       | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5200DW  | A1T010065    | A1T010066     | A1T010067     | A1T010068     |
	


Scenario Outline: Scenario Two
	Given "<Country>" Dealer have created "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                       | UsageType                                 | Role1            | Method | Type | Length   | Billing      | ServicePack             | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Local Office Approver | France         | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans    | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010077    | A1T010078     | A1T010079     | A1T010080     |
	| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 48       | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010081    | A1T010082     | A1T010083     | A1T010084     |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 4 años   | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010085    | A1T010086     | A1T010087     | A1T010088     |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 4 år     | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | HL-L5200DW  | A1T010089    | A1T010090     | A1T010091     | A1T010092     |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 48       | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | HL-L5100DN  | A1T010093    | A1T010094     | A1T010095     | A1T010096     |
	| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 4 jaar   | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010097    | A1T010098     | A1T010099     | A1T010100     |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years  | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010105    | A1T010106     | A1T010107     | A1T010108     |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 4 lata   | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010109    | A1T010110     | A1T010111     | A1T010112     |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years  | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010113    | A1T010114     | A1T010115     | A1T010116     |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 ans    | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010121    | A1T010122     | A1T010123     | A1T010124     |
	| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Halbjährlich | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010129    | A1T010130     | A1T010131     | A1T010132     |
	| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Halbjährlich | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010133    | A1T010134     | A1T010135     | A1T010136     |
	| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 48       | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010101    | A1T010102     | A1T010103     | A1T010104     |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 48       | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | HL-L5200DW  | A1T010125    | A1T010126     | A1T010127     | A1T010128     |
	| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | BOR  | 4 vuotta | Half Yearly  | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-8950DW  | A1T010117    | A1T010118     | A1T010119     | A1T010120     |
	

Scenario Outline: Scenario Three
	Given "<Country>" Dealer have created "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                       | UsageType                                 | Role1            | Method | Type | Length   | Billing      | ServicePack             | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Local Office Approver | France         | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 5 ans    | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010137    | A1T010138     | A1T010139     | A1T010140     |
	| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 60       | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010141    | A1T010142     | A1T010143     | A1T010144     |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 5 años   | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010145    | A1T010146     | A1T010147     | A1T010148     |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 5 år     | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | HL-L5200DW  | A1T010149    | A1T010150     | A1T010151     | A1T010152     |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 60       | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | HL-L5100DN  | A1T010153    | A1T010154     | A1T010155     | A1T010156     |
	| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 5 jaar   | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010157    | A1T010158     | A1T010159     | A1T010160     |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 5 years  | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010165    | A1T010166     | A1T010167     | A1T010168     |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 5 lata   | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010169    | A1T010170     | A1T010171     | A1T010172     |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 5 years  | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010173    | A1T010174     | A1T010175     | A1T010176     |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 5 ans    | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010181    | A1T010182     | A1T010183     | A1T010184     |
	| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Halbjährlich | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010189    | A1T010190     | A1T010191     | A1T010192     |
	| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Halbjährlich | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010193    | A1T010194     | A1T010195     | A1T010196     |
	| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 60       | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010161    | A1T010162     | A1T010163     | A1T010164     |
	| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | BOR  | 5 vuotta | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-8950DW  | A1T010177    | A1T010178     | A1T010179     | A1T010180     |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre  | Monthly      | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | HL-L5200DW  | A1T010185    | A1T010186     | A1T010187     | A1T010188     |
	

Scenario Outline: Scenario Four
	Given "<Country>" Dealer have created "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                       | UsageType                                      | Role1            | Method | Type | Length   | Billing                        | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Local Office Approver | France         | Buy & Click                        | Paiement selon la consommation réelle de pages | Cloud MPS Dealer | Cloud  | BOR  | 3 ans    | Trimestriellement à terme échu | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010197    | A1T010198     | A1T010199     | A1T010200     |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Pago por Uso                                   | Cloud MPS Dealer | Cloud  | BOR  | 3 años   | Por trimestres vencidos        | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010205    | A1T010206     | A1T010207     | A1T010208     |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Cloud  | BOR  | 3 år     | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5200DW  | A1T010209    | A1T010210     | A1T010211     | A1T010212     |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Betala per utskrift                            | Cloud MPS Dealer | Cloud  | BOR  | 36       | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5100DN  | A1T010213    | A1T010214     | A1T010215     | A1T010216     |
	| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Betalen naar verbruik                          | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar   | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010217    | A1T010218     | A1T010219     | A1T010220     |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Cloud  | BOR  | 3 years  | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010225    | A1T010226     | A1T010227     | A1T010228     |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Bez limitu                                     | Cloud MPS Dealer | Cloud  | BOR  | 3 lata   | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010229    | A1T010230     | A1T010231     | A1T010232     |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Cloud  | BOR  | 3 years  | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010233    | A1T010234     | A1T010235     | A1T010236     |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Consommation réelle                            | Cloud MPS Dealer | Cloud  | BOR  | 3 ans    | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010241    | A1T010242     | A1T010243     | A1T010244     |
	| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Pay As You Go                                  | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Halbjährlich                   | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010249    | A1T010250     | A1T010251     | A1T010252     |
	| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Pay As You Go                                  | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Halbjährlich                   | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010253    | A1T010254     | A1T010255     | A1T010256     |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Pay As You Go                                  | Cloud MPS Dealer | Cloud  | BOR  | 36       | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | HL-L5200DW  | A1T010245    | A1T010246     | A1T010247     | A1T010248     |
	| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Maksu tulosteiden mukaan                       | Cloud MPS Dealer | Cloud  | BOR  | 3 vuotta | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-8950DW  | A1T010237    | A1T010238     | A1T010239     | A1T010240     |
	| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Betale ved forbruk                             | Cloud MPS Dealer | Cloud  | BOR  | 36       | Quarterly in Arrears           | Pay upfront | Brother      | Yes      | MFC-L8650CDW | DCP-L5500DN | A1T010221    | A1T010222     | A1T010223     | A1T010224     |
	
	#| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Pay As You Go                                  | Cloud MPS Dealer | Cloud  | BOR  | 36       | Trimestrale anticipata         | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010201    | A1T010202     | A1T010203     | A1T010204     |
	

Scenario Outline: Scenario Five
	Given "<Country>" Dealer have created "<ContractType>" with contract "<UsageType>" "<Length>" and "<Leasing>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

Scenarios:

	| Role           | Country | ContractType      | UsageType      | Role1            | Method | Type | Length  | Leasing   | Billing      | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Monatlich | Halbjährlich | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010257    | A1T010258     | A1T010259     | A1T010260     |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Monatlich | Halbjährlich | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010261    | A1T010262     | A1T010263     | A1T010264     |
	

Scenario Outline: Scenario Six
	Given "<Country>" Dealer have created "<ContractType>" with contract "<UsageType>" "<Length>" and "<Leasing>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

Scenarios:

	| Role           | Country | ContractType      | UsageType      | Role1            | Method | Type | Length  | Leasing         | Billing      | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Vierteljährlich | Halbjährlich | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010265    | A1T010266     | A1T010267     | A1T010268     |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Vierteljährlich | Halbjährlich | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010269    | A1T010270     | A1T010271     | A1T010272     |
	

Scenario Outline: Scenario Seven
	Given "<Country>" Dealer have created "<ContractType>" with contract "<UsageType>" "<Length>" and "<Leasing>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

Scenarios:

	| Role           | Country | ContractType      | UsageType      | Role1            | Method | Type | Length  | Leasing   | Billing      | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Monatlich | Halbjährlich | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010273    | A1T010274     | A1T010275     | A1T010276     |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Monatlich | Halbjährlich | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010277    | A1T010278     | A1T010279     | A1T010280     |
	

Scenario Outline: Scenario Eight
	Given "<Country>" Dealer have created "<ContractType>" with contract "<UsageType>" "<Length>" and "<Leasing>" and "<Billing>" and "<ServicePack>" and "<Installation>" and "<Delivery>" and "<Device1>" and "<Device2>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication and "<Type>" installation
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number 
	And I enter serial numbers "<SerialNumber>" and "<SerialNumber1>" and "<SerialNumber2>" and "<SerialNumber3>"
	Then I can connect device "<Device1>" with serials "<SerialNumber>" "<SerialNumber1>" and "<Device2>" with serials "<SerialNumber2>" and "<SerialNumber3>" to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

Scenarios:

	| Role           | Country | ContractType      | UsageType      | Role1            | Method | Type | Length  | Leasing         | Billing      | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Vierteljährlich | Halbjährlich | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010281    | A1T010282     | A1T010283     | A1T010284     |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Vierteljährlich | Halbjährlich | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010285    | A1T010286     | A1T010287     | A1T010288     |
	