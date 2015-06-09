using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankProposalsSummaryPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_ButtonApprove")]
        private IWebElement ApproveButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDecline")]
        private IWebElement DeclineButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalDeclineReason_Input")]
        private IWebElement DeclineReasonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonProposalDeclineDecline")]
        private IWebElement RejectButtonElement;

        public void ClickApproveButton()
        {
            ApproveButtonElement.Click();
        }

        public void ClickDeclineButton()
        {
            ScrollTo(DeclineButtonElement);
            DeclineButtonElement.Click();
        }

        public void SelectDeclineReason(string reason)
        {
            SelectFromDropdown(DeclineReasonElement, reason);
        }

        public BankOffersPage ClickRejectButton()
        {
            ScrollTo(RejectButtonElement);
            RejectButtonElement.Click();

            return GetTabInstance<BankOffersPage>(Driver);
        }
    }
}
