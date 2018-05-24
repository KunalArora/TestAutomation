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
namespace Brother.Tests.Specs.TestSpecifications.MPS2.SilentDevice
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("SilentDeviceReportVerify")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TYPE3")]
    [NUnit.Framework.CategoryAttribute("HIGH")]
    [NUnit.Framework.CategoryAttribute("FULLDATAQUERY")]
    [NUnit.Framework.CategoryAttribute("CI_TestMaintenance")]
    public partial class SilentDeviceReportVerifyFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SilentDeviceReportVerify.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SilentDeviceReportVerify", "\tIn order to sell Cloud MPS services to customers\r\n\tAs a Cloud MPS Dealer\r\n\tI wan" +
                    "t to create a new agreement and complete the installation of all devices", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TYPE3",
                        "HIGH",
                        "FULLDATAQUERY",
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
        [NUnit.Framework.DescriptionAttribute("SilentDeviceReportVerify")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "CPP_AGREEMENT", "False", "MINIMUM_VOLUME", "FOUR_YEARS", "INCLUDED_IN_CLICK_PRICE", "False", "Cloud", "Bor", "5", new string[] {
                "BUK"}, Category="BUK")]
        public virtual void SilentDeviceReportVerify(string country, string agreementType, string optionalFields_1, string usageType, string contractTerm, string service, string optionalFields_2, string communicationMethod, string installationType, string agreementShiftDays, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SilentDeviceReportVerify", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given(string.Format("I have navigated to the Create Agreement page as a Cloud MPS Dealer from \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When(string.Format("I input the fields (Fill Optional fields: \"{0}\") on Agreement Description Page fo" +
                        "r \"{1}\" type agreement", optionalFields_1, agreementType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.And(string.Format("I select the Usage Type of \"{0}\", Contract Term of \"{1}\" and Service of \"{2}\"", usageType, contractTerm, service), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "Quantity",
                        "InstallationPack",
                        "ServicePack",
                        "CoverageMono",
                        "VolumeMono",
                        "CoverageColour",
                        "VolumeColour",
                        "SendInstallationRequest",
                        "MonoPrintCount",
                        "ColorPrintCount",
                        "TonerInkBlackStatus",
                        "TonerInkCyanStatus",
                        "TonerInkMagentaStatus",
                        "TonerInkYellowStatus",
                        "TonerInkBlackRemLife",
                        "TonerInkCyanRemLife",
                        "TonerInkMagentaRemLife",
                        "TonerInkYellowRemLife",
                        "TonerInkBlackReplaceCount",
                        "TonerInkCyanReplaceCount",
                        "TonerInkMagentaReplaceCount",
                        "TonerInkYellowReplaceCount"});
            table1.AddRow(new string[] {
                        "DCP-8110DN",
                        "1",
                        "No",
                        "No",
                        "25",
                        "2000",
                        "0",
                        "0",
                        "Yes",
                        "2250",
                        "0",
                        "Normal",
                        "Normal",
                        "Normal",
                        "Normal",
                        "2",
                        "100",
                        "100",
                        "100",
                        "2",
                        "0",
                        "0",
                        "0"});
            table1.AddRow(new string[] {
                        "MFC-L8650CDW",
                        "1",
                        "No",
                        "No",
                        "25",
                        "2000",
                        "25",
                        "2000",
                        "Yes",
                        "1000",
                        "1250",
                        "Normal",
                        "Empty",
                        "Normal",
                        "Normal",
                        "100",
                        "100",
                        "2",
                        "100",
                        "0",
                        "1",
                        "0",
                        "0"});
#line 11
testRunner.And("I add these printers and verify click price:", ((string)(null)), table1, "And ");
#line 15
testRunner.And("I complete the setup of agreement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
testRunner.Then("I can verify the creation of agreement in the agreement list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.When("I navigate to edit device data page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.And(string.Format("I edit device data using bulk edit option (Fill Optional fields: \"{0}\")", optionalFields_2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.And("I can verify that devices are ready for installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.Then("I can create and send a bulk installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.When("I export the device data into excel and retrieve installation information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.And(string.Format("a Cloud MPS Installer is able to bulk install the devices using \"{0}\" communicati" +
                        "on and \"{1}\" installation", communicationMethod, installationType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.Then("I can verify that all devices are installed and responding", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("the print counts of the devices are updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I can verify the correct reflection of updated print counts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.When("I manually raise a service request for above devices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.When("a Cloud MPS Service Desk closes the service request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.Then("I can verify that service request has been closed succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.When("I manually raise a service request for above devices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.And("a Cloud MPS Service Desk closes the service request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
testRunner.Then("I can verify that service request has been closed succesfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
testRunner.When("I manually raise a service request for above devices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("a Cloud MPS Service Desk can verify the service request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("I manually raise a consumable order for above devices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.Then("I can verify the generation of manual consumable orders alongwith status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("I automatically raise a consumable order for above devices", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I can verify the generation of automatic consumable orders alongwith status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.When(string.Format("the agreement start date gets shifted \"{0}\" days behind without generating invoic" +
                        "e", agreementShiftDays), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("I can verify the device status being silent", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
