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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwo.Proposal
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("LeasingAndClickProposalUserJourney")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class LeasingAndClickProposalUserJourneyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LeasingAndClickProposalUserJourney.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "LeasingAndClickProposalUserJourney", "In order to create different variety of leasing proposal\r\nAs a dealer \r\nI want to" +
                    " be able to use different MPS parameters to derive different leasing proposal", ProgrammingLanguage.CSharp, new string[] {
                        "TEST",
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
        [NUnit.Framework.DescriptionAttribute("Create different varieties of Leasing and Click proposal for new customer")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Lease & Click with Service", "Create new customer", "Minimum Volume", "3 years", "4 Monthly Minimum Volume", "6 Monthly Minimum Volume", "HL-L8350CDW", "Full", "2000", "2000", null)]
        public virtual void CreateDifferentVarietiesOfLeasingAndClickProposalForNewCustomer(string role, string country, string contractType, string createOption, string usageType, string contract, string leasing, string billing, string printer, string deviceScreen, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create different varieties of Leasing and Click proposal for new customer", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.And(string.Format("I select \"{0}\" button for customer data capture", createOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I Enter usage type of \"{0}\" and \"{1}\" contract terms \"{2}\" leasing and \"{3}\" bill" +
                        "ing on Term and Type details", usageType, contract, leasing, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", leasing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create different varieties of Leasing and Click proposal for new customer on Pay " +
            "As You Go Term")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Lease & Click with Service", "Create new customer", "Pay As You Go", "4 years", "6 Monthly", "4 Monthly", "DCP-8110DN", "Full", "2000", null)]
        public virtual void CreateDifferentVarietiesOfLeasingAndClickProposalForNewCustomerOnPayAsYouGoTerm(string role, string country, string contractType, string createOption, string usageType, string contract, string leasing, string billing, string printer, string deviceScreen, string clickVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create different varieties of Leasing and Click proposal for new customer on Pay " +
                    "As You Go Term", exampleTags);
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
 testRunner.And(string.Format("I select \"{0}\" button for customer data capture", createOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And(string.Format("I Enter usage type of \"{0}\" and \"{1}\" contract terms \"{2}\" leasing and \"{3}\" bill" +
                        "ing on Term and Type details", usageType, contract, leasing, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And(string.Format("I type in click price volume of \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", leasing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("\"<ColourVolume>\" displayed on proposal Summary Page corresponds to \"<ColourVolume" +
                    ">\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create different varieties of Leasing and Click proposal for an existing customer" +
            "")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Lease & Click with Service", "Minimum Volume", "4 years", "4 Monthly Minimum Volume", "6 Monthly Minimum Volume", "HL-L8350CDW", "Full", "2000", "2000", null)]
        public virtual void CreateDifferentVarietiesOfLeasingAndClickProposalForAnExistingCustomer(string role, string country, string contractType, string usageType, string contract, string leasing, string billing, string printer, string deviceScreen, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create different varieties of Leasing and Click proposal for an existing customer" +
                    "", exampleTags);
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.And("I choose an existing contact from the list of available contacts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And(string.Format("I Enter usage type of \"{0}\" and \"{1}\" contract terms \"{2}\" leasing and \"{3}\" bill" +
                        "ing on Term and Type details", usageType, contract, leasing, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", leasing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create different varieties of Leasing and Click proposal for an existing customer" +
            " on Pay As You Go")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Lease & Click with Service", "Pay As You Go", "5 years", "6 Monthly", "4 Monthly", "DCP-8110DN", "Full", "2000", null)]
        public virtual void CreateDifferentVarietiesOfLeasingAndClickProposalForAnExistingCustomerOnPayAsYouGo(string role, string country, string contractType, string usageType, string contract, string leasing, string billing, string printer, string deviceScreen, string clickVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create different varieties of Leasing and Click proposal for an existing customer" +
                    " on Pay As You Go", exampleTags);
#line 106
this.ScenarioSetup(scenarioInfo);
#line 107
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 108
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
 testRunner.And("I choose an existing contact from the list of available contacts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.And(string.Format("I Enter usage type of \"{0}\" and \"{1}\" contract terms \"{2}\" leasing and \"{3}\" bill" +
                        "ing on Term and Type details", usageType, contract, leasing, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And(string.Format("I type in click price volume of \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", leasing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("\"<ColourVolume>\" displayed on proposal Summary Page corresponds to \"<ColourVolume" +
                    ">\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
