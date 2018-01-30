using Brother.Tests.Selenium.Lib.Helpers;
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
    public class LocalOfficeApproverProposalsPage : BasePage, IPageObject
    {
        public static string Url = "/";

        private const string _validationElementSelector = "table.dataTable";
        private const string _url = "/mps/local-office/approval/proposals/awaiting-approval";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }



        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";

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
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports\"]")]
        public IWebElement ReportTabElement;
        [FindsBy(How = How.Id, Using = "content_1_ProposalListFilter_InputFilterBy")]
        public IWebElement ProposalFilter;
        [FindsBy(How = How.CssSelector, Using = "[id*=content_1_SimpleProposalList_List_ProposalNameRow_]")]
        public IList<IWebElement> ProposalListProposalNameRowElement;

        public void IsAwaitingApprovalLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (AwaitingApprovalLinkElement == null) 
                throw new Exception("Unable to locate Awaiting Approval Link");

            AssertElementPresent(AwaitingApprovalLinkElement, "Create New Awaiting Approval Link");
        }

        public void IsApprovedLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ApprovedLinkElement == null)
                throw new Exception("Unable to locate Approved");

            AssertElementPresent(ApprovedLinkElement, "Create New Approved Link");
        }

        public void IsDeclinedLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (DeclinedLinkElement == null)
                throw new Exception("Unable to locate Declined");

            AssertElementPresent(ApprovedLinkElement, "Create New Declined Link");
        }

        public void IsProposalSentToLocalOfficeApproverAwaitingProposalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = MpsUtil.CreatedProposal();

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public ReportingDashboardPage NavigateToReportDashboardPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ReportTabElement == null)
                throw new Exception("Approved Proposals Link Element is returned as null");

            ReportTabElement.Click();

            return GetInstance<ReportingDashboardPage>();
        }

        private string Reason()
        {
            LoggingService.WriteLogOnMethodEntry();
            var reason = "";

            if (IsUKSystem()|| IsIrelandSystem())
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
            else if (IsSwedenSystem())
            {
                reason = "Annat";
            }
            else if (IsNetherlandSystem())
            {
                reason = "Overig";
            }
            else if (IsDenmarkSystem())
            {
                reason = "Andet";
            }
            else if (IsBelgiumSystem())
            {
                reason = BelgiumReason();
            }
            else if (IsSwissSystem())
            {
                reason = SwissReason();
            }
            else if (IsPolandSystem())
            {
                reason = "Inny";
            }
            else if (IsFinlandSystem())
            {
                reason = "Muu";
            }
            else if (IsNorwaySystem())
            {
                reason = "Annet";
            }
            
            return reason;
        }

        private string BelgiumReason()
        {
            LoggingService.WriteLogOnMethodEntry();
            var reason = "";
            var language = SpecFlow.GetContext("BelgianLanguage");

            switch (language)
            {
                case "French":
                    reason = "Autre";
                    break;
                case "Dutch" :
                    reason = "Andere";
                    break;
            }

            return reason;

        }

        private string SwissReason()
        {
            LoggingService.WriteLogOnMethodEntry();
            var reason = "";
            var language = SpecFlow.GetContext("BelgianLanguage");

            switch (language)
            {
                case "Français":
                    reason = "Autres";
                    break;
                case "Deutsch":
                    reason = "Andere";
                    break;
            }

            return reason;

        }


        public void SelectRejectionReason()
        {
            LoggingService.WriteLogOnMethodEntry();
            SelectFromDropdown(RejectionReasonDropdownElement, Reason());
        }

        public void EnterRejectionComment()
        {
            LoggingService.WriteLogOnMethodEntry();
            ClearAndType(RejectionCommentBoxElement, "It is rejected by auto");
        }

        public void ClickOnRejectionButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (RejectButtonElement == null)
                throw new Exception("Reject button not displayed, are you trying to reject the proposal?");
            RejectButtonElement.Click();
        }

        public void DeclineAnAwaitingApprovalProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            ClickOnDeclineButton();
            SelectRejectionReason();
            EnterRejectionComment();
            ClickOnRejectionButton();
            WebDriver.Wait(DurationType.Second, 3);
        }

        public void ClickOnDeclineButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (DeclineButtonElement == null)
                throw new Exception("Proposal Decline Button not displayed, are you on Offer Summary page?");
            //WebDriver.Wait(DurationType.Second, 3);
            ScrollTo(DeclineButtonElement);
            DeclineButtonElement.Click();
            WebDriver.Wait(DurationType.Second, 2);
        }

        public void IsProposalDeclined()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsProposalSentToBankAwaitingProposalPage();
        }

        public void IsProposalSentToBankAwaitingProposalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = MpsUtil.CreatedProposal();

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public void ClickOnActionButtonAgainstRelevantProposal()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
        }


        public void NavigateToAwaitingApprovalSummaryPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);
        }
        
        public LocalOfficeApproverProposalsSummaryPage NavigateToViewSummary()
        {
            LoggingService.WriteLogOnMethodEntry();
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<LocalOfficeApproverProposalsSummaryPage>(Driver);
        }

        public LocalOfficeApproverProposalsSummaryPage NavigateToViewSummary(string name)
        {
            LoggingService.WriteLogOnMethodEntry(name);
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<LocalOfficeApproverProposalsSummaryPage>(Driver);
        }

        public LocalOfficeApproverProposalsSummaryPage NavigateToProposalSummary()
        {
            LoggingService.WriteLogOnMethodEntry();
            WebDriver.Wait(DurationType.Second, 2);
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<LocalOfficeApproverProposalsSummaryPage>(Driver);
        }

        public void NavigateToAwaitingApprovalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsAwaitingApprovalLinkAvailable();
            AwaitingApprovalLinkElement.Click();
        }

        public void NavigateToDeclinedPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsDeclinedLinkAvailable();
            DeclinedLinkElement.Click();
        }

        public void NavigateToApprovedPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsApprovedLinkAvailable();
            ApprovedLinkElement.Click();
        }

        public void IsProposalSentToApproverAwaitingProposalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            var createdProposal = MpsUtil.CreatedProposal();

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public void VerifyDeclinedProposalIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsProposalSentToApproverAwaitingProposalPage();
        }

        public void VerifyApprovedProposalIsDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsProposalSentToApproverAwaitingProposalPage();
        }

        
        public void IsProposalListAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProposalListContainerElement == null || !ProposalListContainerElement.Any())
                throw new Exception("Unable to locate Proposal List");

            AssertElementsPresent(ProposalListContainerElement.ToArray(), "Proposal List");
        }

        public void ClickOnSummaryPage(int proposalId, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId,driver);
            ClearAndType(ProposalFilter, proposalId.ToString());
            SeleniumHelper.WaitUntil(d => ProposalListProposalNameRowElement.Count == 1 );
            SeleniumHelper.ClickSafety( SeleniumHelper.ActionsDropdownElement(actionsButton).Last());
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
        }

    }
}
