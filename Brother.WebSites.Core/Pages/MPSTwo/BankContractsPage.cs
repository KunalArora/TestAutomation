using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankContractsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/approved-proposals']")]
        private IWebElement ApprovedProposalsLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/awaiting-acceptance']")]
        private IWebElement AwaitingAcceptancLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/accepted']")]
        private IWebElement AcceptedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/rejected']")]
        private IWebElement RejectedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/invoices']")]
        private IWebElement InvoicesLinkElement;

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
            var createdContract = MpsUtil.CreatedProposal();
            var newlyAdded = @"//td[text()='{0}']";
            newlyAdded = String.Format(newlyAdded, createdContract);

            var newContract = Driver.FindElement(By.XPath(newlyAdded));

            TestCheck.AssertIsEqual(true, newContract.Displayed, "Is new sent to bank awaiting contract page?");
        }

        private IWebElement ActionButtonElementByName(string name, string tdcol)
        {
            string element = String.Format("//td[text()=\"{0}\"]/parent::tr/td[{1}]/div/button", name, tdcol);
            return Driver.FindElement(By.XPath(element));
        }

        public BankContractsSummaryPage NavigateToViewSummary()
        {
            string proposalname = MpsUtil.CreatedProposal();
            IWebElement element = ActionButtonElementByName(proposalname, "7");
            element.Click();
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<BankContractsSummaryPage>(Driver);
        }
    }
}
