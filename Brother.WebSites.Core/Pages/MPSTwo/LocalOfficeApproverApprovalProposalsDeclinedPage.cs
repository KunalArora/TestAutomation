using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalProposalsDeclinedPage : BaseSummaryPage, IPageObject
    {
        private const string _url = "/mps/local-office/approval/proposals/declined";
        private const string _validationElementSelector = "#DataTables_Table_0_wrapper";

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
