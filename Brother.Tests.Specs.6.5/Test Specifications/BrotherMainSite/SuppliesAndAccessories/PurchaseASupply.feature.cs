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
namespace Brother.Tests.Specs.TestSpecifications.BrotherMainSite.SuppliesAndAccessories
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PurchaseANewInkCartridge")]
    [NUnit.Framework.CategoryAttribute("UAT")]
    [NUnit.Framework.CategoryAttribute("TEST")]
    public partial class PurchaseANewInkCartridgeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PurchaseASupply.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PurchaseANewInkCartridge", "In order to continue to use my printer once the ink has run out\r\nAs a user\r\nI nee" +
                    "d to purchase a new ink cartridge", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Purchase a new Inkjet Cartridge with a valid supply code and valid credit card de" +
            "tails")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void PurchaseANewInkjetCartridgeWithAValidSupplyCodeAndValidCreditCardDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Purchase a new Inkjet Cartridge with a valid supply code and valid credit card de" +
                    "tails", new string[] {
                        "SMOKE"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I am logged onto Brother Online \"Ireland\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.Given("I have navigated to the Brother Main Site \"Ireland\" products pages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.And("I have clicked on Supplies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("I have entered my valid supplies code for an InkJet cartridge \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.When("I click on search for supply \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("I should see the selected item information page priced at \"€25.31\" inc vat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.When("I click on Add To Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.Then("I should see the item \"LC1000BK\" in the Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.And("I should see the Basket item count change to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I click on Go to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I should see the item \"LC1000BK\" in the item list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.And("I should see the Basket items count is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.When("I click Checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("I should see the enter Delivery Address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table1.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table1.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table1.AddRow(new string[] {
                        "HouseNumber",
                        "10"});
            table1.AddRow(new string[] {
                        "HouseName",
                        "AutoTestHouse"});
            table1.AddRow(new string[] {
                        "AddressLine1",
                        "29,Selenium Street"});
            table1.AddRow(new string[] {
                        "AddressLine2",
                        "PhantomJSVille"});
            table1.AddRow(new string[] {
                        "CityTown",
                        "Manchester"});
            table1.AddRow(new string[] {
                        "County",
                        "KILKENNY"});
            table1.AddRow(new string[] {
                        "Phone",
                        "12345678910"});
#line 28
 testRunner.When("I enter the delivery details", ((string)(null)), table1, "When ");
#line 40
 testRunner.And("I Click Save & use address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.Then("I should see the Saved payment details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
 testRunner.When("I click on Add Payment Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.And("I click on Add New Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.Then("I can add billing address details for Country \"Ireland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.Then("I should see the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.And("I click Place Your Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I enter valid credit card details for a Visa Credit Card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.When("I click Send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then("I should see the Order Confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.And("I can validate I have ordered \"1\" of \"LC1000BK\" @ \"€25.31\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("If I click on My Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("I can click on Orders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("I can validate the order \"1\" of \"LC1000BK\" @ \"€25.31\" on My Account page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("If I sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("I can validate an Order Confirmation email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Purchase a new Inkjet Cartridge with a valid device code and valid credit card de" +
            "tails")]
        public virtual void PurchaseANewInkjetCartridgeWithAValidDeviceCodeAndValidCreditCardDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Purchase a new Inkjet Cartridge with a valid device code and valid credit card de" +
                    "tails", ((string[])(null)));
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
 testRunner.Given("I am logged onto Brother Online \"Ireland\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
 testRunner.Given("I have navigated to the Brother Main Site \"Ireland\" products pages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
 testRunner.And("I have clicked on Supplies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I have entered my valid device code for an InkJet printer \"DCP-J715W\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("I click on search for model \"DCP-J715W\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("I should see an a list of associated items for model \"DCP-J715W\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.And("If I click on the item \"LC1100BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.Then("I should see the selected item information page priced at \"€22.53\" inc vat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
 testRunner.When("I click on Add To Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
 testRunner.Then("I should see the item \"LC1100BK\" in the Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
 testRunner.And("I should see the Basket item count change to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.When("I click on Go to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
 testRunner.Then("I should see the item \"LC1100BK\" in the item list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
 testRunner.And("I should see the Basket items count is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.When("I click Checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
 testRunner.Then("I should see the enter Delivery Address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table2.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table2.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table2.AddRow(new string[] {
                        "HouseNumber",
                        "10"});
            table2.AddRow(new string[] {
                        "HouseName",
                        "AutoTestHouse"});
            table2.AddRow(new string[] {
                        "AddressLine1",
                        "29,Selenium Street"});
            table2.AddRow(new string[] {
                        "AddressLine2",
                        "PhantomJSVille"});
            table2.AddRow(new string[] {
                        "CityTown",
                        "Manchester"});
            table2.AddRow(new string[] {
                        "County",
                        "KILKENNY"});
            table2.AddRow(new string[] {
                        "Phone",
                        "12345678910"});
#line 76
 testRunner.When("I enter the delivery details", ((string)(null)), table2, "When ");
#line 88
 testRunner.And("I Click Save & use address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.Then("I should see the Saved payment details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
 testRunner.When("I click on Add Payment Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.And("I click on Add New Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.Then("I can add billing address details for Country \"Ireland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.Then("I should see the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
 testRunner.And("I click Place Your Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.When("I enter valid credit card details for a Visa Credit Card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.When("I click Send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
 testRunner.Then("I should see the Order Confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
 testRunner.And("I can validate I have ordered \"1\" of \"LC1100BK\" @ \"€22.53\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("If I click on My Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("I can click on Orders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I can validate the order \"1\" of \"LC1100BK\" @ \"€22.53\" on My Account page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("If I sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
 testRunner.And("I can validate an Order Confirmation email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Purchase a product by product number on Brother \"Ireland\" but click Cancel before" +
            " submitting payment")]
        [NUnit.Framework.CategoryAttribute("PROD")]
        [NUnit.Framework.CategoryAttribute("SMOKE")]
        public virtual void PurchaseAProductByProductNumberOnBrotherIrelandButClickCancelBeforeSubmittingPayment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Purchase a product by product number on Brother \"Ireland\" but click Cancel before" +
                    " submitting payment", new string[] {
                        "PROD",
                        "SMOKE"});
#line 108
this.ScenarioSetup(scenarioInfo);
#line 109
 testRunner.Given("I am logged onto Brother Online \"Ireland\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 110
 testRunner.Given("I have navigated to the Brother Main Site \"Ireland\" products pages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.And("I have clicked on Supplies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.And("I have entered my valid supplies code for an InkJet cartridge \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.When("I click on search for supply \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
 testRunner.Then("I should see the selected item information page priced at \"€25.31\" inc vat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
 testRunner.When("I click on Add To Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
 testRunner.Then("I should see the item \"LC1000BK\" in the Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
 testRunner.And("I should see the Basket item count change to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.When("I click on Go to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
 testRunner.Then("I should see the item \"LC1000BK\" in the item list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
 testRunner.And("I should see the Basket items count is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.When("I click Checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
 testRunner.Then("I should see the enter Delivery Address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table3.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table3.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table3.AddRow(new string[] {
                        "HouseNumber",
                        "10"});
            table3.AddRow(new string[] {
                        "HouseName",
                        "AutoTestHouse"});
            table3.AddRow(new string[] {
                        "AddressLine1",
                        "29,Selenium Street"});
            table3.AddRow(new string[] {
                        "AddressLine2",
                        "PhantomJSVille"});
            table3.AddRow(new string[] {
                        "CityTown",
                        "Manchester"});
            table3.AddRow(new string[] {
                        "County",
                        "KILKENNY"});
            table3.AddRow(new string[] {
                        "Phone",
                        "12345678910"});
#line 123
 testRunner.When("I enter the delivery details", ((string)(null)), table3, "When ");
#line 135
 testRunner.And("I Click Save & use address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.Then("I should see the Saved payment details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
 testRunner.When("I click on Add Payment Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
 testRunner.And("I click on Add New Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.Then("I can add billing address details for Country \"Ireland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
 testRunner.Then("I should see the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
 testRunner.And("I click Place Your Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
 testRunner.When("I enter valid credit card details for a Visa Credit Card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
 testRunner.When("I click Cancel I should return to the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 144
 testRunner.Then("I can navigate back to Brother Online home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 145
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Purchase a new Inkjet Cartridge with valid credit card details")]
        [NUnit.Framework.IgnoreAttribute()]
        [NUnit.Framework.CategoryAttribute("UAT")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.TestCaseAttribute("Ireland", "Supplies", "LC1000BK", "Otto", "Tiest", "10", "Testing House", "30, Its a Test Street", "Village Of Automation", "Manchester", "KILKENNY", "012345678910", null)]
        [NUnit.Framework.TestCaseAttribute("United Kingdom", "Supplies", "LC1000BK", "Otto", "Tiest", "10", "Testing House", "30, Its a Test Street", "Village Of Automation", "Manchester", "", "012345678910", null)]
        public virtual void PurchaseANewInkjetCartridgeWithValidCreditCardDetails(string country, string type, string supplyCode, string firstName, string lastName, string houseNumber, string houseName, string addrLine1, string addrLine2, string cityTown, string county, string phoneNum, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "UAT",
                    "TEST",
                    "ignore"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Purchase a new Inkjet Cartridge with valid credit card details", @__tags);
#line 149
this.ScenarioSetup(scenarioInfo);
#line 150
 testRunner.Given(string.Format("I am logged onto Brother Online \"{0}\" using valid credentials", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 151
 testRunner.Given(string.Format("I have navigated to the Brother Main Site \"{0}\" products pages", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 152
 testRunner.And("I have clicked on Supplies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.And("I have entered my valid supplies code for an InkJet cartridge \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
 testRunner.When(string.Format("I click on search for supply \"{0}\"", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 155
 testRunner.Then("I should see the selected item information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 156
 testRunner.When("I click on Add To Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 157
 testRunner.Then(string.Format("I should see the item \"{0}\" in the Basket", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 158
 testRunner.And("I should see the Basket item count change to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.When("I click on Go to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 160
 testRunner.Then(string.Format("I should see the item \"{0}\" in the item list", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 161
 testRunner.And("I should see the Basket items count is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.When("I click Checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 163
 testRunner.Then("I should see the enter Delivery Address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
 testRunner.When(string.Format("I enter the delivery address details \"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{" +
                        "6}\", \"{7}\", {8}", firstName, lastName, houseNumber, houseName, addrLine1, addrLine2, cityTown, county, phoneNum), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 165
 testRunner.And("I Click Save & use address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
 testRunner.Then("I should see the Saved payment details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 167
 testRunner.When("I click on Add Payment Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 168
 testRunner.And("I click on Add New Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
 testRunner.Then(string.Format("I can add billing address details for Country \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 170
 testRunner.Then("I should see the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 171
 testRunner.And("I click Place Your Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
 testRunner.When("I enter valid credit card details for a Visa Credit Card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 173
 testRunner.When("I click Send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
 testRunner.Then("I should see the Order Confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 175
 testRunner.And(string.Format("I can validate I have ordered \"1\" of \"{0}\" @ \"€25.31\"", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.And("If I click on My Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
 testRunner.And("I can click on Orders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
 testRunner.And(string.Format("I can validate the order \"1\" of \"{0}\" @ \"€25.31\" on My Account page", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.And("If I sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 181
 testRunner.And("I can validate an Order Confirmation email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to purchase an ink cartridge by product serial number using invalid credi" +
            "t card credentials")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void AttemptToPurchaseAnInkCartridgeByProductSerialNumberUsingInvalidCreditCardCredentials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to purchase an ink cartridge by product serial number using invalid credi" +
                    "t card credentials", new string[] {
                        "ignore"});
#line 189
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to purchase an ink cartridge by model code using invalid credit card cred" +
            "entials")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void AttemptToPurchaseAnInkCartridgeByModelCodeUsingInvalidCreditCardCredentials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to purchase an ink cartridge by model code using invalid credit card cred" +
                    "entials", new string[] {
                        "ignore"});
#line 192
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to purchase an ink cartridge by product serial number using invalid Billi" +
            "ng Addresse details")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void AttemptToPurchaseAnInkCartridgeByProductSerialNumberUsingInvalidBillingAddresseDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to purchase an ink cartridge by product serial number using invalid Billi" +
                    "ng Addresse details", new string[] {
                        "ignore"});
#line 195
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to purchase an ink cartridge by product serial number using invalid Deliv" +
            "ery Addresse details")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void AttemptToPurchaseAnInkCartridgeByProductSerialNumberUsingInvalidDeliveryAddresseDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to purchase an ink cartridge by product serial number using invalid Deliv" +
                    "ery Addresse details", new string[] {
                        "ignore"});
#line 198
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to purchase an ink cartridge by product serial number which is out of sto" +
            "ck")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void AttemptToPurchaseAnInkCartridgeByProductSerialNumberWhichIsOutOfStock()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to purchase an ink cartridge by product serial number which is out of sto" +
                    "ck", new string[] {
                        "ignore"});
#line 201
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to purchase an ink cartridge by an invalid product serial number")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void AttemptToPurchaseAnInkCartridgeByAnInvalidProductSerialNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to purchase an ink cartridge by an invalid product serial number", new string[] {
                        "ignore"});
#line 204
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Attempt to purchase an ink cartridge by an invalid Model code number")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void AttemptToPurchaseAnInkCartridgeByAnInvalidModelCodeNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Attempt to purchase an ink cartridge by an invalid Model code number", new string[] {
                        "ignore"});
#line 207
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cancel order transaction at Checkout")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void CancelOrderTransactionAtCheckout()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cancel order transaction at Checkout", new string[] {
                        "ignore"});
#line 210
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Cancel order transaction at Credit Card Details page")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void CancelOrderTransactionAtCreditCardDetailsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cancel order transaction at Credit Card Details page", new string[] {
                        "ignore"});
#line 213
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove item from Basket and add another item")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void RemoveItemFromBasketAndAddAnotherItem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove item from Basket and add another item", new string[] {
                        "ignore"});
#line 216
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Purchase numerous items by Product serial code")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void PurchaseNumerousItemsByProductSerialCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Purchase numerous items by Product serial code", new string[] {
                        "ignore"});
#line 219
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Purchase numerous items by Model code")]
        [NUnit.Framework.IgnoreAttribute()]
        public virtual void PurchaseNumerousItemsByModelCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Purchase numerous items by Model code", new string[] {
                        "ignore"});
#line 222
this.ScenarioSetup(scenarioInfo);
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
