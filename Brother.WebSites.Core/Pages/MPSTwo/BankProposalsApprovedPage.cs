using Brother.WebSites.Core.Pages.Base;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankProposalsApprovedPage : BasePage, IPageObject
    {
        private const string _url = "/mps/bank/proposals/approved";
        private const string _validationElementSelector = ".active a[href=\"/mps/bank/proposals/approved\"]";// list Next 

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
