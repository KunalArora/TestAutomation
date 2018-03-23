﻿using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsAwaitingApprovalPage : BasePage, IPageObject
    {
        public static string Url = "/";

        private const string _url = "/mps/dealer/proposals/awaiting-approval";
        private const string _validationElementSelector = ".js-mps-searchable";


        [FindsBy(How = How.Id, Using = "content_1_ProposalListFilter_InputFilterBy")]
        public IWebElement ProposalFilter;

        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleProposalList_List_ProposalNameRow_]")]
        public IList<IWebElement> ProposalListProposalNameRowElement;

        private const string actionsButtonSelector = @".js-mps-filter-ignore .dropdown-toggle";
        private const string summaryButtonSelector = @".js-mps-view-summary";
        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";

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

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        //[FindsBy(How = How.CssSelector, Using = "#content_1_InputSendToLeasingBank_Label")]
        //private IWebElement ThirdPartyApproval;
        private const string PaginateSelector = ".dataTables_paginate";


        private string CreatedProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = SpecFlow.GetContext("GeneratedProposalName");
            return createdProposal;
        }

        public void IsProposalSentToDealerAwaitingProposalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = CreatedProposal();

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public DealerProposalsCreateSummaryPage NavigateToViewSummary()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);
        }

        public void ClickOnViewSummary(int proposalId, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, driver);
            SeleniumHelper.WaitUntilElementAppears(PaginateSelector);
            SeleniumHelper.SetListFilter(ProposalFilter, proposalId.ToString(), ProposalListProposalNameRowElement);
            SeleniumHelper.ClickSafety(SeleniumHelper.ActionsDropdownElement(actionsButton).Last());
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }

    }
}
