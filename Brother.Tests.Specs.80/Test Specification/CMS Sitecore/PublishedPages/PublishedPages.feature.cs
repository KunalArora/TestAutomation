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
namespace Brother.Tests.Specs._80.TestSpecification.CMSSitecore.PublishedPages
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PublishedPages")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("PROD")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("SMOKE")]
    public partial class PublishedPagesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PublishedPages.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PublishedPages", "In order to validate the success of a new build, \r\npreviously published pages are" +
                    " verified to ensure \r\na CMS code change has not had an adverse effect", ProgrammingLanguage.CSharp, new string[] {
                        "UAT",
                        "PROD",
                        "TEST",
                        "SMOKE"});
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
        [NUnit.Framework.DescriptionAttribute("Navigate to published page to verify all page components")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherdv2.eu/qa/testautomationpleaseleave", null)]
        public virtual void NavigateToPublishedPageToVerifyAllPageComponents(string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to published page to verify all page components", @__tags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given(string.Format("That I navigate to \"{0}\" in order to validate a published page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.Then("I can verify that the page header is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.Then("I can verify that the search icon is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.Then("I can verify that the top navigation component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.Then("I can verify that the accordion compoment is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.Then("I can verify that the features carousel component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.Then("I can verify that a features carousel tile is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.Then("I can verify that a banner bar component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.Then("I can verify that the secondary navigation component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.Then("I can verify that the breadcrumbs component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.Then("I can verify the case study component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
 testRunner.Then("I can verify that the contact bar component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.Then("I can verify that the benefit bar component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.Then("I can verify that the benefit bar tile component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.Then("I can verify that the latest news component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.Then("I can verify that the header bar component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.Then("I can verify that the full info tile component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.Then("I can verify that the hero component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.Then("I can verify that the secondary hero component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
 testRunner.Then("I can verify that the feature module image left is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.Then("I can verify that the feature module image right is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.Then("I can verify that the feature bar component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.Then("I can verify that the feature bar tile is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.Then("I can verify that the super carousel component is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.Then("I can verify that the video list module is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.Then("I can verify that the video tile bar is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.Then("I can verify that the full width hero is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.Then("I can verify that the special full info is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.Then("I can verify that the conversion bar is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.Then("I can verify that the wizard is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.Then("I can verify that the special feature is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.Then("I can verify that the steps bar is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.Then("I can verify that the hero carousel is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.Then("I can verify that the wizard step is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.Then("I can verify that the rich text module is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.Then("I can Verify that the link list item is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Navigate to published page to verify product page - UK")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/DCPL8400CDN", null)]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/DCP9020CDW", null)]
        public virtual void NavigateToPublishedPageToVerifyProductPage_UK(string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to published page to verify product page - UK", @__tags);
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given(string.Format("That I navigate to \"{0}\" in order to validate a published page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.Then("I can validate the product page title is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Navigate to published page to verify supplies product page - UK")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/HGe131V5-Suppli" +
            "esPage", null)]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/AD18ESUK", null)]
        public virtual void NavigateToPublishedPageToVerifySuppliesProductPage_UK(string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to published page to verify supplies product page - UK", @__tags);
#line 75
this.ScenarioSetup(scenarioInfo);
#line 76
 testRunner.Given(string.Format("That I navigate to \"{0}\" in order to validate a published page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 77
 testRunner.Then("I can validate supply description is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Navigate to published page to verify News landing page - UK")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/NewsLandingPage" +
            "", null)]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/News-Landing-Pa" +
            "ge", null)]
        public virtual void NavigateToPublishedPageToVerifyNewsLandingPage_UK(string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to published page to verify News landing page - UK", @__tags);
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
 testRunner.Given(string.Format("That I navigate to \"{0}\" in order to validate a published page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
 testRunner.Then("I can validate article is displayed on the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Navigate to published page to verify Glossary page - UK")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/glossary", null)]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/glossary", null)]
        public virtual void NavigateToPublishedPageToVerifyGlossaryPage_UK(string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to published page to verify Glossary page - UK", @__tags);
#line 99
this.ScenarioSetup(scenarioInfo);
#line 100
 testRunner.Given(string.Format("That I navigate to \"{0}\" in order to validate a published page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 101
 testRunner.Then("I can validate glossary section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Navigate to published page to verify Printer Listing page - UK")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/All-Printers", null)]
        public virtual void NavigateToPublishedPageToVerifyPrinterListingPage_UK(string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to published page to verify Printer Listing page - UK", @__tags);
#line 111
this.ScenarioSetup(scenarioInfo);
#line 112
 testRunner.Given(string.Format("That I navigate to \"{0}\" in order to validate a published page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 113
 testRunner.Then("I can validate printers filter section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Navigate to published page to verify Supplies page - UK")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherdv2.eu/QA/TestAutomationPleaseDoNotTouch/AD18ESUK", null)]
        [NUnit.Framework.TestCaseAttribute("http://main.co.uk.brotherqas.eu/QA/TestAutomationPleaseDoNotTouch/HGe131V5", null)]
        public virtual void NavigateToPublishedPageToVerifySuppliesPage_UK(string siteUrl, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to published page to verify Supplies page - UK", @__tags);
#line 121
this.ScenarioSetup(scenarioInfo);
#line 122
 testRunner.Given(string.Format("That I navigate to \"{0}\" in order to validate a published page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 123
 testRunner.Then("I can validate supplies section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
