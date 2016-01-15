@TEST
Feature: PartnerPortal
As a Dealeradmin user I want to add new users on Manage users list page.
And
As a Dealeruser without adminrights I want to access partner portal page and cannot see manage users list page.

@TEST
Scenario Outline: Add a newuser to userlist page
Given I launch Brother Online for "<Country>"
When I click on Create Account for "<Country>"
And I am redirected to the Brother Login/Register page
And I fill in email as "<Email Address1>"
And I fill in password as "<Password>"
And I press sign in 
Then I should be logged in successfully
And I click on Partner Portal menu
And I click on partner portal button
Then I should see manage userlist page
And I click on Manage a list of closed area
Then I should see ManageCustomersandOrdersPage
And I click on ADD a colleague
Then I should see enter email address field
And I enter email address as "<Email Address2>"
And I click on submit
Then I should see FirstName and LastName fields
And I fill in FirstName as "<FirstName>"
And I fill in LastName as "<LastName>"
And I click submit
Then I should see success message on the page
And I close the message
And I should see created user in the user list page


Examples:
| Country   |   Email Address1                               | Password          | Email Address2 | FirstName            | LastName    |
| Belgium   |   lw_brother_be_dealer@mailinator.com          | Brother1          |                | "Test"	             | "user"      | 

@TEST
Scenario Outline: User without adminrights cannot see manage users list page
Given I launch Brother Online for "<Country>"
When I click on Create Account for "<Country>"
And I am redirected to the Brother Login/Register page
And I fill in email as "<Email Address1>"
And I fill in password as "<Password>"
And I press sign in 
Then I should be logged in successfully
And I click on Partner Portal menu
And I click on partner portal button
Then I should see partner portal homepage without manageusers list page access

Examples:
| Country   |   Email Address1                           | Password          |
| Belgium   |   lw_brother_be_user@mailinator.com        | Brother1          |                

