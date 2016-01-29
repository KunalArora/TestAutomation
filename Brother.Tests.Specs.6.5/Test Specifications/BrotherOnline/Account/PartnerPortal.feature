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


@TEST
Scenario Outline: AdminUser on dealer portal gets valid error messages when personal info page  mandatory fields are not completed
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
When I click on Edit your personal info page
And I see Edit address page
And I enter tab on HouseName field
Then I should see an error message on the HouseName field 
When I enter tab on AddressLine name field
Then I should see an error message on the address field 
When I enter tab on HouseNumber field
Then I should see an error message on house number field
When I enter tab on code postal
Then I should see error message on codepostal field
When I enter tab on phoneNumber field
Then I should see error message on PhoneNumber field

Examples:
| Country   |   Email Address1                           | Password          |
| Belgium   |   lw_brother_be_dealer@mailinator.com      | Brother1          | 
    

@TEST
Scenario Outline: Dealer admin user adds new customer on managecustomersandorder page on Uk dv2 site
Given I launch Brother Online for "<Country>"
When I click on Create Account for "<Country>"
And I am redirected to the Brother Login/Register page
And I fill in email as "<Email Address1>"
And I fill in password as "<Password>"
And I press sign in 
Then I should be logged in successfully
And I click on Partner Portal menu
And I click on partner portal button
And I click on ManageCustomersandOrders button
Then I should see ManageCustomersandOrdersPage
And I click on ADD a colleague
And I enter email address as "<Email Address2>"
And I click on submit
When I fill in FirstName as "<FirstName>"
And I fill in LastName as "<LastName>"
And I fill in companyName as "<CompanyName>"
And I click submit
Then I should see success message on the page
When I close the message
Then I should see added customer in the Managecustomersandorderspage

Examples:
| Country        | Email Address1                      | Password           | Email Address2 | FirstName | LastName | CompanyName |
| United Kingdom | bol_uk@mailinator.com               | Password01         |                | Test      | user     | Test123     |


@TEST
Scenario Outline: Dealer user gets valid error messages when editaddress page mandatory fields are incomplete
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
When I click on Edit address button
And I see Edit address page
When I enter tab on Postcode
Then I should see error message on codepostal field
When I enter tab on HouseNumber field
Then I should see an error message on house number field
When I enter tab on HouseName field
Then I should see an error message on the HouseName field 
When I enter tab on AddressLine name field
Then I should see an error message on the address field 
When I enter tab on CityorTown field
Then I should see an error message on CityorTown field
When I enter tab on phoneNumber field
Then I should see error message on PhoneNumber field

Examples:
| Country          |   Email Address1                           | Password          |
| United Kingdom   |   bol_uk@mailinator.com                    | Password01        | 


@TEST
Scenario Outline: DealerUser can add newuser on partnerportal edit user page
Given I launch Brother Online for "<Country>"
When I click on Create Account for "<Country>"
And I am redirected to the Brother Login/Register page
And I fill in email as "<Email Address1>"
And I fill in password as "<Password>"
And I press sign in 
Then I should be logged in successfully
And I click on Partner Portal menu
And I click on partner portal button
And I click on EditUsers role
Then I should see EditUsersPage
And I click on AddUser
And I enter Email as "<Email Address2>"
And I click next
When I enter FirstName as "<FirstName>"
And I enter LastName as "<LastName>"
And I click on submit
Then I should see success message
And I close the message pop-up

Examples:
| Country        | Email Address1        | Password   | Email Address2 | FirstName | LastName | 
| United Kingdom | bol_uk@mailinator.com | Password01 |                | Test      | User     | 
           
