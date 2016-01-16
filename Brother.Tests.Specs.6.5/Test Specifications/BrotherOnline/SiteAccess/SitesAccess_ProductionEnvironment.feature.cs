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
    [NUnit.Framework.DescriptionAttribute("AccessAllProductionSites")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("SMOKE")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    public partial class AccessAllProductionSitesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SitesAccess_ProductionEnvironment.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AccessAllProductionSites", "In order to validate the status of a Websites on the Production environment\r\nAs a" +
                    " sanity check\r\nWe need to receive a 200 OK request back from a list of selected " +
                    "sites", ProgrammingLanguage.CSharp, new string[] {
                        "TEST",
                        "SMOKE",
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
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Main Site \"<Country>\" on the LIVE environme" +
            "nt")]
        [NUnit.Framework.TestCaseAttribute("Ireland", "http://www.brother.ie/", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "http://www.brother.de/", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "http://www.brother.co.uk/", null)]
        [NUnit.Framework.TestCaseAttribute("France", "http://www.brother.fr/", null)]
        [NUnit.Framework.TestCaseAttribute("Austria", "http://www.brother.at/", null)]
        [NUnit.Framework.TestCaseAttribute("Poland", "http://www.brother.pl/", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "http://www.brother.ch/", null)]
        [NUnit.Framework.TestCaseAttribute("Belgium", "http://www.brother.be/", null)]
        [NUnit.Framework.TestCaseAttribute("Italy", "http://www.brother.it/", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "http://www.brother.nl/", null)]
        [NUnit.Framework.TestCaseAttribute("Denmark", "http://www.brother.dk/", null)]
        [NUnit.Framework.TestCaseAttribute("Finland", "http://www.brother.fi/", null)]
        [NUnit.Framework.TestCaseAttribute("Norway", "http://www.brother.no/", null)]
        [NUnit.Framework.TestCaseAttribute("Sweden", "http://www.brother.se/", null)]
        [NUnit.Framework.TestCaseAttribute("Portugal", "http://www.brother.pt/", null)]
        [NUnit.Framework.TestCaseAttribute("Czech Republic", "http://www.brother.cz/", null)]
        [NUnit.Framework.TestCaseAttribute("Russia", "http://www.brother.ru/", null)]
        [NUnit.Framework.TestCaseAttribute("Slovenia", "http://www.brother.si/", null)]
        [NUnit.Framework.TestCaseAttribute("Luxembourg", "http://www.brother.lu/", null)]
        public virtual void Get200OKResponseBackFromBrotherMainSiteCountryOnTheLIVEEnvironment(string country, string siteUrl, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Main Site \"<Country>\" on the LIVE environme" +
                    "nt", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Online \"<Country>\" on the LIVE environment")]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://online.brother.ie/", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "https://online.brother.es/", null)]
        [NUnit.Framework.TestCaseAttribute("Poland", "https://online.brother.pl/", null)]
        [NUnit.Framework.TestCaseAttribute("France", "https://online.brother.fr/", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://online.brother.co.uk/", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "https://online.brother.de/", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "https://online.brother.ch/", null)]
        [NUnit.Framework.TestCaseAttribute("Austria", "https://online.brother.at/", null)]
        [NUnit.Framework.TestCaseAttribute("Belgium", "https://online.brother.be/", null)]
        [NUnit.Framework.TestCaseAttribute("Italy", "https://online.brother.it/", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "https://online.brother.nl/", null)]
        [NUnit.Framework.TestCaseAttribute("Denmark", "https://online.brother.dk/", null)]
        [NUnit.Framework.TestCaseAttribute("Finland", "https://online.brother.fi/", null)]
        [NUnit.Framework.TestCaseAttribute("Norway", "https://online.brother.no/", null)]
        [NUnit.Framework.TestCaseAttribute("Sweden", "https://online.brother.se/", null)]
        [NUnit.Framework.TestCaseAttribute("Portugal", "https://online.brother.pt/", null)]
        [NUnit.Framework.TestCaseAttribute("Czech Republic", "https://online.brother.cz/", null)]
        [NUnit.Framework.TestCaseAttribute("Russia", "https://online.brother.ru/", null)]
        [NUnit.Framework.TestCaseAttribute("Slovenia", "https://online.brother.si/", null)]
        [NUnit.Framework.TestCaseAttribute("Luxembourg", "https://online.brother.lu/", null)]
        public virtual void Get200OKResponseBackFromBrotherOnlineCountryOnTheLIVEEnvironment(string country, string siteUrl, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Online \"<Country>\" on the LIVE environment", exampleTags);
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Web Conferencing \"<Country>\" on the LIVE environmen" +
            "t")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "http://webconferencing.brother.co.uk/", null)]
        [NUnit.Framework.TestCaseAttribute("France", "http://webconference.brother.fr/", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "http://visioconference.brother.ch/", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "http://webconferencing.brother.ie/", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "http://videokonferenzen.brother.de/", null)]
        public virtual void Get200OKResponseBackFromWebConferencingCountryOnTheLIVEEnvironment(string country, string siteUrl, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Web Conferencing \"<Country>\" on the LIVE environmen" +
                    "t", exampleTags);
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Creative Centre \"<Country>\" on the LIVE environment" +
            "")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://creativecenter.brother.eu", null)]
        public virtual void Get200OKResponseBackFromCreativeCentreCountryOnTheLIVEEnvironment(string country, string siteUrl, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Creative Centre \"<Country>\" on the LIVE environment" +
                    "", exampleTags);
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
 testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test all CD servers on Live Environment")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.at", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.es", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.fr", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.co.uk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.cz", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.dk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.nl", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.hu", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.no", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.pt", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.ru", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.fi", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.lu", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.bg", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.ro", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.sk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.si", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.co.uk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.at", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.fr", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.nl", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.lu", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.pt", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.es", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.dk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.no", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.fi", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.lt", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.ee", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.is", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.lv", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.cz", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.sk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.si", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.hu", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.hr", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.bg", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "http://www.web1.brother.ro", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.at", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.es", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.fr", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.co.uk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.cz", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.dk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.nl", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.hu", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.no", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.pt", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.ru", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.fi", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.lu", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.ru", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.bg", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.ro", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.sk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "https://web2.online.brother.si", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.at", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.fr", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.nl", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.pt", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.es", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.no", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.dk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.fi", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.lt", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.lv", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.is", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.ee", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.cz", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.sk", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.si", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.hu", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.hr", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.bg", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.ro", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.132", "http://www.web2.brother.ru", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.at", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.es", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.fr", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.co.uk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.cz", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.dk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.nl", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.hu", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.no", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.pt", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.ru", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.fi", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.lu", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.bg", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.ro", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.sk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "https://web5.online.brother.si", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.co.uk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.at", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.fr", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.lu", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.pt", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.es", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.dk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.no", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.fi", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.lt", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.lv", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.is", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.ee", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.cz", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.sk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.si", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.hu", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.hr", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.bg", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.ro", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.133", "http://www.web5.brother.ru", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.at", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.co.uk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.cz", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.dk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.nl", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.hu", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.no", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.pt", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.ru", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.fi", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.lu", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.bg", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.ro", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.sk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "https://web6.online.brother.si", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.co.uk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.at", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.fr", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.nl", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.ch", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.pt", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.es", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.dk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.se", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.fi", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.lu", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.lt", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.lv", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.is", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.ee", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.cz", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.sk", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.si", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.hu", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.hr", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.bg", null)]
        [NUnit.Framework.TestCaseAttribute("172.27.16.134", "http://www.web6.brother.ru", null)]
        public virtual void TestAllCDServersOnLiveEnvironment(string pRODUCTIONCDSERVERS, string brotherSite, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test all CD servers on Live Environment", @__tags);
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
  testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", brotherSite), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
