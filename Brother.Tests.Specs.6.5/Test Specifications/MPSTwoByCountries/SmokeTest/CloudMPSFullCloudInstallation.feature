@MPS @UAT @TEST
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

	| Role                            | Country     | ContractType                       | UsageType                                 | Role1            | Method | Type | Length     | Billing                 |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 3 ans      | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans      | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | BOR  | 36         | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Cloud  | Web  | 48         | Trimestrale anticipata  |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | BOR  | 3 años     | Por trimestres vencidos |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Cloud  | Web  | 3 años     | Por trimestres vencidos |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | Web  | 3 år       | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Minimumsvolumen                           | Cloud MPS Dealer | Cloud  | BOR  | 4 år       | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | Web  | 36 månader | Kvartalsvis i efterskott    |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Minimum volym                             | Cloud MPS Dealer | Cloud  | BOR  | 48 månader | Kvartalsvis i efterskott    |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | Web  | 3 jaar     | Per kwartaal achteraf    |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Minimumvolume                             | Cloud MPS Dealer | Cloud  | BOR  | 4 jaar     | Per kwartaal achteraf    |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | Web  | 36         | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Minimum volum                             | Cloud MPS Dealer | Cloud  | BOR  | 48         | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years    | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years    | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | Web  | 3 lata     | Miesięczny / Monthly    |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Cloud  | BOR  | 4 lata     | Miesięczny / Monthly    |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | Web  | 3 vuotta   | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | BOR  | 4 vuotta   | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 36         | Quarterly in Arrears    |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | Web  | 36         | Quarterly in Arrears    |
	


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

	| Role                            | Country     | ContractType                  | UsageType                                 | Role1            | Method | Type | Length   | Billing              | Language |
	| Cloud MPS Local Office Approver | Belgium     | Buy & Click                   | Volume minimum                            | Cloud MPS Dealer | Cloud  | Web  | 3 ans    | Quarterly in Arrears | French   |
	| Cloud MPS Local Office Approver | Belgium     | Buy & Click                   | Volume minimum                            | Cloud MPS Dealer | Cloud  | BOR  | 4 ans    | Quarterly in Arrears | French   |
	| Cloud MPS Local Office Approver | Belgium     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 3 jaar   | Quarterly in Arrears | Dutch    |
	| Cloud MPS Local Office Approver | Belgium     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 4 jaar   | Quarterly in Arrears | Dutch    |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | Web  | 3 vuotta | Quarterly in Arrears | Suomi    |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimitulostusmäärä                       | Cloud MPS Dealer | Cloud  | BOR  | 4 vuotta | Quarterly in Arrears | Suomi    |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | Web  | 3 years  | Quarterly in Arrears | Svenska  |
	#| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service | Minimum Volume                            | Cloud MPS Dealer | Cloud  | BOR  | 4 years  | Quarterly in Arrears | Svenska  |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | Web  | 3 Jahre  | Quarterly in Arrears | Deutsch  |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | BOR  | 4 ans    | Quarterly in Arrears | Français |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Mindestvolumen                            | Cloud MPS Dealer | Cloud  | BOR  | 3 Jahre  | Quarterly in Arrears | Deutsch  |
	#| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Cloud  | Web  | 4 ans    | Quarterly in Arrears | Français |
	#