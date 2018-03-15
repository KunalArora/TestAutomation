using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsRejectedPage : CloudExistingProposalPage, IPageObject
    {
        private const string _url = "/mps/dealer/contracts/rejected";
        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/contracts/rejected\"]";

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
        public IWebElement InputFilterByElement;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleContractList_List_ContractName_]")]
        public IList<IWebElement> ContractListContractNameElement;
        
        public bool VerifyRejectedContractInRejectedContractsList(int proposalId, string proposalName)
        {
            return VerifyProposalInProposalsList(proposalId, proposalName, InputFilterByElement, ContractListContractNameElement);
        }
    }
}
