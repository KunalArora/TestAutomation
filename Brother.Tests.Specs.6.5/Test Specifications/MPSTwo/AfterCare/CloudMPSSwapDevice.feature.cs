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
namespace Brother.Tests.Specs.TestSpecifications.MPSTwo.AfterCare
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CloudMPSSwapDevice")]
    [NUnit.Framework.CategoryAttribute("MPS")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class CloudMPSSwapDeviceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CloudMPSSwapDevice.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CloudMPSSwapDevice", "In order to remove a broken device from a contract\r\nAs an installer\r\nI want to be" +
                    " able to swap contract\'s current device to a new device", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Installer can swap device that is on a contract")]
        [NUnit.Framework.TestCaseAttribute("Cloud MPS Local Office Approver", "France", "Buy & Click", "Engagement sur un minimum volume de pages", "Cloud MPS Dealer", "Cloud", "Web", "3 ans", "Trimestrale anticipata", null)]
        public virtual void InstallerCanSwapDeviceThatIsOnAContract(string role, string country, string contractType, string usageType, string role1, string method, string type, string length, string billing, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Installer can swap device that is on a contract", exampleTags);
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("\"{0}\" Dealer have created a \"{1}\" contract with \"{2}\" and \"{3}\" and \"{4}\"", country, contractType, usageType, length, billing), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And(string.Format("I sign into Cloud MPS as a \"{0}\" from \"{1}\"", role, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("the contract created above is approved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And(string.Format("I sign back into Cloud MPS as a \"{0}\" from \"{1}\"", role1, country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And(string.Format("I generate installation request for the contract with \"{0}\" communication and \"{1" +
                        "}\" installation", method, type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I extract the installer url from Installation Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When(string.Format("I have completed installation for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.And("I begin device swapping process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I generate swapping device request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And(string.Format("installer installed the new swap device for \"{0}\" communication", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.Then("the newly installed device is displayed on Managed Device screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("I can complete the swap process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
