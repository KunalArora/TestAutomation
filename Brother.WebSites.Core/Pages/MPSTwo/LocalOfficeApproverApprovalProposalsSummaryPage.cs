using Brother.Tests.Selenium.Lib.Helpers;
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

        public void ClickOnAccept()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety( ApproveButtonElement);
            SeleniumHelper.ClickSafety( AcceptButtonElement, RuntimeSettings.DefaultFindElementTimeout + 10, true); // Add 10 sec extra to timeout as approval processing takes time
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
