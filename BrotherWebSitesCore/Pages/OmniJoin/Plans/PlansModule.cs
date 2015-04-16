using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Basket;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;

namespace BrotherWebSitesCore.Pages.OmniJoin.Plans
{
    public static class PlansModule
    {
        // Static OmniJoin Plans class which services all OmniJoin plans pages to maximise reuse
        private const string BuyNowAtBrotherOnline = @"#content_0_maincontent_0_btnSubmit";
        private const string BillingSwitch = @"#content_0_maincontent_0_btnSwitchTerm";
        private const string TermsAndConditions = @"#ConfirmTOS";
        private const string PriceExcludingTax = @".priceexctax";

        private static IWebElement BuyNowButton(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(BuyNowAtBrotherOnline));
        }

        private static IWebElement BillingSwitchButton(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(BillingSwitch));
        }

        private static IWebElement TermsAndConditionsCheckbox(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(TermsAndConditions));
        }

        private static IWebElement PriceExcludingTaxText(ISearchContext driver)
        {
            return driver.FindElement(By.CssSelector(PriceExcludingTax));
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
