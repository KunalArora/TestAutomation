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
namespace Brother.Online.Tests.Specs.TestSpecification
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ProductRegistration")]
    [NUnit.Framework.CategoryAttribute("SMOKE_ProductRegistration")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class ProductRegistrationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ProductRegistration.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ProductRegistration", "In order to register a product\r\nEnd user will login to existing account or create" +
                    " a new account", ProgrammingLanguage.CSharp, new string[] {
                        "SMOKE_ProductRegistration",
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
        [NUnit.Framework.DescriptionAttribute("Verify the Header and Footer of the landing page")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", null)]
        public virtual void VerifyTheHeaderAndFooterOfTheLandingPage(string country, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Header and Footer of the landing page", @__tags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
testRunner.Then("I should see the Header and the Footer appearing on the landing Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("New Customer wants to register product with their serial numbers and purchase dat" +
            "e")]
        [NUnit.Framework.CategoryAttribute("SMOKE_ProductRegistration")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/eubol78/serial-number", "U1T004731", "12/12/2013", "testemailidinputfield@guerrillamail.com", "Test", "Test", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        public virtual void NewCustomerWantsToRegisterProductWithTheirSerialNumbersAndPurchaseDate(string country, string siteUrl, string serialNumber, string purchaseDate, string email, string firstName, string lastName, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE_ProductRegistration",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("New Customer wants to register product with their serial numbers and purchase dat" +
                    "e", @__tags);
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And(string.Format("I browse to the \"{0}\" product registration page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\" on Product Registration page", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("clicked on Find Product Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I retreive data product id from Product Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And(string.Format("I have entered \"{0}\"", purchaseDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I entered apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I click on continue button on brother product page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.Then("I can register my Email on user details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
 testRunner.And(string.Format("I enter \"{0}\"  and \"{1}\" on  user details page", firstName, lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("I tick on terms and conditions checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.Then(string.Format("I can complete my product registration by clicking on complete registration butto" +
                        "n and I can deregister the \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("New Customer wants to register product with their serial numbers, purchase date a" +
            "nd promo code")]
        [NUnit.Framework.CategoryAttribute("SMOKE_ProductRegistration")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/eubol78/serial-number", "U1T004731", "12/12/2013", "warrantyup", "testemailidinputfield@mailinator.com", "Test", "Test", "M345JE", "1", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        public virtual void NewCustomerWantsToRegisterProductWithTheirSerialNumbersPurchaseDateAndPromoCode(string country, string siteUrl, string serialNumber, string purchaseDate, string promoCode, string email, string firstName, string lastName, string postcode, string houseNumber, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE_ProductRegistration",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("New Customer wants to register product with their serial numbers, purchase date a" +
                    "nd promo code", @__tags);
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And(string.Format("I browse to the \"{0}\" product registration page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\" on Product Registration page", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("clicked on Find Product Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("I retreive data product id from Product Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And(string.Format("I have entered \"{0}\"", purchaseDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I entered apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And(string.Format("I enter \"{0}\"", promoCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I click on add code button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("I click on continue button on brother product page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.Then("I can register my Email on user details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.And(string.Format("I enter \"{0}\"  and \"{1}\" on  user details page", firstName, lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I click on continue button on user details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And(string.Format("I can register my \"{0}\" on the address details page", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("I click on Find Address Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And(string.Format("I enter \"{0}\" on address page", houseNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("I click on continue button on address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("I tick on terms and conditions checkbox on Address details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then(string.Format("I can complete my product registration by clicking on complete registration butto" +
                        "n on Address Details Page and I can  deregister the \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Existing Customer wants to register product with their serial numbers, purchase d" +
            "ate and promo code and also bank details entered for the user")]
        [NUnit.Framework.CategoryAttribute("SMOKE_ProductRegistration")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "123orderplacedukaccount@mailinator.com", "Hello123", "U1T004731", "cash50", "12/12/2013", "Test", "400699", "54116897", "M345JE", "1", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        public virtual void ExistingCustomerWantsToRegisterProductWithTheirSerialNumbersPurchaseDateAndPromoCodeAndAlsoBankDetailsEnteredForTheUser(string country, string siteUrl, string validEmailAddress, string validPassword, string serialNumber, string promoCode, string purchaseDate, string accountHolderName, string sortCode, string accountNumber, string postcode, string houseNumber, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE_ProductRegistration",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Existing Customer wants to register product with their serial numbers, purchase d" +
                    "ate and promo code and also bank details entered for the user", @__tags);
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
    testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.And(string.Format("I browse to the \"{0}\" for existing user signin page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\"", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("I click on existing customer log in option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
    testRunner.Then(string.Format("I enter an email address as \"{0}\" on existing customer page", validEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
    testRunner.Then(string.Format("I enter valid passowrd for the account \"{0}\"", validPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
    testRunner.And("I click on SignIn button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("clicked on Find Product Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("I retreive data product id from Product Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And(string.Format("I have entered \"{0}\"", purchaseDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("I entered apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And(string.Format("I enter \"{0}\"", promoCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("I click on add code button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("I click on continue button on brother product page to go to address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And(string.Format("I can register my \"{0}\" on the address details page", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("I click on Find Address Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And(string.Format("I enter \"{0}\" on address page", houseNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("I click on continue button on address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And(string.Format("I enter \"{0}\" and \"{1}\" and \"{2}\" on address details page", accountHolderName, sortCode, accountNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.And("I tick on terms and conditions checkbox on Address details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.Then(string.Format("I can complete my product registration by clicking on complete registration butto" +
                        "n on Address Details Page and I can  deregister the \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Existing Customer wants to register product with their serial numbers, purchase d" +
            "ate")]
        [NUnit.Framework.CategoryAttribute("SMOKE_ProductRegistration")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "123orderplacedukaccount@mailinator.com", "Hello123", "U1T004731", "12/12/2013", "Test", "400699", "54116897", "M345JE", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        public virtual void ExistingCustomerWantsToRegisterProductWithTheirSerialNumbersPurchaseDate(string country, string siteUrl, string validEmailAddress, string validPassword, string serialNumber, string purchaseDate, string accountHolderName, string sortCode, string accountNumber, string postcode, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE_ProductRegistration",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Existing Customer wants to register product with their serial numbers, purchase d" +
                    "ate", @__tags);
#line 97
this.ScenarioSetup(scenarioInfo);
#line 98
    testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
 testRunner.And(string.Format("I browse to the \"{0}\" for existing user signin page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\"", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I click on existing customer log in option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
    testRunner.Then(string.Format("I enter an email address as \"{0}\" on existing customer page", validEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
    testRunner.Then(string.Format("I enter valid passowrd for the account \"{0}\"", validPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
    testRunner.And("I click on SignIn button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.And("clicked on Find Product Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.And("I retreive data product id from Product Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And(string.Format("I have entered \"{0}\"", purchaseDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.And("I entered apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.Then(string.Format("I can complete my product registration by clicking on continue button and I can  " +
                        "deregister the \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Deregister Serial Numbers using prod id")]
        [NUnit.Framework.CategoryAttribute("SMOKE_ProductRegistration")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "1c43ec57-5cda-db34-e100-0000ac1b10d3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "7343ec57-5cda-db34-e100-0000ac1b10d3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "c243ec57-5cda-db34-e100-0000ac1b10d3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "1144ec57-5cda-db34-e100-0000ac1b10d3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "6044ec57-5cda-db34-e100-0000ac1b10d3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "af44ec57-5cda-db34-e100-0000ac1b10d3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "A1D1EC57-45DA-D234-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "A5EEEC57-0DDB-5637-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "07EEEC57-0DDB-5637-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "AAB7EC57-E4BA-7B5D-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "E1ECEC57-0DDB-5537-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "EFACEC57-ABDA-FC35-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "02ACEC57-ABDA-FC35-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "35FDEC57-13D7-662B-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "AAFBEC57-13D7-662B-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "0CFBEC57-13D7-662B-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "B4A80058-9890-A70F-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "D0380058-F3BC-7F0C-E100-0000AC1B10D3", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "81380058-F3BC-7F0C-E100-0000AC1B10D3", null)]
        public virtual void DeregisterSerialNumbersUsingProdId(string country, string siteUrl, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE_ProductRegistration",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deregister Serial Numbers using prod id", @__tags);
#line 119
this.ScenarioSetup(scenarioInfo);
#line 120
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 121
 testRunner.And(string.Format("I browse to the \"{0}\" product registration page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\" on Product Registration page", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
