using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverContractsPage : BasePage
    {
        public static string Url = "/";

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
            WebDriver.Wait(DurationType.Second, 3);
            var createdContract = MpsUtil.CreatedProposal();
            var newlyAdded = @"//td[text()='{0}']";
            newlyAdded = String.Format(newlyAdded, createdContract);

            var newContract = Driver.FindElement(By.XPath(newlyAdded));

            RunCreateCustomerAndPersonJob();

            TestCheck.AssertIsEqual(true, newContract.Displayed, "Is new sent to bank awaiting contract page?");
            
        }


        public void RunCreateCustomerAndPersonJob()
        {
            MPSJobRunnerPage.RunCreateCustomerAndPersonCommandJob();
        }

        private IWebElement ActionButtonElementByName(string name, string tdcol)
        {
            string element = String.Format("//td[text()=\"{0}\"]/parent::tr/td[{1}]/div/button", name, tdcol);
            return Driver.FindElement(By.XPath(element));
        }

        public LocalOfficeApproverContractsSummaryPage NavigateToViewSummary()
        {
            ActionsModule.ClickOnSpecificActionsElement();
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<LocalOfficeApproverContractsSummaryPage>(Driver);
        }
        public void DownloadPDFOnBankContractPages()
        {
            ActionsModule.OpenTheFirstActionButton(Driver);
            ActionsModule.DownloadContractPDFAction(Driver);
        }

        

        public void DownloadInvoicePDFOnBankContractPages()
        {
            ActionsModule.OpenTheFirstActionButton(Driver);
            ActionsModule.DownloadContractInvoicePDFAction(Driver);
        }

        public void IsContractsListAvailable()
        {
            if (ContractListContainerElement == null || !ContractListContainerElement.Any())
                throw new Exception("Unable to locate Contract List");

            AssertElementsPresent(ContractListContainerElement.ToArray(), "Contract List");
        }

        public LocalOfficeApproverDeviceManagementPage NavigateTOfficeDeviceManagementPage()
        {
            RunCreateCustomerAndPersonJob();
            LOApproverDeviceManagementElement.Click();
            return GetInstance<LocalOfficeApproverDeviceManagementPage>(Driver);

        }
    }
}
