namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankContractsAwaitingAcceptancePage : LocalOfficeApproverContractsAwaitingAcceptancePage, IPageObject
    {
        private const string _validationElementSelector = ".active a[href=\"/mps/bank/contracts/awaiting-acceptance\"]"; // list Next as "#DataTables_Table_0_next"
        private const string _url = "/mps/bank/contracts/awaiting-acceptance";

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
