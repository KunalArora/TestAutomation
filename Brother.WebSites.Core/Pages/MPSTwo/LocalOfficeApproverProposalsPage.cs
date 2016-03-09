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
    public class LocalOfficeApproverProposalsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/approval/proposals/awaiting-approval']")]
        public IWebElement AwaitingApprovalLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/approval/proposals/approved']")]
        public IWebElement ApprovedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/approval/proposals/declined']")]
        public IWebElement DeclinedLinkElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonDecline")]
        public IWebElement DeclineButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonApprove")]
        public IWebElement ApproveButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputProposalDeclineReason_Input")]
        public IWebElement RejectionReasonDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputProposalDeclineComment_Input")]
        public IWebElement RejectionCommentBoxElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonProposalDeclineDecline")]
        public IWebElement RejectButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonProposalDeclineCancel")]
        public IWebElement RejectionCancelButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-proposal-list-container .table .js-mps-searchable tr")]
        public IList<IWebElement> ProposalListContainerElement;

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
                throw new Exception("Unable to locate Declined");

            AssertElementPresent(ApprovedLinkElement, "Create New Declined Link");
        }

        public void IsProposalSentToLocalOfficeApproverAwaitingProposalPage()
        {
            var createdProposal = MpsUtil.CreatedProposal();

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        private string Reason()
        {
            var reason = "";

            if (IsUKSystem())
            {
                reason = "Other";

            }
            else if (IsFranceSystem())
            {
                reason = "Autre";

            }
            else if (IsItalySystem())
            {
                reason = "Scaduta";
            }
            else if (IsGermanSystem() || IsAustriaSystem())
            {
                reason = "Andere";
            }
            else if (IsSpainSystem())
            {
                reason = "Otro";
            }

            return reason;
        }


        public void SelectRejectionReason()
        {
            SelectFromDropdown(RejectionReasonDropdownElement, Reason());
        }

        public void EnterRejectionComment()
        {
            ClearAndType(RejectionCommentBoxElement, "It is rejected by auto");
        }

        public void ClickOnRejectionButton()
        {
            if (RejectButtonElement == null)
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

        public void ClickOnDeclineButton()
        {
            if (DeclineButtonElement == null)
                throw new Exception("Proposal Decline Button not displayed, are you on Offer Summary page?");
            //WebDriver.Wait(DurationType.Second, 3);
            ScrollTo(DeclineButtonElement);
            DeclineButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void IsProposalDeclined()
        {
            IsProposalSentToBankAwaitingProposalPage();
        }

        public void IsProposalSentToBankAwaitingProposalPage()
        {
            var createdProposal = MpsUtil.CreatedProposal();

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public void ClickOnActionButtonAgainstRelevantProposal()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
        }


        public void NavigateToAwaitingApprovalSummaryPage(IWebDriver driver)
        {
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }
        
        public LocalOfficeApproverProposalsSummaryPage NavigateToViewSummary()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<LocalOfficeApproverProposalsSummaryPage>(Driver);
        }

        public LocalOfficeApproverProposalsSummaryPage NavigateToViewSummary(string name)
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<LocalOfficeApproverProposalsSummaryPage>(Driver);
        }

        public LocalOfficeApproverProposalsSummaryPage NavigateToProposalSummary()
        {
            WebDriver.Wait(DurationType.Second, 2);
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<LocalOfficeApproverProposalsSummaryPage>(Driver);
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

        public void IsProposalSentToApproverAwaitingProposalPage()
        {
            var createdProposal = MpsUtil.CreatedProposal();

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public void VerifyDeclinedProposalIsDisplayed()
        {
            IsProposalSentToApproverAwaitingProposalPage();
        }

        public void VerifyApprovedProposalIsDisplayed()
        {
            IsProposalSentToApproverAwaitingProposalPage();
        }

        
        public void IsProposalListAvailable()
        {
            if (ProposalListContainerElement == null || !ProposalListContainerElement.Any())
                throw new Exception("Unable to locate Proposal List");

            AssertElementsPresent(ProposalListContainerElement.ToArray(), "Proposal List");
        }
    }
}
