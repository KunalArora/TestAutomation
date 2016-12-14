﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Brother.Online.TestSpecs._80.TestSpecification
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Existing User Forgotten Password")]
    [NUnit.Framework.CategoryAttribute("SMOKE")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class ExistingUserForgottenPasswordFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ExistingUser.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Existing User Forgotten Password", "In order to change maintain by Brother Online Account\r\nAs a customer\r\nI need to b" +
                    "e able to have account management options", ProgrammingLanguage.CSharp, new string[] {
                        "SMOKE",
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
        [NUnit.Framework.DescriptionAttribute("Check Forget Password with various invalid scenarios options throws an error for " +
            "existing user - Validation Checks")]
        [NUnit.Framework.CategoryAttribute("SMOKE_ExistingUserSignIn")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "InvalidEmailContaining aspace@mailinator.com", null)]
        public virtual void CheckForgetPasswordWithVariousInvalidScenariosOptionsThrowsAnErrorForExistingUser_ValidationChecks(string country, string siteUrl, string invalidEmailAddress, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE_ExistingUserSignIn",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Forget Password with various invalid scenarios options throws an error for " +
                    "existing user - Validation Checks", @__tags);
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.And(string.Format("I browse to the \"{0}\" for existing user signin page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I click on existing customer log in option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I click on Forgot Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then(string.Format("I enter an invalid email address as \"{0}\"", invalidEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.Then("I should see the Error Message activated and displaying an Error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check Forgotten Password email recieved to the user")]
        [NUnit.Framework.CategoryAttribute("SMOKE_ExistingUserSignIn")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "123orderplacedukaccount@guerrillamail.com", null)]
        public virtual void CheckForgottenPasswordEmailRecievedToTheUser(string country, string siteUrl, string validEmailAddress, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE_ExistingUserSignIn",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check Forgotten Password email recieved to the user", @__tags);
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.And(string.Format("I browse to the \"{0}\" for existing user signin page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I click on existing customer log in option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("I click on Forgot Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then(string.Format("I enter an email address as \"{0}\"", validEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("I press send email button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And(string.Format("Once I have Validated \"{0}\" was received and verified my account", validEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
