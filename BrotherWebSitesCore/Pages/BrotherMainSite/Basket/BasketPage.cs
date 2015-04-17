﻿using System;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.BrotherMainSite.SuppliesAndAccessories;
using BrotherWebSitesCore.Pages.BrotherOnline.Checkout;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.BrotherMainSite.Basket
{
    public class BasketPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".go-to-checkout")] 
        public IWebElement CheckOutButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_ContinueShoppingLink")] public IWebElement
            ContinueShoppingButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_BasketItemsRepeater_QuantityTextBox_0")] public IWebElement
            QuantityEditBox;

        [FindsBy(How = How.CssSelector, Using = ".product-info")]
        public IWebElement ProductInformationList;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div.content-unit.six > div.cart-view > div:nth-child(2) > div.col-item > div.product-info")]
        public IWebElement MyBasketProductInformationList;

        public void IsCheckoutButtonAvailable()
        {
            if (CheckOutButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementValue(CheckOutButton, "Checkout", "Check Out Button");
        }

        public void IsContinueShoppingButtonAvailable()
        {
            if (ContinueShoppingButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementValue(ContinueShoppingButton, "Continue Shopping", "Continue Shopping Button");
        }

        public DeliveryDetailsPage CheckOutButtonClick()
        {
            ScrollTo(CheckOutButton);
            CheckOutButton.Click();
            return GetInstance<DeliveryDetailsPage>(Driver);
        }

        // slight variation for OmniJoin as there is no delivery address
        public BillingDetailsPage OmniJoinCheckOutButtonClick()
        {
            CheckOutButton.Click();
            return GetInstance<BillingDetailsPage>(Driver);
        }

        public InkJetCartridgePage ContinueShoppingButtonClick()
        {
            ContinueShoppingButton.Click();
            return GetInstance<InkJetCartridgePage>(Driver);
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
