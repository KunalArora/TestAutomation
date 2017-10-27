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
namespace Brother.Tests.Specs.TestSpecifications.MPS2.EndToEnd.Type1
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("BusinessScenario_1")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TYPE1")]
    [NUnit.Framework.CategoryAttribute("ENDTOEND")]
    public partial class BusinessScenario_1Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BusinessScenario_1.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BusinessScenario_1", "In order to sell Cloud MPS services to customers\r\nAs a Cloud MPS Dealer\r\nI want t" +
                    "o create a new contract and complete installation of all devices", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TYPE1",
                        "ENDTOEND"});
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
        [NUnit.Framework.DescriptionAttribute("Business Scenario 1")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "Purchase & Click", "Minimum Volume", "Upfront", "3 years", "New", "DCP-8110DN", "1000.00", "Brother", "Yes", "5", "1000", "0", "0", "HL-5450DN", "", "Brother", "Yes", "5", "1000", "0", "0", "DCP-L8450CDW", "", "Brother", "Yes", "5", "1000", "10", "250", "MFC-L8650CDW", "", "Brother", "Yes", "5", "1000", "10", "250", new string[] {
                "BUK"})]
        [NUnit.Framework.TestCaseAttribute("France", "Purchase & Click", "Minimum Volume", "Upfront", "3 years", "New", "ABC1234", "1000.00", "Brother", "Yes", "5", "1000", "0", "0", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", new string[] {
                "BFR"})]
        public virtual void BusinessScenario1(
                    string country, 
                    string contractType, 
                    string usageType, 
                    string servicePackType, 
                    string contractTerm, 
                    string customer, 
                    string printerModel_1, 
                    string printerPrice_1, 
                    string printerInstallation_1, 
                    string printerDelivery_1, 
                    string printerCoverageMono_1, 
                    string printerVolumeMono_1, 
                    string printerCoverageColour_1, 
                    string printerVolumeColour_1, 
                    string printerModel_2, 
                    string printerPrice_2, 
                    string printerInstallation_2, 
                    string printerDelivery_2, 
                    string printerCoverageMono_2, 
                    string printerVolumeMono_2, 
                    string printerCoverageColour_2, 
                    string printerVolumeColour_2, 
                    string printerModel_3, 
                    string printerPrice_3, 
                    string printerInstallation_3, 
                    string printerDelivery_3, 
                    string printerCoverageMono_3, 
                    string printerVolumeMono_3, 
                    string printerCoverageColour_3, 
                    string printerVolumeColour_3, 
                    string printerModel_4, 
                    string printerPrice_4, 
                    string printerInstallation_4, 
                    string printerDelivery_4, 
                    string printerCoverageMono_4, 
                    string printerVolumeMono_4, 
                    string printerCoverageColour_4, 
                    string printerVolumeColour_4, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Business Scenario 1", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given(string.Format("I have navigated to the Create Proposal page as a \"Cloud MPS Dealer\" from \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When(string.Format("I create a \"{0}\" proposal", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.And("I create a new customer for the proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.And(string.Format("I select Usage Type of {0}, Contract Term of {1}, Billing Type of <BillingType> a" +
                        "nd Service Pack type of {2}", usageType, contractTerm, servicePackType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "Price",
                        "Installation",
                        "Delivery",
                        "CoverageMono",
                        "VolumeMono",
                        "CoverageColour",
                        "VolumeColour"});
            table1.AddRow(new string[] {
                        string.Format("{0}", printerModel_1),
                        string.Format("{0}", printerPrice_1),
                        string.Format("{0}", printerInstallation_1),
                        string.Format("{0}", printerDelivery_1),
                        string.Format("{0}", printerCoverageMono_1),
                        string.Format("{0}", printerVolumeMono_1),
                        string.Format("{0}", printerCoverageColour_1),
                        string.Format("{0}", printerVolumeColour_1)});
            table1.AddRow(new string[] {
                        string.Format("{0}", printerModel_2),
                        string.Format("{0}", printerPrice_2),
                        string.Format("{0}", printerInstallation_2),
                        string.Format("{0}", printerDelivery_2),
                        string.Format("{0}", printerCoverageMono_2),
                        string.Format("{0}", printerVolumeMono_2),
                        string.Format("{0}", printerCoverageColour_2),
                        string.Format("{0}", printerVolumeColour_2)});
            table1.AddRow(new string[] {
                        string.Format("{0}", printerModel_3),
                        string.Format("{0}", printerPrice_3),
                        string.Format("{0}", printerInstallation_3),
                        string.Format("{0}", printerDelivery_3),
                        string.Format("{0}", printerCoverageMono_3),
                        string.Format("{0}", printerVolumeMono_3),
                        string.Format("{0}", printerCoverageColour_3),
                        string.Format("{0}", printerVolumeColour_3)});
            table1.AddRow(new string[] {
                        string.Format("{0}", printerModel_4),
                        string.Format("{0}", printerPrice_4),
                        string.Format("{0}", printerInstallation_4),
                        string.Format("{0}", printerDelivery_4),
                        string.Format("{0}", printerCoverageMono_4),
                        string.Format("{0}", printerVolumeMono_4),
                        string.Format("{0}", printerCoverageColour_4),
                        string.Format("{0}", printerVolumeColour_4)});
#line 13
testRunner.And("I add these printers:", ((string)(null)), table1, "And ");
#line 19
testRunner.And("I calculate the click price for each of the above printers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.And("I save the above proposal and submit it for approval", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.And("a Cloud MPS Local Office Approver approves the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.And("I sign the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.And("a Cloud MPS Local Office Approver accepts the above proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.And("I create an installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
