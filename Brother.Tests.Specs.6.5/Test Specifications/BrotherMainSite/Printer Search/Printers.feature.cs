﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Brother.Tests.Specs.TestSpecifications.BrotherMainSite.PrinterSearch
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Correct printer product listings")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    public partial class CorrectPrinterProductListingsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Printers.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Correct printer product listings", "In order to purchase a new Printer\r\nAs a customer\r\nI want to be able to view the " +
                    "list of available printers", ProgrammingLanguage.CSharp, new string[] {
                        "UAT",
                        "PROD"});
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
        [NUnit.Framework.DescriptionAttribute("View the list of available Laser Printers on Brother Main sites for languages exc" +
            "ept Spain and Portugal")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("Belgium", "brother-printers/laser-printers?sc_lang=nl-BE", null)]
        [NUnit.Framework.TestCaseAttribute("Belgium", "imprimantes/imprimantes-laser?sc_lang=fr-BE", null)]
        [NUnit.Framework.TestCaseAttribute("Czech", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Denmark", "printers/all-colour-lasers", null)]
        [NUnit.Framework.TestCaseAttribute("Finland", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("France", "imprimantes/imprimantes-multifonctions/multifonctions-laser", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "drucker/alle-lasergeraete/monolaser", null)]
        [NUnit.Framework.TestCaseAttribute("Hungary", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "printers/laserprinters", null)]
        [NUnit.Framework.TestCaseAttribute("Norway", "printers/all-colour-lasers", null)]
        [NUnit.Framework.TestCaseAttribute("Poland", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Romania", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Russia", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Slovakia", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Slovenia", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "drucker/laserdrucker?sc_lang=de-CH", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "imprimantes/imprimantes-laser?sc_lang=fr-CH", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "printers/all-mono-lasers", null)]
        public virtual void ViewTheListOfAvailableLaserPrintersOnBrotherMainSitesForLanguagesExceptSpainAndPortugal(string country, string site, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View the list of available Laser Printers on Brother Main sites for languages exc" +
                    "ept Spain and Portugal", @__tags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("I have navigated to the Brother Main Site \"{0}\" products pages", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.Given(string.Format("I have navigated to the \"{0}\" MainSite URL for country \"{1}\"", site, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.Then("I should see a list of Laser printers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.And("I can validate that each printer is a valid printer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("View the list of available Laser Printers on Brother Main sites for Spain and Por" +
            "tugal")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("Portugal", "printers/laser-printers", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "impresoras/laser-printers", null)]
        public virtual void ViewTheListOfAvailableLaserPrintersOnBrotherMainSitesForSpainAndPortugal(string country, string site, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View the list of available Laser Printers on Brother Main sites for Spain and Por" +
                    "tugal", @__tags);
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given(string.Format("I have navigated to the Brother Main Site \"{0}\" products pages", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.Given(string.Format("I have navigated to the \"{0}\" MainSite URL for country \"{1}\"", site, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.Then("I should see a list of Laser printers", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.And("I can validate that each printer for Spain and Portugal is a valid printer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
