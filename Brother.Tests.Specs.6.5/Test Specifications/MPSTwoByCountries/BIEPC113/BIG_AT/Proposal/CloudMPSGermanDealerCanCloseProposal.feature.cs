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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC113.BIG_AT.Proposal
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSDealerFromGermanyCanCloseProposal")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("BIEPC113")]
    public partial class CloudMPSDealerFromGermanyCanCloseProposalFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSGermanDealerCanCloseProposal.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSDealerFromGermanyCanCloseProposal", "In order to discontinue a proposal from creation process\r\nAs a dealer\r\nI want to " +
                    "be able to cancel proposal before it gets to contract stage", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TEST",
                        "BIEPC113"});
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
        [NUnit.Framework.DescriptionAttribute("MPS Cancel Leasing Open Proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Austria", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", null)]
        public virtual void MPSCancelLeasingOpenProposal(string role, string country, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Cancel Leasing Open Proposal", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I have created German Leasing and Click proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I am on Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("I can click edit button on proposal item of Exisiting Proposal table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.And("I go to \"Summary\" Tab in Proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("I can close the proposal on the summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And("the closed proposal summary page has no error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Cancel Purchase Open Proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Austria", null)]
        public virtual void MPSCancelPurchaseOpenProposal(string role, string country, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Cancel Purchase Open Proposal", exampleTags);
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("I have created German Purchase and Click proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I am on Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I can click edit button on proposal item of Exisiting Proposal table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.And("I go to \"Summary\" Tab in Proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.Then("I can close the proposal on the summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.And("the closed proposal summary page has no error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Cancel Leasing Awaiting Approval Proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Austria", null)]
        public virtual void MPSCancelLeasingAwaitingApprovalProposal(string role, string country, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Cancel Leasing Awaiting Approval Proposal", exampleTags);
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given(string.Format("I verify and store \"{0}\" Lease and click proposal bypass status", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.Then(string.Format("I can close an awaiting proposal without error on summary page as \"{0}\" \"{1}\"", country, role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Cancel Purchase Awaiting Approval Proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Austria", null)]
        public virtual void MPSCancelPurchaseAwaitingApprovalProposal(string role, string country, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Cancel Purchase Awaiting Approval Proposal", exampleTags);
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given(string.Format("I verify and store \"{0}\" purchase and click proposal bypass status", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.Then(string.Format("I can close a purchase and click awaiting proposal without error on summary page " +
                        "as \"{0}\" \"{1}\"", country, role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Cancel Leasing Approved Proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", "Cloud MPS Bank", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Austria", "Cloud MPS Bank", null)]
        public virtual void MPSCancelLeasingApprovedProposal(string role, string country, string role2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Cancel Leasing Approved Proposal", exampleTags);
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
 testRunner.Given(string.Format("I verify and store \"{0}\" Lease and click proposal bypass status", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 68
 testRunner.And("I have created German Leasing and Click proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("I am on Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I send the created German proposal for approval", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And(string.Format("I approve Leasing and Click proposal as a \"{0}\" from \"{1}\"", role2, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.When("I navigate to dealer approved proposal page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.And("I identify and navigate to the approved proposal summary", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.Then("I can close the proposal on the summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
 testRunner.And("the closed proposal summary page has no error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Cancel Purchase Approved Proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", "Cloud MPS Local Office Approver", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Austria", "Cloud MPS Local Office Approver", null)]
        public virtual void MPSCancelPurchaseApprovedProposal(string role, string country, string role2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Cancel Purchase Approved Proposal", exampleTags);
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
 testRunner.Given(string.Format("I verify and store \"{0}\" purchase and click proposal bypass status", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.And("I have created German Purchase and Click proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("I am on Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("I send the created German proposal for approval", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And(string.Format("I approve purchase and click proposal as a \"{0}\" from \"{1}\"", role2, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.When("I navigate to dealer approved proposal page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
 testRunner.And("I identify and navigate to the approved proposal summary", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.Then("I can close the proposal on the summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
 testRunner.And("the closed proposal summary page has no error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
