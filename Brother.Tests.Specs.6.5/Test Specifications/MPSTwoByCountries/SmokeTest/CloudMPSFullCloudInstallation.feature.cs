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
        [NUnit.Framework.DescriptionAttribute("Installer can complete installation for Cloud Communication")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "United Kingdom", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", null)]
        public virtual void InstallerCanCompleteInstallationForCloudCommunication(string role, string country, string contractType, string usageType, string role1, string method, string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer can complete installation for Cloud Communication", exampleTags);
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
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("German Installer can complete installation for Cloud Communication")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Germany", "Easy Print Pro & Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "BOR", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "Germany", "Leasing & Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "Web", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Austria", "Easy Print Pro & Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "BOR", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Bank", "Austria", "Leasing & Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "Web", null)]
        public virtual void GermanInstallerCanCompleteInstallationForCloudCommunication(string role, string country, string contractType, string usageType, string role1, string method, string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("German Installer can complete installation for Cloud Communication", exampleTags);
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given(string.Format("German Dealer have created a \"{0}\" contract of \"{1}\" and \"{2}\"", country, contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication and \"{1" +
                        "}\" installation", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer can complete installation for Cloud Communication for other countries")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "Web", "3 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "BOR", "4 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Cloud", "BOR", "36", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Italy", "Acquisto + Consumo con assistenza", "Volume minimo", "Cloud MPS Dealer", "Cloud", "Web", "48", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "Cloud MPS Dealer", "Cloud", "BOR", "3 años", "Por trimestres vencidos", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Spain", "Purchase & Click con Service", "Volúmen mínimo", "Cloud MPS Dealer", "Cloud", "Web", "3 años", "Por trimestres vencidos", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Minimumsvolumen", "Cloud MPS Dealer", "Cloud", "Web", "3 år", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Minimumsvolumen", "Cloud MPS Dealer", "Cloud", "BOR", "4 år", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Minimum volym", "Cloud MPS Dealer", "Cloud", "Web", "36", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Minimum volym", "Cloud MPS Dealer", "Cloud", "BOR", "48", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Minimumvolume", "Cloud MPS Dealer", "Cloud", "Web", "3 jaar", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Minimumvolume", "Cloud MPS Dealer", "Cloud", "BOR", "4 jaar", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Minimum volum", "Cloud MPS Dealer", "Cloud", "Web", "36", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Norway", "Kjøp og klikk med service", "Minimum volum", "Cloud MPS Dealer", "Cloud", "BOR", "48", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", "3 years", "Quarterly in Arrears", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Ireland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", "4 years", "Quarterly in Arrears", null)]
        public virtual void InstallerCanCompleteInstallationForCloudCommunicationForOtherCountries(string role, string country, string contractType, string usageType, string role1, string method, string type, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer can complete installation for Cloud Communication for other countries", exampleTags);
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication and \"{1" +
                        "}\" installation", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Installer can complete installation for Cloud Communication for Multiple Language" +
            "s")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", "3 years", "Quarterly in Arrears", "Suomi", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", "4 years", "Quarterly in Arrears", "Suomi", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", "3 years", "Quarterly in Arrears", "Svenska", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Finland", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", "4 years", "Quarterly in Arrears", "Svenska", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Buy & Click", "Volume minimum", "Cloud MPS Dealer", "Cloud", "Web", "3 ans", "Quarterly in Arrears", "French", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Buy & Click", "Volume minimum", "Cloud MPS Dealer", "Cloud", "BOR", "4 ans", "Quarterly in Arrears", "French", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "BOR", "3 jaar", "Quarterly in Arrears", "Dutch", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Belgium", "Purchase & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "Cloud", "Web", "4 jaar", "Quarterly in Arrears", "Dutch", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "Web", "3 Jahre", "Quarterly in Arrears", "Deutsch", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "BOR", "4 ans", "Quarterly in Arrears", "Français", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Mindestvolumen", "Cloud MPS Dealer", "Cloud", "BOR", "3 Jahre", "Quarterly in Arrears", "Deutsch", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "Web", "4 ans", "Quarterly in Arrears", "Français", null)]
        public virtual void InstallerCanCompleteInstallationForCloudCommunicationForMultipleLanguages(string role, string country, string contractType, string usageType, string role1, string method, string type, string length, string billing, string language, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer can complete installation for Cloud Communication for Multiple Language" +
                    "s", exampleTags);
#line 95
this.ScenarioSetup(scenarioInfo);
#line 96
 testRunner.Given(string.Format("\"{0}\" Dealer with \"{1}\" language have created a \"{2}\" contract with \"{3}\" and \"{4" +
                        "}\" and \"{5}\"", country, language, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 97
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication and \"{1" +
                        "}\" installation", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.And(string.Format("I enter device serial number for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
