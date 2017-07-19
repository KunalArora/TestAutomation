using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class FinanceDashboardPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/finance/accruals\"] .media-body")]
        public IWebElement AccrualLinkElement;

        public void IsfinanceDashboardDisplayed()
        {
            if (AccrualLinkElement == null)
                throw new Exception("Dashboard returns as null");

            TestCheck.AssertIsEqual(true, AccrualLinkElement.Displayed, "Finance Dashbaord is not displayed");
        }

        public void NavigateToAccrualDownloadPage()
        {
            if (AccrualLinkElement == null)
                throw new Exception("Dashboard returns as null");

            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, AccrualLinkElement);
        }
    }
}
