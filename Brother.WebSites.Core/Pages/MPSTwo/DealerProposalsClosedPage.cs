using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsClosedPage : CloudExistingProposalPage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/closed";
        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/proposals/closed\"]";// list Next 

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

        [FindsBy(How = How.Id, Using = "content_1_ProposalListFilter_InputFilterBy")]
        public IWebElement ProposalFilter;

        public void IsClosedProposalPresent(int proposalId, string proposalName)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, proposalName);
            SeleniumHelper.SetListFilter(ProposalFilter, proposalId, proposalName, ProposalListProposalNameRowElement, waitSelector: "#DataTables_Table_0_info");
        }
    }
}