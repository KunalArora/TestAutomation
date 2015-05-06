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
    [NUnit.Framework.DescriptionAttribute("AccessAllSites")]
    [NUnit.Framework.IgnoreAttribute()]
    public partial class AccessAllSitesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SiteAccess_TestSites.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AccessAllSites", "In order to validate the status of a Websites on the Test environment\r\nAs a sanit" +
                    "y check\r\nWe need to receive a 200 OK request back from a list of selected sites", ProgrammingLanguage.CSharp, new string[] {
                        "ignore"});
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
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Credit Card test Site at Digital River")]
        public virtual void Get200OKResponseBackFromCreditCardTestSiteAtDigitalRiver()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Credit Card test Site at Digital River", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given(@"The following site test site ""https://testpage.payments.digitalriver.com/pay/?creq=BEii9whIovYlcGLxmfpW6BbtbwV8_Xdk8eulgVCMGaCTa5tOw9muh0vlW3Ssy5q-yR3VkBJrejq5rzxpEV_Q2Dk4Y828PQ4ry3SHMArP--5Yx_mmfVFGW54xZ_ZPXDFrpicvXPqlwSometDrmeMIHKakP096tQsIZkNqnwRbxCfIcoPNHd-fM8k9h38WIwtupxClzqdvbYGVeMt026yRAvJon6hYH9kDw3A-weaTf_5qytndiGB5q1XKiNFM_x7FvBOtUCbYR_ic-aGJlKU4rDTbDJ4fOzKz1qmkJ2LMw3H1nrei1FI5aRPbZoN2UtsFHyuPQ9r7UCuHzj4o2_GTHc0IiGyJA1lQZbSRUKtejiCiEMI2DErwxuKCc15uz7Qiu-fvZw0XJZ0WAgCcSNL129yFT8TJpCSwsrOrgHowWvOkrYYC8ek77OkyxvVJ-9b1dfKfMJ-PTlG__kw7S-zZgGRHa3ZGyLkjU-cs-Uj7lTN-Ix4oR7FmHRFcdiIbRHeDHoS7SVsAZZRSgX2OYWj_RwN-WrGYJgyeaacNo4wb8s4EhCb56Nnq6Ycm0RZej6oWFCqvFJyD77HENyOPB4t9Sp7Bd1dvjj21bXhACZmrh930hkopctYK-b9h8FgGjlrWcU_QLIdqkBn0"" to validate I should receive an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Email Token TEST Site United Kingdom on the Test en" +
            "vironment")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.CategoryAttribute("TEST")]
        public virtual void Get200OKResponseBackFromEmailTokenTESTSiteUnitedKingdomOnTheTestEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Email Token TEST Site United Kingdom on the Test en" +
                    "vironment", new string[] {
                        "TEST",
                        "ignore"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("The following site test site \"http://online.uk.brotherdv2.eu/Test/EmailConfirmati" +
                    "onToken.aspx\" to validate I should receive an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Email Token UAT Site United Kingdom on the QAS envi" +
            "ronment")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.CategoryAttribute("UAT")]
        public virtual void Get200OKResponseBackFromEmailTokenUATSiteUnitedKingdomOnTheQASEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Email Token UAT Site United Kingdom on the QAS envi" +
                    "ronment", new string[] {
                        "UAT",
                        "ignore"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("The following site test site \"http://cms.brotherqas.eu/Test/EmailConfirmationToke" +
                    "n.aspx\" to validate I should receive an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get 200 OK response back from Email Token Production Site United Kingdom on the L" +
            "ive environment")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.CategoryAttribute("PROD")]
        public virtual void Get200OKResponseBackFromEmailTokenProductionSiteUnitedKingdomOnTheLiveEnvironment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get 200 OK response back from Email Token Production Site United Kingdom on the L" +
                    "ive environment", new string[] {
                        "PROD",
                        "ignore"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("The following site test site \"http://cms.brother.eu/Test/EmailConfirmationToken.a" +
                    "spx\" to validate I should receive an Ok response back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
