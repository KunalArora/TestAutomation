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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwo.Proposal
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("LocalOfficeAdminCanManageBanks")]
    [NUnit.Framework.IgnoreAttribute()]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class LocalOfficeAdminCanManageBanksFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LocalOfficeAdminCanManageBanks.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "LocalOfficeAdminCanManageBanks", "In order to manage leasing banks\r\nAs a Local Office Administartor\r\nI want to be a" +
                    "ble to add/edit leasing bank parameters", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "TEST",
                        "UAT",
                        "ignore"});
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
        [NUnit.Framework.DescriptionAttribute("Local Office Admin Can Sell PriceVsSRPConstraint")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", null)]
        public virtual void LocalOfficeAdminCanSellPriceVsSRPConstraint(string role, string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Local Office Admin Can Sell PriceVsSRPConstraint", @__tags);
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("I navigate to admin Lease And Click page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.And("I navigate to Leasing Bank screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Then("I can edit the Sell Price vs SRP Constraint % for an existing Leasing bank", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Local Office Admin Can Set Default Dealer Margin")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Hardware", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Delivery", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Accessories", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Installation", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Service Pack", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Mono Click", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Colour Click", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "All Inclusive", null)]
        public virtual void LocalOfficeAdminCanSetDefaultDealerMargin(string role, string country, string marginType, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Local Office Admin Can Set Default Dealer Margin", @__tags);
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given(string.Format("I sign into MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.When("I navigate to Dealer Defaults page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then(string.Format("I can set one-off dealer \"{0}\" margin", marginType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Local Office Admin should switch on/off type for Leasing and EPP")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Lease and Click", "Minimum Volume", "Off", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Lease and Click", "Pay As You Go", "Off", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Lease and Click", "Minimum Volume", "On", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Lease and Click", "Pay As You Go", "On", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Purchase and Click", "Minimum Volume", "Off", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Purchase and Click", "Pay As You Go", "Off", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Purchase and Click", "Minimum Volume", "On", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "Purchase and Click", "Pay As You Go", "On", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "All In Click", "Minimum Volume", "Off", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office", "United Kingdom", "All In Click", "Minimum Volume", "On", null)]
        public virtual void LocalOfficeAdminShouldSwitchOnOffTypeForLeasingAndEPP(string role, string country, string page, string usageType, string state, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Local Office Admin should switch on/off type for Leasing and EPP", @__tags);
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given(string.Format("I sign into MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.When(string.Format("I navigate to Program Setting page of \"{0}\" page", page), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then(string.Format("I can switch \"{0}\" \"{1}\" Usage Type", state, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
