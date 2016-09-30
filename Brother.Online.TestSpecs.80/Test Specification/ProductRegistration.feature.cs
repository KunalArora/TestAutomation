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
    [NUnit.Framework.DescriptionAttribute("ProductRegistration")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class ProductRegistrationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ProductRegistration.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ProductRegistration", "In order to register a product\r\nEnd user will login to existing account or create" +
                    " a new account", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Verify the Header and Footer of the landing page")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", null)]
        public virtual void VerifyTheHeaderAndFooterOfTheLandingPage(string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST",
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Header and Footer of the landing page", @__tags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
testRunner.Then("I should see the Header and the Footer appearing on the landing Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer wants to register product with their serial numbers and promo code")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/QA/AutomationPleaseDoNotTouch/ProductRegStep-one", "U1T004747", null)]
        public virtual void CustomerWantsToRegisterProductWithTheirSerialNumbersAndPromoCode(string country, string siteUrl, string serialNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST",
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer wants to register product with their serial numbers and promo code", @__tags);
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.And(string.Format("I browse to the \"{0}\" product registration page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("clicked on Find Product Butoon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer has the option to change their sign in preferences to social login")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", null)]
        public virtual void CustomerHasTheOptionToChangeTheirSignInPreferencesToSocialLogin(string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer has the option to change their sign in preferences to social login", @__tags);
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
testRunner.Given(string.Format("I want to create a new account with Brother Online \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
testRunner.When(string.Format("I click on Create Account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.And(string.Format("I am redirected to the Brother Login/Register page \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
testRunner.And(string.Format("I have Checked No I Do Not Have An Account Checkbox \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
#line 43
testRunner.And(string.Format("I fill in the registration information using a valid email address \"{0}\"", country), ((string)(null)), table1, "And ");
#line 51
testRunner.And(string.Format("I have Agreed to the Terms and Conditions \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
testRunner.And(string.Format("I declare that I do not use this account for business \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.When(string.Format("I press Create Your Account \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.Then(string.Format("I should see my account confirmation page \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
testRunner.And(string.Format("When I Click Go Back \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
testRunner.Then(string.Format("I should be able to log into \"{0}\" Brother Online using my account details", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
testRunner.When(string.Format("I navigate to my account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
testRunner.And(string.Format("I click on Sign In Details \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
testRunner.When(string.Format("I click on Social Login Radio button \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.Then(string.Format("I should be able to see social login buttons \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
testRunner.And(string.Format("I can navigate back to Brother Online home page \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.And(string.Format("I can sign out of Brother Online \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
