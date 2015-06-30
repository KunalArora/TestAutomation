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
namespace Brother.Tests.Specs.TestSpecifications.OmniJoin
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("FreeTrial")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("DEV")]
    public partial class FreeTrialFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FreeTrial.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FreeTrial", "In order to try out OmniJoin for 30 days\r\nAs a customer\r\nI need to sign up for a " +
                    "Free trial", ProgrammingLanguage.CSharp, new string[] {
                        "PROD",
                        "UAT",
                        "TEST",
                        "DEV"});
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
        
        public virtual void FeatureBackground()
        {
#line 7
#line 9
 testRunner.Given("I am logged onto Brother Online \"United Kingdom\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial already signed into Brother Online")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void SignUpFor14DayFreeTrialAlreadySignedIntoBrotherOnline()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial already signed into Brother Online", new string[] {
                        "SMOKE"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 13
 testRunner.Given("I am logged into my Brother Online account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("I have navigated to the OmniJoin WebConferencing Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.And("I have entered a valid email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("I have Agreed to the Free Trial Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("if I click Submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("I should be directed to the download page indicating I have 14 days Free trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And("Once I have Validated a Free Trial confirmation Email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.Then("If I go back to Brother Online Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial with a Brother Online account but start from Purcha" +
            "se plans page")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void SignUpFor14DayFreeTrialWithABrotherOnlineAccountButStartFromPurchasePlansPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial with a Brother Online account but start from Purcha" +
                    "se plans page", new string[] {
                        "ignore"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial without an existing Brother Online account")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void SignUpFor14DayFreeTrialWithoutAnExistingBrotherOnlineAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial without an existing Brother Online account", new string[] {
                        "ignore"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 34
 testRunner.Given("I have navigated to the OmniJoin WebConferencing Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.And("I have entered a valid AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I have Agreed to the Free Trial Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("if I click Submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.Then("I should be directed to the download page indicating I have 14 days Free trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.And("Once I have Validated a Free Trial confirmation Email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.Then("If I go back to Brother Online Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form accepts correct amount of characters and displays error " +
            "messages")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormAcceptsCorrectAmountOfCharactersAndDisplaysErrorMessages()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form accepts correct amount of characters and displays error " +
                    "messages", new string[] {
                        "ignore"});
#line 51
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when an invalid email is entered" +
            "")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenAnInvalidEmailIsEntered()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when an invalid email is entered" +
                    "", new string[] {
                        "ignore"});
#line 54
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when invalid First and Last name" +
            "s are entered")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenInvalidFirstAndLastNamesAreEntered()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when invalid First and Last name" +
                    "s are entered", new string[] {
                        "ignore"});
#line 57
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when Terms and Conditions are no" +
            "t checked on Commit")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenTermsAndConditionsAreNotCheckedOnCommit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when Terms and Conditions are no" +
                    "t checked on Commit", new string[] {
                        "ignore"});
#line 60
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when an invalid Password is ente" +
            "red")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenAnInvalidPasswordIsEntered()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when an invalid Password is ente" +
                    "red", new string[] {
                        "ignore"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when Passwords do not match")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenPasswordsDoNotMatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when Passwords do not match", new string[] {
                        "ignore"});
#line 66
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when a mandatory field is missin" +
            "g")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenAMandatoryFieldIsMissing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when a mandatory field is missin" +
                    "g", new string[] {
                        "ignore"});
#line 69
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form when already signed into Brother Online and a Free-trial" +
            " is already in progress")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormWhenAlreadySignedIntoBrotherOnlineAndAFree_TrialIsAlreadyInProgress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form when already signed into Brother Online and a Free-trial" +
                    " is already in progress", new string[] {
                        "ignore"});
#line 72
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form when already signed into Brother Online and a Free-trial" +
            " has expired")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormWhenAlreadySignedIntoBrotherOnlineAndAFree_TrialHasExpired()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form when already signed into Brother Online and a Free-trial" +
                    " has expired", new string[] {
                        "ignore"});
#line 75
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form when already signed into Brother Online, Free-trial has " +
            "expired but is within the wait time for a new trial")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void ValidateFreeTrialFormWhenAlreadySignedIntoBrotherOnlineFree_TrialHasExpiredButIsWithinTheWaitTimeForANewTrial()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form when already signed into Brother Online, Free-trial has " +
                    "expired but is within the wait time for a new trial", new string[] {
                        "ignore"});
#line 78
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
