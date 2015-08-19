@UAT @PROD @TEST
Feature: Navigate main site top About Brother menu
		 As a visitor of the Brother main site
         I am able to navigate to each of the
         tab items within the top About Brother menu
                
Scenario: User is able to navigate to the About Brother page via the top main site About Brother menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the top About Brother menu button
	Then I am navigated to the About Brother page

Scenario: User is able to navigate to the brother-spark page via the top main site brother-spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"                     
	And I hover over the top About Brother menu button
	Then I hover and click the brother spark option
	Then I am navigated to the brother Spark page
                
Scenario: User is able to navigate to the Bright Sparks Workflow page via the top main site  Brother Spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I click on the top Bright Spark menu button
	Then I should be navigated to the bright-sparks page

Scenario: User is able to navigate to the Workflow page via the top main site  Brother Spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I click on the top Bright Spark menu button
	Then I should be navigated to the bright-sparks page

Scenario: User is able to navigate to the sparking ideas Workflow page via the top main site  Brother Spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I click on the top sparking ideas menu button
	Then I should be navigated to the sparking-ideas page

Scenario: User is able to navigate to the tech-trio Workflow page via the top main site  Brother Spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I click on the top sparking ideas menu button
	Then I should be navigated to the tech-trio page

Scenario: User is able to navigate to the my tech life Workflow page via the top main site  Brother Spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I click on the top my tech life menu button
	Then I should be navigated to the my-tech-life page

Scenario: User is able to navigate to the power up Workflow page via the top main site  Brother Spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I click on the top power up menu button
	Then I should be navigated to the power-up page

Scenario: User is able to navigate to the News page via the top main site brother-spark menu
Given I have navigated to the "<site>" MainSite URL for country "<country>"                     
	And I hover over the top About Brother menu button
	Then I hover and click the News option
	Then I am navigated to the News page

Scenario: User is able to navigate to the History page via the top main site brother-spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"                     
	And I hover over the top About Brother menu button
	Then I hover and click the History option
	Then I am navigated to the History page

Scenario: User is able to navigate to the current vacancies page via the top main site brother-spark menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"                     
	And I hover over the top About Brother menu button
	Then I hover and click the current vacancies option
	Then I am navigated to the current-vacancies page
