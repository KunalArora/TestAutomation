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
    [NUnit.Framework.DescriptionAttribute("Type3EnhancedUsageMonitoring")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("HIGH")]
    [NUnit.Framework.CategoryAttribute("TYPE3")]
    [NUnit.Framework.CategoryAttribute("EUM")]
    [NUnit.Framework.CategoryAttribute("CI_TestMaintenance")]
    public partial class Type3EnhancedUsageMonitoringFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Type3EnhancedUsageMonitoring.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Type3EnhancedUsageMonitoring", "\tIn order to sell Cloud MPS services to customers\r\n\tAs a Cloud MPS Dealer with th" +
                    "e help of Cloud MPS BIE Admin\r\n\tI want to ensure the correct working of the defa" +
                    "ult order threshold functionality for Type 3", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "HIGH",
                        "TYPE3",
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
        [NUnit.Framework.DescriptionAttribute("Type3EnhancedUsageMonitoring")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "CPP_AGREEMENT", "True", "MINIMUM_VOLUME", "THREE_YEARS", "PAY_UPFRONT", "True", "Cloud", "Bor", new string[] {
                "BUK"}, Category="BUK")]
        public virtual void Type3EnhancedUsageMonitoring(string country, string agreementType, string optionalFields_1, string usageType, string contractTerm, string service, string optionalFields_2, string communicationMethod, string installationType, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Type3EnhancedUsageMonitoring", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("a Cloud MPS BIE Admin has navigated to the Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("a Cloud MPS BIE Admin navigates to the Printer Engine tab under Manage Device Ord" +
                    "er Threshold section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.And(string.Format("a Cloud MPS BIE Admin selects the country as \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "PrinterEngine",
                        "SupplyItemType",
                        "Threshold",
                        "Enabled"});
            table1.AddRow(new string[] {
                        "BC2 Step",
                        "Mono",
                        "12.00",
                        "true"});
            table1.AddRow(new string[] {
                        "BC2 Step",
                        "Colour",
                        "15.00",
                        "true"});
#line 11
testRunner.Then("a Cloud MPS BIE Admin can set the threshold value for printer engines types as fo" +
                    "llows and saves the details", ((string)(null)), table1, "Then ");
#line 15
testRunner.Given(string.Format("I have navigated to the Create Agreement page as a Cloud MPS Dealer from \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
testRunner.When(string.Format("I input the fields (Fill Optional fields: \"{0}\") on Agreement Description Page fo" +
                        "r \"{1}\" type agreement", optionalFields_1, agreementType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.And(string.Format("I select the Usage Type of \"{0}\", Contract Term of \"{1}\" and Service of \"{2}\"", usageType, contractTerm, service), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "Quantity",
                        "InstallationPack",
                        "ServicePack",
                        "CoverageMono",
                        "VolumeMono",
                        "CoverageColour",
                        "VolumeColour",
                        "SendInstallationRequest",
                        "MonoThresholdValue",
                        "ColourThresholdValue",
                        "TonerInkBlackRemLife",
                        "TonerInkCyanRemLife",
                        "TonerInkMagentaRemLife",
                        "TonerInkYellowRemLife"});
            table2.AddRow(new string[] {
                        "DCP-L8450CDW",
                        "1",
                        "Yes",
                        "Yes",
                        "25",
                        "2500",
                        "25",
                        "2500",
                        "Yes",
                        "15.00",
                        "20.00",
                        "14",
                        "100",
                        "19",
                        "100"});
#line 18
testRunner.And("I add these printers and verify click price:", ((string)(null)), table2, "And ");
#line 21
testRunner.And("I complete the setup of agreement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.Then("I can verify the creation of agreement in the agreement list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
testRunner.When("I navigate to edit device data page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
testRunner.And(string.Format("I edit device data one by one for all devices (Fill Optional fields: \"{0}\")", optionalFields_2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.And("I can verify that devices are ready for installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.Then("I can create and send a bulk installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.When("I export the device data into excel and retrieve installation information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.And(string.Format("a Cloud MPS Installer is able to install devices one by one using \"{0}\" communica" +
                        "tion and \"{1}\" installation", communicationMethod, installationType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.Then("I can verify that all devices are installed and responding", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.When("a Cloud MPS BIE Admin navigates to the Installed Printer tab under Manage Device " +
                    "Order Threshold section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.Then("a Cloud MPS BIE Admin searches for the agreement and ensures correct printer and " +
                    "threshold details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
testRunner.And("a Cloud MPS BIE Admin updates the threshold value for printers and saves the deta" +
                    "ils", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
testRunner.When("I automatically raise a consumable order for above devices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("I can verify the generation of automatic consumable orders alongwith status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
