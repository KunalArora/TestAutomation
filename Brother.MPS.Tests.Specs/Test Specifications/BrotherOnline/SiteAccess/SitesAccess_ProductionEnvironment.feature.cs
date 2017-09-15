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
namespace Brother.Tests.Specs.TestSpecifications.BrotherOnline.SiteAccess
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AccessAllProductionSites")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    public partial class AccessAllProductionSitesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SitesAccess_ProductionEnvironment.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AccessAllProductionSites", "\tIn order to validate the status of a Websites on the Production environment\r\n\tAs" +
                    " a sanity check\r\n\tWe need to receive a 200 OK request back from a list of select" +
                    "ed sites", ProgrammingLanguage.CSharp, new string[] {
                        "UAT",
                        "PROD"});
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
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Main Site \"<Country>\" on the LIVE environme" +
            "nt")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
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
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Main Site \"<Country>\" on the LIVE environme" +
                    "nt", @__tags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Brother Online \"<Country>\" on the LIVE environment")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
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
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Brother Online \"<Country>\" on the LIVE environment", @__tags);
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Web Conferencing \"<Country>\" on the LIVE environmen" +
            "t")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "http://webconferencing.brother.co.uk/", null)]
        [NUnit.Framework.TestCaseAttribute("France", "http://webconference.brother.fr/", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "http://visioconference.brother.ch/", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "http://webconferencing.brother.ie/", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "http://videokonferenzen.brother.de/", null)]
        public virtual void Get200OKResponseBackFromWebConferencingCountryOnTheLIVEEnvironment(string country, string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Web Conferencing \"<Country>\" on the LIVE environmen" +
                    "t", @__tags);
#line 69
this.ScenarioSetup(scenarioInfo);
#line 70
 testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Creative Centre \"<Country>\" on the LIVE environment" +
            "")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://creativecenter.brother.eu", null)]
        public virtual void Get200OKResponseBackFromCreativeCentreCountryOnTheLIVEEnvironment(string country, string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Creative Centre \"<Country>\" on the LIVE environment" +
                    "", @__tags);
