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
namespace Brother.Tests.Specs.TestSpecifications.MPS2.Admin
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Type1LocalOfficeAdminCapabilities")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("TYPE1")]
    [NUnit.Framework.CategoryAttribute("LOW")]
    [NUnit.Framework.CategoryAttribute("ADMIN")]
    [NUnit.Framework.CategoryAttribute("CI_TestMaintenance")]
    public partial class Type1LocalOfficeAdminCapabilitiesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LocalOfficeAdminCapabilities.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Type1LocalOfficeAdminCapabilities", "\tIn order to test the Cloud MPS local office Admin capabilities\r\n\tVerify the diff" +
                    "erent options of local office admin", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TEST",
                        "TYPE1",
                        "LOW",
                        "ADMIN",
                        "CI_TestMaintenance"});
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
        [NUnit.Framework.DescriptionAttribute("Type1LocalOfficeAdminCapabilities")]
        [NUnit.Framework.TestCaseAttribute("Poland", "pl-PL", "LEASE_AND_CLICK", "MONTHLY", "MINIMUM_VOLUME", "RECURRING", new string[] {
                "BPL"}, Category="BPL")]
        public virtual void Type1LocalOfficeAdminCapabilities(string country, string culture, string contractType, string billingType, string billingUsageType, string billingPaymentType, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Type1LocalOfficeAdminCapabilities", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given(string.Format("I have navigated to the dashboard page as a Cloud MPS Local office admin with cul" +
                        "ture \"{0}\" from \"{1}\"", culture, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I navigate to the lease and click program settings page and enable the program", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.And(string.Format("a Cloud MPS Dealer navigated to the create proposal page with culture \"{0}\" from " +
                        "\"{1}\"", culture, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
testRunner.Then(string.Format("a Cloud MPS Dealer can verify the program \"{0}\" is being displayed as contract ty" +
                        "pe", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.And("I disable the program that was previously enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.When("I navigate to the purchase and click program settings page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.And(string.Format("I create a billing cycle with billing type as \"{0}\", billing usage type as \"{1}\" " +
                        "and billing payment type as \"{2}\"", billingType, billingUsageType, billingPaymentType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And(string.Format("a Cloud MPS Dealer navigated to the create proposal page with culture \"{0}\" from " +
                        "\"{1}\"", culture, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.Then(string.Format("a Cloud MPS Dealer can skip customer creation and verify the billing type as \"{0}" +
                        "\" is being displayed", billingType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.And(string.Format("I delete the newly created billing type as \"{0}\", billing usage type as \"{1}\" and" +
                        " billing payment type as \"{2}\"", billingType, billingUsageType, billingPaymentType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
