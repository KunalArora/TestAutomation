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
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial already signed into Brother Online")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void SignUpFor14DayFreeTrialAlreadySignedIntoBrotherOnline()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial already signed into Brother Online", new string[] {
                        "SMOKE"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
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
#line 14
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table1, "And ");
#line 21
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.When("I navigate to my account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.And("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.And("I have entered a valid email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("I have Agreed to the Free Trial Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("if I click Submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.Then("I should be directed to the download page indicating I have 14 days Free trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.And("Once I have Validated a Free Trial confirmation Email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.Then("If I go back to Brother Online Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
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
#line 44
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign Up for 14 day Free trial without an existing Brother Online account(BBAU-253" +
            "3)")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void SignUpFor14DayFreeTrialWithoutAnExistingBrotherOnlineAccountBBAU_2533()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign Up for 14 day Free trial without an existing Brother Online account(BBAU-253" +
                    "3)", new string[] {
                        "SMOKE"});
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
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I have Agreed to the Free Trial Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("if I click Submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.Then("I should be directed to the download page indicating I have 14 days Free trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.Then("If I go back to Brother Online Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
 testRunner.And("Once I have Validated a Free Trial confirmation Email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when an invalid email is entered" +
            " (BBAU-2721)")]
        [NUnit.Framework.CategoryAttribute("PROD")]
        [NUnit.Framework.CategoryAttribute("UAT")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("DEV")]
        [NUnit.Framework.TestCaseAttribute("\"InvalidEmailContaining aspace@mailinator.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"InvalidEmailForUser@mailinator\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"InvalidEmailForUser\"", null)]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenAnInvalidEmailIsEnteredBBAU_2721(string invalidEmailAddress, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "PROD",
                    "UAT",
                    "TEST",
                    "DEV"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when an invalid email is entered" +
                    " (BBAU-2721)", @__tags);
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
 testRunner.Then(string.Format("I enter an invalid email address as {0} for omnijoin free trial", invalidEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
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
#line 85
this.ScenarioSetup(scenarioInfo);
#line 86
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
 testRunner.When("I have entered a valid First and Last name, \"$%&£^GRYIR&^T*$UOITUJO$J\", \"*$%*\"^%*" +
                    "\"£^%(*$^GHWGKD\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.Then("I should see an error message on the first name and last name field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when Terms and Conditions are no" +
            "t checked on Commit")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("UAT")]
        [NUnit.Framework.CategoryAttribute("PROD")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenTermsAndConditionsAreNotCheckedOnCommit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when Terms and Conditions are no" +
                    "t checked on Commit", new string[] {
                        "TEST",
                        "UAT",
                        "PROD"});
#line 93
this.ScenarioSetup(scenarioInfo);
#line 94
 testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I enter a Free Trial Password of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("I click Submit without ticking the terms and conditions field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.Then("I should see an error message on Terms and Conditions field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when Passwords do not match")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("UAT")]
        [NUnit.Framework.CategoryAttribute("PROD")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenPasswordsDoNotMatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when Passwords do not match", new string[] {
                        "TEST",
                        "UAT",
                        "PROD"});
#line 108
this.ScenarioSetup(scenarioInfo);
#line 109
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 110
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 112
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("I enter a Free Trial Password of \"Abcd1234\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1235\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.And("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And("I have Agreed to the Free Trial Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.Then("I should see an error message on Password Confirmation field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate Free Trial form displays error messages when an invalid Password is ente" +
            "red")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("UAT")]
        [NUnit.Framework.CategoryAttribute("PROD")]
        public virtual void ValidateFreeTrialFormDisplaysErrorMessagesWhenAnInvalidPasswordIsEntered()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Free Trial form displays error messages when an invalid Password is ente" +
                    "red", new string[] {
                        "TEST",
                        "UAT",
                        "PROD"});
#line 121
this.ScenarioSetup(scenarioInfo);
#line 122
testRunner.Given("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 123
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
 testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
 testRunner.And("I have entered a Free Trial AutoGenerated email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And("I enter a Free Trial Password of \"Abcd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And("I enter a Free Trial Password confirmation of \"Abcd1235\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
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
#line 133
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
#line 136
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
#line 139
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
#line 142
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
