﻿@MPS @TEST @UAT @BIEPC112
Feature: CloudMPSDannishDealerCanDeleteProposal
	In order to stop the progress of a proposal
	As a math dealer
	I want to be able to delete an open proposal


Scenario Outline: MPS Delete Open Proposal
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I have created a "<ContractType>" proposal with "<UsageType>" and "<Length>" and "<Billing>"
	And I am on Proposal List page
	When I can click delete button on proposal item of Exisiting Proposal table
	Then the deleted proposal is no longer displayed
	And I sign out of Cloud MPS

Scenarios:

	| Role             | Country | Role2                           | ContractType           | UsageType       | Length | Billing              |
	| Cloud MPS Dealer | Denmark | Cloud MPS Local Office Approver | Køb & Klik med service | Minimumsvolumen | 3 år   | Quarterly in Arrears |
	