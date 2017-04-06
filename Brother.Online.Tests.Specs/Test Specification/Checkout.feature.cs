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
namespace Brother.Online.Tests.Specs.TestSpecification
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("As a user I want to create an order on BOL Site and")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class AsAUserIWantToCreateAnOrderOnBOLSiteAndFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Checkout.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "As a user I want to create an order on BOL Site and", "able to checkout with the existing or guest user", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Customer creates an order and checkout as existing user on UK BOL site")]
        [NUnit.Framework.CategoryAttribute("SMOKE_Checkout")]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherdv2.eu/supplies/inkjet-supplies/lc1000bk", "http://atyourside.co.uk.brotherdv2.eu/qa/03-checkout/415existinguserdetailssectio" +
            "n", "testdv2uk@guerrillamail.com", "Brother123", "01234567890", "01234567890", "4259917979151326", "07", "2019", null)]
        public virtual void CustomerCreatesAnOrderAndCheckoutAsExistingUserOnUKBOLSite(string siteUrl, string url, string email, string password, string phoneNumber, string mobileNumber, string creditCardNumber, string month, string year, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE_Checkout"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customer creates an order and checkout as existing user on UK BOL site", @__tags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
    testRunner.Given(string.Format("That I navigate to \"{0}\" in order to add a product to validate a published page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("I click on Add to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And(string.Format("I browse to the \"{0}\" BOL checkout page", url), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I click on the login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And(string.Format("I enter the registered \"{0}\" in the Email field", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And(string.Format("I enter the registered \"{0}\" in the Password field", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("I click on Existing User SiginIn Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("I enter \"{0}\" and \"{1}\" on your details page", phoneNumber, mobileNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I click on Continue to Delivery Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I click on Continue to Billing & Payment Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I click on Continue to Payment Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When(string.Format("I fill in creditCard details \"{0}\"", creditCardNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.And(string.Format("I select a month as \"{0}\"", month), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And(string.Format("I select a year as \"{0}\"", year), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I fill in security number as  \"123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I click the Confirm My Payment button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.Then("I should see the order confirmation message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
