using System;
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
            try
            {
                return driver.FindElement(By.CssSelector(element));
            }
            catch (WebDriverException elementNotFound)
            {
                Helper.MsgOutput(string.Format("Unable to locate element {0} [{1}]", element, message));
            }
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
            TermsAndConditionsCheckbox(driver).Click();
            TestCheck.AssertIsEqual("True", TermsAndConditionsCheckbox(driver).Selected.ToString(), "Accept Terms and Conditions Button");
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
