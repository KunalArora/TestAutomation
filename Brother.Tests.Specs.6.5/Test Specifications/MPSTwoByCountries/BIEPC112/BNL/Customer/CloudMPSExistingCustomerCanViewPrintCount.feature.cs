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
namespace Brother.MPS.Tests.Specs.TestSpecifications.MPSTwoByCountries.BIEPC112.BNL.Customer
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSCreateAContractWithExistingDutchCustomer")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("BIEPC112")]
    public partial class CloudMPSCreateAContractWithExistingDutchCustomerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSExistingCustomerCanViewPrintCount.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSCreateAContractWithExistingDutchCustomer", "In order to work with customer run portion\r\nAs a dealer\r\nI want to be able to cre" +
                    "ate a contract with an existing customer", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
                        "UAT",
                        "TEST",
                        "BIEPC112"});
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
        [NUnit.Framework.DescriptionAttribute("MPS Existing Customer For Run Action")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "Netherlands", "Purchase + Click met Service", "Minimumvolume", "Cloud MPS Dealer", "Cloud", "Web", "Vada20160524081137@mailinator.com", "3 jaar", "Per kwartaal achteraf", "Cloud MPS Customer", null)]
        public virtual void MPSExistingCustomerForRunAction(string role, string country, string contractType, string usageType, string role1, string method, string type, string existingCustomer, string length, string billing, string role2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MPS Existing Customer For Run Action", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("\"{0}\" Dealer have created \"{1}\" contract choosing \"{2}\" with \"{3}\" and \"{4}\" and " +
                        "\"{5}\"", country, contractType, existingCustomer, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When(string.Format("I install the device on the contract with \"{0}\" communication and \"{1}\" installat" +
                        "ion", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", existingCustomer, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I navigate to customer dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I navigate to Print Count page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.Then("the print counts attached to the device are correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
