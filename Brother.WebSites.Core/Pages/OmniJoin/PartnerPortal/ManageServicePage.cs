using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class ManageServicePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private string partnerButtonsSearchString = ".content-box.article-page .content-unit [href*=]";

        public CreateActivationCodesPage PurchaseCodesButtonClick()
        {
            var purchaseCodesButton = Driver.FindElement(By.CssSelector(partnerButtonsSearchString.Replace("href*=", "href*='create-activation-codes'")));
            purchaseCodesButton.Click();
            return GetInstance<CreateActivationCodesPage>();
        }

        public void IsPurchaseActivateCodesButtonAvailable()
        {
            var purchaseCodesButton = Driver.FindElement(By.CssSelector(partnerButtonsSearchString.Replace("href*=", "href*='create-activation-codes'")));
            if (purchaseCodesButton == null)
            {
                throw new NullReferenceException("Unable to locate Purchase Codes Button");
            }

            AssertElementPresent(purchaseCodesButton, "Purchase Codes Button");
        }
    }
}
