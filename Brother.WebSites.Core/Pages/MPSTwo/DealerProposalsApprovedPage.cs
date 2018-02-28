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

        public void ClickOnViewOffer(int proposalId, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, driver);
            SeleniumHelper.SetListFilter(ContractFilter, proposalId, ContractListContractNameRowElement);
            SeleniumHelper.ClickSafety(SeleniumHelper.ActionsDropdownElement(actionsButton).Last());
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver); // ViewOffer ASIS 
        }

        private ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton)
        {
            LoggingService.WriteLogOnMethodEntry(actionsButton);
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

        private const string actionsButton = @".js-mps-filter-ignore > .dropdown-toggle";
        private const string actionSummaryButton = ".js-mps-view-summary";

        public void ClickOnSummaryPage(int proposalId, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId,driver);
            SeleniumHelper.SetListFilter(FilterSearchFieldElement, proposalId, ProposalListProposalNameRowElement, waitSelector: "#DataTables_Table_0_info");
            var actionElement = SeleniumHelper.FindElementByCssSelector(actionsButton);
            SeleniumHelper.ClickSafety(actionElement);
            var actionSummaryElement = SeleniumHelper.FindElementByCssSelector(actionSummaryButton);
            SeleniumHelper.ClickSafety(actionSummaryElement);
        }
    }


}
