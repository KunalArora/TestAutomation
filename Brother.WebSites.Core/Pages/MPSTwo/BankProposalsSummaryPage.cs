using System;
using Brother.Tests.Selenium.Lib.Support;
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
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveCustomerReference_Input")]
        private IWebElement CustomerReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveContractReference_Input")]
        private IWebElement ReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveValidUntil_Input")]
        private IWebElement ValidUntilElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonProposalApproveApprove")]
        private IWebElement AcceptButtonElement;

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

        public BankOffersPage ClickAccpetButton()
        {
            ScrollTo(AcceptButtonElement);
            AcceptButtonElement.Click();

            return GetTabInstance<BankOffersPage>(Driver);
        }

        public void EnterCustomerReference(string str)
        {
            if (str.Equals(string.Empty))
                str = MpsUtil.CustomerReference();

            ClearAndType(CustomerReferenceElement, str);
        }

        public void EnterReference(string reference)
        {
            if (reference.Equals(string.Empty))
                reference = MpsUtil.CustomerReference();
            ClearAndType(ReferenceElement, reference);
        }

        public void EnterValidUntil()
        {
            ValidUntilElement.SendKeys(MpsUtil.SomeDaysFromToday());
        }

        public void EnterApprovalInformation()
        {
            EnterCustomerReference("");
            EnterReference("");
            EnterValidUntil();
        }

    }
}
