using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class MyAccountPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".content-wrapper.my-invoices")]
        public IWebElement InvoiceSection;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_InvoicesRepeater_tablerow_0")]
        public IWebElement InvoiceRow;

        [FindsBy(How = How.CssSelector, Using = "#content_2_navigationcontainer_0_MenuItemsRepeater_LeftMenuLink_9")]
        public IWebElement SignInDetailsMenu;
        [FindsBy(How = How.CssSelector, Using = ".submit.button-blue")]
        public IWebElement UpdateDetailsButton;

        [FindsBy(How = How.CssSelector, Using = "#FNameText")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#LNameText")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.Id, Using = "content_2_innercontent_1_btnUpdateBasicDetails")]
        public IWebElement UpdateButtonDetails;

        [FindsBy(How = How.CssSelector, Using = ".info-bar")]
        public IWebElement InformationMessageBar;

        public void IsInvoiceSectionAvailable()
        {
            if (InvoiceSection == null)
            {
                throw new Exception("Unable to locate Invoice Section on page");
            }
            AssertElementPresent(InvoiceSection, "Invoice Section");
        }

        public void VerifyInvoiceIsDisplayed()
        {
            if (!InvoiceRow.Displayed)
            {
                throw new Exception("Unable to locate Invoice Column on page");
            }
            AssertElementPresent(InvoiceRow, "Invoice Column");
        }

        public void PopulateFirstNameTextBox(string firstname)
        {
            FirstNameTextBox.Clear();
            ScrollTo(FirstNameTextBox);
            FirstNameTextBox.SendKeys(firstname);
            
        }
        public void PopulateLastNameTextBox(string lastname)
        {
            FirstNameTextBox.SendKeys(Keys.Tab);
            LastNameTextBox.SendKeys(lastname);
        }
        public void IsUpdateButtonAvailable()
        {
            if (UpdateButtonDetails == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(UpdateButtonDetails, "Update Button");
        }

        public void UpdateButtonClick()
        {
            if (UpdateButtonDetails == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(UpdateButtonDetails, "Update Details Button");
        }
        public void ClickUpdateDetailsButton()
        {
            if (UpdateButtonDetails == null)
            {
                throw new Exception("Unable to locate Update Details Button");
            }
            ScrollTo(UpdateButtonDetails);
            UpdateButtonDetails.Click();
        }
        public void ValidateInformationMessageBarStatus(bool displayed)
        {
            if (InformationMessageBar == null)
            {
                throw new Exception("Unable to locate Information Message Bar");
            }
            ScrollTo(InformationMessageBar);
           // TestCheck.AssertIsEqual(displayed, InformationMessageBar.Displayed, "Information Message Bar");
        }
    }
}
