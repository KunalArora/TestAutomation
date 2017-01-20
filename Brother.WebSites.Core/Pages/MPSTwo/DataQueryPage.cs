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
        [FindsBy(How = How.CssSelector, Using = "#content_0_txtFromDate")]
        public IWebElement FromDateElement;
        [FindsBy(How = How.CssSelector, Using = "#content_0_txtToDate")]
        public IWebElement ToDateElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-proposal-3")]
        public IWebElement OpenProposalElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-proposal-5")]
        public IWebElement AwaitingApprovalProposalElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-proposal-7")]
        public IWebElement ApprovedProposalElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-proposal-12")]
        public IWebElement ClosedProposalElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-proposal-6")]
        public IWebElement DeclinedProposalElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-contract-8")]
        public IWebElement AwaitingAcceptanceContractElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-contract-10")]
        public IWebElement AcceptedContractElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-contract-9")]
        public IWebElement RunningContractElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-contract-13")]
        public IWebElement ClosedContractElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-status-contract-11")]
        public IWebElement RejectedContractElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-contracttype-2")]
        public IWebElement LeaseClickElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-contracttype-3")]
        public IWebElement PurchaseClickElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-usagetype-1")]
        public IWebElement MinimumVolumeElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-usagetype-2")]
        public IWebElement PayAsYouGoElement;
            
        
        



        private void ClearSearchCriteria()
        {
            if(ClearPreviousSearch == null)
                throw new Exception("Clear Search link is not returned as null");

            ClearPreviousSearch.Click();
            WaitForResultToBeBack();
        }

        public void IsResultDisplayedAfterSearch(int count)
        {
            var containerCount = ProposalControlContainerTitle.Count;

            TestCheck.AssertIsEqual(true, containerCount.Equals(count), "");
        }

        private void WaitForResultToBeBack()
        {
            TestCheck.AssertIsEqual(true, ProposalControlContainerTitle.Count > 0, "No result is returned");
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void AreContractTypeAndUsageTypeReturned()
        {
            WaitForResultToBeBack();
        }

        public void SearchWithDates()
        {
            if(FromDateElement == null)
                throw new Exception("From Date is null");
            if (FromDateElement == null)
                throw new Exception("To Date is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();
        }


        private void InputDatesAYearBackBeforeSearch()
        {
            var searchBegin = DateTime.Now.AddDays(-365).ToString("ddMMyyyy");
            var searchEnd = DateTime.Now.AddDays(365).ToString("ddMMyyyy");

            FromDateElement.SendKeys(searchBegin);
            ToDateElement.SendKeys(searchEnd);
        }


        private void InputDatesBeforeSearch()
        {
            var searchBegin = DateTime.Now.ToString("ddMMyyyy");
            var searchEnd = DateTime.Now.AddDays(365).ToString("ddMMyyyy");

            FromDateElement.SendKeys(searchBegin);
            ToDateElement.SendKeys(searchEnd);
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

            SearchWithGo();
        }

        public void ShowEndingContracts()
        {
            
        }


        public void FilterOpenProposalStatus()
        {
            if (OpenProposalElement == null)
                throw new Exception("Open proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            OpenProposalElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterAwaitingApprovalProposalStatus()
        {
            if (AwaitingApprovalProposalElement == null)
                throw new Exception("Awaiting Approval proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            AwaitingApprovalProposalElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterApprovedProposalStatus()
        {
            if (ApprovedProposalElement == null)
                throw new Exception("Approval proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            ApprovedProposalElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterClosedProposalStatus()
        {
            if (ClosedProposalElement == null)
                throw new Exception("Closed proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesAYearBackBeforeSearch();

            ClosedProposalElement.Click();
            WaitForResultToBeBack();
        }


        public void FilterDeclinedProposalStatus()
        {
            if (DeclinedProposalElement == null)
                throw new Exception("Declined proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesAYearBackBeforeSearch();

            DeclinedProposalElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterAwaitingAcceptanceContractStatus()
        {
            if (AwaitingAcceptanceContractElement == null)
                throw new Exception("Awaiting Acceptance contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            AwaitingAcceptanceContractElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterAcceptedContractStatus()
        {
            if (AcceptedContractElement == null)
                throw new Exception("Accepted contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            AcceptedContractElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterRunningContractStatus()
        {
            if (RunningContractElement == null)
                throw new Exception("Running contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            RunningContractElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterClosedContractStatus()
        {
            if (ClosedContractElement == null)
                throw new Exception("Closed contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            ClosedContractElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterRejectedContractStatus()
        {
            if (RejectedContractElement == null)
                throw new Exception("Rejected contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            RejectedContractElement.Click();
            WaitForResultToBeBack();
        }


        public void FilterLeaseAndClickContracts()
        {
            if (LeaseClickElement == null)
                throw new Exception("Lease and Click filter checkbox is null");
            ClearSearchCriteria();

            InputDatesAYearBackBeforeSearch();

            LeaseClickElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterPurchaseAndClickContracts()
        {
            if (PurchaseClickElement == null)
                throw new Exception("Purchase and click filter checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            PurchaseClickElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterMinimumVolumeContracts()
        {
            if (MinimumVolumeElement == null)
                throw new Exception("Minimum Volume checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            MinimumVolumeElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterPayAsYouGoContracts()
        {
            if (PayAsYouGoElement == null)
                throw new Exception("PAYG checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            PayAsYouGoElement.Click();
            WaitForResultToBeBack();
        }

        public void SearchForNewlyCreatedProposal()
        {
            if (DataQuerySearchField == null)
                throw new Exception("Data Query Search Field is returned as null");

            var proposal = MpsUtil.CreatedProposal();

            ClearSearchCriteria();

            WaitForElementToExistByCssSelector(".js-mps-list.js-mps-searchable");
            DataQuerySearchField.Clear();
            DataQuerySearchField.SendKeys(proposal);
        }

        public void SearchWithGo()
        {
            if (SearchButton == null)
                throw new Exception("Search button returned null");

            SearchButton.Click();
        }

        public void SearchWithContractId(string id)
        {
            ClearSearchCriteria();

            WaitForElementToExistByCssSelector(".js-mps-list.js-mps-searchable");
            ProposalIdSearchField.Clear();
            ProposalIdSearchField.SendKeys(id);

            SearchWithGo();
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

            SearchWithGo();
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
