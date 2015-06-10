using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankOffersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/proposals/awaiting-approval']")]
        private IWebElement AwaitingApprovalLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/proposals/approved']")]
        private IWebElement ApprovedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/proposals/declined']")]
        private IWebElement DeclinedLinkElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonDecline")]
        private IWebElement DeclineButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonApprove")]
        private IWebElement ApproveButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputProposalDeclineReason_Input")]
        private IWebElement RejectionReasonDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputProposalDeclineComment_Input")]
        private IWebElement RejectionCommentBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonProposalDeclineDecline")]
        private IWebElement RejectButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonProposalDeclineCancel")]
        private IWebElement RejectionCancelButtonElement;
        
        

        public void IsAwaitingApprovalLinkAvailable()
        {
            if (AwaitingApprovalLinkElement == null) 
                throw new Exception("Unable to locate Awaiting Approval Link");

            AssertElementPresent(AwaitingApprovalLinkElement, "Create New Awaiting Approval Link");
        }

        public void IsApprovedLinkAvailable()
        {
            if (ApprovedLinkElement == null)
                throw new Exception("Unable to locate Approved");

            AssertElementPresent(ApprovedLinkElement, "Create New Approved Link");
        }

        public void IsDeclinedLinkAvailable()
        {
            if (DeclinedLinkElement == null)
                throw new Exception("Unable to locate Delicind");

            AssertElementPresent(ApprovedLinkElement, "Create New Delicind Link");
        }
        
        public void IsProposalSentToBankAwaitingProposalPage()
        {
            var createdProposal = MpsUtil.CreatedProposal();
            var newlyAdded = @"//td[text()='{0}']";
            newlyAdded = String.Format(newlyAdded, createdProposal);

            var newProposal = Driver.FindElement(By.XPath(newlyAdded));

            TestCheck.AssertIsEqual(true, newProposal.Displayed, "Is new sent to bank awaiting proposal page?");
        }


        public void IsProposalDeclined()
        {
            IsProposalSentToBankAwaitingProposalPage();
        }

        public void NavigateToAwaitingApprovalSummaryPage(IWebDriver driver)
        {
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }

        public void ClickOnActionButtonAgainstRelevantProposal(IWebDriver driver)
        {
            ScrollTo(ActionsModule.SpecificActionsDropdownElement(driver));
            ActionsModule.SpecificClickOnTheActionsDropdown(driver);
        }

        public void ClickOnDeclineButton()
        {
            if(DeclineButtonElement == null)
                throw new Exception("Proposal Decline Button not displayed, are you on Offer Summary page?");
            WebDriver.Wait(DurationType.Second, 3);
            ScrollTo(DeclineButtonElement);
            DeclineButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 5);
        }

        public void SelectRejectionReason()
        {
            SelectFromDropdown(RejectionReasonDropdownElement, "Other");
        }

        public void EnterRejectionComment()
        {
            ClearAndType(RejectionCommentBoxElement, "It is rejected by auto");
        }

        public void ClickOnRejectionButton()
        {
            if(RejectButtonElement == null)
                throw new Exception("Reject button not displayed, are you trying to reject the proposal?");
            RejectButtonElement.Click();
        }

        public void DeclineAnAwaitingApprovalProposal()
        {
            ClickOnDeclineButton();
            SelectRejectionReason();
            EnterRejectionComment();
            ClickOnRejectionButton();
            WebDriver.Wait(DurationType.Second, 3);
        }

        private IWebElement ActionButtonElementByName(string name, string tdcol)
        {
            string element = String.Format("//td[text()=\"{0}\"]/parent::tr/td[{1}]/div/button", name, tdcol);
            return Driver.FindElement(By.XPath(element));
        }

        public BankProposalsSummaryPage NavigateToViewSummary()
        {
            string proposalname = MpsUtil.CreatedProposal();
            IWebElement element = ActionButtonElementByName(proposalname, "6");
            element.Click();
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<BankProposalsSummaryPage>(Driver);
        }

        public BankProposalsSummaryPage NavigateToViewSummary(string name)
        {
            IWebElement element = ActionButtonElementByName(name, "6");
            StoreProposalName(name);
            element.Click();
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<BankProposalsSummaryPage>(Driver);
        }

        public BankProposalsSummaryPage NavigateToProposalSummary()
        {
            ActionsModule.SpecificClickOnTheActionsDropdown(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<BankProposalsSummaryPage>(Driver);
        }

        private void StoreProposalName(string name)
        {
            SpecFlow.SetContext("ProposalNameByBank", name);
        }

        public void NavigateToAwaitingApprovalPage()
        {
            IsAwaitingApprovalLinkAvailable();
            AwaitingApprovalLinkElement.Click();
        }

        public void NavigateToDeclinedPage()
        {
            IsDeclinedLinkAvailable();
            DeclinedLinkElement.Click();
        }

        public void NavigateToApprovedPage()
        {
            IsApprovedLinkAvailable();
            ApprovedLinkElement.Click();
        }

        public void VerifyDeclinedProposalIsDisplayed()
        {
            string name = SpecFlow.GetContext("ProposalNameByBank");

            AssertElementPresent(ActionButtonElementByName(name, "7"), "The proposal is not found");
        }

        public void VerifyApprovedProposalIsDisplayed()
        {
            string name = SpecFlow.GetContext("ProposalNameByBank");

            AssertElementPresent(ActionButtonElementByName(name, "7"), "The proposal is not found");
        }

        public void IsAllTheDeclinedProposalDisplayed()
        {
            
        }
    }
}
