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
    [NUnit.Framework.DescriptionAttribute("CreateNewAccount")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class CreateNewAccountFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NewAccount.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CreateNewAccount", "In order to register myself with brother\r\nAs a customer\r\nI need to create a new o" +
                    "nline account", ProgrammingLanguage.CSharp, new string[] {
                        "PROD",
                        "UAT",
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
        [NUnit.Framework.DescriptionAttribute("Customer creates a new Business account with Brother Online using valid credentia" +
            "ls (NO VAT NUMBER), confirm by email")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void CustomerCreatesANewBusinessAccountWithBrotherOnlineUsingValidCredentialsNOVATNUMBERConfirmByEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer creates a new Business account with Brother Online using valid credentia" +
                    "ls (NO VAT NUMBER), confirm by email", new string[] {
                        "SMOKE"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
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
#line 16
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table1, "And ");
#line 23
 testRunner.And("I add my company name as \"AutoTestLtd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I select my Business Sector as \"IT and telecommunications services\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I select number of Employees as \"11 - 50\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("Once I have Validated an Email was received and verified my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer creates a new account with Brother Online using valid credentials, confi" +
            "rm by email")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void CustomerCreatesANewAccountWithBrotherOnlineUsingValidCredentialsConfirmByEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer creates a new account with Brother Online using valid credentials, confi" +
                    "rm by email", new string[] {
                        "SMOKE"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
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
#line 43
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table2, "And ");
#line 50
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("Once I have Validated an Email was received and verified my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer cannot register for a Brother Online account using an invalid email addr" +
            "ess (BOL-180)")]
        [NUnit.Framework.TestCaseAttribute("\"This is a space@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUsePercent%@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUseCurlyBraces{}@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUsePlus+@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUseDollar$@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUsePound£@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUseQuotes\"@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUseAsterix*@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUseTwoAmpersands@@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUseQuestionMark?@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUseOpenBrace(@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"CannotUseEquals=@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\" LeadingSpace@guerrillamail.com\"", null)]
        [NUnit.Framework.TestCaseAttribute("\"TrailingSpace@guerrillamail.com \"", null)]
        public virtual void CustomerCannotRegisterForABrotherOnlineAccountUsingAnInvalidEmailAddressBOL_180(string emailAddress, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer cannot register for a Brother Online account using an invalid email addr" +
                    "ess (BOL-180)", exampleTags);
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.When(string.Format("I enter an email address containing {0}", emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.Then("I should see an error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
 testRunner.Then("I should refresh the current page to clear all error messages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create an account for Brother Online for different language sites")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("France", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", null)]
        [NUnit.Framework.TestCaseAttribute("Poland", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", null)]
        public virtual void CreateAnAccountForBrotherOnlineForDifferentLanguageSites(string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create an account for Brother Online for different language sites", @__tags);
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
 testRunner.Given(string.Format("I Need A Brother Online \"{0}\" Account In Order To Use Brother Online Services", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer creates a new account with Brother Online using valid credentials, and v" +
            "alidates the user is validated so it can create a device registration but not ac" +
            "tually register")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void CustomerCreatesANewAccountWithBrotherOnlineUsingValidCredentialsAndValidatesTheUserIsValidatedSoItCanCreateADeviceRegistrationButNotActuallyRegister()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer creates a new account with Brother Online using valid credentials, and v" +
                    "alidates the user is validated so it can create a device registration but not ac" +
                    "tually register", new string[] {
                        "SMOKE"});
#line 101
this.ScenarioSetup(scenarioInfo);
#line 102
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 103
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
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
#line 106
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table3, "And ");
#line 113
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And("Once I have Validated an Email was received and verified my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
 testRunner.When("I have clicked on Add Device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
 testRunner.And("I am redirected to the Register Device page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.Given("I have entered my Product Serial Code \"U1T000000\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 124
 testRunner.Then("I can validate that an error message was displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Business customer creates a new account with Brother Online using valid credentia" +
            "ls, and validates the user is validated so it can create a device registration b" +
            "ut not actually register")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void BusinessCustomerCreatesANewAccountWithBrotherOnlineUsingValidCredentialsAndValidatesTheUserIsValidatedSoItCanCreateADeviceRegistrationButNotActuallyRegister()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Business customer creates a new account with Brother Online using valid credentia" +
                    "ls, and validates the user is validated so it can create a device registration b" +
                    "ut not actually register", new string[] {
                        "SMOKE"});
#line 130
this.ScenarioSetup(scenarioInfo);
#line 131
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 132
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table4.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table4.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table4.AddRow(new string[] {
                        "Password",
                        "@@@@@"});
            table4.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 135
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table4, "And ");
#line 142
 testRunner.And("I declare that I do use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
 testRunner.And("I add my company name as \"AutoTestLtd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
 testRunner.And("I select my Business Sector as \"IT and telecommunications services\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
 testRunner.And("I select number of Employees as \"11 - 50\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
 testRunner.When("I add my company VAT number as \"GB145937540\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 147
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 149
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 150
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
 testRunner.And("Once I have Validated an Email was received and verified my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 153
 testRunner.When("I have clicked on Add Device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
 testRunner.And("I am redirected to the Register Device page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
 testRunner.Given("I have entered my Product Serial Code \"U1T000000\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 157
 testRunner.Then("I can validate that an error message was displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 158
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 159
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate that the correct error messages are displayed when a mandatory field Ema" +
            "il is missing while creating a User Account")]
        public virtual void ValidateThatTheCorrectErrorMessagesAreDisplayedWhenAMandatoryFieldEmailIsMissingWhileCreatingAUserAccount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate that the correct error messages are displayed when a mandatory field Ema" +
                    "il is missing while creating a User Account", ((string[])(null)));
#line 162
this.ScenarioSetup(scenarioInfo);
#line 163
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 164
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 165
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
 testRunner.When("I press tab in the email address field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 168
 testRunner.Then("I should see an error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate that the correct error messages are displayed when a mandatory field Pas" +
            "sword is missing while creating a User Account")]
        [NUnit.Framework.TestCaseAttribute("\"aaa@yahoo.com\"", null)]
        public virtual void ValidateThatTheCorrectErrorMessagesAreDisplayedWhenAMandatoryFieldPasswordIsMissingWhileCreatingAUserAccount(string emailAddress, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate that the correct error messages are displayed when a mandatory field Pas" +
                    "sword is missing while creating a User Account", exampleTags);
#line 171
this.ScenarioSetup(scenarioInfo);
#line 172
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 173
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.And(string.Format("I enter an email address containing {0}", emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
 testRunner.When("I press tab in the password field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 178
 testRunner.Then("I should see an error message on the password field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate that the correct error messages are displayed when a Confirm Password fi" +
            "eld contains different passwpord than actual Password (BBAU-2209)")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("\"aaa@yahoo.com\"", "\"Astwer1234\"", "\"aaaahewllo\"", null)]
        public virtual void ValidateThatTheCorrectErrorMessagesAreDisplayedWhenAConfirmPasswordFieldContainsDifferentPasswpordThanActualPasswordBBAU_2209(string emailAddress, string password, string confirmPassword, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate that the correct error messages are displayed when a Confirm Password fi" +
                    "eld contains different passwpord than actual Password (BBAU-2209)", @__tags);
#line 184
 this.ScenarioSetup(scenarioInfo);
#line 185
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 186
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 187
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 188
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
 testRunner.And(string.Format("I enter an email address containing {0}", emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
 testRunner.And(string.Format("I enter the password containing {0}", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
 testRunner.When(string.Format("I enter the different password in the confirm password field containing {0} and p" +
                        "ress tab", confirmPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 192
 testRunner.Then("I should see an error message on the Confirm password field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate that the correct error messages are displayed when a password does not c" +
            "omply the required level")]
        [NUnit.Framework.TestCaseAttribute("\"aaa@yahoo.com\"", "\"stwer\"", null)]
        public virtual void ValidateThatTheCorrectErrorMessagesAreDisplayedWhenAPasswordDoesNotComplyTheRequiredLevel(string emailAddress, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate that the correct error messages are displayed when a password does not c" +
                    "omply the required level", exampleTags);
#line 198
this.ScenarioSetup(scenarioInfo);
#line 199
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 200
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 201
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
 testRunner.And(string.Format("I enter an email address containing {0}", emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 204
 testRunner.When(string.Format("I enter the password containing {0}", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 205
 testRunner.Then("I should see an error message on the password field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate that the correct error messages are displayed when Terms and Conditions " +
            "are not selected")]
        public virtual void ValidateThatTheCorrectErrorMessagesAreDisplayedWhenTermsAndConditionsAreNotSelected()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate that the correct error messages are displayed when Terms and Conditions " +
                    "are not selected", ((string[])(null)));
#line 211
this.ScenarioSetup(scenarioInfo);
#line 212
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 213
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 214
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table5.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table5.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table5.AddRow(new string[] {
                        "Password",
                        "@@@@@"});
            table5.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 216
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table5, "And ");
#line 223
 testRunner.When("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 224
 testRunner.And("I press create account button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 225
 testRunner.Then("I should get an error message displayed on the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
