using System;
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

        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/proposals/awaiting-approval']")]
        private IWebElement AwaitingApprovalLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/proposals/approved']")]
        private IWebElement ApprovedLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/proposals/declined']")]
        private IWebElement DeclinedLinkElement;

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

    }
}
