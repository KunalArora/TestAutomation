using System;
using System.ComponentModel.Design;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
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
        [FindsBy(How = How.XPath, Using = @"//*[@id='basket-page']/div/div/div[2]/div[2]/div/button")]
        public IWebElement CheckOutButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_ContinueShoppingLink")] public IWebElement
            ContinueShoppingButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_BasketItemsRepeater_QuantityTextBox_0")] public IWebElement
            QuantityEditBox;

        [FindsBy(How = How.CssSelector, Using = ".product-info")]
        public IWebElement ProductInformationList;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div.content-unit.six > div.cart-view > div:nth-child(2) > div.col-item > div.product-info")]
        public IWebElement MyBasketProductInformationList;
        
        //Added locator
        [FindsBy(How = How.CssSelector, Using = "#content_0_CheckOutButton")]
        public IWebElement BasketPageCheckOutButton;

        [FindsBy(How = How.CssSelector, Using = "a[data-checkout-step-trigger='1']")] 
        public IWebElement ContinueAsGuestButton;

        [FindsBy(How = How.CssSelector, Using = "#email")]
        public IWebElement EnterEmailTextBox;

        [FindsBy(How = How.Id, Using = "title")]
        public IWebElement SelectTitleBox;


        public void ClickOnContinueAsGuest()
        {
            ContinueAsGuestButton.Click();
        }

        public void EnterEmail(string email)
        {
            ScrollTo(EnterEmailTextBox);
            EnterEmailTextBox.SendKeys(email);
        }

        public void SelectTile()
        {
            SelectTitleBox.SendKeys(Keys.ArrowDown);
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
