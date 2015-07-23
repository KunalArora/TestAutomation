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
    [NUnit.Framework.DescriptionAttribute("Account Management")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class AccountManagementFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AccountManagement.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Account Management", "In order to change my Brother Online account details\r\nAs a customer\r\nI need to be" +
                    " able to have account management options", ProgrammingLanguage.CSharp, new string[] {
                        "TEST",
                        "UAT"});
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
        [NUnit.Framework.DescriptionAttribute("Customer has created a Brother Online account and wishes to change their password" +
            " (BOL-164)")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("UAT")]
        [NUnit.Framework.CategoryAttribute("PROD")]
        public virtual void CustomerHasCreatedABrotherOnlineAccountAndWishesToChangeTheirPasswordBOL_164()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer has created a Brother Online account and wishes to change their password" +
                    " (BOL-164)", new string[] {
                        "TEST",
                        "UAT",
                        "PROD"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("I am logged onto Brother Online \"United Kingdom\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("I navigate to my account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.And("I click on Sign In Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Then("If I enter the current password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And("I enter a new password of \"ChangedPassword123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("I click on Update Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("My password will be updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.Then("If I sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.And("If I sign back into Brother Online \"United Kingdom\" using the same credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer has created a Brother Online account but has forgotten their password an" +
            "d requires a new one")]
        [NUnit.Framework.CategoryAttribute("STAGING")]
        public virtual void CustomerHasCreatedABrotherOnlineAccountButHasForgottenTheirPasswordAndRequiresANewOne()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer has created a Brother Online account but has forgotten their password an" +
                    "d requires a new one", new string[] {
                        "STAGING"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("I am logged onto Brother Online \"United Kingdom\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.And("I click on Forgot Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.Then("I enter my current email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.And("I click on Reset Your Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.Then("If I Click the Reset Password Email Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.And("I reset my password with \"ChangedPassword123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("I click on Reset Your Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.Then("I can sign back into Brother Online \"United Kingdom\" using the updated credential" +
                    "s", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer or Dealer role persists after email address change (BOL-176)")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("UAT")]
        public virtual void CustomerOrDealerRolePersistsAfterEmailAddressChangeBOL_176()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer or Dealer role persists after email address change (BOL-176)", new string[] {
                        "TEST",
                        "UAT"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given("I am logged onto Brother Online \"United Kingdom\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.And("If I grant the user account the \"Extranet\\Brother Online Ink Supply User\" role", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I sign back into Brother Online \"United Kingdom\" using the same credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("I can see the Instant Ink menu option from the BOL home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.When("I navigate to my account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.And("I click on Sign In Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("If I enter a new email address \"changed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("If I enter the current password for email change", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I click on Update details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.Then("I can verify the email change occurred", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
 testRunner.And("If I validate the new changes via email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.Then("I can validate the update was successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then("If I sign back into Brother Online \"United Kingdom\" using the same credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.And("I can see the Instant Ink menu option from the BOL home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer can change their Brother Online email address after registration (BBAU -" +
            " 2337)")]
        [NUnit.Framework.CategoryAttribute("STAGING")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "changed", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "changed", null)]
        public virtual void CustomerCanChangeTheirBrotherOnlineEmailAddressAfterRegistrationBBAU_2337(string country, string emailPrefixForChange, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "STAGING"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer can change their Brother Online email address after registration (BBAU -" +
                    " 2337)", @__tags);
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
 testRunner.Given(string.Format("I am logged onto Brother Online \"{0}\" using valid credentials", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.When(string.Format("I navigate to my account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.And("I click on Sign In Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And(string.Format("If I enter a new email address \"{0}\"", emailPrefixForChange), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("If I enter the current password for email change", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("I click on Update details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.Then("I can verify the email change occurred", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
 testRunner.When("I validate the new changes via email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.Then(string.Format("If I sign back into Brother Online \"{0}\" using the same credentials", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Business Customer can change their business details after logging into account")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("UAT")]
        [NUnit.Framework.CategoryAttribute("PROD")]
        public virtual void BusinessCustomerCanChangeTheirBusinessDetailsAfterLoggingIntoAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Business Customer can change their business details after logging into account", new string[] {
                        "TEST",
                        "UAT",
                        "PROD"});
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
 testRunner.Given("I am logged onto Brother Online \"United Kingdom\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
 testRunner.When("I navigate to my account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.When("I clicked on Business Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
 testRunner.And("I am redirected to the Business Details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("I declare that I do use this account for business on my account page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("I add my company name as \"AutoTestLtd\" on Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("I add my company VAT number as \"GB145937540\" on Business Details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I select my Business Sector as \"IT and telecommunications services\" on Business D" +
                    "etails Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("I select number of Employees as \"11 - 50\" on Business Details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I click on Update details on business details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.Then("I can verify successfull update message appeared at the top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer creates a new account with Brother Online and add Business details in My" +
            " account page")]
        public virtual void CustomerCreatesANewAccountWithBrotherOnlineAndAddBusinessDetailsInMyAccountPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer creates a new account with Brother Online and add Business details in My" +
                    " account page", ((string[])(null)));
#line 104
this.ScenarioSetup(scenarioInfo);
#line 105
 testRunner.Given("I am logged onto Brother Online \"United Kingdom\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 106
 testRunner.When("I navigate to my account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
 testRunner.And("I clicked on Business Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I am redirected to the Business Details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.And("I declare that I do use this account for business on my account page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.And("I add my company name as \"AutoTestLtd\" on Business Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.And("I add my company VAT number as \"GB145937540\" on Business Details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.And("I select my Business Sector as \"IT and telecommunications services\" on Business D" +
                    "etails Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.And("I select number of Employees as \"11 - 50\" on Business Details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("I click on Update details on business details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.Then("I can verify successfull update message appeared at the top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer can add a new address to their acocunt by manually entering address deta" +
            "ils")]
        public virtual void CustomerCanAddANewAddressToTheirAcocuntByManuallyEnteringAddressDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer can add a new address to their acocunt by manually entering address deta" +
                    "ils", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 120
testRunner.Given("I am logged onto Brother Online \"United Kingdom\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 121
testRunner.When("I navigate to my account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
testRunner.When("I click on My Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
testRunner.And("I click on Add a New Address Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table1.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table1.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table1.AddRow(new string[] {
                        "Postcode",
                        "m34 5je"});
            table1.AddRow(new string[] {
                        "HouseNumber",
                        "appt 1"});
            table1.AddRow(new string[] {
                        "HouseName",
                        "Brother"});
            table1.AddRow(new string[] {
                        "Addressline1",
                        "TameSt"});
            table1.AddRow(new string[] {
                        "Addressline2",
                        "Audenshaw"});
            table1.AddRow(new string[] {
                        "City",
                        "Manchester"});
            table1.AddRow(new string[] {
                        "PhoneNumber",
                        "0161 330 6531"});
#line 124
testRunner.And("I enter all the mandatory fields", ((string)(null)), table1, "And ");
#line 135
testRunner.And("I click on the save address button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
