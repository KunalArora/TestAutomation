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
namespace Brother.Tests.Specs.TestSpecifications.MPS2.EndToEnd.Type3
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Type3BusinessScenario_3")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TYPE3")]
    [NUnit.Framework.CategoryAttribute("ENDTOEND")]
    [NUnit.Framework.CategoryAttribute("CI_TestMaintenance")]
    public partial class Type3BusinessScenario_3Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BusinessScenario_3.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Type3BusinessScenario_3", "\tIn order to sell Cloud MPS services to customers\r\n\tAs a Cloud MPS Dealer\r\n\tI wan" +
                    "t to create a new agreement and complete the installation of all devices", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TYPE3",
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
        [NUnit.Framework.DescriptionAttribute("Type3BusinessScenario_3")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "CPP_AGREEMENT", "True", "MINIMUM_VOLUME", "FIVE_YEARS", "INCLUDED_IN_CLICK_PRICE", "True", "Cloud", "Bor", "40", new string[] {
                "BUK"}, Category="BUK")]
        public virtual void Type3BusinessScenario_3(string country, string agreementType, string optionalFields_1, string usageType, string contractTerm, string service, string optionalFields_2, string communicationMethod, string installationType, string agreementShiftDays, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Type3BusinessScenario_3", exampleTags);
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
                        "ResetDevice",
                        "ReInstallDevice"});
            table1.AddRow(new string[] {
                        "DCP-8110DN",
                        "2",
                        "Yes",
                        "Yes",
                        "100",
                        "4000",
                        "0",
                        "0",
                        "Yes",
                        "4000",
                        "0",
                        "Yes",
                        "No"});
            table1.AddRow(new string[] {
                        "DCP-8250DN",
                        "1",
                        "Yes",
                        "Yes",
                        "100",
                        "4000",
                        "0",
                        "0",
                        "Yes",
                        "4000",
                        "0",
                        "No",
                        "Yes"});
#line 11
testRunner.And("I add these printers and verify click price:", ((string)(null)), table1, "And ");
#line 15
testRunner.And("I complete the setup of agreement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
testRunner.Then("I can verify the creation of agreement in the agreement list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.When("I navigate to edit device data page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.And(string.Format("I edit device data using excel edit option (Fill Optional fields: \"{0}\")", optionalFields_2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.And("I can verify that devices are ready for installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.Then("a Cloud MPS LO Approver can create and send a bulk installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "InstallUnitPrice",
                        "ServiceUnitPrice",
                        "MonoClickCoverage",
                        "MonoClickVolume",
                        "ColourClickCoverage",
                        "ColourClickVolume"});
            table2.AddRow(new string[] {
                        "*",
                        "-10.00",
                        "-10.00",
                        "-10",
                        "-100",
                        "-10",
                        "-100"});
#line 21
testRunner.And("a Cloud MPS LO Approver applies special pricing using relative values(+/- w.r.t. " +
                    "current values) or absolute values:", ((string)(null)), table2, "And ");
#line 24
testRunner.Then("a Cloud MPS LO Approver can verify that special pricing is correctly applied", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
testRunner.When("I export the device data into excel and retrieve installation information", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.And(string.Format("a Cloud MPS Installer is able to bulk install the devices using \"{0}\" communicati" +
                        "on and \"{1}\" installation", communicationMethod, installationType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.And("a Cloud MPS Installer resets the devices and reinstalls them", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("I can verify that all devices are installed and responding", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.And("I can verify the device details on device dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.When("a Cloud MPS LO Approver can create and send a device reinstallation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.And(string.Format("a Cloud MPS Installer is able to reinstall devices using \"{0}\" communication and " +
                        "\"{1}\" installation", communicationMethod, installationType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
testRunner.Then("I can verify that the reinstalled devices are responding", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
testRunner.When("the print counts of the devices are updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
testRunner.Then("I can verify the correct reflection of updated print counts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
testRunner.And("I can verify the detailed device information on device dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.When(string.Format("the agreement start date gets shifted \"{0}\" days behind", agreementShiftDays), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I can verify the click rate billing invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.And("I can verify the service/installation billing invoice", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
