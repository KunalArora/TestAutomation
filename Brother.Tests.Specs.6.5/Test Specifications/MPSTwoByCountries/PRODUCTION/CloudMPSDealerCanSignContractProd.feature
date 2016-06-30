﻿@ignore @MPS @PROD
Feature: CloudMPSDealerCanSignContractInProduction
	In order to progress an approved proposal to contract
	As a dealer
	I want to be able to sign an approve proposal


@ignore
Scenario Outline: Dealer Can Sign A Leasing And Click Contract in Prod
	Given I sign as "<Role>" into "<Web>" for "<Country>"
	And I have created Leasing and Click proposal for "<ServerName>"
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	And I sign back into "<Role2>" Cloud MPS as a "<Web>" from "<Country>"
	And I approve the proposal created above
	And I sign out of Cloud MPS
	And I sign back into "<Role>" Cloud MPS as a "<Web>" from "<Country>"
	When I navigate to dealer contract approved proposal page
	Then I can start the process of signing the contract
	And I can successfully sign the contract
	And I sign out of Cloud MPS
	And I sign back into "<Role2>" Cloud MPS as a "<Web>" from "<Country>"
	And navigate to bank contract Awaiting Acceptance page
	And the signed contract is displayed
	And I sign out of Cloud MPS
	
	
	Scenarios: 
	| Role             | Country        | Role2          | Web                               | ServerName |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Bank | https://web1.online.brother.co.uk | Web_1      |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Bank | https://web2.online.brother.co.uk | Web_2      |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Bank | https://web5.online.brother.co.uk | Web_5      |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Bank | https://web6.online.brother.co.uk | Web_6      |
	
	

	
	
#@ignore
Scenario Outline: Dealer Can Sign A Purchase And Click Contract in Prod
	Given I sign as "<Role>" into "<Web>" for "<Country>"
	And I have created Purchase and Click proposal for "<ServerName>" 
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	And I sign back into "<Role2>" Cloud MPS as a "<Web>" from "<Country>"
	And I approve the purchase and click proposal created above
	And I sign out of Cloud MPS
	And I sign back into "<Role>" Cloud MPS as a "<Web>" from "<Country>"
	When I navigate to dealer contract approved proposal page
	Then I can start the process of signing the contract
	And I can successfully sign the contract
	And I sign out of Cloud MPS
	#And I sign back into "<Role2>" Cloud MPS as a "<Web>" from "<Country>"
	#And navigate to Local Office Approver contract Awaiting Acceptance page
	#And the signed purchase and click contract is displayed
	#And I sign out of Cloud MPS
	
	
	Scenarios: 
	| Role             | Country        | Role2                           | Web                               | ServerName |
    | Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver | https://web1.online.brother.co.uk | Web_1      |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver | https://web2.online.brother.co.uk | Web_2      |
	#| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver | https://web5.online.brother.co.uk | Web_5      |
	#| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver | https://web6.online.brother.co.uk | Web_6      |