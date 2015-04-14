using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Account;
using Brother.Tests.Selenium.Lib.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherOnline.ThirdParty
{
    public class BrotherEmailConfirmationPage : BasePage
    {
        public static string Url = @"/Test/EmailConfirmationToken.aspx";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["BrotherEmailConfirmationPage"].ToString(); }
        }

        [FindsBy(How = How.Id, Using = "GetRegistrationLinkButton")]
        public IWebElement GetRegistrationLinkButton;

        [FindsBy(How = How.Id, Using = "LanguageDropDownList")] 
        public IWebElement LanguageDropDownList;

        [FindsBy(How = How.Id, Using = "EmailAddressTextBox")]
        public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.Id, Using = "ConfirmAccountHyperlink")]
        public IWebElement ConfirmAccountHyperlink;

        public void IsConfirmAccountHyperlinkAvailable()
        {
            if (ConfirmAccountHyperlink == null)
            {
                throw new NullReferenceException("Unable to locate link on page");
            }
            AssertElementPresent(ConfirmAccountHyperlink, "Confirm Account Hyperlink");
        }

        public void IsGetRegistrationLinkButtonAvailable()
        {
            if (GetRegistrationLinkButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(GetRegistrationLinkButton, "Get Registration Link Button");
        }

        public RegistrationPage ClickConfirmAccountHyperLink()
        {
            ConfirmAccountHyperlink.Click();
            return LoadSignInPage(Driver, BaseUrl);
        }

        public RegistrationPage GetConfirmAccountHyperLink()
        {
            var url = ConfirmAccountHyperlink.Text;
            return LoadSignInPage(Driver, url);
        }

        public void ClickGetRegistrationLinkButton()
        {
            GetRegistrationLinkButton.Click();
        }

        public void EnterEmailToValidate(string emailAddress)
        {
            EmailAddressTextBox.SendKeys(emailAddress);
            AssertIsEqual(emailAddress, GetTextBoxValue("EmailAddressTextBox"), "Email Address Text Box");   
        }

        public void SelectLanguage(string locale)
        {
            var language = GetSiteLanguage(locale);
            SelectFromDropdown(LanguageDropDownList, language);
            AssertItemIsSelected(LanguageDropDownList, language, "Language Drop Down List");
        }

        private string GetSiteLanguage(string locale)
        {
            switch (locale)
            {
                case "uk":
                    return "English : English";

                case "ie":
                    return "English (Ireland) : English (Ireland)";

                default:
                    return "English : English";
            }
        }
    }
}
