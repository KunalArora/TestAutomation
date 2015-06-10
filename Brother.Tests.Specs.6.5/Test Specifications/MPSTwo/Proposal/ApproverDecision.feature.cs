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
    [NUnit.Framework.DescriptionAttribute("Approver decision feture")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class ApproverDecisionFetureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ApproverDecision.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Approver decision feture", "In order to approve/decline Proposal/Contract\r\nAs a Approver\r\nI want to decide ab" +
                    "out Proposal/Contract", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Bank Decline Proposal")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "United Kingdom", "TEST 23", null)]
        public virtual void BankDeclineProposal(string role, string country, string name, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bank Decline Proposal", @__tags);
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.And("I navigate to OfferPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I navigate to Awaiting Approval screen under Offer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When(string.Format("I select a proposal from \"{0}\" of Proposal", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("I should be able to decline that proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And("the decline proposal should be displayed under Declined tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("LO Approver Decline Proposal")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "United Kingdom", "TEST 23", null)]
        public virtual void LOApproverDeclineProposal(string role, string country, string name, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("LO Approver Decline Proposal", @__tags);
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.And("I navigate to OfferPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I navigate to Awaiting Approval screen under Offer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.When(string.Format("I select a proposal from \"{0}\" of Proposal", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("I should be able to decline that proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.And("the decline proposal should be displayed under Declined tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Declined proposal is displayed on Declined Page")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", null)]
        public virtual void DeclinedProposalIsDisplayedOnDeclinedPage(string role, string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Declined proposal is displayed on Declined Page", @__tags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.And("I navigate to OfferPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.When("I navigate to Declined screen under Offer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Bank Approve Proposal")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "United Kingdom", "MPS_Ross-2015069074732", null)]
        public virtual void BankApproveProposal(string role, string country, string name, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bank Approve Proposal", @__tags);
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
 testRunner.And("I navigate to OfferPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("I navigate to Awaiting Approval screen under Offer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.When(string.Format("I select a proposal from \"{0}\" of Proposal", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.Then("I should be able to approve that proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Bank can decide to reject or approve the contract")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "United Kingdom", null)]
        public virtual void BankCanDecideToRejectOrApproveTheContract(string role, string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bank can decide to reject or approve the contract", @__tags);
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
 testRunner.Given("Dealer have created Leasing and Click contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.When("I navigate to Contract Awaiting Acceptance page from Bank DashBoard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.Then("I can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.And("I can either reject or approve the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Bank can approve the contract")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "United Kingdom", null)]
        public virtual void BankCanApproveTheContract(string role, string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bank can approve the contract", @__tags);
#line 94
this.ScenarioSetup(scenarioInfo);
#line 95
 testRunner.Given("Dealer have created Leasing and Click contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.When("I navigate to Contract Awaiting Acceptance page from Bank DashBoard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
 testRunner.Then("I can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
 testRunner.And("I can successfully approve the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("the accepted contract is displayed on contract Accepted screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Bank can reject the contract")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "United Kingdom", null)]
        public virtual void BankCanRejectTheContract(string role, string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Bank can reject the contract", @__tags);
#line 114
this.ScenarioSetup(scenarioInfo);
#line 115
 testRunner.Given("Dealer have created Leasing and Click contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 116
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.When("I navigate to Contract Awaiting Acceptance page from Bank DashBoard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
 testRunner.Then("I can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
 testRunner.And("I can successfully reject the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And("the rejected contract is displayed on contract Rejected screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer can resign rejected contract")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", null)]
        public virtual void DealerCanResignRejectedContract(string role, string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can resign rejected contract", @__tags);
#line 133
this.ScenarioSetup(scenarioInfo);
#line 134
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 135
 testRunner.When("I navigate to Rejected screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
 testRunner.Then("I can successfully re-sign the rejected contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
