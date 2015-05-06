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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwo.Contract
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PAYGPurchaseAndClickContract")]
    [NUnit.Framework.IgnoreAttribute()]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class PAYGPurchaseAndClickContractFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PAYGPurchaseAndClickContract.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PAYGPurchaseAndClickContract", "In order to create a PAYG Purchase and Click contract\r\nAs a Dealer I want to be a" +
                    "ble to create a PAYG Purchase and Click proposal and convert the proposal to con" +
                    "tract\r\nSo that I am able provide more value to the different customers", ProgrammingLanguage.CSharp, new string[] {
                        "Ignore",
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
        [NUnit.Framework.DescriptionAttribute("Convert Purchase and Click Proposal to Contract")]
        public virtual void ConvertPurchaseAndClickProposalToContract()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Convert Purchase and Click Proposal to Contract", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I sign into Cloud MPS as a \"Cloud MPS Local Office\" from \"Germany\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I navigate to Local Office Admin Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I enable Easy Print Pro contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I sign out of Cloud MPS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I sign back into Cloud MPS as a \"Cloud MPS Dealer\" from \"Germany\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.And("I navigate to Dealer Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("I am on MPS New Proposal Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I fill Proposal Description for \"Purchase-and-Click\" program", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I enter Customer Information Detail for new customer", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I Enter \"Pay As You Go\" usage type \"3 Jahre\" contract length and \"3 Monatlich\" bi" +
                    "lling on Term and Type details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I choose \"DCP-L2500D\" from Products screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("I type in click price volume of \"1500\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I click Save Proposal button on Summary screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.Then("I am directed to Proposals screen of Proposal List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And("the newly created proposal is displayed on the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I start the contract conversion process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I add a date to the proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I save the proposal as a contract", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("the newly converted contract is available on Ready for Bank screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
