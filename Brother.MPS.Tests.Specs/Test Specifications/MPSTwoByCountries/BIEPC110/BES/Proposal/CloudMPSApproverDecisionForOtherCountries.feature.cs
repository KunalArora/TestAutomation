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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC110.BES.Proposal
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSSpanishApproverDecisionFeature")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("BIEPC110")]
    [NUnit.Framework.CategoryAttribute("MEDIUM")]
    public partial class CloudMPSSpanishApproverDecisionFeatureFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSApproverDecisionForOtherCountries.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSSpanishApproverDecisionFeature", "\tIn order to approve/decline Proposal/Contract\r\n\tAs a Approver\r\n\tI want to decide" +
                    " about Proposal/Contract", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "TEST",
                        "UAT",
                        "BIEPC110",
                        "MEDIUM"});
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
        [NUnit.Framework.DescriptionAttribute("MPS LO Decline Proposal")]
        [NUnit.Framework.TestCaseAttribute("Spain", "Cloud MPS Local Office Approver", "Purchase & Click con Service", "Volúmen mínimo", "3 años", "Por trimestres vencidos", null)]
        public virtual void MPSLODeclineProposal(string country, string role, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS LO Decline Proposal", exampleTags);
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given(string.Format("I verify and store \"{0}\" purchase and click proposal bypass status", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.Then(string.Format("\"{0}\" can decline Awaiting Approval \"{1}\" \"{2}\" proposal with \"{3}\" and \"{4}\" and" +
                        " \"{5}\"", role, country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS LO Can Reject Or Accept")]
        [NUnit.Framework.TestCaseAttribute("Spain", "Cloud MPS Local Office Approver", "Purchase & Click con Service", "Volúmen mínimo", "3 años", "Por trimestres vencidos", null)]
        public virtual void MPSLOCanRejectOrAccept(string country, string role, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS LO Can Reject Or Accept", exampleTags);
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("Approver navigate to Contract Awaiting Acceptance page from Dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("Approver can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("Approver can either reject or approve the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS LO Approve Contract")]
        [NUnit.Framework.TestCaseAttribute("Spain", "Cloud MPS Local Office Approver", "Purchase & Click con Service", "Volúmen mínimo", "3 años", "Por trimestres vencidos", null)]
        public virtual void MPSLOApproveContract(string country, string role, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS LO Approve Contract", exampleTags);
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.When("Approver navigate to Contract Awaiting Acceptance page from Dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("Approver can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.And("Approver can successfully approve the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("the accepted contract by Approver is displayed on contract Accepted screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS LO Reject Contract")]
        [NUnit.Framework.TestCaseAttribute("Spain", "Cloud MPS Local Office Approver", "Purchase & Click con Service", "Volúmen mínimo", "3 años", "Por trimestres vencidos", null)]
        public virtual void MPSLORejectContract(string country, string role, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS LO Reject Contract", exampleTags);
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.When("Approver navigate to Contract Awaiting Acceptance page from Dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.Then("Approver can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.And("Approver can successfully reject the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("the rejected contract by Approver is displayed on contract Rejected screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Resign Rejected Contract")]
        [NUnit.Framework.TestCaseAttribute("Spain", "Cloud MPS Local Office Approver", "Purchase & Click con Service", "Volúmen mínimo", "3 años", "Por trimestres vencidos", "Cloud MPS Dealer", null)]
        public virtual void MPSResignRejectedContract(string country, string role, string contractType, string usageType, string length, string billing, string role2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Resign Rejected Contract", exampleTags);
#line 70
this.ScenarioSetup(scenarioInfo);
#line 71
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.When("Approver navigate to Contract Awaiting Acceptance page from Dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.Then("Approver can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
 testRunner.And("Approver can successfully reject the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("the rejected contract by Approver is displayed on contract Rejected screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role2, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
 testRunner.When("I navigate to Rejected screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.Then("I can successfully re-sign the rejected contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS LO View Opened Offers")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", null)]
        public virtual void MPSLOViewOpenedOffers(string role, string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS LO View Opened Offers", @__tags);
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
 testRunner.When("I navigate to ProposalPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.And("I navigate to Awaiting Approval screen under Proposals page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.Then("I should see a list of Proposals on Awaiting Approval Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS LO View Contracts")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Awating Acceptance", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Rejected", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Accepted", null)]
        public virtual void MPSLOViewContracts(string role, string country, string acceptance, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS LO View Contracts", exampleTags);
#line 103
this.ScenarioSetup(scenarioInfo);
#line 104
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 105
 testRunner.When(string.Format("I navigate to Local Office Approver Contracts screen on \"{0}\" Tab", acceptance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("I should see a list of Proposals", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
