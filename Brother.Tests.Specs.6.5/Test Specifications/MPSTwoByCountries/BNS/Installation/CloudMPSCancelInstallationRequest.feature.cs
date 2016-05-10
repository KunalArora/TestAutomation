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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwoByCountries.BNS.Installation
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSSwedishDealerCancelInstallationRequest")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class CloudMPSSwedishDealerCancelInstallationRequestFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSCancelInstallationRequest.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSSwedishDealerCancelInstallationRequest", "In order to stop an installer from beginning installation\r\nAs a Dealer \r\nI want t" +
                    "o be able to cancel installation request", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Dealer can cancel installation request for Cloud Communication for other countrie" +
            "s")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "Web", "3 ans", "Trimestrale anticipata", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "BOR", "4 ans", "Trimestrale anticipata", null)]
        public virtual void DealerCanCancelInstallationRequestForCloudCommunicationForOtherCountries(string role, string country, string contractType, string usageType, string role1, string method, string type, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can cancel installation request for Cloud Communication for other countrie" +
                    "s", exampleTags);
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.When("I navigate to the contract Manage Device Screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.And("I select Location in order to create installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And(string.Format("I set device communication method as \"{0}\"", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And(string.Format("I set device installation type as \"{0}\"", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And(string.Format("I completed the create installation process for \"{0}\"", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then("the installation request for that device is completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("I can cancel the above created installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Local Office Approver can cancel installation request for Email Communication for" +
            " other countries")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Email", "3 ans", "Trimestrale anticipata", null)]
        public virtual void LocalOfficeApproverCanCancelInstallationRequestForEmailCommunicationForOtherCountries(string role, string country, string contractType, string usageType, string role1, string method, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Local Office Approver can cancel installation request for Email Communication for" +
                    " other countries", exampleTags);
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("the contract created above is approved without signing out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.When("I navigate to the Local Office Approver device management Screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.And("I select Location in order to create installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And(string.Format("I set device communication method as \"{0}\"", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And(string.Format("I completed the create installation process for \"{0}\"", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.Then("the installation request for that device is completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("I can cancel the above created installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Local Office can cancel installation request for Cloud Communication for other co" +
            "untries")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "3 ans", "Trimestrale anticipata", "Web", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "3 ans", "Trimestrale anticipata", "BOR", null)]
        public virtual void LocalOfficeCanCancelInstallationRequestForCloudCommunicationForOtherCountries(string role, string country, string contractType, string usageType, string role1, string method, string length, string billing, string type, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Local Office can cancel installation request for Cloud Communication for other co" +
                    "untries", exampleTags);
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("the contract created above is approved without signing out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I navigate to the Local Office Approver device management Screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.And("I select Location in order to create installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And(string.Format("I set device communication method as \"{0}\"", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And(string.Format("I set device installation type as \"{0}\"", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And(string.Format("I completed the create installation process for \"{0}\"", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then("the installation request for that device is completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.And("I can cancel the above created installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer can cancel installation request for Email Communication for other countrie" +
            "s")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Sweden", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Email", "3 ans", "Trimestrale anticipata", null)]
        public virtual void DealerCanCancelInstallationRequestForEmailCommunicationForOtherCountries(string role, string country, string contractType, string usageType, string role1, string method, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can cancel installation request for Email Communication for other countrie" +
                    "s", exampleTags);
#line 71
this.ScenarioSetup(scenarioInfo);
#line 72
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.When("I navigate to the contract Manage Device Screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
 testRunner.And("I select Location in order to create installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And(string.Format("I set device communication method as \"{0}\"", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And(string.Format("I completed the create installation process for \"{0}\"", method), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.Then("the installation request for that device is completed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.And("I can cancel the above created installation request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
