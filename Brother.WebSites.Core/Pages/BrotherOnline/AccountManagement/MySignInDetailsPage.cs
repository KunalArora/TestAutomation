using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class MySignInDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["MySignInPreference"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href*='sign-out']")]
        public IWebElement SignOutLink;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_1_innerbottom_1_btnEmailUpdate.submit.button-blue")]
        public IWebElement UpdateDetailsButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_1_innerbottom_1_btnPasswordUpdate.submit.button-blue")]
        public IWebElement UpdatePasswordButton;

        [FindsBy(How = How.CssSelector, Using = ".info-bar")]
        public IWebElement InformationMessageBar;

        [FindsBy(How = How.CssSelector, Using = "#CurrentPWText")]
        public IWebElement CurrentPasswordEditBox;

        [FindsBy(How = How.CssSelector, Using = "#NewPWText")]
        public IWebElement NewPasswordEditBox;

        [FindsBy(How = How.CssSelector, Using = "#ConfirmNewPWText")]
        public IWebElement ConfirmNewPasswordEditBox;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_1_innerbottom_1_emailPasswordText")]
        public IWebElement CurrentPasswordEmailChangeEditBox;

        [FindsBy(How = How.CssSelector, Using = "#emailText")]
        public IWebElement EmailAddressEditBox;
        
        public void IsSignOutLinkAvailable()
        {
            if (SignOutLink == null)
            {
                throw new Exception("Unable to locate link on page");
            }
            AssertElementPresent(SignOutLink, "Sign Out Link");
        }

        // Clicks the Sign Out link and returns back to the Registration Page
        public RegistrationPage ClickSignOutLink()
        {
            if (SignOutLink == null)
            {
                throw new Exception("Unable to locate Sign Out Link");
            }
            SignOutLink.Click();
            return GetInstance<RegistrationPage>(Driver);
        }

        // Clicks the Update Password button
        public void ClickUpdateDetailsButton()
        {
            if (UpdateDetailsButton == null)
            {
                throw new Exception("Unable to locate Update Details Button");
            }
            ScrollTo(UpdateDetailsButton);
            UpdateDetailsButton.Click();
        }

        // Clicks the Update Password button
        public void ClickUpdatePasswordButton()
        {
            if (UpdatePasswordButton == null)
            {
                throw new Exception("Unable to locate Update Password Button");
            }
            ScrollTo(UpdatePasswordButton);
            UpdatePasswordButton.Click();
        }

        public void EnterExistingPasswordForEmailChange(string existingPassword)
        {
            if (CurrentPasswordEmailChangeEditBox == null)
            {
                throw new Exception("Unable to locate Current Password (Email Change) Edit Box");
            }
            ScrollTo(CurrentPasswordEmailChangeEditBox);
            CurrentPasswordEmailChangeEditBox.SendKeys(existingPassword);
        }

        public void VerifyEmailAddressValue(string emailAddress)
        {
            // need to re-find the Edit Control as it loses its object after an update
            EmailAddressEditBox = Driver.FindElement(By.CssSelector("#emailText"));
            if (EmailAddressEditBox == null)
            {
                throw new NullReferenceException("Error locating Email Address Edit box - returned null");
            }
            //TestCheck.AssertIsEqual(emailAddress, EmailAddressEditBox.GetAttribute("value"), "Email Address");
        }

        public void EnterEmailAddress(string newEmailAddress)
        {
            if (EmailAddressEditBox == null)
            {
                throw new Exception("Unable to locate Email Address Edit Box");
            }
            ScrollTo(EmailAddressEditBox);
            EmailAddressEditBox.Clear();
            EmailAddressEditBox.SendKeys(newEmailAddress);
            // Update email address with new one
            Email.RegistrationEmailAddress = newEmailAddress;
        }

        public void EnterExistingPassword(string existingPassword)
        {
            if (CurrentPasswordEditBox == null)
            {
                throw new Exception("Unable to locate Current Password Edit Box");
            }
            ScrollTo(CurrentPasswordEditBox);
            CurrentPasswordEditBox.SendKeys(existingPassword);
        }

        public void EnterNewPassword(string newPassword)
        {
            if (NewPasswordEditBox == null)
            {
                throw new Exception("Unable to locate New Password Edit Box");
            }
            ScrollTo(NewPasswordEditBox);
            NewPasswordEditBox.SendKeys(newPassword);
        }

        public void EnterNewPasswordToConfirm(string newPassword)
        {
            if (ConfirmNewPasswordEditBox == null)
            {
                throw new Exception("Unable to locate Confirm New Password Edit Box");
            }
            ScrollTo(ConfirmNewPasswordEditBox);
            ConfirmNewPasswordEditBox.SendKeys(newPassword);
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
