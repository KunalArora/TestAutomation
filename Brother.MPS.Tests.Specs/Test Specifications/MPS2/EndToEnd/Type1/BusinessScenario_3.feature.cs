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
    [NUnit.Framework.DescriptionAttribute("Type1BusinessScenario_3")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TYPE1")]
    [NUnit.Framework.CategoryAttribute("ENDTOEND")]
    [NUnit.Framework.CategoryAttribute("CI_TestMaintenance")]
    public partial class Type1BusinessScenario_3Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BusinessScenario_3.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Type1BusinessScenario_3", "\tIn order to sell Cloud MPS services to customers\r\n\tAs a Cloud MPS Dealer\r\n\tI wan" +
                    "t to create a new contract and complete the installation of all devices", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TYPE1",
                        "ENDTOEND",
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
        [NUnit.Framework.DescriptionAttribute("Type1BusinessScenario_3")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "", "PURCHASE_AND_CLICK", "MINIMUM_VOLUME", "QUARTERLY_IN_ADVANCE", "INCLUDED_IN_CLICK_PRICE", "FIVE_YEARS", "New", "Cloud", "Web", "REPLACE_THE_PCB", "A3P145604", "100", "0", new string[] {
                "BUK"}, Category="BUK")]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "fr-CH", "PURCHASE_AND_CLICK", "MINIMUM_VOLUME", "QUARTERLY_IN_ADVANCE", "INCLUDED_IN_CLICK_PRICE", "FIVE_YEARS", "New", "Cloud", "Web", "REPLACE_THE_PCB", "A3P145604", "100", "0", new string[] {
                "BSW"}, Category="BSW")]
        public virtual void Type1BusinessScenario_3(string country, string culture, string contractType, string usageType, string billingType, string servicePackType, string contractTerm, string customer, string communicationMethod, string installationType, string swapType, string swapNewDeviceSerialNumber, string swapNewDeviceMonoPrintCount, string swapNewDeviceColorPrintCount, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Type1BusinessScenario_3", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given(string.Format("I have navigated to the Create Proposal page as a Cloud MPS Dealer with culture \"" +
                        "{0}\" from \"{1}\"", culture, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "HL-L2340DW",
                        "1000.00",
                        "DEALER_INSTALLATION_TYPE1",
                        "Yes",
                        "5",
                        "1000",
                        "0",
                        "0",
                        "A3P145600",
                        "23",
                        "100",
                        "Empty",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Empty",
                        "Normal",
                        "Normal",
                        "Normal",
                        "true"});
            table1.AddRow(new string[] {
                        "HL-L2360DN",
                        "1000.00",
                        "DEALER_INSTALLATION_TYPE1",
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
                        "1000.00",
                        "DEALER_INSTALLATION_TYPE1",
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
                        "1000.00",
                        "DEALER_INSTALLATION_TYPE1",
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
#line 13
testRunner.And("I add these printers:", ((string)(null)), table1, "And ");
#line 19
testRunner.And("I calculate the click price for each of the above printers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.And("I save the above proposal and submit it for approval", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.And("a Cloud MPS Local Office Approver declines the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.And("I copy declined proposal and create new customer and submit it for approval", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                        "",
                        "",
                        "",
                        "",
                        "",
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
#line 24
testRunner.And("a Cloud MPS Local Office Approver Set a Special Pricing:", ((string)(null)), table2, "And ");
#line 28
testRunner.And("a Cloud MPS Local Office Approver approves the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.And("I have navigated to the Approved Proposals page and navigate to the proposal Summ" +
                    "ary page for this proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.And("I click the download proposal button and verify if I am able to open the PDF", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.And("I sign the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
testRunner.And("a Cloud MPS Local Office Approver accepts the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
testRunner.And("a Cloud MPS Local Office Approver locate the above contract and click Manage Devi" +
                    "ces button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
testRunner.And(string.Format("a Cloud MPS Local Office Approver create a \"{0}\" installation request for \"{1}\" c" +
                        "ommunication", installationType, communicationMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.And("a Cloud MPS Local Office Approver will be able to see the installation request cr" +
                    "eated above on the Manage Devices page for the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
testRunner.And("a Brother installer has navigated to the Web Installation page and verify Contrac" +
                    "t Reference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.And("Enter the serial numbers and complete installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
testRunner.And("a Cloud MPS Local Office Approver locate the above contract and click Manage Devi" +
                    "ces button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.And("a Cloud MPS Local Office Approver will be able to see on the Manage Devices page " +
                    "that all devices for the above contract are connected with default Print Counts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
testRunner.And("I update the print count, raise consumable order and service request for above de" +
                    "vices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
testRunner.And("a Cloud MPS Local Office Approver will be able to see on the Manage Devices page " +
                    "that above devices have updated Print Counts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
testRunner.And("a Customer has navigated to the Consumables Devices page to verify that above dev" +
                    "ice have updated Ink Status and Service Request is raised", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.And("a Cloud MPS Local Office Approver click Swap Device in the Actions menu for devic" +
                    "e to be swapped on the Manage devices page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.And(string.Format("a Cloud MPS Local Office Approver create a \"{0}\" swap installation request with \"" +
                        "{1}\" installation type for \"{2}\" communication", swapType, installationType, communicationMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.And("a Cloud MPS Local Office Approver will be able to see the status of the installed" +
                    " device is set Being Replaced on the Manage Devices page for the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.And("a Brother installer has navigated to the Web Swap Installation page and verify Co" +
                    "ntract Reference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
testRunner.And(string.Format("Enter the serial number for new device \"{0}\" with new Mono \"{1}\" and color \"{2}\" " +
                        "print count and complete Installation", swapNewDeviceSerialNumber, swapNewDeviceMonoPrintCount, swapNewDeviceColorPrintCount), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
testRunner.Then("a Cloud MPS Local Office Approver will be able to see the status of the swap devi" +
                    "ce is set Being Swapped with updated print counts on the Manage Devices page for" +
                    " the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
