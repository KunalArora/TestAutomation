using Brother.Tests.Selenium.Lib.Support.MPS;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

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
        // TODO OIKE
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveValidUntil_Input")]
        public IWebElement InputProposalApproveValidUntilElement;

        private const string InputReasonSelector = "#content_1_InputProposalDeclineReason_Input";

        public void ClickOnAccept()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety( ApproveButtonElement);
            // TODO OIKE TEST環境def値あらへん。仮対応。 ASKまち。
            if (string.IsNullOrWhiteSpace(InputProposalApproveValidUntilElement.GetAttribute("value")))
            {
                // fill to requred field
                InputProposalApproveValidUntilElement.SendKeys(MpsUtil.DateTimeString(DateTime.Today.AddDays(1)));
            }
            //
            SeleniumHelper.ClickSafety( AcceptButtonElement, RuntimeSettings.DefaultFindElementTimeout, true);
        }

        public void DeclineProposal(string proposalDeclineReasonExpired)
        {
            LoggingService.WriteLogOnMethodEntry(proposalDeclineReasonExpired);
            SeleniumHelper.ClickSafety(DeclineButtonElement);
            var InputReasonElement = SeleniumHelper.FindElementByCssSelector(InputReasonSelector);
            SeleniumHelper.SelectFromDropdownByText(InputReasonElement, proposalDeclineReasonExpired);
            SeleniumHelper.ClickSafety(FinalDeclineButtonElement,IsUntilUrlChanges:true);
        }
    }
}
