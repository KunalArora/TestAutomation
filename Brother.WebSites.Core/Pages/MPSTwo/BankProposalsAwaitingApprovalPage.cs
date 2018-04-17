using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankProposalsAwaitingApprovalPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "table.dataTable";
        private const string _url = "/mps/bank/proposals/awaiting-approval";

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
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleProposalList_List_ProposalNameRow_]")]
        public IList<IWebElement> ProposalListProposalNameRowElement;

        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string PaginateSelector = ".dataTables_paginate";


        public void ClickOnViewSummary(int proposalId, string proposalName, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, proposalName, driver);
            SeleniumHelper.WaitUntilElementAppears(PaginateSelector);
            SeleniumHelper.SetListFilter(ProposalFilter, proposalId, proposalName, ProposalListProposalNameRowElement);
            SeleniumHelper.ClickSafety(SeleniumHelper.ActionsDropdownElement(actionsButton).Last());
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }


    }
}
