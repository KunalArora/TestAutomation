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
    public class ServiceDeskServiceRequestsPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = ".media-list a[href=\"/mps/local-office/service-desk/service-requests\"] div h4")]
        public IWebElement ServiceDeskServiceRequestLink;
        [FindsBy(How = How.CssSelector, Using = ".media-list a[href=\"/mps/local-office/service-desk/print-counts\"] div h4")]
        public IWebElement ServiceDeskPrintCountLink;

        public void IsServiceRequestDashBoardDisplayed()
        {
            if(ServiceDeskServiceRequestLink == null)
                throw new Exception("Service Desk Service Requests Dashboard page not displayed");

            AssertElementPresent(ServiceDeskServiceRequestLink, "Service Request dashboard");
        }

        public ServiceRequestsPage NavigateToServiceRequestsPage()
        {
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ServiceDeskServiceRequestLink);
            return GetInstance<ServiceRequestsPage>();
        }

    }
}
