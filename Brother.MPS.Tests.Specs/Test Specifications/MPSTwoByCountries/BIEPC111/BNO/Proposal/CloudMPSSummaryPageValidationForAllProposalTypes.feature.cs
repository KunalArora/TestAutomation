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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC111.BNO.Proposal
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSSummaryPageValidationForAllNorwegianProposalTypes")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("BIEPC111")]
    public partial class CloudMPSSummaryPageValidationForAllNorwegianProposalTypesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSSummaryPageValidationForAllProposalTypes.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSSummaryPageValidationForAllNorwegianProposalTypes", "\tIn order to avoid ambiguity on proposal summary page\r\n\tAs a dealer\r\n\tI want to b" +
                    "e verify that proposal summary page is correct for all types of proposal", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "TEST",
                        "UAT",
                        "BIEPC111"});
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
        [NUnit.Framework.DescriptionAttribute("Summary Page Validation For Minimum Volume Purchase and Click proposal In Click P" +
            "ayment")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Norway", "Kjøp og klikk med service", "Minimum volum", "36", "Quarterly in Arrears", "Tick", "MFC-L8650CDW", "Full", "I klikk", "800", "800", "I klikk", "På forskudd", null)]
        public virtual void SummaryPageValidationForMinimumVolumePurchaseAndClickProposalInClickPayment(string role, string country, string contractType, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string paymentMethod, string clickVolume, string colourVolume, string basis1, string basis2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Summary Page Validation For Minimum Volume Purchase and Click proposal In Click P" +
                    "ayment", exampleTags);
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
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And(string.Format("I select service pack \"{0}\" payment method", paymentMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("enter a quantity of \"1\" for accessory for \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And(string.Format("I redisplay \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I confirm the values entered for the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("Service Pack In Click line is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.Then(string.Format("the billing basis for product is \"{0}\"", basis2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.And(string.Format("the billing basis for Accessory is \"{0}\"", basis2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And(string.Format("the billing basis for Installation is \"{0}\"", basis2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And(string.Format("the billing basis for Service Pack is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("the installation type displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("the installation cost displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("the quantity displayed is the same as the one entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("service pack cost is included click as \"kr 0,00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And(string.Format("the displayed volume value for mono click price is \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And(string.Format("the displayed volume value for colour click price is \"{0}\"", colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("the calculated consumable net totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("the calculated consumable gross totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("the displayed mono click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("the displayed colour click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("the calculations are not based on estimated values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And(string.Format("clicking on the displayed printer \"{0}\" link takes me back to the device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Summary Page Validation For Minimum Volume Purchase and Click proposal Upfront Pa" +
            "yment")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Norway", "Kjøp og klikk med service", "Minimum volum", "36", "Quarterly in Arrears", "Tick", "MFC-L8650CDW", "Full", "På forskudd", "800", "800", "På forskudd", null)]
        public virtual void SummaryPageValidationForMinimumVolumePurchaseAndClickProposalUpfrontPayment(string role, string country, string contractType, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string paymentMethod, string clickVolume, string colourVolume, string basis1, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Summary Page Validation For Minimum Volume Purchase and Click proposal Upfront Pa" +
                    "yment", exampleTags);
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.And("I choose an existing contact from the list of available contacts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And(string.Format("I select service pack \"{0}\" payment method", paymentMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And(string.Format("enter a quantity of \"1\" for accessory for \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And(string.Format("I redisplay \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I confirm the values entered for the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then(string.Format("the billing basis for product is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.And(string.Format("the billing basis for Accessory is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And(string.Format("the billing basis for Installation is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And(string.Format("the billing basis for Service Pack is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("the installation type displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("the installation cost displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("the quantity displayed is the same as the one entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("the service pack name and price displayed are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And(string.Format("the displayed volume value for mono click price is \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And(string.Format("the displayed volume value for colour click price is \"{0}\"", colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("the calculated consumable net totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("the calculated consumable gross totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("the displayed mono click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("the displayed colour click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("the calculations are not based on estimated values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And(string.Format("clicking on the displayed printer \"{0}\" link takes me back to the device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Summary Page Validation For Pay As you Go Purchase and Click proposal")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Norway", "Kjøp og klikk med service", "Create new customer", "Betale ved forbruk", "48", "Quarterly in Arrears", "Tick", "MFC-8510DN", "Full", "800", "På forskudd", null)]
        public virtual void SummaryPageValidationForPayAsYouGoPurchaseAndClickProposal(string role, string country, string contractType, string createOption, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string clickVolume, string basis1, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Summary Page Validation For Pay As you Go Purchase and Click proposal", exampleTags);
#line 83
this.ScenarioSetup(scenarioInfo);
#line 84
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 85
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.And(string.Format("I select \"{0}\" button for customer data capture", createOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And(string.Format("enter a quantity of \"1\" for accessory for \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And(string.Format("I redisplay \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("I confirm the values entered for the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And(string.Format("I type in click price volume of \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.Then(string.Format("the billing basis for product is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
 testRunner.And(string.Format("the billing basis for Accessory is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And(string.Format("the billing basis for Installation is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And(string.Format("the billing basis for Service Pack is \"{0}\"", basis1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("the installation type displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("the installation cost displayed is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("the quantity displayed is the same as the one entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("the service pack name and price displayed are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And(string.Format("the displayed volume value for mono click price is \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("the calculated consumable net totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.And("the calculated consumable gross totals are equal in all places", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And("the displayed mono click price is correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.And("the calculations are based on estimated values", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.And(string.Format("clicking on the displayed printer \"{0}\" link takes me back to the device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
