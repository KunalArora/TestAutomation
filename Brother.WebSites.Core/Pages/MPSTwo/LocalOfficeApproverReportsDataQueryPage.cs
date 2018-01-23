using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverReportsDataQueryPage : DataQueryPage, IPageObject
    {
        private const string _url = "/mps/local-office/reports/data-query";
        private const string _validationElementSelector = "#MpsAppContent > div > div > div > div.col-md-9.js-mps-report-list-container > div.js-mps-list.js-mps-searchable";

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

        public void ClickOnSearchedProposal(int proposalId, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId,findElementTimeout);
            var proposalIdString = proposalId.ToString();
            SeleniumHelper.WaitUntil(d =>
            {
                try
                {
                    var ProposalLinkElement = ProposalLinkElements.First(e => e.GetAttribute("data-proposal-id") == proposalIdString);
                    ProposalLinkElement.Click();
                    return true;
                }
                catch { return false; }
            }, findElementTimeout);
        }
    }
}
