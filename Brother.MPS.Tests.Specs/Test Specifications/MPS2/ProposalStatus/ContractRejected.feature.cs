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
namespace Brother.Tests.Specs.TestSpecifications.MPS2.ProposalStatus
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Reject Contract")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("DEV")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    [NUnit.Framework.CategoryAttribute("TYPE1")]
    [NUnit.Framework.CategoryAttribute("PROPOSALSTATUS")]
    [NUnit.Framework.CategoryAttribute("HIGH")]
    [NUnit.Framework.CategoryAttribute("PRODUCTIONSMOKE")]
    public partial class RejectContractFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ContractRejected.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Reject Contract", "\tIn order to clearly monitor the progress of created proposals\r\n\tAs a Cloud MPS D" +
                    "ealer\r\n\tI want to see a contract which has been rejected in the Rejected list", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "DEV",
                        "PROD",
                        "TYPE1",
                        "PROPOSALSTATUS",
                        "HIGH",
                        "PRODUCTIONSMOKE"});
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
        [NUnit.Framework.DescriptionAttribute("Reject contract")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "PURCHASE_AND_CLICK", "MINIMUM_VOLUME", "QUARTERLY_IN_ARREARS", "PAY_UPFRONT", "THREE_YEARS", "DIRECT_DEBIT", new string[] {
                "BUK"}, Category="BUK")]
        public virtual void RejectContract(string country, string contractType, string usageType, string billingType, string servicePackType, string contractTerm, string paymentType, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Reject contract", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given(string.Format("I have navigated to the Create Proposal page as a Cloud MPS Dealer from \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When(string.Format("I create a \"{0}\" proposal", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.And("I enter the proposal description", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
testRunner.And("I create a new customer for the proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.And(string.Format("I select Usage Type of \"{0}\", Contract Term of \"{1}\", Billing Type of \"{2}\" and S" +
                        "ervice Pack type of \"{3}\"", usageType, contractTerm, billingType, servicePackType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "Price",
                        "InstallationPack",
                        "Delivery",
                        "CoverageMono",
                        "VolumeMono",
                        "CoverageColour",
                        "VolumeColour"});
            table1.AddRow(new string[] {
                        "HL-L5100DN",
                        "1000.00",
                        "BROTHER_INSTALLATION",
                        "Yes",
                        "5",
                        "1000",
                        "0",
                        "0"});
#line 13
testRunner.And("I add these printers:", ((string)(null)), table1, "And ");
#line 16
testRunner.And("I calculate the click price for each of the above printers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And(string.Format("I save the above proposal and submit it for approval with payment type \"{0}\"", paymentType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.And("a Cloud MPS Local Office Approver approves the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.And("I have navigated to the Approved Proposals page and navigate to the proposal Summ" +
                    "ary page for this proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.And("I sign the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.And("a Cloud MPS Local Office Approver rejects the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.Then("I can see the above proposal in the Rejected list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
