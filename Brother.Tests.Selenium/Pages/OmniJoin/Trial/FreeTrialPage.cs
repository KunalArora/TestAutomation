using System;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.OmniJoin.Trial
{
    public class FreeTrialPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return OmniJoinPageTitles.Default["FreeTrialPage"] + OmniJoinPageTitles.Default["LandingPage"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#txtFirstName")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtLastName")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtEmailAddress")]
        public IWebElement EmailAddressTextBox;

        //[FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_txtPassword")]
        //public IWebElement PasswordTextBox;

        //[FindsBy(How = How.CssSelector, Using = "#txtConfirmPassword")]
        //public IWebElement PasswordTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_txtPhoneNumber")]
        public IWebElement PhoneNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_chkMarketingOptIn")]
        public IWebElement SendInfoCheckBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_chkTerms")]
        public IWebElement TermsAndConditionsCheckBox;

        [FindsBy(How = How.CssSelector, Using = ".button-orange")]
        public IWebElement SubmitButton;

        public void IsSubmitButtonAvailable()
        {
            if (SubmitButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SubmitButton, "Submit (Free-trial) Button");
        }

        public FreeTrialDownloadPage SubmitButtonClick()
        {
            SubmitButton.Click();
            return GetInstance<FreeTrialDownloadPage>(Driver);
        }

        public void PopulateFirstNameTextBox(string firstName)
        {
            FirstNameTextBox.SendKeys(firstName);
            AssertIsEqual(firstName, GetTextBoxValue("txtFirstName"), "FirstName Text Box");
        }

        public void PopulateLastNameTextBox(string lastName)
        {
            LastNameTextBox.SendKeys(lastName);
            AssertIsEqual(lastName, GetTextBoxValue("txtLastName"), "LastName Text Box");
        }

        public void PopulateEmailAddressTextBox(string emailAddress)
        {
            EmailAddressTextBox.SendKeys(emailAddress);
            AssertIsEqual(emailAddress, GetTextBoxValue("txtEmailAddress"), "Email Address Text Box");
        }

        public void PopulatePhoneNumberTextBox(string phoneNumber)
        {
            PhoneNumberTextBox.SendKeys(phoneNumber);
            AssertIsEqual(phoneNumber, GetTextBoxValue("content_0_maincontent_2_txtPhoneNumber"), "Phone Number Text Box");
        }

        public void AgreeToTermsAndConditions()
        {
            ScrollTo(TermsAndConditionsCheckBox);
            TermsAndConditionsCheckBox.Click();
            AssertIsEqual(TermsAndConditionsCheckBox.Selected.ToString(), "True", "Accept Terms and Conditions Button");
        }
    }
}
