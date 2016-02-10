using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class ManageServicePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string PartnerButtonsSearchString = ".content-box.article-page .content-unit [href*=]";


        [FindsBy(How = How.XPath, Using = ".//tbody/tr[1]/td[6]/a")] 
        public IWebElement ViewSubscriptionButton;

        public CreateActivationCodesPage PurchaseCodesButtonClick()
        {
            var purchaseCodesButton = Driver.FindElement(By.CssSelector(PartnerButtonsSearchString.Replace("href*=", "href*='create-activation-codes'")));
            purchaseCodesButton.Click();
            return GetInstance<CreateActivationCodesPage>();
        }

        public void IsPurchaseActivateCodesButtonAvailable()
        {
            var purchaseCodesButton = Driver.FindElement(By.CssSelector(PartnerButtonsSearchString.Replace("href*=", "href*='create-activation-codes'")));
            if (purchaseCodesButton == null)
            {
                throw new NullReferenceException("Unable to locate Purchase Codes Button");
            }

            AssertElementPresent(purchaseCodesButton, "Purchase Codes Button");
        }

        public SubscriptionOverviewPage ClickViewSubscriptionButton()
        {
            if (ViewSubscriptionButton == null)
            {
                throw new NullReferenceException("Unable to locate the ViewSubscription button the page");
            }
            ViewSubscriptionButton.Click();
            return GetInstance<SubscriptionOverviewPage>(Driver);
        }
    }
}
