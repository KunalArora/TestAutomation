@MPS @TEST @UAT @ignore
Feature: LocalOfficeAdminCanManageBanks
	In order to manage leasing banks
	As a Local Office Administartor
	I want to be able to add/edit leasing bank parameters


@ignore
Scenario Outline: Local Office Admin Can Sell PriceVsSRPConstraint
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	When I navigate to admin Lease And Click page
	And I navigate to Leasing Bank screen
	Then I can edit the Sell Price vs SRP Constraint % for an existing Leasing bank
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                   | Country        |
	| Cloud MPS Local Office | United Kingdom |

@ignore
Scenario Outline: Local Office Admin Can Set Default Dealer Margin
	Given I sign into MPS as a "<Role>" from "<Country>"
	When I navigate to Dealer Defaults page
	Then I can set one-off dealer "<MarginType>" margin
	And I sign out of Cloud MPS

	Scenarios: 
	| Role                   | Country        | MarginType    |
	| Cloud MPS Local Office | United Kingdom | Hardware      |
	| Cloud MPS Local Office | United Kingdom | Delivery      |
	| Cloud MPS Local Office | United Kingdom | Accessories   |
	| Cloud MPS Local Office | United Kingdom | Installation  |
	| Cloud MPS Local Office | United Kingdom | Service Pack  |
	| Cloud MPS Local Office | United Kingdom | Mono Click    |
	| Cloud MPS Local Office | United Kingdom | Colour Click  |
	| Cloud MPS Local Office | United Kingdom | All Inclusive |

