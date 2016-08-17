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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC112.BND.Contract
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSDannishDealerCanCopyADeclineProposal")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class CloudMPSDannishDealerCanCopyADeclineProposalFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSDealerCanCopyADeclineProposal.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSDannishDealerCanCopyADeclineProposal", "In order to resubmit a declined proposal\r\nAs a dealer \r\nI want to be to copy and " +
                    "submit a declined proposal", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "TEST",
                        "UAT"});
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
        [NUnit.Framework.DescriptionAttribute("MPS Danish Dealer Can Copy A Declined Purchase and Click Proposal without custome" +
            "r detail for other countries")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Denmark", "Cloud MPS Local Office Approver", "Køb & Klik med service", "Minimumsvolumen", "3 år", "Quarterly in Arrears", null)]
        public virtual void MPSDanishDealerCanCopyADeclinedPurchaseAndClickProposalWithoutCustomerDetailForOtherCountries(string role, string country, string role2, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Danish Dealer Can Copy A Declined Purchase and Click Proposal without custome" +
                    "r detail for other countries", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("I verify and store \"{0}\" purchase and click proposal bypass status", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.Then(string.Format("I can copy the declined \"{0}\" proposal with \"{1}\" and \"{2}\" and \"{3}\" as a \"{4}\" " +
                        "from \"{5}\" and approved by \"{6}\"", contractType, usageType, length, billing, role, country, role2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Danish Dealer Can Copy A Declined Purchase and Click Proposal with customer d" +
            "etail for other countries")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Denmark", "Cloud MPS Local Office Approver", "Køb & Klik med service", "Minimumsvolumen", "3 år", "Quarterly in Arrears", null)]
        public virtual void MPSDanishDealerCanCopyADeclinedPurchaseAndClickProposalWithCustomerDetailForOtherCountries(string role, string country, string role2, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Danish Dealer Can Copy A Declined Purchase and Click Proposal with customer d" +
                    "etail for other countries", exampleTags);
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given(string.Format("I verify and store \"{0}\" purchase and click proposal bypass status", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.Then(string.Format("I can copy the customer detail with the declined \"{0}\" proposal with \"{1}\" and \"{" +
                        "2}\" and \"{3}\" as a \"{4}\" from \"{5}\" and approved by \"{6}\"", contractType, usageType, length, billing, role, country, role2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
