using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerReportsDashboardPage : LocalOfficeReportsDashboardPage, IPageObject
    {
        private const string _validationElementSelector = "div.mps-dashboard";
        private const string _url = "/mps/dealer/reports/dashboard";

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

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/dealer/reports/cpp-agreement-report\"] .media-heading")]
        public IWebElement CPPAgreementReportElement;
    }
}
