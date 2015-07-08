﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18408
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
    [NUnit.Framework.DescriptionAttribute("DealerCanOperateProposalOffers")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    public partial class DealerCanOperateProposalOffersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DealerCanOperateProposalOffers.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DealerCanOperateProposalOffers", "In order to view/edit/delete/copy existing proposals\r\nAs an MPS Dealer\r\nI want to" +
                    " operate existing proposals", ProgrammingLanguage.CSharp, new string[] {
                        "MPS",
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
        [NUnit.Framework.DescriptionAttribute("Dealer can see proposal offers")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", null)]
        public virtual void DealerCanSeeProposalOffers(string role, string country, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can see proposal offers", exampleTags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I navigate to existing proposal screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.Then("I can see the Existing Proposal table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer can edit an existing proposal offer")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Lease & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "United Kingdom", "Description", null)]
        [NUnit.Framework.TestCaseAttribute("Lease & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "United Kingdom", "CustomerInformation", null)]
        [NUnit.Framework.TestCaseAttribute("Lease & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "United Kingdom", "TermAndType", null)]
        [NUnit.Framework.TestCaseAttribute("Lease & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "United Kingdom", "Products", null)]
        [NUnit.Framework.TestCaseAttribute("Lease & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "United Kingdom", "ClickPrice", null)]
        public virtual void DealerCanEditAnExistingProposalOffer(string contractType, string usageType, string role, string country, string tabName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can edit an existing proposal offer", @__tags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given(string.Format("Dealer have created a Open proposal of \"{0}\" and \"{1}\"", contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.And("I navigate to Dealer Dashboard page from Dealer Proposal page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("I navigate to existing proposal screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I can click edit button on proposal item of Exisiting Proposal table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.And(string.Format("I go to \"{0}\" Tab in Proposal", tabName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And(string.Format("I edit \"{0}\" Tab in Proposal", tabName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I go to \"Summary\" Tab in Proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.Then(string.Format("I can confirm \"{0}\" on Summary Tab in Proposal", tabName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer can edit products in an existing proposal offer")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Lease & Click with Service", "Minimum Volume", "Cloud MPS Dealer", "United Kingdom", "Products", "Add", null)]
        public virtual void DealerCanEditProductsInAnExistingProposalOffer(string contractType, string usageType, string role, string country, string tabName, string action, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can edit products in an existing proposal offer", @__tags);
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given(string.Format("Dealer have created a Open proposal of \"{0}\" and \"{1}\"", contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.And("I navigate to Dealer Dashboard page from Dealer Proposal page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I navigate to existing proposal screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.When("I can click edit button on proposal item of Exisiting Proposal table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.And("I go to \"Products\" Tab in Proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And(string.Format("I edit Products Tab and \"{0}\" in Proposal", action), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I go to \"Summary\" Tab in Proposal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.Then(string.Format("I can confirm Products and \"{0}\" on Summary Tab in Proposal", action), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer can delete an existing proposal offer")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("Lease & Click with Service", "Minimum Volume", "OK", "NewlyCreatedItem", null)]
        public virtual void DealerCanDeleteAnExistingProposalOffer(string contractType, string usageType, string confirm, string targetItem, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can delete an existing proposal offer", @__tags);
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
    testRunner.Given(string.Format("Dealer have created a Open proposal of \"{0}\" and \"{1}\"", contractType, usageType), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
 testRunner.When(string.Format("I click the delete button against \"{0}\" on Exisiting Proposal table", targetItem), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.And(string.Format("I click the \"{0}\" button on Confirmation Dialog", confirm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.Then("I can see the deleted item does not exist on the table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer can cansel deleting proposal offer")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Dismiss", "AnyItem", null)]
        public virtual void DealerCanCanselDeletingProposalOffer(string role, string country, string confirm, string targetItem, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can cansel deleting proposal offer", exampleTags);
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 70
 testRunner.And("I navigate to existing proposal screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.When(string.Format("I click the delete button against \"{0}\" on Exisiting Proposal table", targetItem), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
 testRunner.And(string.Format("I click the \"{0}\" button on Confirmation Dialog", confirm), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.Then("I can see the deleted item still exists on the table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Dealer can copy an existing proposal offer")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Without", "Without", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "Without", "With", null)]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Dealer", "United Kingdom", "With", "With", null)]
        public virtual void DealerCanCopyAnExistingProposalOffer(string role, string country, string operation, string target, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Dealer can copy an existing proposal offer", exampleTags);
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
 testRunner.Given(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
 testRunner.And("I navigate to existing proposal screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.When(string.Format("I can Copy \"{0}\" Customer an item of Exisiting Proposal table \"{1}\" Customer", operation, target), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
 testRunner.Then(string.Format("I can see the Proposal offer which copied \"{0}\" Customer", operation), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
