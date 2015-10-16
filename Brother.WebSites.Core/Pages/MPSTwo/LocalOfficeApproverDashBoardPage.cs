using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverDashBoardPage : BasePage
    {
        public static string Url = "/mps/local-office/dashboard";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

       
        [FindsBy(How = How.CssSelector, Using = ".separator [href=\"/mps/local-office/approval\"]")]
        public IWebElement ApprovalTabElement;
        [FindsBy(How = How.CssSelector, Using = ".separator [href=\"/mps/local-office/manage-devices\"]")]
        public IWebElement DeviceManagementTabTabElement;


        public void IsApprovalLinkAvailable()
        {
            if (ApprovalTabElement == null)
                throw new Exception("Unable to locate Approval link on dashboard page");

            AssertElementPresent(ApprovalTabElement, "Create New Proposals Link");
        }


        public LocalOfficeApproverApprovalPage NavigateToOfficeApproverApprovalPage()
        {
            IsApprovalLinkAvailable();
            ApprovalTabElement.Click();

            return GetInstance<LocalOfficeApproverApprovalPage>(Driver);
        }

        

       
    }
}
