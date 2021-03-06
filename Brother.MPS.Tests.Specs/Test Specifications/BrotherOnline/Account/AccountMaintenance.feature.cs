﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Account Maintenance")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    public partial class AccountMaintenanceFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AccountMaintenance.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Account Maintenance", "\tIn order to change maintain by Brother Online Account\r\n\tAs a customer\r\n\tI need t" +
                    "o be able to have account management maintenance options", ProgrammingLanguage.CSharp, new string[] {
                        "TEST",
                        "UAT",
                        "PROD"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
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
        [NUnit.Framework.DescriptionAttribute("Check Forget Password with various invalid scenarios options")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", @"""ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com""", null)]
        [NUnit.Framework.TestCaseAttribute("France", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("France", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("France", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("France", @"""ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com""", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", @"""ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com""", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", @"""ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com""", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", @"""ThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceeds241CharactersAndThisIsNotSupportedaaaaaaaaaaaThisIsAVeryLargeEmailAddressWhichExceed241CharactersExceed241Characters@mailinator.com""", null)]
        public virtual void CheckForgetPasswordWithVariousInvalidScenariosOptions(string country, string invalidEmailAddress, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Forget Password with various invalid scenarios options", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("I want to create a new account with Brother Online \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.And("I click on Forgot Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.Then(string.Format("I enter an invalid email address as {0}", invalidEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.Then("I should see the Error Message activated and displaying an Error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And(string.Format("I can navigate to the Brother Online Home Page \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer create a new account and amend their personal details by going into my a" +
            "ccount page")]
        [NUnit.Framework.TestCaseAttribute("Test", "Test", null)]
        public virtual void CustomerCreateANewAccountAndAmendTheirPersonalDetailsByGoingIntoMyAccountPage(string firstName, string lastName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer create a new account and amend their personal details by going into my a" +
                    "ccount page", exampleTags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                        "Password",
                        "@@@@@"});
            table1.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 45
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table1, "And ");
#line 52
    testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
 testRunner.When("I navigate to my account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.And(string.Format("I enter First Name containing {0}", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And(string.Format("I enter the Last Name containing {0}", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I click on update details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.Then("my personal details should get updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
 testRunner.Then("I can navigate back to Brother Online home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer gets valid error message on BOL Norway site with invalid tax code")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("Norway", "Industri", "INVALIDVATNUMBER", null)]
        public virtual void CustomerGetsValidErrorMessageOnBOLNorwaySiteWithInvalidTaxCode(string country, string businessSector, string vATNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore",
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer gets valid error message on BOL Norway site with invalid tax code", @__tags);
#line 71
this.ScenarioSetup(scenarioInfo);
#line 72
 testRunner.Given(string.Format("I want to create a new account with Brother Online \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
 testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I declare that I do use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table2.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table2.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table2.AddRow(new string[] {
                        "Password",
                        "@@@@@"});
            table2.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 77
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table2, "And ");
#line 83
 testRunner.And("I add my company name as \"AutoTestLtd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And(string.Format("I select my Business Sector as \"{0}\"", businessSector), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("I select number of Employees as \"11 - 50\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.And(string.Format("I enter an invalid VAT Number as \"{0}\"", vATNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.Then("I should see an error message due to an invalid tax code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer create a new B2C account and closes that account on signin details page")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "Other", null)]
        public virtual void CustomerCreateANewB2CAccountAndClosesThatAccountOnSigninDetailsPage(string country, string reasonForCancellation, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer create a new B2C account and closes that account on signin details page", exampleTags);
#line 97
this.ScenarioSetup(scenarioInfo);
#line 98
 testRunner.Given(string.Format("I want to create a new account with Brother Online \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
 testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table3.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table3.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table3.AddRow(new string[] {
                        "Password",
                        "@@@@@"});
            table3.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 102
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table3, "And ");
#line 109
    testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.Then(string.Format("I should be able to log into \"{0}\" Brother Online using my account details", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
 testRunner.When(string.Format("I navigate to my account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
 testRunner.And("I click on Sign In Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And("I click close account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And(string.Format("I select \"{0}\"", reasonForCancellation), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.And("I click closeaccount button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.Then("I should see email sent message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
 testRunner.Then("I can navigate back to Brother Online home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
