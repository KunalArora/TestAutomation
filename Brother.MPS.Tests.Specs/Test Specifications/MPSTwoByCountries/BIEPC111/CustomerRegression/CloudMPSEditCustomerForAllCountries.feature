@MPS @UAT @TEST @BIEPC113
Feature: CloudMPSEditCustomerForAllCountries
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario Outline: MPS Edit New Customer for All Countries 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer with payment type "<PaymentType>" for "<Country>" 
	And I click the edit button against "<TargetItem>" on Exisiting Customers table
	And I edit "<Country>" customer payment type to "<PaymentType2>"
	Then I can see the edited Customer
	And I click the edit button against "<TargetItem>" on Exisiting Customers table
	And I can confirm the edited Customer in detail
	And I can verify that payment details are displayed
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        | TargetItem       | PaymentType          | PaymentType2         |
	| Cloud MPS Dealer | United Kingdom | NewlyCreatedItem | Invoice              | Direct Debit         |
	| Cloud MPS Dealer | United Kingdom | NewlyCreatedItem | Direct Debit         | Invoice              |
	| Cloud MPS Dealer | Italy          | NewlyCreatedItem | Addebito diretto     | Fattura              |
	| Cloud MPS Dealer | Italy          | NewlyCreatedItem | Fattura              | Addebito diretto     |
	| Cloud MPS Dealer | Norway         | NewlyCreatedItem | Faktura              | Fast trekk           |
	| Cloud MPS Dealer | Norway         | NewlyCreatedItem | Fast trekk           | Faktura              |
	| Cloud MPS Dealer | Finland        | NewlyCreatedItem | Laskutus             | Laskutus             |
	| Cloud MPS Dealer | Sweden         | NewlyCreatedItem | Faktura              | Faktura              |
	| Cloud MPS Dealer | Germany        | NewlyCreatedItem | Bankeinzug           | Rechnung             |
	| Cloud MPS Dealer | Germany        | NewlyCreatedItem | Rechnung             | Bankeinzug           |
	| Cloud MPS Dealer | Poland         | NewlyCreatedItem | Faktura              | Faktura              |
	| Cloud MPS Dealer | Ireland        | NewlyCreatedItem | Direct Debit         | Government PAYE only |
	| Cloud MPS Dealer | Ireland        | NewlyCreatedItem | Government PAYE only | Direct Debit         |
	| Cloud MPS Dealer | Netherlands    | NewlyCreatedItem | Automatische incasso | Automatische incasso |
	| Cloud MPS Dealer | France         | NewlyCreatedItem | Débit direct         | Facture              |
	| Cloud MPS Dealer | France         | NewlyCreatedItem | Facture              | Débit direct         |
	| Cloud MPS Dealer | Spain          | NewlyCreatedItem | Debito directo       | Factura              |
	| Cloud MPS Dealer | Spain          | NewlyCreatedItem | Factura              | Debito directo       |
	| Cloud MPS Dealer | Denmark        | NewlyCreatedItem | Faktura              | Faktura              |
	

Scenario Outline: MPS Edit New Customer for Multiple Languages 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I changed the language to "<Culture>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new "<Culture>" Customer with payment type "<PaymentType>" for "<Country>"
	And I click the edit button against "<TargetItem>" on Exisiting Customers table
	And I edit "<Country>" customer payment type to "<PaymentType2>"
	Then I can see the edited Customer
	And I click the edit button against "<TargetItem>" on Exisiting Customers table
	And I can confirm the edited Customer in detail
	And I can verify that payment details are displayed
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country     | TargetItem       | PaymentType   | PaymentType2            | Culture    |
	| Cloud MPS Dealer | Belgium     | NewlyCreatedItem | Facture       | Domiciliation           | Français   |
	| Cloud MPS Dealer | Belgium     | NewlyCreatedItem | Domiciliëring | Factuur                 | Nederlands |
	| Cloud MPS Dealer | Switzerland | NewlyCreatedItem | LSV           | Rechnung                | Deutsch    |
	| Cloud MPS Dealer | Switzerland | NewlyCreatedItem | Facture       | Prélèvement automatique | Français   |


Scenario Outline: MPS Add Additional Address to New Customer for All Countries 
	Given I sign into Cloud MPS as a "<Role>" from "<Country>"
	And I navigate to existing customer screen
	And I click Create Customer Button
	When I create new Customer with payment type "<PaymentType>" for "<Country>" 
	And I navigate to the details of the newly edited customer
	And I add additional address to the customer
	And the newly added additional address is displayed
	And I can sign out of Brother Online

	Scenarios: 
	| Role             | Country        | TargetItem       | PaymentType          |
	| Cloud MPS Dealer | United Kingdom | NewlyCreatedItem | Invoice              |
	| Cloud MPS Dealer | Italy          | NewlyCreatedItem | Addebito diretto     |
	| Cloud MPS Dealer | Norway         | NewlyCreatedItem | Faktura              | 
	| Cloud MPS Dealer | Finland        | NewlyCreatedItem | Laskutus             |
	| Cloud MPS Dealer | Sweden         | NewlyCreatedItem | Faktura              |
	| Cloud MPS Dealer | Germany        | NewlyCreatedItem | Bankeinzug           |
	| Cloud MPS Dealer | Poland         | NewlyCreatedItem | Faktura              |
	| Cloud MPS Dealer | Ireland        | NewlyCreatedItem | Direct Debit         |
	| Cloud MPS Dealer | Netherlands    | NewlyCreatedItem | Automatische incasso |
	| Cloud MPS Dealer | France         | NewlyCreatedItem | Débit direct         |
	| Cloud MPS Dealer | Spain          | NewlyCreatedItem | Debito directo       |
	| Cloud MPS Dealer | Denmark        | NewlyCreatedItem | Faktura              |
	