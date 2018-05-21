namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverReportsDashboardPage : LocalOfficeReportsDashboardPage, IPageObject
    {
        private const string _url = "/mps/local-office/reports/dashboard";
        private const string _validationElementSelector = "ul.media-list";
        public new string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public new string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }
    }
}
