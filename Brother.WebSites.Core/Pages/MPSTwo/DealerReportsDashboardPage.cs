namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerReportsDashboardPage : ReportingDashboardPage, IPageObject
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

    }
}
