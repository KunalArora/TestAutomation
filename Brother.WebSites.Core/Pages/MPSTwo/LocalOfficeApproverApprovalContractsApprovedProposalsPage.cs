namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalContractsApprovedProposalsPage : LocalOfficeApproverContractsPage, IPageObject
    {
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/approval/contracts/approved-proposals\"]"; // list Next as "#DataTables_Table_0_next"
        private const string _url = "/mps/local-office/approval/contracts/approved-proposals";

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

    }
}
