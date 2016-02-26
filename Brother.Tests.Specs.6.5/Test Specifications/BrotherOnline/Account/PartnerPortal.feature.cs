﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Brother.Tests.Specs.TestSpecifications.BrotherOnline.Account
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PartnerPortal")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class PartnerPortalFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PartnerPortal.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PartnerPortal", "As a Dealeradmin user I want to add new users on Manage users list page.\r\nAnd\r\nAs" +
                    " a Dealeruser without adminrights I want to access partner portal page and canno" +
                    "t see manage users list page.", ProgrammingLanguage.CSharp, new string[] {
                        "TEST"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add a newuser to userlist page")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("Belgium", "lw_brother_be_dealer@mailinator.com", "Brother1", "", "\"Test\"", "\"user\"", null)]
        public virtual void AddANewuserToUserlistPage(string country, string emailAddress1, string password, string emailAddress2, string firstName, string lastName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a newuser to userlist page", @__tags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.Then("I should see manage userlist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.And("I click on Manage a list of closed area", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.Then("I should see ManageCustomersandOrdersPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.And("I click on ADD a colleague", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.Then("I should see enter email address field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
testRunner.And(string.Format("I enter email address as \"{0}\"", emailAddress2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.And("I click on submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.Then("I should see FirstName and LastName fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.And(string.Format("I fill in FirstName as \"{0}\"", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.And(string.Format("I fill in LastName as \"{0}\"", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.And("I click submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.Then("I should see success message on the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.And("I close the message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.And("I should see created user in the user list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User without adminrights cannot see manage users list page")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("Belgium", "lw_brother_be_user@mailinator.com", "Brother1", null)]
        public virtual void UserWithoutAdminrightsCannotSeeManageUsersListPage(string country, string emailAddress1, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User without adminrights cannot see manage users list page", @__tags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
testRunner.Then("I should see partner portal homepage without manageusers list page access", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("AdminUser on dealer portal gets valid error messages when personal info page  man" +
            "datory fields are not completed")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("Belgium", "lw_brother_be_dealer@mailinator.com", "Brother1", null)]
        public virtual void AdminUserOnDealerPortalGetsValidErrorMessagesWhenPersonalInfoPageMandatoryFieldsAreNotCompleted(string country, string emailAddress1, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("AdminUser on dealer portal gets valid error messages when personal info page  man" +
                    "datory fields are not completed", @__tags);
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
testRunner.Then("I should see manage userlist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
testRunner.When("I click on Edit your personal info page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.And("I see Edit address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.And("I enter tab on HouseName field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
testRunner.Then("I should see an error message on the HouseName field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
testRunner.When("I enter tab on AddressLine name field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
testRunner.Then("I should see an error message on the address field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
testRunner.When("I enter tab on HouseNumber field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
testRunner.Then("I should see an error message on house number field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
testRunner.When("I enter tab on code postal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
testRunner.Then("I should see error message on codepostal field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
testRunner.When("I enter tab on phoneNumber field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
testRunner.Then("I should see error message on PhoneNumber field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer admin user adds new customer on managecustomersandorder page on Uk dv2 sit" +
            "e")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "bol_uk@mailinator.com", "Password01", "", "Test", "user", "Test123", null)]
        public virtual void DealerAdminUserAddsNewCustomerOnManagecustomersandorderPageOnUkDv2Site(string country, string emailAddress1, string password, string emailAddress2, string firstName, string lastName, string companyName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer admin user adds new customer on managecustomersandorder page on Uk dv2 sit" +
                    "e", @__tags);
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
testRunner.And("I click on ManageCustomersandOrders button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
testRunner.Then("I should see ManageCustomersandOrdersPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 100
testRunner.And("I click on ADD a colleague", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
testRunner.And(string.Format("I enter email address as \"{0}\"", emailAddress2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
testRunner.And("I click on submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
testRunner.When(string.Format("I fill in FirstName as \"{0}\"", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
testRunner.And(string.Format("I fill in LastName as \"{0}\"", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
testRunner.And(string.Format("I fill in companyName as \"{0}\"", companyName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
testRunner.And("I click submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
testRunner.Then("I should see success message on the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
testRunner.When("I close the message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
testRunner.Then("I should see added customer in the Managecustomersandorderspage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer user gets valid error messages when editaddress page mandatory fields are " +
            "incomplete")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "bol_uk@mailinator.com", "Password01", null)]
        public virtual void DealerUserGetsValidErrorMessagesWhenEditaddressPageMandatoryFieldsAreIncomplete(string country, string emailAddress1, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer user gets valid error messages when editaddress page mandatory fields are " +
                    "incomplete", @__tags);
#line 117
this.ScenarioSetup(scenarioInfo);
#line 118
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 119
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
testRunner.Then("I should see manage userlist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.When("I click on Edit address button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
testRunner.And("I see Edit address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
testRunner.When("I enter tab on Postcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
testRunner.Then("I should see error message on codepostal field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
testRunner.When("I enter tab on HouseNumber field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
testRunner.Then("I should see an error message on house number field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
testRunner.When("I enter tab on HouseName field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 135
testRunner.Then("I should see an error message on the HouseName field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
testRunner.When("I enter tab on AddressLine name field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 137
testRunner.Then("I should see an error message on the address field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
testRunner.When("I enter tab on CityorTown field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
testRunner.Then("I should see an error message on CityorTown field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
testRunner.When("I enter tab on phoneNumber field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
testRunner.Then("I should see error message on PhoneNumber field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DealerUser can add newuser on partnerportal edit user page")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "bol_uk@mailinator.com", "Password01", "", "Test", "User", null)]
        public virtual void DealerUserCanAddNewuserOnPartnerportalEditUserPage(string country, string emailAddress1, string password, string emailAddress2, string firstName, string lastName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DealerUser can add newuser on partnerportal edit user page", @__tags);
#line 149
this.ScenarioSetup(scenarioInfo);
#line 150
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 151
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 152
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
testRunner.And("I click on EditUsers role", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 160
testRunner.Then("I should see EditUsersPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 161
testRunner.And("I click on AddUser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
testRunner.And(string.Format("I enter Email as \"{0}\"", emailAddress2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
testRunner.And("I click next", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 164
testRunner.When(string.Format("I enter FirstName as \"{0}\"", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 165
testRunner.And(string.Format("I enter LastName as \"{0}\"", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
testRunner.And("I click on submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
testRunner.Then("I should see success message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 168
testRunner.And("I close the message pop-up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealeruser gets valid errormessage if number of licences  field is incomplete in " +
            "manage subscription page")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "bol_uk@mailinator.com", "Password01", null)]
        public virtual void DealeruserGetsValidErrormessageIfNumberOfLicencesFieldIsIncompleteInManageSubscriptionPage(string country, string emailAddress1, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealeruser gets valid errormessage if number of licences  field is incomplete in " +
                    "manage subscription page", @__tags);
#line 175
this.ScenarioSetup(scenarioInfo);
#line 176
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 177
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 178
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 181
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 182
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 183
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 184
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 185
testRunner.And("I click on manage services button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 186
testRunner.And("I click on view subscription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 187
testRunner.And("I click manage subscription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 188
testRunner.And("I click submit button to upgrade the trail without selecting licenses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
testRunner.Then("I should error message on Number of licenses field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealeruser gets valid errormessage if cancel subscription page mandatory fields a" +
            "re incomplete before cancelling the subscription")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "bol_uk@mailinator.com", "Password01", null)]
        public virtual void DealeruserGetsValidErrormessageIfCancelSubscriptionPageMandatoryFieldsAreIncompleteBeforeCancellingTheSubscription(string country, string emailAddress1, string password, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealeruser gets valid errormessage if cancel subscription page mandatory fields a" +
                    "re incomplete before cancelling the subscription", @__tags);
#line 197
this.ScenarioSetup(scenarioInfo);
#line 198
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 199
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 200
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 201
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 204
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 205
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 206
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 207
testRunner.And("I click on manage services button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 208
testRunner.And("I click on view subscription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 209
testRunner.And("I click on cancel subscription link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 210
testRunner.And("I click on cancel subscription button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
testRunner.Then("I should see error message on Reason for cancellation field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 212
testRunner.And("I should see error message on Confirm your account password field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Dealeruser can remove cancellation of already placed order subscription")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "bol_uk@mailinator.com", "Password01", "Other", null)]
        public virtual void VerifyDealeruserCanRemoveCancellationOfAlreadyPlacedOrderSubscription(string country, string emailAddress1, string password, string reasonForCancellation, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Dealeruser can remove cancellation of already placed order subscription", @__tags);
#line 219
this.ScenarioSetup(scenarioInfo);
#line 220
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 221
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 222
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 223
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 224
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 225
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 226
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 227
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 228
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 229
testRunner.And("I click on manage services button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 230
testRunner.And("I click on view subscription", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 231
testRunner.And("I click on cancel subscription link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 232
testRunner.And(string.Format("I select \"{0}\"", reasonForCancellation), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 233
testRunner.And(string.Format("I enter confirm with your password \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 234
testRunner.And("I click on cancel subscription button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 235
testRunner.Then("I should see remove cancellation button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 236
testRunner.And("I click on remove cancellation button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 237
testRunner.Then("I should be redirected to cancel subscription page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealeruser able to delete the customer in editdetails page")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "bol_uk@mailinator.com", "Password01", "Edit Customer", null)]
        public virtual void DealeruserAbleToDeleteTheCustomerInEditdetailsPage(string country, string emailAddress1, string password, string selectAction, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealeruser able to delete the customer in editdetails page", @__tags);
#line 245
this.ScenarioSetup(scenarioInfo);
#line 246
testRunner.Given(string.Format("I launch Brother Online for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 247
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 248
testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 249
testRunner.And(string.Format("I fill in email as \"{0}\"", emailAddress1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 250
testRunner.And(string.Format("I fill in password as \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 251
testRunner.And("I press sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 252
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 253
testRunner.And("I click on Partner Portal menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 254
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 255
testRunner.And("I click on ManageCustomersandOrders button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 256
testRunner.And(string.Format("I select action \"{0}\"", selectAction), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 257
testRunner.Then("I should see EditDetails page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 258
testRunner.And("I click on DeleteCustomer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 259
testRunner.Then("I should see Deletecustomer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 260
testRunner.And("I click on cancel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 261
testRunner.Then("I should see manage orders and customers page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
