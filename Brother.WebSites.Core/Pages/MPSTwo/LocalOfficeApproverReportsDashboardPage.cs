using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverReportsDashboardPage : ReportingDashboardPage, IPageObject
    {
        private const string _url = "/mps/local-office/reports/dashboard";
        private const string _validationElementSelector = "ul.media-list";
        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }
    }
}
