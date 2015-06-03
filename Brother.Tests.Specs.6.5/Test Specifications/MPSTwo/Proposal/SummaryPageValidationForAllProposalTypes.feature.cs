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
    [NUnit.Framework.DescriptionAttribute("SummaryPageValidationForAllProposalTypes")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class SummaryPageValidationForAllProposalTypesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SummaryPageValidationForAllProposalTypes.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SummaryPageValidationForAllProposalTypes", "In order to avoid ambiguity on proposal summary page\r\nAs a dealer\r\nI want to be v" +
                    "erify that proposal summary page is correct for all types of proposal", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Summary Page Validation For Minimum Volume Leasing and Click proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Lease & Click with Service", "Minimum Volume", "3 years", "4 Monthly Minimum Volume", "6 Monthly Minimum Volume", "HL-L8350CDW", "2000", "2000", null)]
        public virtual void SummaryPageValidationForMinimumVolumeLeasingAndClickProposal(string role, string country, string contractType, string usageType, string contract, string leasing, string billing, string deviceScreen, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Summary Page Validation For Minimum Volume Leasing and Click proposal", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.And("I choose an existing contact from the list of available contacts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And(string.Format("I Enter usage type of \"{0}\" and \"{1}\" contract terms \"{2}\" leasing and \"{3}\" bill" +
                        "ing on Term and Type details", usageType, contract, leasing, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I display \"<Printer>\" device screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.Then("the billing basis for product is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
 testRunner.And("the billing basis for Accessory is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("the billing basis for Installation is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("the billing basis for Service Pack is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("the installation type displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("the installation cost displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("the quantity displayed is the same as the one entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("the service pack name and price displayed are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("the displayed volume value for mono click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("the displayed volume value for colour click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("the bank displayed for leasing is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("the calculated net totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("the calculated gross totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("the calculations are not based on estimated values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("leasing panels displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("clicking on the printer link takes me back to the device screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Summary Page Validation For Pay As You Go Leasing and Click proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Lease & Click with Service", "Create new customer", "Pay As You Go", "4 years", "6 Monthly", "4 Monthly", "DCP-8110DN", "Full", "2000", null)]
        public virtual void SummaryPageValidationForPayAsYouGoLeasingAndClickProposal(string role, string country, string contractType, string createOption, string usageType, string contract, string leasing, string billing, string printer, string deviceScreen, string clickVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Summary Page Validation For Pay As You Go Leasing and Click proposal", exampleTags);
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.And(string.Format("I select \"{0}\" button for customer data capture", createOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And(string.Format("I Enter usage type of \"{0}\" and \"{1}\" contract terms \"{2}\" leasing and \"{3}\" bill" +
                        "ing on Term and Type details", usageType, contract, leasing, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And(string.Format("I type in click price volume of \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("the billing basis for product is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
 testRunner.And("the billing basis for Accessory is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("the billing basis for Installation is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("the billing basis for Service Pack is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("the installation type displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("the installation cost displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("the service pack name and price displayed are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("the displayed volume value for mono click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("the bank displayed for leasing is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("the quantity displayed is the same as the one entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("the calculated consumable net totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("the calculated consumable gross totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("the calculations are based on estimated values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("leasing panels displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("clicking on the printer link takes me back to the device screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Summary Page Validation For Minimum Volume Purchase and Click proposal In Click P" +
            "ayment")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "3 years", "4 Monthly Minimum Volume", "6 Monthly Minimum Volume", "Tick", "MFC-L8650CDW", "Full", "Included in Click Price", "2000", "2000", null)]
        public virtual void SummaryPageValidationForMinimumVolumePurchaseAndClickProposalInClickPayment(string role, string country, string contractType, string usageType, string contract, string leasing, string billing, string priceHardware, string printer, string deviceScreen, string paymentMethod, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Summary Page Validation For Minimum Volume Purchase and Click proposal In Click P" +
                    "ayment", exampleTags);
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
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("Service Pack payment method is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.And(string.Format("I choose to pay Service Packs \"{0}\"", paymentMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.Then("the billing basis for product is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
 testRunner.And("the billing basis for Accessory is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("the billing basis for Installation is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("the billing basis for Service Pack is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("the installation type displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("the installation cost displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("the quantity displayed is the same as the one entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("the service pack name and price displayed are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("the displayed volume value for mono click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("the displayed volume value for colour click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("the bank displayed for leasing is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("the calculated net totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("the calculated gross totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("the calculations are not based on estimated values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("leasing panels displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.And("clicking on the printer link takes me back to the device screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Summary Page Validation For Minimum Volume Purchase and Click proposal Upfront Pa" +
            "yment")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "3 years", "4 Monthly Minimum Volume", "6 Monthly Minimum Volume", "Tick", "MFC-L8650CDW", "Full", "Pay Upfront", "2000", "2000", null)]
        public virtual void SummaryPageValidationForMinimumVolumePurchaseAndClickProposalUpfrontPayment(string role, string country, string contractType, string usageType, string contract, string leasing, string billing, string priceHardware, string printer, string deviceScreen, string paymentMethod, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Summary Page Validation For Minimum Volume Purchase and Click proposal Upfront Pa" +
                    "yment", exampleTags);
#line 116
this.ScenarioSetup(scenarioInfo);
#line 117
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 118
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
 testRunner.And("I choose an existing contact from the list of available contacts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("Service Pack payment method is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And(string.Format("I choose to pay Service Packs \"{0}\"", paymentMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.Then("the billing basis for product is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.And("the billing basis for Accessory is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.And("the billing basis for Installation is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.And("the billing basis for Service Pack is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.And("the installation type displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("the installation cost displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.And("the quantity displayed is the same as the one entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.And("the service pack name and price displayed are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("the displayed volume value for mono click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.And("the displayed volume value for colour click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.And("the bank displayed for leasing is \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
 testRunner.And("the calculated net totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
 testRunner.And("the calculated gross totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
 testRunner.And("the calculations are not based on estimated values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
 testRunner.And("leasing panels displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
 testRunner.And("clicking on the printer link takes me back to the device screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
