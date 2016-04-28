@MPS @TEST @UAT
Feature: CloudMPSDealerCanDeleteProposal
	In order to stop the progress of a proposal
	As a math dealer
	I want to be able to delete an open proposal


Scenario Outline: Dealer can delete an open proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created Purchase and Click proposal
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed
	And I sign out of Cloud MPS


Scenarios:

	| Role             | Country        |
	| Cloud MPS Dealer | United Kingdom |

Scenario Outline: German Dealer can delete an open Leasing and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Leasing and Click proposal 
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed
	And I sign out of Cloud MPS

Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany |
	| Cloud MPS Dealer | Austria |

Scenario Outline: German Dealer can delete an open Purchase and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created German Purchase and Click proposal 
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed
	And I sign out of Cloud MPS

Scenarios:

	| Role             | Country |
	| Cloud MPS Dealer | Germany |
	| Cloud MPS Dealer | Austria |


Scenario Outline: Other Dealers can delete an open Purchase and Click proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed
	And I sign out of Cloud MPS

Scenarios:

	| Role             | Country | Role2                           | ContractType                      | UsageType                                 | Length | Billing                 |
	| Cloud MPS Dealer | France  | Cloud MPS Local Office Approver | Buy & Click                       | Engagement sur un minimum volume de pages | 3 ans  | Trimestrale anticipata  |
	| Cloud MPS Dealer | Italy   | Cloud MPS Local Office Approver | Acquisto + Consumo con assistenza | Volume minimo                             | 36     | Trimestrale anticipata  |
	| Cloud MPS Dealer | Spain   | Cloud MPS Local Office Approver | Purchase & Click con Service      | Volúmen mínimo                            | 3 años | Por trimestres vencidos |
	
	