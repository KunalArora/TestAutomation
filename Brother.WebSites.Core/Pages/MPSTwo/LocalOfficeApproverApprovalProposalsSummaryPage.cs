using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

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

        public void ClickOnAccept(int timeout)
        {
            SeleniumHelper.ClickSafety( ApproveButtonElement, timeout);
            SeleniumHelper.ClickSafety( AcceptButtonElement, timeout);
        }
    }
}
