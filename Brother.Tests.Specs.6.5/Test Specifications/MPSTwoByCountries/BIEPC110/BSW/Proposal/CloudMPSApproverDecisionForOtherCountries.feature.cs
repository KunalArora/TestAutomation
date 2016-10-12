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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC110.BSW.Proposal
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSSwissApproverDecisionFeature")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class CloudMPSSwissApproverDecisionFeatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSApproverDecisionForOtherCountries.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSSwissApproverDecisionFeature", "In order to approve/decline Proposal/Contract\r\nAs a Approver\r\nI want to decide ab" +
                    "out Proposal/Contract", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Approver Decline Proposal for other Countries")]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "Cloud MPS Local Office Approver", "Purchase & Click mit Service", "Mindestvolumen", "36", "Quarterly in Arrears", null)]
        public virtual void ApproverDeclineProposalForOtherCountries(string country, string role, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Approver Decline Proposal for other Countries", exampleTags);
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given(string.Format("I verify and store \"{0}\" purchase and click proposal bypass status", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.Then(string.Format("\"{0}\" can decline Awaiting \"<Language>\" Approval \"{1}\" \"{2}\" proposal with \"{3}\" " +
                        "and \"{4}\" and \"{5}\"", role, country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Approver can decide to reject or approve the contract for other Countries")]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "Cloud MPS Local Office Approver", "Purchase & Click mit Service", "Mindestvolumen", "36", "Quarterly in Arrears", null)]
        public virtual void ApproverCanDecideToRejectOrApproveTheContractForOtherCountries(string country, string role, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Approver can decide to reject or approve the contract for other Countries", exampleTags);
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.When("Approver navigate to Contract Awaiting Acceptance page from Dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("Approver can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.And("Approver can either reject or approve the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Approver can approve the contract for other Countries")]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "Cloud MPS Local Office Approver", "Purchase & Click mit Service", "Mindestvolumen", "36", "Quarterly in Arrears", null)]
        public virtual void ApproverCanApproveTheContractForOtherCountries(string country, string role, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Approver can approve the contract for other Countries", exampleTags);
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("Approver navigate to Contract Awaiting Acceptance page from Dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("Approver can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("Approver can successfully approve the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("the accepted contract by Approver is displayed on contract Accepted screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Approver can reject the contract for other Countries")]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "Cloud MPS Local Office Approver", "Purchase & Click mit Service", "Mindestvolumen", "36", "Quarterly in Arrears", null)]
        public virtual void ApproverCanRejectTheContractForOtherCountries(string country, string role, string contractType, string usageType, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Approver can reject the contract for other Countries", exampleTags);
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.When("Approver navigate to Contract Awaiting Acceptance page from Dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("Approver can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("Approver can successfully reject the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("the rejected contract by Approver is displayed on contract Rejected screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer can resign rejected contract for other Countries")]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "Cloud MPS Local Office Approver", "Purchase & Click mit Service", "Mindestvolumen", "36", "Quarterly in Arrears", "Cloud MPS Dealer", null)]
        public virtual void DealerCanResignRejectedContractForOtherCountries(string country, string role, string contractType, string usageType, string length, string billing, string role2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can resign rejected contract for other Countries", exampleTags);
#line 66
this.ScenarioSetup(scenarioInfo);
#line 67
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 68
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("Approver navigate to Contract Awaiting Acceptance page from Dashboard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("Approver can view all the contracts that have been signed by dealer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.And("Approver can successfully reject the contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("the rejected contract by Approver is displayed on contract Rejected screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role2, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
 testRunner.When("I navigate to Rejected screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.Then("I can successfully re-sign the rejected contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Local Office Approver can view opened offers for other Countries")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", null)]
        public virtual void LocalOfficeApproverCanViewOpenedOffersForOtherCountries(string role, string country, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Local Office Approver can view opened offers for other Countries", exampleTags);
#line 85
this.ScenarioSetup(scenarioInfo);
#line 86
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
 testRunner.When("I navigate to ProposalPage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.And("I navigate to Awaiting Approval screen under Proposals page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.Then("I should see a list of Proposals on Awaiting Approval Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Local Office Approver can view confirmed/rejected/signed contracts for other Coun" +
            "tries")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Awating Acceptance", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Rejected", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Accepted", null)]
        public virtual void LocalOfficeApproverCanViewConfirmedRejectedSignedContractsForOtherCountries(string role, string country, string acceptance, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Local Office Approver can view confirmed/rejected/signed contracts for other Coun" +
                    "tries", exampleTags);
#line 97
this.ScenarioSetup(scenarioInfo);
#line 98
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
 testRunner.When(string.Format("I navigate to Local Office Approver Contracts screen on \"{0}\" Tab", acceptance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("I should see a list of Proposals", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion