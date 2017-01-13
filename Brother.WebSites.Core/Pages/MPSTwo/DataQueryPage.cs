using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DataQueryPage : BasePage
    {

        private const string SelectedProposal = @"#proposal-{0} .js-mps-proposal-link";


        [FindsBy(How = How.CssSelector, Using = "#content_0_txtInputSearch")]
        public IWebElement DataQuerySearchField;
        [FindsBy(How = How.CssSelector, Using = "#txtContractId")]
        public IWebElement ProposalIdSearchField;
        [FindsBy(How = How.CssSelector, Using = "#btnGo")]
        public IWebElement SearchButton;
        [FindsBy(How = How.CssSelector, Using = "#SerialNumberSearchInput")]
        public IWebElement SerialNumberSearchField;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-list-filter-clear")]
        public IWebElement ClearPreviousSearch;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-list-group")]
        public IList<IWebElement> ProposalControlContainerTitle;
        




        private void ClearSearchCriteria()
        {
            if(ClearPreviousSearch == null)
                throw new Exception("Clear Search link is not returned as null");

            ClearPreviousSearch.Click();
        }

        public void IsResultDisplayedAfterSearch(int count)
        {
            var containerCount = ProposalControlContainerTitle.Count;

            TestCheck.AssertIsEqual(true, containerCount.Equals(count), "");
        }

        private void WaitForResultToBeBack()
        {
            
        }


        private string ContractId()
        {
            var contractid = SpecFlow.GetContext("SummaryPageContractId");

            return contractid;
        }

        public void SearchUsingSerialNumber(string serialNumber)
        {
            if(SerialNumberSearchField == null)
                throw new Exception("Serial Number Search field is returned as null");
            ClearSearchCriteria();

            ClearAndType(SerialNumberSearchField, serialNumber);
        }


        public void SearchForNewlyCreatedProposal()
        {
            if (DataQuerySearchField == null)
                throw new Exception("Data Query Search Field is returned as null");

            var proposal = MpsUtil.CreatedProposal();

            WaitForElementToExistByCssSelector(".js-mps-list.js-mps-searchable");
            DataQuerySearchField.Clear();
            DataQuerySearchField.SendKeys(proposal);
        }

        public void SearchForNewlyCreatedProposalByProposalId()
        {
            if (ProposalIdSearchField == null)
                throw new Exception("ProposalId Search Field is returned as null");
            if (SearchButton == null)
                throw new Exception("Search Button is returned as null");

            var proposal = ContractId();

            WaitForElementToExistByCssSelector(".js-mps-list.js-mps-searchable");
            ProposalIdSearchField.Clear();
            ProposalIdSearchField.SendKeys(proposal);

            SearchButton.Click();
        }

        public ReportProposalSummaryPage ClickOnSearchedProposal()
        {
            var displayedProposal = string.Format(SelectedProposal, ContractId());
            var proposalElement = Driver.FindElement(By.CssSelector(displayedProposal));

            if (proposalElement == null)
                throw new Exception("Proposal Element is returned as null");

            proposalElement.Click();

            return GetInstance<ReportProposalSummaryPage>();
        }

        
    }
}
