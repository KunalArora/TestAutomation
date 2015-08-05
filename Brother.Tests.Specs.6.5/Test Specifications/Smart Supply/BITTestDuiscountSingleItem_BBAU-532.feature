@ignore
Feature:BOL - WS - BIT - Test discount ticket - calculation of discounts for single item
As a Brother Supply Club user
I need to add the supply club product to basket and see the club product discounts calculated correctly and displayed in correct order


@ignore
Scenario: View Brother Supply Club product - calculation of discounts for single item on Basket Page
Given I am logged onto Brother Online "Italy" using valid credentials
Given I have navigated to the Brother Main Site "Italy" products pages
And I have clicked on Supplies
And I have entered my valid supplies code for an InkJet cartridge "TN2220"
When I click on search for supply "TN2220"
When I click on Add to basket button
And I  click the smart supply basket icon
And I can see brother supply club benefits checkbox in the basket page  