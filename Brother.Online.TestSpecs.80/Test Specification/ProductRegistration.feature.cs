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
namespace Brother.Online.TestSpecs._80.TestSpecification
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ProductRegistration")]
    [NUnit.Framework.CategoryAttribute("SMOKE")]
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
                        "SMOKE",
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
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/eubol78/serial-number", "U1T004731", "12/12/2013", "123orderplacedukaccount@mailinator.com", "Test", "Test", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        public virtual void NewCustomerWantsToRegisterProductWithTheirSerialNumbersAndPurchaseDate(string country, string siteUrl, string serialNumber, string purchaseDate, string email, string firstName, string lastName, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE",
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
        [NUnit.Framework.DescriptionAttribute("New Customer wants to register product with their serial numbers in the file")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/eubol78/serial-number", "12/12/2013", "testemailidinputfield@mailinator.com", "Test", "Test", null)]
        public virtual void NewCustomerWantsToRegisterProductWithTheirSerialNumbersInTheFile(string country, string siteUrl, string purchaseDate, string email, string firstName, string lastName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("New Customer wants to register product with their serial numbers in the file", @__tags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
 testRunner.And(string.Format("I browse to the \"{0}\" product registration page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.And("I deregister the serial number using the \"<ProdId>\" on Product Registration page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.And("I have entered my product SerialNumber reading from the environmental variable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("clicked on Find Product Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And(string.Format("I have entered \"{0}\"", purchaseDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.And("I entered apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("I click on continue button on brother product page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.Then("I can register my Email on user details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.And(string.Format("I enter \"{0}\"  and \"{1}\" on  user details page", firstName, lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I tick on terms and conditions checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.Then("I can complete my product registration by clicking on complete registration butto" +
                    "n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("New Customer wants to register product with their serial numbers, purchase date a" +
            "nd promo code")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/eubol78/serial-number", "U1T004731", "12/12/2013", "warrantyup", "testemailidinputfield@mailinator.com", "Test", "Test", "M345JE", "1", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        public virtual void NewCustomerWantsToRegisterProductWithTheirSerialNumbersPurchaseDateAndPromoCode(string country, string siteUrl, string serialNumber, string purchaseDate, string promoCode, string email, string firstName, string lastName, string postcode, string houseNumber, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("New Customer wants to register product with their serial numbers, purchase date a" +
                    "nd promo code", @__tags);
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
 testRunner.And(string.Format("I browse to the \"{0}\" product registration page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\"", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("clicked on Find Product Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("I retreive data product id from Product Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And(string.Format("I have entered \"{0}\"", purchaseDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("I entered apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And(string.Format("I enter \"{0}\"", promoCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I click on add code button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("I click on continue button on brother product page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.Then("I can register my Email on user details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
 testRunner.And(string.Format("I enter \"{0}\"  and \"{1}\" on  user details page", firstName, lastName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("I click on continue button on user details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And(string.Format("I can register my \"{0}\" on the address details page", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I click on Find Address Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And(string.Format("I enter \"{0}\" on address page", houseNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("I click on continue button on address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("I tick on terms and conditions checkbox on Address details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.Then(string.Format("I can complete my product registration by clicking on complete registration butto" +
                        "n on Address Details Page and I can  deregister the \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Existing Customer wants to register product with their serial numbers, purchase d" +
            "ate and promo code and also bank details entered for the user")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "123orderplacedukaccount@mailinator.com", "Hello123", "U1T004731", "cash50", "12/12/2013", "Test", "400699", "54116897", "M345JE", "1", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        public virtual void ExistingCustomerWantsToRegisterProductWithTheirSerialNumbersPurchaseDateAndPromoCodeAndAlsoBankDetailsEnteredForTheUser(string country, string siteUrl, string validEmailAddress, string validPassword, string serialNumber, string promoCode, string purchaseDate, string accountHolderName, string sortCode, string accountNumber, string postcode, string houseNumber, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Existing Customer wants to register product with their serial numbers, purchase d" +
                    "ate and promo code and also bank details entered for the user", @__tags);
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
    testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
 testRunner.And(string.Format("I browse to the \"{0}\" for existing user signin page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\"", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("I click on existing customer log in option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
    testRunner.Then(string.Format("I enter an email address as \"{0}\"", validEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
    testRunner.Then(string.Format("I enter valid passowrd for the account \"{0}\"", validPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
    testRunner.And("I click on SignIn button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("clicked on Find Product Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I retreive data product id from Product Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And(string.Format("I have entered \"{0}\"", purchaseDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I entered apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And(string.Format("I enter \"{0}\"", promoCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("I click on add code button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.And("I click on continue button on brother product page to go to address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And(string.Format("I can register my \"{0}\" on the address details page", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.And("I click on Find Address Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
 testRunner.And(string.Format("I enter \"{0}\" on address page", houseNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I click on tickbox to confirm I will send my proof of purchase", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.And("I click on continue button on address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.And(string.Format("I enter \"{0}\" and \"{1}\" and \"{2}\" on address details page", accountHolderName, sortCode, accountNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.And("I tick on terms and conditions checkbox on Address details Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.Then(string.Format("I can complete my product registration by clicking on complete registration butto" +
                        "n on Address Details Page and I can  deregister the \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.And("I can verify registration confirmaiton message is present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Existing Customer wants to register product with their serial numbers, purchase d" +
            "ate")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "123orderplacedukaccount@mailinator.com", "Hello123", "U1T004731", "12/12/2013", "Test", "400699", "54116897", "M345JE", "c3beeb53-d80a-1a4c-e100-0000ac1b10d3", null)]
        public virtual void ExistingCustomerWantsToRegisterProductWithTheirSerialNumbersPurchaseDate(string country, string siteUrl, string validEmailAddress, string validPassword, string serialNumber, string purchaseDate, string accountHolderName, string sortCode, string accountNumber, string postcode, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Existing Customer wants to register product with their serial numbers, purchase d" +
                    "ate", @__tags);
#line 121
this.ScenarioSetup(scenarioInfo);
#line 122
    testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 123
 testRunner.And(string.Format("I browse to the \"{0}\" for existing user signin page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\"", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("I click on existing customer log in option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
    testRunner.Then(string.Format("I enter an email address as \"{0}\"", validEmailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
    testRunner.Then(string.Format("I enter valid passowrd for the account \"{0}\"", validPassword), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
    testRunner.And("I click on SignIn button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.And(string.Format("I have entered my product \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
 testRunner.And("clicked on Find Product Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.And("I retreive data product id from Product Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.And(string.Format("I have entered \"{0}\"", purchaseDate), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.And("I entered apply button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.Then(string.Format("I can complete my product registration by clicking on continue button and I can  " +
                        "deregister the \"{0}\"", serialNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
 testRunner.And("I can verify registration confirmaiton message is present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Deregister Serial Numbers using prod id")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "/qa/signintest", "1e20eb53-c926-cd2f-e100-0000ac1b10d3", null)]
        public virtual void DeregisterSerialNumbersUsingProdId(string country, string siteUrl, string prodId, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "SMOKE",
                    "TEST"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deregister Serial Numbers using prod id", @__tags);
#line 146
this.ScenarioSetup(scenarioInfo);
#line 147
 testRunner.Given(string.Format("I navigate to \"{0}\" Brother Online landing page", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 148
 testRunner.And(string.Format("I browse to the \"{0}\" product registration page", siteUrl), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.And(string.Format("I deregister the serial number using the \"{0}\" on Product Registration page", prodId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
