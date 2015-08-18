@UAT @PROD @TEST
Feature: Navigate main site top business solutions menu
       As a visitor of the Brother main site
       I am able to navigate to each of the
       tab items within the top business solutions menu
       
Scenario: User is able to navigate to the products page via the top main site business solutions menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the top business solutions menu button
	Then I am navigated to the business solutions page

Scenario: User is able to navigate to the Manage Print Services page via the top main site business solutions menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
    And I hover over the top Business Solutions menu button
    Then I hover and click the Manage Print Services option
    Then I am navigated to the View All Print Management page
       
Scenario: User is able to navigate to the Document Capture Workflow page via the top main site  business solutions menu
    Given I have navigated to the "<site>" MainSite URL for country "<country>"
    And I hover over the top Business Solutions menu button
    Then I hover and click the Document Capture Workflow option
    Then I am navigated to the View All Document Capture and Workflow page

Scenario: User is able to navigate to the Cost Control and Security page via the top main site  business solutions menu
    Given I have navigated to the "<site>" MainSite URL for country "<country>"
    And I hover over the top Business Solutions menu button
    Then I hover and click the Cost Control and Security option
    Then I am navigated to the View All Cost Control and Security page

Scenario: User is able to navigate to the Mobile and Cloud page via the top main site  business solutions menu
    Given I have navigated to the "<site>" MainSite URL for country "<country>"
    And I hover over the top Business Solutions menu button
    Then I hover and click the Mobile and Cloud option
    Then I am navigated to the View All Mobile and Cloud page

Scenario: User is able to navigate to the Portable Print and Label page via the top main site  business solutions menu
    Given I have navigated to the "<site>" MainSite URL for country "<country>"
    And I hover over the top Business Solutions menu button
    Then I hover and click the Portable Print and Label option
    Then I am navigated to the View All Portable Print and Label page

Scenario: User is able to navigate to the Communication and Collaboration page via the top main site  business solutions menu
    Given I have navigated to the "<site>" MainSite URL for country "<country>"
    And I hover over the top Business Solutions menu button
    Then I hover and click the Communication and Collaboration option
    Then I am navigated to the View All Communication and Collaboration page

Scenario: User is able to navigate to the Visitor and Event Management page via the top main site  business solutions menu
    Given I have navigated to the "<site>" MainSite URL for country "<country>"
    And I hover over the top Business Solutions menu button
    Then I hover and click the Visitor and Event Management option
    Then I am navigated to the View All Visitor and Event Management page
