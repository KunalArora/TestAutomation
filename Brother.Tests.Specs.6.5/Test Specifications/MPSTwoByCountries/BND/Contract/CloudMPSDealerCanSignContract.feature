﻿@MPS @TEST @UAT
Feature: CloudMPSDannishDealerCanSignContract
	In order to progress an approved proposal to contract
	As a dealer
	I want to be able to sign an approve proposal


@ignore
Scenario Outline: Belgian Dealer Can Sign A Leasing And Click Contract
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Leasing and Click proposal 
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I approve the proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract approved proposal page
	Then I can start the process of signing the contract
	And I can successfully sign the contract
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And navigate to bank contract Awaiting Acceptance page
	And the signed contract is displayed
	And I sign out of Cloud MPS
	
	
	Scenarios: 
	| Role             | Country        | Role2          |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Bank |

	



Scenario Outline: Belgian Dealer Can Sign A Purchase And Click Contract
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I approve the purchase and click proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract approved proposal page
	Then I can start the process of signing the contract
	And I can successfully sign the contract
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And navigate to Local Office Approver contract Awaiting Acceptance page
	And the signed purchase and click contract is displayed
	And I sign out of Cloud MPS
	
	
	Scenarios: 
	| Role             | Country        | Role2          |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver |


Scenario Outline: Belgian Dealer Can Sign A Purchase And Click Contract for other countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I approve the purchase and click proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer contract approved proposal page
	Then I can start the process of signing the contract
	And I can successfully sign the contract
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And navigate to Local Office Approver contract Awaiting Acceptance page
	And the signed purchase and click contract is displayed
	And I sign out of Cloud MPS
	
	
	Scenarios: 
	| Role             | Country | Role2                           | ContractType                      | UsageType                                 | Length | Billing                 |
	| Cloud MPS Dealer | France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata  |
	| Cloud MPS Dealer | Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Trimestrale anticipata  |
	| Cloud MPS Dealer | Spain   | Cloud MPS Local Office Approver | Purchase & Click con Service      | Volúmen mínimo                            | 3 años | Por trimestres vencidos |
	