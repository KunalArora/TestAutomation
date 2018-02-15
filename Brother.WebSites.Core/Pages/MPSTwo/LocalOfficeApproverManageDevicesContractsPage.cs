using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverManageDevicesContractsPage : DealerContractsPage, IPageObject
    {
        private const string _url = "/mps/local-office/manage-devices/contracts";
        private const string _validationElementSelector = "a[href=\"/mps/local-office/manage-devices/contracts\"]"; // Contracts tab element

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

        [FindsBy(How = How.Id, Using = "content_1_ContractListFilter_InputFilterBy")]
        public IWebElement InputFilterBy;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleContractList_List_ContractName_]")]
        public IList<IWebElement> ContractOrProposalNameElementList;

        public void SetListFilter(int contractId)
        {
            LoggingService.WriteLogOnMethodEntry(contractId);
            SeleniumHelper.SetListFilter(InputFilterBy, contractId, ContractOrProposalNameElementList);
        }
    }
}
