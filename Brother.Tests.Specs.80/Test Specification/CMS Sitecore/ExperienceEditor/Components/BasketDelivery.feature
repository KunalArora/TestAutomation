﻿Feature: Basket delivery feature
	As a content editor I am able to add 
	edit and delete the basket delivery
	component on existing and newly created pages

@mytag
Scenario: Add a new basket delivery component to page
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen