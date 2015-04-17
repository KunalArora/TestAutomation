﻿using System;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.BrotherOnline.AccountManagement.PaymentMethods
{
    public class AddNewCardPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".billing-change.button-grey")]
        public IWebElement ChangeBillingAddressButton;

        public void IsChangeBillingAddressButtonAvailable()
        {
            if (ChangeBillingAddressButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(ChangeBillingAddressButton, "Change Billing Address Button");
        }

        public void ChangeBillingAddressButtonClick()
        {
            ChangeBillingAddressButton.Click();
        }

    }
}
