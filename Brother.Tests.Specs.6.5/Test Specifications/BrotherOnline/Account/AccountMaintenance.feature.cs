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
    [NUnit.Framework.DescriptionAttribute("Account Maintenance")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    public partial class AccountMaintenanceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AccountMaintenance.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Account Maintenance", "In order to change maintain by Brother Online Account\r\nAs a customer\r\nI need to b" +
                    "e able to have account management maintenance options", ProgrammingLanguage.CSharp, new string[] {
                        "TEST",
                        "UAT",
                        "PROD"});
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
        [NUnit.Framework.DescriptionAttribute("Check Forget Password with various invalid scenarios options (BOL-177, BBAU-2339)" +
            "")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("France", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("France", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("France", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "\"InvalidEmailForUser\"", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "\"InvalidEmailForUser\"", null)]
        public virtual void CheckForgetPasswordWithVariousInvalidScenariosOptionsBOL_177BBAU_2339(string country, string invalidEmailAddress, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Forget Password with various invalid scenarios options (BOL-177, BBAU-2339)" +
                    "", exampleTags);
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
    }
}
#pragma warning restore
#endregion
