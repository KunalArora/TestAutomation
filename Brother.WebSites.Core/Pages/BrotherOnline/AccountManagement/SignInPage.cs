using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class SignInPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '#Existing')]")]
        public IWebElement ExistingUserTab;

        [FindsBy(How = How.CssSelector, Using = "#lnkForgottenPassword")]
        public IWebElement ForgottenPasswordLink;

        [FindsBy(How = How.CssSelector, Using = "#email")]
        public IWebElement EnterEmailId;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='spanEmailNotValidError']/*/*")] 
        public IWebElement EmailAddressErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary.btn--forgotpassword")]
        public IWebElement SendEmailButton;

        [FindsBy(How = How.CssSelector, Using = "#password")] 
        public IWebElement EnterPassword;

        [FindsBy(How = How.Id, Using = "btnSignin")]
        public IWebElement SignInButton;

        public void ClickExistingUserTab()
        {
            ExistingUserTab.Click();
        }
        public void ClickForgottenPasswordLink()
        {
            ForgottenPasswordLink.Click();
        }
        public void PopulateInvalidEmailAddress(string emailid)
        {
            EnterEmailId.SendKeys(emailid);
        }
        public void VerifyErrorMessageExist()
        {
            TestCheck.AssertIsEqual(true, EmailAddressErrorMessage.Displayed, "Is Email Error message displayed");
        }
        public void PopulateValidEmailAddress(string emailid)
        {
            EnterEmailId.SendKeys(emailid);
        }
        public void ClickSendButton()
        {
            SendEmailButton.Click();
        }
        public void PopulatePassword(string password)
        {
            EnterPassword.SendKeys(password);
        }
        public ProductRegistrationPage ClickSignInButton()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<ProductRegistrationPage>(Driver);  
        }

    }
}
