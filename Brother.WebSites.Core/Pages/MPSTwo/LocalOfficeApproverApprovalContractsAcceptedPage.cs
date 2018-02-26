using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void VerifyContractFilter(int proposalId, string proposalName)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, proposalName);
            SeleniumHelper.SetListFilter(ContractFilter, proposalId, ContractListContractNameRowElement);
            if (proposalName == null) return;

            var actual = ContractListContractNameRowElement.First().Text;
            if (proposalName.Equals(actual) == false)
            {
                TestCheck.AssertFailTest(string.Format("VerifyContractFilter error proposalId={0}, expectName={1}, actual={2}", proposalId, proposalName, actual));
            }
        }
    }
}
