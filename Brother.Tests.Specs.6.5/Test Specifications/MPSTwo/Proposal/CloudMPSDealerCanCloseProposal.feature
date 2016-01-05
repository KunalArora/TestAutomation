@MPS @UAT @TEST
Feature: CloudMPSDealerCanCloseProposal
	In order to discontinue a proposal from creation process
	As a dealer
	I want to be able to cancel proposal before it gets to contract stage


Scenario Outline: Dealer can cancel a proposal in Open state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal
	And I am on Proposal List page
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "Summary" Tab in Proposal
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: German and Austria Dealer can cancel a proposal in Open state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Purchase and Click proposal
	And I am on Proposal List page
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "Summary" Tab in Proposal
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany  |
	| Cloud MPS Dealer | Austria |
	

Scenario Outline: Dealer can cancel a proposal in Awaiting Approval state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created proposal for approval
	When I navigate to the Summary page of the proposal awaiting approval
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |


Scenario Outline: German and Austria Dealer can cancel a proposal in Awaiting Approval state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created German proposal for approval
	When I navigate to the Summary page of the proposal awaiting approval
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany  |
	| Cloud MPS Dealer | Austria |


Scenario Outline: Dealer can cancel a proposal in Approved state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I approve the purchase and click proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer approved proposal page
	And I identify and navigate to the approved proposal summary
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country        | Role2          |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver |

Scenario Outline: German and Austria Dealer can cancel a proposal in Approved state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Purchase and Click proposal 
	And I am on Proposal List page
	And I send the created German proposal for approval
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I approve the purchase and click proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer approved proposal page
	And I identify and navigate to the approved proposal summary
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country        | Role2          |
	| Cloud MPS Dealer | Germany | Cloud MPS Local Office Approver |
	| Cloud MPS Dealer | Austria | Cloud MPS Local Office Approver |




Scenario Outline: Other Dealers can cancel a proposal in Open state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I can click edit button on proposal item of Exisiting Proposal table
	And I go to "Summary" Tab in Proposal
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country | Role2                           | ContractType                      | UsageType                                 | Length | Billing              |
	| Cloud MPS Dealer | France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Quarterly in Arrears |
	| Cloud MPS Dealer | Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Quarterly in Advance |
	


Scenario Outline: Other Dealers can cancel a proposal in Awaiting Approval state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	And I send the created proposal for approval
	When I navigate to the Summary page of the proposal awaiting approval
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country | Role2                           | ContractType                      | UsageType                                 | Length | Billing              |
	| Cloud MPS Dealer | France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Quarterly in Arrears |
	| Cloud MPS Dealer | Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Quarterly in Advance |
	

Scenario Outline: Other Dealers can cancel a proposal in Approved state
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	And I send the created proposal for approval
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role2>" from "<Country>"
	And I approve the purchase and click proposal created above
	And I sign out of Cloud MPS
	And I sign back into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to dealer approved proposal page
	And I identify and navigate to the approved proposal summary
	Then I can close the proposal on the summary page
	And I can sign out of Brother Online


Scenarios:

	| Role             | Country | Role2                           | ContractType                      | UsageType                                 | Length | Billing              |
	| Cloud MPS Dealer | France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Quarterly in Arrears |
	| Cloud MPS Dealer | Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Quarterly in Advance |
	