using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DataQueryPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = ".js-mps-report-list-container";
        private const string _url = "/mps/local-office/reports/data-query";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        private const string SelectedProposal = @"#proposal-{0} .js-mps-proposal-link";
        private const string MpsListNotesSelector = ".mps-list-notes";
        private const string MpsListItemSelector = ".js-mps-list-item";
        private const string AgreementLinkSelector = "span.js-mps-agreement-link";



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
        [FindsBy(How = How.CssSelector, Using = ".js-mps-proposal-link")]
        public IList<IWebElement> ProposalLinkElements;
        [FindsBy(How = How.CssSelector, Using = "div.row.mps-proposal.js-mps-proposal.mps-list-row:not(.hidden)")]
        public IList<IWebElement> VisibleItemDivElements;

        private void ClearSearchCriteria()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ClearPreviousSearch == null)
                throw new Exception("Clear Search link is not returned as null");

            ClearPreviousSearch.Click();
            WaitForResultToBeBack();
        }

        public void IsResultDisplayedAfterSearch(int count)
        {
            LoggingService.WriteLogOnMethodEntry(count);
            var containerCount = ProposalControlContainerTitle.Count;

            TestCheck.AssertIsEqual(true, containerCount.Equals(count), "");
        }

        private void WaitForResultToBeBack()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, ProposalControlContainerTitle.Count > 0, "No result is returned");
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void AreContractTypeAndUsageTypeReturned()
        {
            LoggingService.WriteLogOnMethodEntry();
            WaitForResultToBeBack();
        }

        public void SearchWithDates()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (FromDateElement == null)
                throw new Exception("From Date is null");
            if (FromDateElement == null)
                throw new Exception("To Date is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();
        }


        private void InputDatesYearsBackBeforeSearch()
        {
            LoggingService.WriteLogOnMethodEntry();
            var searchBegin = DateTime.Now.AddDays(-1095).ToString("ddMMyyyy");
            var searchEnd = DateTime.Now.AddDays(365).ToString("ddMMyyyy");

            FromDateElement.SendKeys(searchBegin);
            ToDateElement.SendKeys(searchEnd);
        }


        private void InputDatesBeforeSearch()
        {
            LoggingService.WriteLogOnMethodEntry();
            var searchBegin = DateTime.Now.AddDays(-1095).ToString("ddMMyyyy");
            var searchEnd = DateTime.Now.AddDays(365).ToString("ddMMyyyy");

            FromDateElement.SendKeys(searchBegin);
            ToDateElement.SendKeys(searchEnd);
        }


        private string ContractId()
        {
            LoggingService.WriteLogOnMethodEntry();
            var contractid = SpecFlow.GetContext("SummaryPageContractId");

            return contractid;
        }

        public void SearchUsingSerialNumber(string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber);
            if (SerialNumberSearchField == null)
                throw new Exception("Serial Number Search field is returned as null");
            ClearSearchCriteria();

            ClearAndType(SerialNumberSearchField, serialNumber);

            SearchWithGo();
        }

        public void ShowEndingContracts()
        {
            LoggingService.WriteLogOnMethodEntry();
        }


        public void FilterOpenProposalStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (OpenProposalElement == null)
                throw new Exception("Open proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            OpenProposalElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterAwaitingApprovalProposalStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AwaitingApprovalProposalElement == null)
                throw new Exception("Awaiting Approval proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            AwaitingApprovalProposalElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterApprovedProposalStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ApprovedProposalElement == null)
                throw new Exception("Approval proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            ApprovedProposalElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterClosedProposalStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ClosedProposalElement == null)
                throw new Exception("Closed proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesYearsBackBeforeSearch();

            ClosedProposalElement.Click();
            WaitForResultToBeBack();
        }


        public void FilterDeclinedProposalStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (DeclinedProposalElement == null)
                throw new Exception("Declined proposal checkbox is null");
            ClearSearchCriteria();

            InputDatesYearsBackBeforeSearch();

            DeclinedProposalElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterAwaitingAcceptanceContractStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AwaitingAcceptanceContractElement == null)
                throw new Exception("Awaiting Acceptance contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            AwaitingAcceptanceContractElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterAcceptedContractStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AcceptedContractElement == null)
                throw new Exception("Accepted contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            AcceptedContractElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterRunningContractStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (RunningContractElement == null)
                throw new Exception("Running contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            RunningContractElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterClosedContractStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ClosedContractElement == null)
                throw new Exception("Closed contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            ClosedContractElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterRejectedContractStatus()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (RejectedContractElement == null)
                throw new Exception("Rejected contract checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            RejectedContractElement.Click();
            WaitForResultToBeBack();
        }


        public void FilterLeaseAndClickContracts()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (LeaseClickElement == null)
                throw new Exception("Lease and Click filter checkbox is null");
            ClearSearchCriteria();

            InputDatesYearsBackBeforeSearch();

            LeaseClickElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterPurchaseAndClickContracts()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PurchaseClickElement == null)
                throw new Exception("Purchase and click filter checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            PurchaseClickElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterMinimumVolumeContracts()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (MinimumVolumeElement == null)
                throw new Exception("Minimum Volume checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            MinimumVolumeElement.Click();
            WaitForResultToBeBack();
        }

        public void FilterPayAsYouGoContracts()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PayAsYouGoElement == null)
                throw new Exception("PAYG checkbox is null");
            ClearSearchCriteria();

            InputDatesBeforeSearch();

            PayAsYouGoElement.Click();
            WaitForResultToBeBack();
        }

        public void SearchForNewlyCreatedProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            if (SearchButton == null)
                throw new Exception("Search button returned null");

            SearchButton.Click();
        }

        public void SearchWithContractId(string id)
        {
            LoggingService.WriteLogOnMethodEntry();
            ClearSearchCriteria();

            WaitForElementToExistByCssSelector(".js-mps-list.js-mps-searchable");
            ProposalIdSearchField.Clear();
            ProposalIdSearchField.SendKeys(id);

            SearchWithGo();
        }

        public void SearchForNewlyCreatedProposalByProposalId()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            var displayedProposal = string.Format(SelectedProposal, ContractId());
            var proposalElement = Driver.FindElement(By.CssSelector(displayedProposal));

            if (proposalElement == null)
                throw new Exception("Proposal Element is returned as null");

            proposalElement.Click();

            return GetInstance<ReportProposalSummaryPage>();
        }

        public ReportProposalSummaryPage ClickOnTheFirstProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProposalLinkElements == null)
                throw new Exception("Proposal Element is returned as null");

            ProposalLinkElements.ElementAt(0).Click();

            return GetInstance<ReportProposalSummaryPage>();
        }

        public void FilterAndClickAgreement(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);
            // note: from MpsLocalOfficeStepActions#NavigateToContractsSummaryPage(...)
            var agreementRowLinkElement = SeleniumHelper.SetListFilter(DataQuerySearchField, agreementId, VisibleItemDivElements, dataAttibuteName:"proposal-id"); 
            SeleniumHelper.ClickSafety(agreementRowLinkElement, IsUntilUrlChanges:true);
        }
    }
}
