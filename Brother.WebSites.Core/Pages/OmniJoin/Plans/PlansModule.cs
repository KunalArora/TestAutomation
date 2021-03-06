﻿using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.OmniJoin.Plans
{
    public static class PlansModule
    {
        // Static OmniJoin Plans class which services all OmniJoin plans pages to maximise reuse
        private const string BuyNowAtBrotherOnline = @"#content_0_maincontent_0_btnSubmit";
        private const string BillingSwitch = @"#content_0_maincontent_0_btnSwitchTerm";
        private const string TermsAndConditions = @"#ConfirmTOS";
        private const string PriceExcludingTax = @".priceexctax";

        private static IWebElement FindElement(ISearchContext driver, string element, string message)
        {
            if (SeleniumHelper.WaitForElementToExistByCssSelector(element, 5, 5))
            {
                Helper.MsgOutput(string.Format("Plans Module : {0} found", element));
                return driver.FindElement(By.CssSelector(element));
            }
            
            TestCheck.AssertFailTest(string.Format("Plans Module : Unable to locate Basket Item {0}", element));
            return null;
        }

        private static IWebElement BuyNowButton(ISearchContext driver)
        {
            return FindElement(driver, BuyNowAtBrotherOnline, "Buy Now At Brother Online Button");
        }

        private static IWebElement BillingSwitchButton(ISearchContext driver)
        {
            return FindElement(driver, BillingSwitch, "Billing Switch Button");
        }

        private static IWebElement TermsAndConditionsCheckbox(ISearchContext driver)
        {
            return FindElement(driver, TermsAndConditions, "Terms and Conditions Checkbox");
        }

        private static IWebElement PriceExcludingTaxText(ISearchContext driver)
        {
            return FindElement(driver, PriceExcludingTax, "Price Excluding tax");
        }

        public static void IsBuyNowAtBrotherOnlineButtonAvailable(IWebDriver driver)
        {
            if (BuyNowButton(driver) == null)
            {
                TestCheck.AssertFailTest("Unable to locate button on page");
            }
            SeleniumHelper.AssertElementPresent(BuyNowButton(driver), "Buy Now At Brother Online Button");
        }

        public static void SwitchBillingButtonClick(IWebDriver driver)
        {
            SeleniumHelper.ScrollTo(driver, BillingSwitchButton(driver));
            BillingSwitchButton(driver).Click();
        }

        public static void AgreeToTermsAndConditionsClick(IWebDriver driver)
        {
            var tcTickbox = TermsAndConditionsCheckbox(driver);
            SeleniumHelper.AssertElementPresent(tcTickbox, "OJ Terms and Conditions checkbox");
            SeleniumHelper.ScrollTo(driver, tcTickbox);
            WebDriver.Wait(Helper.DurationType.Second, 2);
            TestCheck.AssertIsEqual(true, SeleniumHelper.SetCheckboxStatus("#ConfirmTOS", true, "OmniJoin Plan purchase Accept Terms and Conditions Checkbox"), "OmniJoin Plan purchase Accept Terms and Conditions Checkbox was not checked");
        }

        public static BasketPage BuyNowAtBrotherOnlineButtonClick(IWebDriver driver)
        {
            SeleniumHelper.ScrollTo(driver, BuyNowButton(driver));
            BuyNowButton(driver).Click();
            return BasePage.GetInstance<BasketPage>(driver, "", "");
        }

        public static string GetPriceExTax(IWebDriver driver)
        {
            return PriceExcludingTaxText(driver).Text;
        }
    }
}
