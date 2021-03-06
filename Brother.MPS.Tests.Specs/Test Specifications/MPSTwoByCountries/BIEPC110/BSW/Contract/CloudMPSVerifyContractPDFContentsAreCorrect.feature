﻿@MPS @UAT @TEST @BIEPC110
Feature: CloudMPSVerifySwissPDFContentsAreCorrect
	In order to ensure that PDF contents are correct when compared with Summary page
	As a MPS Dealer
	I want to be able to compare the values on summary page with PDF contents



Scenario Outline: Verify PDF Contents Are Correct
	Given "<Country>" Dealer has created an awaiting acceptance "<ContractType>" contract of "<UsageType>" and "<Length>" and "<Billing>"
	When the dealer downloads PDF for the created contract
	Then the noted values above are available in the PDF content
	And I sign out of Cloud MPS


Scenarios:

	| ContractType                 | Country     | UsageType     | Length | Billing       |
	| Purchase & Click mit Service | Switzerland | Pay As You Go | 36     | Quartalsweise |
	
