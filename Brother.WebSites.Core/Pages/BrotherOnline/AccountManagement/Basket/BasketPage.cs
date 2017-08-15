using System;
using System.ComponentModel.Design;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite.Basket
{
    public class BasketPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        //[FindsBy(How = How.CssSelector, Using = ".go-to-checkout")]
        //[FindsBy(How = How.XPath, Using = @"//*[@id='basket-page']/div/div/div[2]/div[2]/div/button")]
        [FindsBy(How = How.Id, Using = "basket-page--continue-checkout")]
        public IWebElement CheckOutButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_ContinueShoppingLink")]
        public IWebElement ContinueShoppingButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_BasketItemsRepeater_QuantityTextBox_0")]
        public IWebElement QuantityEditBox;

        [FindsBy(How = How.CssSelector, Using = ".product-info")]
        public IWebElement ProductInformationList;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div.content-unit.six > div.cart-view > div:nth-child(2) > div.col-item > div.product-info")]
        public IWebElement MyBasketProductInformationList;
        
        //Added locator
        [FindsBy(How = How.CssSelector, Using = "#content_0_CheckOutButton")]
        public IWebElement BasketPageCheckOutButton;

        [FindsBy(How = How.CssSelector, Using = "a[data-checkout-step-trigger='1']")] 
        public IWebElement ContinueAsGuestButton;

        [FindsBy(How = How.CssSelector, Using = "#frmGuest #email")]
        public IWebElement GuestEmailTextBox;

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement ExistingUserEmailTextBox;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement ExistingUserPasswordTextBox;

        [FindsBy(How = How.Id, Using = "title")]
        public IWebElement SelectTitleBox;

        [FindsBy(How = How.Id, Using = "txtFirstname")]
        public IWebElement FirstNameInputField;

        [FindsBy(How = How.Id, Using = "txtLastname")]
        public IWebElement LastNameInputField;

        [FindsBy(How = How.Id, Using = "txtTelephone")]
        public IWebElement PhoneNumberTextBox;

        [FindsBy(How = How.Id, Using = "txtMobilephone")]
        public IWebElement MobileNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "button[data-checkout-step-trigger='2']")] 
        public IWebElement ContinueToDeliveryButton;

        [FindsBy(How = How.Id, Using = "DeliveryAddress_PostCode")]
        public IWebElement PostcodeField;

        [FindsBy(How = How.CssSelector, Using = "fieldset[data-checkout-step='2'] button[data-postcode-lookup-button]")]
        public IWebElement FindAddressButton;

        [FindsBy(How = How.Id, Using = "DeliveryAddress_Housenumber")]
        public IWebElement HouseNumber;

        [FindsBy(How = How.Id, Using = "chkUseDeliveryAddress")]
        public IWebElement UseDeliveryyAddressCheckbox;

        [FindsBy(How = How.CssSelector, Using = "button[data-checkout-step-trigger='3']")]
        public IWebElement ContinueToBillingAndpaymentyButton;

        [FindsBy(How = How.Id, Using = "btnGuestPayment")]
        public IWebElement ContinueToPaymentButton;

        [FindsBy(How = How.Id, Using = "btnSignin")]
        public IWebElement ExistingUserSignInButton;

        [FindsBy(How = How.XPath, Using = @"//*[@id='Login1']/div/a[1]")]
        public IWebElement LogInButton;

        [FindsBy(How = How.CssSelector, Using = "[for='optpaymentmethod3']")]
        public IWebElement CashOnDeliveryRadioButton ;

        public void ClickOnContinueAsGuest()
        {
            ContinueAsGuestButton.Click();
        }

        public void ClickOnLoginButton()
        {
            ScrollTo(LogInButton);
            LogInButton.Click();
        }

        public void EnterName(string firstname, string lastname)
        {
            FirstNameInputField.SendKeys(firstname);
            LastNameInputField.SendKeys(lastname);
        }
        public void EnterEmail(string email)
        {
            ScrollTo(GuestEmailTextBox);
            GuestEmailTextBox.SendKeys(email);
        }

        public void EnterExistingUserName(string email)
        {
            ScrollTo(ExistingUserEmailTextBox);
            ExistingUserEmailTextBox.SendKeys(email);
        }

        public void EnterPasswordForExistingUser(string password)
        {
            ScrollTo(ExistingUserPasswordTextBox);
            ExistingUserPasswordTextBox.SendKeys(password);
        }

        public void ClickOnExistingUserSignInButton()
        {
            ExistingUserSignInButton.Click();
        }

        public void SelectTile()
        {
            SelectTitleBox.SendKeys(Keys.ArrowDown);
        }

        public void EnterPhoneNumber(string phonenumber, string mobilenumber)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            PhoneNumberTextBox.SendKeys(phonenumber);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            MobileNumberTextBox.SendKeys(mobilenumber);
        }

        public void ClickOnContinueToDelivery()
        {
            ScrollTo(ContinueToDeliveryButton);
            ContinueToDeliveryButton.Click();
        }

        public void EnterPostcode(string postcode)
        {
            PostcodeField.SendKeys(postcode);
        }

        public void ClickOnFindAddressButton()
        {
            FindAddressButton.Click();
            WaitForElementToBeClickableByCssSelector("fieldset[data-checkout-step='2'] button[data-postcode-lookup-button]", 3, 10);
        }

        public void EnterHouseNumber(string housenumber)
        {
            HouseNumber.SendKeys(housenumber);
        }

        public void ClickOnContinueToBillingAndPayment()
        {
            ScrollTo(ContinueToBillingAndpaymentyButton);
            ContinueToBillingAndpaymentyButton.Click();
        }

        public void ClickOnCashOnDeliveryRadioButton()
        {   
            WaitForElementToExistByCssSelector("[for='optpaymentmethod3']", 10, 10);
            CashOnDeliveryRadioButton.Click();
        }

        public OrderConfirmationPage ClickOnContinueToPayment()
        {
            ScrollTo(ContinueToPaymentButton);
            ContinueToPaymentButton.Click();
            return GetInstance<OrderConfirmationPage>(Driver);
            //return GetInstance<PaymentPage>(Driver);
            //return LoadPaymentCardDetailsFrame(Driver);
        }

        public void ClickOnCheckboxUseSameDeliveryAddress()
        {
            UseDeliveryyAddressCheckbox.Click();
        }

        private static IWebElement FindElement(ISearchContext driver, string element, string message)
        {
            if (WaitForElementToExistByCssSelector(element, 5, 5))
            {
                MsgOutput(string.Format("Basket Page: Found {0} element correctly", element));
                return driver.FindElement(By.CssSelector(element));
            }
            TestCheck.AssertFailTest(string.Format("Unable to locate Basket Page {0}", element));
            return null;

        }

        public void IsCheckoutButtonAvailable()
        {
            CheckOutButton = FindElement(TestController.CurrentDriver, ".go-to-checkout", "Check Out Button");
            if (CheckOutButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(CheckOutButton, "Is Check Out Button present and correct");
        }

        public void IsContinueShoppingButtonAvailable()
        {
            if (ContinueShoppingButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(ContinueShoppingButton, "Is Continue Shopping Button present and correct");
        }

        public DeliveryDetailsPage CheckOutButtonClick()
        {
            ScrollTo(CheckOutButton);
            CheckOutButton.Click();
            return GetInstance<DeliveryDetailsPage>(Driver);
        }

        public RegistrationPage CheckOutButtonClickBeforeLogin()
        {
            ScrollTo(CheckOutButton);
            CheckOutButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }
//Added

        public void IsBasketPageCheckoutButtonDisplayed()
        {

            TestCheck.AssertIsEqual(true, BasketPageCheckOutButton.Displayed, "Is BasketPage checkout button dislayed");
           //if (BasketPageCheckOutButton == null)
           // {
           //     throw new NullReferenceException("Unable to locate button on page");
           // }
           // AssertElementPresent(BasketPageCheckOutButton, "Is BasketPage Checkout Button present and correct");

        }
        public DeliveryDetailsPage BasketPageCheckOutButtonClick()
        {
            ScrollTo(BasketPageCheckOutButton);
            BasketPageCheckOutButton.Click();
            return GetInstance<DeliveryDetailsPage>(Driver);
        }


        // slight variation for OmniJoin as there is no delivery address
        public BillingDetailsPage OmniJoinCheckOutButtonClick()
        {
            CheckOutButton.Click();
            return GetInstance<BillingDetailsPage>(Driver);
        }

       public int GetItemQuantity()
        {
            return Convert.ToInt32(QuantityEditBox.GetAttribute("value"));
        }

        public string GetItemInBasket()
        {
            return GetBasketInformationItem();
        }

        public string GetBasketInformationItem()
        {
            if (!IsElementPresent(MyBasketProductInformationList)) return string.Empty;
            var itemPresent = MyBasketProductInformationList.Text;
            return itemPresent ?? string.Empty;
        }


    }
}
