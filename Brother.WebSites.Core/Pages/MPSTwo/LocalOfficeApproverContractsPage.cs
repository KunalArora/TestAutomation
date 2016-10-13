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
    public class LocalOfficeApproverContractsPage : BasePage
    {
        public static string Url = "/";
        private const string DownloadDirectory = @"C:/DataTest";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/approval/contracts/approved-proposals']")]
        public IWebElement ApprovedProposalsLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/approval/contracts/awaiting-acceptance']")]
        public IWebElement AwaitingAcceptancLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/approval/contracts/accepted']")]
        public IWebElement AcceptedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/approval/contracts/rejected']")]
        public IWebElement RejectedLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/approval/contracts/awaiting-acceptance\"] span")]
        public IWebElement OpenedAwaitingAcceptancLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-contract-list-container .table .js-mps-searchable tr")]
        public IList<IWebElement> ContractListContainerElement;
        [FindsBy(How = How.CssSelector, Using = ".separator a[href=\"/mps/local-office/manage-devices\"]")]
        public IWebElement LOApproverDeviceManagementElement;
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

        
        public void IsContractsSignedByDealerDisplayed()
        {
            
            var createdProposal = MpsUtil.CreatedProposal();
            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);
            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

       
        

        private IWebElement ActionButtonElementByName(string name, string tdcol)
        {
            string element = String.Format("//td[text()=\"{0}\"]/parent::tr/td[{1}]/div/button", name, tdcol);
            return Driver.FindElement(By.XPath(element));
        }

        public LocalOfficeApproverContractsSummaryPage NavigateToViewSummary()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<LocalOfficeApproverContractsSummaryPage>(Driver);
        }
        public void DownloadPDFOnBankContractPages()
        {
            ActionsModule.OpenTheFirstActionButton(Driver);
            ActionsModule.DownloadContractPDFAction(Driver);
        }

        private string DownloadFolderPath()
        {
            var path = "";

            if (IsAustriaSystem() || IsGermanSystem() || IsSwissSystem())
            {
                path = "file:///C:/DataTest/{0}-Vertrag.pdf";

            }
            else if (IsUKSystem() || IsIrelandSystem())
            {
                path = "file:///C:/DataTest/{0}-Contract.pdf";

            }
            else if (IsFranceSystem())
            {
                path = "file:///C:/DataTest/{0}-Contrat.pdf";

            }
            else if (IsItalySystem())
            {
                path = "file:///C:/DataTest/{0}-Contratto.pdf";
            }
            else if (IsSpainSystem())
            {
                path = "file:///C:/DataTest/{0}-Contrato.pdf";
               
            }
            else if (IsSwedenSystem())
            {
                path = "file:///C:/DataTest/{0}-Avtal.pdf";
            }
            else if (IsNetherlandSystem())
            {
                path = "file:///C:/DataTest/{0}-Contract.pdf";
            }else if (IsDenmarkSystem())
            {
                path = "file:///C:/DataTest/{0}-Kontrakt.pdf";
            }
            else if (IsPolandSystem())
            {
                path = "file:///C:/DataTest/{0}-Contract.pdf";

            }
            else if (IsBelgiumSystem())
            {
                path = BelgianPath();

            }
            
            

            return path;
        }


        private String BelgianPath()
        {
            string lang;
            string language;

            try
            {
                language = SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {

                language = "Dutch";
            }

            switch (language)
            {
                case "French":
                    lang = "file:///C:/DataTest/{0}-Contrat.pdf";
                    break;
                case "Dutch":
                    lang = "file:///C:/DataTest/Contract-{0}.pdf";
                    break;

                default:
                    lang = "file:///C:/DataTest/{0}-Contrat.pdf";
                    break;
            }

            return lang;
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

        
        public void IsContractsListAvailable()
        {
            if (ContractListContainerElement == null || !ContractListContainerElement.Any())
                throw new Exception("Unable to locate Contract List");

            AssertElementsPresent(ContractListContainerElement.ToArray(), "Contract List");
        }

        public LocalOfficeApproverDeviceManagementPage NavigateTOfficeDeviceManagementPage()
        {
            MpsJobRunnerPage.RunCreateCustomerAndPersonCommandJob();
            LOApproverDeviceManagementElement.Click();
            return GetInstance<LocalOfficeApproverDeviceManagementPage>(Driver);

        }
    }
}
