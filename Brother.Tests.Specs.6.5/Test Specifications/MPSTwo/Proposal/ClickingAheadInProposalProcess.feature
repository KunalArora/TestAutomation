@Ignore 
Feature: ClickingAheadInProposalCreationProcess
	In order to prevent user from proceeding to next page with black fields
	As an MPS Administrator
	I want to look down the next tab within proposal process


Background: It should not possible to proceed beyond a blank page
			Given I am on MPS New Proposal Page
@ignore
Scenario: It should not possible to proceed beyond a blank Proposal Description page
	
	When I click on "Customer Information" tab
	And I click on "Term & Type" tab
	And I click on "Products" tab
	And I click on "Summary" tab
	Then I am redirected to "New Proposal" screen

@ignore
Scenario: It should not possible to proceed beyond blank Customer Information page
	
	And I fill Proposal Description
	When I click on "Products" tab
	And I click on "Summary" tab
	Then I am redirected to "Term & Type" screen

@ignore
Scenario: It should not possible to proceed beyond blank Product page

	And I fill Proposal Description
	And I skip Customer Information Screen
	When I arrive at "Products" screen
	And I click on "Summary" tab
	Then I am redirected to "Products" screen
