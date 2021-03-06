﻿using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    //
    public class LocalOfficeApproverContractsAwaitingAcceptancePage : BasePage, IPageObject
    {
        private const string _url = "/mps/local-office/approval/contracts/awaiting-acceptance";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/approval/contracts/awaiting-acceptance\"]";// list Next  as "#DataTables_Table_0_next"

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

        private const string PaginateSelector = ".dataTables_paginate";

        [FindsBy(How = How.Id, Using = "content_1_ContractListFilter_InputFilterBy")]
        public IWebElement ContractFilter;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleContractList_List_ContractName_]")]
        public IList<IWebElement> ContractListContractNameRowElement;

        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";

        public void ClickOnViewSummary(int proposalId, string proposalName, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, proposalName, driver);
            SeleniumHelper.WaitUntilElementAppears(PaginateSelector);
            SeleniumHelper.SetListFilter(ContractFilter, proposalId, proposalName, ContractListContractNameRowElement);
            SeleniumHelper.ClickSafety( SeleniumHelper.ActionsDropdownElement(actionsButton).Last());
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }

    }
}
