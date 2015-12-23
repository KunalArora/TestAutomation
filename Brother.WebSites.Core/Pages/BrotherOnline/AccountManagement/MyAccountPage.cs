using System;
using System.Collections.Specialized;
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

        [FindsBy(How = How.Id, Using = "227d43a9-3489-4b80-b229-5b9366d978f0")]
        public IWebElement MyOrdersMenuItem;

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

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement FirstNameErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement LastNameErrorMessage;

       
        public IWebElement GetMyOrdersMenuItem()
        {
            if (MyOrdersMenuItem == null)
            {
                throw new Exception("Unable to locate My Orders Menu Item on page");
            }
            AssertElementPresent(MyOrdersMenuItem, "My Orders Menu Item");
            return MyOrdersMenuItem;
        }

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
        public void ClearFirstNameTextBox()
        {   
            ScrollTo(FirstNameTextBox);
            FirstNameTextBox.Clear();
            FirstNameTextBox.SendKeys(Keys.Tab);
        }
        public void ClearLastNameTextBox()
        {
            ScrollTo(LastNameTextBox);
            LastNameTextBox.Clear();
            LastNameTextBox.SendKeys(Keys.Tab);
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
           TestCheck.AssertIsEqual(displayed, InformationMessageBar.Displayed, "Information Message Bar");
        }
        public void FirstNameErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, FirstNameErrorMessage.Displayed, "Is Error Message Displayed");
        }
        public void LastNameErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, LastNameErrorMessage.Displayed, "Is Error Message Displayed");
        }
    }
}
