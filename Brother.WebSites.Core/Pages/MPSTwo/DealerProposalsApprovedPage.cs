﻿using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsApprovedProposalPage : BasePage, IPageObject
    {
        private const string _url = "/mps/dealer/contracts/approved-proposals";
        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/contracts/approved-proposals\"]";// list Next 


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

        [FindsBy(How = How.Id, Using = "content_1_ContractListFilter_InputFilterBy")]
        public IWebElement ContractFilter;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleContractList_List_ContractName_]")]
        public IList<IWebElement> ContractListContractNameRowElement;

        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";

        public void ClickOnViewOffer(int proposalId, int findElementTimeout, IWebDriver driver)
        {
            ClearAndType(ContractFilter, proposalId.ToString());
            SeleniumHelper.WaitUntil(d => ContractListContractNameRowElement.Count == 1 , findElementTimeout);
            SeleniumHelper.ClickSafety( SeleniumHelper.ActionsDropdownElement(actionsButton).Last(), findElementTimeout) ;
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver); // ViewOffer ASIS 
        }

        private ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton)
        {
            var actionsElement = Driver.FindElements(By.CssSelector(actionsButton));
            return actionsElement;
        }

    }

    public class DealerProposalsApprovedPage : BasePage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/approved";
        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/proposals/approved\"]";// list Next 

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

        [FindsBy(How = How.CssSelector, Using = ".js-mps-filter-search-field")]
        public IWebElement FilterSearchFieldElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleProposalList_List_ProposalNameRow_]")]
        public IList<IWebElement> ProposalListProposalNameRowElement;

        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";

        public void ClickOnSummaryPage(string text, int timeout, IWebDriver driver)
        {
            ClearAndType(FilterSearchFieldElement, text);
            SeleniumHelper.WaitUntil(d => ProposalListProposalNameRowElement.Count == 1, timeout);
            SeleniumHelper.ClickSafety(SeleniumHelper.ActionsDropdownElement(actionsButton).Last(), timeout);
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }
    }


}