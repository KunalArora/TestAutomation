using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalContractsAcceptedPage : BasePage, IPageObject
    {
        private const string _url = "/mps/local-office/approval/contracts/accepted";
        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/approval/contracts/accepted\"]"; // list Next (#DataTables_Table_0_next)


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

        public void VerifyContractFilter(int proposalId, string proposalName, int findElementTimeout)
        {
            ClearAndType(ContractFilter, proposalId.ToString());
            if(proposalName == null)
            {
                SeleniumHelper.WaitUntil(d => ContractListContractNameRowElement.Count == 1, findElementTimeout);
            }
            else
            {
                SeleniumHelper.WaitUntil(d => { try { return ContractListContractNameRowElement.First().Text == proposalName; } catch { return false; } }, findElementTimeout);
            }
            
        }
    }
}
