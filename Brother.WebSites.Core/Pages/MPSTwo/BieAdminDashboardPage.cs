using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BieAdminDashboardPage : BasePage, IPageObject
    {
        private string _validationElementSelector = ".separator [href=\"/mps/bie-admin/enhanced-usage-monitoring\"]";
        private const string _url = "/mps/bie-admin/dashboard";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bie-admin/enhanced-usage-monitoring\"] .media-body")] 
        public IWebElement EnhancedUsageMonitoringLink;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bie-admin/proposals\"] .media-body")]
        public IWebElement ProposalsListLink;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bie-admin/products\"] .media-body")]
        public IWebElement ProductsListLink;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bie-admin/products\"] .media-body")]
        public IWebElement PricingListLink;


        public void IsBieAdminDashboardDisplayed()
        {
            if(EnhancedUsageMonitoringLink == null)
                throw new Exception("Dashboard returns as null");

            TestCheck.AssertIsEqual(true, EnhancedUsageMonitoringLink.Displayed, "BIE Admin Dashbaord is not displayed");
        }

        public EnhancedUsageMonitoringInstalledPrinterPage NavigateToEnhancedUsageMonitoringPage()
        {
            if (EnhancedUsageMonitoringLink == null)
                throw new Exception("Enhanced Usage Monitoring returns as null");

            EnhancedUsageMonitoringLink.Click();

            return GetInstance<EnhancedUsageMonitoringInstalledPrinterPage>();
        }
    }
}
