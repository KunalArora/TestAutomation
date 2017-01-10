@PROD @UAT @TEST
Feature: Cookie Information
	As a vistor of the Brother Websites
	I am able to view and dismiss
	cookie information

# Validate that a user is able to accept the cookie information on first visit to brother online to prevent it from being displayed again
Scenario: Validate that a user can view cookie information on first visit to brother online and once accepted does not see it again
	Given I launch Brother Online for "United Kingdom"
	Then I delete all page cookies
	Then I refresh the current page
	Then I can see and click the accept cookies button
	And I refresh the current page
	Then I can no longer see the accept cookies button

# Validate that a user always sees the cookie information bar on subsequent visits to the site unless the information is accepted
Scenario: Validate that a user of Brother online will always see cookie information on subsequent visits to the site if cookies are not accepted
	Given I launch Brother Online for "United Kingdom"
	Then I delete all page cookies
	And I refresh the current page
	Then I can see the cookies information bar
	And I refresh the current page again
	Then I continue to see the cookies information bar

# Validate that a user can click to find out more information about the cookie privacy policy and then go on to view company terms and conditions
Scenario: Validate that a user of Brother online can view the cookie privacy policy and terms and conditions information prior to accepting cookies
	Given I launch Brother Online for "United Kingdom"
	Then I delete all page cookies
	And I refresh the current page
	Then I can see the cookies information bar
	And I can see and click the find out more button on the cookies information bar
	Then I am navigated to the privacy policy for cookies
	And I click to view the company terms and conditions
	Then I am navigated to the company terms and conditions page
