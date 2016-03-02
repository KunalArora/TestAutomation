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
    public class BankOffersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/proposals/awaiting-approval']")]
        public IWebElement AwaitingApprovalLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/proposals/approved']")]
        public IWebElement ApprovedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/proposals/declined']")]
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
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputProposalDeclineBankCustomerNumber_Input")]
        public IWebElement RejectionCustomerNumberElement;

        
        

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
            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);
            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }


        public void IsProposalDeclined()
        {
            IsProposalSentToBankAwaitingProposalPage();
        }

        public void NavigateToAwaitingApprovalSummaryPage(IWebDriver driver)
        {
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }

        public void ClickOnActionButtonAgainstRelevantProposal()
        {
            ScrollTo(ActionsModule.SpecificActionsDropdownElement(Driver));
            ActionsModule.ClickOnSpecificActionsElement(Driver);
        }

        public void ClickOnDeclineButton()
        {
            if(DeclineButtonElement == null)
                throw new Exception("Proposal Decline Button not displayed, are you on Offer Summary page?");
            //WebDriver.Wait(DurationType.Second, 3);
            ScrollTo(DeclineButtonElement);
            DeclineButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 5);
        }

        public void SelectRejectionReason()
        {
            if (IsAustriaSystem() || IsGermanSystem())
            {
                SelectFromDropdown(RejectionReasonDropdownElement, "Andere");

            } else if (IsUKSystem())
            {
                SelectFromDropdown(RejectionReasonDropdownElement, "Other");
            }
            else if (IsItalySystem())
            {
                SelectFromDropdown(RejectionReasonDropdownElement, "Scaduta");
            }
            else if (IsFranceSystem())
            {
                SelectFromDropdown(RejectionReasonDropdownElement, "Autre");
            }
        }

        public void EnterRejectionCustomerNumber()
        {
            if (IsGermanSystem())
            {
                ClearAndType(RejectionCustomerNumberElement, MpsUtil.CustomerReference());
            }
        }

        public void EnterRejectionComment()
        {
            ClearAndType(RejectionCommentBoxElement, "It is rejected by auto");
        }

        public void ClickOnRejectionButton()
        {
            if(RejectButtonElement == null)
                throw new Exception("Reject button not displayed, are you trying to reject the proposal?");
            //RejectButtonElement.Click();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, RejectButtonElement);
        }

        public void DeclineAnAwaitingApprovalProposal()
        {
            ClickOnDeclineButton();
            SelectRejectionReason();
            EnterRejectionCustomerNumber();
            EnterRejectionComment();
            ClickOnRejectionButton();
            WebDriver.Wait(DurationType.Second, 3);
        }

        private IWebElement ActionButtonElementByName(string name)
        {
            //var element = String.Format("//td[text()=\"{0}\"]", name);

            //return Driver.FindElement(By.XPath(element));

            return ActionsModule.SpecificActionsDropdownElement(Driver);
        }

        public BankProposalsSummaryPage NavigateToViewSummary()
        {
            var element = ActionsModule.SpecificActionsDropdownElement(Driver);
            ScrollTo(element);
            element.Click();
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<BankProposalsSummaryPage>(Driver);
        }

        public BankProposalsSummaryPage NavigateToViewSummary(string name)
        {
            var element = ActionsModule.SpecificActionsDropdownElement(Driver);
            ScrollTo(element);
            element.Click();
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<BankProposalsSummaryPage>(Driver);
        }

        public BankProposalsSummaryPage NavigateToProposalSummary()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver); 
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<BankProposalsSummaryPage>(Driver);
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
            var name = SpecFlow.GetContext("GeneratedProposalName");

            AssertElementPresent(ActionButtonElementByName(name), "The proposal is not found");
        }

        public void VerifyApprovedProposalIsDisplayed()
        {
            var name = SpecFlow.GetContext("GeneratedProposalName");

            AssertElementPresent(ActionButtonElementByName(name), "The proposal is not found");
        }

        public void IsAllTheDeclinedProposalDisplayed()
        {
            
        }

        public void IsProposalListAvailable()
        {
            if (ProposalListContainerElement == null || !ProposalListContainerElement.Any())
                throw new Exception("Unable to locate Proposal List");

            AssertElementsPresent(ProposalListContainerElement.ToArray(), "Proposal List");
        }
    }
}
