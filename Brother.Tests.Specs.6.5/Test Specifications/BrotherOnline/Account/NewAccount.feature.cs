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
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("Romania", null)]
        public virtual void CreateAnAccountForBrotherOnlineForDifferentLanguageSites(string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE",
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create an account for Brother Online for different language sites", @__tags);
#line 90
this.ScenarioSetup(scenarioInfo);
#line 91
 testRunner.Given(string.Format("I Need A Brother Online \"{0}\" Account In Order To Use Brother Online Services", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.When("I have clicked on Add Device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
 testRunner.And("I am redirected to the Register Device page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.Given("I have entered my Product Serial Code \"U1T000000\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
 testRunner.Then("I can validate that an error message was displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 98
 testRunner.Then("I am redirected to the Brother Home Page", @"	| Germany        |
	| Netherlands    |
	| Spain          |
	| Denmark        |
	| Belgium        |
	| Russia         |- Red warning on page - look into
	| Hungary        |- unknown error - possibly cannot get to site 
	| Portugal       |
	| Switzerland    | - need to add specific default language to URL
	| Slovakia       | - Links for validation set of for UK so needs updating
	| Slovenia       | - Links for validation set of for UK so needs updating
	| Czech          | - Links for validation set of for UK so needs updating
	| Bulgaria       | - Links for validation set of for UK so needs updating - maybe no version in SiteCore on DV2
	| Finland        |
	| Norway         | - Link for validation of registration links to something completely different
	| Italy          | - NEEDS to have Número de identificación fiscal added to test otherwise registration fails
	| Austria        |", ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 125
this.ScenarioSetup(scenarioInfo);
#line 126
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 127
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
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
#line 130
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table3, "And ");
#line 137
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 140
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
 testRunner.And("Once I have Validated an Email was received and verified my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
 testRunner.When("I have clicked on Add Device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
 testRunner.And("I am redirected to the Register Device page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.Given("I have entered my Product Serial Code \"U1T000000\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 148
 testRunner.Then("I can validate that an error message was displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 150
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
#line 154
this.ScenarioSetup(scenarioInfo);
#line 155
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 156
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 157
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
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
#line 159
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table4, "And ");
#line 166
 testRunner.And("I declare that I do use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
 testRunner.And("I add my company name as \"AutoTestLtd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
 testRunner.And("I select my Business Sector as \"IT and telecommunications services\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
 testRunner.And("I select number of Employees as \"11 - 50\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
 testRunner.When("I add my company VAT number as \"GB145937540\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 171
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 173
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 174
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
 testRunner.And("Once I have Validated an Email was received and verified my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 177
 testRunner.When("I have clicked on Add Device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 178
 testRunner.And("I am redirected to the Register Device page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.Given("I have entered my Product Serial Code \"U1T000000\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 181
 testRunner.Then("I can validate that an error message was displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 182
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 183
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
#line 186
this.ScenarioSetup(scenarioInfo);
#line 187
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 188
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 189
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
 testRunner.When("I press tab in the email address field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 192
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
#line 195
this.ScenarioSetup(scenarioInfo);
#line 196
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 197
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 198
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 200
 testRunner.And(string.Format("I enter an email address containing {0}", emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 201
 testRunner.When("I press tab in the password field", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 202
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
#line 208
 this.ScenarioSetup(scenarioInfo);
#line 209
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 210
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 211
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 212
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 213
 testRunner.And(string.Format("I enter an email address containing {0}", emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 214
 testRunner.And(string.Format("I enter the password containing {0}", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
 testRunner.When(string.Format("I enter the different password in the confirm password field containing {0} and p" +
                        "ress tab", confirmPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 216
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
#line 222
this.ScenarioSetup(scenarioInfo);
#line 223
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 224
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 225
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 226
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 227
 testRunner.And(string.Format("I enter an email address containing {0}", emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 228
 testRunner.When(string.Format("I enter the password containing {0}", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 229
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
#line 235
this.ScenarioSetup(scenarioInfo);
#line 236
 testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 237
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 238
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 239
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
#line 240
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table5, "And ");
#line 247
 testRunner.When("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 248
 testRunner.And("I press create account button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 249
 testRunner.Then("I should get an error message displayed on the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Log in as a Printer On dealer and ensure that they can see the required permissio" +
            "ns BBAU-2189")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void LogInAsAPrinterOnDealerAndEnsureThatTheyCanSeeTheRequiredPermissionsBBAU_2189()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Log in as a Printer On dealer and ensure that they can see the required permissio" +
                    "ns BBAU-2189", new string[] {
                        "ignore"});
#line 252
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
