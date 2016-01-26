using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ServiceDeskDashBoardPage : BasePage
    {
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

        public ServiceDeskReportingPage NavigateToServiceDeskReportPage()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ServiceReportLink);
            return GetInstance<ServiceDeskReportingPage>();
        }
    }
}
