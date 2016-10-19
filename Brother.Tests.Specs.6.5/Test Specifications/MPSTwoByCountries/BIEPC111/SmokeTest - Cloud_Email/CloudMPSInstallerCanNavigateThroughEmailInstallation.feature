@MPS @UAT @TEST
Feature: CloudMPSInstallerCanNavigateThroughInstallationForSmokeTest
	In order to get an installer to begin installation
	As a Dealer 
	I want to be able to complete installation

#@ignore
Scenario Outline: MPS BUK Email Installation
	Given Dealer have created a contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Method>" communication
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country        | ContractType                  | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | United Kingdom | Purchase & Click with Service | Minimum Volume | Cloud MPS Dealer | Email  |



Scenario Outline: MPS Email Installation
	Given "<Country>" Dealer have created a "<ContractType>" contract with "<UsageType>" and "<Length>" and "<Billing>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Method>" communication
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country     | ContractType                       | UsageType                                 | Role1            | Method | Length     | Billing                  |
	| Cloud MPS Local Office Approver | France      | Buy & Click                        | Engagement sur un minimum volume de pages | Cloud MPS Dealer | Email  | 3 ans      | Trimestrale anticipata   |
	| Cloud MPS Local Office Approver | Italy       | Acquisto + Consumo con assistenza  | Volume minimo                             | Cloud MPS Dealer | Email  | 36         | Trimestrale anticipata   |
	| Cloud MPS Local Office Approver | Spain       | Purchase & Click con Service       | Volúmen mínimo                            | Cloud MPS Dealer | Email  | 3 años     | Por trimestres vencidos  |
	| Cloud MPS Local Office Approver | Poland      | Buy + Click                        | Pakiet wydruków                           | Cloud MPS Dealer | Email  | 3 lata     | Miesięczny / Monthly     |
	| Cloud MPS Local Office Approver | Denmark     | Purchase & Click with Service      | Pay As You Go                             | Cloud MPS Dealer | Email  | 3 år       | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Sweden      | Purchase & click inklusive service | Betala per utskrift                       | Cloud MPS Dealer | Email  | 36 månader | Kvartalsvis i efterskott |
	| Cloud MPS Local Office Approver | Netherlands | Purchase + Click met Service       | Betalen naar verbruik                     | Cloud MPS Dealer | Email  | 3 jaar     | Per kwartaal achteraf    |
	| Cloud MPS Local Office Approver | Ireland     | Purchase & Click with Service      | Pay As You Go                             | Cloud MPS Dealer | Email  | 3 years    | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Belgium     | Purchase & Click with Service      | Minimum Volume                            | Cloud MPS Dealer | Email  | 3 jaar     | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Switzerland | Purchase & Click with Service      | Mindestvolumen                            | Cloud MPS Dealer | Email  | 36         | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Finland     | Purchase & Click with Service      | Maksu tulosteiden mukaan                  | Cloud MPS Dealer | Email  | 3 vuotta   | Quarterly in Arrears     |
	| Cloud MPS Local Office Approver | Norway      | Kjøp og klikk med service          | Betale ved forbruk                        | Cloud MPS Dealer | Email  | 36         | Quarterly in Arrears     |
	




Scenario Outline: MPS BIGAT Email Installation
	Given German Dealer have created a "<Country>" contract of "<ContractType>" and "<UsageType>"
	And I sign into Cloud MPS as a "<Role>" from "<Country>"
	And the contract created above is approved
	And I sign back into Cloud MPS as a "<Role1>" from "<Country>"
	And I generate installation request for the contract with "<Method>" communication
	And I extract the installer url from Installation Request
	When I navigate to the installer page
	And I enter the contract reference number
	And I enter device serial number for "<Method>" communication 
	And I enter the device IP address
	Then I can connect the device to Brother environment
	And I can complete device installation
	And I can sign out of Brother Online

	
Scenarios:

	| Role                            | Country | ContractType             | UsageType      | Role1            | Method |
	| Cloud MPS Local Office Approver | Austria | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Email  |
	| Cloud MPS Local Office Approver | Germany | Easy Print Pro & Service | Mindestvolumen | Cloud MPS Dealer | Email  |
