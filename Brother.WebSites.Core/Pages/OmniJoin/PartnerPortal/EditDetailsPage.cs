using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class EditDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".button-aqua")]
        public IWebElement DeleteCustomerLink;


        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnSave")]
        public IWebElement SaveButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnCancel")]
        public IWebElement CancelButton;


        public ManageCustomersAndOrdersPage ClickCancelButton()
        {
            if (CancelButton == null)
            {
                throw new Exception("Unable to locate the button");
            }
            CancelButton.Click();
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);
        }

        public DeleteCustomerPage ClickDeleteCustomerLink()
        {
            if (DeleteCustomerLink == null)
            {
                throw new Exception("Unable to locate the element");
            }
            DeleteCustomerLink.Click();
            return GetInstance<DeleteCustomerPage>(Driver);
         }

        public void IsSaveButtonDisplayed()
        {
            if (SaveButton == null)
            {
                throw new Exception(" unable to locate the button");
            }
            TestCheck.AssertIsEqual(true, SaveButton.Displayed, "Is save button displayed");
        }

    }
}
