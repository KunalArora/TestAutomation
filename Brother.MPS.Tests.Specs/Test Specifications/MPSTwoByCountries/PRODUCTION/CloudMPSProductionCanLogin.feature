@MPS @PROD @VERIFYPROD
Feature: CloudMPSProductionCanLogin
	In order to view my dashboard on production
	As a dealer
	I want to be able to log in

Scenario Outline: Dealer Can Log in to Production Site
	Given I sign as "<Role>" into "<Server>" for "<Country>"
	
	Scenarios: 
	| Role             | Country        | Role2                           | Server                          | ServerName | Method | Type |
	| Cloud MPS Dealer | United Kingdom | Cloud MPS Local Office Approver | https://p1.online.brother.co.uk | Web_1      | Cloud  | Web  |
	
	