﻿using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalProposalsSummaryPage : BaseSummaryPage, IPageObject
    {
        private const string _url = "/mps/local-office/approval/proposals/summary";
        private const string _validationElementSelector = ".btn-primary.pull-right"; // "#content_1_ButtonDownloadProposalPdf"

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonApprove")]
        public IWebElement ApproveButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonProposalApproveApprove")]
        public IWebElement AcceptButtonElement;

        [FindsBy(How = How.Id, Using = "content_1_ButtonDecline")]
        public IWebElement DeclineButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonProposalDeclineDecline")]
        public IWebElement FinalDeclineButtonElement;

        private const string InputReasonSelector = "#content_1_InputProposalDeclineReason_Input";

        public void ClickOnAccept(int timeout)
        {
            LoggingService.WriteLogOnMethodEntry(timeout);
            SeleniumHelper.ClickSafety( ApproveButtonElement, timeout);
            SeleniumHelper.ClickSafety( AcceptButtonElement, timeout,true);
        }

        public void DeclineProposal(string proposalDeclineReasonExpired, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(proposalDeclineReasonExpired,findElementTimeout);
            SeleniumHelper.ClickSafety(DeclineButtonElement, findElementTimeout);
            var InputReasonElement = SeleniumHelper.FindElementByCssSelector(InputReasonSelector, findElementTimeout);
            SeleniumHelper.SelectFromDropdownByText(InputReasonElement, proposalDeclineReasonExpired);
            SeleniumHelper.ClickSafety(FinalDeclineButtonElement, findElementTimeout);
        }
    }
}
