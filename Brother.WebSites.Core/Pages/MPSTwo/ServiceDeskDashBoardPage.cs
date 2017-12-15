using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ServiceDeskDashBoardPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = ".separator [href=\"/mps/local-office/service-desk\"]"; // Service Desk URL selector
        private const string _url = "/mps/local-office/dashboard";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }



        [FindsBy(How = How.CssSelector, Using = ".media-list a[href=\"/mps/local-office/service-desk\"] h4")]
        public IWebElement ServiceDeskLink;
        [FindsBy(How = How.CssSelector, Using = ".media-list a[href=\"/mps/local-office/reports\"] h4")]
        public IWebElement ServiceReportLink;



        public void IsDashboardPageDisplayed()
        {
            if(ServiceDeskLink == null)
                throw new Exception("Service Desk dashboard page is not displayed");

            AssertElementPresent(ServiceDeskLink, "Service Desk dashboard page");
        }

        public ServiceDeskServiceRequestsPage NavigateToServiceDeskPage()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ServiceDeskLink);
            return GetInstance<ServiceDeskServiceRequestsPage>();
        }

        public ReportingDashboardPage NavigateToServiceDeskReportPage()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ServiceReportLink);
            return GetInstance<ReportingDashboardPage>();
        }
    }
}
