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
    [NUnit.Framework.DescriptionAttribute("CloudMPSPurchaseAndClickProposalUserJourney")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    public partial class CloudMPSPurchaseAndClickProposalUserJourneyFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSPurchaseAndClickProposalUserJourney.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSPurchaseAndClickProposalUserJourney", "In order to create different variety of purchase and click proposal\r\nAs a dealer " +
                    "\r\nI want to be able to use different MPS parameters to derive different leasing " +
                    "proposal", ProgrammingLanguage.CSharp, new string[] {
                        "TEST",
                        "UAT",
                        "MPS"});
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
        [NUnit.Framework.DescriptionAttribute("Create different varieties of Purchase and Click proposal for new customer on Min" +
            "imum Volume Term")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Purchase & Click with Service", "Create new customer", "Minimum Volume", "3 years", "Quarterly in Arrears", "Tick", "MFC-L8650CDW", "Full", "Pay upfront", "800", "800", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "France", "Buy & Click", "Create new customer", "Engagement sur un minimum volume de pages", "4 ans", "Trimestrale anticipata", "Tick", "MFC-L8650CDW", "Full", "Pay upfront", "800", "800", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Italy", "Acquisto & Consumo", "Create new customer", "Volume minimo", "48", "Trimestrale anticipata", "Tick", "MFC-L8650CDW", "Full", "Pagamento anticipato", "800", "800", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Spain", "Purchase & Click con Service", "Create new customer", "Volúmen mínimo", "3 años", "Por trimestres vencidos", "Tick", "MFC-L8650CDW", "Full", "Pago por adelantado", "800", "800", null)]
        public virtual void CreateDifferentVarietiesOfPurchaseAndClickProposalForNewCustomerOnMinimumVolumeTerm(string role, string country, string contractType, string createOption, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string paymentMethod, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create different varieties of Purchase and Click proposal for new customer on Min" +
                    "imum Volume Term", exampleTags);
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
#line 13
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("Service Pack payment method is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And(string.Format("I choose to pay Service Packs \"{0}\"", paymentMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
        [NUnit.Framework.DescriptionAttribute("Create different varieties of Purchase and Click proposal for new customer on Pay" +
            " As You Go Term")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Purchase & Click with Service", "Create new customer", "Pay As You Go", "4 years", "Quarterly in Arrears", "Tick", "MFC-8510DN", "Full", "750", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "France", "Buy & Click", "Create new customer", "Paiement selon la consommation réelle de pages", "4 ans", "Trimestriellement à terme échu", "Tick", "MFC-8510DN", "Full", "750", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Spain", "Purchase & Click con Service", "Create new customer", "Pago por Uso", "4 años", "Por trimestres vencidos", "Tick", "MFC-8510DN", "Full", "750", null)]
        public virtual void CreateDifferentVarietiesOfPurchaseAndClickProposalForNewCustomerOnPayAsYouGoTerm(string role, string country, string contractType, string createOption, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string clickVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create different varieties of Purchase and Click proposal for new customer on Pay" +
                    " As You Go Term", exampleTags);
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.And(string.Format("I select \"{0}\" button for customer data capture", createOption), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("enter a quantity of \"2\" for model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
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
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("\"<ColourVolume>\" displayed on proposal Summary Page corresponds to \"<ColourVolume" +
                    ">\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create different varieties of Purchase and Click proposal for an existing custome" +
            "r")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "3 years", "Quarterly in Arrears", "Tick", "MFC-L8650CDW", "Full", "Included in Click Price", "800", "800", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "3 ans", "Trimestrale anticipata", "Tick", "MFC-L8650CDW", "Full", "Inclus dans le coût à la page", "800", "800", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Italy", "Acquisto & Consumo", "Volume minimo", "36", "Trimestrale anticipata", "Tick", "MFC-L8650CDW", "Full", "Incluso nel click", "800", "800", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "3 años", "Por trimestres vencidos", "Tick", "MFC-L8650CDW", "Full", "Pago por adelantado", "800", "800", null)]
        public virtual void CreateDifferentVarietiesOfPurchaseAndClickProposalForAnExistingCustomer(string role, string country, string contractType, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string paymentMethod, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create different varieties of Purchase and Click proposal for an existing custome" +
                    "r", exampleTags);
#line 79
this.ScenarioSetup(scenarioInfo);
#line 80
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
 testRunner.And("I choose an existing contact from the list of available contacts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("Service Pack payment method is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And(string.Format("I choose to pay Service Packs \"{0}\"", paymentMethod), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create different varieties of Purchase and Click proposal for an existing custome" +
            "r on Pay As You Go Term")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Purchase & Click with Service", "Pay As You Go", "5 years", "Quarterly in Arrears", "Tick", "MFC-8510DN", "Full", "750", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "France", "Buy & Click", "Paiement selon la consommation réelle de pages", "5 ans", "Trimestriellement à terme échu", "Tick", "MFC-8510DN", "Full", "750", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Spain", "Purchase & Click con Service", "Pago por Uso", "5 años", "Por trimestres vencidos", "Tick", "MFC-8510DN", "Full", "750", null)]
        public virtual void CreateDifferentVarietiesOfPurchaseAndClickProposalForAnExistingCustomerOnPayAsYouGoTerm(string role, string country, string contractType, string usageType, string contract, string billing, string priceHardware, string printer, string deviceScreen, string clickVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create different varieties of Purchase and Click proposal for an existing custome" +
                    "r on Pay As You Go Term", exampleTags);
#line 113
this.ScenarioSetup(scenarioInfo);
#line 114
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 115
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.When(string.Format("I fill Proposal Description for \"{0}\" Contract type", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
 testRunner.And("I choose an existing contact from the list of available contacts", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And(string.Format("I Enter \"{0}\" usage type \"{1}\" contract length and \"{2}\" billing on Term and Type" +
                        " details", usageType, contract, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And(string.Format("I display \"{0}\" device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And(string.Format("\"{0}\" device screen is displayed", deviceScreen), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And("enter a quantity of \"2\" for model", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And("I accept the default values of the device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.And(string.Format("I type in click price volume of \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.Then(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contractType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", contract), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
 testRunner.And(string.Format("\"{0}\" displayed on proposal Summary Page corresponds to \"{0}\"", clickVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.And("\"<ColourVolume>\" displayed on proposal Summary Page corresponds to \"<ColourVolume" +
                    ">\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.And("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
