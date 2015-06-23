using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverContractPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/contracts/awaiting-acceptance\"] span")]
        private IWebElement AwaitingAcceptanceElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/contracts/rejected\"] span")]
        private IWebElement RejectedElement;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/local-office/contracts/approved-proposals\"] span")]
        private IWebElement DisplayedApprovedProposalTabElement;
        



        public void IsApprovedProposalTabAvailable()
        {
            if (DisplayedApprovedProposalTabElement == null)
                throw new Exception("Unable to locate Approved Proposals tab on dashboard page");

            AssertElementPresent(DisplayedApprovedProposalTabElement, "Approved Proposal tab");
        }

        public void NavigateToAwaitingAcceptanceTab()
        {
            if (AwaitingAcceptanceElement == null)
                throw new Exception("Unable to locate Awaiting Proposals tab on dashboard page");

            AwaitingAcceptanceElement.Click();
        }

        public void NavigateToRejectTab()
        {
            if (RejectedElement == null)
                throw new Exception("Unable to locate Rejected tab on dashboard page");

            RejectedElement.Click();
        }

        public void DownloadPDFOnBankContractPages()
        {
            ActionsModule.ClickOnTheActionsDropdown(Driver);
            ActionsModule.DownloadContractPDFAction(Driver);
        }

        public void DownloadInvoicePDFOnBankContractPages()
        {
            ActionsModule.ClickOnTheActionsDropdown(Driver);
            ActionsModule.DownloadContractInvoicePDFAction(Driver);
        }

        public void ClickOnActionButtonAgainstRelevantProposal(IWebDriver driver)
        {
            ScrollTo(ActionsModule.SpecificActionsDropdownElement(driver));
            ActionsModule.SpecificClickOnTheActionsDropdown(driver);
        }


        public void NavigateToAwaitingApprovalSummaryPage(IWebDriver driver)
        {
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }

        


    }
}
