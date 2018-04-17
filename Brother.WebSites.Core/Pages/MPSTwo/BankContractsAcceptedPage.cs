using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankContractsAcceptedPage : LocalOfficeApproverApprovalContractsAcceptedPage, IPageObject
    {
        private const string _url = "/mps/bank/contracts/accepted";
        private const string _validationElementSelector = "#DataTables_Table_0_next";


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

        [FindsBy(How = How.Id, Using = "content_1_ContractListFilter_InputFilterBy")]
        public IWebElement ContractFilter;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleContractList_List_ContractName_]")]
        public IList<IWebElement> ContractListProposalNameRowElement;
        [FindsBy(How = How.Id, Using = "content_1_SimpleContractList_List_ListActions_0_List_0_Link_1")]
        public IWebElement ActionsContractEdit;

        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";
        private const string PaginateSelector = ".dataTables_paginate";


        public void ClickOnContractEdit(int contractId, string proposalName, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(contractId, driver);
            SeleniumHelper.WaitUntilElementAppears(PaginateSelector);
            SeleniumHelper.SetListFilter(ContractFilter, contractId, proposalName, ContractListProposalNameRowElement);
            SeleniumHelper.ClickSafety(SeleniumHelper.ActionsDropdownElement(actionsButton).Last());
            SeleniumHelper.ClickSafety(ActionsContractEdit, IsUntilUrlChanges: true);
            // goto /mps/bank/contracts/maintenance          
        }

    }
}
