﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PurchaseANewInkCartridge")]
    [NUnit.Framework.IgnoreAttribute("Ignored feature")]
    public partial class PurchaseANewInkCartridgeFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PurchaseASupply.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PurchaseANewInkCartridge", "\tIn order to continue to use my printer once the ink has run out\r\n\tAs a user\r\n\tI " +
                    "need to purchase a new ink cartridge", ProgrammingLanguage.CSharp, new string[] {
                        "IGNORE"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
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
        [NUnit.Framework.DescriptionAttribute("(BBAU-2877) Purchase a new Inkjet Cartridge with a valid supply code and valid cr" +
            "edit card details")]
        public virtual void BBAU_2877PurchaseANewInkjetCartridgeWithAValidSupplyCodeAndValidCreditCardDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(BBAU-2877) Purchase a new Inkjet Cartridge with a valid supply code and valid cr" +
                    "edit card details", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
   testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                        "Password",
                        "@@@@@"});
            table1.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 19
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table1, "And ");
#line 26
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.Given("I have navigated to the Brother Main Site \"Ireland\" products pages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.And("I have clicked on Supplies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("I have entered my valid supplies code for an InkJet cartridge \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("I click on search for supply \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("I should see the selected item information page priced at \"€25.31\" inc vat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.When("I click on Add To Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("I should see the item \"LC1000BK\" in the Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("I should see the Basket item count change to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("I click on Go to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("I should see the item \"LC1000BK\" in the item list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.And("I should see the Basket items count is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
 testRunner.When("I click Checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
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
#line 46
 testRunner.When("I enter the delivery details", ((string)(null)), table2, "When ");
#line 58
 testRunner.And("I Click Save & use address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.Then("I should see the Saved payment details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.When("I click on Add Payment Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.And("I click on Add New Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.Then("I can add billing address details for Country \"Ireland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
 testRunner.Then("I should see the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.And("I click Place Your Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.When("I enter valid credit card details for a Visa Credit Card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.When("I click Send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
 testRunner.Then("I should see the Order Confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
 testRunner.And("I can validate I have ordered \"1\" of \"LC1000BK\" @ \"€25.31\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("If I click on My Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.And("I can click on Orders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("I can validate the order \"1\" of \"LC1000BK\" @ \"€25.31\" on My Account page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("If I sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
 testRunner.And("I can validate an Order Confirmation email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("(BBAU-2877) - Purchase a new Inkjet Cartridge with a valid device code and valid " +
            "credit card details")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("TEST")]
        [NUnit.Framework.CategoryAttribute("UAT")]
        public virtual void BBAU_2877_PurchaseANewInkjetCartridgeWithAValidDeviceCodeAndValidCreditCardDetails()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("(BBAU-2877) - Purchase a new Inkjet Cartridge with a valid device code and valid " +
                    "credit card details", new string[] {
                        "TEST",
                        "UAT",
                        "IGNORE"});
#line 79
this.ScenarioSetup(scenarioInfo);
#line 80
testRunner.Given("I want to create a new account with Brother Online \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 81
 testRunner.When("I click on Create Account for \"United Kingdom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
 testRunner.And("I am redirected to the Brother Login/Register page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("I have Checked No I Do Not Have An Account Checkbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                        "Password",
                        "@@@@@"});
            table3.AddRow(new string[] {
                        "ConfirmPassword",
                        "@@@@@"});
#line 84
 testRunner.And("I fill in the registration information using a valid email address", ((string)(null)), table3, "And ");
#line 91
 testRunner.And("I have Agreed to the Terms and Conditions", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("I declare that I do not use this account for business", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.When("I press Create Your Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.Then("I should see my account confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
 testRunner.And("When I Click Go Back", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.Then("I should be able to log into \"United Kingdom\" Brother Online using my account det" +
                    "ails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
 testRunner.Given("I have navigated to the Brother Main Site \"Ireland\" products pages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
 testRunner.And("I have clicked on Supplies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("I have entered my valid device code for an InkJet printer \"DCP-J715W\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.When("I click on search for model \"DCP-J715W\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
 testRunner.Then("I should see an a list of associated items for model \"DCP-J715W\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
 testRunner.And("If I click on the item \"LC1100BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.Then("I should see the selected item information page priced at \"€22.53\" inc vat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.When("I click on Add To Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("I should see the item \"LC1100BK\" in the Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.And("I should see the Basket item count change to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.When("I click on Go to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
 testRunner.Then("I should see the item \"LC1100BK\" in the item list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
 testRunner.And("I should see the Basket items count is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.When("I click Checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.Then("I should see the enter Delivery Address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table4.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table4.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table4.AddRow(new string[] {
                        "HouseNumber",
                        "10"});
            table4.AddRow(new string[] {
                        "HouseName",
                        "AutoTestHouse"});
            table4.AddRow(new string[] {
                        "AddressLine1",
                        "29,Selenium Street"});
            table4.AddRow(new string[] {
                        "AddressLine2",
                        "PhantomJSVille"});
            table4.AddRow(new string[] {
                        "CityTown",
                        "Manchester"});
            table4.AddRow(new string[] {
                        "County",
                        "KILKENNY"});
            table4.AddRow(new string[] {
                        "Phone",
                        "12345678910"});
#line 113
 testRunner.When("I enter the delivery details", ((string)(null)), table4, "When ");
#line 125
 testRunner.And("I Click Save & use address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.Then("I should see the Saved payment details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
 testRunner.When("I click on Add Payment Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
 testRunner.And("I click on Add New Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.Then("I can add billing address details for Country \"Ireland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.Then("I should see the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
 testRunner.And("I click Place Your Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.When("I enter valid credit card details for a Visa Credit Card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
 testRunner.When("I click Send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
 testRunner.Then("I should see the Order Confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
 testRunner.And("I can validate I have ordered \"1\" of \"LC1100BK\" @ \"€22.53\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.And("If I click on My Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("I can click on Orders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.And("I can validate the order \"1\" of \"LC1100BK\" @ \"€22.53\" on My Account page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.And("If I sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
 testRunner.And("I can validate an Order Confirmation email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Purchase a product by product number on Brother \"Ireland\" but click Cancel before" +
            " submitting payment")]
        [NUnit.Framework.CategoryAttribute("PROD")]
        public virtual void PurchaseAProductByProductNumberOnBrotherIrelandButClickCancelBeforeSubmittingPayment()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Purchase a product by product number on Brother \"Ireland\" but click Cancel before" +
                    " submitting payment", new string[] {
                        "PROD"});
#line 145
this.ScenarioSetup(scenarioInfo);
#line 146
 testRunner.Given("I am logged onto Brother Online \"Ireland\" using valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 147
 testRunner.Given("I have navigated to the Brother Main Site \"Ireland\" products pages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 148
 testRunner.And("I have clicked on Supplies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.And("I have entered my valid supplies code for an InkJet cartridge \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
 testRunner.When("I click on search for supply \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 151
 testRunner.Then("I should see the selected item information page priced at \"€25.31\" inc vat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 152
 testRunner.When("I click on Add To Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 153
 testRunner.Then("I should see the item \"LC1000BK\" in the Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
 testRunner.And("I should see the Basket item count change to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
 testRunner.When("I click on Go to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
 testRunner.Then("I should see the item \"LC1000BK\" in the item list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
 testRunner.And("I should see the Basket items count is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
 testRunner.When("I click Checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 159
 testRunner.Then("I should see the enter Delivery Address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "field",
                        "value"});
            table5.AddRow(new string[] {
                        "FirstName",
                        "AutoTest"});
            table5.AddRow(new string[] {
                        "LastName",
                        "AutoTest"});
            table5.AddRow(new string[] {
                        "HouseNumber",
                        "10"});
            table5.AddRow(new string[] {
                        "HouseName",
                        "AutoTestHouse"});
            table5.AddRow(new string[] {
                        "AddressLine1",
                        "29,Selenium Street"});
            table5.AddRow(new string[] {
                        "AddressLine2",
                        "PhantomJSVille"});
            table5.AddRow(new string[] {
                        "CityTown",
                        "Manchester"});
            table5.AddRow(new string[] {
                        "County",
                        "KILKENNY"});
            table5.AddRow(new string[] {
                        "Phone",
                        "12345678910"});
#line 160
 testRunner.When("I enter the delivery details", ((string)(null)), table5, "When ");
#line 172
 testRunner.And("I Click Save & use address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
 testRunner.Then("I should see the Saved payment details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 174
 testRunner.When("I click on Add Payment Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 175
 testRunner.And("I click on Add New Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.Then("I can add billing address details for Country \"Ireland\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 177
 testRunner.Then("I should see the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 178
 testRunner.And("I click Place Your Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.When("I enter valid credit card details for a Visa Credit Card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 180
 testRunner.When("I click Cancel I should return to the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 181
 testRunner.Then("I can navigate back to Brother Online home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 182
 testRunner.Then("I can sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Purchase a new Inkjet Cartridge with valid credit card details")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
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
#line 186
this.ScenarioSetup(scenarioInfo);
#line 187
 testRunner.Given(string.Format("I am logged onto Brother Online \"{0}\" using valid credentials", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 188
 testRunner.Given(string.Format("I have navigated to the Brother Main Site \"{0}\" products pages", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 189
 testRunner.And("I have clicked on Supplies", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
 testRunner.And("I have entered my valid supplies code for an InkJet cartridge \"LC1000BK\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
 testRunner.When(string.Format("I click on search for supply \"{0}\"", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 192
 testRunner.Then("I should see the selected item information page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 193
 testRunner.When("I click on Add To Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 194
 testRunner.Then(string.Format("I should see the item \"{0}\" in the Basket", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 195
 testRunner.And("I should see the Basket item count change to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
 testRunner.When("I click on Go to Basket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 197
 testRunner.Then(string.Format("I should see the item \"{0}\" in the item list", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 198
 testRunner.And("I should see the Basket items count is \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
 testRunner.When("I click Checkout", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 200
 testRunner.Then("I should see the enter Delivery Address details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 201
 testRunner.When(string.Format("I enter the delivery address details \"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{" +
                        "6}\", \"{7}\", {8}", firstName, lastName, houseNumber, houseName, addrLine1, addrLine2, cityTown, county, phoneNum), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 202
 testRunner.And("I Click Save & use address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
 testRunner.Then("I should see the Saved payment details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 204
 testRunner.When("I click on Add Payment Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 205
 testRunner.And("I click on Add New Address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 206
 testRunner.Then(string.Format("I can add billing address details for Country \"{0}\"", country), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 207
 testRunner.Then("I should see the Order Summary page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 208
 testRunner.And("I click Place Your Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 209
 testRunner.When("I enter valid credit card details for a Visa Credit Card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 210
 testRunner.When("I click Send", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 211
 testRunner.Then("I should see the Order Confirmation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 212
 testRunner.And(string.Format("I can validate I have ordered \"1\" of \"{0}\" @ \"€25.31\"", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 213
 testRunner.And("If I click on My Account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 214
 testRunner.And("I can click on Orders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 215
 testRunner.And(string.Format("I can validate the order \"1\" of \"{0}\" @ \"€25.31\" on My Account page", supplyCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 216
 testRunner.And("If I sign out of Brother Online", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 217
 testRunner.Then("I am redirected to the Brother Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 218
 testRunner.And("I can validate an Order Confirmation email was received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
