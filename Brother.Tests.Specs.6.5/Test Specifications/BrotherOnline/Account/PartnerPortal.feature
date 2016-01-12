Feature: PartnerPortal
As a admin user I want to add new users on maintenance user list page.

@TEST
Scenario Outline: Add a new user to userlist page
Given I launch Brother Online for "<Country>"
When I click on Create Account for "<Country>"
And I am redirected to the Brother Login/Register page
And I fill in email as "<Email Address1>"
And I fill in password as "<Password>"
And I press sign in 
Then I should be logged in successfully
And I click on partner portal tab
Then I should see partner portal home page 
And I click on partner portal button
Then I should see manage userlist page
And I click on Manage a list of closed area
Then I should see Manage users list page
#And I click on ADD a colleague
#Then I should see enter email address field
#And I enter email address as "<Email Address2>"
#And I click on submit
#Then I should see FirstName and Name fields appears on pop-up window
#And I fill in FirstName as "<FirstName>"
#And I fill in Name as "<Name>"
#And I click confirm
#Then I should see message "<Pop-Up Message>" on the page
#And I close the pop-up window
#Then I should see added user in maintain user list page.

Examples:
| Country   |   Email Address1                               | Password          | Email Address2 | FirstName            | Name        | Pop-Up Message                         |
| Belgium   |   lw_brother_be_dealer@mailinator.com          | Brother1          |                | "Test"	             |  "user"     |  "User added successfully"             |



