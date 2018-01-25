using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class ServiceDeskServiceDeskDashBoardPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = "a[href=\"/mps/local-office/service-desk/service-requests\"]";
        private const string _url = "/mps/local-office/service-desk/dashboard";

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

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Web Elements

        [FindsBy(How = How.CssSelector, Using = ".media-list a[href=\"/mps/local-office/service-desk/service-requests\"] h4")]
        public IWebElement ServiceRequestsLink;
        [FindsBy(How = How.CssSelector, Using = ".media-list a[href=\"/mps/local-office/service-desk/print-counts\"] h4")]
        public IWebElement PrintCountsLink;
        [FindsBy(How = How.CssSelector, Using = ".media-list a[href=\"/mps/local-office/service-desk/communication-logs\"] h4")]
        public IWebElement CommunicationLogsLink;
    }
}
