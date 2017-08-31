@MPS @UAT @TEST
Feature: CloudMPSUKDealerCanLogin
	In order to manage my proposals
	As a dealer
	I want to log in to my dashboard

Scenario Outline: MPS Log in to dashboard
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"

@BIRONLY
Scenarios: 
	| Role             | Country | ContractType                  | UsageType      | Contract | Billing              | PriceHardware | Printer      | DeviceScreen | PaymentMethod           | ClickVolume | ColourVolume | Basis1                  | Basis2      |
	| Cloud MPS Dealer | Ireland | Purchase & Click with Service | Minimum Volume | 3 years  | Quarterly in Arrears | Tick          | MFC-L8650CDW | Full         | Included in Click Price | 800         | 800          | Included in Click Price | Pay upfront |
	