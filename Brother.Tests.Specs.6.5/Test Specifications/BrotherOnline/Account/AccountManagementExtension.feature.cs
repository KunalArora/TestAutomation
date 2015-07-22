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
    [NUnit.Framework.DescriptionAttribute("Account Management Test Extension")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class AccountManagementTestExtensionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AccountManagementExtension.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Account Management Test Extension", "In order to change my Brother Online account details\r\nAs a customer\r\nI need to be" +
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
        [NUnit.Framework.DescriptionAttribute("Create a business account change the business account to be Customer Account")]
        public virtual void CreateABusinessAccountChangeTheBusinessAccountToBeCustomerAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a business account change the business account to be Customer Account", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I declare that I do use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
#line 15
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table1, "And ");
#line 22
 testRunner.And("I add my company name as \"AutoTestLtd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I select my Business Sector as \"IT and telecommunications services\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I select number of Employees as \"11 - 50\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("Once I have Validated an Email was received and verified my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.When("I navigate to my account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.When("I clicked on Business Details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.And("I declare that I do not use this account for business on my account page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I click on Update details on business details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.Then("I can verify successfull update message appeared at the top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
