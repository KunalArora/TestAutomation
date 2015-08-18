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
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from the following Brother Main Sites on the UAT environ" +
            "ment")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("Ireland", "http://ie.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "http://uk.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "http://de.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Slovakia", "http://sk.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Poland", "http://pl.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("France", "http://fr.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "http://nl.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Russia", "http://ru.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Portugal", "http://pt.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Romania", "http://ro.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Czech", "http://cz.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Hungary", "http://hr.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Belgium", "http://be.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Denmark", "http://dk.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "http://ch.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Slovenia", "http://si.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "http://es.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Italy", "http://it.brotherqas.eu/", null)]
        public virtual void Get200OKResponseBackFromTheFollowingBrotherMainSitesOnTheUATEnvironment(string country, string mainSite, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from the following Brother Main Sites on the UAT environ" +
                    "ment", @__tags);
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given(string.Format("The following site {0} {1} to validate I should receive an Ok response back", country, mainSite), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from the following Brother Online Sites on the UAT envir" +
            "onment")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://online.ie.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://online.uk.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "https://online.es.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Poland", "https://online.pl.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "https://online.de.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Slovakia", "https://online.sk.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("France", "https://online.fr.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "https://online.nl.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Russia", "https://online.ru.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Portugal", "https://online.pt.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Romania", "https://online.ro.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Czech", "https://online.cz.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Hungary", "https://online.hr.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Belgium", "https://online.be.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Denmark", "https://online.dk.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "https://online.ch.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Slovenia", "https://online.si.brotherqas.eu/", null)]
        [NUnit.Framework.TestCaseAttribute("Italy", "https://online.it.brotherqas.eu/", null)]
        public virtual void Get200OKResponseBackFromTheFollowingBrotherOnlineSitesOnTheUATEnvironment(string country, string brotherOnline, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from the following Brother Online Sites on the UAT envir" +
                    "onment", @__tags);
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given(string.Format("The following site {0} {1} to validate I should receive an Ok response back", country, brotherOnline), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Creative Centre United Kingdom on the UAT environme" +
            "nt")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void Get200OKResponseBackFromCreativeCentreUnitedKingdomOnTheUATEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Creative Centre United Kingdom on the UAT environme" +
                    "nt", new string[] {
                        "SMOKE"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("The following site \"United Kingdom\" https://creativecenter.eu.brotherqas.eu/ to v" +
                    "alidate I should receive an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
