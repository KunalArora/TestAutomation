@IGNORE
# @UAT @PROD @TEST
Feature: Navigate main site top support menu
	As a visitor of the Brother main site
	I am able to navigate to each of the
	tab items within the top support menu

Scenario: User is able to navigate to the support us page via the top main site support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I have clicked the top support menu button
	Then I am navigated to the brother support page

# Contact us navigation (Further tests on this form will be split into a new contact us feature)
Scenario: User is able to navigate to the contact us page via the top main site support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top support menu button
	Then I hover and click the contact us option
	Then I am navigated to the contact us page

# Where to buy navigation (Further page navigation in this area is covered in the product navigation tests)
Scenario: User is able to navigate to the where to buy page via the top main site support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top support menu button
	Then I hover and click the where to buy option
	Then I am navigated to the where to buy page

# Recycling navigation
Scenario: User is able to navigate to the recycling page via the top main site support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top support menu button
	Then I hover and click the recycling option
	Then I am navigated to the recycling page

		# Toner recycling navigation (Further page navigation in this area is covered in the product navigation tests)
		Scenario: User is able to navigate to the toner recycling page via the top main site support menu
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top support menu button
			Then I hover and click the recycling option
			Then I click the toner recycling button
			Then I am navigated to the toner recycling page

				# Toner recycling label navigation (Further page navigation in this area is covered in the product navigation tests)
				Scenario: User is able to navigate to the toner recycling download label page via the top main site support menu
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top support menu button
					Then I hover and click the recycling option
					Then I click the toner recycling button
					Then I click the download your label button
					Then I am navigated to the download your label page

				# Toner recycling collection box navigation (Further page navigation in this area is covered in the product navigation tests)
				Scenario: User is able to navigate to the toner recycling order collection box page via the top main site support menu
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top support menu button
					Then I hover and click the recycling option
					Then I click the toner recycling button
					Then I click the order collection box button
					Then I am navigated to the order your collection box
			
		# Inkjet recycling navigation (Further page navigation in this area is covered in the product navigation tests)
		Scenario: User is able to navigate to the inkjet recycling page via the top main site support menu
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top support menu button
			Then I hover and click the recycling option
			Then I click the inkjet recycling button
			Then I am navigated to the inkjet recycling page

				# Inkjet recycling form navigation (Further page navigation in this area is covered in the product navigation tests)
				Scenario: User is able to navigate to the inkjet recycling form page via the top main site support menu
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top support menu button
					Then I hover and click the recycling option
					Then I click the inkjet recycling button
					Then I click the inkjet recycling form button
					Then I am navigated to the inkkjet recycling form page
		
		# Machine recycling navigation (Further page navigation in this area is covered in the product navigation tests)
		Scenario: User is able to navigate to the machine recycling page via the top main site support menu
			Given I have navigated to the "<site>" MainSite URL for country "<country>"
			And I hover over the top support menu button
			Then I hover and click the recycling option
			Then I click the machine recycling button
			Then I am navigated to the machine recycling page

				# Machine recycling navigation (Further page navigation in this area is covered in the product navigation tests)
				Scenario: User is able to navigate to the machine recycling statement page via the top main site support menu
					Given I have navigated to the "<site>" MainSite URL for country "<country>"
					And I hover over the top support menu button
					Then I hover and click the recycling option
					Then I click the machine recycling button
					Then I click the view statement page
					Then I am navigated to the machine recycling statement page

# Locate a service centre navigation
Scenario: User is able to navigate to the locate a service centre page via the top main site support menu
	Given I have navigated to the "<site>" MainSite URL for country "<country>"
	And I hover over the top support menu button
	Then I hover and click the locate a service centre option
	Then I am navigated to the locate a service centre page





