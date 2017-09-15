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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC111.SmokeTest_Cloud_Email
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSInstallerCanNavigateThroughInstallationForSmokeTest")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("BIEPC111")]
    public partial class CloudMPSInstallerCanNavigateThroughInstallationForSmokeTestFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSInstallerCanNavigateThroughEmailInstallation.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSInstallerCanNavigateThroughInstallationForSmokeTest", "\tIn order to get an installer to begin installation\r\n\tAs a Dealer \r\n\tI want to be" +
                    " able to complete installation", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TEST",
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
        [NUnit.Framework.DescriptionAttribute("MPS BUK Email Installation")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Email", null)]
        public virtual void MPSBUKEmailInstallation(string role, string country, string contractType, string usageType, string role1, string method, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS BUK Email Installation", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("Dealer have created a contract of \"{0}\" and \"{1}\"", contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS BUK Email Installation through Email Exchange")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Email", "MFC-L8650CDW", "A1T010001", "45000", "15000", "30000", "brothermps_QAS@brother.co.uk", "E-mail Report", null)]
        public virtual void MPSBUKEmailInstallationThroughEmailExchange(string role, string country, string contractType, string usageType, string role1, string method, string model, string serial, string total, string colour, string mono, string emailAddress, string subject, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS BUK Email Installation through Email Exchange", exampleTags);
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given(string.Format("Dealer have created a contract of \"{0}\" and \"{1}\"", contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.And(string.Format("I can complete device installation for email \"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"" +
                        "{5}\" and \"{6}\"", model, serial, total, colour, mono, emailAddress, subject), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Email Installation")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Email", "4 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Email", "48", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "Cloud MPS Dealer", "Email", "4 años", "Por trimestres vencidos", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Poland", "Buy + Click", "Pakiet wydruków", "Cloud MPS Dealer", "Email", "4 lata", "Miesięczny / Monthly", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Løbende betaling", "Cloud MPS Dealer", "Email", "4 år", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Betala per utskrift", "Cloud MPS Dealer", "Email", "48 månader", "Kvartalsvis i efterskott", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Betalen naar verbruik", "Cloud MPS Dealer", "Email", "4 jaar", "3-maandelijks achteraf", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 years", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Buy & Click", "Volume minimum", "Cloud MPS Dealer", "Email", "4 ans", "Jaarlijke afrekening / Décompte annuel", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "48", "Quartalsweise", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Maksu tulosteiden mukaan", "Cloud MPS Dealer", "Email", "4 vuotta", "3 kk välein käytön mukaan", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Betale ved forbruk", "Cloud MPS Dealer", "Email", "48", "Quarterly in Arrears", null)]
        public virtual void MPSEmailInstallation(string role, string country, string contractType, string usageType, string role1, string method, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Email Installation", exampleTags);
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS BIGAT Email Installation")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Austria", "Easy Print Pro & Service", "Mindestvolumen", "Cloud MPS Dealer", "Email", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Germany", "Easy Print Pro & Service", "Mindestvolumen", "Cloud MPS Dealer", "Email", null)]
        public virtual void MPSBIGATEmailInstallation(string role, string country, string contractType, string usageType, string role1, string method, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS BIGAT Email Installation", exampleTags);
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
 testRunner.Given(string.Format("German Dealer have created a \"{0}\" contract of \"{1}\" and \"{2}\"", country, contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 88
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("MPS Email Installation Through Email Exchange")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Email", "4 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Email", "48", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "Cloud MPS Dealer", "Email", "4 años", "Por trimestres vencidos", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Poland", "Buy + Click", "Pakiet wydruków", "Cloud MPS Dealer", "Email", "4 lata", "Miesięczny / Monthly", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Løbende betaling", "Cloud MPS Dealer", "Email", "4 år", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Betala per utskrift", "Cloud MPS Dealer", "Email", "48 månader", "Kvartalsvis i efterskott", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Betalen naar verbruik", "Cloud MPS Dealer", "Email", "4 jaar", "3-maandelijks achteraf", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 years", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Buy & Click", "Volume minimum", "Cloud MPS Dealer", "Email", "4 ans", "Jaarlijke afrekening / Décompte annuel", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "48", "Quartalsweise", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Maksu tulosteiden mukaan", "Cloud MPS Dealer", "Email", "4 vuotta", "3 kk välein käytön mukaan", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Betale ved forbruk", "Cloud MPS Dealer", "Email", "48", "Quarterly in Arrears", null)]
        public virtual void MPSEmailInstallationThroughEmailExchange(string role, string country, string contractType, string usageType, string role1, string method, string length, string billing, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Email Installation Through Email Exchange", @__tags);
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