#line 82
this.ScenarioSetup(scenarioInfo);
#line 83
 testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test all CD servers on Live Environment")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
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
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
  testRunner.Given(string.Format("The following site \"{0}\" to validate I should receive an Ok response back", brotherSite), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Test CD servers on Live Environment to check user registration")]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web1.online.brother.ie", "Web_1", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web2.online.brother.ie", "Web_2", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://web1.online.brother.co.uk", "Web_1", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://web2.online.brother.co.uk", "Web_2", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("France", "https://web5.online.brother.fr", "Web_5", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("France", "https://web6.online.brother.fr", "Web_6", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "https://web5.online.brother.de", "Web_5", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "https://web6.online.brother.de", "Web_6", "Test", "User", null)]
        public virtual void TestCDServersOnLiveEnvironmentToCheckUserRegistration(string country, string web, string serverName, string firstName, string lastName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test CD servers on Live Environment to check user registration", exampleTags);
#line 350
this.ScenarioSetup(scenarioInfo);
#line 351
   testRunner.Given(string.Format("I navigate to BOL \"{0}\" for \"{1}\"", web, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 352
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
#line 353
 testRunner.When("I fill in the registration information using a valid email address", ((string)(null)), table1, "When ");
#line 360
    testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 361
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 362
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 363
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 364
 testRunner.And("Once I have Validated an Email was received and verified my account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 365
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 366
 testRunner.Then(string.Format("I should be able to log into \"{0}\" Brother Online using my account details", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 367
 testRunner.When(string.Format("I navigate to my account for \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 368
 testRunner.And(string.Format("I enter First Name containing {0}", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 369
 testRunner.And(string.Format("I enter the Last Name containing {0}", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 370
 testRunner.And("I click on update details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 371
 testRunner.Then("my personal details should get updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 372
 testRunner.Then("I can navigate back to Brother Online home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 373
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("View  list of available Laser Printers")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "printers/all-mono-lasers", "http://www.web1.brother.co.uk/", null)]
        [NUnit.Framework.TestCaseAttribute("Germany", "drucker/alle-lasergeraete/farblaser", "http://www.web2.brother.de", null)]
        [NUnit.Framework.TestCaseAttribute("France", "imprimantes/imprimantes-laser", "http://www.web5.brother.fr", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "printers/laser-printers/mono-laser-printers", "http://www.web6.brother.ie", null)]
        [NUnit.Framework.TestCaseAttribute("Netherlands", "printers/laserprinters/zwart-wit", "http://www.web1.brother.nl", null)]
        [NUnit.Framework.TestCaseAttribute("Norway", "printers/all-mono-lasers", "http://www.web2.brother.no", null)]
        [NUnit.Framework.TestCaseAttribute("Belgium", "printers/all-in-one-printers", "http://www.web5.brother.be", null)]
        [NUnit.Framework.TestCaseAttribute("Russia", "printers/laser-printers/mono-laser-printers", "http://www.web6.brother.ru", null)]
        [NUnit.Framework.TestCaseAttribute("Spain", "impresoras/impresoras-laser/impresoras-laser-monocromo", "http://www.web1.brother.es", null)]
        [NUnit.Framework.TestCaseAttribute("Italy", "printers-and-all-in-one/gamma-stampanti", "http://www.web2.brother.it", null)]
        [NUnit.Framework.TestCaseAttribute("Poland", "printers/laser-printers/", "http://www.web1.brother.pl", null)]
        [NUnit.Framework.TestCaseAttribute("Switzerland", "drucker/laserdrucker/mono-laser-printers", "http://www.web2.brother.ch", null)]
        public virtual void ViewListOfAvailableLaserPrinters(string country, string site, string web, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View  list of available Laser Printers", @__tags);
#line 388
this.ScenarioSetup(scenarioInfo);
#line 389
    testRunner.Given(string.Format("I navigate to  \"{0}\" for \"{1}\"", web, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 390
 testRunner.When(string.Format("I have navigated to the \"{0}\" MainSite URL for country \"{1}\"", site, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 391
 testRunner.Then("I should see list of printers once loaded page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create B2C account and sign Up for 14 day Free trial on uk")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "https://web1.online.brother.co.uk", null)]
        public virtual void CreateB2CAccountAndSignUpFor14DayFreeTrialOnUk(string country, string web, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create B2C account and sign Up for 14 day Free trial on uk", @__tags);
#line 411
this.ScenarioSetup(scenarioInfo);
#line 412
 testRunner.Given(string.Format("I navigate to BOL \"{0}\" for \"{1}\"", web, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 413
 testRunner.When("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 414
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table2.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table2.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table2.AddRow(new string[] {
                        "Password",
                        "@@@@@"});
            table2.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 415
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table2, "And ");
#line 421
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 422
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 423
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 424
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 425
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 426
 testRunner.Then(string.Format("I should be able to log into \"{0}\" and \"{1}\" Brother site using my account detail" +
                        "s", web, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 427
 testRunner.And("I have navigated to the OmniJoin home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 428
 testRunner.And("If I click on Start Free Trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 429
    testRunner.Then("I should be directed to the OmniJoin Free Trial page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 430
   testRunner.When("I have entered a valid First and Last name, \"AutoTest\", \"AutoTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 431
   testRunner.And("I have entered a valid email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 432
   testRunner.And("I have entered a valid password and confirmpassword, \"Brother123\", \"Brother123\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 433
   testRunner.When("I have entered a valid phone number \"01555 522522\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 434
    testRunner.And("I have Agreed to the Free Trial Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 435
 testRunner.And("if I click Submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 436
 testRunner.Then("I should be directed to the download page indicating I have 14 days Free trial", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create a B2C account and Sign Up for 14 day Free trial already signed into Irelan" +
            "d Brother site on Test CD servers Live Environment")]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web1.online.brother.ie", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web2.online.brother.ie", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web5.online.brother.ie", "Test", "User", null)]
        [NUnit.Framework.TestCaseAttribute("Ireland", "https://web6.online.brother.ie", "Test", "User", null)]
        public virtual void CreateAB2CAccountAndSignUpFor14DayFreeTrialAlreadySignedIntoIrelandBrotherSiteOnTestCDServersLiveEnvironment(string country, string web, string firstName, string lastName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a B2C account and Sign Up for 14 day Free trial already signed into Irelan" +
                    "d Brother site on Test CD servers Live Environment", exampleTags);
#line 448
 this.ScenarioSetup(scenarioInfo);
#line 449
 testRunner.Given(string.Format("I navigate to BOL \"{0}\" for \"{1}\"", web, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 450
 testRunner.When("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 451
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table3.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table3.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table3.AddRow(new string[] {
                        "Password",
                        "@@@@@"});
            table3.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 452
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table3, "And ");
#line 459
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 460
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 461
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 462
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 463
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 464
 testRunner.Then(string.Format("I should be able to log into \"{0}\" Brother Online using my account details", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 465
 testRunner.And("I click on Try Now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 466
 testRunner.Then("I should see OmniJOin Free trail page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 467
 testRunner.When(string.Format("I have entered a valid FirstName as \"{0}\"", firstName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 468
 testRunner.And(string.Format("I have  entered a valid LastName as \"{0}\"", lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 469
 testRunner.And("I entered a valid email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 470
 testRunner.And("I agreed to the free trail terms and services", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 471
  testRunner.And("I click start free trail button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 472
 testRunner.Then("I should be on download page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 473
 testRunner.And("Once I have Validated a Free Trial confirmation Email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 474
 testRunner.Then("If I go back to Brother Online Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 475
 testRunner.Then(string.Format("If I go back to Brother Site home page on \"{0}\" and \"{1}\"", web, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 476
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 477
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
