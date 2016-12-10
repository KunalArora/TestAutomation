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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC111.SmokeTest_Cloud_Email
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSFullCloudInstallationForSmokeTest")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("BIEPC111")]
    public partial class CloudMPSFullCloudInstallationForSmokeTestFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSFullCloudInstallation.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSFullCloudInstallationForSmokeTest", "In order to get an installer to begin cloud installation\r\nAs a Dealer \r\nI want to" +
                    " be able to complete cloud installation", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TEST",
                        "BIEPC111"});
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
        [NUnit.Framework.DescriptionAttribute("MPS BUK Cloud Installation")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", null)]
        public virtual void MPSBUKCloudInstallation(string role, string country, string contractType, string usageType, string role1, string method, string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS BUK Cloud Installation", exampleTags);
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given(string.Format("Dealer have created a contract of \"{0}\" and \"{1}\"", contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication and \"{1" +
                        "}\" installation", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I navigate to the Invoice tool homepage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And(string.Format("I select \"{0}\" of interest", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I enter mono and colour print count for a single device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("I generate invoices for the contract above", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS BIGAT Cloud Installation")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Germany", "Easy Print Pro & Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "BOR", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "Germany", "Leasing & Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "Web", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Austria", "Easy Print Pro & Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "BOR", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "Austria", "Leasing & Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "Web", null)]
        public virtual void MPSBIGATCloudInstallation(string role, string country, string contractType, string usageType, string role1, string method, string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS BIGAT Cloud Installation", exampleTags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given(string.Format("German Dealer have created a \"{0}\" contract of \"{1}\" and \"{2}\"", country, contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication and \"{1" +
                        "}\" installation", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("I navigate to the Invoice tool homepage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And(string.Format("I select \"{0}\" of interest", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I enter mono and colour print count for a single device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("I generate invoices for the contract above", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Cloud Installation")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "Web", "4 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "BOR", "5 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Cloud", "BOR", "36", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Cloud", "Web", "48", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "Cloud MPS Dealer", "Cloud", "BOR", "3 años", "Por trimestres vencidos", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "Cloud MPS Dealer", "Cloud", "Web", "4 años", "Por trimestres vencidos", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Minimumsvolumen", "Cloud MPS Dealer", "Cloud", "Web", "3 år", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Minimumsvolumen", "Cloud MPS Dealer", "Cloud", "BOR", "4 år", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Minimum volym", "Cloud MPS Dealer", "Cloud", "Web", "36 månader", "Kvartalsvis i efterskott", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Minimum volym", "Cloud MPS Dealer", "Cloud", "BOR", "48 månader", "Kvartalsvis i efterskott", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Minimumvolume", "Cloud MPS Dealer", "Cloud", "Web", "3 jaar", "Per kwartaal achteraf", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Minimumvolume", "Cloud MPS Dealer", "Cloud", "BOR", "4 jaar", "Per kwartaal achteraf", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Minimum volum", "Cloud MPS Dealer", "Cloud", "Web", "36", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Minimum volum", "Cloud MPS Dealer", "Cloud", "BOR", "48", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", "3 years", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", "4 years", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Poland", "Buy + Click", "Pakiet wydruków", "Cloud MPS Dealer", "Cloud", "Web", "4 lata", "Miesięczny / Monthly", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Poland", "Buy + Click", "Pakiet wydruków", "Cloud MPS Dealer", "Cloud", "BOR", "4 lata", "Miesięczny / Monthly", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Minimitulostusmäärä", "Cloud MPS Dealer", "Cloud", "Web", "3 vuotta", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Minimitulostusmäärä", "Cloud MPS Dealer", "Cloud", "BOR", "4 vuotta", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Cloud", "BOR", "36", "Quartalsweise", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Cloud", "Web", "48", "Quartalsweise", null)]
        public virtual void MPSCloudInstallation(string role, string country, string contractType, string usageType, string role1, string method, string type, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Cloud Installation", exampleTags);
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 70
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication and \"{1" +
                        "}\" installation", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("I navigate to the Invoice tool homepage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And(string.Format("I select \"{0}\" of interest", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.And("I enter mono and colour print count for a single device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("I generate invoices for the contract above", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS MLang Cloud Installation")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Buy & Click", "Volume minimum", "Cloud MPS Dealer", "Cloud", "Web", "5 ans", "Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance", "French", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Buy & Click", "Volume minimum", "Cloud MPS Dealer", "Cloud", "BOR", "4 ans", "Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance", "French", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", "5 jaar", "Jaarlijke afrekening / Décompte annuel", "Dutch", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", "4 jaar", "Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance", "Dutch", null)]
        public virtual void MPSMLangCloudInstallation(string role, string country, string contractType, string usageType, string role1, string method, string type, string length, string billing, string language, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS MLang Cloud Installation", exampleTags);
#line 116
this.ScenarioSetup(scenarioInfo);
#line 117
 testRunner.Given(string.Format("\"{0}\" Dealer with \"{1}\" language have created a \"{2}\" contract with \"{3}\" and \"{4" +
                        "}\" and \"{5}\"", country, language, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 118
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication and \"{1" +
                        "}\" installation", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
 testRunner.And("I navigate to the Invoice tool homepage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.And(string.Format("I select \"{0}\" of interest", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.And("I enter mono and colour print count for a single device", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.And("I generate invoices for the contract above", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Multiple Installation")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Paiement selon la consommation réelle de pages", "Cloud MPS Dealer", "Email", "4 ans", "Trimestriellement à terme échu", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010197", "A1T010198", "A1T010199", "A1T010200", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Pago por Uso", "Cloud MPS Dealer", "Email", "4 años", "Por trimestres vencidos", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010205", "A1T010206", "A1T010207", "A1T010208", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 år", "Quarterly in Arrears", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "HL-L5200DW", "A1T010209", "A1T010210", "A1T010211", "A1T010212", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Betala per utskrift", "Cloud MPS Dealer", "Email", "48 månader", "Kvartalsvis i efterskott", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "HL-L5100DN", "A1T010213", "A1T010214", "A1T010215", "A1T010216", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Betalen naar verbruik", "Cloud MPS Dealer", "Email", "4 jaar", "Per kwartaal achteraf", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010217", "A1T010218", "A1T010219", "A1T010220", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 years", "Quarterly in Arrears", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010225", "A1T010226", "A1T010227", "A1T010228", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Poland", "Buy + Click", "Pakiet wydruków", "Cloud MPS Dealer", "Email", "4 lata", "Miesięczny / Monthly", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010229", "A1T010230", "A1T010231", "A1T010232", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "United Kingdom", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 years", "Quarterly in Arrears", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010233", "A1T010234", "A1T010235", "A1T010236", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Purchase & Click with Service", "Volume minimum", "Cloud MPS Dealer", "Email", "4 ans", "Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010241", "A1T010242", "A1T010243", "A1T010244", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Germany", "Easy Print Pro & Service", "Mindestvolumen", "Cloud MPS Dealer", "Email", "4 Jahre", "Halbjährlich", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010249", "A1T010250", "A1T010251", "A1T010252", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Austria", "Easy Print Pro & Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "5 Jahre", "Halbjährlich", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010253", "A1T010254", "A1T010255", "A1T010256", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "48", "Quartalsweise", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "HL-L5200DW", "A1T010245", "A1T010246", "A1T010247", "A1T010248", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Maksu tulosteiden mukaan", "Cloud MPS Dealer", "Email", "4 vuotta", "Quarterly in Arrears", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-8950DW", "A1T010237", "A1T010238", "A1T010239", "A1T010240", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Betale ved forbruk", "Cloud MPS Dealer", "Email", "48", "Quarterly in Arrears", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "DCP-L5500DN", "A1T010221", "A1T010222", "A1T010223", "A1T010224", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Email", "48", "Trimestrale anticipata", "Pay upfront", "Brother", "Yes", "MFC-L8650CDW", "MFC-L5750DW", "A1T010201", "A1T010202", "A1T010203", "A1T010204", "5000", "5000", null)]
        public virtual void MultipleInstallation(
                    string role, 
                    string country, 
                    string contractType, 
                    string usageType, 
                    string role1, 
                    string method, 
                    string length, 
                    string billing, 
                    string servicePack, 
                    string installation, 
                    string delivery, 
                    string device1, 
                    string device2, 
                    string serialNumber, 
                    string serialNumber1, 
                    string serialNumber2, 
                    string serialNumber3, 
                    string mono, 
                    string colour, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiple Installation", exampleTags);
#line 155
this.ScenarioSetup(scenarioInfo);
#line 156
 testRunner.Given(string.Format("\"{0}\" Dealer have created \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\" and \"{5}\"" +
                        " and \"{6}\" and \"{7}\" and \"{8}\" and \"{9}\"", country, contractType, usageType, length, billing, servicePack, installation, delivery, device1, device2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 157
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 164
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
 testRunner.And(string.Format("I enter serial numbers \"{0}\" and \"{1}\" and \"{2}\" and \"{3}\"", serialNumber, serialNumber1, serialNumber2, serialNumber3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
 testRunner.And("I navigate to the Invoice tool homepage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
 testRunner.And(string.Format("I select \"{0}\" of interest", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
 testRunner.And(string.Format("I enter \"{0}\" mono and \"{1}\" colour print count", mono, colour), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
 testRunner.And("I generate invoices for the contract above", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Single Installation With Specified Printer")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Paiement selon la consommation réelle de pages", "Cloud MPS Dealer", "Email", "4 ans", "Trimestriellement à terme échu", "DCP-9015CDW", "A1T010266", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Pago por Uso", "Cloud MPS Dealer", "Email", "4 años", "Por trimestres vencidos", "DCP-9015CDW", "A1T010267", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 år", "Quarterly in Arrears", "DCP-9015CDW", "A1T010268", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Betala per utskrift", "Cloud MPS Dealer", "Email", "48 månader", "Kvartalsvis i efterskott", "DCP-9015CDW", "A1T010269", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Betalen naar verbruik", "Cloud MPS Dealer", "Email", "4 jaar", "Per kwartaal achteraf", "DCP-9015CDW", "A1T010270", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 years", "Quarterly in Arrears", "DCP-9015CDW", "A1T010271", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Poland", "Buy + Click", "Pakiet wydruków", "Cloud MPS Dealer", "Email", "4 lata", "Miesięczny / Monthly", "DCP-9015CDW", "A1T010272", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "United Kingdom", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 years", "Quarterly in Arrears", "DCP-9015CDW", "A1T010273", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Purchase & Click with Service", "Volume minimum", "Cloud MPS Dealer", "Email", "4 ans", "Driemaandelijks, betaling vooraf / Paiement trimestriel à l’avance", "DCP-9015CDW", "A1T010274", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Germany", "Easy Print Pro & Service", "Mindestvolumen", "Cloud MPS Dealer", "Email", "4 Jahre", "Halbjährlich", "DCP-9015CDW", "A1T010275", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Austria", "Easy Print Pro & Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "5 Jahre", "Halbjährlich", "DCP-9015CDW", "A1T010278", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "48", "Quartalsweise", "DCP-9015CDW", "A1T010279", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Maksu tulosteiden mukaan", "Cloud MPS Dealer", "Email", "4 vuotta", "Quarterly in Arrears", "DCP-9015CDW", "A1T010276", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Betale ved forbruk", "Cloud MPS Dealer", "Email", "48", "Quarterly in Arrears", "DCP-9015CDW", "A1T010277", "5000", "5000", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Email", "48", "Trimestrale anticipata", "DCP-9015CDW", "A1T010280", "5000", "5000", null)]
        public virtual void SingleInstallationWithSpecifiedPrinter(string role, string country, string contractType, string usageType, string role1, string method, string length, string billing, string device1, string serialNumber, string mono, string colour, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Single Installation With Specified Printer", @__tags);
#line 199
this.ScenarioSetup(scenarioInfo);
#line 200
 testRunner.Given(string.Format("\"{0}\" Dealer have created \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\" and \"{5}\"" +
                        "", country, contractType, usageType, length, billing, device1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 201
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 204
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 205
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 206
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 207
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 208
 testRunner.And(string.Format("I enter device serial number \"{0}\" for \"{1}\" communication", serialNumber, method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 209
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 211
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 212
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 213
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 214
 testRunner.And("I navigate to the Invoice tool homepage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
 testRunner.And(string.Format("I select \"{0}\" of interest", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 216
 testRunner.And(string.Format("I enter \"{0}\" and \"{1}\" print count for a single device", mono, colour), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 217
 testRunner.And("I generate invoices for the contract above", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
