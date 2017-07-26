@MPS @TEST @UAT @BIEPC110
Feature: CloudMPSCertainRolesCanAddComment
	In order to add and edit comment on a proposal or contract
	As a qualified MPS User
	I want to be add comment via Data Query page


Scenario Outline: Local Office Approver Can Add Comment
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Approver Reporting page
	And Approver navigate to Data Query page
	And I click on the first proposal link displayed
	And I click on Edit Comment button on summary page
	And I enter "<Text>" in the comment box
	Then the "<Text>" added to the comment box is displayed on summary page
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                            | Country     | Text                                             |
	| Cloud MPS Local Office Approver | Switzerland | Test Automation created this for testing purpose |


Scenario Outline: Local Office Admin Can Add Comment
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Local Office Admin Reporting page
	And Local Office Admin navigates to Data Query page
	And I click on the first proposal link displayed
	And I click on Edit Comment button on summary page
	And I enter "<Text>" in the comment box
	Then the "<Text>" added to the comment box is displayed on summary page
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                   | Country     | Text                                             |
	| Cloud MPS Local Office | Switzerland | Test Automation created this for testing purpose |

Scenario Outline: Service Desk  User Cannot Add Comment
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Service Desk Reporting page
	And Service Desk user navigate to Data Query page
	And I click on the first proposal link displayed
	And I click on Edit Comment button on summary page
	And I enter "<Text>" in the comment box
	Then the "<Text>" added to the comment box is displayed on summary page
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                   | Country     | Text                                             |
	| Cloud MPS Service Desk | Switzerland | Test Automation created this for testing purpose |

Scenario Outline: Dealer Cannot Add Comment
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to Dealer Reporting page
	And Service Desk user navigate to Data Query page
	And I click on the first proposal link displayed
	Then Comment button is not displayed on Summary page
	And I sign out of Cloud MPS

	Scenarios: 
	| Role             | Country     |
	| Cloud MPS Dealer | Switzerland |
	