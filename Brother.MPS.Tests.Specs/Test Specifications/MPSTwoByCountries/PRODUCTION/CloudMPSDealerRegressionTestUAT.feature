@MPS @UAT
Feature: CloudMPSRegressionTestUAT
	In order to progress an approved proposal to contract
	As a dealer
	I want to be able to sign an approve proposal
#Same as Production smoke test but designed to run on UAT
#Currently cannot use scenarios due to tag checks in SpecFlow hooks, this needs to be resolved
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
	
	Scenarios: 
	| Role             | Country        | Role2                           | Web                                           | ServerName | Method | Type |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver | https://online65.co.uk.cds.uat.brother.eu.com | Dave       | Cloud  | Web  |