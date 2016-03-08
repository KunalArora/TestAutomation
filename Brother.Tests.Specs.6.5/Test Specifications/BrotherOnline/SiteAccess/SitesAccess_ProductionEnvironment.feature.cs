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
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("10.91.0.131", "https://web1.online.brother.co.uk", null)]
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test CD servers on Live Environment to check user registration")]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web1.online.brother.ie", "Web_1", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web2.online.brother.ie", "Web_2", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web5.online.brother.ie", "Web_5", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web6.online.brother.ie", "Web_6", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://web1.online.brother.co.uk", "Web_1", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://web2.online.brother.co.uk", "Web_2", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://web5.online.brother.co.uk", "Web_5", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://web6.online.brother.co.uk", "Web_6", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("France", "https://web1.online.brother.fr", "Web_1", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("France", "https://web2.online.brother.fr", "Web_2", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("France", "https://web5.online.brother.fr", "Web_5", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("France", "https://web6.online.brother.fr", "Web_6", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "https://web1.online.brother.de", "Web_1", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "https://web2.online.brother.de", "Web_2", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "https://web5.online.brother.de", "Web_5", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "https://web6.online.brother.de", "Web_6", "Test", "User", null)]
        public virtual void TestCDServersOnLiveEnvironmentToCheckUserRegistration(string country, string web, string serverName, string firstName, string lastName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test CD servers on Live Environment to check user registration", exampleTags);
#line 348
this.ScenarioSetup(scenarioInfo);
#line 349
   testRunner.Given(string.Format("I navigate to BOL \"{0}\" for \"{1}\"", web, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 350
 testRunner.When("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table1.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table1.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table1.AddRow(new string[] {
                        "Password",
                        "@@@@@"});
            table1.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 351
 testRunner.When("I fill in the registration information using a valid email address", ((string)(null)), table1, "When ");
#line 358
    testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 359
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 360
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 361
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 362
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 363
 testRunner.Then(string.Format("I should be able to log into \"{0}\" Brother Online using my account details", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 364
 testRunner.When(string.Format("I navigate to my account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 365
 testRunner.And(string.Format("I enter First Name containing {0}", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 366
 testRunner.And(string.Format("I enter the Last Name containing {0}", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 367
 testRunner.And("I click on update details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 368
 testRunner.Then("my personal details should get updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 369
 testRunner.Then("I can navigate back to Brother Online home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 370
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
