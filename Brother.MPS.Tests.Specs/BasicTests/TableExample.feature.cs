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
namespace Brother.Tests.Specs.BasicTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("TableExample")]
    [NUnit.Framework.CategoryAttribute("MPS_EXAMPLES")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    public partial class TableExampleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TableExample.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TableExample", "\tIn order to generate revenue\r\n\tAs a dealer\r\n\tI want to create new contracts", ProgrammingLanguage.CSharp, new string[] {
                        "MPS_EXAMPLES",
                        "UAT",
                        "MPS"});
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
        [NUnit.Framework.DescriptionAttribute("Create a new proposal")]
        [NUnit.Framework.TestCaseAttribute("Purchase & Click", "Minimum Volume", "Upfront", "3 years", "New", "ABC1234", "1000.00", "Brother", "", "", "", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("Lease & Click", "Pay As You Go", "Upfront", "5 years", "Existing", "", "", "", "", "", "", "", "", "", "", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("Lease & Click", "Minimum Volume", "In click", "5 years", "Skip", "", "", "", "", "", "", "", "", "", "", "", "", null)]
        public virtual void CreateANewProposal(
                    string contractType, 
                    string usageType, 
                    string servicePackType, 
                    string contractTerm, 
                    string customer, 
                    string printerModel_1, 
                    string printerPrice_1, 
                    string printerInstallation_1, 
                    string printerModel_2, 
                    string printerPrice_2, 
                    string printerInstallation_2, 
                    string printerModel_3, 
                    string printerPrice_3, 
                    string printerInstallation_3, 
                    string printerModel_4, 
                    string printerPrice_4, 
                    string printerInstallation_4, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a new proposal", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Model",
                        "Price",
                        "Installation",
                        "Delivery"});
            table1.AddRow(new string[] {
                        string.Format("{0}", printerModel_1),
                        string.Format("{0}", printerPrice_1),
                        string.Format("{0}", printerInstallation_1),
                        "Yes"});
            table1.AddRow(new string[] {
                        string.Format("{0}", printerModel_2),
                        string.Format("{0}", printerPrice_2),
                        string.Format("{0}", printerInstallation_2),
                        "No"});
            table1.AddRow(new string[] {
                        string.Format("{0}", printerModel_3),
                        string.Format("{0}", printerPrice_3),
                        string.Format("{0}", printerInstallation_3),
                        "No"});
            table1.AddRow(new string[] {
                        string.Format("{0}", printerModel_4),
                        string.Format("{0}", printerPrice_4),
                        string.Format("{0}", printerInstallation_4),
                        "Yes"});
#line 8
 testRunner.Given("I create a proposal with these printers:", ((string)(null)), table1, "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
