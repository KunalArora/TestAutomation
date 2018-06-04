using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerReportsDashboardPage : LocalOfficeReportsDashboardPage, IPageObject
    {
        private const string _validationElementSelector = "div.mps-dashboard";
        private const string _url = "/mps/dealer/reports/dashboard";

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/reports/cpp-agreement-devices-report\"] .media-heading")]
        public IWebElement CppAgreementDevicesReportElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/reports/cpp-agreement-report\"] .media-heading")]
        public IWebElement CppAgreementReportElement;

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/reports/data-query\"] .media-heading")]
        public IWebElement DataQueryElement;

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }


    }
}
