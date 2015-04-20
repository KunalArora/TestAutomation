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
namespace Brother.Tests.Specs.TestSpecifications.BrotherOnline.SiteAccess
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AccessAllUATSites")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class AccessAllUATSitesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SitesAccess_UATEnvironment.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AccessAllUATSites", "In order to validate the status of a Websites on the UAT environment\r\nAs a sanity" +
                    " check\r\nWe need to receive a 200 OK request back from a list of selected sites", ProgrammingLanguage.CSharp, new string[] {
                        "UAT"});
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
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Main Site Ireland on the QAS environment")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromBrotherMainSiteIrelandOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Main Site Ireland on the QAS environment", new string[] {
                        "SMOKE"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("The following site \"http://ie.brotherqas.eu/\" to validate I should receive an Ok " +
                    "response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Main Site United Kingdom on the QAS environment")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromMainSiteUnitedKingdomOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Main Site United Kingdom on the QAS environment", new string[] {
                        "SMOKE"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("The following site \"http://uk.brotherqas.eu/\" to validate I should receive an Ok " +
                    "response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Online Ireland on the QAS environment")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromBrotherOnlineIrelandOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Online Ireland on the QAS environment", new string[] {
                        "SMOKE"});
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("The following site \"https://online.ie.brotherqas.eu/\" to validate I should receiv" +
                    "e an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Online United Kingdom on the QAS environmen" +
            "t")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromBrotherOnlineUnitedKingdomOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Online United Kingdom on the QAS environmen" +
                    "t", new string[] {
                        "SMOKE"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("The following site \"https://online.uk.brotherqas.eu/\" to validate I should receiv" +
                    "e an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Online Spain on the QAS environment")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromBrotherOnlineSpainOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Online Spain on the QAS environment", new string[] {
                        "SMOKE"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("The following site \"https://online.es.brotherqas.eu/\" to validate I should receiv" +
                    "e an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Online Poland on the QAS environment")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromBrotherOnlinePolandOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Online Poland on the QAS environment", new string[] {
                        "SMOKE"});
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
 testRunner.Given("The following site \"https://online.pl.brotherqas.eu/\" to validate I should receiv" +
                    "e an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Web Conferencing United Kingdom on the QAS environm" +
            "ent")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromWebConferencingUnitedKingdomOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Web Conferencing United Kingdom on the QAS environm" +
                    "ent", new string[] {
                        "SMOKE"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("The following site \"http://webconferencing.uk.brotherqas.eu/\" to validate I shoul" +
                    "d receive an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Creative Centre United Kingdom on the QAS environme" +
            "nt")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromCreativeCentreUnitedKingdomOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Creative Centre United Kingdom on the QAS environme" +
                    "nt", new string[] {
                        "SMOKE"});
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given("The following site \"http://creativecenter.eu.brotherqas.eu/\" to validate I should" +
                    " receive an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
