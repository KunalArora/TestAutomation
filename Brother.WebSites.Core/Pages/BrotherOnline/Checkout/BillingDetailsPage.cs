using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement.PaymentMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Checkout
{
    public class BillingDetailsPage : BasePage
    {
        public static string Url = "/";

        public enum DeliveryAddress { PhoneNumber, FirstName, LastName, PostCode, HouseNumber, CityTown };

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["BillingAddressPage"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#FirstnameTextBox")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#LastNameTextbox")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#HouseNumberTextBox")]
        public IWebElement HouseNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#HouseNameTextBox")]
        public IWebElement HouseNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#AddrLine1Text")]
        public IWebElement AddressLine1TextBox;

        [FindsBy(How = How.CssSelector, Using = "#AddrLine2Text")]
        public IWebElement AddressLine2TextBox;

        [FindsBy(How = How.CssSelector, Using = "#RegexPostCodeText")]
        public IWebElement PostCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = "#FindAddressBtn")]
        public IWebElement FindAddressButton;

        [FindsBy(How = How.CssSelector, Using = "#CityTownText")]
        public IWebElement CityTownTextBox;

        [FindsBy(How = How.CssSelector, Using = "#PhoneNumberText")]
        public IWebElement PhoneNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#ContextSapRegionDropDownList")]
        public IWebElement CountryDropDownBox;

        [FindsBy(How = How.CssSelector, Using = "#DeliverToAddressCB")]
        public IWebElement DeliverToThisAddressTickBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_checkoutcontent_0_billingedit_btnbillingContinue")]
        public IWebElement SaveBillingAddressButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_1_ChangeaddressLB_ChangeInvoiceaddressLB_AddNewAddressButton")]
        public IWebElement AddNewAddressButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_billingedit_btnPaymentContinue")] 
        public IWebElement SaveAddressAndReturnToPaymentMethodsButton;

// Throwing warning as its not used so taking out for now
//        private string useThisAddressButton =
//            ".content.cf .content-box.left-nav-container.cf .content-wrapper.cf.saved-payment-cards .lightbox .box-out .lightbox-address-list .cf #content_1_innercontent_1_ChangeaddressLB_ChangeInvoiceaddressLB_AddressRepeater_useAsDeliveryAddressButton_0";

        public void AddNewAddressButtonClick()
        {
            ScrollTo(AddNewAddressButton);
            AddNewAddressButton.Click();
        }

        public void IsAddNewAddressButtonAvailable()
        {
            if (AddNewAddressButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(AddNewAddressButton, "Add New Address Button");
        }

        public AddNewCardPage SaveAddressAndReturnToPaymentMethodsButtonClick()
        {
            ScrollTo(SaveAddressAndReturnToPaymentMethodsButton);
            SaveAddressAndReturnToPaymentMethodsButton.Click();
            return GetInstance<AddNewCardPage>(Driver);
        }

        public AddNewCardPage AddCardUseThisAddressButtonClick()
        {
            try
            {
                Driver.Manage().Window.Maximize();
                IWebElement useThisAddressButtonElement = Driver.FindElement(By.CssSelector("[href*='useAs']"));

                var actions = new Actions(Driver);
                actions.MoveToElement(useThisAddressButtonElement).Click().Perform();
            }
            catch (NoSuchElementException notFound)
            {
                TestCheck.AssertFailTest(string.Format("Unable to locate Use This Address button [{0}]", notFound));
            }
            return GetInstance<AddNewCardPage>(Driver);
        }

        public OrderSummaryPage SaveBillingAddressButtonClick()
        {
            ScrollTo(SaveBillingAddressButton);
            SaveBillingAddressButton.Click();
            return GetInstance<OrderSummaryPage>(Driver);
        }

        public void IsSaveAddressAndReturnToPaymentMethodsButtonAvailable()
        {
            if (SaveAddressAndReturnToPaymentMethodsButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(SaveAddressAndReturnToPaymentMethodsButton, "Save Address And Return to Payment Methods Button");
        }

        public void IsSaveBillingAddressButtonAvailable()
        {
            if (SaveBillingAddressButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(SaveBillingAddressButton, "Save Billing Address Button");
        }

        public void PopulateFirstNameTextBox(string firstName)
        {
            FirstNameTextBox.SendKeys(firstName);
            TestCheck.AssertIsEqual(firstName, GetTextBoxValue("FirstnameTextBox"), "FirstName Text Box");
        }

        public void PopulateLastNameTextBox(string lastName)
        {
            LastNameTextBox.SendKeys(lastName);
            TestCheck.AssertIsEqual(lastName, GetTextBoxValue("LastNameTextbox"), "LastName Text Box");
        }

        public void PopulateHouseNumberTextBox(string houseNumber)
        {
            HouseNumberTextBox.SendKeys(houseNumber);
            TestCheck.AssertIsEqual(houseNumber, GetTextBoxValue("HouseNumberTextBox"), "House Number Text Box");
        }

        public void PopulateHouseNameTextBox(string houseName)
        {
            HouseNameTextBox.SendKeys(houseName);
            TestCheck.AssertIsEqual(houseName, GetTextBoxValue("HouseNameTextBox"), "House Name Text Box");
        }

        public void PopulateAddressLine1TextBox(string addressLine1)
        {
            AddressLine1TextBox.SendKeys(addressLine1);
            TestCheck.AssertIsEqual(addressLine1, GetTextBoxValue("AddrLine1Text"), "Address Line 1 Text Box");
        }

        public void PopulateAddressLine2TextBox(string addressLine2)
        {
            AddressLine2TextBox.SendKeys(addressLine2);
            TestCheck.AssertIsEqual(addressLine2, GetTextBoxValue("AddrLine2Text"), "Address Line 2 Text Box");
        }

        public void PopulateCityTownTextBox(string cityTown)
        {
            CityTownTextBox.SendKeys(cityTown);
            TestCheck.AssertIsEqual(cityTown, GetTextBoxValue("CityTownText"), "City Town Text Box");
        }

        public void PopulatePhoneTextBox(string phone)
        {
            PhoneNumberTextBox.SendKeys(phone);
            TestCheck.AssertIsEqual(phone, GetTextBoxValue("PhoneNumberText"), "Phone Number Text Box");
        }

        public void PopulateCountryDropDown(string country)
        {
            SelectFromDropdown(CountryDropDownBox, country);
            AssertItemIsSelected(CountryDropDownBox, country, "Country Drop Down List");
        }

        public void PopulatePostCodeTextBox(string postCode)
        {
            PostCodeTextBox.SendKeys(postCode);
            TestCheck.AssertIsEqual(postCode, GetTextBoxValue("RegexPostCodeText"), "Post Code Text Box");
        }

        public void PopulatePhoneNumberTextBox(string phoneNumber)
        {
            PhoneNumberTextBox.SendKeys(phoneNumber);
            TestCheck.AssertIsEqual(phoneNumber, GetTextBoxValue("PhoneNumberText"), "Phone Number Text Box");
        }
    }
}
