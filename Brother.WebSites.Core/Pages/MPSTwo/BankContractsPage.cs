using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankContractsPage : BasePage
    {
        public static string Url = "/";

        private const string DownloadDirectory = @"C:/DataTest";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/approved-proposals']")]
        public IWebElement ApprovedProposalsLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/awaiting-acceptance']")]
        public IWebElement AwaitingAcceptancLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/accepted']")]
        public IWebElement AcceptedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/rejected']")]
        public IWebElement RejectedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/invoices']")]
        public IWebElement InvoicesLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bank/contracts/awaiting-acceptance\"] span")]
        public IWebElement OpenedAwaitingAcceptancLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-contract-list-container .table .js-mps-searchable tr")]
        public IList<IWebElement> ContractListContainerElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-manage-devices")]
        public IWebElement ManageDevicesElement;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-download-contract-pdf")]
        public IWebElement DownloadContractPdfElement;
        

        

        

        public void IsApprovedProposalsLinkAvailable()
        {
            if (ApprovedProposalsLinkElement == null) 
                throw new Exception("Unable to locate Approved Proposals Link");

            AssertElementPresent(ApprovedProposalsLinkElement, "Create New Awaiting Approval Link");
        }

        public void IsAwaitingAcceptanceLinkAvailable()
        {
            if (AwaitingAcceptancLinkElement == null)
                throw new Exception("Unable to locate Approved");

            AssertElementPresent(AwaitingAcceptancLinkElement, "Create Awaiting Acceptance Link");
        }

        public void IsAwaitingAcceptancePageOpened()
        {
            if (OpenedAwaitingAcceptancLinkElement == null)
                throw new Exception("Unable to locate Approved");

            AssertElementPresent(OpenedAwaitingAcceptancLinkElement, "Opened Awaiting Acceptance Page");
        }

        public void IsAcceptedLinkAvailable()
        {
            if (AcceptedLinkElement == null)
                throw new Exception("Unable to locate Accepted");

            AssertElementPresent(AcceptedLinkElement, "Create New Accepted Link");
        }

        public void IsRejectedLinkAvailable()
        {
            if (RejectedLinkElement == null)
                throw new Exception("Unable to locate Rejected");

            AssertElementPresent(RejectedLinkElement, "Create New Rejected Link");
        }

        public void NavigateToAwaitingAcceptancePage()
        {
            IsAwaitingAcceptanceLinkAvailable();
            AwaitingAcceptancLinkElement.Click();
        }

        public void DownloadPDFOnBankContractPages()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.DownloadContractPDFAction(Driver);
        }

        public void DownloadFirstPDFOnBankContractPages()
        {
            ActionsModule.OpenTheFirstActionButton(Driver);
            ActionsModule.DownloadContractPDFAction(Driver);
        }

        public void DownloadInvoicePDFOnBankContractPages()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.DownloadContractInvoicePDFAction(Driver);
        }

        public void NavigateToAcceptedPage()
        {
            IsAcceptedLinkAvailable();
            AcceptedLinkElement.Click();
        }

        public void NavigateToRejectedPage()
        {
            IsRejectedLinkAvailable();
            RejectedLinkElement.Click();
        }

        public DealerManageDevicesPage NavigateToManageDevicesPage()
        {
            if(ManageDevicesElement == null)
                throw new Exception("Manage Device Element is not displayed");

            MpsJobRunnerPage.RunCreateCustomerAndPersonCommandJob();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ManageDevicesElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
            return GetInstance<DealerManageDevicesPage>(Driver);
        }
        
        public void IsContractsSignedByDealerDisplayed()
        {
            

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);

        }

        

        private string DownloadFolderPath()
        {
            var path = "";

            if (IsAustriaSystem() || IsGermanSystem())
            {
                path = "file:///C:/DataTest/{0}-Vertrag.pdf";

            } else if (IsUKSystem())
            {
                path = "file:///C:/DataTest/{0}-Contract.pdf";

            } else if (IsFranceSystem())
            {
                path = "file:///C:/DataTest/{0}-Contrat.pdf";

            } else if (IsItalySystem())
            {
                path = "file:///C:/DataTest/{0}-Contratto.pdf";
            }

            return path;
        }

        public void GetDownloadedPdfPath()
        {
            ActionsModule.OpenTheFirstActionButton(Driver);
            var contractid = DownloadContractPdfElement.GetAttribute("data-contract-id");
            SpecFlow.SetContext("DownloadedContractId", contractid);
            var downloadPath = String.Format(DownloadFolderPath(), contractid);
            SpecFlow.SetContext("DownloadedPdfPath", downloadPath);
            ActionsModule.OpenTheFirstActionButton(Driver);
            WebDriver.Wait(DurationType.Second, 10);

        }

        public void DisplayDownloadedPdf()
        {
            var downloadedPdf = DownloadedPdf();
            Driver.Navigate().GoToUrl(downloadedPdf);
        }

        private static string DownloadedPdf()
        {
            var downloadedPdf = SpecFlow.GetContext("DownloadedPdfPath");
            return downloadedPdf;
        }

        public void DoesPdfContentContainSomeText()
        {
            var contractId = SpecFlow.GetContext("DownloadedContractId");
            TestCheck.AssertTextContains(contractId, ExtractTextFromPdf(DownloadedPdf()), "Text is not available");
            Driver.Navigate().Back();
            PurgeDownloads(DownloadDirectory);
        }
        
        
       public BankContractsSummaryPage NavigateToViewSummary()
        {
            
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<BankContractsSummaryPage>(Driver);
        }

        public void IsContractsListAvailable()
        {
            if (ContractListContainerElement == null || !ContractListContainerElement.Any())
                throw new Exception("Unable to locate Contract List");

            AssertElementsPresent(ContractListContainerElement.ToArray(), "Contract List");
        }
    }
}
