using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement.PaymentMethods
{
    public class AddNewCardPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".billing-change.button-grey")]
        public IWebElement ChangeBillingAddressButton;

        // added locator
        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_1_ChangeBtn")]
        public IWebElement AddNewCardChangeBillingAddressButton;

        public void IsChangeBillingAddressButtonAvailable()
        {
            if (ChangeBillingAddressButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(ChangeBillingAddressButton, "Change Billing Address Button");
        }

        // added method
        public void IsAddNewCardChangeBillingAddressButtonAvailable()
        {
            if (AddNewCardChangeBillingAddressButton  == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(AddNewCardChangeBillingAddressButton, "AddNewCard Change Billing Address Button");
        }
        public void ChangeBillingAddressButtonClick()
        {
            ChangeBillingAddressButton.Click();
        }

    }
}
