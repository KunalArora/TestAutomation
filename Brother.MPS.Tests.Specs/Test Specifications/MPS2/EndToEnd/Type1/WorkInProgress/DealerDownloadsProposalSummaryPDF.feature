@MPS @UAT @TYPE1 @WORKINPROGRESS
Feature: DealerDownloadsSummaryPDF
	In order to send the proposal to my customer
	As a Cloud MPS Dealer
	I want to download a Proposal Summary PDF

Scenario Outline: Business Scenario 1 - Dealer Downloads Proposal Summary PDF
Given I have navigated to the Approved Proposals page as a "Cloud MPS Dealer" from "<Country>"
And I navigate to the Proposal summary page for proposal id "<ProposalId>"
When I click the download proposal button
Then I should be able to open the PDF
# Validations of pricings should be done as part of last step after opening the PDF

Scenarios:
		| Country        | ProposalId |
		| United Kingdom | xxxxxx     |
