@MPS @TEST @UAT
Feature: CloudMPSDealerCanCopyADeclineProposal
	In order to resubmit a declined proposal
	As a dealer 
	I want to be to copy and submit a declined proposal


Scenario Outline: Dealer Can Copy A Declined Leasing and Click Proposal without customer detail
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Leasing and Click proposal 
	And I am on Proposal List page
	And I send the created German proposal for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal without customer
	##And I am redirected to Customer screen when I start proposal conversion process
	And I sign out of Cloud MPS
	
	Scenarios:

	| Role             | Country | Role2          |
	| Cloud MPS Dealer | Germany | Cloud MPS Bank |
	| Cloud MPS Dealer | Austria | Cloud MPS Bank |
	



Scenario Outline: Dealer Can Copy A Declined Leasing and Click Proposal with customer detail
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Leasing and Click proposal 
	And I am on Proposal List page
	And I send the created German proposal for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal with customer
	##And I am redirected to Summary page when I start proposal conversion process
	And I sign out of Cloud MPS

	Scenarios:

	| Role             | Country | Role2          |
	| Cloud MPS Dealer | Germany | Cloud MPS Bank |
	| Cloud MPS Dealer | Austria | Cloud MPS Bank |
	



Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal without customer detail
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created proposal to local office approver for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above as a Local Office Approver
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal without customer
	##And I am redirected to Customer screen when I start proposal conversion process
	And I sign out of Cloud MPS
	
	Scenarios:

	| Role             | Country        | Role2                           |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver |
	


Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal with customer detail
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created proposal to local office approver for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above as a Local Office Approver
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal with customer
	##And I am redirected to Summary page when I start proposal conversion process
	And I sign out of Cloud MPS
	
	Scenarios:

	| Role             | Country        | Role2                           |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver |


Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal without customer detail for other countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	And I send the created proposal to local office approver for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above as a Local Office Approver
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal without customer
	##And I am redirected to Customer screen when I start proposal conversion process
	And I sign out of Cloud MPS
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType                      | UsageType                                 | Length | Billing                 |
	| Cloud MPS Dealer | France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata  |
	| Cloud MPS Dealer | Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Trimestrale anticipata  |
	| Cloud MPS Dealer | Spain   | Cloud MPS Local Office Approver | Purchase & Click con Service      | Volúmen mínimo                            | 3 años | Por trimestres vencidos |
	


Scenario Outline: Dealer Can Copy A Declined Purchase and Click Proposal with customer detail for other countries
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	And I send the created proposal to local office approver for approval
	And I sign out of Cloud MPS
	When I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I decline the proposal created above as a Local Office Approver
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to decline proposal list page
	Then I can copy the declined proposal with customer
	##And I am redirected to Summary page when I start proposal conversion process
	And I sign out of Cloud MPS
	
	Scenarios:

	| Role             | Country | Role2                           | ContractType                      | UsageType                                 | Length | Billing                 |
	| Cloud MPS Dealer | France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata  |
	| Cloud MPS Dealer | Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Trimestrale anticipata  |
	| Cloud MPS Dealer | Spain   | Cloud MPS Local Office Approver | Purchase & Click con Service      | Volúmen mínimo                            | 3 años | Por trimestres vencidos |
	