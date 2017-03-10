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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC113.PrintersCheck
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSCheckNewPrinterWorks")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("BIEPC113")]
    public partial class CloudMPSCheckNewPrinterWorksFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSCheckNewPrinterWorks.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSCheckNewPrinterWorks", "In order to ensure that new printers work as expected\r\nAs a dealer\r\nI want to per" +
                    "form a thorough check on new printers", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("MPS Printer Checks")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "Denmark", "Køb & Klik med service", "Minimumsvolumen", "3 år", "Quarterly in Arrears", "Tick", "MFC-J5330DW", "800", "800", null)]
        public virtual void MPSPrinterChecks(string role, string country, string contractType, string usageType, string contract, string billing, string priceHardware, string printer, string clickVolume, string colourVolume, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Printer Checks", exampleTags);
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
 testRunner.And("I select service pack \"<PaymentMethod>\" payment method", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I \"{0}\" Price Hardware radio button", priceHardware), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("I accept the default value of printer \"{0}\"", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("Service Pack In Click line is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And(string.Format("I enter click price volume of \"{0}\" and \"{1}\"", clickVolume, colourVolume), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then(string.Format("clicking on the displayed printer \"{0}\" link takes me back to the device screen", printer), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Single Installation With New Printer")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "4 år", "Quarterly in Arrears", "MFC-J5330DW", "A1T010391", "5000", "5000", null)]
        public virtual void SingleInstallationWithNewPrinter(string role, string country, string contractType, string usageType, string role1, string method, string length, string billing, string device1, string serialNumber, string mono, string colour, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Single Installation With New Printer", exampleTags);
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given(string.Format("\"{0}\" Dealer has created \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\" and \"{5}\"", country, contractType, usageType, length, billing, device1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
 testRunner.And(string.Format("I enter device serial number \"{0}\" for \"{1}\" communication", serialNumber, method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.Then("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("I navigate to the Invoice tool homepage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And(string.Format("I select \"{0}\" of interest", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And(string.Format("I enter \"{0}\" and \"{1}\" print count for a single device", mono, colour), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I generate invoices for the contract above", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Multiple Devices Verification")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Løbende betaling", "Cloud MPS Dealer", "Email", "4 år", "Quarterly in Arrears", "HL-L8260CDW", "HL-L8360CDW", "HL-L9310CDW", "HL-L9310CDWT", "A1T010292", "A1T010293", "A1T010294", "A1T010295", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Løbende betaling", "Cloud MPS Dealer", "Email", "4 år", "Quarterly in Arrears", "DCP-L8410CDW", "MFC-L8690CDW", "MFC-L8900CDW", "MFC-L9570CDW", "A1T010296", "A1T010297", "A1T010298", "A1T010299", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Denmark", "Purchase & Click with Service", "Løbende betaling", "Cloud MPS Dealer", "Email", "4 år", "Quarterly in Arrears", "MFC-L9570CDWT", "MFC-L8690CDW", "MFC-L8900CDW", "MFC-L9570CDW", "A1T010300", "A1T010301", "A1T010302", "A1T010303", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Betala per utskrift", "Cloud MPS Dealer", "Email", "48 månader", "Kvartalsvis i efterskott", "HL-L8260CDW", "HL-L8360CDW", "HL-L9310CDW", "HL-L9310CDWT", "A1T010304", "A1T010305", "A1T010306", "A1T010307", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Betala per utskrift", "Cloud MPS Dealer", "Email", "48 månader", "Kvartalsvis i efterskott", "DCP-L8410CDW", "MFC-L8690CDW", "MFC-L8900CDW", "MFC-L9570CDW", "A1T010308", "A1T010309", "A1T010310", "A1T010311", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Purchase & click inklusive service", "Betala per utskrift", "Cloud MPS Dealer", "Email", "48 månader", "Kvartalsvis i efterskott", "MFC-L9570CDWT", "MFC-L8690CDW", "MFC-L8900CDW", "MFC-L9570CDW", "A1T010312", "A1T010313", "A1T010314", "A1T010315", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "48", "Quartalsweise", "HL-L8260CDW", "HL-L8360CDW", "HL-L9310CDW", "HL-L9310CDWT", "A1T010316", "A1T010317", "A1T010318", "A1T010319", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "48", "Quartalsweise", "DCP-L8410CDW", "MFC-L8690CDW", "MFC-L8900CDW", "MFC-L9570CDW", "A1T010320", "A1T010321", "A1T010322", "A1T010323", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Switzerland", "Purchase & Click with Service", "Pay As You Go", "Cloud MPS Dealer", "Email", "48", "Quartalsweise", "MFC-L9570CDWT", "HL-L9310CDWTT", "MFC-L8900CDW", "MFC-L9570CDW", "A1T010324", "A1T010325", "A1T010326", "A1T010327", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Betalen naar verbruik", "Cloud MPS Dealer", "Email", "4 jaar", "Per kwartaal achteraf", "HL-L8260CDW", "HL-L8360CDW", "HL-L9310CDW", "HL-L9310CDWT", "A1T010328", "A1T010329", "A1T010330", "A1T010331", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Betalen naar verbruik", "Cloud MPS Dealer", "Email", "4 jaar", "Per kwartaal achteraf", "DCP-L8410CDW", "MFC-L8690CDW", "MFC-L8900CDW", "MFC-L9570CDW", "A1T010332", "A1T010333", "A1T010334", "A1T010335", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Betalen naar verbruik", "Cloud MPS Dealer", "Email", "4 jaar", "Per kwartaal achteraf", "MFC-L9570CDWT", "HL-L9310CDWTT", "MFC-L8900CDW", "MFC-L9570CDW", "A1T010336", "A1T010337", "A1T010338", "A1T010339", null)]
        public virtual void MultipleDevicesVerification(
                    string role, 
                    string country, 
                    string contractType, 
                    string usageType, 
                    string role1, 
                    string method, 
                    string length, 
                    string billing, 
                    string device1, 
                    string device2, 
                    string device3, 
                    string device4, 
                    string serialNumber, 
                    string serialNumber1, 
                    string serialNumber2, 
                    string serialNumber3, 
                    string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiple Devices Verification", exampleTags);
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
 testRunner.Given(string.Format("\"{0}\" Dealer has created \"{1}\" contract the following \"{2}\" and \"{3}\" and \"{4}\" a" +
                        "nd \"{5}\" and \"{6}\" and \"{7}\" and \"{8}\"", country, contractType, usageType, length, billing, device1, device2, device3, device4), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.When("I navigate to the installer page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.And("I enter the contract reference number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And(string.Format("I enter serial numbers \"{0}\" and \"{1}\" and \"{2}\" and \"{3}\"", serialNumber, serialNumber1, serialNumber2, serialNumber3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("I enter the device IP address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("I can connect the device to Brother environment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I can complete device installation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
