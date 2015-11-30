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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial with a Brother Online account but start from Purcha" +
            "se plans page")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void SignUpFor14DayFreeTrialWithABrotherOnlineAccountButStartFromPurchasePlansPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial with a Brother Online account but start from Purcha" +
                    "se plans page", new string[] {
                        "ignore"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when an invalid email is entered" +
            " (BBAU-2721)")]
        [NUnit.Framework.TestCaseAttribute("\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"InvalidEmailForUser\"", null)]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenAnInvalidEmailIsEnteredBBAU_2721(string invalidEmailAddress, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when an invalid email is entered" +
                    " (BBAU-2721)", exampleTags);
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then(string.Format("I enter an invalid email address as {0} for omnijoin free trial", invalidEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.Then("I should see the Error Message displayed on the Email Address field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.When("I have entered a valid First and Last name, \"$%&£^GRYIR&^T*$UOITUJO$J\", \"*$%*\"^%*" +
                    "\"£^%(*$^GHWGKD\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.Then("I should see an error message on the first name and last name field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when Terms and Conditions are no" +
            "t checked on Commit")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenTermsAndConditionsAreNotCheckedOnCommit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when Terms and Conditions are no" +
                    "t checked on Commit", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("I enter a Free Trial Password of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I click Submit without ticking the terms and conditions field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.Then("I should see an error message on Terms and Conditions field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when Passwords do not match")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenPasswordsDoNotMatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when Passwords do not match", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I enter a Free Trial Password of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1235\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("I have Agreed to the Free Trial Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.Then("I should see an error message on Password Confirmation field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when an invalid Password is ente" +
            "red")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenAnInvalidPasswordIsEntered()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when an invalid Password is ente" +
                    "red", ((string[])(null)));
#line 62
this.ScenarioSetup(scenarioInfo);
#line 63
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("I enter a Free Trial Password of \"Abcd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1235\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.Then("I should see an error message on Password field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 74
this.ScenarioSetup(scenarioInfo);
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
#line 77
this.ScenarioSetup(scenarioInfo);
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
#line 80
this.ScenarioSetup(scenarioInfo);
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
#line 83
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
