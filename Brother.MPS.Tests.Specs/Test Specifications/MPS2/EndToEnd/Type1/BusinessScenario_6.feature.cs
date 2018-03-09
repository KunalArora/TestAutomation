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
namespace Brother.Tests.Specs.TestSpecifications.MPS2.EndToEnd.Type1
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("BusinessScenario_6")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TYPE1")]
    [NUnit.Framework.CategoryAttribute("ENDTOEND")]
    public partial class BusinessScenario_6Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BusinessScenario_6.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BusinessScenario_6", "\tIn order to sell Cloud MPS services to customers\r\n\tAs a Cloud MPS Dealer\r\n\tI wan" +
                    "t to create a new contract and complete the installation of all devices", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TYPE1",
                        "ENDTOEND"});
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
        [NUnit.Framework.DescriptionAttribute("Business Scenario 6")]
        [NUnit.Framework.TestCaseAttribute("Germany", "LEASING_AND_SERVICE", "PAY_AS_YOU_GO", "HALF_YEARLY", "ADD_TO_THE_LEASING_RATE", "FIVE_YEARS", "New", "Cloud", "Web", "MONTHLY", new string[] {
                "BUK"}, Category="BUK")]
        public virtual void BusinessScenario6(string country, string contractType, string usageType, string billingType, string servicePackType, string contractTerm, string customer, string communicationMethod, string installationType, string leasingBillingCycle, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Business Scenario 6", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 11
testRunner.Given(string.Format("I have navigated to the Create Proposal page as a Cloud MPS Dealer from \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
testRunner.When(string.Format("I create a \"{0}\" proposal", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.And("I enter the proposal description", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.And(string.Format("I select Usage Type of \"{0}\", Contract Term of \"{1}\", Billing Type of \"{2}\", Serv" +
                        "ice Pack type of \"{3}\" and Leasing Billing Cycle of \"{4}\"", usageType, contractTerm, billingType, servicePackType, leasingBillingCycle), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "Price",
                        "InstallationPack",
                        "Delivery",
                        "CoverageMono",
                        "VolumeMono",
                        "CoverageColour",
                        "VolumeColour",
                        "SerialNumber",
                        "MonoPrintCount",
                        "ColorPrintCount",
                        "TonerInkBlackStatus",
                        "TonerInkCyanStatus",
                        "TonerInkMagentaStatus",
                        "TonerInkYellowStatus",
                        "LaserUnit",
                        "FuserUnit",
                        "PaperFeedingKit1",
                        "PaperFeedingKit2",
                        "PaperFeedingKit3",
                        "IsSwap"});
            table1.AddRow(new string[] {
                        "DCP-8110DN",
                        "300.00",
                        "",
                        "Yes",
                        "5",
                        "1000",
                        "0",
                        "0",
                        "A3P145600",
                        "23",
                        "100",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "false"});
            table1.AddRow(new string[] {
                        "HL-5450DN",
                        "300.00",
                        "",
                        "Yes",
                        "5",
                        "1000",
                        "0",
                        "0",
                        "A3P145601",
                        "0",
                        "0",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "false"});
            table1.AddRow(new string[] {
                        "DCP-L8450CDW",
                        "300.00",
                        "",
                        "Yes",
                        "5",
                        "1000",
                        "20",
                        "250",
                        "A3P145602",
                        "0",
                        "0",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "false"});
            table1.AddRow(new string[] {
                        "MFC-L8650CDW",
                        "300.00",
                        "",
                        "Yes",
                        "5",
                        "1000",
                        "20",
                        "200",
                        "A3P145603",
                        "0",
                        "0",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "false"});
            table1.AddRow(new string[] {
                        "DCP-8250DN",
                        "300.00",
                        "",
                        "Yes",
                        "5",
                        "1000",
                        "0",
                        "250",
                        "A3P145604",
                        "0",
                        "0",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "false"});
            table1.AddRow(new string[] {
                        "DCP-L2520DW",
                        "300.00",
                        "",
                        "Yes",
                        "5",
                        "1000",
                        "0",
                        "200",
                        "A3P145605",
                        "0",
                        "0",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "false"});
#line 21
testRunner.And("I add these printers:", ((string)(null)), table1, "And ");
#line 30
testRunner.And("I calculate the click price for each of the above printers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
testRunner.And("I save the above proposal and submit it for approval", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.And("a Cloud MPS Bank release the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.And("I have navigated to the Approved Proposals page and navigate to the proposal Summ" +
                    "ary page for this proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.And("I click the download proposal button and verify if I am able to open the PDF", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "InstallUnitCost",
                        "InstallMargin",
                        "InstallUnitPrice",
                        "ServiceUnitCost",
                        "ServiceMargin",
                        "ServiceUnitPrice",
                        "MonoClickServiceCost",
                        "MonoClickServicePrice",
                        "MonoClickCoverage",
                        "MonoClickVolume",
                        "MonoClickMargin",
                        "MonoClick",
                        "ColourClickServiceCost",
                        "ColourClickServicePrice",
                        "ColourClickCoverage",
                        "ColourClickVolume",
                        "ColourClickMargin",
                        "ColourClick"});
            table2.AddRow(new string[] {
                        "*",
                        "100",
                        "50",
                        "",
                        "120",
                        "50",
                        "",
                        "",
                        "",
                        "10",
                        "100",
                        "50.00",
                        "0.01300",
                        "",
                        "",
                        "40",
                        "300",
                        "50.00",
                        "0.10700"});
#line 45
testRunner.And("a Cloud MPS Local Office Approver Set a Special Pricing:", ((string)(null)), table2, "And ");
#line 49
testRunner.And("I sign the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.And("I navigate to the Accepted Contracts page and I locate the above contract and cli" +
                    "ck Manage Devices button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
testRunner.And(string.Format("I create a \"{0}\" installation request for \"{1}\" communication", installationType, communicationMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
testRunner.And("I will be able to see the installation request created above on the Manage Device" +
                    "s page for the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
testRunner.And("a Brother installer has navigated to the Web Installation page and verify Contrac" +
                    "t Reference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
testRunner.And("Enter the serial numbers and complete installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.And("I navigate to the Accepted Contracts page and I locate the above contract and cli" +
                    "ck Manage Devices button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.And("I will be able to see on the Manage Devices page that all devices for the above c" +
                    "ontract are connected with default Print Counts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
testRunner.And("I update the print count, raise consumable order and service request for above de" +
                    "vices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
testRunner.And("I will be able to see on the Manage Devices page that above devices have updated " +
                    "Print Counts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
