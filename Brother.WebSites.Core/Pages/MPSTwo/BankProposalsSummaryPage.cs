﻿using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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
        public IWebElement ApproveButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonDecline")]
        public IWebElement DeclineButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalDeclineReason_Input")]
        public IWebElement DeclineReasonElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonProposalDeclineDecline")]
        public IWebElement RejectButtonElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveCustomerReference_Input")]
        public IWebElement CustomerReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveContractReference_Input")]
        public IWebElement ReferenceElement;
        [FindsBy(How = How.Id, Using = "content_1_InputProposalApproveValidUntil_Input")]
        public IWebElement ValidUntilElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonProposalApproveApprove")]
        public IWebElement AcceptButtonElement;

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
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, RejectButtonElement);

            return GetTabInstance<BankOffersPage>(Driver);
        }

        public BankOffersPage ClickAccpetButton()
        {
            ScrollTo(AcceptButtonElement);
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, AcceptButtonElement);
            //WebDriver.Wait(Helper.DurationType.Second, 5);

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
            WebDriver.Wait(Helper.DurationType.Second, 3);
        }

    }
}
