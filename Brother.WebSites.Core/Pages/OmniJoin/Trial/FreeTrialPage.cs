using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.Trial
{
    public class FreeTrialPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#txtFirstName")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtLastName")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtEmailAddress")]
        public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_txtPassword")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtConfirmPassword")]
        public IWebElement ConfirmPasswordTextBox;

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
            TestCheck.AssertIsEqual(firstName, GetTextBoxValue("txtFirstName"), "FirstName Text Box");
        }

        public void PopulateLastNameTextBox(string lastName)
        {
            LastNameTextBox.SendKeys(lastName);
            TestCheck.AssertIsEqual(lastName, GetTextBoxValue("txtLastName"), "LastName Text Box");
        }

        public void PopulateEmailAddressTextBox(string emailAddress)
        {
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueEmailAddress();
            }

            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(emailAddress);
            EmailAddressTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(emailAddress, GetTextBoxValue("txtEmailAddress"), "Email Address Text Box");
        }

        public void PopulateConfirmPasswordTextBox(string password)
        {
            ConfirmPasswordTextBox.SendKeys(password);
        }

        public void IsPopulatePasswordTextBoxAvailable()
        {
            if (PasswordTextBox == null)
            {
                throw new NullReferenceException("Unable to locate Password Text Box on page");
            }
            AssertElementPresent(PasswordTextBox, "Password Text Box (Free-trial)");
        }

        public void PopulatePasswordTextBox(string password)
        {
            IsPopulatePasswordTextBoxAvailable();
            PasswordTextBox.SendKeys(password);
        }

        public void PopulatePhoneNumberTextBox(string phoneNumber)
        {
            PhoneNumberTextBox.SendKeys(phoneNumber);
            TestCheck.AssertIsEqual(phoneNumber, GetTextBoxValue("content_0_maincontent_2_txtPhoneNumber"), "Phone Number Text Box");
        }

        public void AgreeToTermsAndConditions()
        {
            ScrollTo(TermsAndConditionsCheckBox);
            TermsAndConditionsCheckBox.Click();
            TestCheck.AssertIsEqual(TermsAndConditionsCheckBox.Selected.ToString(), "True", "Accept Terms and Conditions Button");
        }
    }
}
