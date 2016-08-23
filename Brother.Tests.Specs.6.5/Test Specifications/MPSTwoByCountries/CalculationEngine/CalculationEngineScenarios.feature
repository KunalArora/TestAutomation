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

	| Role                            | Country        | ContractType                       | UsageType                                 | Role1            | Method | Type | Length  | Billing                 | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	#| Cloud MPS Local Office Approver | France         | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 3 ans   | Trimestrale anticipata  | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	#| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 36      | Trimestrale anticipata  | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	#| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 3 años  | Por trimestres vencidos | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010027    | A1T010024     | A1T010025     | A1T010026     |
	#| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 3 år    | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010028    | A1T010029     | A1T010030     | A1T010031     |
	#| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 36      | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010032    | A1T010033     | A1T010034     | A1T010035     |
	#| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar  | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010036    | A1T010037     | A1T010038     | A1T010039     |
	#| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 36      | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010040    | A1T010041     | A1T010042     | A1T010043     |
	#| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010044    | A1T010045     | A1T010046     | A1T010047     |
	#| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 3 lata  | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010048    | A1T010049     | A1T010050     | A1T010047     |
	#| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	#| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar  | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	#| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	#| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	#| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	


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

	| Role                            | Country        | ContractType                       | UsageType                                 | Role1            | Method | Type | Length  | Billing     | ServicePack             | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Local Office Approver | France         | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans   | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 48      | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 4 años  | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010027    | A1T010024     | A1T010025     | A1T010026     |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 4 år    | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010028    | A1T010029     | A1T010030     | A1T010031     |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 48      | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010032    | A1T010033     | A1T010034     | A1T010035     |
	| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 4 jaar  | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010036    | A1T010037     | A1T010038     | A1T010039     |
	| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 48      | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010040    | A1T010041     | A1T010042     | A1T010043     |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010044    | A1T010045     | A1T010046     | A1T010047     |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 4 lata  | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010048    | A1T010049     | A1T010050     | A1T010047     |
	| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 jaar  | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 4 Jahre | Half Yearly | Included in Click Price | Brother      | No       | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	

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

	| Role                            | Country        | ContractType                       | UsageType                                 | Role1            | Method | Type | Length  | Billing | ServicePack             | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Local Office Approver | France         | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 5 ans   | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 60      | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 5 años  | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010027    | A1T010024     | A1T010025     | A1T010026     |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 5 år    | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010028    | A1T010029     | A1T010030     | A1T010031     |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 60      | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010032    | A1T010033     | A1T010034     | A1T010035     |
	| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 5 jaar  | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010036    | A1T010037     | A1T010038     | A1T010039     |
	| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 60      | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010040    | A1T010041     | A1T010042     | A1T010043     |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 5 years | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010044    | A1T010045     | A1T010046     | A1T010047     |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 5 lata  | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 5 years | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010048    | A1T010049     | A1T010050     | A1T010047     |
	| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 5 years | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 5 jaar  | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Monthly | Included in Click Price | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	

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

	| Role                            | Country        | ContractType                       | UsageType      | Role1            | Method | Type | Length  | Billing                 | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Local Office Approver | France         | Buy & Click                        | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 ans   | Trimestrale anticipata  | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Italy          | Acquisto + Consumo con assistenza  | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 36      | Trimestrale anticipata  | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Spain          | Purchase & Click con Service       | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 años  | Por trimestres vencidos | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010027    | A1T010024     | A1T010025     | A1T010026     |
	| Cloud MPS Local Office Approver | Denmark        | Purchase & Click with Service      | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 år    | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010028    | A1T010029     | A1T010030     | A1T010031     |
	| Cloud MPS Local Office Approver | Sweden         | Purchase & click inklusive service | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 36      | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010032    | A1T010033     | A1T010034     | A1T010035     |
	| Cloud MPS Local Office Approver | Netherlands    | Purchase + Click met Service       | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar  | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010036    | A1T010037     | A1T010038     | A1T010039     |
	| Cloud MPS Local Office Approver | Norway         | Kjøp og klikk med service          | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 36      | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010040    | A1T010041     | A1T010042     | A1T010043     |
	| Cloud MPS Local Office Approver | Ireland        | Purchase & Click with Service      | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010044    | A1T010045     | A1T010046     | A1T010047     |
	| Cloud MPS Local Office Approver | Poland         | Buy + Click                        | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 lata  | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service      | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010048    | A1T010049     | A1T010050     | A1T010047     |
	| Cloud MPS Local Office Approver | Finland        | Purchase & Click with Service      | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 years | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Belgium        | Purchase & Click with Service      | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar  | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Switzerland    | Purchase & Click with Service      | Pay As You Go  | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Germany        | Easy Print Pro & Service           | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Local Office Approver | Austria        | Easy Print Pro & Service           | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Quarterly in Arrears    | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	


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

	| Role           | Country | ContractType      | UsageType      | Role1            | Method | Type | Length  | Billing                | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Trimestrale anticipata | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre | Trimestrale anticipata | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	

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

	| Role           | Country | ContractType      | UsageType      | Role1            | Method | Type | Length  | Billing                | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Trimestrale anticipata | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Trimestrale anticipata | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |


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

	| Role           | Country | ContractType      | UsageType      | Role1            | Method | Type | Length  | Billing                | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Trimestrale anticipata | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Trimestrale anticipata | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |


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

	| Role           | Country | ContractType      | UsageType      | Role1            | Method | Type | Length  | Billing                | ServicePack | Installation | Delivery | Device1      | Device2     | SerialNumber | SerialNumber1 | SerialNumber2 | SerialNumber3 |
	| Cloud MPS Bank | Germany | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Trimestrale anticipata | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
	| Cloud MPS Bank | Austria | Leasing & Service | Mindestvolumen | Cloud MPS Dealer | Cloud  | BOR  | 5 Jahre | Trimestrale anticipata | Pay upfront | Brother      | Yes      | MFC-L8650CDW | MFC-L5750DW | A1T010020    | A1T010021     | A1T010022     | A1T010023     |
