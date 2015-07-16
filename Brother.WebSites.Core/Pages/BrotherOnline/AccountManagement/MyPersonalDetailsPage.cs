using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class MyPersonalDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["MyPersonalDetails"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = ".submit.button-blue")]
        public IWebElement UpdateDetailsButton;

        [FindsBy(How = How.CssSelector, Using = "#FNameText")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "LNameText")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.Id, Using = "content_2_innercontent_1_btnUpdateBasicDetails")]
        public IWebElement UpdateButtonDetails;

        [FindsBy(How = How.CssSelector, Using = ".info-bar")]
        public IWebElement InformationMessageBar;

        public void PopulateFirstNameTextBox(string firstname)
        {
           FirstNameTextBox.Clear();
           ScrollTo(FirstNameTextBox);
           FirstNameTextBox.SendKeys(firstname);
            //TestCheck.AssertIsEqual(firstName, GetTextBoxValue("FirstNameTextBox"), "FirstName Text Box");
        }
        public void PopulateLastNameTextBox(string lastname)
        {   
            LastNameTextBox.Clear();
            ScrollTo(LastNameTextBox);
            LastNameTextBox.SendKeys(lastname);
            TestCheck.AssertIsEqual(lastname, GetTextBoxValue("LastNameTextBox"), "LastName Text Box");
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
    }
}
