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
namespace Brother.MPS.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC113.BIG_AT.Proposal
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSGermanPurchaseAndClickProposalUserJourney")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("BIEPC113")]
    public partial class CloudMPSGermanPurchaseAndClickProposalUserJourneyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSPurchaseAndClickProposalGermanUserJourney.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSGermanPurchaseAndClickProposalUserJourney", "In order to create different variety of purchase and click proposal\r\nAs a dealer " +
                    "\r\nI want to be able to use different MPS parameters to derive different leasing " +
                    "proposal", ProgrammingLanguage.CSharp, new string[] {
                        "TEST",
                        "UAT",
                        "MPS",
                        "BIEPC113"});
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
        [NUnit.Framework.DescriptionAttribute("MPS Create MV Proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Austria", "Easy Print Pro & Service", "Create new customer", "Mindestvolumen", "5 Jahre", "Vierteljährlich", "Tick", "MFC-L8650CDW", "Full", "im Voraus bezahlen", "800", "800", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", "Easy Print Pro & Service", "Create new customer", "Mindestvolumen", "5 Jahre", "Vierteljährlich", "Tick", "MFC-L8650CDW", "Full", "im Voraus bezahlen", "800", "800", null)]
        public virtual void MPSCreateMVProposal(string role, string country, string contractType, string createOption, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string paymentMethod, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Create MV Proposal", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("Customer Information tab is not displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And(string.Format("I select service pack \"{0}\" payment method", paymentMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("\"<Leasing>\" displayed on proposal Summary Page corresponds to \"<Leasing>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS GermanAustria Create different varieties of German And Austria Purchase and C" +
            "lick proposal for new customer on Pay As You Go Term")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", "Easy Print Pro & Service", "Create new customer", "Pay As You Go", "3 Jahre", "Halbjährlich", "Tick", "MFC-8510DN", "Full", "750", null)]
        public virtual void MPSGermanAustriaCreateDifferentVarietiesOfGermanAndAustriaPurchaseAndClickProposalForNewCustomerOnPayAsYouGoTerm(string role, string country, string contractType, string createOption, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string clickVolume, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS GermanAustria Create different varieties of German And Austria Purchase and C" +
                    "lick proposal for new customer on Pay As You Go Term", @__tags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.And(string.Format("I select \"{0}\" button for customer data capture", createOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And(string.Format("I type in click price volume of \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("\"<Leasing>\" displayed on proposal Summary Page corresponds to \"<Leasing>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("\"<ColourVolume>\" displayed on proposal Summary Page corresponds to \"<ColourVolume" +
                    ">\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Create Proposal With Existing Customer")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", "Easy Print Pro & Service", "Create new customer", "Mindestvolumen", "5 Jahre", "Vierteljährlich", "Tick", "MFC-L8650CDW", "Full", "über den Seitenpreis zahlen", "800", "800", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Austria", "Easy Print Pro & Service", "Create new customer", "Mindestvolumen", "5 Jahre", "Vierteljährlich", "Tick", "MFC-L8650CDW", "Full", "über den Seitenpreis zahlen", "800", "800", null)]
        public virtual void MPSCreateProposalWithExistingCustomer(string role, string country, string contractType, string createOption, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string paymentMethod, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Create Proposal With Existing Customer", exampleTags);
#line 71
this.ScenarioSetup(scenarioInfo);
#line 72
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("Customer Information tab is not displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And(string.Format("I select service pack \"{0}\" payment method", paymentMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("Service Pack In Click line is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.And("\"<Leasing>\" displayed on proposal Summary Page corresponds to \"<Leasing>\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS GermanAustria Create different varieties of German And Austria Purchase and C" +
            "lick proposal for an existing customer on Pay As You Go Term")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Germany", "Easy Print Pro & Service", "Pay As You Go", "5 years", "Quarterly", "Quarterly", "Tick", "MFC-8510DN", "Full", "3000", null)]
        public virtual void MPSGermanAustriaCreateDifferentVarietiesOfGermanAndAustriaPurchaseAndClickProposalForAnExistingCustomerOnPayAsYouGoTerm(string role, string country, string contractType, string usageType, string contract, string leasing, string billing, string priceHardware, string printer, string deviceScreen, string clickVolume, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS GermanAustria Create different varieties of German And Austria Purchase and C" +
                    "lick proposal for an existing customer on Pay As You Go Term", @__tags);
#line 104
this.ScenarioSetup(scenarioInfo);
#line 105
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 106
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.And("I choose an existing contact from the list of available contacts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.And("enter a quantity of \"2\" for model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And(string.Format("I type in click price volume of \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", leasing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And("\"<ColourVolume>\" displayed on proposal Summary Page corresponds to \"<ColourVolume" +
                    ">\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
