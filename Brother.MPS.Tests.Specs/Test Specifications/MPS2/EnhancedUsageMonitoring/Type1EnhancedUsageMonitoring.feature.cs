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
namespace Brother.Tests.Specs.TestSpecifications.MPS2.EnhancedUsageMonitoring
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Type1EnhancedUsageMonitoring")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("HIGH")]
    [NUnit.Framework.CategoryAttribute("TYPE1")]
    [NUnit.Framework.CategoryAttribute("EUM")]
    [NUnit.Framework.CategoryAttribute("CI_TestMaintenance")]
    public partial class Type1EnhancedUsageMonitoringFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Type1EnhancedUsageMonitoring.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Type1EnhancedUsageMonitoring", "\tIn order to sell Cloud MPS services to customers\r\n\tAs a Cloud MPS Dealer with th" +
                    "e help of Cloud MPS LO Admin\r\n\tI want to ensure the correct working of the defau" +
                    "lt order threshold functionality for Type 1", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "HIGH",
                        "TYPE1",
                        "EUM",
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
        [NUnit.Framework.DescriptionAttribute("Type1EnhancedUsageMonitoring")]
        [NUnit.Framework.TestCaseAttribute("Germany", "LEASING_AND_SERVICE", "PAY_AS_YOU_GO", "HALF_YEARLY_IN_ARREARS", "ADD_TO_THE_LEASING_RATE", "FIVE_YEARS", "New", "Cloud", "Web", "MONTHLY", new string[] {
                "BIG"}, Category="BIG")]
        public virtual void Type1EnhancedUsageMonitoring(string country, string contractType, string usageType, string billingType, string servicePackType, string contractTerm, string customer, string communicationMethod, string installationType, string leasingBillingCycle, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Type1EnhancedUsageMonitoring", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given(string.Format("a Cloud MPS Local Office Admin has navigated to the Dashboard page for country \"{" +
                        "0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("a Cloud MPS Local Office Admin navigates to the Printer Engine tab under Manage D" +
                    "evice Order Threshold section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "PrinterEngine",
                        "SupplyItemType",
                        "Threshold",
                        "Enabled"});
            table1.AddRow(new string[] {
                        "BC2 Step",
                        "Mono",
                        "14.00",
                        "true"});
            table1.AddRow(new string[] {
                        "BC2 Step",
                        "Colour",
                        "12.00",
                        "true"});
#line 10
testRunner.Then("a Cloud MPS Local Office Admin can set the threshold value for printer engines ty" +
                    "pes as follows and saves the details", ((string)(null)), table1, "Then ");
#line 14
testRunner.Given(string.Format("I have navigated to the Create Proposal page as a Cloud MPS Dealer from \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
testRunner.When(string.Format("I create a \"{0}\" proposal", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.And("I enter the proposal description", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And(string.Format("I select Usage Type of \"{0}\", Contract Term of \"{1}\", Billing Type of \"{2}\", Serv" +
                        "ice Pack type of \"{3}\" and Leasing Billing Cycle of \"{4}\"", usageType, contractTerm, billingType, servicePackType, leasingBillingCycle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "Price",
                        "InstallationPack",
                        "Delivery",
                        "CoverageMono",
                        "VolumeMono",
                        "CoverageColour",
                        "VolumeColour",
                        "MonoThresholdValue",
                        "ColourThresholdValue",
                        "TonerInkBlackRemLife",
                        "TonerInkCyanRemLife",
                        "TonerInkMagentaRemLife",
                        "TonerInkYellowRemLife",
                        "SerialNumber"});
            table2.AddRow(new string[] {
                        "DCP-L8450CDW",
                        "300.00",
                        "",
                        "Yes",
                        "5",
                        "1000",
                        "20",
                        "20",
                        "12.00",
                        "10.00",
                        "11",
                        "100",
                        "9",
                        "100",
                        "A3P145600"});
#line 18
testRunner.And("I add these printers:", ((string)(null)), table2, "And ");
#line 21
testRunner.And("I calculate the click price for each of the above printers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.And("I save the above proposal and submit it for approval", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.And("a Cloud MPS Bank release the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.Then("I have navigated to the Approved Proposals page and navigate to the proposal Summ" +
                    "ary page for this proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
testRunner.When("a Cloud MPS Local Office Approver navigates to Manage Device Order Threshold sect" +
                    "ion and ensures correct display of tabs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.Then("a Cloud MPS Local Office Approver can search for the proposal, verify proposal de" +
                    "tails and ensure printer details are not displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.When("I sign the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.And("a Cloud MPS Local Office Approver searches for the proposal and ensures correct p" +
                    "rinter and threshold details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.Then("a Cloud MPS Local Office Approver updates the threshold value for printers and sa" +
                    "ves the details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.When("I navigate to the Accepted Contracts page and I locate the above contract and cli" +
                    "ck Manage Devices button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.And(string.Format("I create a \"{0}\" installation request for \"{1}\" communication", installationType, communicationMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
testRunner.And("I will be able to see the installation request created above on the Manage Device" +
                    "s page for the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
testRunner.And("a Brother installer has navigated to the Web Installation page and verify Contrac" +
                    "t Reference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
testRunner.And("Enter the serial numbers and complete installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.And("I navigate to the Accepted Contracts page and I locate the above contract and cli" +
                    "ck Manage Devices button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
testRunner.And("I will be able to see on the Manage Devices page that all devices for the above c" +
                    "ontract are connected with default Print Counts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.And("a Cloud MPS Bank Cloud MPS Bank Summary Accept", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
testRunner.And("a Cloud MPS Bank Populated Maintain Contact", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.Then("I set the Contract in the running state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
testRunner.When("I automatically raise a consumable order for above devices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.Then("I can verify the generation of automatic consumable orders alongwith status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion