﻿using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Checkout
{
    public class OrderConfirmationPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a.button-grey")]
        [CacheLookup]
        public IWebElement AccountButtonFindThisPlease;

        [CacheLookup]
        [FindsBy(How = How.CssSelector, Using = ".btns-container a.button-grey")]
        public IWebElement MyAccountButton;

        [FindsBy(How = How.CssSelector, Using = ".cf .price")]
        public IWebElement ItemPrice;

        [FindsBy(How = How.CssSelector, Using = ".products .product-info")]
        public IWebElement ProductInfo;

        [FindsBy(How = How.CssSelector, Using = ".purchase-confirmed")]
        public IWebElement PurchaseInfo;

        [FindsBy(How = How.CssSelector, Using = ".box-out.purchase-confirmed h3")]
        public IWebElement OrderConfirmationNumber;

        private const string OrderNumberString = @"Order Number : ";
        private const string PriceString = @"PRICE";
        private const string BillingTermString = @"Term: ";

        private const string BillingTermCssSelectorText = ".product-info div";

        private const string MyAccountMenuButtonCssId =
            ".content.cf .wrapper .content-box.checkout-container.cf .box-out.purchase-confirmed .button-grey";

        public string GetBillingType()
        {
            var billingTypeElements = Driver.FindElements(By.CssSelector(BillingTermCssSelectorText));

            try
            {
                foreach (var billingTypeElement in billingTypeElements)
                {
                    if (billingTypeElement.Text.Contains(BillingTermString))
                    {
                        return billingTypeElement.Text.Remove(0, BillingTermString.Length);
                    }
                }
            }
            catch (NoSuchElementException noSuchElement)
            {
                MsgOutput("Unable to locate Billing Type element on page", noSuchElement.Message);
            }
            return string.Empty;
        }

        public void IsMyAccountButtonAvailable()
        {
            AssertElementPresent(MyAccountButton, "Order Confirmation : My Account Button availability check", 3000);
        }

        public MyAccountPage MyAccountButtonClick()
        {
            MyAccountButton.Click();
            return GetInstance<MyAccountPage>(Driver);
        }

        public string GetItemPrice()
        {
            return ItemPrice.Text.Contains(PriceString) ? ItemPrice.Text.Remove(0, PriceString.Length) : ItemPrice.Text;
        }

        public string GetProductInfo()
        {
            return ProductInfo.Text;
        }

        public string GetPurchaseConfirmation()
        {
            return PurchaseInfo.Text;
        }

        public string GetOrderConfirmationNumber()
        {
            // remove the prefix from the Order Number
            return OrderConfirmationNumber == null ? string.Empty : OrderConfirmationNumber.Text.Remove(0, OrderNumberString.Length);
        }

        public bool ValidateSapOrderNumber(string orderNumber)
        {
            return Utils.ConfirmSapOrder(orderNumber);
        }
    }
}
