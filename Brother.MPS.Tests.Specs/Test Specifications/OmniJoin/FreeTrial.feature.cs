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
namespace Brother.Tests.Specs.TestSpecifications.OmniJoin
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("FreeTrial")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("DEV")]
    public partial class FreeTrialFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "FreeTrial.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "FreeTrial", "\tIn order to try out OmniJoin for 30 days\r\n\tAs a customer\r\n\tI need to sign up for" +
                    " a Free trial\r\n\r\n// @ignore", ProgrammingLanguage.CSharp, new string[] {
                        "PROD",
                        "UAT",
                        "TEST",
                        "DEV"});
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
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial with a Brother Online account but start from Purcha" +
            "se plans page")]
        public virtual void SignUpFor14DayFreeTrialWithABrotherOnlineAccountButStartFromPurchasePlansPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial with a Brother Online account but start from Purcha" +
                    "se plans page", ((string[])(null)));
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
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then(string.Format("I enter an invalid email address as {0} for omnijoin free trial", invalidEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.And("I should see the Error Message displayed on the Email Address field for omnijoin " +
                    "free trail page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when invalid First and Last name" +
            "s are entered")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenInvalidFirstAndLastNamesAreEntered()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when invalid First and Last name" +
                    "s are entered", new string[] {
                        "ignore"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.When("I have entered a valid First and Last name, \"$%&£^GRYIR&^T*$UOITUJO$J\", \"*$%*\"^%*" +
                    "\"£^%(*$^GHWGKD\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
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
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I enter a Free Trial Password of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I click Submit without ticking the terms and conditions field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.Then("I should see an error message on Terms and Conditions field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when Passwords do not match")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenPasswordsDoNotMatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when Passwords do not match", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("I enter a Free Trial Password of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1235\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I have Agreed to the Free Trial Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
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
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("I enter a Free Trial Password of \"Abcd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1235\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.Then("I should see an error message on Password field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial already signed into Brother Online Germany")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void SignUpFor14DayFreeTrialAlreadySignedIntoBrotherOnlineGermany()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial already signed into Brother Online Germany", new string[] {
                        "IGNORE"});
#line 73
this.ScenarioSetup(scenarioInfo);
#line 74
 testRunner.Given("I want to create a new account with Brother Online \"Germany\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
 testRunner.When("I click on Create Account for \"Germany\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
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
#line 78
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table1, "And ");
#line 85
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.Then("I should be able to log into \"Germany\" Brother Online using my account details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
 testRunner.And("I click on Try Now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.Then("I should see OmniJOin Free trail page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.When("I have entered a valid FirstName as \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.And("I have  entered a valid LastName as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("I have entered a valid company name as \"adfasdfadsf\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("I have entered a valid phone number as \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
    testRunner.And("I agreed to the free trail terms and services", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
  testRunner.And("I click start free trail button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.Then("I should be on download page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 100
 testRunner.And("Once I have Validated a Free Trial confirmation Email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.Then("If I go back to Brother Online Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial already signed into Brother Online Ireland")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void SignUpFor14DayFreeTrialAlreadySignedIntoBrotherOnlineIreland()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial already signed into Brother Online Ireland", new string[] {
                        "IGNORE"});
#line 107
this.ScenarioSetup(scenarioInfo);
#line 108
 testRunner.Given("I want to create a new account with Brother Online \"Ireland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 109
 testRunner.When("I click on Create Account for \"Ireland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
#line 112
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table2, "And ");
#line 119
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.Then("I should be able to log into \"Ireland\" Brother Online using my account details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
 testRunner.And("I click on Try Now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.Then("I should see OmniJOin Free trail page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
 testRunner.When("I have entered a valid FirstName as \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
 testRunner.And("I have  entered a valid LastName as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.And("I agreed to the free trail terms and services", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
  testRunner.And("I click start free trail button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.Then("I should be on download page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
 testRunner.And("Once I have Validated a Free Trial confirmation Email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.Then("If I go back to Brother Online Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when a mandatory field is missin" +
            "g")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenAMandatoryFieldIsMissing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when a mandatory field is missin" +
                    "g", new string[] {
                        "ignore"});
#line 137
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form when already signed into Brother Online and a Free-trial" +
            " is already in progress")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void ValidateFreeTrialFormWhenAlreadySignedIntoBrotherOnlineAndAFree_TrialIsAlreadyInProgress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form when already signed into Brother Online and a Free-trial" +
                    " is already in progress", new string[] {
                        "ignore"});
#line 140
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form when already signed into Brother Online and a Free-trial" +
            " has expired")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void ValidateFreeTrialFormWhenAlreadySignedIntoBrotherOnlineAndAFree_TrialHasExpired()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form when already signed into Brother Online and a Free-trial" +
                    " has expired", new string[] {
                        "ignore"});
#line 143
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form when already signed into Brother Online, Free-trial has " +
            "expired but is within the wait time for a new trial")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        public virtual void ValidateFreeTrialFormWhenAlreadySignedIntoBrotherOnlineFree_TrialHasExpiredButIsWithinTheWaitTimeForANewTrial()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form when already signed into Brother Online, Free-trial has " +
                    "expired but is within the wait time for a new trial", new string[] {
                        "ignore"});
#line 146
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
