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
testRunner.And("I click on partner portal tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.Then("I should see partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.And("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.Then("I should see manage userlist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.And("I click on Manage a list of closed area", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.Then("I should see ManageCustomersandOrdersPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.And("I click on ADD a colleague", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.Then("I should see enter email address field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.And(string.Format("I enter email address as \"{0}\"", emailAddress2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.And("I click on submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.Then("I should see FirstName and LastName fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.And(string.Format("I fill in FirstName as \"{0}\"", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.And(string.Format("I fill in LastName as \"{0}\"", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.And("I click submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.Then("I should see success message on the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
testRunner.And("I close the message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
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
testRunner.And("I click on partner portal tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.Then("I should see partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
testRunner.When("I click on partner portal button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("I should see partner portal homepage without manageusers list page access", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
