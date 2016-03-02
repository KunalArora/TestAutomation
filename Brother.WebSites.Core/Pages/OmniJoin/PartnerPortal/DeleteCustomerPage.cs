using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class DeleteCustomerPage : BasePage
    {

        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnDelete")]
        public IWebElement DeleteButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnCancel")]
        public IWebElement CancelButton;

        public void IsDeleteButtonDisplayed()
        {
            if (DeleteButton == null)
            {
                throw new Exception("unable to locate the button");
            }
            TestCheck.AssertIsEqual(true, DeleteButton.Displayed, " Is delete button displayed");
        }

        public ManageCustomersAndOrdersPage ClickCancel()
         {
            if (CancelButton == null)
            {
                throw new Exception("unable to locate the button");
            }
            CancelButton.Click();
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);
          
         }

    }
}
