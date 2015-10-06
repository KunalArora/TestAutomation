using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class PartnerPortalPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string PartnerButtonsSearchString = ".content-box.article-page .content-unit [href*=]";

        public ManageServicePage ManageServicesButtonClick()
        {
            var manageServicesButton = Driver.FindElement(By.CssSelector(PartnerButtonsSearchString.Replace("href*=", "href*='my-services'")));
            manageServicesButton.Click();
            return GetInstance<ManageServicePage>();
        }

        public ManageCustomersAndOrdersPage ManageCustomersAndOrdersButtonClick()
        {
            var manageCustomersAndOrdersButton = Driver.FindElement(By.CssSelector(PartnerButtonsSearchString.Replace("href*=", "href*='my-customers'")));
            manageCustomersAndOrdersButton.Click();
            return GetInstance<ManageCustomersAndOrdersPage>();
        }

        public void IsHomeButtonAvailable()
        {
            var homeButton = Driver.FindElement(By.CssSelector(PartnerButtonsSearchString.Replace("href*=", "href*='partner-portal'")));
            if (homeButton == null)
            {
                throw new NullReferenceException("Unable to locate Home Button");
            }

            AssertElementPresent(homeButton, "Home Button");
        }
    }
}
