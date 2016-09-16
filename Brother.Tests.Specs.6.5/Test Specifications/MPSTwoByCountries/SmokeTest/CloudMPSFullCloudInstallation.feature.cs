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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.SmokeTest
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSFullCloudInstallationForSmokeTest")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
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
                        "TEST"});
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
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "Web", "3 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "BOR", "4 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Cloud", "BOR", "36", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Cloud", "Web", "48", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "Cloud MPS Dealer", "Cloud", "BOR", "3 años", "Por trimestres vencidos", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "Cloud MPS Dealer", "Cloud", "Web", "3 años", "Por trimestres vencidos", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Minimumsvolumen", "Cloud MPS Dealer", "Cloud", "Web", "3 år", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Minimumsvolumen", "Cloud MPS Dealer", "Cloud", "BOR", "4 år", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Minimum volym", "Cloud MPS Dealer", "Cloud", "Web", "36 månader", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Minimum volym", "Cloud MPS Dealer", "Cloud", "BOR", "48 månader", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Minimumvolume", "Cloud MPS Dealer", "Cloud", "Web", "3 jaar", "Per kwartaal achteraf", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Minimumvolume", "Cloud MPS Dealer", "Cloud", "BOR", "4 jaar", "Per kwartaal achteraf", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Minimum volum", "Cloud MPS Dealer", "Cloud", "Web", "36", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Minimum volum", "Cloud MPS Dealer", "Cloud", "BOR", "48", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", "3 years", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", "4 years", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Poland", "Buy + Click", "Pakiet wydruków", "Cloud MPS Dealer", "Cloud", "Web", "3 lata", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Poland", "Buy + Click", "Pakiet wydruków", "Cloud MPS Dealer", "Cloud", "BOR", "4 lata", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Minimitulostusmäärä", "Cloud MPS Dealer", "Cloud", "Web", "3 vuotta", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Minimitulostusmäärä", "Cloud MPS Dealer", "Cloud", "BOR", "4 vuotta", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "BOR", "36", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "Web", "36", "Quarterly in Arrears", null)]
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
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Buy & Click", "Volume minimum", "Cloud MPS Dealer", "Cloud", "Web", "3 ans", "Quarterly in Arrears", "French", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Buy & Click", "Volume minimum", "Cloud MPS Dealer", "Cloud", "BOR", "4 ans", "Quarterly in Arrears", "French", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", "3 jaar", "Quarterly in Arrears", "Dutch", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", "4 jaar", "Quarterly in Arrears", "Dutch", null)]
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
    }
}
#pragma warning restore
#endregion
