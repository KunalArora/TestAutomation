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
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "http://atyourside.co.uk.brotherdv2.eu/", null)]
        public virtual void VerifyTheHeaderAndFooterOfTheLandingPage(string country, string siteUrl, string[] exampleTags)
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
#line 8
testRunner.Given(string.Format("I navigate to \"{0}\" in order to validate the landing page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.Then("I should see the Header and the Footer appearing on the landing Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Customer wants to register product with their serial numbers and promo code")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "http://atyourside.co.uk.brotherdv2.eu/QA/AutomationPleaseDoNotTouch/Step-one", "U1T004747", null)]
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
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given(string.Format("I navigate to \"{0}\" in order to validate the landing page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("clicked on Find Product Butoon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
